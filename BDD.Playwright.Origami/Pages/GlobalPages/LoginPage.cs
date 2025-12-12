using BDD.Playwright.Core.Interfaces;
using BDD.Playwright.GBIZ.PageElements;
using BDD.Playwright.GBIZ.Pages.CommonPage;
using BDD.Playwright.GBIZ.Pages.XpathProperties;
using Microsoft.Playwright;
using Reqnroll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDD.Playwright.GBIZ.Pages.GlobalPages
{
    public class LoginPage : BasePage
    {
        //public CommonXpath _commonXpath;
        private readonly string _scenarioTitle;
        private readonly IFileReader _fileReader;
        public CommonXpath _commonXpath;
        public LoginPage(ScenarioContext scenarioContext, IFileReader fileReader, CommonXpath commonXpath) : base(scenarioContext)
        {

            //PageFactory.InitElements(Driver, this);
            //_commonXpath = commonXpath;
            _scenarioTitle = scenarioContext.ScenarioInfo.Title;
            _fileReader = fileReader;
            _commonXpath = commonXpath;

        }
        #region Xpath
        #endregion
        public async Task LoginAsync()
        {
            if (_fileReader == null)
            {
                throw new InvalidOperationException("FileReader is not available. Use constructor with IFileReader parameter.");
            }

            try
            {
                var filePath = "AgentLogin.json";
                var profileKey = "Agent_TC11";

                var accountType = _fileReader.GetOptionalValue(filePath, $"{profileKey}.Account");
                var userName = _fileReader.GetOptionalValue(filePath, $"{profileKey}.UserName");
                var password = _fileReader.GetOptionalValue(filePath, $"{profileKey}.Password");

                await page.WaitForLoadStateAsync(LoadState.NetworkIdle);

                if (accountType == "Agents")
                {
                    await Button.ClickButtonAsync(_commonXpath.AgentPortal, ActionType.Click, true, 1, "Agents");
                }
                else if (accountType == "Members")
                {
                    await Button.ClickButtonAsync(_commonXpath.Members, ActionType.Click, true, 1, "Members");
                }

                await InputField.SetTextAreaInputFieldAsync(_commonXpath.UsernameInp, userName, true, 1, "UserName");
                await InputField.SetTextAreaInputFieldAsync(_commonXpath.PasswordInp, password, true, 1, "Password");
                await Button.ClickButtonForStaleElementWithoutDepenAsync(_commonXpath.SignInBtn, ActionType.Click, true, 1, "Login");

                logger.WriteLine("User logged into GBIZ successfully.");
                await page.WaitForLoadStateAsync(LoadState.NetworkIdle);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error during login for profile: {ex.Message}", ex);
            }
        }

        //private string AgentPortal => "//button[text()='Agents']";
        // private string Members => "//button[text()='Members']";
        // private string UsernameInp => "//input[@id='username']";
        // private string PasswordInp => "//input[@id='password']";
        // private string SignInBtn => "//button[text()='Sign In']";

        public async Task LoginUsingJSONAsync()
        {
            if (_fileReader == null)
            {
                throw new InvalidOperationException("FileReader is not available. Use constructor with IFileReader parameter.");
            }

            try
            {
               
                var filePath = "AgentLogin.json";
                var profileKey = "Agent_TC11";

                var accountType = _fileReader.GetOptionalValue(filePath, $"{profileKey}.Account");
                var userName = _fileReader.GetOptionalValue(filePath, $"{profileKey}.UserName");
                var password = _fileReader.GetOptionalValue(filePath, $"{profileKey}.Password");

                await page.WaitForLoadStateAsync(LoadState.NetworkIdle);
                if (accountType == "Agents")
                {
                    await Button.ClickButtonAsync(_commonXpath.AgentPortal, ActionType.Click, true, 1, "Agents");
                }
                else if (accountType == "Members")
                {
                    await Button.ClickButtonAsync(_commonXpath.Members, ActionType.Click, true, 1, "Members");
                }

                await InputField.SetTextAreaInputFieldAsync(_commonXpath.UsernameInp, userName, true, 1, "UserName");
                await InputField.SetTextAreaInputFieldAsync(_commonXpath.PasswordInp, password, true, 1, "Password");
                await Button.ClickButtonAsync(_commonXpath.SignInBtn, ActionType.Click, true, 1, "Login");

                logger.WriteLine("User logged into GBIZ successfully.");
            }
            catch (Exception ex)
            {
                throw new Exception($"Error during login for profile: {ex.Message}", ex);
            }
        }
    }
}

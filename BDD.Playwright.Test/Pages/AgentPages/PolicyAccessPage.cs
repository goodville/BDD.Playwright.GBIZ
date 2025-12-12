using BDD.Playwright.Core.Interfaces;
using BDD.Playwright.Core.Loggers;
using BDD.Playwright.GBIZ.PageElements;
using BDD.Playwright.GBIZ.Pages.CommonPage;
using BDD.Playwright.GBIZ.Pages.GlobalPages;
using BDD.Playwright.GBIZ.Pages.PublicPages;
using BDD.Playwright.GBIZ.Pages.XpathProperties;
using Microsoft.Playwright;
using Reqnroll;
using System;
using System.Threading.Tasks;

namespace BDD.Playwright.GBIZ.Pages.AgentPages
{
    public class PolicyAccessPage : BasePage
    {
        private readonly ScenarioContext _scenarioContext;
        public FeatureContext _featureContext;
        public CommonXpath _commonXpath;
        private readonly ApplicationLogger _applicationLogger;
        public LoginPage _loginPage;
        public ReportAClaimStartPage _reportAClaimStartPage;
        public ReportAClaimFormPage _reportAClaimFormPage;
        private readonly IFileReader _fileReader;
        private readonly IReqnrollOutputHelper _reqnrollLogger;

        // Constructor
        public PolicyAccessPage(
            ScenarioContext scenarioContext,
            LoginPage loginPage,
            CommonXpath commonXpath,
            ReportAClaimStartPage reportAClaimStartPage,
            ReportAClaimFormPage reportAClaimFormPage,
            IFileReader fileReader
        ) : base(scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _loginPage = loginPage;
            _commonXpath = commonXpath;
            _reportAClaimStartPage = reportAClaimStartPage;
            _reportAClaimFormPage = reportAClaimFormPage;
            _fileReader = fileReader;
            // Optionally: await _commonFunctions.ReadTestDataForClaimPageAsync();
        }

        #region Xpath
        public string Access_Link => "//a[contains(text(),'ACCESS')]";
        public string Remove_Link => "//div[./div[./span[contains(text(),'{0}')]]]/div[4]/a[contains(text(),'Remove')]";
        public string Deactivate_Link => "//div[./div[./span[contains(text(),'{0}')]]]/div[3]/a[contains(text(),'Deactivate')]";
        public string FirstName_Inp => "//input[contains(@name,'firstname')]";
        public string LastName_Inp => "//input[contains(@name,'lastname')]";
        public string MiddleInitial_Inp => "//input[contains(@name,'middleinitial')]";
        public string Email_Inp => "//input[contains(@name,'pemail')]";
        public string Add_Btn => "//input[contains(@name,'submit_button_add')]";
        public string Successful_Text => "//div[contains(@class,'ml_row ml_message')]";
        #endregion

        public async Task ManageLoginsAddAsync()
        {
            var profileKey = "Agent_TC25";
            // Optionally: await _commonFunctions.ReadTestDataforPolicyAccessPageAsync();
            var filePath = "PolicyAccessPage\\PolicyAccessPage.json";
            await TextLink.ClickTextLinkAsync(Access_Link, true, 1);
            await IFrame.SwitchToIframeAsync();

            var firstName = _fileReader.GetOptionalValue(filePath, $"{profileKey}.FirstName");
            var lastName = _fileReader.GetOptionalValue(filePath, $"{profileKey}.LastName");
            var middleInitial = _fileReader.GetOptionalValue(filePath, $"{profileKey}.MiddleInitial");
            var email = _fileReader.GetOptionalValue(filePath, $"{profileKey}.Email");

            var frame = page.FrameLocator("//iframe[contains(@src, 'index.cfm?f=manageinsureds')]");
            await frame.Locator(FirstName_Inp).FillAsync(firstName);
            await frame.Locator(LastName_Inp).FillAsync(lastName);
            await frame.Locator(MiddleInitial_Inp).FillAsync(middleInitial);
            await frame.Locator(Email_Inp).FillAsync(email);
            await frame.Locator(Add_Btn).ClickAsync();            //await InputField.SetTextAreaInputFieldAsync(FirstName_Inp, firstName, true, 1);
            //await InputField.SetTextAreaInputFieldAsync(LastName_Inp, lastName, true, 1);
            //await InputField.SetTextAreaInputFieldAsync(MiddleInitial_Inp, middleInitial, true, 1);
            // await InputField.SetTextAreaInputFieldAsync(Email_Inp, email, true, 1);
            //await Button.ClickButtonAsync(Add_Btn, ActionType.Click, true, 1);
            await Task.Delay(5000);
            await frame.Locator(Successful_Text)
    .WaitForAsync(new() { State = WaitForSelectorState.Visible, Timeout = 10000 });
            var successMessage = await frame.Locator(Successful_Text).InnerTextAsync();
            if (!successMessage.Contains("Invite sucessfully sent to user."))
            {
                throw new Exception($"Success message not found. Actual: '{successMessage}'");
            }

            //await IFrame.CloseAsync();
        }

        public async Task ManageLoginsDeleteAsync()
        {
            var profileKey = "Agent_TC25";
            var filePath = "PolicyAccessPage\\PolicyAccessPage.json";
            await TextLink.ClickTextLinkAsync(Access_Link, true, 1);
            var frame = page.FrameLocator("//iframe[contains(@src, 'index.cfm?f=manageinsureds')]");
            //await IFrame.SwitchToIframeAsync();
            //var frame = page.FrameLocator("//iframe[contains(@src, 'index.cfm?f=manageinsureds')]");
            var removeOrDeactivate = _fileReader.GetOptionalValue(filePath, $"{profileKey}.RemoveorDeactivate");
            var deleteUserName = _fileReader.GetOptionalValue(filePath, $"{profileKey}.DeleteUserName");

            if (removeOrDeactivate == "Remove")
            {
                var RemoveName = string.Format(Remove_Link, deleteUserName);
                // await TextLink.ClickTextLinkAsync(RemoveName, true, 1);
                page.Dialog += async (_, dialog) => await dialog.AcceptAsync();
                await frame.Locator(RemoveName).ClickAsync();
                await Task.Delay(2000);
                await frame.Locator(Successful_Text)
         .WaitForAsync(new() { State = WaitForSelectorState.Visible, Timeout = 10000 });
                var confirmationText = await frame.Locator(Successful_Text).InnerTextAsync();
                if (!confirmationText.Contains("Pending user successfully removed from policy."))
                {
                    throw new Exception("Removal message not found");
                }
            }
            else if (removeOrDeactivate == "Deactivate")
            {
                var DeactivateName = string.Format(Deactivate_Link, deleteUserName);
                page.Dialog += async (_, dialog) => await dialog.AcceptAsync();
                await frame.Locator(DeactivateName).ClickAsync();
                //await TextLink.ClickTextLinkAsync(DeactivateName, true, 1);
                await Task.Delay(2000);

                await frame.Locator(Successful_Text)
    .WaitForAsync(new() { State = WaitForSelectorState.Visible, Timeout = 10000 });
                var actualText = await frame.Locator(Successful_Text).InnerTextAsync();
                if (!actualText.Contains("User successfully deactivated on this policy."))
                {
                    throw new Exception(
                        $"Expected 'User successfully deactivated on this policy.' but got '{actualText}'"
                    );
                }
            }
        }
    }
}
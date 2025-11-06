using BDD.Playwright.GBIZ.PageElements;
using BDD.Playwright.GBIZ.Pages.CommonPage;
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
        public LoginPage(ScenarioContext scenarioContext) : base(scenarioContext)
        {

            //PageFactory.InitElements(Driver, this);
            //_commonXpath = commonXpath;
            _scenarioTitle = scenarioContext.ScenarioInfo.Title;

        }
        #region Xpath
        #endregion
        public async Task LoginAsync()
        {
            commonFunctions.ReadTestDataForLoginPage();
            commonFunctions.UserWaitForPageToLoadCompletly();
            if (commonFunctions.AccountName_LabelAndValue.Item2 == "Agents")
            {
                Button.ClickButton(_commonXpath.AgentPortal, ActionType.Click, true, 1, "Agents");
            }
            else if (commonFunctions.AccountName_LabelAndValue.Item2 == "Members")
            {
                Button.ClickButton(_commonXpath.Members, ActionType.Click, true, 1, "Members");
            }
            InputField.SetTextAreaInputField(_commonXpath.UsernameInp, commonFunctions.UserName_LabelAndValue.Item2, true, 1, "UserName");
            InputField.SetTextAreaInputField(_commonXpath.PasswordInp, commonFunctions.Password_LabelAndValue.Item2, true, 1, "Password");
            Button.ClickButtonForStaleElementWithoutDepen(_commonXpath.SignInBtn, ActionType.Click, true, 1, "Login");
            Console.WriteLine("User logged into GBIZ");
            commonFunctions.UserWaitForPageToLoadCompletly();
        }

        public async Task LoginUsingJSONAsync()
        {
            commonFunctions.UserWaitForPageToLoadCompletly();
            var jsonDataReader = new JsonTestDataReader();
            var testData = JsonTestDataReader.LoadTestData(_scenarioTitle, "AgentLogin.json");
            if (testData["Account"].ToString() == "Agents")
            {
                Button.ClickButton(_commonXpath.AgentPortal, ActionType.Click, true, 1, "Agents");
            }
            else if (testData["Account"].ToString() == "Members")
            {
                Button.ClickButton(_commonXpath.Members, ActionType.Click, true, 1, "Members");
            }
            InputField.SetTextAreaInputField(_commonXpath.UsernameInp, testData["UserName"].ToString(), true, 1, "UserName");
            InputField.SetTextAreaInputField(_commonXpath.PasswordInp, testData["Password"].ToString(), true, 1, "Password");
            Button.ClickButtonForStaleElementWithoutDepen(_commonXpath.SignInBtn, ActionType.Click, true, 1, "Login");
            Console.WriteLine("User logged into GBIZ");
            commonFunctions.UserWaitForPageToLoadCompletly();
        }
    }
}

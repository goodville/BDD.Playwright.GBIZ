using BDD.Playwright.Core.Loggers;
using GoodVille.GBIZ.Reqnroll.Automation.Pages.GlobalPages;
using Microsoft.CodeAnalysis.Text;
using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDD.Playwright.Test.Pages.AgentPages
{
    public class PolicyAccessPage : BasePage
    {
        //private CommonFunctions _commonFunctions;
        //private WebDriverManager _webDriverManager;
        //private readonly ScenarioContext _scenarioContext;
        //public FeatureContext _featureContext;
        //public CommonXpath _commonXpath;
        //private readonly ApplicationLogger _applicationLogger;
        public LoginPage _loginPage;
        //public ReportAClaimStartPage _reportAClaimStartPage;
        //public ReportAClaimForm _reportAClaimForm;
        //private WebDriverWait _driverWait;
        // Constructor
        public PolicyAccessPage(ScenarioContext scenarioContext, CommonFunctions commonFunctions, ApplicationLogger applicationLogger, LoginPage loginPage, CommonXpath commonXpath, ReportAClaimStartPage reportAClaimStartPage, ReportAClaimForm reportAClaimForm) : base(scenarioContext)
        {
            //_scenarioContext = scenarioContext;
            //_commonFunctions = commonFunctions;
            //_applicationLogger = applicationLogger;
            //_webDriverManager = _scenarioContext.Get<WebDriverManager>("WebDriverManager");
            //_loginPage = loginPage;
            //_commonXpath = commonXpath;
            //_reportAClaimStartPage = reportAClaimStartPage;
            //_reportAClaimForm = reportAClaimForm;
            //commonFunctions.ReadTestDataForClaimPage();
           // _driverWait = new WebDriverWait(Driver, TimeSpan.FromSeconds(60));
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

        public async Task ManageLoginsAdd()
        {
            commonFunctions.UserWaitForPageToLoadCompletly();
            commonFunctions.ReadTestDataforPolicyAccessPage();
            TextLink.ClickTextLink(Access_Link, true, 1);
            commonFunctions.UserWaitForPageToLoadCompletly();
            IFrame.switchToIframe();
            InputField.SetTextAreaInputField(FirstName_Inp, commonFunctions.ManageLogin_FirstName_LabelAndValue.Item2, true, 1);
            InputField.SetTextAreaInputField(LastName_Inp, commonFunctions.ManageLogin_LastName_LabelAndValue.Item2, true, 1);
            InputField.SetTextAreaInputField(MiddleInitial_Inp, commonFunctions.ManageLogin_MiddleInitial_LabelAndValue.Item2, true, 1);
            InputField.SetTextAreaInputField(Email_Inp, commonFunctions.ManageLogin_Email_LabelAndValue.Item2, true, 1);
            Button.ClickButton(Add_Btn, ActionType.Click, true, 1);
            commonFunctions.UserWaitForPageToLoadCompletly();
            Thread.Sleep(5000);
            Label.VerifyText(Successful_Text, "Invite sucessfully sent to user.", true, 1);
            IFrame.close();
        }

        public async Task ManageLoginsDelete()
        {
            commonFunctions.UserWaitForPageToLoadCompletly();
            commonFunctions.ReadTestDataforPolicyAccessPage();
            _driverWait.Until(ExpectedConditions.ElementToBeClickable(OpenQA.Selenium.By.XPath(Access_Link)));
            TextLink.ClickTextLink(Access_Link, true, 1);
            IFrame.switchToIframe();
            if (commonFunctions.ManageLogin_RemoveorDeactivate_LabelAndValue.Item2 == "Remove")
            {
                commonFunctions.UserWaitForPageToLoadCompletly();
                string RemoveName = string.Format(Remove_Link, commonFunctions.ManageLogin_DeleteUserName_labelAndvalue.Item2);
                TextLink.ClickTextLink(RemoveName, true, 1);
                Driver.SwitchTo().Alert().Accept();
                commonFunctions.UserWaitForPageToLoadCompletly();
                Thread.Sleep(2000);
                Label.VerifyText(Successful_Text, "Pending user successfully removed from policy.", true, 1);
            }
            if (commonFunctions.ManageLogin_RemoveorDeactivate_LabelAndValue.Item2 == "Deactivate")
            {
                commonFunctions.UserWaitForPageToLoadCompletly();
                string DeactivateName = string.Format(Deactivate_Link, commonFunctions.ManageLogin_DeleteUserName_labelAndvalue.Item2);
                TextLink.ClickTextLink(DeactivateName, true, 1);
                commonFunctions.UserWaitForPageToLoadCompletly();
                Driver.SwitchTo().Alert().Accept();
                commonFunctions.UserWaitForPageToLoadCompletly();
                Thread.Sleep(2000);
                Label.VerifyText(Successful_Text, "User successfully deactivated on this policy.", true, 1);
            }
            IFrame.close();
            commonFunctions.UserWaitForPageToLoadCompletly();
        }
    }
}

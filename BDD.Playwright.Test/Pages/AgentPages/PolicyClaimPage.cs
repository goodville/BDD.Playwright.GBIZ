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
    public class PolicyClaimPage : BasePage
    {
        //private CommonFunctions _commonFunctions;
        //private WebDriverManager _webDriverManager;
        //private readonly ScenarioContext _scenarioContext;
        //public FeatureContext _featureContext;
        //public CommonXpath _commonXpath;
        //private readonly ApplicationLogger _applicationLogger;
        //public LoginPage _loginPage;
        //public ReportAClaimStartPage _reportAClaimStartPage;
        //public ReportAClaimForm _reportAClaimForm;
        // Constructor
        public PolicyClaimPage(ScenarioContext scenarioContext, CommonFunctions commonFunctions, ApplicationLogger applicationLogger, LoginPage loginPage, CommonXpath commonXpath, ReportAClaimStartPage reportAClaimStartPage, ReportAClaimForm reportAClaimForm) : base(scenarioContext)
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
        }

        #region Xpath
        public string Claim_Link => "//a[contains(text(),'CLAIMS')]";
        public string NoClaimHistory_Text => "//span[contains(text(),'No Records Returned!')]";
        public string ClaimLossReport_Btn => "//button[contains(text(),'{0}')]";
        public string ClaimLossReportNoRecord_Text => "//td[contains(text(),'No claims found on this policy.')]";
        #endregion

        public async Task NoClaimHistoryMethod()
        {
            commonFunctions.UserWaitForPageToLoadCompletly();
            commonFunctions.ReadTestDataPolicyClaimPage();
            TextLink.ClickTextLink(Claim_Link, true, 1);
            commonFunctions.UserWaitForPageToLoadCompletly();
            Thread.Sleep(5000);
            Label.VerifyText(NoClaimHistory_Text, "No Records Returned!", true, 1);
            string ClaimLossreportyeartoSelect = string.Format(ClaimLossReport_Btn, commonFunctions.PolicyClaim_3or5orAll_LabelAndValue.Item2);
            Button.ClickButton(ClaimLossreportyeartoSelect, ActionType.Click, true, 1);
            commonFunctions.UserWaitForPageToLoadCompletly();
            IFrame.switchToWindow();
            Thread.Sleep(2000);
            Label.VerifyText(ClaimLossReportNoRecord_Text, "No claims found on this policy.", true, 1);
            IFrame.CurrentWindowClose();
            commonFunctions.UserWaitForPageToLoadCompletly();
        }
    }
}

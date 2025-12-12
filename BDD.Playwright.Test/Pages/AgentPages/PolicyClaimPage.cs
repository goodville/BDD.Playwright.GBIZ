using BDD.Playwright.Core.Interfaces;
using BDD.Playwright.Core.Loggers;
using BDD.Playwright.GBIZ.PageElements;
using BDD.Playwright.GBIZ.Pages.CommonPage;
using BDD.Playwright.GBIZ.Pages.GlobalPages;
using BDD.Playwright.GBIZ.Pages.PublicPages;
using BDD.Playwright.GBIZ.Pages.XpathProperties;
using Microsoft.Playwright;
using Reqnroll;
using System.Threading.Tasks;

namespace BDD.Playwright.GBIZ.Pages.AgentPages
{
    public class PolicyClaimPage : BasePage
    {
        private readonly ScenarioContext _scenarioContext;
        public FeatureContext _featureContext;
        public CommonXpath _commonXpath;
        public LoginPage _loginPage;
        public ReportAClaimStartPage _reportAClaimStartPage;
        public ReportAClaimFormPage _reportAClaimFormPage;
        private readonly IFileReader _fileReader;

        public PolicyClaimPage(
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
        public string Claim_Link => "//a[contains(text(),'CLAIMS')]";
        public string NoClaimHistory_Text => "//span[contains(text(),'No Records Returned!')]";
        public string ClaimLossReport_Btn => "//button[contains(text(),'{0}')]";
        public string ClaimLossReportNoRecord_Text => "//td[contains(text(),'No claims found on this policy.')]";
        #endregion

        public async Task NoClaimHistoryMethodAsync()
        {
            // Optionally: await _commonFunctions.ReadTestDataPolicyClaimPageAsync();
            var profileKey = "Agent_TC26";
            var filePath = "PolicyClaimPage\\PolicyClaimPage.json";
            // Use JSON fields for test data
            var claimLossReportBtnYear = _fileReader.GetOptionalValue(filePath, $"{profileKey}.3or5orAll");

            await TextLink.ClickTextLinkAsync(Claim_Link, true, 1);
            await Task.Delay(5000);
            await Label.VerifyTextAsync(NoClaimHistory_Text, "No Records Returned!", true, 1);
            var claimLossReportYearToSelect = string.Format(ClaimLossReport_Btn, claimLossReportBtnYear);
            await Button.ClickButtonAsync(claimLossReportYearToSelect, ActionType.Click, true, 1);
            await Task.Delay(2000);
            await Label.VerifyTextAsync(ClaimLossReportNoRecord_Text, "No claims found on this policy.", true, 1);
            await Task.Delay(3000);
        }
    }
}
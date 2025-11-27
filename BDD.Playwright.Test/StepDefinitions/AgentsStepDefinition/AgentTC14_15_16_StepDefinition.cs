using BDD.Playwright.GBIZ.Pages.CommonPage;
using BDD.Playwright.GBIZ.Pages.GlobalPages;
using BDD.Playwright.GBIZ.Pages.PublicPages;
using BDD.Playwright.GBIZ.Pages.XpathProperties;

namespace BDD.Playwright.GBIZ.Steps.AgentsStepDefinition
{
    [Binding]
    public class AgentTC14_15_16_StepDefinition : BasePage
    {
        private readonly ScenarioContext _scenarioContext;
        public FeatureContext _featureContext;
        public CommonXpath _commonXpath;
        private readonly IReqnrollOutputHelper _ReqnrollLogger;
        public LoginPage _loginPage;
        public ClaimsPage _claimsPage;

        // Add Playwright page if needed (not strictly required for helpers)
        // private readonly IPage _page;

        public AgentTC14_15_16_StepDefinition(
            ScenarioContext scenarioContext,
            LoginPage loginPage,
            CommonXpath commonXpath,
            ClaimsPage claimsPage
        ) : base(scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _loginPage = loginPage;
            _commonXpath = commonXpath;
            _claimsPage = claimsPage;
        }

        [When(@"User clicks on claims")]
        public async Task WhenUserClicksOnClaimsAsync()
        {
            await _claimsPage.ClaimButtonAsync();
        }

        [When(@"User Clicks on Report Loss and Add the Loss from {string}")]
        public async Task WhenUserClickonReportLossandAddtheLossAsync(string profileKey)
        {
            await _claimsPage.ReportLossAsync(profileKey);
        }

        [When(@"User Clicks on Report Loss and Verify Page is Loaded or Not from {string}")]
        public async Task WhenUserClickonReportLossandVerifyPageisLoadedorNotAsync(string profileKey)
        {
            await _claimsPage.ReportLossAsync(profileKey);
        }

        [When(@"User Clicks on Service and Verify Page is Loaded or Not from {string}")]
        public async Task WhenUserClickonServiceandVerifyPageisLoadedorNotAsync(string profileKey)
        {
            await _claimsPage.ServiceAsync(profileKey);
        }

        [When(@"User Clicks on DirectPay and Verify Page is Loaded or Not from {string}")]
        public async Task WhenUserClickonDirectPayandVerifyPageisLoadedorNotAsync(string profileKey)
        {
            await _claimsPage.DirectPayShopAsync(profileKey);
        }

        [When(@"User Clicks on YTDLoss and Verify Page is Loaded or Not from {string}")]
        public async Task WhenUserClickonYTDLossandVerifyPageisLoadedorNotAsync(string profileKey)
        {
            await _claimsPage.YTDLossAsync(profileKey);
        }

        [When(@"User Clicks on Payments and Verify Page is Loaded or Not from {string}")]
        public async Task WhenUserClickonPaymentsandVerifyPageisLoadedorNotAsync(string profileKey)
        {
            await _claimsPage.PaymentsAsync(profileKey);
        }

        [When(@"User Clicks on Search and Verify Page is Loaded or Not from {string}")]
        public async Task WhenUserClickonSearchandVerifyPageisLoadedorNotAsync(string profileKey)
        {
            await _claimsPage.SearchAsync(profileKey);
        }

        [When(@"User enter the Invalid claim number and verify the no data has known")]
        public async Task WhenUserEntertheInvalidClaimNumberandVerifythenodatahasKnownAsync()
        {
            await InputField.SetTextAreaInputFieldAsync(_claimsPage.Search_ClaimNumber_Inp, "123456", true, 1);
            await Task.Delay(3000);
            await Label.VerifyTextAsync(_claimsPage.Serach_NoData_Text, "No data was returned with your query.", true, 1);
        }
    }
}
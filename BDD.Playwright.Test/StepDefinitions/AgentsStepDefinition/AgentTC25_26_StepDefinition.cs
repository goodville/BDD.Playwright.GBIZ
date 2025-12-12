using BDD.Playwright.GBIZ.Pages.AgentPages;
using BDD.Playwright.GBIZ.Pages.CommonPage;
using BDD.Playwright.GBIZ.Pages.GlobalPages;
using BDD.Playwright.GBIZ.Pages.XpathProperties;

namespace BDD.Playwright.GBIZ.Steps.AgentsStepDefinition
{
    [Binding]
    public class AgentTC25_26_StepDefinition : BasePage
    {
        private readonly ScenarioContext _scenarioContext;
        public FeatureContext _featureContext;
        public CommonXpath _commonXpath;
        public LoginPage _loginPage;
        public PolicyAccessPage _policyAccessPage;
        public PolicyClaimPage _policyClaimPage;

        public AgentTC25_26_StepDefinition(
            ScenarioContext scenarioContext,
            LoginPage loginPage,
            CommonXpath commonXpath,
            PolicyAccessPage policyAccessPage,
            PolicyClaimPage policyClaimPage
        ) : base(scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _loginPage = loginPage;
            _commonXpath = commonXpath;
            _policyAccessPage = policyAccessPage;
            _policyClaimPage = policyClaimPage;
        }

        [When(@"User Add the Login to Access the Policy")]
        public async Task WhenUserAddtheLogintoAccessthePolicyAsync()
        {
            await _policyAccessPage.ManageLoginsAddAsync();
        }

        [When(@"User Delete the Login to Access the Policy")]
        public async Task WhenUserDeletetheLogintoAccessthePolicyAsync()
        {
            await _policyAccessPage.ManageLoginsDeleteAsync();
        }

        [When(@"User Click on Policy Claim and Verify the Claims Records")]
        public async Task WhenUserClickonPolicyClaimandVerifytheClaimsRecordsAsync()
        {
            await _policyClaimPage.NoClaimHistoryMethodAsync();
        }
    }
}
using BDD.Playwright.Core.Loggers;
using BDD.Playwright.GBIZ.Pages.AgentPages;
using BDD.Playwright.GBIZ.Pages.CommonPage;
using BDD.Playwright.GBIZ.Pages.GlobalPages;
using BDD.Playwright.GBIZ.Pages.XpathProperties;
using Microsoft.Playwright;
using Reqnroll;
using System.Threading.Tasks;

namespace BDD.Playwright.GBIZ.Steps.AgentsStepDefinition
{
    [Binding]
    public class AgentTC29_StepDefinition : BasePage
    {
        private readonly ScenarioContext _scenarioContext;
        public FeatureContext _featureContext;
        public CommonXpath _commonXpath;
        public LoginPage _loginPage;
        public QuotePage _quotePage;

        public AgentTC29_StepDefinition(
            ScenarioContext scenarioContext,
            LoginPage loginPage,
            CommonXpath commonXpath,
            QuotePage quotePage
        ) : base(scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _loginPage = loginPage;
            _commonXpath = commonXpath;
            _quotePage = quotePage;
        }

        [When(@"User Click on the Quoting")]
        public async Task WhenUserClickontheQuotingAsync()
        {
            await _quotePage.QuotingLinkAsync();
        }

        [When(@"User Click on New Quote and Verify the Correct Page is displayed")]
        public async Task WhenUserClickonNewQuoteandVerifytheCorrectPageisDisplayedAsync()
        {
            await _quotePage.QuotingNewQuoteAsync();
        }

        [When(@"User Click on E2Value and Verify the Correct Page is displayed")]
        public async Task WhenUserClickonE2ValueandVerifytheCorrectPageisDisplayedAsync()
        {
            await _quotePage.QuotingE2ValueAsync();
        }

        [When(@"User Click on FAQS and Verify the Correct Page is displayed")]
        public async Task WhenUserClickonFAQSandVerifytheCorrectPageisDisplayedAsync()
        {
            await _quotePage.QuotingFAQSAsync();
        }

        [When(@"User Click on Search and Verify the Correct Page is displayed")]
        public async Task WhenUserClickonSearchandVerifytheCorrectPageisDisplayedAsync()
        {
            await _quotePage.QuotingSearchAsync();
        }
    }
}
using BDD.Playwright.Core.Loggers;
using BDD.Playwright.GBIZ.Pages.AgentPages;
using BDD.Playwright.GBIZ.Pages.CommonPage;
using BDD.Playwright.GBIZ.Pages.GlobalPages;
using BDD.Playwright.GBIZ.Pages.XpathProperties;
using BDD.Playwright.Origami.Pages.AgentPages;
using GoodVille.GBIZ.Reqnroll.Automation.Pages.AgentPages;
using Microsoft.Playwright;

namespace BDD.Playwright.GBIZ.Steps.AgentsStepDefinition
{
    [Binding]
    public class AgentTC79_StepDefinitions : BasePage
    {
        private readonly ScenarioContext _scenarioContext;
        public FeatureContext _featureContext;
        public CommonXpath _commonXpath;
        public Quote_ApplicantPage _quoteApplicant;
        public Quote_CoveragesPage _quoteCoverage;
        public Quote_DwellingPage _quoteDwelling;
        public Quote_LocationsPage _quote_LocationsPage;
        public Quote_PriorCarriersPage _quote_PriorCarriersPage;

        // Constructor
        public AgentTC79_StepDefinitions(
            ScenarioContext scenarioContext,
            CommonXpath commonXpath,
            Quote_ApplicantPage quoteApplicantpage,
            Quote_CoveragesPage quoteCoveragespage,
            Quote_DwellingPage quoteDwellingpage,
            Quote_LocationsPage quote_LocationsPage,
            Quote_PriorCarriersPage quote_PriorCarriersPage) : base(scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _commonXpath = commonXpath;
            _quoteApplicant = quoteApplicantpage;
            _quoteCoverage = quoteCoveragespage;
            _quoteDwelling = quoteDwellingpage;
            _quote_LocationsPage = quote_LocationsPage;
            _quote_PriorCarriersPage = quote_PriorCarriersPage;
        }

        [When("User fills the mandatory field in the application info in applicant page for commercial umbrella from {string}")]
        public async Task WhenUserFillsTheMandatoryFieldInTheApplicationInfoInApplicantPageForCommercialUmbrellaAsync(string profileKey)
        {
            // Assumes your Quote_ApplicantPage has an async Playwright-compatible method
            await _quoteApplicant.CommercialUmbrellaApplicantDatafillAsync(profileKey);
        }
    }
}
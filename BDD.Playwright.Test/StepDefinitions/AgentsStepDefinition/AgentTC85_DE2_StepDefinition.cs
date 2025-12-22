using AventStack.ExtentReports.Gherkin.Model;
using BDD.Playwright.Core.Loggers;
using BDD.Playwright.GBIZ.Pages.AgentPages;
using BDD.Playwright.GBIZ.Pages.CommonPage;
using BDD.Playwright.GBIZ.Pages.XpathProperties;
using BDD.Playwright.Origami.Pages.AgentPages;
using GoodVille.GBIZ.Reqnroll.Automation.Pages.AgentPages;
using GoodVille.GBIZ.Reqnroll.Automation.Pages.GlobalPages;

namespace GoodVille.GBIZ.Specflow.Automation.Steps.AgentsStepDefinition
{
    [Binding]
    public class AgentTC85_DE2_StepDefinition : BasePage
    {
        private readonly ScenarioContext _scenarioContext;
        public FeatureContext _featureContext;
        public CommonXpath _commonXpath;
        public LoginPage _loginPage;
        public QuotePage _quotePage;
        public NewQuote_TradesmanCoverPage _tradesmanCoverPage;

        // Constructor
        public AgentTC85_DE2_StepDefinition(
            ScenarioContext scenarioContext,
            LoginPage loginPage,
            CommonXpath commonXpath,
            QuotePage quotePage,
            NewQuote_TradesmanCoverPage tradesmanCoverPage) : base(scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _loginPage = loginPage;
            _commonXpath = commonXpath;
            _quotePage = quotePage;
            _tradesmanCoverPage = tradesmanCoverPage;
        }

        [When("User clicks on Tools Equipment sub tab and enters the required fields from json {string}")]
        public async Task WhenUserClicksOnToolsEquipmentSubTabAndEntersTheRequiredFieldsAsync(string jsonFile)
        {
            await _tradesmanCoverPage.ToolsEquipmentInformationAsync(jsonFile);
        }

        /*[When("User clicks on billing tab and enter the required Info")]
        public async Task WhenUserClicksOnBillingTabAndEnterTheRequiredInfo()
        {
            await _tradesmanCoverPage.BillingInformationAsync();
        }

        [When("User clicks on Bind tab and enter the required Info")]
        public async Task WhenUserClicksOnBindTabAndEnterTheRequiredInfo()
        {
            await _tradesmanCoverPage.BindingInformationAsync();
        }*/
    }
}
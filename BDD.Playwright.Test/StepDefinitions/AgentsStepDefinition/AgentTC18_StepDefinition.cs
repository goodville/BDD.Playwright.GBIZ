using BDD.Playwright.GBIZ.Pages.AgentPages;
using BDD.Playwright.GBIZ.Pages.AgentsPages;
using BDD.Playwright.GBIZ.Pages.CommonPage;
using BDD.Playwright.GBIZ.Pages.PublicPages;
using BDD.Playwright.GBIZ.Pages.XpathProperties;
using BDD.Playwright.GBIZ.Steps.AgentsStepDefinition;
using GoodVille.GBIZ.Reqnroll.Automation.Pages.GlobalPages;
using OpenQA.Selenium.Support.UI;

namespace GoodVille.GBIZ.Reqnroll.Automation.Steps.AgentsStepDefinition
{
    [Binding]
    public class AgentTC18_StepDefinition : BasePage
    {
        private readonly ScenarioContext _scenarioContext;
        public FeatureContext _featureContext;
        public CommonXpath _commonXpath;
        public LoginPage _loginPage;
        public Accounting_MakeAPayment _accounting_MakeAPayment;
        public MakeAPaymentPage _makeAPaymentPage;
        public AgentTC13_StepDefinition _agentTC13_StepDefinition;
        public MyBusinessHomePage _myBusinessHomePage;

        // Constructor
        public AgentTC18_StepDefinition(ScenarioContext scenarioContext, LoginPage loginPage, CommonXpath commonXpath, Accounting_MakeAPayment accounting_MakeAPayment, MakeAPaymentPage makeAPaymentPage, MyBusinessHomePage myBusinessHomePage, AgentTC13_StepDefinition agentTC13_StepDefinition) : base(scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _loginPage = loginPage;
            _commonXpath = commonXpath;
            _accounting_MakeAPayment = accounting_MakeAPayment;
            _makeAPaymentPage = makeAPaymentPage;
            _myBusinessHomePage = myBusinessHomePage;
            _agentTC13_StepDefinition = agentTC13_StepDefinition;
        }

        [When("User Click on the different business and selects radio buttons for Insured and Agent")]
        public async Task WhenUserClickOnTheDifferentBusinessAndSelectsRadioButtonsForInsuredAndAgentAsync()
        {
            await Checkbox.SelectCheckboxAsync(_commonXpath.CommercialLines_BusinessCover_InsuredRadioButton, true, true, 1);
            await Checkbox.SelectCheckboxAsync(_commonXpath.CommercialLines_CommercialUmbrella_AgentRadioButton, true, true, 1);
        }
    }
}

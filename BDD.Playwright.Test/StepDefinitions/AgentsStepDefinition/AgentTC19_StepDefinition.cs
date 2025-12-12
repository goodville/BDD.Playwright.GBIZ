using BDD.Playwright.GBIZ.PageElements;
using BDD.Playwright.GBIZ.Pages.AgentPages;
using BDD.Playwright.GBIZ.Pages.CommonPage;
using BDD.Playwright.GBIZ.Pages.PublicPages;
using BDD.Playwright.GBIZ.Pages.XpathProperties;
using BDD.Playwright.GBIZ.Steps.AgentsStepDefinition;
using GoodVille.GBIZ.Reqnroll.Automation.Pages.GlobalPages;
using OpenQA.Selenium.Support.UI;

namespace GoodVille.GBIZ.Reqnroll.Automation.Steps.AgentsStepDefinition
{
    [Binding]
    public class AgentTC19_StepDefinition : BasePage
    {
        private readonly ScenarioContext _scenarioContext;
        public FeatureContext _featureContext;
        public CommonXpath _commonXpath;
        public LoginPage _loginPage;
        public Accounting_MakeAPayment _accounting_MakeAPayment;
        public MakeAPaymentPage _makeAPaymentPage;
        public AgentTC13_StepDefinition _agentTC13_StepDefinition;
        // Constructor
        public AgentTC19_StepDefinition(ScenarioContext scenarioContext, LoginPage loginPage, CommonXpath commonXpath, Accounting_MakeAPayment accounting_MakeAPayment, MakeAPaymentPage makeAPaymentPage, AgentTC13_StepDefinition agentTC13_StepDefinition) : base(scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _loginPage = loginPage;
            _commonXpath = commonXpath;
            _accounting_MakeAPayment = accounting_MakeAPayment;
            _makeAPaymentPage = makeAPaymentPage;
            _agentTC13_StepDefinition = agentTC13_StepDefinition;
        }
        #region Xpath
        //public string Verify_PolicyId_exists { get; set; } = "//td[contains(text(),'826103')]";
        //public string Verify_NumberCoulmn_exists { get; set; } = "//div[contains(text(),'Number')]";
        public string MakePaymentButton { get; set; } = "//button[normalize-space()='Make Payment']";
        #endregion
        [When("User Click on the Make payment button and verify the Make a payment page opens or not")]
        public async Task WhenUserClickOnTheMakePaymentButtonAndVerifyTheMakeAPaymentPageOpensOrNotAsync()
        {
            await Button.ClickButtonAsync(MakePaymentButton, ActionType.Click, true, 1);
        }
    }
}


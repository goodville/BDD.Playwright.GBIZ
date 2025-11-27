using BDD.Playwright.Core.Loggers;
using BDD.Playwright.GBIZ.PageElements;
using BDD.Playwright.GBIZ.Pages.AgentPages;
using BDD.Playwright.GBIZ.Pages.CommonPage;
using BDD.Playwright.GBIZ.Pages.XpathProperties;
using GoodVille.GBIZ.Reqnroll.Automation.Pages.GlobalPages;

namespace GoodVille.GBIZ.Specflow.Automation.Steps.AgentsStepDefinition
{
    [Binding]
    public class AgentTC28_StepDefinition : BasePage
    {
        private readonly ScenarioContext _scenarioContext;
        public FeatureContext _featureContext;
        public CommonXpath _commonXpath;
        public LoginPage _loginPage;
        public QuotePage _quotePage;
        // Constructor
        public AgentTC28_StepDefinition(
            ScenarioContext scenarioContext,
            LoginPage loginPage,
            CommonXpath commonXpath,
            QuotePage quotePage) : base(scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _loginPage = loginPage;
            _commonXpath = commonXpath;
            _quotePage = quotePage;
        }

        [When(@"User Click on the Policy and Verify the Accouting Guidelines Link")]
        public async Task WhenUserClickonthePolicyandVerifytheAccountingGuidelinesLinkAsync()
        {
            await Button.ClickButtonCssAsync(_commonXpath.ShadowHost, _commonXpath.PolicySidePanelShadow);
            await TextLink.ClickTextLinkAsync(_commonXpath.PolicyPage_AccountingGuidelines_Link, true, 1);
            await Button.ClickButtonAsync(_commonXpath.PolicyPage_AccountingNewLink_Link, ActionType.Click, true, 1);
            await Task.Delay(2000);
            await Label.VerifyTextAsync(_commonXpath.AccountingSuccessfulOpen_Text, "Accounting Guidelines", true, 1);
            await page.GoBackAsync();
        }

        [When(@"User Verify the Payment Options Link")]
        public async Task WhenUserVerifythePaymentOptionsLinkAsync()
        {
            await TextLink.ClickTextLinkAsync(_commonXpath.PolicyPage_PaymentOptions_Link, true, 1);
            await Button.ClickButtonAsync(_commonXpath.PolicyPage_VisitNewSearch, ActionType.Click, true, 1);
            await Label.VerifyTextAsync(_commonXpath.PaymentOptionsSuccessful_Text, "Policies & Quotes", true, 1);
            await page.GoBackAsync();
        }

        [When(@"User Verify the FAQs Link")]
        public async Task WhenUserVerifytheFAQsLinkAsync()
        {
            await TextLink.ClickTextLinkAsync(_commonXpath.PolicyPage_FAQs_Link, true, 1);
            await Label.VerifyTextAsync(_commonXpath.FAQsSuccessfulOpen_Text, "Questions Frequently Asked by Agents", true, 1);
            await page.GoBackAsync();
        }

        [When(@"User Verify the Search Policies Link")]
        public async Task WhenUserVerifytheSearchPoliciesLinkAsync()
        {
            await TextLink.ClickTextLinkAsync(_commonXpath.PolicyPage_SearchPolicies_Link, true, 1);
            await Button.ClickButtonAsync(_commonXpath.PolicyPage_VisitNewSearch, ActionType.Click, true, 1);
            await Task.Delay(3000);
            await Label.VerifyTextAsync(_commonXpath.PaymentOptionsSuccessful_Text, "Policies & Quotes", true, 1);
        }

        [When(@"User enters the Invalid PolicyNumber and Verify the No Record found")]
        public async Task WhenUserEnterstheInvalidPolicyNumberandVErifytheNoRecordFoundAsync()
        {
            await InputField.SetTextAreaInputFieldAsync(_commonXpath.SearchPolicyPage_Keyword_Inp, "123456", true, 1);
            await Task.Delay(2000);
            await Label.VerifyTextAsync(_commonXpath.NoRecordFound_Text, "No Records Returned!", true, 1);
        }
    }
}
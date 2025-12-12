using System.Threading.Tasks;
using BDD.Playwright.GBIZ.Pages.AgentsPages;
using BDD.Playwright.GBIZ.Pages.CommonPage;
using BDD.Playwright.GBIZ.Pages.GlobalPages;
using BDD.Playwright.GBIZ.Pages.XpathProperties;
using Microsoft.Playwright;
using Reqnroll;

namespace BDD.Playwright.GBIZ.Steps.AgentsStepDefinition
{
    [Binding]
    public class AgentTC4_StepDefinition : BasePage
    {
        private readonly ScenarioContext _scenarioContext;
        public FeatureContext _featureContext;
        public CommonXpath _commonXpath;
        public LoginPage _loginPage;
        public PersonalAutoNewQuotePrefillOrder _personalAutoNewQuotePrefillOrder;

        public AgentTC4_StepDefinition(
            ScenarioContext scenarioContext,
            LoginPage loginPage,
            CommonXpath commonXpath,
            PersonalAutoNewQuotePrefillOrder personalAutoNewQuotePrefillOrder
        ) : base(scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _loginPage = loginPage;
            _commonXpath = commonXpath;
            _personalAutoNewQuotePrefillOrder = personalAutoNewQuotePrefillOrder;
        }

        [When(@"User clicks on quoting")]
        public async Task WhenUserClicksOnQuotingAsync()
        {
            await Button.ClickButtonCssAsync(_commonXpath.ShadowHost, _commonXpath.QuotingSidePanelShadow);
        }

        [When(@"user clicks on new quote")]
        public async Task WhenUserClicksOnNewQuoteAsync()
        {
            await TextLink.ClickTextLinkAsync(_commonXpath.NewQuoteLink, true, 1);
        }

        [When(@"user clicks on personal auto")]
        public async Task WhenUserClicksOnPersonalAutoAsync()
        {
            await Button.ClickButtonAsync(_commonXpath.PersonalAutoButton, PageElements.ActionType.Click, true, 1);
        }

        [When(@"user fills mandatory fields in personal auto new quote page from {string}")]
        public async Task WhenUserFillsMandatoryFieldsInPersonalAutoNewQuotePageAsync(string profileKey)
        {
            await _personalAutoNewQuotePrefillOrder.PersonalAutonewQuotePrefillAsync(profileKey);
        }

        [When(@"user click on order prefil data button")]
        public async Task WhenUserClickOnOrderPrefilDataButtonAsync()
        {
            await _personalAutoNewQuotePrefillOrder.ClickOrderDataAsync();
        }

        [Then(@"User verifies error messages on personal auto new quote page")]
        public async Task ThenUserVerifiesErrorMessagesOnPersonalAutoNewQuotePageAsync()
        {
            await _personalAutoNewQuotePrefillOrder.VerifyErrorMessagesDisplayedAsync();
        }
    }
}
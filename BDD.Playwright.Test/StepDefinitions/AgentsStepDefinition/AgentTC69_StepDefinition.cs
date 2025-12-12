using AventStack.ExtentReports.Gherkin.Model;
using BDD.Playwright.Core.Loggers;
using BDD.Playwright.GBIZ.PageElements;
using BDD.Playwright.GBIZ.Pages.AgentPages;
using BDD.Playwright.GBIZ.Pages.CommonPage;
using BDD.Playwright.GBIZ.Pages.XpathProperties;
using GoodVille.GBIZ.Reqnroll.Automation.Pages.GlobalPages;
using Microsoft.Playwright;

namespace GoodVille.GBIZ.Reqnroll.Automation.Steps.AgentsStepDefinition
{
    [Binding]
    public class AgentTC69_StepDefinition : BasePage
    {
        private readonly ScenarioContext _scenarioContext;
        public FeatureContext _featureContext;
        public CommonXpath _commonXpath;
        public LoginPage _loginPage;
        public QuotePage _quotePage;
        public Agent75_StepDefinition _agent75_StepDefinition;
        public NewQuote_TradesmanCoverPage _tradesmanCoverPage;
        public AgentTC69_StepDefinition(
            ScenarioContext scenarioContext,
            LoginPage loginPage,
            CommonXpath commonXpath,
            QuotePage quotePage,
            NewQuote_TradesmanCoverPage tradesmanCoverPage,
            Agent75_StepDefinition agent75_StepDefinition
        ) : base(scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _loginPage = loginPage;
            _commonXpath = commonXpath;
            _quotePage = quotePage;
            _tradesmanCoverPage = tradesmanCoverPage;
            _agent75_StepDefinition = agent75_StepDefinition;
        }

        [When(@"User enters required fields in the Quote Information page from json {string}")]
        public async Task UserentersrequiredfieldsintheQuoteInformationpageAsync(string ProfileKey)
        {
            await _tradesmanCoverPage.NewQuoteDetailsAsync(ProfileKey);
        }

        [When(@"User enter the required fields in the Add Location Page from json {string}")]
        public async Task UserentertherequiredfieldsintheAddLocationPageAsync(string profileKey)
        {
            await _tradesmanCoverPage.LocationDetailsAsync(profileKey);
        }

        [When(@"User enter the required fields in the Add Buildings Page from json {string}")]
        public async Task UserentertherequiredfieldsintheAddBuildingsPageAsync(string profileKey)
        {
            await _tradesmanCoverPage.BuildingDetailsAsync(profileKey);
        }

        [When("User clicks on Limits sub tab and enters the required fields from json {string}")]
        public async Task WhenUserClicksOnLimitsSubTabAndEntersTheRequiredFieldsAsync(string profileKey)
        {
            await _tradesmanCoverPage.BuildingLimitsAsync(profileKey);
        }

        [When("User clicks on RatingsInfo Sub tab and enters the required fields from json {string}")]
        public async Task WhenUserClicksOnRatingsInfoSubTabAndEntersTheRequiredFieldsAsync(string profileKey)
        {
            await _tradesmanCoverPage.BuildingRatingInformationAsync(profileKey);
        }

        [When("User clicks on Coverages Tab and enters the required fields from json {string}")]
        public async Task WhenUserClicksOnCoveragesTabAndEntersTheRequiredFieldsAsync(string profileKey)
        {
            await _tradesmanCoverPage.CoveragesInformationAsync(profileKey);
        }

        [When("User clicks on Enhancement sub tab and enters the required fields from json {string}")]
        public async Task WhenUserClicksOnEnhancementSubTabAndEntersTheRequiredFieldsAsync(string profileKey)
        {
            await _tradesmanCoverPage.EnhancementInformationAsync(profileKey);
        }

        [When("User clicks on Summary Tab and Validate the Estimated Premium Value has displayed or not")]
        public async Task WhenUserClicksOnSummaryTabAndValidateTheEstimatedPremiumValueHasDisplayedOrNotAsync()
        {
            await _tradesmanCoverPage.SummaryInformationAsync();
            await _tradesmanCoverPage.EstimatedPremiumValidationAsync();
        }

        [When("User click on Delete Button and verify user should be able to delete the Quote successfully")]
        public async Task WhenUserClickOnDeleteButtonAndVerifyUserShouldBeAbleToDeleteTheQuoteSuccessfullyAsync()
        {
            await Button.ClickButtonAsync(_agent75_StepDefinition.Delete_Quotebutton, ActionType.Click, true, 1);

            // Wait for Playwright alert/dialog and accept
            var dialogHandled = false;
            page.Dialog += async (_, dialog) =>
            {
                await dialog.AcceptAsync();
                dialogHandled = true;
            };
            // Wait up to 10s for dialog (simulate Selenium's WebDriverWait for alert)
            for (var i = 0; i < 20 && !dialogHandled; i++)
            {
                await page.WaitForTimeoutAsync(500);
            }
        }
    }
}
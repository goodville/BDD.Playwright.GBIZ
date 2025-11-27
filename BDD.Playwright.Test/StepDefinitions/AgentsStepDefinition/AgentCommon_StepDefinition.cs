using BDD.Playwright.Core.Interfaces;
using BDD.Playwright.GBIZ.PageElements;
using BDD.Playwright.GBIZ.Pages.AgentsPages;
using BDD.Playwright.GBIZ.Pages.CommonPage;
using BDD.Playwright.GBIZ.Pages.XpathProperties;
using GoodVille.GBIZ.Reqnroll.Automation.Pages.GlobalPages;
using Microsoft.Playwright;

namespace GoodVille.GBIZ.Reqnroll.Automation.Steps.AgentsStepDefinition
{
    [Binding]
    public class AgentCommon_StepDefinition : BasePage
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly string _scenarioTitle;
        public FeatureContext _featureContext;
        public CommonXpath _commonXpath;
        public LoginPage _loginPage;
        public MyBusinessHomePage _myBusinessHomePage;
        private readonly IFileReader _fileReader;

        // Constructor
        public AgentCommon_StepDefinition(
            ScenarioContext scenarioContext,
            LoginPage loginPage,
            CommonXpath commonXpath,
            MyBusinessHomePage myBusinessHomePage,
            IFileReader fileReader)
            : base(scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _scenarioTitle = scenarioContext.ScenarioInfo.Title;
            _loginPage = loginPage;
            _commonXpath = commonXpath;
            _myBusinessHomePage = myBusinessHomePage;
            _fileReader = fileReader;
        }

        [When(@"User navigates to home page")]
        public async Task WhenUserNavigatesToHomePageAsync()
        {
            await Button.ClickButtonCssAsync(".gg-header.hydrated", _commonXpath.HomeMainShadow);
        }

        [When("User navigates to search page")]
        public async Task WhenUserNavigatesToSearchPageAsync()
        {
            await Button.ClickButtonCssAsync(_commonXpath.ShadowHostSlidePanelShadow, _commonXpath.SearchSidePanelShadow);
        }

        [When("User performs a search")]
        public async Task WhenUserPerformsASearchAsync()
        {
            var policyOrQuote = _fileReader.GetValue("AgentSearchPage.json", $"{_scenarioTitle}.SearcPolicyOrQuote", null);
            _scenarioContext["policyOrQuote"] = policyOrQuote;
            await InputField.SetTextAreaInputFieldAsync(_commonXpath.SearchPolicyPage_Keyword_Inp, policyOrQuote, true, 1);
        }

        [When("User navigates to policy details page")]
        public async Task WhenUserNavigatesToPolicyDetailsPageAsync()
        {
            var policyOrQuote = _scenarioContext["policyOrQuote"].ToString();
            var navigatetoPolicyXpath = string.Format(_commonXpath.SearchPolicyPage_NavigateToPolicyInfo, policyOrQuote);
            await Button.ClickButtonAsync(navigatetoPolicyXpath, ActionType.Click, true, 1);
        }

        [When("User navigates to policy details billing page")]
        public async Task WhenUserNavigatesToPolicyDetailsBillingPageAsync()
        {
            await TextLink.ClickTextLinkAsync(_commonXpath.PolicyDetailsPage_Billing_Link, true, 1);
        }

        [When(@"User navigates to business")]
        public async Task WhenUserNavigatesToBusinessAsync()
        {
            await Button.ClickButtonCssAsync("body > gg-page > gg-navigation", _commonXpath.BusinessMainShadow);
        }

        [When("User navigates to accounting page")]
        public async Task WhenUserNavigatesToAccountingPageAsync()
        {
            await Button.ClickButtonCssAsync(_commonXpath.ShadowHostSlidePanelShadow, _commonXpath.AccountingSidePanelShadow);
        }

        [When(@"User clicks on sign out")]
        public async Task WhenUserClicksOnSignOutAsync()
        {
            await Button.ClickButtonCssAsync("gg-navigation", "a[href*='logout']");
        }

        [When("User clicks on Mailing Preferences and Verify the Mailing Preferences Page has Displayed")]
        public async Task WhenUserClicksOnMailingPreferencesAndVerifyTheMailingPreferencesPageHasDisplayedAsync()
        {
            await TextLink.ClickTextLinkAsync(_commonXpath.MailingPreferences_Link, true, 1);
            if (await Label.VerifyTextAsync(_myBusinessHomePage.MailingPreferences_Text, "Mailing Preferences", true, 1))
            {
                Console.WriteLine("Mailing Preferences Page has been Displayed");
            }
        }

        [When(@"User selects agent and insured defaults checkbox")]
        public async Task WhenUserSelectsAgentAndInsuredDefaultsCheckboxAsync()
        {
            await Checkbox.SelectCheckboxAsync(_commonXpath.AgreementCommercialLinesNewAgent_Input, true, true, 1);
            await Checkbox.SelectCheckboxAsync(_commonXpath.AgreementCommercialLinesNewInsured_Input, true, true, 1);
        }

        [When("User navigates to back")]
        public async Task WhenUserNavigatesToBackAsync()
        {
            await page.GoBackAsync();
            await page.WaitForLoadStateAsync(LoadState.NetworkIdle);
        }

        [When("User clicks on close")]
        public async Task WhenUserClicksOnCloseAsync()
        {
            await Button.ClickButtonAsync(_commonXpath.Close_Button, ActionType.Click, true, 1);
        }
    }
}
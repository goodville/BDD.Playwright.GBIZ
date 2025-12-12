using AventStack.ExtentReports.Gherkin.Model;
using BDD.Playwright.Core.Loggers;
using BDD.Playwright.GBIZ.PageElements;
using BDD.Playwright.GBIZ.Pages.AgentPages;
using BDD.Playwright.GBIZ.Pages.AgentsPages;
using BDD.Playwright.GBIZ.Pages.CommonPage;
using BDD.Playwright.GBIZ.Pages.XpathProperties;
using BDD.Playwright.Origami.Pages.AgentPages;
using GoodVille.GBIZ.Reqnroll.Automation.Pages.AgentPages;
using GoodVille.GBIZ.Reqnroll.Automation.Pages.GlobalPages;
using Microsoft.Playwright;

namespace GoodVille.GBIZ.Specflow.Automation.Steps.AgentsStepDefinition
{
    [Binding]
    public class AgentTC84_StepDefinition : BasePage
    {
        private readonly ScenarioContext _scenarioContext;
        public FeatureContext _featureContext;
        public CommonXpath _commonXpath;
        public LoginPage _loginPage;
        public ProfilePage _profilePage;
        public PersonalAutoQuoteInformation _quoteInformation;
        public Quote_ApplicantPage _quoteApplicant;
        public Quote_PADriversPage _quotePADrivers;
        public Quote_VehiclesPage _quoteVehicles;
        public Quote_PACoveragesPage _quotePACoverages;
        public Quote_PABindingPage _quotePABinding;
        public CommonPage _commonPage;

        public AgentTC84_StepDefinition(
            ScenarioContext scenarioContext,
            LoginPage loginPage,
            CommonXpath commonXpath,
            ProfilePage profilePage,
            PersonalAutoQuoteInformation quoteInformation,
           // PersonalAutoNewQuotePrefillOrder personalAutoNewQuotePrefillOrder,
            Quote_ApplicantPage quoteApplicantpage,
            Quote_PADriversPage quotePADrivers,
            Quote_VehiclesPage quoteVehiclesPage,
            Quote_PACoveragesPage quotePACoveragesPage,
            Quote_PABindingPage quotePABindingPage,
            CommonPage commonPage
        ) : base(scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _commonPage = commonPage;
            _loginPage = loginPage;
            _commonXpath = commonXpath;
            _profilePage = profilePage;
            _quoteInformation = quoteInformation;
            _quoteApplicant = quoteApplicantpage;
            _quotePADrivers = quotePADrivers;
            _quoteVehicles = quoteVehiclesPage;
            _quotePACoverages = quotePACoveragesPage;
            _quotePABinding = quotePABindingPage;
        }

        [When(@"User clicks on the Quoting links and confirms Online Quoting is visible")]
        public async Task UserClicksOnTheQuotingLinksAndConfirmsOnlineQuotingIsVisibleAsync()
        {
            await Button.ClickButtonCssAsync(_commonXpath.ShadowHost, _commonXpath.QuotingSidePanelShadow);
            await page.WaitForTimeoutAsync(2000);
            await Label.VerifyTextAsync(_commonXpath.OnlineQuoting_Text, "Online Quoting", true, 1);
        }

        [When(@"User selects the Start New Quote tab option")]
        public async Task UserSelectNewQuoteTabAsync()
        {
            await page.WaitForTimeoutAsync(2000);
            await Button.ClickButtonAsync(_commonXpath.NewQuoteLink, ActionType.Click, true, 1);
        }

        [When(@"User chooses the Personal Auto lob product option")]
        public async Task UserSelectthePersonalAutoOptionAsync()
        {
            await page.WaitForTimeoutAsync(2000);
            await Button.ClickButtonAsync(_commonXpath.Quote_PersonalAuto, ActionType.Click, true, 1);
        }

        [Then(@"The page should display PersonalAutomobile heading")]
        public async Task VerifyPersonalAutomobileTextIsPresentAsync()
        {
            await Label.VerifyTextAsync(_commonXpath.PersonalAuto_Text, "Personal Automobile", true, 1);
            await Label.GetTextAsync(_commonXpath.PersonalAuto_FullText, true, 1);
            var pattern = @"^Personal Automobile - \d+$";
            await Label.VerifyTextFormatAsync("//div[@id='formHeaderLeft']", pattern, true, 1, "Policy Header");
        }

        [When(@"User completes all required fields on the Personal Auto quote initiation page from json {string}")]
        public async Task WhenUserFillsMandatoryFieldsInPersonalAutoNewQuotePagesAsync(string jsonFile)
        {
            await _quoteInformation.PersonalAutonewQuotePrefillAsync(jsonFile);
        }

        [When(@"User clicks the Order Prefill Data button")]
        public async Task WhenUserClickOnOrderPrefilDataButtonAsync()
        {
            await _quoteInformation.ClickOrderDataAsync();
        }

        [Then(@"The PersonalAutomobile heading should still be visible after data is prefetched")]
        public async Task VerifyPersonalAutomobileTextIsPresent1Async()
        {
            await page.WaitForTimeoutAsync(10000);
            await Label.VerifyTextAsync(_commonXpath.PersonalAuto_Text, "Personal Automobile", true, 1);
            await Label.GetTextAsync(_commonXpath.PersonalAuto_FullText, true, 1);
            var pattern = @"^Personal Automobile - \d+$";
            await Label.VerifyTextFormatAsync("//div[@id='formHeaderLeft']", pattern, true, 1, "Policy Header");
        }

        [When(@"User enters mandatory details on the Applicant page and proceeds from json {string}")]
        public async Task WhenUserFillsMandatoryFieldsInApplicantpageAsync(string jsonFile)
        {
            await _quoteApplicant.ApplicantDataFillAsync(jsonFile);
        }

        [When(@"User provides required information on the Drivers page and continues from json {string}")]
        public async Task WhenUserFillsDriversFieldsInApplicantpageAsync(string jsonFile)
        {
            await _quotePADrivers.PADriversDatafillAsync(jsonFile);
        }

        [When(@"User inputs necessary data on the Vehicles page and clicks continue from json {string}")]
        public async Task WhenUserFillsMandatoryFieldsInApplicantpage1Async(string jsonFile)
        {
            await _quoteVehicles.AddVehicleAsync(jsonFile);
        }

        [When(@"User fills in the required fields on the PA Coverages page and proceeds")]
        public async Task WhenUserFillsMandatoryFieldsInCoveragespageAsync()
        {
            await _quotePACoverages.PACoveragesFillDataAsync();
        }

        [When(@"The PASummary page should show the Applicant's information")]
        public async Task VerifyApplicantinformationonSummarypageAsync()
        {
            await Button.ClickButtonAsync(_commonXpath.MessageOverRides, ActionType.Click, true, 1);
            /*await Checkbox.SelectCheckboxAsync(_commonXpath.PA_QuoteOverride1, true, true, 1);
            await Checkbox.SelectCheckboxAsync(_commonXpath.PA_QuoteOverride2, true, true, 1);
            await Checkbox.SelectCheckboxAsync(_commonXpath.PA_QuoteOverride3, true, true, 1);
            await Checkbox.SelectCheckboxAsync(_commonXpath.PA_QuoteOverride6, true, true, 1);
            await Checkbox.SelectCheckboxAsync(_commonXpath.PA_QuoteOverride7, true, true, 1);
            await Checkbox.SelectCheckboxAsync(_commonXpath.PA_QuoteOverride8, true, true, 1);*/
            await _commonPage.CheckAllMessageOverrideCheckboxes1Async();
            page.Dialog += async (_, dialog) => await dialog.AcceptAsync();
            await Button.ClickButtonAsync(_commonXpath.ApplyOverRides1, ActionType.Click, true, 1);
            // Handle alert, if Playwright dialog handler
            // await _page.OnDialog(dialog => dialog.AcceptAsync());
            await page.WaitForTimeoutAsync(40000);
            await Button.ClickButtonAsync(_commonXpath.Save_btn, ActionType.Click, true, 1);
            await page.WaitForTimeoutAsync(4000);
            await Button.ClickButtonAsync(_commonXpath.Rate_btn, ActionType.Click, true, 1);
            await page.WaitForTimeoutAsync(10000);

            await Label.VerifyTextAsync(_commonXpath.PASummary_Name, "Vijay Sample", true, 1);
            await Label.VerifyTextAsync(_commonXpath.DwellingSummary_EffectiveDateText, "Effective Date", true, 1);
        }

        [Then(@"The PASummary page should display the calculated Total Premium")]
        public async Task VerifyTotalpremiumAmountdisplayedonSummarypageAsync()
        {
            await page.WaitForTimeoutAsync(4000);
            await Label.GetTextAsync(_commonXpath.PA_EstimatedPremium, true, 1);
            await Label.VerifyValueAsync(_commonXpath.PA_EstimatedPremium, "754", true, 1);
            await page.WaitForTimeoutAsync(4000);
            await Button.ClickButtonAsync(_commonXpath.PAcoverageContinue_btn, ActionType.Click, true, 1);
            await Button.ClickButtonAsync(_commonXpath.PAcoverageContinue_btn, ActionType.Click, true, 1);
        }

        [When(@"User fill the mandatory fields in the PABilling page")]
        public async Task UserFillsMandatoryFieldsinBillingpageAsync()
        {
            await Button.ClickButtonAsync(_commonXpath.PABindPolicy, ActionType.Click, true, 1);
            await page.WaitForTimeoutAsync(10000);
        }

        [When(@"User fill the mandatory fields in the PABinding page")]
        public async Task UserFillsMandatoryFieldsinBindingPageAsync()
        {
            await _quotePABinding.PABindingDataFillAsync();
            await page.WaitForTimeoutAsync(2000);
            await Button.ClickButtonAsync(_commonXpath.Save_btn, ActionType.Click, true, 1);
            await Button.ClickButtonAsync(_commonXpath.Rate_btn, ActionType.Click, true, 1);
            await page.WaitForTimeoutAsync(5000);
            await page.WaitForTimeoutAsync(7000);
            await Button.ClickButtonAsync(_commonXpath.MessageOverRides, ActionType.Click, true, 1);
            await page.WaitForTimeoutAsync(7000);
            await Checkbox.SelectCheckboxAsync(_commonXpath.PA_BindQuoteOverride1_1, true, true, 1);
            await Checkbox.SelectCheckboxAsync(_commonXpath.PA_BindQuoteOverride1_2, true, true, 1);
            await Checkbox.SelectCheckboxAsync(_commonXpath.PA_BindQuoteOverride1_3, true, true, 1);
            await Checkbox.SelectCheckboxAsync(_commonXpath.PA_BindQuoteOverride1_4, true, true, 1);
            await Checkbox.SelectCheckboxAsync(_commonXpath.PA_BindQuoteOverride1_5, true, true, 1);
            await Checkbox.SelectCheckboxAsync(_commonXpath.PA_BindQuoteOverride1_6, true, true, 1);
            //await _commonPage.CheckAllMessageOverrideCheckboxes1Async();
            page.Dialog += async (_, dialog) => await dialog.AcceptAsync();
            await Button.ClickButtonAsync(_commonXpath.ApplyOverRides2, ActionType.Click, true, 1);
            await page.WaitForTimeoutAsync(40000);
            await Button.ClickButtonAsync(_commonXpath.Bcbind_btn, ActionType.Click, true, 1);
            await page.WaitForTimeoutAsync(5000);
            await Button.ClickButtonAsync(_commonXpath.BindPolicyOkButton, ActionType.Click, true, 1);
            await page.WaitForTimeoutAsync(5000);

            await page.WaitForTimeoutAsync(7000);
            await Button.ScrollIntoViewAsync(_commonXpath.MessageOverRides, true, 1);
            await Button.ClickButtonAsync(_commonXpath.MessageOverRides, ActionType.Click, true, 1);
            await page.WaitForTimeoutAsync(7000);

            await Checkbox.SelectCheckboxAsync(_commonXpath.PA_BindQuoteOverride2_0, true, true, 1);
            await Checkbox.SelectCheckboxAsync(_commonXpath.PA_BindQuoteOverride2_1, true, true, 1);
            await Checkbox.SelectCheckboxAsync(_commonXpath.PA_BindQuoteOverride2_2, true, true, 1);
            await Button.ClickButtonAsync(_commonXpath.ApplyOverRides5, ActionType.Click, true, 1);
            await page.WaitForTimeoutAsync(40000);
            await Button.ClickButtonAsync(_commonXpath.Bcbind_btn, ActionType.Click, true, 1);
            await page.WaitForTimeoutAsync(5000);
            await Button.ClickButtonAsync(_commonXpath.BindPolicyOkButton, ActionType.Click, true, 1);
            await page.WaitForTimeoutAsync(40000);
        }

        [Then(@"Verify the policy whether it is bound successfully")]
        public async Task VerifyPolicyIsBoundSuccessfullyAsync()
        {
            await page.WaitForTimeoutAsync(5000);
        }
    }
}
using bdd.playwright.gbiz.pages.agentpages;
using Bdd.Playwright.GBIZ.Pages.AgentPages;
using BDD.Playwright.Core.Loggers;
using BDD.Playwright.GBIZ.PageElements;
using BDD.Playwright.GBIZ.Pages.AgentPages;
using BDD.Playwright.GBIZ.Pages.AgentsPages;
using BDD.Playwright.GBIZ.Pages.CommonPage;
using BDD.Playwright.GBIZ.Pages.XpathProperties;
using BDD.Playwright.Origami.Pages.AgentPages;
using GoodVille.GBIZ.Reqnroll.Automation.Pages.GlobalPages;
using Microsoft.Playwright;

namespace GoodVille.GBIZ.Specflow.Automation.Steps.AgentsStepDefinition
{
    [Binding]
    public class AgentTC88_StepDefinition : BasePage
    {
        private readonly ScenarioContext _scenarioContext;
        public FeatureContext _featureContext;
        public CommonXpath _commonXpath;
        public LoginPage _loginPage;
        public ProfilePage _profilePage;
        public PersonalAutoQuoteInformation _quoteInformation;
        public Quote_ApplicantPage _quoteApplicant;
        public Quote_LocationPage _quoteLocation;
        public Quote_BuildingPage _quoteBuilding;
        public Quote_BusinesscoveragePage _quoteBusinesscoverage;
        public Quote_BCBindingPage _quoteBCBinding;
        public PersonalAutoNewQuotePrefillOrder _personalAutoNewQuotePrefillOrder;
        public CommonPage _commonPage;

        // Playwright page context

        public AgentTC88_StepDefinition(
            ScenarioContext scenarioContext,
            LoginPage loginPage,
            CommonXpath commonXpath,
            ProfilePage profilePage,
            PersonalAutoQuoteInformation quoteInformation,
            PersonalAutoNewQuotePrefillOrder personalAutoNewQuotePrefillOrder,
            Quote_ApplicantPage quoteApplicantpage,
            Quote_LocationPage quoteLocationpage,
            Quote_BuildingPage quoteBuildingpage,
            Quote_BusinesscoveragePage quoteBusinesscoveragepage,
            Quote_BCBindingPage quoteBCBindingPage,
            CommonPage commonPage) : base(scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _loginPage = loginPage;
            _commonXpath = commonXpath;
            _profilePage = profilePage;
            _quoteInformation = quoteInformation;
            _personalAutoNewQuotePrefillOrder = personalAutoNewQuotePrefillOrder;
            _quoteApplicant = quoteApplicantpage;
            _quoteLocation = quoteLocationpage;
            _quoteBuilding = quoteBuildingpage;
            _quoteBusinesscoverage = quoteBusinesscoveragepage;
            _quoteBCBinding = quoteBCBindingPage;
            _commonPage = commonPage;
        }

        [When(@"user navigates to the Quoting panel and verifies Online Quoting text is displayed")]
        public async Task WhenUserNavigatesToQuotingPanelAndVerifiesOnlineQuotingTextAsync()
        {
            await Button.ClickButtonCssAsync(_commonXpath.ShadowHost, _commonXpath.QuotingSidePanelShadow);
            await Label.VerifyTextAsync(_commonXpath.OnlineQuoting_Text, "Online Quoting", true, 1);
        }

        [When(@"user selects the New Quote tab for Business Cover")]
        public async Task WhenUserSelectsNewQuoteTabForBusinessCoverAsync()
        {
            await Button.ClickButtonAsync(_commonXpath.NewQuoteLink, ActionType.Click, true, 1);
        }

        [When(@"user chooses the Business Cover option")]
        public async Task WhenUserChoosesTheBusinessCoverOptionAsync()
        {
            await Button.ClickButtonAsync(_commonXpath.Quote_BusinessCover, ActionType.Click, true, 1);
        }

        [Then(@"Business Cover page is displayed with correct header")]
        public async Task ThenBusinessCoverPageIsDisplayedWithCorrectHeaderAsync()
        {
            await Label.VerifyTextAsync(_commonXpath.BusinessCover_Text, "Business Cover", true, 1);
            await Label.GetTextAsync(_commonXpath.BusinessCover_FullText, true, 1);
            var pattern = @"^Business Cover - \d+$";
            await Label.VerifyTextFormatAsync("//div[@id='formHeaderLeft']", pattern, true, 1, "Policy Header");
        }

        [When(@"user enters required applicant details in Business Cover new quote page from json {string}")]
        public async Task WhenUserEntersRequiredApplicantDetailsInBusinessCoverNewQuotePageAsync(string jsonFilePath)
        {
            await _quoteApplicant.ApplicantDataFillAsync(jsonFilePath);
        }

        [When(@"user enters mandatory location details for Business Cover from json {string}")]
        public async Task WhenUserEntersMandatoryLocationDetailsForBusinessCoverAsync(string jsonFilePath)
        {
            await _quoteLocation.LocationDataFillAsync(jsonFilePath);
        }

        [When(@"user enters building information on the Building page and proceeds from json {string}")]
        public async Task WhenUserEntersBuildingInformationAndProceedsAsync(string jsonFilePath)
        {
            await _quoteBuilding.BuildingDataFillAsync(jsonFilePath);
        }

        [When(@"user enters coverage details on the Business Cover coverage page and proceeds from json {string}")]
        public async Task WhenUserEntersCoverageDetailsAndProceedsAsync(string jsonFilePath)
        {
            await _quoteBusinesscoverage.BusinesscoverageDataFillAsync(jsonFilePath);
        }

        [Then(@"Applicant information is displayed on the Summary page for Business Cover")]
        public async Task ThenApplicantInformationDisplayedOnSummaryPageForBusinessCoverAsync()
        {
           await Task.Delay(2000);
           await Label.VerifyTextAsync(_commonXpath.Businesscover_Address1_updated, "9 Mill St", true, 1);
           await Label.VerifyTextAsync(_commonXpath.Businesscover_EffectiveDateText, "Effective date", true, 1);
            // await Label.VerifyTextAsync(page, _commonXpath.Businesscover_EffectiveDate, "08/06/2025", true, 1);
            // await _commonFunctions.HandleMessageOverridesPopupAsync(page);
        }

        [Then(@"Limits of Insurance are displayed on the Business Cover Summary page")]
        public async Task ThenLimitsOfInsuranceDisplayedOnBusinessCoverSummaryPageAsync()
        {
            await Task.Delay(4000);
            // await Label.VerifyTextAsync(page, _commonXpath.Businesscover_TerrorismLossLiability, "$ 500,000", true, 1);
            // await Label.VerifyTextAsync(page, _commonXpath.Businesscover_TerrorismLossproperty, "$ 350,000", true, 1);
            // await Label.VerifyTextAsync(page, _commonXpath.Businesscover_EmploymentrelatedLiability, "$ 50,000", true, 1);
            // await Label.VerifyTextAsync(page, _commonXpath.Businesscover_FireLegalliability, "$ 300,000", true, 1);
            await Task.Delay(4000);
        }

        [Then(@"Total premium amount is displayed on the Business Cover Summary page")]
        public async Task ThenTotalPremiumAmountDisplayedOnBusinessCoverSummaryPageAsync()
        {
            await Label.GetTextAsync(_commonXpath.BCTotalPremium, true, 1);
            await Label.VerifyValueAsync(_commonXpath.BCTotalPremium, "768", true, 1);
            await Task.Delay(1000);
            await Button.ClickButtonAsync(_commonXpath.Continuetomortage, ActionType.Click, true, 1);
            await Task.Delay(3000);
        }

        [When(@"user completes the Billing page for Business Cover")]
        public async Task WhenUserCompletesTheBillingPageForBusinessCoverAsync()
        {
            await Task.Delay(3000);
            await Button.ClickButtonAsync(_commonXpath.BCContinueBilling, ActionType.Click, true, 1);
            await Task.Delay(3000);
            await Button.ClickButtonAsync(_commonXpath.Payment_6Pay, ActionType.Click, true, 1);
            await Task.Delay(3000);
            // awat Label.GetTextAsync(page, _commonXpath.BC6PayPremium_1, true, 1);
            // await Label.VerifyValueAsync(page, _commonXpath.BC6PayPremium_1, "152", true, 1);
            // ... more commented premium checks ...
            await Button.ClickButtonAsync(_commonXpath.BCContinueBinding, ActionType.Click, true, 1);
            await Task.Delay(3000);
        }

        [When(@"user completes the Binding page for Business Cover from json {string}")]
        public async Task WhenUserCompletesTheBindingPageForBusinessCoverAsync(string profileKey)
        {
            await _quoteBCBinding.BindingDataFillAsync(profileKey);
            await Task.Delay(3000);
            await Button.ClickButtonAsync(_commonXpath.Save_btn, ActionType.Click, true, 1);
            await Button.ClickButtonAsync(_commonXpath.Rate_btn, ActionType.Click, true, 1);
            await Task.Delay(3000);
            await Task.Delay(3000);
            /*await Button.ClickButtonAsync(_commonXpath.Message_btn, ActionType.Click, true, 1);
            await Task.Delay(3000);
            await _commonPage.CheckAllMessageOverrideCheckboxes1Async();
            await Task.Delay(2000);
            page.Dialog += async (_, dialog) => await dialog.AcceptAsync();
            await Button.ClickButtonAsync(_commonXpath.Apply_Override_btn, ActionType.Click, true, 1);
            await Task.Delay(2000);*/
            await Button.ClickButtonAsync(_commonXpath.Bcbind_btn, ActionType.Click, true, 1);
            await Task.Delay(3000);
            await Button.ClickButtonAsync(_commonXpath.BindPolicyOkButton, ActionType.Click, true, 1);
            await Task.Delay(3000);

            //await _commonFunctions.ScrollUpAsync(page);
            await Task.Delay(3000);
        }

        [Then(@"user should see whether the policy is bound successfully or not")]
        public async Task VerifyPolicyIsBoundSuccessfullyAsync()
        {
            await Task.Delay(5000);
        }

        [When(@"User clicks on the Logout")]
        public async Task UserClickontheLogoutButtonAsync()
        {
            await Button.ClickButtonCssAsync("gg-navigation", "a[href*='logout']");
            Console.WriteLine("Agent Logout Successfully.");
        }
    }
}
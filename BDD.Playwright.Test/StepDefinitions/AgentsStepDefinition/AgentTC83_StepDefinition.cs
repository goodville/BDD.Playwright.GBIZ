using BDD.Playwright.Core.Loggers;
using BDD.Playwright.GBIZ.PageElements;
using BDD.Playwright.GBIZ.Pages.AgentPages;
using BDD.Playwright.GBIZ.Pages.CommonPage;
using BDD.Playwright.GBIZ.Pages.XpathProperties;
using BDD.Playwright.Origami.Pages.AgentPages;
using GoodVille.GBIZ.Reqnroll.Automation.Pages.AgentPages;
using GoodVille.GBIZ.Reqnroll.Automation.Pages.GlobalPages;
using Microsoft.Playwright;

namespace GoodVille.GBIZ.Specflow.Automation.Steps.AgentsStepDefinition
{
    [Binding]
    public class AgentTC83_StepDefinition : BasePage
    {
        private readonly ScenarioContext _scenarioContext;
        public FeatureContext _featureContext;
        public CommonXpath _commonXpath;
        public Quote_ApplicantPage _quoteApplicant;
        public Quote_CoveragesPage _quoteCoverage;
        public Quote_DwellingPage _quoteDwelling;
        public Quote_AdditionalInterestPage _quoteAdditionalInterestPage;
        public Quote_BindingPage _quoteBindingPage;
        public Quote_PropertyPage _quotePropertyPage;
        public Quote_ClaimsPage _quoteClaimsPage;
        public Quote_ScheduledPage _quoteScheduledPage;
        public CommonPage _commonPage;
        public AgentTC83_StepDefinition(
            ScenarioContext scenarioContext,
            CommonXpath commonXpath,
            Quote_ApplicantPage quoteApplicantpage,
            Quote_CoveragesPage quoteCoveragespage,
            Quote_DwellingPage quoteDwellingpage,
            Quote_AdditionalInterestPage quoteAdditionalInterestPage,
            Quote_BindingPage quoteBindingPage,
            Quote_PropertyPage propertyPage,
            Quote_ClaimsPage claimsPage,
            CommonPage commonPage,
            Quote_ScheduledPage scheduledPage): base(scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _commonXpath = commonXpath;
            _quoteApplicant = quoteApplicantpage;
            _quoteCoverage = quoteCoveragespage;
            _quoteDwelling = quoteDwellingpage;
            _quoteAdditionalInterestPage = quoteAdditionalInterestPage;
            _quoteBindingPage = quoteBindingPage;
            _quotePropertyPage = propertyPage;
            _quoteClaimsPage = claimsPage;
            _quoteScheduledPage = scheduledPage;
            _commonPage = commonPage;
        }

        [When(@"user Clicks on the 'Quoting link' and Verify 'Online Quoting' text is displayed")]
        public async Task UserClickontheQuotinglinkandverifyOnlineQuotingtextisdisplayedAsync()
        {
            await Button.ClickButtonCssAsync(_commonXpath.ShadowHost, _commonXpath.QuotingSidePanelShadow);
            await page.WaitForTimeoutAsync(2000);
            await Label.VerifyTextAsync(_commonXpath.OnlineQuoting_Text, "Online Quoting", true, 1);
        }

        [When(@"user selects the new Quote")]
        public async Task UserSelectNewQuoteTabAsync()
        {
            await page.WaitForTimeoutAsync(2000);
            await Button.ClickButtonAsync(_commonXpath.NewQuoteLink, ActionType.Click, true, 1);
        }

        [When(@"User select 'Homeowner'")]
        public async Task UserSelectHomeownersOptionAsync()
        {
            await page.WaitForTimeoutAsync(2000);
            await Button.ClickButtonAsync(_commonXpath.Quote_Homeowners, ActionType.Click, true, 1);
        }

        [Then(@"verify I have informed the Insured checkbox is Present")]
        public async Task VerifyCheckboxIsPresentAsync()
        {
            await Checkbox.VerifyCheckboxExistAsync(_commonXpath.InfoLMICnsuredCheckbox, true, 1, "I have informed the insured");
            await Label.VerifyTextAsync(_commonXpath.InfoLMICnsuredCheckbox, "I have informed the insured", true, 1);
        }

        [Then(@"verify continue button Exist")]
        public async Task VerifyContinueButtonIsPresentAsync()
        {
            await Button.VerifyButtonExistAsync( _commonXpath.Quote_Continue_Btn, true, 1, "Continues");
            await Label.VerifyTextAsync(_commonXpath.Quote_Continue_Btn, "Continue", true, 1);
        }

        [When(@"User select I have informed the insured checkbox and click Continue Button")]
        public async Task UserSelecttheIhaveinformedtheinsuredCheckboxandClickContinueAsync()
        {
            await Button.ClickButtonAsync(_commonXpath.InfoLMICnsuredCheckbox, ActionType.Click, true, 1);
            await Button.ClickButtonAsync(_commonXpath.Quote_Continue_Btn, ActionType.Click, true, 1);
        }

        [Then(@"verify Homeowner text is present")]
        public async Task VerifyHomeownersTextIsPresentAsync()
        {
            await Label.VerifyTextAsync(_commonXpath.Homeowners_Text, "Homeowners", true, 1);
            await Label.GetTextAsync(_commonXpath.PersonalAuto_FullText, true, 1);

            var pattern = @"^Homeowners - \d+$";
            await Label.VerifyTextFormatAsync("//div[@id='formHeaderLeft']", pattern, true, 1, "Policy Header");
        }

        [When("User fills the mandatory field in the Homeowner Applicant Page and click continue button from json {string}")]
        public async Task WhenUserFillsTheMandatoryFieldInTheHomeOwnerApplicantPageAndClickContinueButtonAsync(string jsonFile)
        {
            await _quoteApplicant.HomeOwnersApplicantDatafillAsync(jsonFile);
            await page.WaitForTimeoutAsync(10000);
        }

        [When("User fills the mandatory field in the Homeowner Property Page and click continue button from json {string}")]
        public async Task WhenUserFillsTheMandatoryFieldInTheHomeOwnerPropertyPageAndClickContinueButtonAsync(string jsonFile)
        {
            await _quotePropertyPage.PropertyDatafillAsync(jsonFile);
            await page.WaitForTimeoutAsync(1000);
        }

        [When("User fills the mandatory field in the Homeowner Coverage Page and click continue button from json {string}")]
        public async Task WhenUserFillsTheMandatoryFieldInTheHomeOwnerCoveragePageAndClickContinueButtonAsync(string jsonFile)
        {
            await _quoteCoverage.HomeOwnersCoveragesDatafillAsync(jsonFile);
            await page.WaitForTimeoutAsync(1000);
        }

        [When("User fills the mandatory field in the Homeowner Scheduled Page and click continue button from json {string}")]
        public async Task WhenUserFillsTheMandatoryFieldInTheHomeOwnerScheduledPageAndClickContinueButtonAsync(string jsonFile)
        {
            await _quoteScheduledPage.VerifyScheduledQuotesPageAsync(jsonFile);
            await page.WaitForTimeoutAsync(1000);
        }

        [When("User fills the mandatory field in the Homeowner Claims Page and click continue button")]
        public async Task WhenUserFillsTheMandatoryFieldInTheHomeOwnerClaimsPageAndClickContinueButtonAsync()
        {
            //await _commonFunctions.ScrollUpAsync(page);
            await page.WaitForTimeoutAsync(50000); // Replace with a proper wait
            await Button.ClickButtonAsync(_commonXpath.MessageOverRides, ActionType.Click, true, 1);
            await Checkbox.SelectCheckboxAsync(_commonXpath.HO_QuoteOver1, true, true, 1);
            await Checkbox.SelectCheckboxAsync(_commonXpath.HO_QuoteOver2, true, true, 1);
            await Checkbox.SelectCheckboxAsync(_commonXpath.HO_QuoteOver3, true, true, 1);
            await Checkbox.SelectCheckboxAsync(_commonXpath.HO_QuoteOver4, true, true, 1);
            await _commonPage.CheckAllMessageOverrideCheckboxes1Async();

            //await page.WaitForTimeoutAsync(5000);
            page.Dialog += async (_, dialog) => await dialog.AcceptAsync();
            await Button.ClickButtonAsync(_commonXpath.ApplyOverRides1, ActionType.Click, true, 1);

            await page.WaitForTimeoutAsync(5000);
            await Button.ClickButtonAsync(_commonXpath.ContinueSummary, ActionType.Click, true, 1);
            await page.WaitForTimeoutAsync(1000);
        }

        [Then("Verify Homeowner Applicant information displayed on the Summary Page")]
        public async Task ThenVerifyHomeOwnerApplicantInformationDisplayedOnTheSummaryPageAsync()
        {
            //await _commonFunctions.ScrollUpAsync(page);
            //await _commonFunctions.ScrollUpAsync(page);
            await Button.ClickButtonAsync(_commonXpath.Save1_btn, ActionType.Click, true, 1);
            await page.WaitForTimeoutAsync(5000);
            //await _commonFunctions.ScrollUpAsync(page);
            //await _commonFunctions.ScrollUpAsync(page);
            await page.WaitForTimeoutAsync(1000);
            await Button.ClickButtonAsync(_commonXpath.Rate1_btn, ActionType.Click, true, 1);
            await page.WaitForTimeoutAsync(10000);

            await Label.VerifyTextAsync(_commonXpath.HO_ApplicantName, "Sam SamplePA", true, 1);
            await Label.VerifyTextAsync(_commonXpath.HO_EffectievDate, "12/12/2025", true, 1);
            await Label.VerifyTextAsync(_commonXpath.HO_AllPerilsDeductible, "$1,000.00", true, 1);
            await Label.VerifyTextAsync(_commonXpath.HO_WindHailDeductible, "$2,000.00", true, 1);
            await Label.VerifyTextAsync(_commonXpath.HO_MailingAddress, "625 W Main St", true, 1);
            await Label.VerifyTextAsync(_commonXpath.HO_PropertyAddress, "625 W Main St", true, 1);
            await Label.VerifyTextAsync(_commonXpath.HO_YearofConstruction, "2000", true, 1);
            await Label.VerifyTextAsync(_commonXpath.HO_Protection, "Protected A", true, 1);
            await Label.VerifyTextAsync( _commonXpath.HO_ConstructionType, "Frame", true, 1);
            await Label.VerifyTextAsync( _commonXpath.HO_ResidenceType, "Dwelling", true, 1);
            await Label.VerifyTextAsync( _commonXpath.HO_OccupancyType, "Primary", true, 1);
            await Label.VerifyTextAsync(_commonXpath.HO_NumberofFamilies, "1", true, 1);
           // await _commonFunctions.ScrollUpAsync(page);
        }

        [Then("Verify Homeowner Limits of Insurance information displayed on the Summary Page")]
        public async Task VerifyHomeOwnerLimitsOfInsuranceInformationDisplayedOnTheSummaryPageAsync()
        {
            await page.WaitForTimeoutAsync(2000);
            //await _commonFunctions.ScrollDownAsync(page);
            //await _commonFunctions.UserWaitForPageToLoadCompletlyAsync(page);
            await Label.VerifyTextAsync(_commonXpath.HO_Dwelling_Label, "A. Dwelling", true, 1);
            await Label.VerifyValueAsync(_commonXpath.HO_Dwelling_Amount, "200,000", true, 1);
            await Label.VerifyTextAsync(_commonXpath.HO_RelatedPrivateStructures_Label, "B. Related Private Structures", true, 1);
            await Label.VerifyValueAsync(_commonXpath.HO_RelatedPrivateStructures_Amount, "20,000", true, 1);
            await Label.VerifyTextAsync(_commonXpath.HO_PersonalProperty_Label, "C. Personal Property", true, 1);
            await Label.VerifyValueAsync(_commonXpath.HO_PersonalProperty_Amount, "150,000", true, 1);
            await Label.VerifyTextAsync(_commonXpath.HO_AdditionalLivingCosts_LossOfRents_Label, "D. Additional Living Costs & Loss of Rents", true, 1);
            await Label.VerifyTextAsync(_commonXpath.HO_AdditionalLivingCosts, "Unlimited", true, 1);
            //await Label.VerifyTextAsync(_commonXpath.HO_HomeCoverExtraEndorsement_Label, "Home Cover Extra Endorsement", true, 1);
            await Label.VerifyValueAsync(_commonXpath.HO_HomeCoverExtraEndorsement_Amount, "45", true, 1);
            //await Label.VerifyTextAsync(_commonXpath.HO_HomeCoverExtraEndorsement_Label, "Home Cover Extra Endorsement", true, 1);
            await Label.VerifyTextAsync(_commonXpath.HO_ProtectiveDevices_Amount, "-12", true, 1);
        }

        [Then("Verify Homeowner Total premium amount displayed on the Summary Page")]
        public async Task ThenVerifyHomeOwnerTotalPremiumAmountDisplayedOnTheSummaryPageAsync()
        {
            await page.WaitForTimeoutAsync(2000);
           // await _commonFunctions.ScrollUpAsync(page);
            await Label.GetTextAsync(_commonXpath.HO_EstimatedPremium, true, 1);
            await Label.VerifyValueAsync(_commonXpath.HO_EstimatedPremium, "655", true, 1);
            await page.WaitForTimeoutAsync(3000);
           // await _commonFunctions.ScrollDownAsync(page);
            await Button.ClickButtonAsync(_commonXpath.Continuetomortage, ActionType.Click, true, 1);
            await page.WaitForTimeoutAsync(30000);
        }

        [When("User Click on the Continue to billing on Additional Interest Page")]
        public async Task WhenUserClickOnTheContinueToBillingOnAdditionalInterestPageAsync()
        {
           // await _commonFunctions.ScrollUpAsync(page);
           // await _commonFunctions.ScrollUpAsync(page);
            await page.WaitForTimeoutAsync(3000);
            await Button.ClickButtonAsync(_commonXpath.Continuetomortage, ActionType.Click, true, 1);
            await page.WaitForTimeoutAsync(3000);
        }

        [When(@"User fills mandatory field in the Homeowner Billing page and Verify the 6Pay Payment plans are displayed")]
        public async Task UserFillsMandatoryFieldsinBillingpageAsync()
        {
            await page.WaitForTimeoutAsync(30000);
            await Button.ClickButtonAsync(_commonXpath.Payment_6Pay, ActionType.Click, true, 1);
            await page.WaitForTimeoutAsync(5000);
            await page.WaitForTimeoutAsync(5000);
            await page.WaitForTimeoutAsync(3000);
            await Button.ClickButtonAsync(_commonXpath.ContinueBinding, ActionType.Click, true, 1);
            await page.WaitForTimeoutAsync(3000);
        }

        [When(@"User fills mandatory field in the Homeowner Binding Page and click Bind Policy Button from json {string}")]
        public async Task UserFillsMandatoryFieldsinBindingPageAsync(string jsonFile)
        {
            await _quoteBindingPage.BindingDataFillAsync(jsonFile);
            await page.WaitForTimeoutAsync(1000);
            //await _commonFunctions.ScrollDownAsync(page);
            await page.WaitForTimeoutAsync(10000);
            //await _commonFunctions.UserWaitForPageToLoadCompletlyAsync(page);
        }

        [Then(@"Verify Policy Number is generated for the HomeOwner Quote")]
        public async Task ClicksBindPolicyWithPolicyAsync()
        {
            await Button.ClickButtonAsync(_commonXpath.BindPolicywithGoodVilleButton, ActionType.Click, true, 1);
            await page.WaitForTimeoutAsync(10000);
            await Button.ClickButtonAsync(_commonXpath.BindPolicyOkButton, ActionType.Click, true, 1);
            await page.WaitForTimeoutAsync(20000);
           // await _commonFunctions.UserWaitForPageToLoadCompletlyAsync(page);
            await page.WaitForTimeoutAsync(5000);

            await Label.VerifyTextAsync(_commonXpath.HO_PolicyNumber, "Your Policy Number is", true, 1);
            logger.WriteLine("Policy number Generated");
            await Label.GetTextAsync(_commonXpath.HO_PolicyNumber, true, 1);
            await Label.VerifyTextAsync(_commonXpath.Homeowners_Text, "Homeowners", true, 1);
            await Label.GetTextAsync(_commonXpath.PersonalAuto_FullText, true, 1);

            var pattern = @"^Homeowners - \d+$";
            await Label.VerifyTextFormatAsync("//div[@id='formHeaderLeft']", pattern, true, 1, "Policy Header");
            await page.WaitForTimeoutAsync(5000);
        }

        [When(@"user click on Logout Button")]
        public async Task UserClickontheLogoutButtonAsync()
        {
            await Button.ClickButtonCssAsync("gg-navigation", "a[href*='logout']");
            Console.WriteLine("Agent Logout Successfully.");
        }
    }
}
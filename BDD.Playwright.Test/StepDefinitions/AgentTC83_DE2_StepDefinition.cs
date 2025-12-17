using AventStack.ExtentReports.Gherkin.Model;
using BDD.Playwright.Core.Loggers;
using BDD.Playwright.GBIZ.PageElements;
using BDD.Playwright.GBIZ.Pages.AgentPages;
using BDD.Playwright.GBIZ.Pages.CommonPage;
using BDD.Playwright.GBIZ.Pages.XpathProperties;
using BDD.Playwright.Origami.Pages.AgentPages;
using GoodVille.GBIZ.Reqnroll.Automation.Pages.AgentPages;
using Microsoft.Playwright;

namespace GoodVille.GBIZ.Specflow.Automation.Steps.AgentsStepDefinition
{
    [Binding]
    public class AgentTC83_DE2_StepDefinition : BasePage
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

        public AgentTC83_DE2_StepDefinition(
            ScenarioContext scenarioContext,
            CommonXpath commonXpath,
            Quote_ApplicantPage quoteApplicantpage,
            Quote_CoveragesPage quoteCoveragespage,
            Quote_DwellingPage quoteDwellingpage,
            Quote_AdditionalInterestPage quoteAdditionalInterestPage,
            Quote_BindingPage quoteBindingPage,
            Quote_PropertyPage propertyPage,
            Quote_ClaimsPage claimsPage,
            Quote_ScheduledPage scheduledPage,
            CommonPage commonPage
        ) : base(scenarioContext)
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

        [When(@"user Clicks on the Quoting Link and verify Online Quoting text is Displayed.")]
        public async Task UserClickontheQuotinglinkandverifyOnlineQuotingtextisdisplayedAsync()
        {
            await Button.ClickButtonCssAsync(_commonXpath.ShadowHost, _commonXpath.QuotingSidePanelShadow);
            await page.WaitForTimeoutAsync(2000);
            await Label.VerifyTextAsync(_commonXpath.OnlineQuoting_Text, "Online Quoting", true, 1);
        }

        [When(@"User selects the new Quote.")]
        public async Task UserSelectNewQuoteTabAsync()
        {
            await page.WaitForTimeoutAsync(2000);
            await Button.ClickButtonAsync(_commonXpath.NewQuoteLink, ActionType.Click, true, 1);
        }

        [When(@"User select HomeOwner.")]
        public async Task UserSelectHomeownersOptionAsync()
        {
            await page.WaitForTimeoutAsync(2000);
            await Button.ClickButtonAsync(_commonXpath.Quote_Homeowners, ActionType.Click, true, 1);
        }

        [Then(@"verify I have Informed the Insured checkbox is present.")]
        public async Task VerifyCheckboxIsPresentAsync()
        {
            await Checkbox.VerifyCheckboxExistAsync(_commonXpath.InfoLMICnsuredCheckbox, true, 1, "I have informed the insured");
            await Label.VerifyTextAsync(_commonXpath.InfoLMICnsuredCheckbox, "I have informed the insured", true, 1);
        }

        [Then(@"Verify continue button exist.")]
        public async Task VerifyContinueButtonIsPresentAsync()
        {
            await Button.VerifyButtonExistAsync(_commonXpath.Quote_Continue_Btn, true, 1, "Continues");
            await Label.VerifyTextAsync(_commonXpath.Quote_Continue_Btn, "Continue", true, 1);
        }

        [When(@"User Select I have informed the insured checkbox and click continue Button.")]
        public async Task UserSelecttheIhaveinformedtheinsuredCheckboxandClickContinueAsync()
        {
            await Button.ClickButtonAsync(_commonXpath.InfoLMICnsuredCheckbox, ActionType.Click, true, 1);
            await Button.ClickButtonAsync(_commonXpath.Quote_Continue_Btn, ActionType.Click, true, 1);
        }

        [Then(@"verify HomeOwner text is present.")]
        public async Task VerifyHomeownersTextIsPresentAsync()
        {
            await Label.VerifyTextAsync(_commonXpath.Homeowners_Text, "Homeowners", true, 1);
            await Label.GetTextAsync(_commonXpath.PersonalAuto_FullText, true, 1);
            var pattern = @"^Homeowners - \d+$";
            await Label.VerifyTextFormatAsync("//div[@id='formHeaderLeft']", pattern, true, 1, "Policy Header");
        }

        [When("user Override the checkbox in Homeowner Claims Page and click continue button.")]
        public async Task WhenUserFillsTheMandatoryFieldInTheHomeOwnerClaimsPageAndClickContinueButtonAsync()
        {
            await page.WaitForTimeoutAsync(50000);
            await Button.ClickButtonAsync(_commonXpath.MessageOverRides, ActionType.Click, true, 1);
            await _commonPage.CheckAllMessageOverrideCheckboxes1Async();
            page.Dialog += async (_, dialog) => await dialog.AcceptAsync();
            await Button.ClickButtonAsync(_commonXpath.ApplyOverRides1, ActionType.Click, true, 1);
            await page.WaitForTimeoutAsync(50000);
            await Button.ClickButtonAsync(_commonXpath.ContinueSummary, ActionType.Click, true, 1);
            await page.WaitForTimeoutAsync(1000);
        }

        [Then("Verify Homeowner Applicant Information displayed on Summary Page.")]
        public async Task ThenVerifyHomeOwnerApplicantInformationDisplayedOnTheSummaryPageAsync()
        {
            await Button.ClickButtonAsync(_commonXpath.Save1_btn, ActionType.Click, true, 1);
            await page.WaitForTimeoutAsync(5000);
            await Button.ClickButtonAsync(_commonXpath.Rate1_btn, ActionType.Click, true, 1);
            await page.WaitForTimeoutAsync(10000);
            await Label.VerifyTextAsync(_commonXpath.HO_ApplicantName1, "Sam Sample", true, 1);
            await Label.VerifyTextAsync(_commonXpath.HO_AllPerilsDeductible1, "$1,000.00", true, 1);
            await Label.VerifyTextAsync(_commonXpath.HO_MailingAddres1, "1 Anna Ave", true, 1);
            await Label.VerifyTextAsync(_commonXpath.HO_PropertyAddress1, "1 Anna Ave", true, 1);
            await Label.VerifyTextAsync(_commonXpath.HO_YearofConstruction1, "2000", true, 1);
            await Label.VerifyTextAsync(_commonXpath.HO_Protection2, "Protected A", true, 1);
            await Label.VerifyTextAsync(_commonXpath.HO_ConstructionType1, "Frame", true, 1);
            await Label.VerifyTextAsync(_commonXpath.HO_ResidenceType1, "Dwelling", true, 1);
            await Label.VerifyTextAsync(_commonXpath.HO_OccupancyType1, "Primary", true, 1);
            await Label.VerifyTextAsync(_commonXpath.HO_NumberofFamilies1, "1", true, 1);
        }

        [Then("Verify Homeowner Limits of insurance information displayed on Summary Page.")]
        public async Task VerifyHomeOwnerLimitsOfInsuranceInformationDisplayedOnTheSummaryPageAsync()
        {
            await page.WaitForTimeoutAsync(2000);
            _commonPage.UserWaitForPageToLoadCompletly();
            await Label.VerifyTextAsync(_commonXpath.HO_Dwelling_Label, "A. Dwelling", true, 1);
            await Label.VerifyValueAsync(_commonXpath.HO_SummaryDwelling_Amount, "60,000", true, 1);
            await Label.VerifyTextAsync(_commonXpath.HO_PersonalProperty_Label, "C. Personal Property", true, 1);
            await Label.VerifyValueAsync(_commonXpath.HO_SummarylProperty_Amount, "100,000", true, 1);
            await Label.VerifyTextAsync(_commonXpath.HO_AdditionalLivingCosts_LossOfRents_Label, "D. Additional Living Costs & Loss of Rents", true, 1);
            await Label.VerifyTextAsync(_commonXpath.HO_AdditionalLivingCosts, "Unlimited", true, 1);
            await Label.VerifyValueAsync(_commonXpath.HO_SummaryCoverExtraEndorsement_Amount, "25", true, 1);
            await Label.VerifyTextAsync(_commonXpath.HO_SummaryProtectiveDevices_Amount1, "-11", true, 1);
        }

        [Then("Verify Homeowner Total Premium Amount displayed on Summary Page.")]
        public async Task ThenVerifyHomeOwnerTotalPremiumAmountDisplayedOnTheSummaryPageAsync()
        {
            await page.WaitForTimeoutAsync(2000);
            await Label.GetTextAsync(_commonXpath.HO_EstimatedPremium, true, 1);
            await Label.VerifyValueAsync(_commonXpath.HO_EstimatedPremium, "817", true, 1);
            await page.WaitForTimeoutAsync(3000);
            await Button.ClickButtonAsync(_commonXpath.Continuetomortage, ActionType.Click, true, 1);
            await page.WaitForTimeoutAsync(30000);
        }

        [When("User Click on Continue to Billing on Additional Interest Page")]
        public async Task WhenUserClickOnTheContinueToBillingOnAdditionalInterestPageAsync()
        {
            await page.WaitForTimeoutAsync(3000);
            await Button.ClickButtonAsync(_commonXpath.Continuetomortage, ActionType.Click, true, 1);
            await page.WaitForTimeoutAsync(3000);
        }

        [When(@"User fills mandatory field in Homeowner Billing page and Verify the 6Pay Payment Plans are Displayed")]
        public async Task UserFillsMandatoryFieldsinBillingpageAsync()
        {
            await page.WaitForTimeoutAsync(30000);
            await Button.ClickButtonAsync(_commonXpath.Payment_6Pay, ActionType.Click, true, 1);
            await page.WaitForTimeoutAsync(5000);
            await page.WaitForTimeoutAsync(5000);
            await Label.GetTextAsync(_commonXpath.HO6PayPremium1, true, 1);
            await Label.VerifyValueAsync(_commonXpath.HO6PayPremium1, "136", true, 1);
            await Label.GetTextAsync(_commonXpath.HO6PayPremium2, true, 1);
            await Label.VerifyValueAsync(_commonXpath.HO6PayPremium2, "140", true, 1);
            await Label.GetTextAsync(_commonXpath.HO6PayPremium3, true, 1);
            await Label.VerifyValueAsync(_commonXpath.HO6PayPremium3, "141", true, 1);
            await Label.GetTextAsync(_commonXpath.HO6PayPremium4, true, 1);
            await Label.VerifyValueAsync(_commonXpath.HO6PayPremium4, "140", true, 1);
            await Label.GetTextAsync(_commonXpath.HO6PayPremium5, true, 1);
            await Label.VerifyValueAsync(_commonXpath.HO6PayPremium5, "140", true, 1);
            await Label.GetTextAsync(_commonXpath.HO6PayPremium6, true, 1);
            await Label.VerifyValueAsync(_commonXpath.HO6PayPremium6, "140", true, 1);
            await Label.GetTextAsync(_commonXpath.HO6TotalPremium1, true, 1);
            await Label.VerifyValueAsync(_commonXpath.HO6TotalPremium1, "837", true, 1);
            await page.WaitForTimeoutAsync(3000);
            await Button.ClickButtonAsync(_commonXpath.ContinueBinding, ActionType.Click, true, 1);
            await page.WaitForTimeoutAsync(3000);
        }

        [Then(@"Verify Policy Number is generated for HomeOwner Quote")]
        public async Task ClicksBindPolicyWithPolicyAsync()
        {
            await Button.ClickButtonAsync(_commonXpath.BindPolicywithGoodVilleButton, ActionType.Click, true, 1);
            await page.WaitForTimeoutAsync(10000);
            await Button.ClickButtonAsync(_commonXpath.BindPolicyOkButton, ActionType.Click, true, 1);
            await page.WaitForTimeoutAsync(20000);
            _commonPage.UserWaitForPageToLoadCompletly();
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
            System.Console.WriteLine("Agent Logout Successfully.");
        }
    }
}
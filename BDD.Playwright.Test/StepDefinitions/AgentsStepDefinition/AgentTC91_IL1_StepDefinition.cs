using AventStack.ExtentReports.Gherkin.Model;
using BDD.Playwright.Core.Loggers;
using BDD.Playwright.GBIZ.PageElements;
using BDD.Playwright.GBIZ.Pages.AgentPages;
using BDD.Playwright.GBIZ.Pages.CommonPage;
using BDD.Playwright.GBIZ.Pages.XpathProperties;
using BDD.Playwright.Origami.Pages.AgentPages;
using GoodVille.GBIZ.Reqnroll.Automation.Pages.AgentPages;
using GoodVille.GBIZ.Reqnroll.Automation.Pages.GlobalPages;
using Microsoft.Playwright;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GoodVille.GBIZ.Specflow.Automation.Steps.AgentsStepDefinition
{
    [Binding]
    public class AgentTC91_IL1_StepDefinition : BasePage
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

        public AgentTC91_IL1_StepDefinition(
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

        [When(@"user Clicks on the Quoting Link and Verify Online Quoting text is Displayed.")]
        public async Task UserClickontheQuotinglinkandverifyOnlineQuotingtextisdisplayedAsync()
        {
            await Button.ClickButtonCssAsync(_commonXpath.ShadowHost, _commonXpath.QuotingSidePanelShadow);
            await page.WaitForTimeoutAsync(2000);
            await Label.VerifyTextAsync(_commonXpath.OnlineQuoting_Text, "Online Quoting", true, 1);
        }

        [When(@"user selects the new Quote.")]
        public async Task UserSelectNewQuoteTabAsync()
        {
            await page.WaitForTimeoutAsync(2000);
            await Button.ClickButtonAsync(_commonXpath.NewQuoteLink, ActionType.Click, true, 1);
        }

        [When(@"User select the HomeOwner")]
        public async Task UserSelectHomeownersOptionAsync()
        {
            await page.WaitForTimeoutAsync(2000);
            await Button.ClickButtonAsync(_commonXpath.Quote_Homeowners, ActionType.Click, true, 1);
        }

        [Then(@"verify I have Informed the Insured Checkbox is present.")]
        public async Task VerifyCheckboxIsPresentAsync()
        {
            await Checkbox.VerifyCheckboxExistAsync(_commonXpath.InfoLMICnsuredCheckbox, true, 1, "I have informed the insured");
            await Label.VerifyTextAsync(_commonXpath.InfoLMICnsuredCheckbox, "I have informed the insured", true, 1);
        }

        [Then(@"Verify Continue button exist.")]
        public async Task VerifyContinueButtonIsPresentAsync()
        {
            await Button.VerifyButtonExistAsync(_commonXpath.Quote_Continue_Btn, true, 1, "Continues");
            await Label.VerifyTextAsync(_commonXpath.Quote_Continue_Btn, "Continue", true, 1);
        }

        [When(@"User Select I have informed the insured checkbox and click Continue button.")]
        public async Task UserSelecttheIhaveinformedtheinsuredCheckboxandClickContinueAsync()
        {
            await Button.ClickButtonAsync(_commonXpath.InfoLMICnsuredCheckbox, ActionType.Click, true, 1);
            await Button.ClickButtonAsync(_commonXpath.Quote_Continue_Btn, ActionType.Click, true, 1);
        }

        [Then(@"verify Homeowner text is Present.")]
        public async Task VerifyHomeownersTextIsPresentAsync()
        {
            await Label.VerifyTextAsync(_commonXpath.Homeowners_Text, "Homeowners", true, 1);
            await Label.GetTextAsync(_commonXpath.PersonalAuto_FullText, true, 1);
            var pattern = @"^Homeowners - \d+$";
            await Label.VerifyTextFormatAsync("//div[@id='formHeaderLeft']", pattern, true, 1, "Policy Header");
        }

        [When("User Override the checkbox in Homeowner Claims Page and click Continue button.")]
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

        [Then("Verify Homeowner Applicant information displayed on Summary page.")]
        public async Task ThenVerifyHomeOwnerApplicantInformationDisplayedOnTheSummaryPageAsync()
        {
            await Button.ClickButtonAsync(_commonXpath.Save1_btn, ActionType.Click, true, 1);
            await page.WaitForTimeoutAsync(5000);
            await Button.ClickButtonAsync(_commonXpath.Rate1_btn, ActionType.Click, true, 1);
            await page.WaitForTimeoutAsync(10000);
            await Label.VerifyTextAsync(_commonXpath.HO_ApplicantName1, "Sam Sample", true, 1);
            await Label.VerifyTextAsync(_commonXpath.HO_AllPerilsDeductible1, "$1,000.00", true, 1);
            await Label.VerifyTextAsync(_commonXpath.HO_WindHailDeductible1, "$2,000.00", true, 1);
            await Label.VerifyTextAsync(_commonXpath.HO_MailingAddress1, "106 W Douglas St", true, 1);
            await Label.VerifyTextAsync(_commonXpath.HO_PropertyAddress1, "106 W Douglas St", true, 1);
            await Label.VerifyTextAsync(_commonXpath.HO_YearofConstruction1, "2000", true, 1);
            await Label.VerifyTextAsync(_commonXpath.HO_Protection1, "Protected A", true, 1);
            await Label.VerifyTextAsync(_commonXpath.HO_ConstructionType1, "Frame", true, 1);
            await Label.VerifyTextAsync(_commonXpath.HO_ResidenceType1, "Dwelling", true, 1);
            await Label.VerifyTextAsync(_commonXpath.HO_OccupancyType1, "Primary", true, 1);
            await Label.VerifyTextAsync(_commonXpath.HO_NumberofFamilies1, "1", true, 1);
        }

        [Then("Verify Homeowner Limits of Insurance information displayed on Summary page.")]
        public async Task VerifyHomeOwnerLimitsOfInsuranceInformationDisplayedOnTheSummaryPageAsync()
        {
            await page.WaitForTimeoutAsync(2000);
            _commonPage.UserWaitForPageToLoadCompletly();
            await Label.VerifyTextAsync(_commonXpath.HO_Dwelling_Label, "A. Dwelling", true, 1);
            await Label.VerifyValueAsync(_commonXpath.HO_Dwelling_Amount, "200,000", true, 1);
            await Label.VerifyTextAsync(_commonXpath.HO_RelatedPrivateStructures_Label, "B. Related Private Structures", true, 1);
            await Label.VerifyValueAsync(_commonXpath.HO_RelatedPrivateStructures_Amount, "20,000", true, 1);
            await Label.VerifyTextAsync(_commonXpath.HO_PersonalProperty_Label, "C. Personal Property", true, 1);
            await Label.VerifyValueAsync(_commonXpath.HO_PersonalProperty_Amount, "150,000", true, 1);
            await Label.VerifyTextAsync(_commonXpath.HO_AdditionalLivingCosts_LossOfRents_Label, "D. Additional Living Costs & Loss of Rents", true, 1);
            await Label.VerifyTextAsync(_commonXpath.HO_AdditionalLivingCosts, "Unlimited", true, 1);
            await Label.VerifyTextAsync(_commonXpath.HO_HomeCoverExtraEndorsement_Label, "Home Cover Extra Endorsement", true, 1);
            await Label.VerifyValueAsync(_commonXpath.HO_HomeCoverExtraEndorsement_Amount, "45", true, 1);
            await Label.VerifyTextAsync(_commonXpath.HO_HomeCoverExtraEndorsement_Label, "Home Cover Extra Endorsement", true, 1);
            await Label.VerifyTextAsync(_commonXpath.HO_ProtectiveDevice_Amount1, "-37", true, 1);
        }

        [Then("Verify Homeowner Total premium amount displayed on Summary page.")]
        public async Task ThenVerifyHomeOwnerTotalPremiumAmountDisplayedOnTheSummaryPageAsync()
        {
            await page.WaitForTimeoutAsync(2000);
            await Label.GetTextAsync(_commonXpath.HO_EstimatedPremium, true, 1);
            await Label.VerifyValueAsync(_commonXpath.HO_EstimatedPremium, "1,901", true, 1);
            await page.WaitForTimeoutAsync(3000);
            await Button.ScrollIntoViewAsync(_commonXpath.Continuetomortage, true, 1);
            await Button.ClickButtonAsync(_commonXpath.Continuetomortage, ActionType.Click, true, 1);
            await page.WaitForTimeoutAsync(30000);
        }

        [When(@"user click on Logout Button")]
        public async Task UserClickontheLogoutButtonAsync()
        {
            await Button.ClickButtonCssAsync("gg-navigation", "a[href*='logout']");
            System.Console.WriteLine("Agent Logout Successfully.");
        }
    }
}
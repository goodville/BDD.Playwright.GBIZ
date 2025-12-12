using AventStack.ExtentReports.Gherkin.Model;
using BDD.Playwright.Core.Loggers;
using BDD.Playwright.GBIZ.PageElements;
using BDD.Playwright.GBIZ.Pages.AgentPages;
using BDD.Playwright.GBIZ.Pages.CommonPage;
using BDD.Playwright.GBIZ.Pages.XpathProperties;
using BDD.Playwright.Origami.Pages.AgentPages;
using GoodVille.GBIZ.Reqnroll.Automation.Pages.AgentPages;
using GoodVille.GBIZ.Reqnroll.Automation.Pages.GlobalPages;
using System.Text.RegularExpressions;

namespace GoodVille.GBIZ.Specflow.Automation.Steps.AgentsStepDefinition
{
    [Binding]
    public class AgentTC64_StepDefinition : BasePage
    {
        private readonly ScenarioContext _scenarioContext;
        public FeatureContext _featureContext;
        public CommonXpath _commonXpath;
        public Quote_ApplicantPage _quoteApplicant;
        public Quote_CoveragesPage _quoteCoverage;
        public Quote_DwellingPage _quoteDwelling;
        public Quote_AdditionalInterestPage _quoteAdditionalInterestPage;
        public Quote_BindingPage _quoteBindingPage;
        // Constructor
        public AgentTC64_StepDefinition(ScenarioContext scenarioContext, CommonXpath commonXpath, Quote_ApplicantPage quoteApplicantpage, Quote_CoveragesPage quoteCoveragespage, Quote_DwellingPage quoteDwellingpage, Quote_AdditionalInterestPage quoteAdditionalInterestPage, Quote_BindingPage quoteBindingPage) : base(scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _commonXpath = commonXpath;
            _quoteApplicant = quoteApplicantpage;
            _quoteCoverage = quoteCoveragespage;
            _quoteDwelling = quoteDwellingpage;
            _quoteAdditionalInterestPage = quoteAdditionalInterestPage;
            _quoteBindingPage = quoteBindingPage;
            _commonXpath = commonXpath;
            _quoteApplicant = quoteApplicantpage;
            _quoteCoverage = quoteCoveragespage;
            _quoteDwelling = quoteDwellingpage;
            _quoteAdditionalInterestPage = quoteAdditionalInterestPage;
            _quoteBindingPage = quoteBindingPage;
        }

        [When(@"User Clicks on Quoting link and verify Online Quoting text is displayed")]
        public async Task UserClickontheQuotinglinkandverifyOnlineQuotingtextisdisplayedAsync()
        {
            await Button.ClickButtonCssAsync(_commonXpath.ShadowHost, _commonXpath.QuotingSidePanelShadow);
            await Task.Delay(2000);
            await Label.VerifyTextAsync(_commonXpath.OnlineQuoting_Text, "Online Quoting", true, 1);
        }
        [When(@"User selects the new quote")]
        public async Task UserSelectNewQuoteTabAsync()
        {
            await Task.Delay(2000);
            await Button.ClickButtonAsync(_commonXpath.NewQuoteLink, ActionType.Click, true, 1);
        }
        [When(@"User selects Dwelling Fire Option")]
        public async Task UserSelectDwellingFireOptionAsync()
        {
            await Task.Delay(2000);
            await Button.ClickButtonAsync(_commonXpath.CrossSell_DwellingFire_Btn, ActionType.Click, true, 1);
        }
        [Then(@"verify 'I have informed insured' checkbox is exist")]
        public async Task VerifyCheckboxIsPresentAsync()
        {
            await Checkbox.VerifyCheckboxExistAsync(_commonXpath.InfoLMICnsuredCheckbox, true, 1, "I have informed the insured");
            await Label.VerifyTextAsync(_commonXpath.InfoLMICnsuredCheckbox, "I have informed the insured", true, 1);
        }
        [Then(@"verify 'continue' button is exist")]
        public async Task VerifyContinueButtonIsPresentAsync()
        {
            await Button.VerifyButtonExistAsync(_commonXpath.Quote_Continue_Btn, true, 1, "Continues");
            await Label.VerifyTextAsync(_commonXpath.Quote_Continue_Btn, "Continue", true, 1);
        }
        [When(@"User select 'I have informed insured' checkbox and click continue button")]
        public async Task UserSelecttheIhaveinformedtheinsuredCheckboxandClickContinueAsync()
        {
            await Button.ClickButtonAsync(_commonXpath.InfoLMICnsuredCheckbox, ActionType.Click, true, 1);
            await Button.ClickButtonAsync(_commonXpath.Quote_Continue_Btn, ActionType.Click, true, 1);
        }
        [Then(@"verify Dwelling Fire text is present")]
        public async Task VerifyHomeownersTextIsPresentAsync()
        {
            await Label.VerifyTextAsync(_commonXpath.DwellingFire_Text, "Dwelling Fire", true, 1);
            await Label.GetTextAsync(_commonXpath.PersonalAuto_FullText, true, 1);
            var pattern = @"^Dwelling Fire - \d+$";
            await Label.VerifyTextFormatAsync("//div[@id='formHeaderLeft']", pattern, true, 1, "Policy Header");
        }
        [When(@"User fills the mandatory field in the applicant page and click continue button from json {string}")]
        public async Task WhenUserFillsMandatoryFieldsInApplicantpageAsync(string ProfileKey)
        {
            await _quoteApplicant.ApplicantDataFillAsync(ProfileKey);
        }
        [When(@"User fills the mandatory field in the coverages page and click continue button")]
        public async Task WhenUserFillsMandatoryFieldsInCoveragespageAsync()
        {
            //await _quoteCoverage.CoveragesDatafillAsync();
        }
        [When(@"User fills the mandatory field in the dwelling page and click continue button")]
        public async Task WhenUserFillsMandatoryFieldsInDwellingpageAsync()
        {
           // await _quoteDwelling.DwellingDatafillAsync();
        }
        [When(@"User Click on the Continue to Summary button")]
        public async Task WhenUserClickonContinuetoSummaryAsync()
        {
            await Button.ClickButtonAsync(_commonXpath.ContinueSummary, ActionType.Click, true, 1);
        }
        [Then(@"Verify Applicant information displayed on the Summary page")]
        public async Task VerifyApplicantinformationonSummarypageAsync()
        {
            await Task.Delay(4000);
            await Button.ClickButtonAsync(_commonXpath.Save_btn, ActionType.Click, true, 1);
            await Task.Delay(4000);
            await Button.ClickButtonAsync(_commonXpath.Rate_btn, ActionType.Click, true, 1);
            await Task.Delay(10000);
            await Button.ClickButtonAsync(_commonXpath.MessageOverRides, ActionType.Click, true, 1);
            await Checkbox.SelectCheckboxAsync(_commonXpath.DF_QuoteOverride1, true, true, 1);
            await Checkbox.SelectCheckboxAsync(_commonXpath.DF_QuoteOverride2, true, true, 1);
            await Checkbox.SelectCheckboxAsync(_commonXpath.DF_QuoteOverride3, true, true, 1);
            await Button.ClickButtonAsync(_commonXpath.ApplyOverRides1, ActionType.Click, true, 1);
            // Playwright does not have native alerts; handle accordingly if needed
            await Task.Delay(40000);
            await Label.VerifyTextAsync(_commonXpath.DwellingSummary_Name, "Mohan Qtest", true, 1);
            await Label.VerifyTextAsync(_commonXpath.DwellingSummary_Address1, "41 Commerce St", true, 1);
            await Label.VerifyTextAsync(_commonXpath.DwellingSummary_EffectiveDateText, "Effective Date", true, 1);
        }
        [Then(@"Verify Limits of Insurance information displayed on the Summary page")]
        public async Task VerifyLimitsofInsuranceinformationSummarypageAsync()
        {
            await Task.Delay(4000);
            await Label.VerifyTextAsync(_commonXpath.DwellingSummary_CoverageLPremisesLiability, "$100,000 per occurrence / $200,000 per aggregate", true, 1);
            await Label.VerifyValueAsync(_commonXpath.DwellingSummary_CoverageMMedicalPayments, "2,000", true, 1);
            await Label.VerifyValueAsync(_commonXpath.DwellingSummary_AllPerilsDeductible, "1,000", true, 1);
            await Label.VerifyValueAsync(_commonXpath.DwellingSummary_WindOrHailDeductible, "2,000", true, 1);
            await Task.Delay(4000);
        }
        [Then(@"Verify Total premium amount displayed on the Summary page")]
        public async Task VerifyTotalpremiumAmountdisplayedonSummarypageAsync()
        {
            await Button.ClickButtonAsync(_commonXpath.OrderCredit_btn, ActionType.Click, true, 1);
            await Task.Delay(4000);
            /* Alerts are not the same in Playwright C# - handle accordingly if needed */
            await Task.Delay(4000);
            await Label.GetTextAsync(_commonXpath.TotalPremium, true, 1);
            await Label.VerifyValueAsync(_commonXpath.TotalPremium, "323", true, 1);
        }
        [When(@"User Click on the Continue to Additional Interest button and click the Mortgagee button")]
        public async Task ClickontheContinuetoSummarybuttonAsync()
        {
            await Task.Delay(3000);
            await Button.ClickButtonAsync(_commonXpath.ContinueAddInterest, ActionType.Click, true, 1);
            await Task.Delay(3000);
            await Button.ClickButtonAsync(_commonXpath.AddMortage, ActionType.Click, true, 1);
            await Task.Delay(10000);
        }
        [When(@"User fills the mandatory field in the Additional information Mortgagee page")]
        public async Task UserFillsMandatoryFieldsinAdditionalInformationMortgageepageAsync()
        {
           // await _quoteAdditionalInterestPage.AdditionalInterestDataFillAsync();
            await Task.Delay(2000);
            await Button.ClickButtonAsync(_commonXpath.Save_btn, ActionType.Click, true, 1);
            await Task.Delay(3000);
        }
        [When(@"User fills the mandatory field in the Billing page and Verify the 6Pay payment plans are displayed")]
        public async Task UserFillsMandatoryFieldsinBillingpageAsync()
        {
            await Button.ClickButtonAsync(_commonXpath.ContinueBilling, ActionType.Click, true, 1);
            await Task.Delay(3000);
            await Button.ClickButtonAsync(_commonXpath.Payment_6Pay, ActionType.Click, true, 1);
            await Label.GetTextAsync(_commonXpath.DF6PayPremium_1, true, 1);
            await Label.VerifyValueAsync(_commonXpath.DF6PayPremium_1, "54", true, 1);
            await Label.GetTextAsync(_commonXpath.DF6PayPremium_2, true, 1);
            await Label.VerifyValueAsync(_commonXpath.DF6PayPremium_2, "58", true, 1);
            await Label.GetTextAsync(_commonXpath.DF6PayPremium_3, true, 1);
            await Label.VerifyValueAsync(_commonXpath.DF6PayPremium_3, "58", true, 1);
            await Label.GetTextAsync(_commonXpath.DF6PayPremium_4, true, 1);
            await Label.VerifyValueAsync(_commonXpath.DF6PayPremium_4, "57", true, 1);
            await Label.GetTextAsync(_commonXpath.DF6PayPremium_5, true, 1);
            await Label.VerifyValueAsync(_commonXpath.DF6PayPremium_5, "58", true, 1);
            await Label.GetTextAsync(_commonXpath.DF6PayPremium_6, true, 1);
            await Label.VerifyValueAsync(_commonXpath.DF6PayPremium_6, "58", true, 1);
            await Label.GetTextAsync(_commonXpath.DF6PayTotPremium, true, 1);
            await Label.VerifyValueAsync(_commonXpath.DF6PayTotPremium, "343", true, 1);
            await Task.Delay(3000);
            await Button.ClickButtonAsync(_commonXpath.ContinueBinding, ActionType.Click, true, 1);
            await Task.Delay(3000);
        }
        [When(@"User fills the mandatory field in the Binding page and click Bind Policy button")]
        public async Task UserFillsMandatoryFieldsinBindingPageAsync()
        {
           // await _quoteBindingPage.BindingDataFillAsync();
            await Task.Delay(2000);
            await Button.ClickButtonAsync(_commonXpath.Save_btn, ActionType.Click, true, 1);
            await Task.Delay(5000);
            await Button.ClickButtonAsync(_commonXpath.MessageOverRides, ActionType.Click, true, 1);
            await Checkbox.SelectCheckboxAsync(_commonXpath.DF_OverrideCode_Input1, true, true, 1);
            await Checkbox.SelectCheckboxAsync(_commonXpath.DF_OverrideCode_Input2, true, true, 1);
            await Checkbox.SelectCheckboxAsync(_commonXpath.DF_OverrideCode_Input3, true, true, 1);
            await Checkbox.SelectCheckboxAsync(_commonXpath.DF_OverrideCode_Input4, true, true, 1);
            await Checkbox.SelectCheckboxAsync(_commonXpath.DF_OverrideCode_Input5, true, true, 1);
            await Checkbox.SelectCheckboxAsync(_commonXpath.DF_OverrideCode_Input6, true, true, 1);
            await Checkbox.SelectCheckboxAsync(_commonXpath.DF_OverrideCode_Input7, true, true, 1);
            await Checkbox.SelectCheckboxAsync(_commonXpath.DF_OverrideCode_Input8, true, true, 1);
            await Checkbox.SelectCheckboxAsync(_commonXpath.DF_OverrideCode_Input9, true, true, 1);
            await Button.ClickButtonAsync(_commonXpath.ApplyOverRides, ActionType.Click, true, 1);
            await Task.Delay(1000);
            // Playwright does not have native alerts: handle accordingly
            await Task.Delay(10000);
        }

        [Then(@"Verify Policy Number is generated for the Dwelling Fire")]
        public async Task ClicksBindPolicyWithPolicyAsync()
        {
            await Button.ClickButtonAsync(_commonXpath.BindPolicywithGoodVilleButton, ActionType.Click, true, 1);
            await Task.Delay(1000);
            await Button.ClickButtonAsync(_commonXpath.BindPolicyOkButton, ActionType.Click, true, 1);
            await Task.Delay(20000);
            await Task.Delay(5000);
            await Label.VerifyTextAsync(_commonXpath.DF_PolicyNumber, "Your Policy Number is", true, 1);
            logger.WriteLine("Policy number Generated");
            var fullText = await Label.GetTextAsync(_commonXpath.DF_PolicyNumber, true, 1);
            var policyNumber = Regex.Match(fullText, @"\d+").Value;
            Console.WriteLine($"Extracted Policy Number: {policyNumber}");
            await Task.Delay(5000);
            await Button.ClickButtonAsync(_commonXpath.DF_SatelliteImages, ActionType.Click, true, 1);
            logger.WriteLine("SatelliteImages link clicked and PDF are downloaded");
            await Task.Delay(10000);
            await Button.ClickButtonAsync(_commonXpath.DF_Proposal, ActionType.Click, true, 1);
            logger.WriteLine("Proposal link clicked and PDF are downloaded");
            await Task.Delay(10000);
            await Button.ClickButtonAsync(_commonXpath.DF_RatingLog, ActionType.Click, true, 1);
            logger.WriteLine("Rating Log link clicked and PDF are downloaded");
            await Task.Delay(10000);
            await Button.ClickButtonAsync(_commonXpath.DF_EvidenceProperty, ActionType.Click, true, 1);
            logger.WriteLine("Evidence of Property link clicked and PDF are downloaded");
            await Task.Delay(10000);
            await Button.ClickButtonAsync(_commonXpath.DF_DeductibleShopper, ActionType.Click, true, 1);
            logger.WriteLine("Deductible Shopper link clicked and PDF are downloaded");
            await Task.Delay(10000);
            await Button.ClickButtonAsync(_commonXpath.DF_Application, ActionType.Click, true, 1);
            logger.WriteLine("Application link clicked and PDF are downloaded");
            await Task.Delay(10000);
            await Button.ClickButtonAsync(_commonXpath.DF_ProposalSummary, ActionType.Click, true, 1);
            logger.WriteLine("Proposal Summary link clicked and PDF are downloaded");
            await Task.Delay(10000);
            await Button.ClickButtonAsync(_commonXpath.DF_Binder, ActionType.Click, true, 1);
            logger.WriteLine("Binder link clicked and PDF are downloaded");
            await Task.Delay(10000);
            // Search scenario omitted, see Selenium block for real search
        }
        [When(@"User clicks on the Logout")]
        public async Task UserClickontheLogoutButtonAsync()
        {
            await Button.ClickButtonCssAsync("gg-navigation", "a[href*='logout']");
            Console.WriteLine("Agent Logout Successfully.");
        }
    }
}
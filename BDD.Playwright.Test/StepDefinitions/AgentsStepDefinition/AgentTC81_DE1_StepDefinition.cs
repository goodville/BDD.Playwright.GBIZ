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

namespace GoodVille.GBIZ.Specflow.Automation.Steps.AgentsStepDefinition
{
    [Binding]
    public class AgentTC81_DE1_StepDefinition : BasePage
    {
        private readonly ScenarioContext _scenarioContext;
        public FeatureContext _featureContext;
        public CommonXpath _commonXpath;
        public Quote_ApplicantPage _quoteApplicant;
        public Quote_CoveragesPage _quoteCoverage;
        public Quote_DwellingPage _quoteDwelling;
        public Quote_AdditionalInterestPage _quoteAdditionalInterestPage;
        public Quote_BindingPage _quoteBindingPage;
        public CommonPage _commonPage;

        // Page should expose Playwright IPage here if your helpers need it.
        // If your helper APIs are async, prefer await; otherwise keep as is.

        public AgentTC81_DE1_StepDefinition(
            ScenarioContext scenarioContext,
            CommonXpath commonXpath,
            Quote_ApplicantPage quoteApplicantpage,
            Quote_CoveragesPage quoteCoveragespage,
            Quote_DwellingPage quoteDwellingpage,
            Quote_AdditionalInterestPage quoteAdditionalInterestPage,
            CommonPage commonPage,
            Quote_BindingPage quoteBindingPage) : base(scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _commonXpath = commonXpath;
            _quoteApplicant = quoteApplicantpage;
            _quoteCoverage = quoteCoveragespage;
            _quoteDwelling = quoteDwellingpage;
            _quoteAdditionalInterestPage = quoteAdditionalInterestPage;
            _quoteBindingPage = quoteBindingPage;
            _commonPage = commonPage;
        }

        [When(@"User Click on Quoting link and verify Online Quoting text is displayed")]
        public async Task UserClickontheQuotinglinkandverifyOnlineQuotingtextisdisplayedAsync()
        {
            await Button.ClickButtonCssAsync(_commonXpath.ShadowHost, _commonXpath.QuotingSidePanelShadow);
            await Task.Delay(2000);
            await Label.VerifyTextAsync(_commonXpath.OnlineQuoting_Text, "Online Quoting", true, 1);
        }

        [When(@"User select the new quote")]
        public async Task UserSelectNewQuoteTabAsync()
        {
            await Task.Delay(2000);
            await Button.ClickButtonAsync(_commonXpath.NewQuoteLink, ActionType.Click, true, 1);
        }

        [When(@"User select DwellingFire Option")]
        public async Task UserSelectDwellingFireOptionAsync()
        {
            await Task.Delay(2000);
            await Button.ClickButtonAsync(_commonXpath.CrossSell_DwellingFire_Btn, ActionType.Click, true, 1);
        }

        [Then(@"verify 'I have informed insured' checkbox is present")]
        public async Task VerifyCheckboxIsPresentAsync()
        {
            await Checkbox.VerifyCheckboxExistAsync(_commonXpath.InfoLMICnsuredCheckbox, true, 1, "I have informed the insured");
            await Label.VerifyTextAsync(_commonXpath.InfoLMICnsuredCheckbox, "I have informed the insured", true, 1);
        }

        [Then(@"verify continue button is present")]
        public async Task VerifyContinueButtonIsPresentAsync()
        {
            await Button.VerifyButtonExistAsync(_commonXpath.Quote_Continue_Btn, true, 1, "Continues");
            await Label.VerifyTextAsync(_commonXpath.Quote_Continue_Btn, "Continue", true, 1);
        }

        [When(@"User selects 'I have informed insured' checkbox and click continue button")]
        public async Task UserSelecttheIhaveinformedtheinsuredCheckboxandClickContinueAsync()
        {
            await Button.ClickButtonAsync(_commonXpath.InfoLMICnsuredCheckbox, ActionType.Click, true, 1);
            await Button.ClickButtonAsync(_commonXpath.Quote_Continue_Btn, ActionType.Click, true, 1);
        }

        [Then(@"verify 'Dwelling Fire' text is present")]
        public async Task VerifyHomeownersTextIsPresentAsync()
        {
            await Label.VerifyTextAsync(_commonXpath.DwellingFire_Text, "Dwelling Fire", true, 1);
            await Label.GetTextAsync(_commonXpath.PersonalAuto_FullText, true, 1);
            var pattern = @"^Dwelling Fire - \d+$";
            await Label.VerifyTextFormatAsync("//div[@id='formHeaderLeft']", pattern, true, 1, "Policy Header");
        }

        [When(@"User fills mandatory field in applicant page and click continue button from json {string}")]
        public async Task WhenUserFillsMandatoryFieldsInApplicantpageAsync(string profileKey)
        {
            await _quoteApplicant.ApplicantDataFillAsync(profileKey);
        }

        [When(@"User fills mandatory field in coverages page and click continue button from json {string}")]
        public async Task WhenUserFillsMandatoryFieldsInCoveragespageAsync(string profileKey)
        {
            await _quoteCoverage.CoveragesDataFillAsync(profileKey);
        }

        [When(@"User fills mandatory field in dwelling page and click continue button from json {string}")]
        public async Task WhenUserFillsMandatoryFieldsInDwellingpageAsync(string profileKey)
        {
            await _quoteDwelling.DwellingDatafillAsync(profileKey);
        }

        [When(@"User Click Continue to Summary button")]
        public async Task WhenUserClickonContinuetoSummaryAsync()
        {
            await Button.ClickButtonAsync(_commonXpath.ContinueSummary, ActionType.Click, true, 1);
        }

        [Then(@"Verify Applicant information displayed on the Summarypage")]
        public async Task VerifyApplicantinformationonSummarypageAsync()
        {
            await Task.Delay(4000);
            await Button.ClickButtonAsync(_commonXpath.Save_btn, ActionType.Click, true, 1);
            await Task.Delay(4000);
            await Button.ClickButtonAsync(_commonXpath.Rate_btn, ActionType.Click, true, 1);
            await Task.Delay(10000);

            await Button.ClickButtonAsync(_commonXpath.MessageOverRides, ActionType.Click, true, 1);
            await _commonPage.CheckAllMessageOverrideCheckboxes1Async();
            page.Dialog += async (_, dialog) =>
            {
                try
                {
                    await dialog.AcceptAsync();
                }
                catch (PlaywrightException ex)
                {
                    Console.WriteLine("Dialog already handled: " + ex.Message);

                    logger.WriteLine("Dialog already handled: " + ex.Message);
                }
            };

            await Button.ClickButtonAsync(_commonXpath.ApplyOverRide, ActionType.Click, true, 1);
            await Task.Delay(4000);
            await Label.VerifyTextAsync(_commonXpath.DFSummary1_Name1, "Sam Sample", true, 1);
            await Label.VerifyTextAsync(_commonXpath.DFSummary1_Address1, "9 Mill St", true, 1);
            await Label.VerifyTextAsync(_commonXpath.DFSummary1_Address2, "Greenwood, DE 19950-132", true, 1);
            await Label.VerifyTextAsync(_commonXpath.DFSummary1_EffectiveDateText1, "Effective Date", true, 1);
        }

        [Then(@"Verify Limits of Insurance information displayed on the Summarypage")]
        public async Task VerifyLimitsofInsuranceinformationSummarypageAsync()
        {
            await Task.Delay(4000);
            await Label.VerifyTextAsync(_commonXpath.DFSummary1_CoverageLPremisesLiability1, "$300,000 per occurrence / $600,000 per aggregate", true, 1);
            await Label.VerifyValueAsync(_commonXpath.DFSummary1_CoverageMMedicalPayments1, "2,000", true, 1);
            await Label.VerifyValueAsync(_commonXpath.DFSummary1_AllPerilsDeductible, "500", true, 1);
            await Label.VerifyValueAsync(_commonXpath.DFSummary1_WindOrHailDeductible, "1,000", true, 1);
            await Task.Delay(40000);
        }

        [Then(@"Verify Total premium amount displayed on the Summarypage")]
        public async Task VerifyTotalpremiumAmountdisplayedonSummarypageAsync()
        {
            // Now click the button
            await Button.ClickButtonAsync(_commonXpath.OrderCredit_btn, ActionType.Click, true, 1);

            // (You may want to unsubscribe afterwards if this is a one-off)
            //page.Dialog += async (_, dialog) => await dialog.AcceptAsync();
            await Task.Delay(4000);
               // async dialog => { await dialog.AcceptAsync(); }

            await Label.GetTextAsync(_commonXpath.TotalPremium, true, 1);
            await Label.VerifyValueAsync(_commonXpath.TotalPremium, "620", true, 1);
        }

        [When(@"User Click on Continue to Additional Interest button and click the Mortgageebutton")]
        public async Task ClickontheContinuetoSummarybuttonAsync()
        {
            await Task.Delay(3000);
            await Button.ClickButtonAsync(_commonXpath.ContinueAddInterest, ActionType.Click, true, 1);
            await Task.Delay(3000);
            await Button.ClickButtonAsync(_commonXpath.AddMortage, ActionType.Click, true, 1);
            await Task.Delay(10000);
        }

        [When(@"User fills the mandatory field in the Additional information Mortgageepage from json {string}")]
        public async Task UserFillsMandatoryFieldsinAdditionalInformationMortgageepageAsync(string profileKey)
        {
            await _quoteAdditionalInterestPage.AdditionalInterestDataFillAsync(profileKey);
            await Task.Delay(3000);
            await Button.ClickButtonAsync(_commonXpath.Save_btn, ActionType.Click, true, 1);
            await Task.Delay(3000);
        }

        [When(@"User fills the mandatory field in the Billing page and Verify the 6Paypayment plans are displayed")]
        public async Task UserFillsMandatoryFieldsinBillingpageAsync()
        {
            await Button.ClickButtonAsync(_commonXpath.ContinueBilling, ActionType.Click, true, 1);
            await Task.Delay(3000);
            await Button.ClickButtonAsync(_commonXpath.Payment_6Pay, ActionType.Click, true, 1);
            await Task.Delay(3000);
            await Button.ClickButtonAsync(_commonXpath.ContinueBinding, ActionType.Click, true, 1);
            await Task.Delay(3000);
        }

        [When(@"User fills the mandatory field in the Binding page and click Bind Policybutton from json {string}")]
        public async Task UserFillsMandatoryFieldsinBindingPageAsync(string profileKey)
        {
            await _quoteBindingPage.BindingDataFillAsync(profileKey);
            await Task.Delay(2000);
            await Button.ClickButtonAsync(_commonXpath.Save_btn, ActionType.Click, true, 1);
            await Task.Delay(5000);

            await Button.ClickButtonAsync(_commonXpath.MessageOverRides, ActionType.Click, true, 1);
            await _commonPage.CheckAllMessageOverrideCheckboxes1Async();
            //await Button.ClickButtonAsync(_commonXpath.ApplyOverRides, ActionType.Click, true, 1);
            //page.Dialog += async (_, dialog) => await dialog.AcceptAsync();
            await Task.Delay(4000);
        }

        [Then(@"Verify Policy Number is generated for the DwellingFire")]
        public async Task ClicksBindPolicyWithPolicyAsync()
        {
            await Button.ClickButtonAsync(_commonXpath.BindPolicywithGoodVilleButton, ActionType.Click, true, 1);
            await Task.Delay(1000);
            await Button.ClickButtonAsync(_commonXpath.BindPolicyOkButton, ActionType.Click, true, 1);
            await Task.Delay(10000);

            await Label.VerifyTextAsync(_commonXpath.DF_PolicyNumber, "Your Policy Number is", true, 1);

            var fullText = await Label.GetTextAsync(_commonXpath.DF_PolicyNumber, true, 1);
            await Label.VerifyTextAsync(_commonXpath.DwellingFire_Text, "Dwelling Fire", true, 1);
            await Label.GetTextAsync(_commonXpath.PersonalAuto_FullText, true, 1);

            var pattern = @"^Dwelling Fire - \d+$";
            await Label.VerifyTextFormatAsync("//div[@id='formHeaderLeft']", pattern, true, 1, "Policy Header");

            await Button.ClickButtonAsync(_commonXpath.DF_SatelliteImages, ActionType.Click, true, 1);
            await Task.Delay(10000);

            await Button.ClickButtonAsync(_commonXpath.DF_Proposal, ActionType.Click, true, 1);
            await Task.Delay(10000);

            await Button.ClickButtonAsync(_commonXpath.DF_RatingLog, ActionType.Click, true, 1);
            await Task.Delay(10000);

            await Button.ClickButtonAsync(_commonXpath.DF_EvidenceProperty, ActionType.Click, true, 1);
            await Task.Delay(10000);

            await Button.ClickButtonAsync(_commonXpath.DF_DeductibleShopper, ActionType.Click, true, 1);
            await Task.Delay(10000);

            await Button.ClickButtonAsync(_commonXpath.DF_Application, ActionType.Click, true, 1);
            await Task.Delay(10000);

            await Button.ClickButtonAsync(_commonXpath.DF_ProposalSummary, ActionType.Click, true, 1);
            await Task.Delay(10000);

            await Button.ClickButtonAsync(_commonXpath.DF_Binder, ActionType.Click, true, 1);
            await Task.Delay(10000);

            var policyNumber = Regex.Match(fullText, @"\d+").Value;
            Console.WriteLine($"Extracted Policy Number: {policyNumber}");
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
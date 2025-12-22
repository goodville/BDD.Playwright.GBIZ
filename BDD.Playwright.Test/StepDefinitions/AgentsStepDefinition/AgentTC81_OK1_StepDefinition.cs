using AventStack.ExtentReports.Gherkin.Model;
using BDD.Playwright.Core.Loggers;
using BDD.Playwright.GBIZ.PageElements;
using BDD.Playwright.GBIZ.Pages.AgentPages;
using BDD.Playwright.GBIZ.Pages.CommonPage;
using BDD.Playwright.GBIZ.Pages.XpathProperties;
using BDD.Playwright.Origami.Pages.AgentPages;
using GoodVille.GBIZ.Reqnroll.Automation.Pages.AgentPages;
using Microsoft.Playwright;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GoodVille.GBIZ.Specflow.Automation.Steps.AgentsStepDefinition
{
    [Binding]
    public class AgentTC81_OK1_StepDefinition : BasePage
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

        public AgentTC81_OK1_StepDefinition(
            ScenarioContext scenarioContext,
            CommonXpath commonXpath,
            Quote_ApplicantPage quoteApplicantpage,
            Quote_CoveragesPage quoteCoveragespage,
            Quote_DwellingPage quoteDwellingpage,
            Quote_AdditionalInterestPage quoteAdditionalInterestPage,
            Quote_BindingPage quoteBindingPage,
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
            _commonPage = commonPage;
        }

        [When(@"user click quoting link & verify online quoting text is Displayed")]
        public async Task UserClickontheQuotinglinkandverifyOnlineQuotingtextisdisplayedAsync()
        {
            await Button.ClickButtonCssAsync(_commonXpath.ShadowHost, _commonXpath.QuotingSidePanelShadow);
            await page.WaitForTimeoutAsync(2000);
            await Label.VerifyTextAsync(_commonXpath.OnlineQuoting_Text, "Online Quoting", true, 1);
        }

        [When(@"user Select New Quote")]
        public async Task UserSelectNewQuoteTabAsync()
        {
            await page.WaitForTimeoutAsync(2000);
            await Button.ClickButtonAsync(_commonXpath.NewQuoteLink, ActionType.Click, true, 1);
        }

        [When(@"user selects DwellingFire Option")]
        public async Task UserSelectDwellingFireOptionAsync()
        {
            await page.WaitForTimeoutAsync(2000);
            await Button.ClickButtonAsync(_commonXpath.CrossSell_DwellingFire_Btn, ActionType.Click, true, 1);
        }

        [Then(@"verify 'I have Informed Insured' checkbox is Present")]
        public async Task VerifyCheckboxIsPresentAsync()
        {
            await Checkbox.VerifyCheckboxExistAsync(_commonXpath.InfoLMICnsuredCheckbox, true, 1, "I have informed the insured");
            await Label.VerifyTextAsync(_commonXpath.InfoLMICnsuredCheckbox, "I have informed the insured", true, 1);
        }

        [Then(@"Verify continue Button Present")]
        public async Task VerifyContinueButtonIsPresentAsync()
        {
            await Button.VerifyButtonExistAsync(_commonXpath.Quote_Continue_Btn, true, 1, "Continues");
            await Label.VerifyTextAsync(_commonXpath.Quote_Continue_Btn, "Continue", true, 1);
        }

        [When(@"user select 'I have informed Insured' Checkbox & Click Continue button")]
        public async Task UserSelecttheIhaveinformedtheinsuredCheckboxandClickContinueAsync()
        {
            await Button.ClickButtonAsync(_commonXpath.InfoLMICnsuredCheckbox, ActionType.Click, true, 1);
            await Button.ClickButtonAsync(_commonXpath.Quote_Continue_Btn, ActionType.Click, true, 1);
        }

        [Then(@"Verify 'DwellingFire' Text present")]
        public async Task VerifyHomeownersTextIsPresentAsync()
        {
            await Label.VerifyTextAsync(_commonXpath.DwellingFire_Text, "Dwelling Fire", true, 1);
            await Label.GetTextAsync(_commonXpath.PersonalAuto_FullText, true, 1);
            var pattern = @"^Dwelling Fire - \d+$";
            await Label.VerifyTextFormatAsync("//div[@id='formHeaderLeft']", pattern, true, 1, "Policy Header");
        }
        [When(@"user click continue summary Button")]
        public async Task WhenUserClickonContinuetoSummaryAsync()
        {
            await Button.ClickButtonAsync(_commonXpath.ContinueSummary, ActionType.Click, true, 1);
        }

        [Then(@"Verify 'Applicant Information' Displayed on the summarypage")]
        public async Task VerifyApplicantinformationonSummarypageAsync()
        {
            await page.WaitForTimeoutAsync(4000);
            await Button.ClickButtonAsync(_commonXpath.Save_btn, ActionType.Click, true, 1);
            await page.WaitForTimeoutAsync(4000);
            await Button.ClickButtonAsync(_commonXpath.Rate_btn, ActionType.Click, true, 1);
            await page.WaitForTimeoutAsync(10000);
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
            await Button.ClickButtonAsync(_commonXpath.ApplyOverRides1, ActionType.Click, true, 1);
            await page.WaitForTimeoutAsync(40000);
            await Label.VerifyTextAsync(_commonXpath.DFSummary1_Name1, "Sam Sample", true, 1);
            await Label.VerifyTextAsync(_commonXpath.DFSummary11_Address12, "305 S Oklahoma", true, 1);
            await Label.VerifyTextAsync(_commonXpath.DFSummary11_Address22, "Corn, OK 73024-292", true, 1);
            await Label.VerifyTextAsync(_commonXpath.DFSummary11_EffectiveDateText1, "Effective Date", true, 1);
        }

        [Then(@"Verify 'Limits of insurance' information Displayed on the summarypage")]
        public async Task VerifyLimitsofInsuranceinformationSummarypageAsync()
        {
            await page.WaitForTimeoutAsync(4000);
            await Label.VerifyTextAsync(_commonXpath.DFSummary12_CoverageLPremisesLiability1, "$300,000 per occurrence / $600,000 per aggregate", true, 1);
            await Label.VerifyValueAsync(_commonXpath.DFSummary12_CoverageMMedicalPayments1, "2,000", true, 1);
            await Label.VerifyValueAsync(_commonXpath.DFSummary13_AllPerilsDeductible1, "1,000", true, 1);
            await Label.VerifyValueAsync(_commonXpath.DFSummary13_WindOrHailDeductible1, "2,000", true, 1);
            await page.WaitForTimeoutAsync(4000);
        }

        [Then(@"Verify 'Total Premium amount' Displayed on the summarypage")]
        public async Task VerifyTotalpremiumAmountdisplayedonSummarypageAsync()
        {
            await Button.ClickButtonAsync(_commonXpath.OrderCredit_btn, ActionType.Click, true, 1);
            await page.WaitForTimeoutAsync(4000);
            // Alert handling in Playwright might need event hooks.
            await Label.GetTextAsync(_commonXpath.TotalPremium, true, 1);
            await Label.VerifyValueAsync(_commonXpath.TotalPremium, "1226", true, 1);
        }

        [Then(@"Verify Policy Number is generated For the dwellingFire")]
        public async Task ClicksBindPolicyWithPolicyAsync()
        {
            await Button.ClickButtonAsync(_commonXpath.BindPolicywithGoodVilleButton, ActionType.Click, true, 1);
            await page.WaitForTimeoutAsync(1000);
            await Button.ClickButtonAsync(_commonXpath.BindPolicyOkButton, ActionType.Click, true, 1);
            await page.WaitForTimeoutAsync(20000);
            await page.WaitForTimeoutAsync(5000);
            await Label.VerifyTextAsync(_commonXpath.DF_PolicyNumber, "Your Policy Number is", true, 1);
            System.Console.WriteLine("Policy number Generated");
            await Label.GetTextAsync(_commonXpath.DF_PolicyNumber, true, 1);
            await Label.VerifyTextAsync(_commonXpath.DwellingFire_Text, "Dwelling Fire", true, 1);
            await Label.GetTextAsync(_commonXpath.PersonalAuto_FullText, true, 1);
            var pattern = @"^Dwelling Fire - \d+$";
            await Label.VerifyTextFormatAsync("//div[@id='formHeaderLeft']", pattern, true, 1, "Policy Header");
            await Button.ClickButtonAsync(_commonXpath.DF_SatelliteImages, ActionType.Click, true, 1);
            await page.WaitForTimeoutAsync(10000);
            System.Console.WriteLine("SatelliteImages link clicked and PDF are downloaded");
            await Button.ClickButtonAsync(_commonXpath.DF_Proposal, ActionType.Click, true, 1);
            await page.WaitForTimeoutAsync(10000);
            System.Console.WriteLine("Proposal link clicked and PDF are downloaded");
            await Button.ClickButtonAsync(_commonXpath.DF_RatingLog, ActionType.Click, true, 1);
            await page.WaitForTimeoutAsync(10000);
            System.Console.WriteLine("Rating Log link clicked and PDF are downloaded");
            await Button.ClickButtonAsync(_commonXpath.DF_EvidenceProperty, ActionType.Click, true, 1);
            await page.WaitForTimeoutAsync(10000);
            System.Console.WriteLine("Evidence of Property link clicked and PDF are downloaded");
            await Button.ClickButtonAsync(_commonXpath.DF_DeductibleShopper, ActionType.Click, true, 1);
            await page.WaitForTimeoutAsync(10000);
            System.Console.WriteLine("Deductible Shopper link clicked and PDF are downloaded");
            await Button.ClickButtonAsync(_commonXpath.DF_Application, ActionType.Click, true, 1);
            await page.WaitForTimeoutAsync(10000);
            System.Console.WriteLine("Application link clicked and PDF are downloaded");
            await Button.ClickButtonAsync(_commonXpath.DF_ProposalSummary, ActionType.Click, true, 1);
            await page.WaitForTimeoutAsync(10000);
            System.Console.WriteLine("Proposal Summary link clicked and PDF are downloaded");
            await Button.ClickButtonAsync(_commonXpath.DF_Binder, ActionType.Click, true, 1);
            await page.WaitForTimeoutAsync(10000);
            System.Console.WriteLine("Binder link clicked and PDF are downloaded");
            var fullText = await Label.GetTextAsync(_commonXpath.DF_PolicyNumber, true, 1);
            var policyNumber = Regex.Match(fullText, @"\d+").Value;
            System.Console.WriteLine($"Extracted Policy Number: {policyNumber}");
            await page.WaitForTimeoutAsync(5000);
        }

        [When(@"User clicks on the Logout")]
        public async Task UserClickontheLogoutButtonAsync()
        {
            await Button.ClickButtonCssAsync("gg-navigation", "a[href*='logout']");
            System.Console.WriteLine("Agent Logout Successfully.");
        }
    }
}
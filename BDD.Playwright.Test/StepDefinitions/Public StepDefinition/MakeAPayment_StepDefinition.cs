using BDD.Playwright.GBIZ.PageElements;
using BDD.Playwright.GBIZ.Pages.CommonPage;
using BDD.Playwright.GBIZ.Pages.PublicPages;
using BDD.Playwright.GBIZ.Pages.XpathProperties;
using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDD.Playwright.Test.StepDefinitions.Public_StepDefinition
{
    [Binding]
    public class MakeAPayment_StepDefinition : BasePage
    {
        private readonly ScenarioContext _scenarioContext;
        public CommonXpath _commonXpath;
        private readonly ReportAClaimStartPage _reportAClaimStartPage;
        private readonly MakeAPaymentPage _makeAPaymentPage;
        public MakeAPayment_StepDefinition(ScenarioContext scenarioContext, MakeAPaymentPage makeAPaymentPage, CommonXpath commonXpath, ReportAClaimStartPage reportAClaimStartPage) : base(scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _commonXpath = commonXpath;
            _reportAClaimStartPage = reportAClaimStartPage;
            _makeAPaymentPage = makeAPaymentPage;
        }

        [When(@"User clicks on Make a Payment option from the toolbar")]
        public async Task WhenUserClicksOnMakeAPaymentOptionFromTheToolbarAsync()
        {
            await TextLink.ClickTextLinkAsync(_commonXpath.MakeaPayment_Link, true, 1);
        }

        [Then(@"User verifies Make a Payment page is displayed")]
        public async Task ThenUserVerifiesMakeAPaymentPageIsDisplayedAsync()
        {
            var PageTitle = await page.TitleAsync();

            if (PageTitle == "Goodville Mutual Casualty Company - Make A Payment")
            {
                logger.WriteLine("Page Title is Goodville Mutual Casualty Company - Make A Payment");
            }
            else
            {
                throw new Exception("Page Title is not Matching it is displaying " + PageTitle);
            }
        }

        [When("User enters policy details and submit button on Make a Payment page from {string}")]
        public async Task WhenUserEntersPolicyDetailsAndSubmitButtonOnMakeAPaymentPageFromAsync(string ProfileKey)
        {
            await _reportAClaimStartPage.EnterPolicyDetailsInReportsAClaimStartPageAsync(ProfileKey);
        }

        [When("User clicks on submit with index {int}")]
        public async Task WhenUserClicksOnSubmitWithIndexAsync(int index)
        {
            await Button.ClickButtonAsync(_commonXpath.Submit_Btn, ActionType.Click, true, index);
        }

        [When("User selects payment type and plan then enters payment and banking and insured information then proceeds to review from {string}")]
        public async Task WhenUserSelectsPaymentTypeAndPlanThenEntersPaymentAndBankingAndInsuredInformationThenProceedsToReviewFromAsync(string ProfileKey)
        {
            await _makeAPaymentPage.MakeAPaymentAsync(ProfileKey);
        }

        [When("User pays the amount for the policy")]
        public async Task WhenUserPaysTheAmountForThePolicyAsync()
        {
            await Button.ClickButtonAsync(_makeAPaymentPage.Pay_Button, ActionType.Click, true, 1, "Pay");
        }

        [When("User verifies confirmation message for payment")]
        public async Task WhenUserVerifiesConfirmationMessageForPaymentAsync()
        {
            var frame = page.FrameLocator("#PortalOneFrame");
            var confirmationLocator = frame.Locator(_makeAPaymentPage.PaymentConfirmation_Text);
            await confirmationLocator.WaitForAsync(new() { State = WaitForSelectorState.Visible, Timeout = 30000 });

            // Get the text and verify it contains the expected value
            var actualText = await confirmationLocator.InnerTextAsync();
            if (!actualText.Contains("You're all set!"))
            {
                throw new Exception($"Confirmation did not match expected value. Actual: '{actualText}'");
            }
        }

        [When("User validates the payment paid message")]
        public async Task WhenUserValidatesThePaymentPaidMessageAsync()
        {
            await page.Locator(_makeAPaymentPage.NoBalanceDue_Text).WaitForAsync(new LocatorWaitForOptions
            {
                State = WaitForSelectorState.Visible,
                Timeout = 30000,
            });
            var actualText = await page.Locator(_makeAPaymentPage.NoBalanceDue_Text).InnerTextAsync();
            if (actualText.Trim() == "No balance due.")
            {
                Console.WriteLine("Validation successful: No balance due.");
            }
            else
            {
                throw new Exception($"Validation failed! Expected: 'No balance due.' Actual: '{actualText}'");
            }
        }
    }
}

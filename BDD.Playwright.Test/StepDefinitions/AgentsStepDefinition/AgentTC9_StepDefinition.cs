using System;
using System.Threading.Tasks;
using BDD.Playwright.Core.Helpers;
using BDD.Playwright.GBIZ.Pages.AgentPages;
using BDD.Playwright.GBIZ.Pages.CommonPage;
using BDD.Playwright.GBIZ.Pages.GlobalPages;
using BDD.Playwright.GBIZ.Pages.PublicPages;
using BDD.Playwright.GBIZ.Pages.XpathProperties;
using Microsoft.Playwright;
using Reqnroll;

namespace BDD.Playwright.GBIZ.Steps.AgentsStepDefinition
{
    [Binding]
    public class AgentTC9_StepDefinition : BasePage
    {
        private readonly ScenarioContext _scenarioContext;
        public FeatureContext _featureContext;
        public CommonXpath _commonXpath;
        public LoginPage _loginPage;
        public Accounting_MakeAPayment _accounting_MakeAPayment;
        public MakeAPaymentPage _makeAPaymentPage;
        public AgentTC9_StepDefinition(
            ScenarioContext scenarioContext,
            LoginPage loginPage,
            CommonXpath commonXpath,
            Accounting_MakeAPayment accounting_MakeAPayment,
            MakeAPaymentPage makeAPaymentPage
        ) : base(scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _loginPage = loginPage;
            _commonXpath = commonXpath;
            _accounting_MakeAPayment = accounting_MakeAPayment;
            _makeAPaymentPage = makeAPaymentPage;
        }

        [When("User navigates to makepayment page")]
        public async Task WhenUserNavigatesToMakepaymentPageAsync()
        {
            await Button.ClickButtonAsync(_accounting_MakeAPayment.Accounting_MakeAPayment_Button, PageElements.ActionType.Click, true, 1);
        }

        [When("User enters mandatory fields for make payment from {string}")]
        public async Task WhenUserEntersMandatoryFieldsForMakepaymentAsync(string profileKey)
        {
            await _accounting_MakeAPayment.EnterPolicyDataAsync(profileKey);
        }

        [When("User enters mandatory fields for make payment with DF policy Number")]
        public async Task WhenUserEntersMandatoryFieldsForMakePaymentWithDFPolicyNumberAsync()
        {
            await _accounting_MakeAPayment.EnterPolicyDataWithScenarioContextAsync();
        }

        [When("User has to select payment method as Credit Card")]
        public async Task WhenUserHasToSelectPaymentMethodAsCreditCardAsync()
        {
            /*await page.Locator("//iframe[@aria-label='Payment method']").WaitForAsync(new() { State = WaitForSelectorState.Visible, Timeout = 60000 });
            var frame = page.FrameLocator("//iframe[@aria-label='Payment method']");
            await frame.Locator(_accounting_MakeAPayment.CreditCard_PaymentMethod_RadioButton).WaitForAsync(new() { State = WaitForSelectorState.Visible, Timeout = 60000 });
            await frame.Locator(_accounting_MakeAPayment.CreditCard_PaymentMethod_RadioButton).ClickAsync();*/
            await Button.ClickButtonAsync(_accounting_MakeAPayment.CreditCard_PaymentMethod_RadioButton, PageElements.ActionType.Click, true, 1);
        }

        [When("User clicks on Continue button")]
        public async Task WhenUserClicksOnContinueButtonAsync()
        {
            await Button.ClickButtonAsync(_accounting_MakeAPayment.Continue_AccountingMakeAPayment, PageElements.ActionType.Click, true, 1);
        }

        [When("User has to click on acknowledge Continue button")]
        public async Task WhenUserHasToClickOnAcknowledgeContinueButtonAsync()
        {
            await page.Locator("//iframe[@aria-label='Payment method']").WaitForAsync(new() { State = WaitForSelectorState.Visible, Timeout = 60000 });
            var frame = page.FrameLocator("//iframe[@aria-label='Payment method']");
            await frame.Locator(_accounting_MakeAPayment.AcknowledgeContinue_AccountingMakeAPayment).WaitForAsync(new() { State = WaitForSelectorState.Visible, Timeout = 60000 });
            await frame.Locator(_accounting_MakeAPayment.AcknowledgeContinue_AccountingMakeAPayment).ClickAsync();
        }

        [When("User has to click on Use Another Payment Method")]
        public async Task WhenUserHasToClickOnUseAnotherPaymentMethodAsync()
        {
            await page.Locator("//iframe[@aria-label='Payment method']").WaitForAsync(new() { State = WaitForSelectorState.Visible, Timeout = 60000 });
            var frame = page.FrameLocator("//iframe[@aria-label='Payment method']");
            await frame.Locator(_accounting_MakeAPayment.UseAnotherPaymentMethod).WaitForAsync(new() { State = WaitForSelectorState.Visible, Timeout = 60000 });
            await frame.Locator(_accounting_MakeAPayment.UseAnotherPaymentMethod).ClickAsync();
            //await Button.ClickButtonAsync(_accounting_MakeAPayment.UseAnotherPaymentMethod, PageElements.ActionType.Click, true, 1);
        }

        [When("User enters Credit Card details from {string}")]
        public async Task WhenUserEntersCreditCardDetailsAsync(string profileKey)
        {
            await _makeAPaymentPage.MakeAccountPaymentDetailsAsync(profileKey);
            }

        [When("User clicks on CreditCard Review button")]
        public async Task WhenUserClicksOnCreditCardReviewButtonAsync()
        {
            await Button.ClickButtonAsync(_accounting_MakeAPayment.MakePayment_CreditCard_Review_Button, PageElements.ActionType.Click, true, 1);
        }

        [When("User clicks on Pay button")]
        public async Task WhenUserClicksOnPayButtonAsync()
        {
            var frame = page.FrameLocator("#PortalOneFrame");
            await frame.Locator(_accounting_MakeAPayment.PayButton).ClickAsync();
            //await Button.ClickButtonAsync(_accounting_MakeAPayment.PayButton, PageElements.ActionType.Click, true, 1);
        }
    }
}
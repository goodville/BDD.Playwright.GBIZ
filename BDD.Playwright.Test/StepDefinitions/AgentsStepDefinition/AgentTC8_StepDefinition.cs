using System;
using System.Threading.Tasks;
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
    public class AgentTC8_StepDefinition : BasePage
    {
        private readonly ScenarioContext _scenarioContext;
        public FeatureContext _featureContext;
        public CommonXpath _commonXpath;
        public LoginPage _loginPage;
        public Accounting_MakeAPayment _accounting_MakeAPayment;
        public MakeAPaymentPage _makeAPaymentPage;

        public AgentTC8_StepDefinition(
            ScenarioContext scenarioContext,
            CommonXpath commonXpath,
            LoginPage loginPage,
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

        [When("user navigates to makepayment page")]
        public async Task WhenUserNavigatesToMakepaymentPageAsync()
        {
            await Button.ClickButtonAsync(_accounting_MakeAPayment.Accounting_MakeAPayment_Button, PageElements.ActionType.Click, true, 1);
        }

        [When("user enters policy data for make a payment from {string}")]
        public async Task WhenUserEntersPolicyDataForMakeAPaymentAsync(string profileKey)
        {
            await _accounting_MakeAPayment.EnterPolicyDataAsync(profileKey);
        }

        [When("user has to select payment method As AgencySweep")]
        public async Task WhenUserHasToSelectPaymentMethodAsAgencySweepAsync()
        {
            await RadioButton.SelectRadioButtonAsync(_accounting_MakeAPayment.AgencySweep_PaymentMethod_RadioButton, "Value", true, 1);
        }

        [Then("User selected that the payment method dropdown selected for paymentplan")]
        public async Task ThenUserSelectedThatThePaymentMethodDropdownSelectedForPaymentplanAsync()
        {
            await DropDown.SelectDropDownAsync(_accounting_MakeAPayment.PayPlan_Dropdown, "6 Pay", true, 1);
        }

        [When("user clicks on Continue button")]
        public async Task WhenUserClicksOnContinueButtonAsync()
        {
            await Button.ClickButtonAsync(_commonXpath.Continue_Button, PageElements.ActionType.Click, true, 1);
        }

        [When("user has to click on AddnewPayment Method")]
        public async Task WhenUserHasToClickOnAddnewPaymentMethodAsync()
        {
            await Task.Delay(2000);
            page.Locator("//iframe[@aria-label='Payment method']").WaitForAsync();
            var frame = page.FrameLocator("//iframe[@aria-label='Payment method']");
            //await IFrame.SwitchToIframeByXpathAsync("//iframe[@aria-label='Payment method']");
            await frame.Locator(_accounting_MakeAPayment.AddNewPayment_Button).WaitForAsync(new() { State = WaitForSelectorState.Visible, Timeout = 60000 });
            await frame.Locator(_accounting_MakeAPayment.AddNewPayment_Button).ClickAsync();
        }

        [When("user enters payment details for make a payment from {string}")]
        public async Task WhenUserEntersPaymentDetailsForMakeAPaymentAsync(string profileKey)
        {
            await _accounting_MakeAPayment.EnterPaymentDetailsAsync(profileKey);
        }

        [When("user clicks on savings button")]
        public async Task WhenUserClicksOnSavingsButtonAsync()
        {
            await Task.Delay(2000);
            await page.Locator("#PortalOneFrame").WaitForAsync(new() { State = WaitForSelectorState.Attached, Timeout = 60000 });
            var frame = page.FrameLocator("#PortalOneFrame");

            await frame.Locator(_accounting_MakeAPayment.Savings_Radiobutton).Nth(1).ClickAsync();
        }

        [When("User click on default checkbox")]
        public async Task WhenUserClickOnDefaultCheckboxAsync()
        {
            await page.Locator("#PortalOneFrame").WaitForAsync(new() { State = WaitForSelectorState.Attached, Timeout = 60000 });
            var frame = page.FrameLocator("#PortalOneFrame");
            await frame.Locator(_accounting_MakeAPayment.Default_Checkbox).Nth(1).ClickAsync();
            //await Checkbox.SelectCheckboxAsync(_accounting_MakeAPayment.Default_Checkbox, true, true, 1);
        }

        [When("User clicks on submit for agent accounting payment page")]
        public async Task WhenUserClicksOnSubmitForAgentAccountingPaymentPageAsync()
        {
            await page.Locator("#PortalOneFrame").WaitForAsync(new() { State = WaitForSelectorState.Attached, Timeout = 60000 });
            var frame = page.FrameLocator("#PortalOneFrame");
            await frame.Locator(_accounting_MakeAPayment.MakePaymentSubmit_Button).WaitForAsync(new() { State = WaitForSelectorState.Visible, Timeout = 60000 });
            await frame.Locator(_accounting_MakeAPayment.MakePaymentSubmit_Button).ClickAsync();
        }

        [When("User clicks on Review buttton")]
        public async Task WhenUserClicksOnReviewButttonAsync()
        {
            await page.Locator("//iframe[@aria-label='Payment method']").WaitForAsync(new() { State = WaitForSelectorState.Visible, Timeout = 60000 });
            var frame = page.FrameLocator("//iframe[@aria-label='Payment method']");
            await frame.Locator(_accounting_MakeAPayment.MakePaymentReview_Button).WaitForAsync(new() { State = WaitForSelectorState.Visible, Timeout = 60000 });
            await frame.Locator(_accounting_MakeAPayment.MakePaymentReview_Button).ClickAsync();
        }

        [When("user Click on Pay ten dollar for agent accounting payment page")]
        public async Task WhenUserClickOnPayTenDollarForAgentAccountingPaymentPageAsync()
        {
            await page.Locator("//iframe[@aria-label='Payment method']").WaitForAsync(new() { State = WaitForSelectorState.Visible, Timeout = 60000 });
            var frame = page.FrameLocator("//iframe[@aria-label='Payment method']");
            await frame.Locator(_accounting_MakeAPayment.MakePayment_PaytenDollar).ClickAsync();
        }
    }
}
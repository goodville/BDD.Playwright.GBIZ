using BDD.Playwright.GBIZ.PageElements;
using BDD.Playwright.GBIZ.Pages.AgentPages;
using BDD.Playwright.GBIZ.Pages.CommonPage;
using BDD.Playwright.GBIZ.Pages.PublicPages;
using BDD.Playwright.GBIZ.Pages.XpathProperties;
using GoodVille.GBIZ.Reqnroll.Automation.Pages.GlobalPages;
using Microsoft.Playwright;

namespace GoodVille.GBIZ.Reqnroll.Automation.Steps.AgentsStepDefinition
{
    [Binding]
    public class AgentTC12_StepDefinition : BasePage
    {
        private readonly ScenarioContext _scenarioContext;
        public FeatureContext _featureContext;
        public CommonXpath _commonXpath;
        public LoginPage _loginPage;
        public Accounting_MakeAPayment _accounting_MakeAPayment;
        public MakeAPaymentPage _makeAPaymentPage;

        // Constructor
        public AgentTC12_StepDefinition(
            ScenarioContext scenarioContext,
            LoginPage loginPage,
            CommonXpath commonXpath,
            Accounting_MakeAPayment accounting_MakeAPayment,
            MakeAPaymentPage makeAPaymentPage) : base(scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _loginPage = loginPage;
            _commonXpath = commonXpath;
            _accounting_MakeAPayment = accounting_MakeAPayment;
            _makeAPaymentPage = makeAPaymentPage;
        }

        [When("User navigates to ManageSweepPayments page")]
        public async Task WhenUserNavigatesToManageSweepPaymentsPageAsync()
        {
            await Button.ClickButtonAsync(_accounting_MakeAPayment.Accounting_ManageSweepPayments_Button, ActionType.Click, true, 1);
        }

        [When("User clicks on Manage button")]
        public async Task WhenUserClicksOnManageButtonAsync()
        {
            await Button.ClickButtonAsync(_accounting_MakeAPayment.ManageSweepPayments_ManageButton, ActionType.Click, true, 1);
        }

        [When("User has to click on Add New Payment Method")]
        public async Task WhenUserHasToClickOnAddNewPaymentMethodAsync()
        {
            await page.Locator("//iframe[@aria-label='Payment method']").WaitForAsync(new() { State = WaitForSelectorState.Visible, Timeout = 60000 });
            var frame = page.FrameLocator("//iframe[@aria-label='Payment method']");
            await frame.Locator(_accounting_MakeAPayment.AddNewPayment_Button).WaitForAsync(new() { State = WaitForSelectorState.Visible, Timeout = 60000 });
            await frame.Locator(_accounting_MakeAPayment.AddNewPayment_Button).ClickAsync();
            //await Button.ClickButtonAsync(_accounting_MakeAPayment.AddNewPayment_Button, ActionType.Click, true, 1);
        }

        [Then("User has to select that the payment method is Bank Account type")]
        public async Task ThenUserHasToSelectThatThePaymentMethodIsBankAccountTypeAsync()
        {
            await Task.Delay(5000);
            await page.Locator("//iframe[@aria-label='Payment method']").WaitForAsync(new() { State = WaitForSelectorState.Visible, Timeout = 60000 });
            var frame = page.FrameLocator("//iframe[@aria-label='Payment method']");
            await frame.Locator(_accounting_MakeAPayment.ManageSweepPayments_BankAccountButton).WaitForAsync(new() { State = WaitForSelectorState.Visible, Timeout = 60000 });
            await frame.Locator(_accounting_MakeAPayment.ManageSweepPayments_BankAccountButton).ClickAsync();
            //await Button.ClickButtonAsync(_accounting_MakeAPayment.ManageSweepPayments_BankAccountButton, ActionType.Click, true, 1);
        }

        [When("User has to select the latest paymethod and clicks on Remove Button.")]
        public async Task WhenUserHasToSelectTheLatestPaymethodAndClicksOnRemoveButton_Async()
        {
            await page.Locator("//iframe[@aria-label='Payment method']").WaitForAsync(new() { State = WaitForSelectorState.Visible, Timeout = 60000 });
            var frame = page.FrameLocator("//iframe[@aria-label='Payment method']");
            await frame.Locator("//button[@class='btn btn-secondary']").WaitForAsync(new() { State = WaitForSelectorState.Visible, Timeout = 60000 });
            await frame.Locator("//button[@class='btn btn-secondary']").ClickAsync();
            await Task.Delay(5000);
            await frame.Locator("//button[contains(text(),'REMOVE')]").ClickAsync();
            //await Button.ClickButtonAsync(_accounting_MakeAPayment.ManageSweepPayments_BankAccountButton, ActionType.Click, true, 1);
            //await Button.ClickButtonAsync(_accounting_MakeAPayment.ManageSweepPayments_RemoveButton, ActionType.Click, true, 1);
            //await frame.Locator(_accounting_MakeAPayment.ManageSweepPayments_ConfirmRemoveButton).ClickAsync();
        }

        [Then("User has to click on Close button and Navigates to Manage page")]
        public async Task ThenUserHasToClickOnCloseButtonAndNavigatesToManagePageAsync()
        {
            await Task.Delay(5000);
            await page.Locator("//iframe[@aria-label='Payment method']").WaitForAsync(new() { State = WaitForSelectorState.Visible, Timeout = 60000 });
            var frame = page.FrameLocator("//iframe[@aria-label='Payment method']");
            await frame.Locator(_accounting_MakeAPayment.Close_Button).WaitForAsync(new() { State = WaitForSelectorState.Visible, Timeout = 60000 });
            await frame.Locator(_accounting_MakeAPayment.Close_Button).ClickAsync();
           // await Button.ClickButtonAsync(_accounting_MakeAPayment.Close_Button, ActionType.Click, true, 1);
        }

        [Then("User has to verify that the paymethod is removed Successfully")]
        public async Task ThenUserHasToVerifyThatThePaymethodIsRemovedSuccessfullyAsync()
        {
            await Button.ScrollIntoViewAsync(_accounting_MakeAPayment.Verify_PaymentMethod_Removal, true, 1);
            var isRemoved = !await Label.VerifyLabelExistAsync(_accounting_MakeAPayment.Verify_PaymentMethod_Removal);
            if (isRemoved)
            {
                Console.WriteLine("Payment Method ending with 0019 has been removed");
            }
        }
    }
}
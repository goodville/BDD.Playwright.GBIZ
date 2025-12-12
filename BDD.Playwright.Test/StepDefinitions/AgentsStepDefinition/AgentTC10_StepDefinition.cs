using BDD.Playwright.GBIZ.PageElements;
using BDD.Playwright.GBIZ.Pages.AgentPages;
using BDD.Playwright.GBIZ.Pages.CommonPage;
using BDD.Playwright.GBIZ.Pages.PublicPages;
using BDD.Playwright.GBIZ.Pages.XpathProperties;
using GoodVille.GBIZ.Reqnroll.Automation.PageElements;
using GoodVille.GBIZ.Reqnroll.Automation.Pages.GlobalPages;
using Microsoft.Playwright;

namespace GoodVille.GBIZ.Reqnroll.Automation.Steps.AgentsStepDefinition
{
    [Binding]
    public class AgentTC10_StepDefinition : BasePage
    {
        private readonly ScenarioContext _scenarioContext;
        public FeatureContext _featureContext;
        public CommonXpath _commonXpath;
        public LoginPage _loginPage;
        public Accounting_MakeAPayment _accounting_MakeAPayment;
        public MakeAPaymentPage _makeAPaymentPage;

        public AgentTC10_StepDefinition(
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

        [When("User has to select payment method as EFT One Time")]
        public async Task WhenUserHasToSelectPaymentMethodAsEFTOneTimeAsync()
        {
            await Button.ClickButtonAsync(_accounting_MakeAPayment.EFT_PaymentMethod_RadioButton, ActionType.Click, true, 1);
        }

        [When("User clicks on Review button")]
        public async Task WhenUserClicksOnReviewButtonAsync()
        {
            await page.Locator("//iframe[@aria-label='Payment method']").WaitForAsync(new() { State = WaitForSelectorState.Visible, Timeout = 60000 });
            var frame = page.FrameLocator("//iframe[@aria-label='Payment method']");
            await frame.Locator(_accounting_MakeAPayment.MakePaymentReview_Button).WaitForAsync(new() { State = WaitForSelectorState.Visible, Timeout = 60000 });
            await frame.Locator(_accounting_MakeAPayment.MakePaymentReview_Button).ClickAsync();
            // await Button.ClickButtonAsync(_accounting_MakeAPayment.MakePaymentReview_Button, ActionType.Click, true, 1);
        }

        [When("User clicks on EFT Review button")]
        public async Task WhenUserClicksOnEFTReviewButtonAsync()
        {
            var frame = page.FrameLocator("#PortalOneFrame");
            await frame.Locator(_accounting_MakeAPayment.MakePaymentEFTReview_Button).ClickAsync();
            //await Button.ClickButtonAsync(_accounting_MakeAPayment.MakePaymentEFTReview_Button, ActionType.Click, true, 1);
        }

        [When("User enters Account and Routing details from {string}")]
        public async Task WhenUserEntersAccountAndRoutingDetailsAsync(string profileKey)
        {
            await _makeAPaymentPage.MakeAccountPaymentDetailsAsync(profileKey);
        }

        [When("User clicks on EFTsavings button")]
        public async Task WhenUserClicksOnEFTsavingsButtonAsync()
        {
            var frame = page.FrameLocator("#PortalOneFrame");
            await frame.Locator(_accounting_MakeAPayment.EFTSavings_Radiobutton).ClickAsync();
        }

        [When("User has to enter the Email address and Click on Send Button from {string}")]
        public async Task WhenUserHasToEnterTheEmailAddressAndClickOnSendButtonAsync(string profileKey)
        {
            await _accounting_MakeAPayment.EnterEmailIdAndSendAsync(profileKey);
        }

        [When("User has to Click on DownloadReceipt Button")]
        public async Task WhenUserHasToClickOnPrintReceiptButtonAsync()
        {
            var frame = page.FrameLocator("#PortalOneFrame");
            await frame.Locator(_accounting_MakeAPayment.DownloadReceipt_Button).ClickAsync();
            //await Button.ClickButtonAsync(_accounting_MakeAPayment.DownloadReceipt_Button, ActionType.Click, true, 1);
        }

        /* [When("User has to click on Close Button")]
        public async Task WhenUserHasToClickOnCloseButtonAsync()
        {
            await Button.ClickButtonAsync(_accounting_MakeAPayment.Close_Button, PageElements.ActionType.Click, true, 1);
        } */
    }
}
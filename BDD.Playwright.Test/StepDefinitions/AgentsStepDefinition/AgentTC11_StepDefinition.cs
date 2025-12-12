using BDD.Playwright.GBIZ.Pages.AgentPages;
using BDD.Playwright.GBIZ.Pages.CommonPage;
using BDD.Playwright.GBIZ.Pages.XpathProperties;
using GoodVille.GBIZ.Reqnroll.Automation.Pages.GlobalPages;
using Microsoft.Playwright;

namespace GoodVille.GBIZ.Reqnroll.Automation.Steps.AgentsStepDefinition
{
    [Binding]
    public class AgentTC11_StepDefinition : BasePage
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly string _scenarioTitle;
        public FeatureContext _featureContext;
        public CommonXpath _commonXpath;
        public LoginPage _loginPage;
        private readonly PolicyDetails_RecurringEFTPage _policyDetailsRecurringEFTPage;

        // Constructor
        public AgentTC11_StepDefinition(
            ScenarioContext scenarioContext,
            LoginPage loginPage,
            CommonXpath commonXpath,
            PolicyDetails_RecurringEFTPage policyDetailsRecurringEFTPage) : base(scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _scenarioTitle = scenarioContext.ScenarioInfo.Title;
            _loginPage = loginPage;
            _commonXpath = commonXpath;
            _policyDetailsRecurringEFTPage = policyDetailsRecurringEFTPage;
        }

        [When("User navigates to recurringEFT page and adds a policy wallet with account details")]
        public async Task WhenUserNavigatesToRecurringEFTPageAndAddsAPolicyWalletWithAccountDetailsAsync()
        {
            await _policyDetailsRecurringEFTPage.AddPaymentForRecurringEFTAsync();
        }

        [Then("User verifies that policy wallet is added {string}")]
        public async Task ThenUserVerifiesThatPolicyWalletIsAddedAsync(string walletNumber)
        {
            var walletAddedText = $"//*[contains(text(),'{walletNumber}')]";
            await page.Locator(walletAddedText)
                .WaitForAsync(new() { State = WaitForSelectorState.Visible, Timeout = 60000 });
        }

        [Then("User removes the policy wallet")]
        public async Task ThenUserRemovesThePolicyWalletAsync()
        {
            await _policyDetailsRecurringEFTPage.RemovePolicyWalletPaymentMethodAsync();
        }

        [Then("User verifies that policy wallet is removed")]
        public async Task ThenUserVerifiesThatPolicyWalletIsRemovedAsync()
        {
            await page.Locator(_commonXpath.Create_Button)
                .WaitForAsync(new() { State = WaitForSelectorState.Visible, Timeout = 60000 });
            var isEnabled = await page.Locator(_commonXpath.Create_Button).IsEnabledAsync();
            if (!isEnabled)
            {
                throw new Exception("Create button is not enabled after wallet removal.");
            }
        }
    }
}
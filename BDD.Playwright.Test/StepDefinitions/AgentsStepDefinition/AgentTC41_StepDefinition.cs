using BDD.Playwright.Core.Interfaces;
using BDD.Playwright.Core.Loggers;
using BDD.Playwright.GBIZ.PageElements;
using BDD.Playwright.GBIZ.Pages.CommonPage;
using BDD.Playwright.GBIZ.Pages.XpathProperties;
using BDD.Playwright.Origami.Pages.CommonPage;
using GoodVille.GBIZ.Reqnroll.Automation.Pages.GlobalPages;
using Microsoft.Playwright;

namespace GoodVille.GBIZ.Specflow.Automation.Steps.AgentsStepDefinition
{
    [Binding]
    internal class AgentTC41_StepDefinition : BasePage
    {
        private readonly ScenarioContext _scenarioContext;
        public FeatureContext _featureContext;
        public CommonXpath _commonXpath;
        public LoginPage _loginPage;
        public SecureEmailRegistrationPage _secureEmailRegistrationPage;

        // Constructor
        public AgentTC41_StepDefinition(
            ScenarioContext scenarioContext,
            LoginPage loginPage,
            CommonXpath commonXpath,
            SecureEmailRegistrationPage secureEmailRegistrationPage) : base(scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _loginPage = loginPage;
            _commonXpath = commonXpath;
            _secureEmailRegistrationPage = secureEmailRegistrationPage;
        }

        [When("User Click on the Contact us and Clicks on secure email link")]
        public async Task WhenUserClickOnTheContactUsAndClicksOnSecureEmailLinkAsync()
        {
            await TextLink.ClickTextLinkAsync(_commonXpath.ContactUs_Link, true, 1);
            //await TextLink.ClickTextLinkAsync(_commonXpath.SecureEmail_Link, true, 1);
            var popupTask = page.WaitForPopupAsync();
            await TextLink.ClickTextLinkAsync(_commonXpath.SecureEmail_Link, true, 1);
            var newTab = await popupTask; // This is the new tab/page object

            await newTab.WaitForLoadStateAsync(LoadState.NetworkIdle);
            await Task.Delay(2000);
            // await page.WaitForLoadStateAsync(LoadState.NetworkIdle);
            await Task.Delay(2000);
        }

        [When("User Register his mail for secure emails with json profile {string}")]
        public async Task WhenUserRegisterHisMailForSecureEmailsWithJsonProfileAsync(string ProfileKey)
        {
            //await IFrame.SwitchToWindowAsync();
            await _secureEmailRegistrationPage.RegistrationMethodAsync(ProfileKey);
            //await IFrame.CurrentWindowCloseAsync();
        }
    }
}
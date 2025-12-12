using BDD.Playwright.GBIZ.PageElements;
using BDD.Playwright.GBIZ.Pages.AgentPages;
using BDD.Playwright.GBIZ.Pages.CommonPage;
using BDD.Playwright.GBIZ.Pages.PublicPages;
using BDD.Playwright.GBIZ.Pages.XpathProperties;
using Microsoft.Playwright;

namespace BDD.Playwright.Test.StepDefinitions.Public_StepDefinition
{
    [Binding]
    public class TC12_StepDefinition : BasePage
    {
        private readonly ScenarioContext _scenarioContext;
        public CommonXpath _commonXpath;
        private readonly ReportAClaimStartPage _reportAClaimStartPage;
        private readonly ReportAClaimFormPage _reportAClaimFormPage;
        public TC12_StepDefinition(ScenarioContext scenarioContext, CommonXpath commonXpath, ReportAClaimStartPage reportAClaimStartPage, ReportAClaimFormPage reportAClaimFormPage) : base(scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _commonXpath = commonXpath;
            _reportAClaimStartPage = reportAClaimStartPage;
            _reportAClaimFormPage = reportAClaimFormPage;
        }

        [When(@"User clicks on report a claim in current policy holders section on home page")]
        public async Task WhenUserClicksOnReportAClaimInCurrentPolicyHoldersSectionOnHomePageAsync()
        {
            await TextLink.ClickTextLinkAsync(_commonXpath.PolicyHolderReportaClaim_Link, true, 1);
        }

        [When("User enters policy details in policy lookup section from {string}")]
        public async Task WhenUserEntersPolicyDetailsInPolicyLookupSectionFromAsync(string profileKey)
        {
            await _reportAClaimStartPage.EnterPolicyDetailsInReportAClaimStartPageAsync(profileKey);
        }

        [When(@"User clicks on submit")]
        public async Task WhenUserClicksOnSubmitAsync()
        {
            await page.Locator("//iframe[@aria-label='Payment method']").WaitForAsync(new() { State = WaitForSelectorState.Visible, Timeout = 60000 });
            var frame = page.FrameLocator("//iframe[@aria-label='Payment method']");
            await frame.Locator(_commonXpath.Submit_Btn).WaitForAsync(new() { State = WaitForSelectorState.Visible, Timeout = 60000 });
            await frame.Locator(_commonXpath.Submit_Btn).ClickAsync();
            //await Button.ClickButtonAsync(_commonXpath.Submit_Btn, ActionType.Click, true, 1);
        }

        [When(@"User clicks on submit Button")]
        public async Task WhenUserClicksOnSubmitButtonAsync()
        {
            //await page.Locator("//iframe[@aria-label='Payment method']").WaitForAsync(new() { State = WaitForSelectorState.Visible, Timeout = 60000 });
            var frame = page.FrameLocator("#PortalOneFrame");
            await frame.Locator(_commonXpath.Submit_Btn).WaitForAsync(new() { State = WaitForSelectorState.Visible, Timeout = 60000 });
            await frame.Locator(_commonXpath.Submit_Btn).ClickAsync();
            //await Button.ClickButtonAsync(_commonXpath.Submit_Btn, ActionType.Click, true, 1);
        }

        [When(@"User click on submit Button")]
        public async Task WhenUserClickOnSubmitButtonAsync()
        {
            //await page.Locator("//iframe[@aria-label='Payment method']").WaitForAsync(new() { State = WaitForSelectorState.Visible, Timeout = 60000 });
            await Button.ClickButtonAsync(_commonXpath.Submit_Btn, ActionType.Click, true, 1);
        }

        [When("User verifies report a claim form page and policy information section is loaded from {string}")]
        public async Task WhenUserVerifiesReportAClaimFormPageAndPolicyInformationSectionIsLoadedFromAsync(string profileKey)
        {
            await _reportAClaimFormPage.VerifyReportAClaimFormPageAsync(profileKey);
        }
    }
}

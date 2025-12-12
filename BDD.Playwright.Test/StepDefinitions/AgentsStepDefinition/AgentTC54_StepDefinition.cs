using AventStack.ExtentReports.Gherkin.Model;
using BDD.Playwright.Core.Loggers;
using BDD.Playwright.GBIZ.PageElements;
using BDD.Playwright.GBIZ.Pages.CommonPage;
using BDD.Playwright.GBIZ.Pages.XpathProperties;
using BDD.Playwright.Origami.Pages.AgentPages;
using GoodVille.GBIZ.Reqnroll.Automation.Pages.GlobalPages;
using Microsoft.Playwright;

namespace GoodVille.GBIZ.Specflow.Automation.Steps.AgentsStepDefinition
{
    [Binding]
    public class AgentTC54_StepDefinition : BasePage
    {
        private readonly ScenarioContext _scenarioContext;
        public FeatureContext _featureContext;
        public CommonXpath _commonXpath;
        public LoginPage _loginPage;
        public ProfilePage _profilePage;

        public AgentTC54_StepDefinition(
            ScenarioContext scenarioContext,
            LoginPage loginPage,
            CommonXpath commonXpath,
            ProfilePage profilePage
        ) : base(scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _loginPage = loginPage;
            _commonXpath = commonXpath;
            _profilePage = profilePage;
        }

        [When(@"User Click on Quoting link and verifies Online Quoting text is displayed")]
        public async Task UserClickontheQuotinglinkandverifyOnlineQuotingtextisdisplayedAsync()
        {
            await Button.ClickButtonCssAsync(_commonXpath.ShadowHost, _commonXpath.QuotingSidePanelShadow);
            await page.WaitForTimeoutAsync(2000);
            await Label.VerifyTextAsync(_commonXpath.OnlineQuoting_Text, "Online Quoting", true, 1);
        }

        [When(@"User selects new quote tab")]
        public async Task UserSelectNewQuoteTabAsync()
        {
            await page.WaitForTimeoutAsync(2000);
            await Button.ClickButtonAsync(_commonXpath.NewQuoteLink, ActionType.Click, true, 1);
        }

        [When(@"User select the Tradesman Cover Option")]
        public async Task UserSelectTradesmanCoverOptionAsync()
        {
            await page.WaitForTimeoutAsync(2000);
            await Button.ClickButtonAsync(_commonXpath.TradesmanCoverButton, ActionType.Click, true, 1);
        }

        [Then(@"verify the Tradesman Cover text is present")]
        public async Task VerifyTradesmanCoverTextIsPresentAsync()
        {
            await page.WaitForTimeoutAsync(2000);
            await Label.VerifyTextAsync(_commonXpath.PersonalAuto_FullText, "Tradesman Cover", true, 1);
            await Label.GetTextAsync(_commonXpath.PersonalAuto_FullText, true, 1);

            var pattern = @"^Tradesman Cover - \d+$";
            var isVerified = await Label.VerifyTextFormatAsync("//div[@id='formHeaderLeft']", pattern, true, 1, "Policy Header");
            Assert.IsTrue(isVerified, "Quote Header Format does not match expected.");
        }

        [When(@"User Clicks on Logout Button")]
        public async Task UserClickontheLogoutButtonAsync()
        {
            await Button.ClickButtonCssAsync("gg-navigation", "a[href*='logout']");
            Console.WriteLine("Agent Logout Successfully.");
        }
    }
}
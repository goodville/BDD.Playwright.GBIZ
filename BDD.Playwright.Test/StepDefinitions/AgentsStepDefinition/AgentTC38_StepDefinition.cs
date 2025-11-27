using AventStack.ExtentReports.Gherkin.Model;
using BDD.Playwright.GBIZ.PageElements;
using BDD.Playwright.GBIZ.Pages.AgentsPages;
using BDD.Playwright.GBIZ.Pages.CommonPage;
using BDD.Playwright.GBIZ.Pages.XpathProperties;
using Microsoft.Playwright;

namespace GoodVille.GBIZ.Reqnroll.Automation.Steps.AgentsStepDefinition
{
    [Binding]
    public class AgentTC38_StepDefinition : BasePage
    {
        private readonly ScenarioContext _scenarioContext;
        public FeatureContext _featureContext;
        public CommonXpath _commonXpath;
        public MyBusinessHomePage _myBusinessHomePage;

        public AgentTC38_StepDefinition(
            ScenarioContext scenarioContext,
            MyBusinessHomePage myBusinessHomePage,
            CommonXpath commonXpath) : base(scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _myBusinessHomePage = myBusinessHomePage;
            _commonXpath = commonXpath;
        }

        public string FAQHelp_Link { get; set; } = "a[href='/agents/marketing/faq/']";

        public async Task SamePageHeadingVerifyMethodAsync(string requiredXpath, string requiredHeading, string returnToPage)
        {
            await TextLink.ClickTextLinkAsync(requiredXpath, true, 1);
            var exists = await Label.VerifyLabelExistAsync(requiredHeading, true, 1);
            if (exists)
            {
               logger.WriteLine("Heading exists " + requiredHeading);
            }
            else
            {
                throw new Exception("Page Heading is not Matching.");
            }

            if (returnToPage == "Back")
            {
                await page.GoBackAsync();
               logger.WriteLine("Back clicked");
            }
            else
            {
                await TextLink.ClickTextLinkAsync(returnToPage, true, 1);
            }
        }

        [When("User Clicks on FAQ and Help")]
        public async Task WhenUserClickOnFAQHelpAsync()
        {
            await Button.ClickButtonCssAsync(_commonXpath.ShadowHostSlidePanelShadow, FAQHelp_Link);
        }
    }
}
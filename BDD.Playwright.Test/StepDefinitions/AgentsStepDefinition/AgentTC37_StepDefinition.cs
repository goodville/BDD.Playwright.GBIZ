using BDD.Playwright.GBIZ.PageElements;
using BDD.Playwright.GBIZ.Pages.AgentsPages;
using BDD.Playwright.GBIZ.Pages.CommonPage;
using BDD.Playwright.GBIZ.Pages.XpathProperties;
using Microsoft.Playwright;

namespace GoodVille.GBIZ.Reqnroll.Automation.Steps.AgentsStepDefinition
{
    [Binding]
    public class AgentTC37_StepDefinition : BasePage
    {
        private readonly ScenarioContext _scenarioContext;
        public FeatureContext _featureContext;
        public CommonXpath _commonXpath;
        public MyBusinessHomePage _myBusinessHomePage;

        public AgentTC37_StepDefinition(
            ScenarioContext scenarioContext,
            MyBusinessHomePage myBusinessHomePage,
            CommonXpath commonXpath) : base(scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _myBusinessHomePage = myBusinessHomePage;
            _commonXpath = commonXpath;
        }

        #region Xpath
        public string EmployeeDirectory_Link { get; set; } = "div.gg-leftnavlinkgrid > a:nth-child(4)";
        public string Submit_btn { get; set; } = "//input[@type='submit']";
        #endregion

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

        [When("User click on Employee Directory Page")]
        public async Task WhenUserClickOnEmployeeDirectoryPageAsync()
        {
            await Button.ClickButtonCssAsync(_commonXpath.ShadowHostSlidePanelShadow, EmployeeDirectory_Link);
        }

        [When("User clicks on all the employee directory tabs and verify the pages")]
        public async Task WhenUserClicksOnAllTheEmployeeDirectoryTabsAndVerifyThePagesAsync()
        {
            // Find the shadow host component
            var shadowHost = page.Locator("gg-elements-employee-directory");

            // Use Playwright's shadow selector to query inside shadow DOM
            var tabs = shadowHost.Locator(".gg-tab-nav-bar .gg-tab-link");
            var tabCount = await tabs.CountAsync();

            for (var i = 0; i < tabCount; i++)
            {
                var tab = tabs.Nth(i);
                var tabText = await tab.InnerTextAsync();
                Console.WriteLine($"Clicking tab: {tabText}");

                await tab.ClickAsync();
                await page.WaitForTimeoutAsync(2000);

                // Find paragraphs under the same shadow root
                var paragraphs = shadowHost.Locator(".department-subgroup p");
                var pCount = await paragraphs.CountAsync();

                var contentVisible = false;

                for (var j = 0; j < pCount; j++)
                {
                    var para = paragraphs.Nth(j);
                    var displayed = await para.IsVisibleAsync();
                    var txt = await para.InnerTextAsync();
                    if (displayed && !string.IsNullOrWhiteSpace(txt))
                    {
                        contentVisible = true;
                        Console.WriteLine($"    Content: {txt}");
                    }
                }

                Assert.IsTrue(contentVisible, $"No visible content found after clicking tab '{tabText}'");
            }
        }
    }
}
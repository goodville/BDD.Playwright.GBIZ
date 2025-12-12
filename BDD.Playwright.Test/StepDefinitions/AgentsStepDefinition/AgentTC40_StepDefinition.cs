using AventStack.ExtentReports.Gherkin.Model;
using BDD.Playwright.GBIZ.PageElements;
using BDD.Playwright.GBIZ.Pages.AgentsPages;
using BDD.Playwright.GBIZ.Pages.CommonPage;
using BDD.Playwright.GBIZ.Pages.XpathProperties;
using Microsoft.Playwright;

namespace GoodVille.GBIZ.Reqnroll.Automation.Steps.AgentsStepDefinition
{
    [Binding]
    public class AgentTC40_StepDefinition : BasePage
    {
        private readonly ScenarioContext _scenarioContext;
        public FeatureContext _featureContext;
        public CommonXpath _commonXpath;
        public MyBusinessHomePage _myBusinessHomePage;

        public AgentTC40_StepDefinition(
            ScenarioContext scenarioContext,
            MyBusinessHomePage myBusinessHomePage,
            CommonXpath commonXpath) : base(scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _myBusinessHomePage = myBusinessHomePage;
            _commonXpath = commonXpath;
        }

        #region Xpath
        public string Updates_Link { get; set; } = "a[href='/agents/marketing/updates/']";
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

        [When("User click on Updates Page")]
        public async Task WhenUserClickOnUpdatesPageAsync()
        {
            await Button.ClickButtonCssAsync(_commonXpath.ShadowHostSlidePanelShadow, Updates_Link);
        }

        [When("User enters the Top Ten in the update textbox")]
        public async Task WhenUserEnterstheTopTenintheUpdateTextboxAsync()
        {
            // 1. Wait for and enter 'Top Ten' in the textbox
            var updateTextbox = page.Locator("//input[@name='keywords']");
            await updateTextbox.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Visible, Timeout = 10000 });
            await updateTextbox.FillAsync("Top Ten");

            // 2. Wait for Submit button and click it
            var submitButton = page.Locator("//input[@type='submit']");
            await submitButton.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Visible, Timeout = 10000 });
            await submitButton.ClickAsync();

            // 3. Wait for the container to be available after result loads
            var containerSelector = "body > gg-page:nth-child(1) > div:nth-child(4) > div:nth-child(2) > div:nth-child(1) > div:nth-child(1) > div:nth-child(1) > div:nth-child(1) > div:nth-child(3) > div:nth-child(2) > div:nth-child(1) > div:nth-child(5)";
            var container = page.Locator(containerSelector);
            await container.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Visible, Timeout = 10000 });

            // 4. Get all child divs that contain 'Top Ten'
            var topTenItems = container.Locator("div:has-text('Top Ten')");
            var count = await topTenItems.CountAsync();

            // 5. Validate all found elements
            Assert.IsTrue(count > 0, "No 'Top Ten' items found inside the grid.");

            for (var i = 0; i < count; i++)
            {
                var item = topTenItems.Nth(i);
                var displayed = await item.IsVisibleAsync();
                var text = await item.InnerTextAsync();
                Assert.IsTrue(displayed, $"Item '{text}' is not visible.");
            }
        }
    }
}
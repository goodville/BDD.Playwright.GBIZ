using BDD.Playwright.GBIZ.PageElements;
using BDD.Playwright.GBIZ.Pages.CommonPage;
using BDD.Playwright.GBIZ.Pages.XpathProperties;
using Microsoft.Playwright;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDD.Playwright.Test.StepDefinitions.Public_StepDefinition
{
    [Binding]
    public class TC8_StepDefinition : BasePage
    {
        private readonly ScenarioContext _scenarioContext;
        public CommonXpath _commonXpath;
        public TC8_StepDefinition(ScenarioContext scenarioContext, CommonXpath commonXpath) : base(scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _commonXpath = commonXpath;
        }

        [When(@"User Click on the Search Icon and Enter the Home and Verify the Blog Home is displayed")]
        public async Task WhenUserClickontheSearchIconandEntertheHomeandVerifytheBlogHomeisDisplayedAsync()
        {
            await Button.ClickButtonAsync(_commonXpath.Search_ICON, ActionType.Click, true, 1);
            await page.Locator(_commonXpath.SearchBlog_Inp).FillAsync("Home");
            await page.Keyboard.PressAsync("Enter");
            await page.WaitForLoadStateAsync(LoadState.NetworkIdle);
            var OurBlogTitle = await page.TitleAsync();
            if (OurBlogTitle == "Goodville Mutual Casualty Company - Home")
            {
                logger.WriteLine("Goodville Mutual Casualty Company - Home");
            }
            else
            {
                logger.WriteLine(OurBlogTitle);
                throw new Exception("Our Blog page Title is not Matching it is displaying " + OurBlogTitle);
            }

            await Label.VerifyTextAsync(_commonXpath.BlogPage_Validation, "Our Blog", true, 1);
        }

        [When("User Click on Search Icon and Enter Text and Verify the no Results dispalyed")]
        public async Task WhenUserClickOnSearchIconAndEnterTextAndVerifyTheNoResultsDispalyedAsync()
        {
           await Button.ClickButtonAsync(_commonXpath.Search_ICON, ActionType.Click, true, 1);
           await page.Locator(_commonXpath.SearchBlog_Inp).FillAsync("Text");
           await page.Keyboard.PressAsync("Enter");
           await page.WaitForLoadStateAsync(LoadState.NetworkIdle);
           await Label.VerifyTextAsync(_commonXpath.BlogPage_NoResult_Validation, "There are no results to display.", true, 1);
        }
    }
}

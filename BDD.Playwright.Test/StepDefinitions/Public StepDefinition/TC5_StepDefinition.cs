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
    public class TC5_StepDefinition : BasePage
    {
        private readonly ScenarioContext _scenarioContext;
        public CommonXpath _commonXpath;
        public TC5_StepDefinition(ScenarioContext scenarioContext, CommonXpath commonXpath) : base(scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _commonXpath = commonXpath;
        }

        [When(@"User Click on the Our Blog and Verify the Title")]
        public async Task WhenUserClickontheOurBlogandVerifytheTitleAsync()
        {
            await TextLink.ClickTextLinkAsync(_commonXpath.OurBlog_Link, true, 1);
            var OurBlogTitle = await page.TitleAsync();
            if (OurBlogTitle == "Goodville Mutual Casualty Company - Blog")
            {
                logger.WriteLine("Our Blog page Title is Goodville Mutual Casualty Company - Blog");
            }
            else
            {
                throw new Exception("Our Blog page Title is not Matching it is displaying " + OurBlogTitle);
            }

            await TextLink.ClickTextLinkAsync(_commonXpath.PolicyHolderStories_Link, true, 1);
            await Label.VerifyTextAsync(_commonXpath.PolicyHolderMessageValidation, "Policyholder Claim Story: Rich in Ohio", true, 1);
            await TextLink.ClickTextLinkAsync(_commonXpath.BlogArchive2016_Link, true, 1);
            Thread.Sleep(1000);
            await TextLink.ClickTextLinkAsync(_commonXpath.BlogArchive2016Oct_Link, true, 1);
            await Label.VerifyTextAsync(_commonXpath.BlogArchive2016Oct_Validation, "October 19, 2016", true, 1);
        }
    }
}

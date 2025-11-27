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
    public class TC1_StepDefinition : BasePage
    {
        private readonly ScenarioContext _scenarioContext;
        public CommonXpath _commonXpath;
        public TC1_StepDefinition(ScenarioContext scenarioContext, CommonXpath commonXpath) : base(scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _commonXpath = commonXpath;
        }

        [When(@"Verifying the Home Page Title")]
        public async Task WhenVerifyingtheHomePageTitleAsync()
        {
            var HomePageTitle = await page.TitleAsync();
            if (HomePageTitle == "Goodville Mutual Casualty Company - Home")
            {
                logger.WriteLine("Home Page Title is Goodville Mutual Casualty Company - Home");
            }
            else
            {
                throw new Exception("Home page Title is not Matching it is displaying " + HomePageTitle);
            }
        }

        [When("User Enter the Address to find an Agent in that Location")]
        public async Task WhenUserEntertheZipcodetoFindAgentinthatLocationAsync()
        {
            await page.Locator(_commonXpath.Address_Inp).FillAsync("New Holland, PA 17557, USA");
            await page.Locator(_commonXpath.Search_Button).ClickAsync();
            await page.WaitForLoadStateAsync(LoadState.NetworkIdle);
            var addressValue = await page.Locator(_commonXpath.ZipSearch_Inp).InputValueAsync();

            if (addressValue.Contains("New Holland, PA 17557, USA"))
            {
                Console.WriteLine("Address is displaying correctly");
            }
            else
            {
                throw new Exception($"Address is not displaying correctly. Actual: {addressValue}");
            }

            var findAnAgentPageTitle = await page.TitleAsync();
            if (findAnAgentPageTitle == "Goodville Mutual Casualty Company - Find An Agent")
            {
                Console.WriteLine("Find an Agent Page Title is correct");
            }
            else
            {
                throw new Exception($"Find an Agent page title is not matching. Actual: {findAnAgentPageTitle}");
            }
        }

        [When(@"User Verify the Agent Name is Paul")]
        public async Task WhenUserVerifytheResultAsync()
        {
            await Label.VerifyTextAsync(_commonXpath.AgentValidation, "Paul I. Sheaffer Insurance Agency, Inc.", true, 1);
            await TextLink.ClickTextLinkAsync("//span[contains(text(),'Show More')]", true, 1);
            await Label.VerifyTextAsync(_commonXpath.OfficeContact, "(717) 768-8236", true, 1);
            await TextLink.ClickTextLinkAsync("//span[contains(text(),'Show Less')]", true, 1);
        }
    }
}

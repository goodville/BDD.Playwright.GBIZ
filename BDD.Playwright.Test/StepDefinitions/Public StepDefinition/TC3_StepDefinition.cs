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
    public class TC3_StepDefinition : BasePage
    {
        private readonly ScenarioContext _scenarioContext;
        public CommonXpath _commonXpath;
        public TC3_StepDefinition(ScenarioContext scenarioContext, CommonXpath commonXpath) : base(scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _commonXpath = commonXpath;
        }

        [When(@"User Click on Find an Agent and Enter the Address and Verify the Agent details of that Address")]
        public async Task WhenUserClickonFindanAgentandEntertheAddressandVerifytheAgentDetailsofthatAddressAsync()
        {
            await TextLink.ClickTextLinkAsync(_commonXpath.FindanAgent_Link, true, 1);
            await InputField.SetTextAreaInputFieldAsync(_commonXpath.ZipSearch_Inp, "73096", true, 1);
            await Button.ClickButtonAsync(_commonXpath.Search_Button, ActionType.Click, true, 1);
            await Task.Delay(2000);
            await Label.VerifyTextAsync(_commonXpath.AgentValidation, "Harms Insurance Agency, Inc.", true, 1);
            await TextLink.ClickTextLinkAsync(_commonXpath.ShowMore_Link, true, 1);
            await Label.VerifyTextAsync(_commonXpath.OfficeContact, "(800) 657-8846", true, 1);
            await TextLink.ClickTextLinkAsync(_commonXpath.ShowLess_Link, true, 1);
        }
    }
}

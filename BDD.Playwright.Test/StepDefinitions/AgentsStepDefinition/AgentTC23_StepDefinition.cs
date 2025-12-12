using BDD.Playwright.GBIZ.PageElements;
using BDD.Playwright.GBIZ.Pages.CommonPage;
using BDD.Playwright.GBIZ.Pages.GlobalPages;
using BDD.Playwright.GBIZ.Pages.XpathProperties;
using Microsoft.Playwright;
using Reqnroll;
using System.Threading.Tasks;

namespace BDD.Playwright.GBIZ.Pages.AgentsStepDefinition
{
    [Binding]
    public class AgentTC23_StepDefinition : BasePage
    {
        private readonly ScenarioContext _scenarioContext;
        public FeatureContext _featureContext;
        public CommonXpath _commonXpath;
        public LoginPage _loginPage;

        public AgentTC23_StepDefinition(
            ScenarioContext scenarioContext,
            LoginPage loginPage,
            CommonXpath commonXpath
        ) : base(scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _loginPage = loginPage;
            _commonXpath = commonXpath;
        }

        [When(@"User Click on Cross Sell and Click on Business Cover and Delete the quote")]
        public async Task WhenUserClickonCrossSellandClickonBusinessCoverandDeletetheQuoteAsync()
        {
            await Button.ClickButtonAsync(_commonXpath.CrossSell_Btn, ActionType.Click, true, 1);
            await Button.ClickButtonAsync(_commonXpath.CrossSell_BusinessCover_Btn, ActionType.Click, true, 1);
            //await TextLink.ClickTextLinkAsync(_commonXpath.Delete_Link, true, 1);
            page.Dialog += async (_, dialog) => await dialog.AcceptAsync();
            await TextLink.ClickTextLinkAsync(_commonXpath.Delete_Link, true, 1);
            Console.WriteLine("text");
            await Button.ClickButtonCssAsync(_commonXpath.ShadowHost, _commonXpath.PolicySidePanelShadow);
            //var locator = page.Locator("gg-leftnav >>> div.gg-leftnavlinkgrid > a[href='/agents/business/policy/']").ClickAsync();
        }

        [When(@"User Click on Cross Sell and Click on Tradesman Cover and Delete the quote")]
        public async Task WhenUserClickonCrossSellandClickonTradesmanCoverandDeletetheQuoteAsync()
        {
            await Button.ClickButtonAsync(_commonXpath.CrossSell_Btn, ActionType.Click, true, 1);
            await Button.ClickButtonAsync(_commonXpath.CrossSell_TradesmanCover_Btn, ActionType.Click, true, 1);
            page.Dialog += async (_, dialog) => await dialog.AcceptAsync();
            await TextLink.ClickTextLinkAsync(_commonXpath.Delete_Link, true, 1);
            await Button.ClickButtonCssAsync(_commonXpath.ShadowHost, _commonXpath.PolicySidePanelShadow);
        }

        [When(@"User Click on Cross Sell and Click on Personal Umbrella and Delete the quote")]
        public async Task WhenUserClickonCrossSellandClickonPersonalUmbrellaandDeletetheQuoteAsync()
        {
            await Button.ClickButtonAsync(_commonXpath.CrossSell_Btn, ActionType.Click, true, 1);
            await Button.ClickButtonAsync(_commonXpath.CrossSell_PersonalUmbrella_Btn, ActionType.Click, true, 1);
           // await TextLink.ClickTextLinkAsync(_commonXpath.Delete_Link, true, 1);

            page.Dialog += async (_, dialog) => await dialog.AcceptAsync();

            await TextLink.ClickTextLinkAsync(_commonXpath.Delete_Link, true, 1);
           // page.Dialog -= async (_, dialog) => await dialog.AcceptAsync();
            await Button.ClickButtonCssAsync(_commonXpath.ShadowHost, _commonXpath.PolicySidePanelShadow);
        }

        [When(@"User clicks on Cross Sell and clicks cancel")]
        public async Task WhenUserClicksonCrossSellandClicksCancelAsync()
        {
            await Button.ClickButtonAsync(_commonXpath.CrossSell_Btn, ActionType.Click, true, 1);
            await Button.ClickButtonAsync(_commonXpath.CrossSell_Cancel_Btn, ActionType.Click, true, 2);
        }
    }
}
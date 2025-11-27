using BDD.Playwright.GBIZ.PageElements;
using BDD.Playwright.GBIZ.Pages.CommonPage;
using BDD.Playwright.GBIZ.Pages.PublicPages;
using BDD.Playwright.GBIZ.Pages.XpathProperties;
using BDD.Playwright.Origami.Pages.PublicPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDD.Playwright.Test.StepDefinitions.Public_StepDefinition
{
    [Binding]
    public class TC11_StepDefinition : BasePage
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly BecomeAGoodvilleAgentProfilePage _becomeAGoodvilleAgentProfilePage;
        private readonly BecomeAGoodvilleAgentOwnershipPage _becomeAGoodvilleAgentOwnershipPage;
        private readonly BecomeAGoodvilleAgentProductionPage _becomeAGoodvilleAgentProductionPage;
        private readonly BecomeAGoodvilleAgentLossHistoryPage _becomeAGoodvilleAgentLossHistoryPage;
        public CommonXpath _commonXpath;
        public TC11_StepDefinition(ScenarioContext scenarioContext, BecomeAGoodvilleAgentProfilePage becomeAGoodvilleAgentProfilePage, BecomeAGoodvilleAgentOwnershipPage becomeAGoodvilleAgentOwnershipPage, BecomeAGoodvilleAgentProductionPage becomeAGoodvilleAgentProductionPage, BecomeAGoodvilleAgentLossHistoryPage becomeAGoodvilleAgentLossHistoryPage, CommonXpath commonXpath) : base(scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _commonXpath = commonXpath;
            _becomeAGoodvilleAgentProfilePage = becomeAGoodvilleAgentProfilePage;
            _becomeAGoodvilleAgentOwnershipPage = becomeAGoodvilleAgentOwnershipPage;
            _becomeAGoodvilleAgentProductionPage = becomeAGoodvilleAgentProductionPage;
            _becomeAGoodvilleAgentLossHistoryPage = becomeAGoodvilleAgentLossHistoryPage;
        }

        [When(@"User clicks on about us on home page")]
        public async Task WhenUserClicksOnAboutUsOnHomePageAsync()
        {
            await TextLink.ClickTextLinkAsync(_commonXpath.AboutUS_Link, true, 1);
        }

        [When(@"User clicks on become a goodville agent")]
        public async Task WhenUserClicksOnBecomeAGoodvilleAgentAsync()
        {
            await TextLink.ClickTextLinkAsync(_commonXpath.BecomeAgent_Link, true, 1);
        }

        [When(@"User clicks on continue")]
        public async Task WhenUserClicksOnContinueAsync()
        {
            await Button.ClickButtonAsync(_commonXpath.Continue_Button, ActionType.Click, true, 1);
        }

        [When(@"User enters required fields in become a goodville agent profile page")]
        public async Task WhenUserEntersRequiredFieldsInBecomeAGoodvilleAgentProfilePageAsync()
        {
            await _becomeAGoodvilleAgentProfilePage.AddAgencyDetailsProfileAsync();
        }

        [When(@"User enters required fields in become a goodville agent ownership page")]
        public async Task WhenUserEntersRequiredFieldsInBecomeAGoodvilleAgentOwnershipPageAsync()
        {
            await _becomeAGoodvilleAgentOwnershipPage.FillOwnershipDataAsync();
        }

        [When(@"User enters required fields in become a goodville agent production page")]
        public async Task WhenUserEntersRequiredFieldsInBecomeAGoodvilleAgentProductionPageAsync()
        {
            await _becomeAGoodvilleAgentProductionPage.AddCarriersAsync();
        }

        [When(@"User enters required fields in become a goodville agent loss history page")]
        public async Task WhenUserEntersRequiredFieldsInBecomeAGoodvilleAgentLossHistoryPageAsync()
        {
            await _becomeAGoodvilleAgentLossHistoryPage.FillLossHistoryDataAsync();
        }

       /* [When(@"User clicks on continue for Loss History Page")]
        public void WhenUserClicksOnContinueForLossHistoryPage()
        {
            Button.ClickButton(_becomeAGoodvilleAgentLossHistoryPage.LossHistoryContinue_Button, ActionType.Click, true, 1);
        }*/

        [When(@"User clicks on continue review and apply page")]
        public async Task WhenUserClicksOnContinueReviewAndApplyPageAsync()
        {
            await Button.ClickButtonAsync(_commonXpath.ReviewAndApplyContinue_Button, ActionType.Click, true, 1);
        }
    }
}

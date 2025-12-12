using BDD.Playwright.GBIZ.PageElements;
using BDD.Playwright.GBIZ.Pages.AgentsPages;
using BDD.Playwright.GBIZ.Pages.CommonPage;
using BDD.Playwright.GBIZ.Pages.XpathProperties;
using Microsoft.Playwright; // <-- Playwright

namespace GoodVille.GBIZ.Reqnroll.Automation.Steps.AgentsStepDefinition
{
    [Binding]
    public class AgentTC36_StepDefinition : BasePage
    {
        private readonly ScenarioContext _scenarioContext;
        public FeatureContext _featureContext;
        public CommonXpath _commonXpath;
        public MyBusinessHomePage _myBusinessHomePage;

        public AgentTC36_StepDefinition(
            ScenarioContext scenarioContext,
            MyBusinessHomePage myBusinessHomePage,
            CommonXpath commonXpath) : base(scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _myBusinessHomePage = myBusinessHomePage;
            _commonXpath = commonXpath;
        }

        #region Xpath
        public string AgentDirectory_Link { get; set; } = "a[href='/agents/marketing/directory/']";
        public string Kansas_MapPath { get; set; } = "//*[name()='path' and @id='KS']";
        public string Oklahoma_MapPath { get; set; } = "//*[name()='path' and @id='OK']";
        public string Illinois_MapPath { get; set; } = "//*[name()='path' and @id='IL']";
        public string Indiana_MapPath { get; set; } = "//*[name()='path' and @id='IN']";
        public string Ohio_MapPath { get; set; } = "//*[name()='path' and @id='OH']";
        public string Pennsylvania_MapPath { get; set; } = "//*[name()='path' and @id='PA']";
        public string Virginia_MapPath { get; set; } = "//*[name()='path' and @id='VA']";
        public string Delaware_MapPath { get; set; } = "//*[name()='path' and @id='DE']";

        public string KansasHeading_Title { get; set; } = "//span[@class='heading1' and contains(text(),'KS')]";
        public string OklahomaHeading_Title { get; set; } = "//span[@class='heading1' and contains(text(),'OK')]";
        public string IllinoisHeading_Title { get; set; } = "//span[@class='heading1' and contains(text(),'IL')]";
        public string IndianaHeading_Title { get; set; } = "//span[@class='heading1' and contains(text(),'IN')]";
        public string OhioHeading_Title { get; set; } = "//span[@class='heading1' and contains(text(),'OH')]";
        public string PennsylvaniaHeading_Title { get; set; } = "//span[@class='heading1' and contains(text(),'PA')]";
        public string VirginiaHeading_Title { get; set; } = "//span[@class='heading1' and contains(text(),'VA')]";
        public string DelawareHeading_Title { get; set; } = "//span[@class='heading1' and contains(text(),'DE')]";
        #endregion

        // Playwright version is async
        public async Task SamePageHeadingVerifyMethodAsync(string requiredXpath, string requiredHeading, string returnToPage)
        {
            // Assume TextLink.ClickTextLink uses Playwright internally and is async
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

        [When("User navigates to goodville information")]
        public async Task WhenUserNavigatesToGoodvilleInformationAsync()
        {
            await Button.ClickButtonCssAsync(_commonXpath.ShadowHostTopPanelShadow, _commonXpath.GoodvilleInformationMainShadow);
        }

        [When("User click on Agent directory")]
        public async Task WhenUserClickOnAgentDirectoryAsync()
        {
            await Button.ClickButtonCssAsync(_commonXpath.ShadowHostSlidePanelShadow, AgentDirectory_Link);
        }

        [When("User verifies map navigation for Delaware state")]
        public async Task WhenUserVerifiesMapNavigationForDelawareStateAsync()
        {
            await SamePageHeadingVerifyMethodAsync(Delaware_MapPath, DelawareHeading_Title, "Back");
        }

        [When("User verifies map navigation for Illinois state")]
        public async Task WhenUserVerifiesMapNavigationForIllinoisStateAsync()
        {
            await SamePageHeadingVerifyMethodAsync(Illinois_MapPath, IllinoisHeading_Title, "Back");
        }

        [When("User verifies map navigation for Indiana state")]
        public async Task WhenUserVerifiesMapNavigationForIndianaStateAsync()
        {
            await SamePageHeadingVerifyMethodAsync(Indiana_MapPath, IndianaHeading_Title, "Back");
        }

        [When("User verifies map navigation for Ohio state")]
        public async Task WhenUserVerifiesMapNavigationForOhioStateAsync()
        {
            await SamePageHeadingVerifyMethodAsync(Ohio_MapPath, OhioHeading_Title, "Back");
        }

        [When("User verifies map navigation for Oklahoma state")]
        public async Task WhenUserVerifiesMapNavigationForOklahomaStateAsync()
        {
            await SamePageHeadingVerifyMethodAsync(Oklahoma_MapPath, OklahomaHeading_Title, "Back");
        }

        [When("User verifies map navigation for Kansas state")]
        public async Task WhenUserVerifiesMapNavigationForKansasStateAsync()
        {
            await SamePageHeadingVerifyMethodAsync(Kansas_MapPath, KansasHeading_Title, "Back");
        }

        [When("User verifies map navigation for Pennsylvania state")]
        public async Task WhenUserVerifiesMapNavigationForPennsylvaniaStateAsync()
        {
            await SamePageHeadingVerifyMethodAsync(Pennsylvania_MapPath, PennsylvaniaHeading_Title, "Back");
        }

        [When("User verifies map navigation for Virginia state")]
        public async Task WhenUserVerifiesMapNavigationForVirginiaStateAsync()
        {
            await SamePageHeadingVerifyMethodAsync(Virginia_MapPath, VirginiaHeading_Title, "Back");
        }
    }
}
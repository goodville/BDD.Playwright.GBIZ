using AventStack.ExtentReports.Gherkin.Model;
using BDD.Playwright.GBIZ.PageElements;
using BDD.Playwright.GBIZ.Pages.AgentsPages;
using BDD.Playwright.GBIZ.Pages.CommonPage;
using BDD.Playwright.GBIZ.Pages.XpathProperties;
using BDD.Playwright.Test.StepDefinitions.Public_StepDefinition;
using Microsoft.Playwright;

namespace GoodVille.GBIZ.Reqnroll.Automation.Steps.AgentsStepDefinition
{
    [Binding]
    public class AgentTC39_StepDefinition : BasePage
    {
        private readonly ScenarioContext _scenarioContext;
        public FeatureContext _featureContext;
        public CommonXpath _commonXpath;
        public TC9_StepDefinition _TC9_StepDefinition;
        public MyBusinessHomePage _myBusinessHomePage;

        public AgentTC39_StepDefinition(
            ScenarioContext scenarioContext,
            MyBusinessHomePage myBusinessHomePage,
            CommonXpath commonXpath,
            TC9_StepDefinition tC9_StepDefinition) : base(scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _myBusinessHomePage = myBusinessHomePage;
            _commonXpath = commonXpath;
            _TC9_StepDefinition = tC9_StepDefinition;
        }

        #region Xpath
        public string Links_Link { get; set; } = "a[href='/agents/marketing/links/']";
        #endregion

        [When("User click on IIAA Links Page and verifies that each link is navigate to correct page")]
        public async Task WhenUserclickonIIAALinksPageAsync()
        {
            await Button.ClickButtonCssAsync(_commonXpath.ShadowHostSlidePanelShadow, Links_Link);
            await _TC9_StepDefinition.NextPageTitleVerifyMethodAsync(_commonXpath.Link_IIAA, "The Big \"I\" | The Association for Independent Insurance Agents");
        }

        [When("User click on PIA Links Page and verifies that each link is navigate to correct page")]
        public async Task WhenUserclickonPIALinksPageAsync()
        {
            await Button.ClickButtonCssAsync(_commonXpath.ShadowHostSlidePanelShadow, Links_Link);
            await _TC9_StepDefinition.NextPageTitleVerifyMethodAsync(_commonXpath.Link_PIA, "Home | PIA");
        }

        [When("User click on Applied Systems Links Page and verifies that each link is navigate to correct page")]
        public async Task WhenUserclickonAppliedSystemsLinksPageAsync()
        {
            await Button.ClickButtonCssAsync(_commonXpath.ShadowHostSlidePanelShadow, Links_Link);
            await _TC9_StepDefinition.NextPageTitleVerifyMethodAsync(_commonXpath.Link_AppliedSystyems, "Insurance Software for Independent Agencies | Applied Systems");
        }

        [When("User click on ASCnet Links Page and verifies that each link is navigate to correct page")]
        public async Task WhenUserclickonASCLinksPageAsync()
        {
            await Button.ClickButtonCssAsync(_commonXpath.ShadowHostSlidePanelShadow, Links_Link);
            await _TC9_StepDefinition.NextPageTitleVerifyMethodAsync(_commonXpath.Link_ACSnet, "Applied Client Network");
        }

        [When("User click on Doris Links Page and verifies that each link is navigate to correct page")]
        public async Task WhenUserclickonDorisLinksPageAsync()
        {
            await Button.ClickButtonCssAsync(_commonXpath.ShadowHostSlidePanelShadow, Links_Link);
            await _TC9_StepDefinition.NextPageTitleVerifyMethodAsync(_commonXpath.Link_Doris, "Insurance Software for Independent Agencies | Applied Systems");
        }

        [When("User click on Vertafore Links Page and verifies that each link is navigate to correct page")]
        public async Task WhenUserclickonVertaforeLinksPageAsync()
        {
            await Button.ClickButtonCssAsync(_commonXpath.ShadowHostSlidePanelShadow, Links_Link);
            await _TC9_StepDefinition.NextPageTitleVerifyMethodAsync(_commonXpath.Link_Vertafore, "Insurance Software Solutions - Carriers, Agencies, MGAs, Independent Agents");
        }

        [When("User click on CPCU Links Page and verifies that each link is navigate to correct page")]
        public async Task WhenUserclickonCPCULinksPageAsync()
        {
            await Button.ClickButtonCssAsync(_commonXpath.ShadowHostSlidePanelShadow, Links_Link);
            await _TC9_StepDefinition.NextPageTitleVerifyMethodAsync(_commonXpath.Link_CPCU, "The Institutes CPCU Society - Community for Risk & Insurance Professionals");
        }

        [When("User click on American Institute CPCU Links Page and verifies that each link is navigate to correct page")]
        public async Task WhenUserclickonAmericanCPCULinksPageAsync()
        {
            await Button.ClickButtonCssAsync(_commonXpath.ShadowHostSlidePanelShadow, Links_Link);
            await _TC9_StepDefinition.NextPageTitleVerifyMethodAsync(_commonXpath.Link_AmericanInsCPCUIns, "Homepage | The Institutes");
        }

        [When("User click on National Alliance for Insurance Education and Research Links Page and verifies that each link is navigate to correct page")]
        public async Task WhenUserclickonAllianceInsEduResearchAsync()
        {
            await Button.ClickButtonCssAsync(_commonXpath.ShadowHostSlidePanelShadow, Links_Link);
            await _TC9_StepDefinition.NextPageTitleVerifyMethodAsync(_commonXpath.Link_NationalAlliance, "Risk & Insurance Education Alliance");
        }

        [When("User click on National Underwriter Company Links Page and verifies that each link is navigate to correct page")]
        public async Task WhenUserclickonNationalUWCompanyLinksPageAsync()
        {
            await Button.ClickButtonCssAsync(_commonXpath.ShadowHostSlidePanelShadow, Links_Link);
            await _TC9_StepDefinition.NextPageTitleVerifyMethodAsync(_commonXpath.Link_NationalUWCompany, "National Underwriter Resource Center");
        }

        [When("User click on EZLynx Links Page and verifies that each link is navigate to correct page")]
        public async Task WhenUserclickonEZLynxinksPageAsync()
        {
            await Button.ClickButtonCssAsync(_commonXpath.ShadowHostSlidePanelShadow, Links_Link);
            await _TC9_StepDefinition.NextPageTitleVerifyMethodAsync(_commonXpath.Link_EZLynx, "Comparative Rater - Agency Management Systems (AMS) – Insurance CRM Software | EZLynx");
        }

        [When("User click on PL Rating Links Page and verifies that each link is navigate to correct page")]
        public async Task WhenUserclickonPLRatinginksPageAsync()
        {
            await Button.ClickButtonCssAsync(_commonXpath.ShadowHostSlidePanelShadow, Links_Link);
            await _TC9_StepDefinition.NextPageTitleVerifyMethodAsync(_commonXpath.Link_PLRating, "Insurance Comparative Rater | PL Rater");
        }

        [When("User click on Quomation Links Page and verifies that each link is navigate to correct page")]
        public async Task WhenUserclickonQuomationLinksPageAsync()
        {
            await Button.ClickButtonCssAsync(_commonXpath.ShadowHostSlidePanelShadow, Links_Link);
            await _TC9_StepDefinition.NextPageTitleVerifyMethodAsync(_commonXpath.Link_Quomation, "Quomation Insurance Services");
        }

        [When("User click on Rough Notes Links Page and verifies that each link is navigate to correct page")]
        public async Task WhenUserclickonRoughLinksPageAsync()
        {
            await Button.ClickButtonCssAsync(_commonXpath.ShadowHostSlidePanelShadow, Links_Link);
            await _TC9_StepDefinition.NextPageTitleVerifyMethodAsync(_commonXpath.Link_RoughNotes, "Home - The Rough Notes Company Inc.");
        }

        [When("User click on NFPA Links Page and verifies that each link is navigate to correct page")]
        public async Task WhenUserclickonNFPALinksPageAsync()
        {
            await Button.ClickButtonCssAsync(_commonXpath.ShadowHostSlidePanelShadow, Links_Link);
            await _TC9_StepDefinition.NextPageTitleVerifyMethodAsync(_commonXpath.Link_NFPA, "NFPA | The National Fire Protection Association");
        }

        [When("User click on NADA Links Page and verifies that each link is navigate to correct page")]
        public async Task WhenUserclickonNADALinksPageAsync()
        {
            await Button.ClickButtonCssAsync(_commonXpath.ShadowHostSlidePanelShadow, Links_Link);
            await _TC9_StepDefinition.NextPageTitleVerifyMethodAsync(_commonXpath.Link_NADA, "New Car Prices & Used Car Values | NADA Car Value");
        }

        // If you uncomment or add variants, update them to async and Playwright, as above.

        // If you need the "every link" validator, you would loop via Playwright APIs, e.g.:
        // public async Task WhenUserVerifiesEveryLinkAsync()
        // {
        //     var links = await _page.QuerySelectorAllAsync("a");
        //     foreach (var link in links)
        //     {
        //         var href = await link.GetAttributeAsync("href");
        //         // ...Validate and click as needed, handle window context etc...
        //     }
        // }
    }
}
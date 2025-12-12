using AventStack.ExtentReports.Gherkin.Model;
using BDD.Playwright.Core.Loggers;
using BDD.Playwright.GBIZ.PageElements;
using BDD.Playwright.GBIZ.Pages.CommonPage;
using BDD.Playwright.GBIZ.Pages.XpathProperties;
using BDD.Playwright.Origami.Pages.AgentPages;
using GoodVille.GBIZ.Reqnroll.Automation.Pages.GlobalPages;

namespace GoodVille.GBIZ.Specflow.Automation.Steps.AgentsStepDefinition
{
    [Binding]
    public class AgentTC49_StepDefinition : BasePage
    {
        private readonly ScenarioContext _scenarioContext;
        public FeatureContext _featureContext;
        public CommonXpath _commonXpath;
        private readonly ApplicationLogger _applicationLogger;
        public LoginPage _loginPage;
        public ProfilePage _profilePage;

        // Playwright page
        private readonly Microsoft.Playwright.IPage _page;

        // Constructor updates to accept IPage for Playwright
        public AgentTC49_StepDefinition(
            ScenarioContext scenarioContext,
            LoginPage loginPage,
            CommonXpath commonXpath,
            ProfilePage profilePage
        ) : base(scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _loginPage = loginPage;
            _commonXpath = commonXpath;
            _profilePage = profilePage;
            _page = page;
        }

        [When(@"User Click the Cross Sell Quote link")]
        public async Task UserClickTheCrossSellQuotelinkAsync()
        {
            // Equivalent Playwright call to your Button helper class
            await Button.ClickButtonAsync(_commonXpath.CrossSell_Btn, ActionType.Click, true, 1);
            await Task.Delay(6000); // Maintain explicit timing as per Selenium code
        }

        [When(@"User navigate to the Commercial Umbrella quote applicant page")]
        public async Task UserNavigateToTheCommercialUmbrellaQuoteApplicantPageAsync()
        {
            await Button.ClickButtonAsync(_commonXpath.CrossSell_CommercialUmbrella_Btn, ActionType.Click, true, 1);
            await Task.Delay(12000); // Maintain pause as per Selenium code
            await Label.VerifyTextAsync(_commonXpath.CommercialUmbrellaApplicant_Text, "Commercial Umbrella", true, 1);
        }
    }
}
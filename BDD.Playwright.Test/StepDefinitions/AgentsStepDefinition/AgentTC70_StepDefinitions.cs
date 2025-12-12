using BDD.Playwright.Core.Loggers;
using BDD.Playwright.GBIZ.PageElements;
using BDD.Playwright.GBIZ.Pages.AgentPages;
using BDD.Playwright.GBIZ.Pages.CommonPage;
using BDD.Playwright.GBIZ.Pages.XpathProperties;
using BDD.Playwright.Origami.Pages.AgentPages;
using GoodVille.GBIZ.Reqnroll.Automation.Pages.AgentPages;
using GoodVille.GBIZ.Reqnroll.Automation.Pages.GlobalPages;

namespace GoodVille.GBIZ.Reqnroll.Automation.Steps.AgentsStepDefinition
{
    [Binding]
    public class AgentTC70_StepDefinitions : BasePage
    {
        private readonly ScenarioContext _scenarioContext;
        public FeatureContext _featureContext;
        public CommonXpath _commonXpath;
        public Quote_ApplicantPage _quoteApplicant;
        public Quote_CoveragesPage _quoteCoverage;
        public Quote_DwellingPage _quoteDwelling;
        public Quote_LocationsPage _quote_LocationsPage;
        public Quote_PriorCarriersPage _quote_PriorCarriersPage;

        #region Xpath
        public string WorkersComp_Button { get; set; } = "//button[normalize-space()='Workers Comp']";
        public string WorkersCompensation_Text { get; set; } = "//div[contains(text(),'Workers Compensation')]";
        #endregion

        // Constructor
        public AgentTC70_StepDefinitions(
            ScenarioContext scenarioContext,
            CommonXpath commonXpath,
            Quote_ApplicantPage quoteApplicantpage,
            Quote_CoveragesPage quoteCoveragespage,
            Quote_DwellingPage quoteDwellingpage,
            Quote_LocationsPage quote_LocationsPage,
            Quote_PriorCarriersPage quote_PriorCarriersPage) : base(scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _commonXpath = commonXpath;
            _quoteApplicant = quoteApplicantpage;
            _quoteCoverage = quoteCoveragespage;
            _quoteDwelling = quoteDwellingpage;
            _quote_LocationsPage = quote_LocationsPage;
            _quote_PriorCarriersPage = quote_PriorCarriersPage;
        }

        [When("User clicks on Workers Comp Button")]
        public async Task WhenUserClicksOnWorkersCompButtonAsync()
        {
            await Task.Delay(2000);
            await Button.ClickButtonAsync(WorkersComp_Button, ActionType.Click, true, 1);
        }

        [When("User fills the mandatory field in the application info in applicant page for Workers Comp from json {string}")]
        public async Task WhenUserFillsTheMandatoryFieldInTheApplicationInfoInApplicantPageForWorkersCompAsync(string jsonFile)
        {
            await _quoteApplicant.WorkersCompApplicantDatafillAsync(jsonFile);
        }

        [When("User fills the mandatory field in the underwriting info in applicant page for Workers Comp from json {string}")]
        public async Task WhenUserFillsTheMandatoryFieldInTheUnderwritingInfoInApplicantPageForWorkersCompAsync(string jsonFile)
        {
            await _quoteApplicant.WorkersCompUnderwritingInfoFillAsync(jsonFile);
        }

        [When("User fills the mandatory field in the locations page for Workers Comp from json {string}")]
        public async Task WhenUserFillsTheMandatoryFieldInTheLocationsPageForWorkersCompAsync(string jsonFile)
        {
            await _quote_LocationsPage.WorkersCompLocationsDataFillAsync(jsonFile);
        }

        [When("User fills the mandatory field in the coverages page for Workers Comp from json {string}")]
        public async Task WhenUserFillsTheMandatoryFieldInTheCoveragesPageForWorkersCompAsync(string jsonFile)
        {
            await _quoteCoverage.WorkersCompCoveragesDataFillAsync(jsonFile);
        }

        [When("User fills the mandatory field in the prior carriers page for Workers Comp from json {string}")]
        public async Task WhenUserFillsTheMandatoryFieldInThePriorCarriersPageForWorkersCompAsync(string jsonFile)
        {
            await _quote_PriorCarriersPage.WorkersCompPriorCarriersDatafillAsync(jsonFile);
        }

        [Then("Verify Workers Compensation text is present")]
        public async Task ThenVerifyWorkersCompensationTextIsPresentAsync()
        {
            await Label.VerifyTextAsync(WorkersCompensation_Text, "Workers Compensation", true, 1);
            await Label.GetTextAsync(_commonXpath.PersonalAuto_FullText, true, 1);
            var pattern = @"^Workers Compensation - \d+$";
            await Label.VerifyTextFormatAsync("//div[@id='formHeaderLeft']", pattern, true, 1, "Policy Header");
        }
    }
}
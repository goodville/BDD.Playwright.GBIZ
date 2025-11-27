using BDD.Playwright.GBIZ.PageElements;
using BDD.Playwright.GBIZ.Pages.AgentsPages;
using BDD.Playwright.GBIZ.Pages.CommonPage;
using BDD.Playwright.GBIZ.Pages.XpathProperties;
using Microsoft.Playwright;
using System.Threading.Tasks;

namespace GoodVille.GBIZ.Reqnroll.Automation.Steps.AgentsStepDefinition
{
    [Binding]
    public class AgentTC43_StepDefinition : BasePage
    {
        private readonly ScenarioContext _scenarioContext;
        public FeatureContext _featureContext;
        public CommonXpath _commonXpath;
        public MyBusinessHomePage _myBusinessHomePage;

        public AgentTC43_StepDefinition(
            ScenarioContext scenarioContext,
            MyBusinessHomePage myBusinessHomePage,
            CommonXpath commonXpath
        ) : base(scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _myBusinessHomePage = myBusinessHomePage;
            _commonXpath = commonXpath;
        }

        #region XPATH
        public string Policy_PolicyNumber_Text { get; set; } = "//div[contains(text(),'Policy 135037')]";
        public string Policy_Details_Displayed { get; set; } = "//tr[@class='gg-row cdk-row ng-star-inserted']";
        public string IDCards_btn { get; set; } = "//button[@class='solid button-theme-primary' and text()='ID Cards']";
        public string GenerateIdCard_Text { get; set; } = "//h2[text()='Generate ID Card']";
        public string Print_btn { get; set; } = "//button[@class='solid button-theme-primary' and text()='Print']";
        #endregion

        [When("User Click on Search panel")]
        public async Task WhenUserClickonSearchpanelAsync()
        {
            await Button.ClickButtonCssAsync(_commonXpath.ShadowHost, _commonXpath.SearchSidePanelShadow);
        }

        [When("User enter the policy and search")]
        public async Task WhenUserEnterThePolicyAndSearchAsync()
        {
            await InputField.SetTextAreaInputFieldAsync( _commonXpath.SearchPolicyPage_Keyword_Inp, "135037", true, 1);
            await Button.ClickButtonAsync(Policy_Details_Displayed, ActionType.Click, true, 1, "Policy Details Table Row", false);
            await Label.VerifyTextAsync(Policy_PolicyNumber_Text, "Policy 135037", true, 1);
        }

        [When("User click on Id card button")]
        public async Task WhenUserClickonIdcardbuttonAsync()
        {
            await Button.ClickButtonAsync(IDCards_btn, ActionType.Click, true, 1, "ID Card", false);
        }

        [When("User able to see the Generate ID card popup")]
        public async Task WhenUserAbleToSeeTheGenerateIDCardPopupAsync()
        {
            await Label.VerifyTextAsync(GenerateIdCard_Text, "Generate ID Card", true, 1);
        }

        [When("User click on Print button")]
        public async Task WhenUserClickOnPrintButtonAsync()
        {
            await Button.ClickButtonAsync(Print_btn, ActionType.Click, true, 1, "Print button", false);
        }

        [When("User validates the PDF document downloaded")]
        public async Task WhenUserValidatesThePDFDocumentDownloadedAsync()
        {
            // PDF validation logic is assumed to be synchronous and unchanged.
            var downloadFolder = @"C:\Users\ssurapar\Downloads";
            var filePattern = "Document_*.pdf";
            var expectedPolicyNumber = "135037";

            await ValidatePdf.ValidatePdfContainsTextAsync(folderPath: downloadFolder, filePattern: filePattern, expectedText: expectedPolicyNumber);
        }
    }
}
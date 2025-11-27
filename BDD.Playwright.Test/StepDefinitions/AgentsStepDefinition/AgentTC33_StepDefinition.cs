using AventStack.ExtentReports.Gherkin.Model;
using BDD.Playwright.GBIZ.PageElements;
using BDD.Playwright.GBIZ.Pages.AgentsPages;
using BDD.Playwright.GBIZ.Pages.CommonPage;
using BDD.Playwright.GBIZ.Pages.XpathProperties;

namespace GoodVille.GBIZ.Reqnroll.Automation.Steps.AgentsStepDefinition
{
    [Binding]
    public class AgentTC33_StepDefinition : BasePage
    {
        private readonly ScenarioContext _scenarioContext;
        public FeatureContext _featureContext;
        public CommonXpath _commonXpath;
        public MyBusinessHomePage _myBusinessHomePage;

        public AgentTC33_StepDefinition(
            ScenarioContext scenarioContext,
            MyBusinessHomePage myBusinessHomePage,
            CommonXpath commonXpath
        ) : base(scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _myBusinessHomePage = myBusinessHomePage;
            _commonXpath = commonXpath;
        }

        public string FAQHelp_Link { get; set; } = "a[href='/agents/marketing/faq/']";

        public async Task SamePageHeadingVerifyMethodAsync(string RequiredXpath, string RequiredHeading, string ReturnToPage)
        {
            await TextLink.ClickTextLinkAsync(RequiredXpath, true, 1);
            if (await Label.VerifyLabelExistAsync(RequiredHeading, true, 1))
            {
                logger.WriteLine("Heading exists " + RequiredHeading);
            }
            else
            {
                throw new Exception("Page Heading is not Matching.");
            }

            if (ReturnToPage == "Back")
            {
                await page.GoBackAsync();
                logger.WriteLine("Back clicked");
            }
            else
            {
                await TextLink.ClickTextLinkAsync(ReturnToPage, true, 1);
            }
        }

        [When("User Clicks Documents tab and verify the Estimator History documents Opens and clicks PDF")]
        public async Task WhenUserClickOnFAQHelpAsync()
        {
            await Button.ClickButtonAsync(_commonXpath.DocumentsPolicyTab, ActionType.Click, true, 1);
            await Label.VerifyTextAsync(_commonXpath.EstimatorHistDoc, "Estimator History", true, 1);
            await Button.ClickButtonAsync(_commonXpath.EstimatorHistDoc, ActionType.Click, true, 1);
            await Task.Delay(5000);
            await Button.ClickButtonAsync(_commonXpath.PDFClickDoc, ActionType.Click, true, 1, "PDF", false);
            await Task.Delay(5000);
        }

        [When("User Open the PDF page and verify the Replacement Estimator Cost Results")]
        public async Task WhenUservalidatesthePDFdocumentdownloadedAsync()
        {
            var downloadFolder = @"C:\Users\syarramn\Documents\Downloads";
            var filePattern = "*.pdf";
            var expectedReplacementCostType = "Full";
            await ValidatePdf.ValidatePdfContainsTextAsync(folderPath: downloadFolder, filePattern: filePattern, expectedText: expectedReplacementCostType);
        }
    }
}
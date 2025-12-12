using BDD.Playwright.Core.Interfaces;
using BDD.Playwright.GBIZ.PageElements;
using BDD.Playwright.GBIZ.Pages.CommonPage;
using BDD.Playwright.GBIZ.Pages.GlobalPages;
using BDD.Playwright.GBIZ.Pages.XpathProperties;
using Reqnroll;

namespace GoodVille.GBIZ.Reqnroll.Automation.Pages.AgentPages
{
    public class Quote_ClaimsPage : BasePage
    {
        private readonly ScenarioContext _scenarioContext;
        public FeatureContext _featureContext;
        public CommonXpath _commonXpath;
        public LoginPage _loginPage;
        public IFileReader _fileReader;
        // Constructor
        public Quote_ClaimsPage(ScenarioContext scenarioContext, LoginPage loginPage, CommonXpath commonXpath, IFileReader fileReader) : base(scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _loginPage = loginPage;
            _commonXpath = commonXpath;
            _fileReader = fileReader;
        }
        #region Xpath
        public string ClaimType_DropDown { get; set; } = "//select[@id='fld_claim_type']";
        public string LossDate_Input { get; set; } = "//input[@name='claim_lossDate']";
        public string LossAmount_Input { get; set; } = "//input[@name='claim_lossAmount']";
        public string Description_TextArea { get; set; } = "//textarea[@name='claim_description']";
        public string SubmitButton { get; set; } = "//button[@id='buttonclaims_submitbutton']";
        public string AddClaim { get; set; } = "//button[@id='addClaimsButton']";

        #endregion

        public async Task ClaimsDatafillPlaywrightAsync(string profileKey)
        {
            var filePath = "ClaimsPage\\ClaimsPageData.json";

            // Claim Type Dropdown
            var claimTypeValue = _fileReader.GetOptionalValue(filePath, $"{profileKey}.ClaimType");
            if (!string.IsNullOrEmpty(claimTypeValue))
            {
                await DropDown.SelectDropDownAsync(ClaimType_DropDown, claimTypeValue, true, 1);
            }

            // Loss Date Input
            var lossDateValue = _fileReader.GetOptionalValue(filePath, $"{profileKey}.LossDate");
            if (!string.IsNullOrEmpty(lossDateValue))
            {
                await InputField.SetInputFieldAsync(LossDate_Input, lossDateValue, true, 1);
            }

            // Loss Amount Input
            var lossAmountValue = _fileReader.GetOptionalValue(filePath, $"{profileKey}.LossAmount");
            if (!string.IsNullOrEmpty(lossAmountValue))
            {
                await InputField.SetInputFieldAsync(LossAmount_Input, lossAmountValue, true, 1);
            }

            // Description TextArea Input
            var descriptionValue = _fileReader.GetOptionalValue(filePath, $"{profileKey}.Description");
            if (!string.IsNullOrEmpty(descriptionValue))
            {
                await InputField.SetTextAreaInputFieldAsync(Description_TextArea, descriptionValue, true, 1);
            }

            // Add Claim Button
            await Button.ClickButtonAsync(AddClaim, ActionType.Click, true, 1);
        }
    }
}

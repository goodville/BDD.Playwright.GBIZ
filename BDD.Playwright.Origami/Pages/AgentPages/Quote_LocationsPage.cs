
using BDD.Playwright.Core.Interfaces;
using BDD.Playwright.GBIZ.PageElements;
using BDD.Playwright.GBIZ.Pages.CommonPage;
using BDD.Playwright.GBIZ.Pages.GlobalPages;
using BDD.Playwright.GBIZ.Pages.XpathProperties;
using Reqnroll;

namespace BDD.Playwright.GBIZ.Pages.AgentPages
{
    public class Quote_LocationsPage : BasePage
    {
        private readonly ScenarioContext _ScenarioContext;
        public FeatureContext _FeatureContext;
        public CommonXpath _CommonXpath;
        private readonly IFileReader _FileReader;
        public LoginPage _LoginPage;

        public Quote_LocationsPage(
            ScenarioContext scenarioContext,
            LoginPage loginPage,
            CommonXpath commonXpath,
            IFileReader fileReader)
            : base(scenarioContext)
        {
            _ScenarioContext = scenarioContext;
            _LoginPage = loginPage;
            _CommonXpath = commonXpath;
            _FileReader = fileReader;
        }

        #region Xpath
        public string Locations_Link { get; set; } = "//a[normalize-space()='Locations']";
        public string AddLocation_Link { get; set; } = "//a[normalize-space()='Add location']";
        public string LocationStreetAddress_Input { get; set; } = "//input[contains(@id,'loc_streetAddress')]";
        public string LocationCity_Input { get; set; } = "//input[contains(@id,'loc_city')]";
        public string LocationZipCode_Input { get; set; } = "//input[contains(@id,'loc_zipCode')]";
        public string LocationPbrcClassUW_Input { get; set; } = "//input[contains(@id,'fld_loc_pbrcclassUW_1_1')]";
        public string LocationPbrcClassUWDesc_Textarea { get; set; } = "//textarea[contains(@id,'fld_loc_pbrcclassUWDesc_1_1')]";
        public string LocationCategoriesDesc_Textarea { get; set; } = "//textarea[contains(@id,'fld_loc_categoriesdesc_1_1')]";
        public string LocationFullTime_Input { get; set; } = "//input[contains(@id,'fld_loc_fulltime_1_1')]";
        public string LocationPartTime_Input { get; set; } = "//input[contains(@id,'fld_loc_parttime_1_1')]";
        public string LocationPayroll_Input { get; set; } = "//input[contains(@id,'fld_loc_payroll_1_1')]";

        public string QuoteTypeE_DropDown { get; set; } = "//select[@id='fld_quoteTypeE']";
        public string QuoteDescriptionE_Input { get; set; } = "//input[@id='fld_quoteDescriptionE']";
        public string EffectiveDateE_Input { get; set; } = "//input[@id='fld_effectivedateE']";
        public string BookOfBusinessE_Input { get; set; } = "//input[@id='fld_bookofbusinessE_text']";
        public string EinE_Input { get; set; } = "//input[@id='fld_einE']";
        #endregion

        public async Task WorkersCompLocationsDataFillAsync(string profileKey)
        {
            if (_FileReader == null)
            {
                throw new InvalidOperationException("FileReader is not available.");
            }

            var filePath = "QuoteLocationPage\\QuoteLocationPage.json";

            // Scroll and click location tab and add location
            await Button.ScrollIntoViewAsync(Locations_Link, true, 1);
            await TextLink.ClickTextLinkAsync(Locations_Link, true, 1);

            await Button.ScrollIntoViewAsync(AddLocation_Link, true, 1);
            await TextLink.ClickTextLinkAsync(AddLocation_Link, true, 1);

            // Fill location fields using JSON values
            var streetAddress = _FileReader.GetOptionalValue(filePath, $"{profileKey}.LocationsStreetAddress");
            if (!string.IsNullOrEmpty(streetAddress))
            {
                await InputField.SetInputFieldAsync(LocationStreetAddress_Input, streetAddress, true, 1);
            }

            var city = _FileReader.GetOptionalValue(filePath, $"{profileKey}.LocationsCity");
            if (!string.IsNullOrEmpty(city))
            {
                await InputField.SetInputFieldAsync(LocationCity_Input, city, true, 1);
            }

            var zip = _FileReader.GetOptionalValue(filePath, $"{profileKey}.LocationsZipCode");
            if (!string.IsNullOrEmpty(zip))
            {
                await InputField.SetInputFieldAsync(LocationZipCode_Input, zip, true, 1);
            }

            var pbrcClassUW = _FileReader.GetOptionalValue(filePath, $"{profileKey}.LocationsPbrcClassUW");
            if (!string.IsNullOrEmpty(pbrcClassUW))
            {
                await InputField.SetInputFieldAsync(LocationPbrcClassUW_Input, pbrcClassUW, true, 1);
            }

            // Playwright: .press() to send tab if needed (commented, usually not required)
             await page.PressAsync(LocationPbrcClassUW_Input, "Tab");

            var pbrcClassUWDesc = _FileReader.GetOptionalValue(filePath, $"{profileKey}.LocationsPbrcClassUWDesc");
            if (!string.IsNullOrEmpty(pbrcClassUWDesc))
            {
                await InputField.SetTextAreaInputFieldAsync(LocationPbrcClassUWDesc_Textarea, pbrcClassUWDesc, true, 1);
            }

            var categoriesDesc = _FileReader.GetOptionalValue(filePath, $"{profileKey}.LocationsCategoriesDesc");
            if (!string.IsNullOrEmpty(categoriesDesc))
            {
                await InputField.SetTextAreaInputFieldAsync(LocationCategoriesDesc_Textarea, categoriesDesc, true, 1);
            }

            var fullTime = _FileReader.GetOptionalValue(filePath, $"{profileKey}.LocationsFullTime");
            if (!string.IsNullOrEmpty(fullTime))
            {
                await InputField.SetInputFieldAsync(LocationFullTime_Input, fullTime, true, 1);
            }

            var partTime = _FileReader.GetOptionalValue(filePath, $"{profileKey}.LocationsPartTime");
            if (!string.IsNullOrEmpty(partTime))
            {
                await InputField.SetInputFieldAsync(LocationPartTime_Input, partTime, true, 1);
            }

            var payroll = _FileReader.GetOptionalValue(filePath, $"{profileKey}.LocationsPayroll");
            if (!string.IsNullOrEmpty(payroll))
            {
                await InputField.SetInputFieldAsync(LocationPayroll_Input, payroll, true, 1);
            }
        }
    }
}
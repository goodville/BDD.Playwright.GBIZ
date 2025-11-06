using BDD.Playwright.GBIZ.Pages.CommonPage;
using Microsoft.Playwright;
using Reqnroll;

namespace BDD.Playwright.Origami.Pages.AgentPages
{
    public class Quote_LocationsPage : BasePage
    {
        public Quote_LocationsPage(ScenarioContext scenarioContext) : base(scenarioContext) { }

        #region Xpath
        public string Locations_Link { get; set; } = "//a[normalize-space()='Locations']";
        public string Addlocation_Link { get; set; } = "//a[normalize-space()='Add location']";
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

        #region Workers Compensation Locations Fill
        public async Task WorkersCompLocationsDatafillAsync(dynamic commonFunctions)
        {
            await page.WaitForLoadStateAsync(LoadState.DOMContentLoaded);
            await TextLink.ClickTextLinkAsync(Locations_Link, true, 1);
            await TextLink.ClickTextLinkAsync(Addlocation_Link, true, 1);
            await InputField.SetInputFieldAsync(LocationStreetAddress_Input, commonFunctions.LocationsStreetAddress_LabelAndValue.Item2, true, 1);
            await InputField.SetInputFieldAsync(LocationCity_Input, commonFunctions.LocationsCity_LabelAndValue.Item2, true, 1);
            await InputField.SetInputFieldAsync(LocationZipCode_Input, commonFunctions.LocationsZipCode_LabelAndValue.Item2, true, 1);
            await InputField.SetInputFieldAsync(LocationPbrcClassUW_Input, commonFunctions.LocationsPbrcClassUW_LabelAndValue.Item2, true, 1);
            // Simulate Tab key press after entering PBRC Class UW
            var pbrcClassUWLocator = page.Locator(LocationPbrcClassUW_Input);
            await pbrcClassUWLocator.PressAsync("Tab");
            await InputField.SetTextAreaInputFieldAsync(LocationPbrcClassUWDesc_Textarea, commonFunctions.LocationsPbrcClassUWDesc_LabelAndValue.Item2, true, 1);
            await InputField.SetTextAreaInputFieldAsync(LocationCategoriesDesc_Textarea, commonFunctions.LocationsCategoriesDesc_LabelAndValue.Item2, true, 1);
            await InputField.SetInputFieldAsync(LocationFullTime_Input, commonFunctions.LocationsFullTime_LabelAndValue.Item2, true, 1);
            await InputField.SetInputFieldAsync(LocationPartTime_Input, commonFunctions.LocationsPartTime_LabelAndValue.Item2, true, 1);
            await InputField.SetInputFieldAsync(LocationPayroll_Input, commonFunctions.LocationsPayroll_LabelAndValue.Item2, true, 1);
            await page.WaitForLoadStateAsync(LoadState.DOMContentLoaded);
        }
        #endregion
    }
}
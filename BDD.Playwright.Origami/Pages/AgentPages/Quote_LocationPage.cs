using BDD.Playwright.GBIZ.PageElements;
using BDD.Playwright.GBIZ.Pages.CommonPage;
using Microsoft.Playwright;
using Reqnroll;

namespace BDD.Playwright.Origami.Pages.AgentPages
{
    public class Quote_LocationPage : BasePage
    {
        public Quote_LocationPage(ScenarioContext scenarioContext) : base(scenarioContext) { }

        #region Xpath
        public string Addlocation { get; set; } = "//a[text()='Add Location']";
        public string Protection_Drp { get; set; } = "//select[@name='loc_protection_1' and @id='fld_loc_protection_1']";
        public string StreetAddress_input { get; set; } = "//input[@name='loc_streetAddress_1']";
        public string City_input { get; set; } = "//input[@id='fld_loc_city_1']";
        public string Zipcode_input { get; set; } = "//input[@id='fld_loc_zipCode_1']";
        public string Milestofire_input { get; set; } = "//input[@id='fld_loc_milesToFireDept_1']";
        public string RespondingFireDept_Input { get; set; } = "//input[@id='fld_loc_respondingFireDept_1']";
        public string Loc_PassagewaysLit_Radio { get; set; } = "//input[contains(@id,'loc_passagewaysLit_1')  and @value='{0}']";
        public string Loc_PorchHandrails_Radio { get; set; } = "//input[contains(@id,'loc_porchHandrails_1')  and @value='{0}']";
        public string Loc_StairwaysHandrails_Radio { get; set; } = "//input[contains(@id,'loc_stairwaysHandrails_1')  and @value='{0}']";
        public string Loc_RiInsuredWithin70MiOfLocation_1_Radio { get; set; } = "//input[contains(@id,'loc_riInsuredWithin70MiOfLocation_1')  and @value='{0}']";
        public string Loc_Thereatrampoline_Radio { get; set; } = "//input[contains(@id,'loc_trampolineOrPool_1')  and @value='{0}']";
        public string Continue_btn { get; set; } = "//button[contains(text(),'Continue')]";
        #endregion

        public async Task LocationDatafillAsync(dynamic commonFunctions)
        {
            await page.WaitForLoadStateAsync(LoadState.DOMContentLoaded);
            await Button.ClickButtonAsync(Addlocation, ActionType.Click, true, 1);
            await page.WaitForTimeoutAsync(3000);
            await DropDown.SelectDropDownAsync(Protection_Drp, commonFunctions.LocationProtection_LabelAndValue.Item2, true, 1);
            await InputField.SetTextAreaInputFieldAsync(StreetAddress_input, commonFunctions.LocationStreetAddress_LabelAndValue.Item2, true, 1);
            await InputField.SetTextAreaInputFieldAsync(City_input, commonFunctions.LocationCity_LabelAndValue.Item2, true, 1);
            await InputField.SetTextAreaInputFieldAsync(Zipcode_input, commonFunctions.LocationZipCode_LabelAndValue.Item2, true, 1);
            await InputField.SetTextAreaInputFieldAsync(Milestofire_input, commonFunctions.LocationMiles_LabelAndValue.Item2, true, 1);
            await InputField.SetTextAreaInputFieldAsync(RespondingFireDept_Input, commonFunctions.LocationRespondingFireDepartment_LabelAndValue.Item2, true, 1);
            if (!string.IsNullOrEmpty(commonFunctions.Locationtrampoline_LabelAndValue.Item2))
            {
                var trampolineRadio = string.Format(Loc_Thereatrampoline_Radio, commonFunctions.Locationtrampoline_LabelAndValue.Item2);
                await RadioButton.SelectRadioButtonAsync(trampolineRadio, commonFunctions.Locationtrampoline_LabelAndValue.Item2, true, 1);
            }

            if (!string.IsNullOrEmpty(commonFunctions.LocationArepassagewayswelllighted_LabelAndValue.Item2))
            {
                var passagewaysLitRadio = string.Format(Loc_PassagewaysLit_Radio, commonFunctions.LocationArepassagewayswelllighted_LabelAndValue.Item2);
                await RadioButton.SelectRadioButtonAsync(passagewaysLitRadio, commonFunctions.LocationArepassagewayswelllighted_LabelAndValue.Item2, true, 1);
            }

            if (!string.IsNullOrEmpty(commonFunctions.LocationAreallporches_LabelAndValue.Item2))
            {
                var porchHandrailsRadio = string.Format(Loc_PorchHandrails_Radio, commonFunctions.LocationAreallporches_LabelAndValue.Item2);
                await RadioButton.SelectRadioButtonAsync(porchHandrailsRadio, commonFunctions.LocationAreallporches_LabelAndValue.Item2, true, 1);
            }

            if (!string.IsNullOrEmpty(commonFunctions.LocationAreallinterior_LabelAndValue.Item2))
            {
                var stairwaysHandrailsRadio = string.Format(Loc_StairwaysHandrails_Radio, commonFunctions.LocationAreallinterior_LabelAndValue.Item2);
                await RadioButton.SelectRadioButtonAsync(stairwaysHandrailsRadio, commonFunctions.LocationAreallinterior_LabelAndValue.Item2, true, 1);
            }

            if (!string.IsNullOrEmpty(commonFunctions.LocationDoestheinsuredlivewithin70miles_LabelAndValue.Item2))
            {
                var insuredWithin70MiRadio = string.Format(Loc_RiInsuredWithin70MiOfLocation_1_Radio, commonFunctions.LocationDoestheinsuredlivewithin70miles_LabelAndValue.Item2);
                await RadioButton.SelectRadioButtonAsync(insuredWithin70MiRadio, commonFunctions.LocationDoestheinsuredlivewithin70miles_LabelAndValue.Item2, true, 1);
            }

            await Button.ClickButtonAsync(Continue_btn, ActionType.Click, true, 1);
            await page.WaitForLoadStateAsync(LoadState.DOMContentLoaded);
        }
    }
}

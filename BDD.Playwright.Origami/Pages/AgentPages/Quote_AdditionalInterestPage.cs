using BDD.Playwright.GBIZ.PageElements;
using BDD.Playwright.GBIZ.Pages.CommonPage;
using Microsoft.Playwright;
using Reqnroll;

namespace BDD.Playwright.Origami.Pages.AgentPages
{
    public class Quote_AdditionalInterestPage : BasePage
    {
        public Quote_AdditionalInterestPage(ScenarioContext scenarioContext) : base(scenarioContext) { }

        #region Xpath
        public string MortgageeName { get; set; } = "//input[@name='mort_name1_1']";
        public string MortgageeAddress { get; set; } = "//input[@name='mort_address1_1']";
        public string MortgageeCity { get; set; } = "//input[@name='mort_city_1']";
        public string MortgageeState { get; set; } = "//select[contains(@name,'mort_state_1')]";
        public string MortgageeZip { get; set; } = "//input[@name='mort_zip_1']";
        public string MortgageeRelateDwelling { get; set; } = "//div[@class='text11 nowrap']";
        public string MortgageeDwelling_Drp { get; set; } = "//select[@name='mortgageeRelateBuildings_selectLocation']";
        public string MortgageeRelate_btn { get; set; } = "//span[@class='ui-button-text' and text()='Relate Dwelling']";
        public string AdditionalInsured { get; set; } = "//div[@class='tabText']//div[@id='subtab_2']";
        public string AdditionalInsuredName { get; set; } = "//input[@name='ai_name1_1']";
        public string AdditionalInsuredAddress { get; set; } = "//input[@name='ai_address1_1']";
        public string AdditionalInsuredCity { get; set; } = "//input[@name='ai_city_1']";
        public string AdditionalInsuredState { get; set; } = "//select[contains(@name,'ai_state_1')]";
        public string AdditionalInsuredZip { get; set; } = "//input[@name='ai_zip_1']";
        public string AdditionalInsuredInterest { get; set; } = "//select[@name='ai_interest_1']";
        public string AdditionalInsuredDescription { get; set; } = "//input[@name='ai_interestOtherDesc_1']";
        public string AdditionalRelateDwelling { get; set; } = "//a[text()='Relate Dwelling']";
        public string AdditionalRelateDwelling_btn { get; set; } = "(//span[@class='ui-button-text' and text()='Relate Dwelling'])[2]";
        #endregion

        public async Task AdditionalInterestDataFillAsync(
            string mortgageeName,
            string mortgageeAddress,
            string mortgageeCity,
            string mortgageeState,
            string mortgageeZip,
            string mortgageeDwellingValue,
            string insuredName,
            string insuredAddress,
            string insuredCity,
            string insuredState,
            string insuredZip,
            string insuredInterest,
            string insuredDescription,
            string additionalDwellingValue)
        {
            await page.WaitForLoadStateAsync(LoadState.DOMContentLoaded);
            await InputField.SetTextAreaInputFieldAsync(MortgageeName, mortgageeName, true, 1);
            await InputField.SetTextAreaInputFieldAsync(MortgageeAddress, mortgageeAddress, true, 1);
            await InputField.SetTextAreaInputFieldAsync(MortgageeCity, mortgageeCity, true, 1);
            await DropDown.SelectDropDownAsync(MortgageeState, mortgageeState, true, 1);
            await InputField.SetTextAreaInputFieldAsync(MortgageeZip, mortgageeZip, true, 1);
            await Button.ClickButtonAsync(MortgageeRelateDwelling, ActionType.Click, true, 1);
            await page.WaitForTimeoutAsync(2000);
            await DropDown.SelectDropDownAsync(MortgageeDwelling_Drp, mortgageeDwellingValue, true, 1);
            await Button.ClickButtonAsync(MortgageeRelate_btn, ActionType.Click, true, 1);
            await page.WaitForTimeoutAsync(2000);
            await page.EvaluateAsync("window.scrollTo(0,0)");
            await page.WaitForTimeoutAsync(2000);
            await page.EvaluateAsync("window.scrollTo(0,0)");
            await page.WaitForTimeoutAsync(2000);
            await page.EvaluateAsync("window.scrollTo(0,0)");
            await page.WaitForTimeoutAsync(4000);
            await Button.ClickButtonAsync(AdditionalInsured, ActionType.Click, true, 1);
            await page.WaitForTimeoutAsync(4000);
            await InputField.SetTextAreaInputFieldAsync(AdditionalInsuredName, insuredName, true, 1);
            await InputField.SetTextAreaInputFieldAsync(AdditionalInsuredAddress, insuredAddress, true, 1);
            await InputField.SetTextAreaInputFieldAsync(AdditionalInsuredCity, insuredCity, true, 1);
            await DropDown.SelectDropDownAsync(AdditionalInsuredState, insuredState, true, 1);
            await InputField.SetTextAreaInputFieldAsync(AdditionalInsuredZip, insuredZip, true, 1);
            await DropDown.SelectDropDownAsync(AdditionalInsuredInterest, insuredInterest, true, 1);
            await InputField.SetTextAreaInputFieldAsync(AdditionalInsuredDescription, insuredDescription, true, 1);
            await Button.ClickButtonAsync(AdditionalRelateDwelling, ActionType.Click, true, 1);
            await page.WaitForTimeoutAsync(2000);
            await DropDown.SelectDropDownAsync(MortgageeDwelling_Drp, additionalDwellingValue, true, 2);
            await Button.ClickButtonAsync(AdditionalRelateDwelling_btn, ActionType.Click, true, 1);
            await page.WaitForTimeoutAsync(2000);
        }
    }
}

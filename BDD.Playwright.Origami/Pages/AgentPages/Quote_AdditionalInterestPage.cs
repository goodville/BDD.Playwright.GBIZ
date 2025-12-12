using BDD.Playwright.Core.Interfaces;
using BDD.Playwright.GBIZ.PageElements;
using BDD.Playwright.GBIZ.Pages.CommonPage;
using BDD.Playwright.GBIZ.Pages.GlobalPages;
using BDD.Playwright.GBIZ.Pages.XpathProperties;
using Reqnroll;

namespace GoodVille.GBIZ.Reqnroll.Automation.Pages.AgentPages
{
    public class Quote_AdditionalInterestPage : BasePage
    {
        private readonly ScenarioContext _scenarioContext;
        public FeatureContext _featureContext;
        public CommonXpath _commonXpath;
        public LoginPage _loginPage;
        private readonly IFileReader _fileReader;

        public Quote_AdditionalInterestPage(ScenarioContext scenarioContext, LoginPage loginPage, CommonXpath commonXpath, IFileReader fileReader)
            : base(scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _loginPage = loginPage;
            _commonXpath = commonXpath;
            _fileReader = fileReader;
        }

        #region Xpath
        public string MortgageeName { get; set; } = "//input[@name='mort_name1_1']";
        public string MortgageeAddress { get; set; } = "//input[@name='mort_address1_1']";
        public string MortgageeCity { get; set; } = "//input[@name='mort_city_1']";
        public string MortgageeState { get; set; } = "//select[contains(@name,'mort_state_1')]";
        public string MortgageeZip { get; set; } = "//input[@name='mort_zip_1']";
        public string MortgageeRelateDwelling { get; set; } = "//div[@class='text11 nowrap']";
        public string MortgageeDwelling_Drp { get; set; } = "//select[@name='mortgageeRelateBuildings_selectLocation']";
        
        public string MortgageeDwelling_Drp1 { get; set; } = "(//select[@name='mortgageeRelateBuildings_selectLocation'])[2]";
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

        public async Task AdditionalInterestDataFillAsync(string profileKey)
        {
            var filePath = "QuoteAdditionalInterestPage\\QuoteAdditionalInterestPage.json";

            // Mortgagee Section
            var mortgageeNameValue = _fileReader.GetOptionalValue(filePath, $"{profileKey}.MortgageeName");
            if (!string.IsNullOrEmpty(mortgageeNameValue))
            {
                await InputField.SetTextAreaInputFieldAsync(MortgageeName, mortgageeNameValue, true, 1);
            }

            var mortgageeAddressValue = _fileReader.GetOptionalValue(filePath, $"{profileKey}.MortgageeAddress");
            if (!string.IsNullOrEmpty(mortgageeAddressValue))
            {
                await InputField.SetTextAreaInputFieldAsync(MortgageeAddress, mortgageeAddressValue, true, 1);
            }

            var mortgageeCityValue = _fileReader.GetOptionalValue(filePath, $"{profileKey}.MortgageeCity");
            if (!string.IsNullOrEmpty(mortgageeCityValue))
            {
                await InputField.SetTextAreaInputFieldAsync(MortgageeCity, mortgageeCityValue, true, 1);
            }

            var mortgageeStateValue = _fileReader.GetOptionalValue(filePath, $"{profileKey}.MortgageeState");
            if (!string.IsNullOrEmpty(mortgageeStateValue))
            {
                await DropDown.SelectDropDownAsync(MortgageeState, mortgageeStateValue, true, 1);
            }

            var mortgageeZipValue = _fileReader.GetOptionalValue(filePath, $"{profileKey}.MortgageeZip");
            if (!string.IsNullOrEmpty(mortgageeZipValue))
            {
                await InputField.SetTextAreaInputFieldAsync(MortgageeZip, mortgageeZipValue, true, 1);
            }

            // Relate Dwelling
            await Button.ClickButtonAsync(MortgageeRelateDwelling, ActionType.Click, true, 1);
            var mortgageeDwellingValue = _fileReader.GetOptionalValue(filePath, $"{profileKey}.MortgageeDwelling");
            await DropDown.SelectDropDownAsync(MortgageeDwelling_Drp, mortgageeDwellingValue, true, 1);

            await Task.Delay(2000);
            await Button.ClickButtonAsync(MortgageeRelate_btn, ActionType.Click, true, 1);

           // await _commonFunctions.ScrollUpAsync();
           // await _commonFunctions.ScrollUpAsync();
            await Button.ClickButtonAsync(AdditionalInsured, ActionType.Click, true, 1);

            var addInsuredNameValue = _fileReader.GetOptionalValue(filePath, $"{profileKey}.InsuredName");
            if (!string.IsNullOrEmpty(addInsuredNameValue))
            {
                await InputField.SetTextAreaInputFieldAsync(AdditionalInsuredName, addInsuredNameValue, true, 1);
            }

            var addInsuredAddressValue = _fileReader.GetOptionalValue(filePath, $"{profileKey}.InsuredAddress");
            if (!string.IsNullOrEmpty(addInsuredAddressValue))
            {
                await InputField.SetTextAreaInputFieldAsync(AdditionalInsuredAddress, addInsuredAddressValue, true, 1);
            }

            var addInsuredCityValue = _fileReader.GetOptionalValue(filePath, $"{profileKey}.InsuredCity");
            if (!string.IsNullOrEmpty(addInsuredCityValue))
            {
                await InputField.SetTextAreaInputFieldAsync(AdditionalInsuredCity, addInsuredCityValue, true, 1);
            }

            var addInsuredStateValue = _fileReader.GetOptionalValue(filePath, $"{profileKey}.InsuredState");
            if (!string.IsNullOrEmpty(addInsuredStateValue))
            {
                await DropDown.SelectDropDownAsync(AdditionalInsuredState, addInsuredStateValue, true, 1);
            }

            var addInsuredZipValue = _fileReader.GetOptionalValue(filePath, $"{profileKey}.InsuredZip");
            if (!string.IsNullOrEmpty(addInsuredZipValue))
            {
                await InputField.SetTextAreaInputFieldAsync(AdditionalInsuredZip, addInsuredZipValue, true, 1);
            }

            var interestValue = _fileReader.GetOptionalValue(filePath, $"{profileKey}.InsuredInterest");
            if (!string.IsNullOrEmpty(interestValue))
            {
                await DropDown.SelectDropDownAsync(AdditionalInsuredInterest, interestValue, true, 1);
            }

            var descriptionValue = _fileReader.GetOptionalValue(filePath, $"{profileKey}.InsuredDescription");
            if (!string.IsNullOrEmpty(descriptionValue))
            {
                await InputField.SetTextAreaInputFieldAsync(AdditionalInsuredDescription, descriptionValue, true, 1);
            }

            await Button.ClickButtonAsync(AdditionalRelateDwelling, ActionType.Click, true, 1);
            var mortgageeDwellingValue1 = _fileReader.GetOptionalValue(filePath, $"{profileKey}.MortgageeDwelling");
            await DropDown.SelectDropDownAsync(MortgageeDwelling_Drp1, mortgageeDwellingValue1, true, 1);
            await Task.Delay(3000);

            await Button.ClickButtonAsync(AdditionalRelateDwelling_btn, ActionType.Click, true, 1);

        }
    }
}
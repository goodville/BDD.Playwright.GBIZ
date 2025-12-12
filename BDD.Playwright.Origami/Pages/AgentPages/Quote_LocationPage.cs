using BDD.Playwright.Core.Interfaces;
using BDD.Playwright.GBIZ.PageElements;
using BDD.Playwright.GBIZ.Pages.CommonPage;
using BDD.Playwright.GBIZ.Pages.GlobalPages;
using BDD.Playwright.GBIZ.Pages.XpathProperties;
using Microsoft.Playwright;
using Reqnroll;

namespace BDD.Playwright.GBIZ.Pages.AgentPages
{
    public class Quote_LocationPage : BasePage
    {
        private readonly ScenarioContext _ScenarioContext;
        public FeatureContext _FeatureContext;
        public CommonXpath _CommonXpath;
        private readonly IFileReader _FileReader;
        public LoginPage _LoginPage;

        public Quote_LocationPage(
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
        public string AddLocation { get; set; } = "//a[text()='Add Location']";
        public string Protection_Drp { get; set; } = "//select[@name='loc_protection_1' and @id='fld_loc_protection_1']";
        public string StreetAddress_Input { get; set; } = "//input[@name='loc_streetAddress_1']";
        public string City_Input { get; set; } = "//input[@id='fld_loc_city_1']";
        public string ZipCode_Input { get; set; } = "//input[@id='fld_loc_zipCode_1']";
        public string MilesToFire_Input { get; set; } = "//input[@id='fld_loc_milesToFireDept_1']";
        public string RespondingFireDept_Input { get; set; } = "//input[@id='fld_loc_respondingFireDept_1']";
        public string IsThereATrampoline_Radio { get; set; } = "//input[contains(@id,'loc_trampolineOrPool_1')  and @value='{0}']";
        public string PassagewaysLit_Radio { get; set; } = "//input[contains(@id,'loc_passagewaysLit_1')  and @value='{0}']";
        public string PorchHandrails_Radio { get; set; } = "//input[contains(@id,'loc_porchHandrails_1')  and @value='{0}']";
        public string StairwaysHandrails_Radio { get; set; } = "//input[contains(@id,'loc_stairwaysHandrails_1')  and @value='{0}']";
        public string InsuredWithin70MiOfLocation_Radio { get; set; } = "//input[contains(@id,'loc_riInsuredWithin70MiOfLocation_1')  and @value='{0}']";
        public string Continue_Btn { get; set; } = "//button[@id = 'buttonlocations_submitbutton']";
        #endregion

        public async Task LocationDataFillAsync(string profileKey)
        {
            if (_FileReader == null)
            {
                throw new InvalidOperationException("FileReader is not available.");
            }

            var filePath = "QuoteLocationPage\\QuoteLocationPage.json";
            await Button.ClickButtonAsync(AddLocation, ActionType.Click, true, 1);

            await DropDown.SelectDropDownAsync(Protection_Drp, _FileReader.GetOptionalValue(filePath, $"{profileKey}.Protection"), true, 1);
            await InputField.SetTextAreaInputFieldAsync(StreetAddress_Input, _FileReader.GetOptionalValue(filePath, $"{profileKey}.StreetAddress"), true, 1);
            await InputField.SetTextAreaInputFieldAsync(City_Input, _FileReader.GetOptionalValue(filePath, $"{profileKey}.City"), true, 1);
            await InputField.SetTextAreaInputFieldAsync(ZipCode_Input, _FileReader.GetOptionalValue(filePath, $"{profileKey}.ZipCode"), true, 1);
            await InputField.SetTextAreaInputFieldAsync(MilesToFire_Input, _FileReader.GetOptionalValue(filePath, $"{profileKey}.Miles"), true, 1);
            await InputField.SetTextAreaInputFieldAsync(RespondingFireDept_Input, _FileReader.GetOptionalValue(filePath, $"{profileKey}.RespondingFireDepartment"), true, 1);
            await Task.Delay(3000);

            var trampoline = _FileReader.GetOptionalValue(filePath, $"{profileKey}.trampoline");
            if (!string.IsNullOrEmpty(trampoline))
            {
                await RadioButton.SelectRadioButtonAsync(string.Format(IsThereATrampoline_Radio, trampoline), "value", true,1);
            }

            var passagewaysLit = _FileReader.GetOptionalValue(filePath, $"{profileKey}.Arepassagewayswelllighted");
            if (!string.IsNullOrEmpty(passagewaysLit))
            {
                await RadioButton.SelectRadioButtonAsync(string.Format(PassagewaysLit_Radio, passagewaysLit), "value", true, 1);
            }

            var porchHandrails = _FileReader.GetOptionalValue(filePath, $"{profileKey}.Areallporches");
            if (!string.IsNullOrEmpty(porchHandrails))
            {
                await RadioButton.SelectRadioButtonAsync(string.Format(PorchHandrails_Radio, porchHandrails), "value", true, 1);
            }

            var stairwaysHandrails = _FileReader.GetOptionalValue(filePath, $"{profileKey}.Areallinterior");
            if (!string.IsNullOrEmpty(stairwaysHandrails))
            {
                await RadioButton.SelectRadioButtonAsync(string.Format(StairwaysHandrails_Radio, stairwaysHandrails), "value", true, 1);
            }

            var insuredWithin70Mi = _FileReader.GetOptionalValue(filePath, $"{profileKey}.Doestheinsuredlivewithin70miles");
            if (!string.IsNullOrEmpty(insuredWithin70Mi))
            {
                await RadioButton.SelectRadioButtonAsync(string.Format(InsuredWithin70MiOfLocation_Radio, insuredWithin70Mi), "value", true, 1);
            }

            await Button.ClickButtonAsync(Continue_Btn, ActionType.Click, true, 1);
        }
    }
}

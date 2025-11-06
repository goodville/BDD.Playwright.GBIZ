using BDD.Playwright.Core.Interfaces;
using BDD.Playwright.GBIZ.PageElements;
using BDD.Playwright.GBIZ.Pages.CommonPage;
using Reqnroll;

namespace BDD.Playwright.GBIZ.Pages.AgentPages
{
    public class Quote_VehiclesPage : BasePage
    {
        private readonly IReqnrollOutputHelper _ReqnrollLogger;
        private readonly FeatureContext _featureContext;
        private readonly ScenarioContext _scenarioContext;
        private readonly IFileReader _fileReader;

        // Constructor
        public Quote_VehiclesPage(ScenarioContext scenarioContext, IFileReader fileReader) : base(scenarioContext)
        {
            _fileReader = fileReader;
            // _baseElement = new BaseElement(scenarioContext);

        }
        #region Vehicle XPaths
        public string Vehicles_Link => "//a[normalize-space()='Vehicles']";
        public string VinNumber_Input => "//input[@id='fld_vh_vinNumber_1']";
        public string Vinsave_btn => "//button[@id='buttonvh_vehicleSetButtonVIN_1']";
        public string VehicleType_DropDown => "//select[@id='fld_vh_vehicleType_1']";
        public string OverrideSymbolComp_Input => "//input[@id='fld_vh_overrideSymbolComp_1']";
        public string OverrideSymbolColl_Input => "//input[@id='fld_vh_overrideSymbolColl_1']";
        public string VehicleUse_DropDown => "//select[@id='fld_vh_vehicleUse_1']";
        public string AnnualMileageOverride_Radio => "//input[contains(@id,'vh_annualMileageOverride_1') and @value='{0}']";
        public string TitlesNamedInsured_Radio => "//input[contains(@id,'vh_titlesNamedInsured_1') and @value='{0}']";
        public string ReconstructedSalvageTitle_Radio => "//input[contains(@id,'vh_reconstructedSalvageTitle_1') and @value='{0}']";
        public string AssignDriverOverride_DropDown => "//select[@id='fld_vh_assignDriverOveride_1']";
        public string IsGaragedAddress_Radio => "//input[contains(@id,'vh_isGaragedAddress_1') and @value='{0}']";
        public string RegisteredState_DropDown => "//select[@id='fld_vh_registeredState_1']";
        public string PassiveRestraints_DropDown => "//select[@id='fld_vh_passiveRestraints_1']";
        public string AntiTheftDevices_DropDown => "//select[@id='fld_vh_antiTheftDevices_1']";
        public string FourWheelALB_Radio => "//input[contains(@id,'vh_fourWheelALB_1') and @value='{0}']";

        public string PAvehicleContinue_btn => "//button[contains(text(),'Continue')]";
        #endregion
        public async Task AddVehicleAsync(string profileKey)
        {
            if (_fileReader == null)
            {
                throw new InvalidOperationException("FileReader is not available. Use constructor with IFileReader parameter.");
            }

            try
            {
                logger.WriteLine($"Starting to fill Quote Vehicles information using profile: {profileKey}");

                var filePath = "QuoteVehicles\\QuoteVehiclesData.json";

                // Get values from JSON - Quote Details
                var vinNumber_Input = _fileReader.GetOptionalValue(filePath, $"{profileKey}.VinNumber_Input");
                var vehicleType_DropDown = _fileReader.GetOptionalValue(filePath, $"{profileKey}.VehicleType_DropDown");
                var overrideSymbolComp_Input = _fileReader.GetOptionalValue(filePath, $"{profileKey}.OverrideSymbolComp_Input");
                var overrideSymbolColl_Input = _fileReader.GetOptionalValue(filePath, $"{profileKey}.OverrideSymbolColl_Input");
                var vehicleUse_DropDown = _fileReader.GetOptionalValue(filePath, $"{profileKey}.VehicleUse_DropDown");
                var annualMileageOverride_Radio = _fileReader.GetOptionalValue(filePath, $"{profileKey}.AnnualMileageOverride_Radio");
                var titlesNamedInsured_Radio = _fileReader.GetOptionalValue(filePath, $"{profileKey}.TitlesNamedInsured_Radio");
                var reconstructedSalvageTitle_Radio = _fileReader.GetOptionalValue(filePath, $"{profileKey}.ReconstructedSalvageTitle_Radio");
                var assignDriverOverride_DropDown = _fileReader.GetOptionalValue(filePath, $"{profileKey}.AssignDriverOverride_DropDown");
                var isGaragedAddress_Radio = _fileReader.GetOptionalValue(filePath, $"{profileKey}.IsGaragedAddress_Radio");

                Thread.Sleep(3000);

                //commonFunctions.ScrollUptoElement(Driver.FindElement(By.XPath(Vehicles_Link)));
                //TextLink.ClickTextLink(Vehicles_Link, true, 1);
                await InputField.SetTextAreaInputFieldAsync(VinNumber_Input, vinNumber_Input, true, 1);
                await Button.ClickButtonAsync(Vinsave_btn, ActionType.Click, true, 1);
                Thread.Sleep(1000);
                await DropDown.SelectDropDownAsync(VehicleType_DropDown, vehicleType_DropDown, true, 1);
                await InputField.SetTextAreaInputFieldAsync(OverrideSymbolComp_Input,overrideSymbolComp_Input, true, 1);
                await InputField.SetTextAreaInputFieldAsync(OverrideSymbolColl_Input, overrideSymbolColl_Input, true, 1);
                await DropDown.SelectDropDownAsync(VehicleUse_DropDown, vehicleUse_DropDown, true, 1);
                await RadioButton.SelectRadioButtonAsync(AnnualMileageOverride_Radio, annualMileageOverride_Radio, true, 1);
                await RadioButton.SelectRadioButtonAsync(TitlesNamedInsured_Radio, titlesNamedInsured_Radio, true, 1);
                await RadioButton.SelectRadioButtonAsync(ReconstructedSalvageTitle_Radio, reconstructedSalvageTitle_Radio, true, 1);
                await DropDown.SelectDropDownAsync(AssignDriverOverride_DropDown, assignDriverOverride_DropDown, true, 1);
                await RadioButton.SelectRadioButtonAsync(IsGaragedAddress_Radio, isGaragedAddress_Radio, true, 1);
                /* DropDown.SelectDropDown(RegisteredState_DropDown, commonFunctions.RegisteredState_LabelAndValue.Item2, true, 1);
                 DropDown.SelectDropDown(PassiveRestraints_DropDown, commonFunctions.PassiveRestraints_LabelAndValue.Item2, true, 1);
                 DropDown.SelectDropDown(AntiTheftDevices_DropDown, commonFunctions.AntiTheftDevices_LabelAndValue.Item2, true, 1);
                 RadioButton.SelectRadioButton(string.Format(FourWheelALB_Radio, commonFunctions.FourWheelALB_LabelAndValue.Item2), true, 1);*/
                await Button.ClickButtonAsync(PAvehicleContinue_btn, ActionType.Click, true, 1);

                logger.WriteLine($"Retrieved Quote Vehicles data for: {vinNumber_Input} {isGaragedAddress_Radio}");

                // Note: Form filling implementation would go here using the same pattern as BasicInformationPage
                // with the page elements (Button, InputField, DropDown, etc.) once they are properly resolved

                logger.WriteLine($"Successfully filled Quote Vehicles information using profile: {profileKey}");
                logger.WriteLine("Quote Vehicles Page Details Entered Successfully from JSON Data");
            }
            catch (Exception ex)
            {
                logger.WriteLine($"Error filling Quote Vehicles data: {ex.Message}");
                throw new Exception($"Failed to fill Quote Vehicles data using profile '{profileKey}': {ex.Message}", ex);
            }
        }
    }
}


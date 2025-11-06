using BDD.Playwright.Core.Interfaces;
using BDD.Playwright.GBIZ.PageElements;
using BDD.Playwright.GBIZ.Pages.CommonPage;
using Reqnroll;

namespace BDD.Playwright.GBIZ.Pages.AgentPages
{
    public class Farm_CoveragesPage : BasePage
    {
        private readonly IReqnrollOutputHelper _ReqnrollLogger;
        private readonly FeatureContext _featureContext;
        private readonly ScenarioContext _scenarioContext;
        private readonly IFileReader _fileReader;
        //public BaseElement _baseElement;
        // Constructor
        public Farm_CoveragesPage(ScenarioContext scenarioContext, IFileReader fileReader) : base(scenarioContext)
        {
            _fileReader = fileReader;
            // _baseElement = new BaseElement(scenarioContext);
        }

        #region Xpath
        public string FarmPolIcYFom_Drp => "//select[@id='fld_structC_Policyform_1']";
        public string TypeOfBuilding_Drp => "//select[@name='structC_TypeOfBuilding_1']";
        public string Limit_Farmosner => "//input[@id='fld_structC_limit_1']";
        public string AllPeRilDeduc_Farm => "//select[@id='fld_structC_BasicDeductible_1']";
        public string AddStructure_Farm => "//a[normalize-space()='Add Structure']";
        public string WindhaIldeduc_Farm => "//select[@id='fld_structC_WindHailDeductible_1']";
        public string YearOfConst_Farm => "//input[@id='fld_structC_YearOfConstruction_1']";
        public string ConstructionType_Drpdown => "//select[@id='fld_structC_ConstructionType_1']";
        public string Length_Drpdown => "//input[@id='fld_structC_Length_1']";
        public string Width_dropdown => "//input[@id='fld_structC_Width_1']";
        public string Rateas_drpdown => "//input[@id='fld_structC_RateAs_1_1']";
        public string Earthquake_drpdown => "//input[@id='fld_yes_structC_Earthquake_1']";
        public string LossOfEarnings_dropdon => "//select[@id='fld_structC_lossofEarningType_1']";
        public string LocationFarm_Text => "//select[@id='fld_structC_location_1']";
        public string PolicyFoRm_drp => "//select[@id='fld_structC_Policyform_1']";
        public string TypeOfBuilDing_drP => "//select[@id='fld_structC_TypeOfBuilding_1']";
        public string ExcludingOfBAse_drp => "//input[@id='fld_yes_structC_BrickMasonryInConstruction_1']";
        #endregion
        public async Task CoveragesforFarmOwnerAsync(string profileKey)
        {
            if (_fileReader == null)
            {
                throw new InvalidOperationException("FileReader is not available. Use constructor with IFileReader parameter.");
            }

            try
            {
                logger.WriteLine($"Starting to fill Coverages for FarmOwner information using profile: {profileKey}");

                var filePath = "";

                // Get values from JSON - Quote Details
                var LocationFarm = _fileReader.GetOptionalValue(filePath, $"{profileKey}.LocationFarm");
                var FarmPolIcYFom = _fileReader.GetOptionalValue(filePath, $"{profileKey}.FarmPolIcYFom");
                var TypeOfBuilding = _fileReader.GetOptionalValue(filePath, $"{profileKey}.TypeOfBuilding");
                var Limit_Farm = _fileReader.GetOptionalValue(filePath, $"{profileKey}.Limit_Farm");
                var AllPeRilDeduc_Farm_Value = _fileReader.GetOptionalValue(filePath, $"{profileKey}.AllPeRilDeduc_Farm");
                var WindhaIldeduc_Farm_Value = _fileReader.GetOptionalValue(filePath, $"{profileKey}.WindhaIldeduc_Farm");
                var YearOfConst_Farm_Value = _fileReader.GetOptionalValue(filePath, $"{profileKey}.YearOfConst_Farm");
                var ConstructionType = _fileReader.GetOptionalValue(filePath, $"{profileKey}.ConstructionType");
                var Length = _fileReader.GetOptionalValue(filePath, $"{profileKey}.Length");
                var Width = _fileReader.GetOptionalValue(filePath, $"{profileKey}.Width");
                var Rateas = _fileReader.GetOptionalValue(filePath, $"{profileKey}.Rateas");
                var Earthquake = _fileReader.GetOptionalValue(filePath, $"{profileKey}.Earthquake");
                var ExcludingOfBAse = _fileReader.GetOptionalValue(filePath, $"{profileKey}.ExcludingOfBAse");
                
                await DropDown.SelectDropDownAsync(LocationFarm_Text, LocationFarm, true, 1);
                //InputField.SetTextAreaInputField(LocationFarm_Text, commonFunctions.LocationFarm_Text_LabelAndValue.Item2, true, 1, "Location");
                Thread.Sleep(2000);
                await DropDown.SelectDropDownAsync(FarmPolIcYFom_Drp, FarmPolIcYFom, true, 1);
                //InputField.SetTextAreaInputField(FarmPolIcYFom_Drp, commonFunctions.LocationFarm_Text_LabelAndValue.Item2, true, 1, "FarmPolicy");
                await DropDown.SelectDropDownAsync(TypeOfBuilding_Drp, TypeOfBuilding, true, 1);
                Thread.Sleep(2000);
                //DropDown.SelectDropDown(Limit_Farmosner, commonFunctions.Farmowner_Limit_Farmosner_LabelAndValue.Item2, true, 1);
                await InputField.SetTextAreaInputFieldAsync(Limit_Farmosner, Limit_Farm, true, 1, "Limit");
                await DropDown.SelectDropDownAsync(AllPeRilDeduc_Farm, AllPeRilDeduc_Farm_Value, true, 1);
                //InputField.SetTextAreaInputField(AllPeRilDeduc_Farm, commonFunctions.Farmowner_AllPeRilDeduc_Farm_LabelAndValue.Item2, true, 1, "AllPerilDeductible");
                await DropDown.SelectDropDownAsync(WindhaIldeduc_Farm, WindhaIldeduc_Farm_Value, true, 1);
                await InputField.SetTextAreaInputFieldAsync(YearOfConst_Farm, YearOfConst_Farm_Value, true, 1, "Year of construction");
                await DropDown.SelectDropDownAsync(ConstructionType_Drpdown, ConstructionType, true, 1);
                await InputField.SetTextAreaInputFieldAsync(Length_Drpdown, Length, true, 1, "Length (ft)");
                //DropDown.SelectDropDown(Width_dropdown, commonFunctions.Farmowner_Width_dropdown_LabelAndValue.Item2, true, 1);
                await InputField.SetTextAreaInputFieldAsync(Width_dropdown, Width, true, 1, "Width (ft)");
                Thread.Sleep(2000);
                //Button.ClickButton(Rateas_drpdown, ActionType.Click, true, 1);
                await Checkbox.SelectCheckboxAsync(Rateas_drpdown, true, true, 1);
                await Checkbox.SelectCheckboxAsync(Earthquake_drpdown, true, true, 1);
                await Checkbox.SelectCheckboxAsync(ExcludingOfBAse_drp, true, true, 1);

                logger.WriteLine($"Retrieved Coverages for FarmOwner data for: {LocationFarm} {ConstructionType}");

                // Note: Form filling implementation would go here using the same pattern as BasicInformationPage
                // with the page elements (Button, InputField, DropDown, etc.) once they are properly resolved

                logger.WriteLine($"Successfully filled Coverages for FarmOwner information using profile: {profileKey}");
                logger.WriteLine("Coverages for FarmOwner Page Details Entered Successfully from JSON Data");
            }
            catch (Exception ex)
            {
                logger.WriteLine($"Error filling Coverages for FarmOwner data: {ex.Message}");
                throw new Exception($"Failed to fill Coverages for FarmOwner data using profile '{profileKey}': {ex.Message}", ex);
            }
        }
        }
    }


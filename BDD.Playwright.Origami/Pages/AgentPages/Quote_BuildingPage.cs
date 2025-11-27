//using BDD.Playwright.GBIZ.PageElements;
//using BDD.Playwright.Origami.Pages.CommonPage;
//using Reqnroll;

//namespace BDD.Playwright.GBIZ.Pages.AgentPages
//{
//    public class Quote_BuildingPage : BasePage
//    {
//        private CommonFunctions _commonFunctions;
//        private readonly ScenarioContext _scenarioContext;
//        public FeatureContext _featureContext;
//        public CommonXpath _commonXpath;
//        private readonly IReqnrollOutputHelper _ReqnrollLogger;
//        public LoginPage _loginPage;
//        // Constructor
//        public Quote_BuildingPage(ScenarioContext scenarioContext, CommonFunctions commonFunctions, IReqnrollOutputHelper ReqnrollOutputHelper, LoginPage loginPage, CommonXpath commonXpath) : base(scenarioContext)
//        {
//            _scenarioContext = scenarioContext;
//            _commonFunctions = commonFunctions;
//            _ReqnrollLogger = ReqnrollOutputHelper;
//            _loginPage = loginPage;
//            _commonXpath = commonXpath;
//        }
//        #region Xpath
//        public string AddBuilding { get; set; } = "//a[text()='Add Building']";
//        public string Location_Drp { get; set; } = "//select[@name='bld_location_1' and @id='fld_bld_location_1']";
//        public string Description_input { get; set; } = "//input[@id='fld_bld_description_1']";
//        public string CheckAllThatAreLocated_Radio { get; set; } = "//input[contains(@id,'cbAPTRENT_fld_bld_businessFunction_1')  and @value='{0}']";

//        public string InsuredOwnBuilding_Radio { get; set; } = "//input[contains(@name,'bld_insuredOwnBuilding_1')  and @value='{0}']";
//        public string TotalSquareFootage_input { get; set; } = "//input[contains(@id,'fld_bld_totalSquareFootage_1')]";

//        public string Constructiontype_Drp { get; set; } = "//select[@name='bld_constructionType_1' and @id='fld_bld_constructionType_1']";

//        public string IsthisACondoUnit_Radio { get; set; } = "//input[contains(@name,'bld_condoUnit_1')  and @value='{0}']";
//        public string NumberOfStories_input { get; set; } = "//input[contains(@id,'fld_bld_numberOfStories_1')]";

//        public string Limit_tab { get; set; } = "//div[@id='buildingLimits_head']";

//        public string Continue_btn { get; set; } = "//button[contains(text(),'Continue')]";

//        public string Building_input { get; set; } = "//input[contains(@id,'fld_bld_buildingLimit_1')]";

//        public string Buildingdeductible_drp { get; set; } = "//select[@name='bld_buildingDeductible_1' and @id='fld_bld_buildingDeductible_1']";

//        public string Buildingwindhaildeductible_drp { get; set; } = "//select[@name='bld_whBldDeductible_1' and @id='fld_bld_whBldDeductible_1']";

//        public string BuildingpersonalProperty_Limit { get; set; } = "//input[contains(@id,'fld_bld_personalPropertyLimit_1')]";

//        public string BuildingpersonalPropertyDeductible_drp { get; set; } = "//select[@name='bld_personalPropertyDeductible_1' and @id='fld_bld_personalPropertyDeductible_1']";
//        public string BuildingRating_tab { get; set; } = "//div[@id='buildingRatingInformation_head']";

//        public string Doesbuildinghavesprinklers { get; set; } = "//input[contains(@name,'bld_riSprinklers_1')  and @value='{0}']";

//        public string Bld_riLessThan100Amp_Radio { get; set; } = "//input[contains(@name,'bld_riLessThan100Amp_1')  and @value='{0}']";

//        public string Heatexist_checkboxlabel { get; set; } = "//input[contains(@name,'cbG_bld_riSourcesOfHeat_1')  and @value='G']";
//        public string YearHeatSourceUpdated_input { get; set; } = "//input[contains(@id,'fld_bld_riYearHeatSourceUpdated_1')]";
//        public string LocalPropertyManager_Radio { get; set; } = "//input[contains(@name,'bld_riLocalPropertyManager_1')  and @value='{0}']";
//        public string YearOfConstruction_input { get; set; } = "//input[contains(@id,'fld_bld_riYearOfConstruction_1')]";

//        public string ValueOfBuildingListed100Percent_Radio { get; set; } = "//input[contains(@name, 'bld_riValueOfBuildingListed100Percent_1')  and @value = '{0}']";

//        public string RoofPeaked_Radio { get; set; } = "//input[contains(@name,'bld_riRoofPeaked_1')  and @value='{0}']";

//        public string PortionOfRoofMaterial_Radio { get; set; } = "//input[contains(@name,'bld_riPortionOfRoofMaterial_1')  and @value='{0}']";

//        public string NearFloodzone_Radio { get; set; } = "//input[contains(@name,'bld_riNearFloodzone_1')  and @value='{0}']";

//        public string BuildingIsMobileHome_Radio { get; set; } = "//input[contains(@name,'bld_riBuildingIsMobileHome_1')  and @value='{0}']";
//        public string BuildingIsTownHouse_Radio { get; set; } = "//input[contains(@name,'bld_riBuildingIsTownHouse_1')  and @value='{0}']";
//        public string ExtendedUnoccupied_Radio { get; set; } = "//input[contains(@name,'bld_riExtendedUnoccupied_1')  and @value='{0}']";
//        public string HasAsbestos_Radio { get; set; } = "//input[contains(@name,'bld_riHasAsbestos_1')  and @value='{0}']";

//        public string DoorsWindowsGoodRepair_Radio { get; set; } = "//input[contains(@name,'bld_riDoorsWindowsGoodRepair_1')  and @value='{0}']";

//        public string OtherOccupanciesOnPremises_Radio { get; set; } = "//input[contains(@name,'bld_riOtherOccupanciesOnPremises_1')  and @value='{0}']";

//        public string BuildingTotalSquareFootage_input { get; set; } = "//input[contains(@id,'fld_bld_riTotalSquareFootage_1')]";
//        public string WorkingSmokeDetectorsInPlace_Radio { get; set; } = "//input[contains(@name,'bld_riWorkingSmokeDetectorsInPlace_1')  and @value='{0}']";

//        public string FireExtinguishersInPlace_Radio { get; set; } = "//input[contains(@name,'bld_riFireExtinguishersInPlace_1')  and @value='{0}']";

//        public string SecuritySystem2_Radio { get; set; } = "//input[contains(@name,'bld_riSecuritySystem2_1')  and @value='{0}']";

//        public string APTRENTSquareFootage_input { get; set; } = "//input[contains(@id,'fld_bld_riAPTRENTSquareFootage_1')]";

//        public string APTRENTOccupiedByInsured_Radio { get; set; } = "//input[contains(@name,'bld_riAPTRENTOccupiedByInsured_1')  and @value='{0}']";

//        public string NumberOfUnits_input { get; set; } = "//input[contains(@id,'fld_bld_riNumberOfUnits_1')]";

//        public string NumberOfUnitsOwnedByInsured_input { get; set; } = "//input[contains(@id,'fld_bld_riNumberOfUnitsOwnedByInsured_1')]";

//        public string StudentHousing_Radio { get; set; } = "//input[contains(@name,'bld_riStudentHousing_1')  and @value='{0}']";

//        public string InsuredIsCondoAssociation_Radio { get; set; } = "//input[contains(@name,'bld_riInsuredIsCondoAssociation_1')  and @value='{0}']";

//        public string HeldForSale_Radio { get; set; } = "//input[contains(@name,'bld_riHeldForSale_1')  and @value='{0}']";

//        public string LeaseType_drp { get; set; } = "//select[@name='bld_riLeaseType_1' and @id='fld_bld_riLeaseType_1']";

//        #endregion
//        public async Task BuildingDatafillAsync()
//        {
//            commonFunctions.UserWaitForPageToLoadCompletly();
//            commonFunctions.ScrollUp();
//            commonFunctions.ScrollUp();
//            commonFunctions.ScrollUp();
//            await Task.Delay(10000);
//            Button.ScrollIntoView(AddBuilding, true, 1);
//            Button.ClickButton(AddBuilding, ActionType.Click, true, 1);
//            await Task.Delay(20000);
//            commonFunctions.ScrollUp();
//            commonFunctions.ScrollUp();
//            commonFunctions.ScrollUp();
//            commonFunctions.ScrollUp();
//            commonFunctions.ReadTestDataForBuildingPage();
//            commonFunctions.UserWaitForPageToLoadCompletly();
//            await Task.Delay(10000);
//            DropDown.SelectDropDown(Location_Drp, commonFunctions.BuildingLocation_LabelAndValue.Item2, true, 1);
//            InputField.SetTextAreaInputField(Description_input, commonFunctions.BuildingDescription_LabelAndValue.Item2, true, 1);
//            if (commonFunctions.BuildingCheckAllThatAreLocated_LabelAndValue.Item2 != string.Empty)
//            {
//                if (commonFunctions.BuildingCheckAllThatAreLocated_LabelAndValue.Item2 == "Yes")
//                {
//                    var CheckAllThatAreLocated_Radio1 = string.Format(CheckAllThatAreLocated_Radio, commonFunctions.BuildingCheckAllThatAreLocated_LabelAndValue.Item2);
//                    RadioButton.SelectRadioButton(CheckAllThatAreLocated_Radio1, true, 1);
//                }
//                else
//                {
//                    var CheckAllThatAreLocated_Radio1 = string.Format(CheckAllThatAreLocated_Radio, commonFunctions.BuildingCheckAllThatAreLocated_LabelAndValue.Item2);
//                    RadioButton.SelectRadioButton(CheckAllThatAreLocated_Radio1, true, 1);
//                }
//            }

//            if (commonFunctions.BuildingInsuredOwnBuilding_Radio_LabelAndValue.Item2 != string.Empty)
//            {
//                if (commonFunctions.BuildingInsuredOwnBuilding_Radio_LabelAndValue.Item2 == "Yes")
//                {
//                    var InsuredOwnBuilding_Radio1 = string.Format(InsuredOwnBuilding_Radio, commonFunctions.BuildingInsuredOwnBuilding_Radio_LabelAndValue.Item2);
//                    RadioButton.SelectRadioButton(InsuredOwnBuilding_Radio1, true, 1);
//                }
//                else
//                {
//                    var InsuredOwnBuilding_Radio1 = string.Format(InsuredOwnBuilding_Radio, commonFunctions.BuildingInsuredOwnBuilding_Radio_LabelAndValue.Item2);
//                    RadioButton.SelectRadioButton(InsuredOwnBuilding_Radio1, true, 1);
//                }
//            }

//            await Task.Delay(10000);
//            InputField.SetTextAreaInputField(TotalSquareFootage_input, commonFunctions.BuildingTotalSquareFootage_input_LabelAndValue.Item2, true, 1);
//            DropDown.SelectDropDown(Constructiontype_Drp, commonFunctions.BuildingConstructiontype_LabelAndValue.Item2, true, 1);
//            if (commonFunctions.BuildingIsthisACondoUnit_Radio_LabelAndValue.Item2 != string.Empty)
//            {
//                if (commonFunctions.BuildingIsthisACondoUnit_Radio_LabelAndValue.Item2 == "Yes")
//                {
//                    var IsthisACondoUnit_Radio1 = string.Format(IsthisACondoUnit_Radio, commonFunctions.BuildingIsthisACondoUnit_Radio_LabelAndValue.Item2);
//                    RadioButton.SelectRadioButton(IsthisACondoUnit_Radio1, true, 1);
//                }
//                else
//                {
//                    var IsthisACondoUnit_Radio1 = string.Format(IsthisACondoUnit_Radio, commonFunctions.BuildingIsthisACondoUnit_Radio_LabelAndValue.Item2);
//                    RadioButton.SelectRadioButton(IsthisACondoUnit_Radio1, true, 1);
//                }
//            }

//            await Task.Delay(5000);
//            InputField.SetTextAreaInputField(NumberOfStories_input, commonFunctions.BuildingNumberOfStories_input_LabelAndValue.Item2, true, 1);
//            await Task.Delay(5000);
//            Button.ScrollIntoView(Limit_tab, true, 1);

//            Button.ClickButton(Limit_tab, ActionType.Click, true, 1);
//            await Task.Delay(3000);

//            //Limit_tab
//            Button.ScrollIntoView(Building_input, true, 1);

//            InputField.SetTextAreaInputField(Building_input, commonFunctions.Building_input_LabelAndValue.Item2, true, 1);
//            DropDown.SelectDropDown(Buildingdeductible_drp, commonFunctions.Building_Buildingdeductible_drp_LabelAndValue.Item2, true, 1);
//            await Task.Delay(5000);
//            DropDown.SelectDropDown(Buildingwindhaildeductible_drp, commonFunctions.Building_Buildingwindhaildeductible_drp_LabelAndValue.Item2, true, 1);
//            InputField.SetTextAreaInputField(BuildingpersonalProperty_Limit, commonFunctions.Building_BuildingpersonalPropertyLimit_drp_LabelAndValue.Item2, true, 1);
//            DropDown.SelectDropDown(BuildingpersonalPropertyDeductible_drp, commonFunctions.Building_BuildingpersonalPropertyDeductible_drp_LabelAndValue.Item2, true, 1);
//            Button.ClickButton(BuildingRating_tab, ActionType.Click, true, 1);
//            await Task.Delay(3000);

//            //Rating_tab

//            if (commonFunctions.Building_BuildingDoesbuildinghavesprinklers_LabelAndValue.Item2 != string.Empty)
//            {
//                if (commonFunctions.Building_BuildingDoesbuildinghavesprinklers_LabelAndValue.Item2 == "Yes")
//                {
//                    var Doesbuildinghavesprinklers1 = string.Format(Doesbuildinghavesprinklers, commonFunctions.Building_BuildingDoesbuildinghavesprinklers_LabelAndValue.Item2);
//                    RadioButton.SelectRadioButton(Doesbuildinghavesprinklers1, true, 1);
//                }
//                else
//                {
//                    var Doesbuildinghavesprinklers1 = string.Format(Doesbuildinghavesprinklers, commonFunctions.Building_BuildingDoesbuildinghavesprinklers_LabelAndValue.Item2);
//                    RadioButton.SelectRadioButton(Doesbuildinghavesprinklers1, true, 1);
//                }
//            }

//            await Task.Delay(5000);
//            if (commonFunctions.Building_bld_riLessThan100Amp_Radio_LabelAndValue.Item2 != string.Empty)
//            {
//                if (commonFunctions.Building_bld_riLessThan100Amp_Radio_LabelAndValue.Item2 == "Yes")
//                {
//                    var bld_riLessThan100Amp_Radio1 = string.Format(bld_riLessThan100Amp_Radio, commonFunctions.Building_bld_riLessThan100Amp_Radio_LabelAndValue.Item2);
//                    RadioButton.SelectRadioButton(bld_riLessThan100Amp_Radio1, true, 1);
//                }
//                else
//                {
//                    var bld_riLessThan100Amp_Radio1 = string.Format(bld_riLessThan100Amp_Radio, commonFunctions.Building_bld_riLessThan100Amp_Radio_LabelAndValue.Item2);
//                    RadioButton.SelectRadioButton(bld_riLessThan100Amp_Radio1, true, 1);
//                }
//            }

//            if (commonFunctions.Building_heatexist_checkboxlabel_LabelAndValue.Item2 != string.Empty)
//            {
//                if (commonFunctions.Building_heatexist_checkboxlabel_LabelAndValue.Item2 == "Yes")
//                {
//                    var heatexist_checkboxlabel1 = string.Format(heatexist_checkboxlabel, commonFunctions.Building_heatexist_checkboxlabel_LabelAndValue.Item2);
//                    Checkbox.SelectCheckbox(heatexist_checkboxlabel1, true, true, 1);
//                }
//            }

//            InputField.SetTextAreaInputField(YearHeatSourceUpdated_input, commonFunctions.Building_YearHeatSourceUpdatedl_LabelAndValue.Item2, true, 1);

//            await Task.Delay(5000);
//            if (commonFunctions.Building_localPropertyManager_Radio_LabelAndValue.Item2 != string.Empty)
//            {
//                if (commonFunctions.Building_localPropertyManager_Radio_LabelAndValue.Item2 == "Yes")
//                {
//                    var localPropertyManager_Radio1 = string.Format(localPropertyManager_Radio, commonFunctions.Building_localPropertyManager_Radio_LabelAndValue.Item2);
//                    RadioButton.SelectRadioButton(localPropertyManager_Radio1, true, 1);
//                }
//                else
//                {
//                    var localPropertyManager_Radio1 = string.Format(localPropertyManager_Radio, commonFunctions.Building_localPropertyManager_Radio_LabelAndValue.Item2);
//                    RadioButton.SelectRadioButton(localPropertyManager_Radio1, true, 1);
//                }
//            }

//            InputField.SetTextAreaInputField(YearOfConstruction_input, commonFunctions.Building_YearOfConstruction_input_LabelAndValue.Item2, true, 1);

//            if (commonFunctions.Building_ValueOfBuildingListed100Percent_Radio_LabelAndValue.Item2 != string.Empty)
//            {
//                if (commonFunctions.Building_ValueOfBuildingListed100Percent_Radio_LabelAndValue.Item2 == "Yes")
//                {
//                    var ValueOfBuildingListed100Percent1 = string.Format(ValueOfBuildingListed100Percent_Radio, commonFunctions.Building_ValueOfBuildingListed100Percent_Radio_LabelAndValue.Item2);
//                    RadioButton.SelectRadioButton(ValueOfBuildingListed100Percent1, true, 1);
//                }
//                else
//                {
//                    var ValueOfBuildingListed100Percent1 = string.Format(ValueOfBuildingListed100Percent_Radio, commonFunctions.Building_ValueOfBuildingListed100Percent_Radio_LabelAndValue.Item2);
//                    RadioButton.SelectRadioButton(ValueOfBuildingListed100Percent1, true, 1);
//                }
//            }

//            await Task.Delay(5000);

//            if (commonFunctions.Building_RoofPeaked_Radio_LabelAndValue.Item2 != string.Empty)
//            {
//                if (commonFunctions.Building_RoofPeaked_Radio_LabelAndValue.Item2 == "Yes")
//                {
//                    var Building_RoofPeaked_Radio1 = string.Format(RoofPeaked_Radio, commonFunctions.Building_RoofPeaked_Radio_LabelAndValue.Item2);
//                    RadioButton.SelectRadioButton(Building_RoofPeaked_Radio1, true, 1);
//                }
//                else
//                {
//                    var Building_RoofPeaked_Radio1 = string.Format(RoofPeaked_Radio, commonFunctions.Building_RoofPeaked_Radio_LabelAndValue.Item2);
//                    RadioButton.SelectRadioButton(Building_RoofPeaked_Radio1, true, 1);
//                }
//            }

//            if (commonFunctions.Building_PortionOfRoofMaterial_Radio_LabelAndValue.Item2 != string.Empty)
//            {
//                if (commonFunctions.Building_PortionOfRoofMaterial_Radio_LabelAndValue.Item2 == "Yes")
//                {
//                    var Building_PortionOfRoofMaterial_Radio_LabelAndValue1 = string.Format(PortionOfRoofMaterial_Radio, commonFunctions.Building_PortionOfRoofMaterial_Radio_LabelAndValue.Item2);
//                    RadioButton.SelectRadioButton(Building_PortionOfRoofMaterial_Radio_LabelAndValue1, true, 1);
//                }
//                else
//                {
//                    var Building_PortionOfRoofMaterial_Radio_LabelAndValue1 = string.Format(PortionOfRoofMaterial_Radio, commonFunctions.Building_PortionOfRoofMaterial_Radio_LabelAndValue.Item2);
//                    RadioButton.SelectRadioButton(Building_PortionOfRoofMaterial_Radio_LabelAndValue1, true, 1);
//                }
//            }

//            await Task.Delay(5000);
//            if (commonFunctions.Building_NearFloodzone_Radio_LabelAndValue.Item2 != string.Empty)
//            {
//                if (commonFunctions.Building_NearFloodzone_Radio_LabelAndValue.Item2 == "Yes")
//                {
//                    var Building_NearFloodzone_Radio_LabelAndValue1 = string.Format(NearFloodzone_Radio, commonFunctions.Building_NearFloodzone_Radio_LabelAndValue.Item2);
//                    RadioButton.SelectRadioButton(Building_NearFloodzone_Radio_LabelAndValue1, true, 1);
//                }
//                else
//                {
//                    var Building_NearFloodzone_Radio_LabelAndValue1 = string.Format(NearFloodzone_Radio, commonFunctions.Building_NearFloodzone_Radio_LabelAndValue.Item2);
//                    RadioButton.SelectRadioButton(Building_NearFloodzone_Radio_LabelAndValue1, true, 1);
//                }
//            }

//            if (commonFunctions.BuildingIsMobileHome_Radio_LabelAndValue.Item2 != string.Empty)
//            {
//                if (commonFunctions.BuildingIsMobileHome_Radio_LabelAndValue.Item2 == "Yes")
//                {
//                    var BuildingIsMobileHome_Radio_LabelAndValue1 = string.Format(BuildingIsMobileHome_Radio, commonFunctions.BuildingIsMobileHome_Radio_LabelAndValue.Item2);
//                    RadioButton.SelectRadioButton(BuildingIsMobileHome_Radio_LabelAndValue1, true, 1);
//                }
//                else
//                {
//                    var BuildingIsMobileHome_Radio_LabelAndValue1 = string.Format(BuildingIsMobileHome_Radio, commonFunctions.BuildingIsMobileHome_Radio_LabelAndValue.Item2);
//                    RadioButton.SelectRadioButton(BuildingIsMobileHome_Radio_LabelAndValue1, true, 1);
//                }
//            }

//            await Task.Delay(5000);
//            if (commonFunctions.BuildingIsTownHouse_Radio_LabelAndValue.Item2 != string.Empty)
//            {
//                if (commonFunctions.BuildingIsTownHouse_Radio_LabelAndValue.Item2 == "Yes")
//                {
//                    var BuildingIsTownHouse_Radio_LabelAndValue1 = string.Format(BuildingIsTownHouse_Radio, commonFunctions.BuildingIsTownHouse_Radio_LabelAndValue.Item2);
//                    RadioButton.SelectRadioButton(BuildingIsTownHouse_Radio_LabelAndValue1, true, 1);
//                }
//                else
//                {
//                    var BuildingIsTownHouse_Radio_LabelAndValue1 = string.Format(BuildingIsTownHouse_Radio, commonFunctions.BuildingIsTownHouse_Radio_LabelAndValue.Item2);
//                    RadioButton.SelectRadioButton(BuildingIsTownHouse_Radio_LabelAndValue1, true, 1);
//                }
//            }

//            if (commonFunctions.Building_ExtendedUnoccupied_Radio_LabelAndValue.Item2 != string.Empty)
//            {
//                if (commonFunctions.Building_ExtendedUnoccupied_Radio_LabelAndValue.Item2 == "Yes")
//                {
//                    var Building_ExtendedUnoccupied_Radio_LabelAndValue1 = string.Format(ExtendedUnoccupied_Radio, commonFunctions.Building_ExtendedUnoccupied_Radio_LabelAndValue.Item2);
//                    RadioButton.SelectRadioButton(Building_ExtendedUnoccupied_Radio_LabelAndValue1, true, 1);
//                }
//                else
//                {
//                    var Building_ExtendedUnoccupied_Radio_LabelAndValue1 = string.Format(ExtendedUnoccupied_Radio, commonFunctions.Building_ExtendedUnoccupied_Radio_LabelAndValue.Item2);
//                    RadioButton.SelectRadioButton(Building_ExtendedUnoccupied_Radio_LabelAndValue1, true, 1);
//                }
//            }

//            await Task.Delay(5000);
//            if (commonFunctions.Building_HasAsbestos_Radio_LabelAndValue.Item2 != string.Empty)
//            {
//                if (commonFunctions.Building_HasAsbestos_Radio_LabelAndValue.Item2 == "Yes")
//                {
//                    var Building_HasAsbestos_Radio_LabelAndValue1 = string.Format(HasAsbestos_Radio, commonFunctions.Building_HasAsbestos_Radio_LabelAndValue.Item2);
//                    RadioButton.SelectRadioButton(Building_HasAsbestos_Radio_LabelAndValue1, true, 1);
//                }
//                else
//                {
//                    var Building_HasAsbestos_Radio_LabelAndValue1 = string.Format(HasAsbestos_Radio, commonFunctions.Building_HasAsbestos_Radio_LabelAndValue.Item2);
//                    RadioButton.SelectRadioButton(Building_HasAsbestos_Radio_LabelAndValue1, true, 1);
//                }
//            }

//            await Task.Delay(5000);

//            if (commonFunctions.Building_DoorsWindowsGoodRepair_Radio_LabelAndValue.Item2 != string.Empty)
//            {
//                if (commonFunctions.Building_DoorsWindowsGoodRepair_Radio_LabelAndValue.Item2 == "Yes")
//                {
//                    var Building_DoorsWindowsGoodRepair_Radio_LabelAndValue1 = string.Format(DoorsWindowsGoodRepair_Radio, commonFunctions.Building_DoorsWindowsGoodRepair_Radio_LabelAndValue.Item2);
//                    RadioButton.SelectRadioButton(Building_DoorsWindowsGoodRepair_Radio_LabelAndValue1, true, 1);
//                }
//                else
//                {
//                    var Building_DoorsWindowsGoodRepair_Radio_LabelAndValue1 = string.Format(DoorsWindowsGoodRepair_Radio, commonFunctions.Building_DoorsWindowsGoodRepair_Radio_LabelAndValue.Item2);
//                    RadioButton.SelectRadioButton(Building_DoorsWindowsGoodRepair_Radio_LabelAndValue1, true, 1);
//                }
//            }

//            await Task.Delay(5000);

//            if (commonFunctions.Building_OtherOccupanciesOnPremises_Radio_LabelAndValue.Item2 != string.Empty)
//            {
//                if (commonFunctions.Building_OtherOccupanciesOnPremises_Radio_LabelAndValue.Item2 == "Yes")
//                {
//                    var Building_OtherOccupanciesOnPremises_Radio_LabelAndValue1 = string.Format(OtherOccupanciesOnPremises_Radio, commonFunctions.Building_OtherOccupanciesOnPremises_Radio_LabelAndValue.Item2);
//                    RadioButton.SelectRadioButton(Building_OtherOccupanciesOnPremises_Radio_LabelAndValue1, true, 1);
//                }
//                else
//                {
//                    var Building_OtherOccupanciesOnPremises_Radio_LabelAndValue1 = string.Format(OtherOccupanciesOnPremises_Radio, commonFunctions.Building_OtherOccupanciesOnPremises_Radio_LabelAndValue.Item2);
//                    RadioButton.SelectRadioButton(Building_OtherOccupanciesOnPremises_Radio_LabelAndValue1, true, 1);
//                }
//            }

//            await Task.Delay(5000);
//            InputField.SetTextAreaInputField(BuildingTotalSquareFootage_input, commonFunctions.Building_TotalSquareFootage_input_LabelAndValue.Item2, true, 1);
//            if (commonFunctions.Building_WorkingSmokeDetectorsInPlace_Radio_LabelAndValue.Item2 != string.Empty)
//            {
//                if (commonFunctions.Building_WorkingSmokeDetectorsInPlace_Radio_LabelAndValue.Item2 == "Yes")
//                {
//                    var Building_WorkingSmokeDetectorsInPlace_Radio_LabelAndValue1 = string.Format(WorkingSmokeDetectorsInPlace_Radio, commonFunctions.Building_WorkingSmokeDetectorsInPlace_Radio_LabelAndValue.Item2);
//                    RadioButton.SelectRadioButton(Building_WorkingSmokeDetectorsInPlace_Radio_LabelAndValue1, true, 1);
//                }
//                else
//                {
//                    var Building_WorkingSmokeDetectorsInPlace_Radio_LabelAndValue1 = string.Format(WorkingSmokeDetectorsInPlace_Radio, commonFunctions.Building_WorkingSmokeDetectorsInPlace_Radio_LabelAndValue.Item2);
//                    RadioButton.SelectRadioButton(Building_WorkingSmokeDetectorsInPlace_Radio_LabelAndValue1, true, 1);
//                }
//            }

//            if (commonFunctions.Building_FireExtinguishersInPlace_Radio_LabelAndValue.Item2 != string.Empty)
//            {
//                if (commonFunctions.Building_FireExtinguishersInPlace_Radio_LabelAndValue.Item2 == "Yes")
//                {
//                    var Building_FireExtinguishersInPlace_Radio_LabelAndValue1 = string.Format(FireExtinguishersInPlace_Radio, commonFunctions.Building_FireExtinguishersInPlace_Radio_LabelAndValue.Item2);
//                    RadioButton.SelectRadioButton(Building_FireExtinguishersInPlace_Radio_LabelAndValue1, true, 1);
//                }
//                else
//                {
//                    var Building_FireExtinguishersInPlace_Radio_LabelAndValue1 = string.Format(FireExtinguishersInPlace_Radio, commonFunctions.Building_FireExtinguishersInPlace_Radio_LabelAndValue.Item2);
//                    RadioButton.SelectRadioButton(Building_FireExtinguishersInPlace_Radio_LabelAndValue1, true, 1);
//                }
//            }

//            if (commonFunctions.Building_SecuritySystem2_Radio_LabelAndValue.Item2 != string.Empty)
//            {
//                if (commonFunctions.Building_SecuritySystem2_Radio_LabelAndValue.Item2 == "Yes")
//                {
//                    var Building_SecuritySystem2_Radio_LabelAndValue1 = string.Format(SecuritySystem2_Radio, commonFunctions.Building_SecuritySystem2_Radio_LabelAndValue.Item2);
//                    RadioButton.SelectRadioButton(Building_SecuritySystem2_Radio_LabelAndValue1, true, 1);
//                }
//                else
//                {
//                    var Building_SecuritySystem2_Radio_LabelAndValue1 = string.Format(SecuritySystem2_Radio, commonFunctions.Building_SecuritySystem2_Radio_LabelAndValue.Item2);
//                    RadioButton.SelectRadioButton(Building_SecuritySystem2_Radio_LabelAndValue1, true, 1);
//                }
//            }

//            await Task.Delay(5000);
//            InputField.SetTextAreaInputField(APTRENTSquareFootage_input, commonFunctions.Building_APTRENTSquareFootage_input_LabelAndValue.Item2, true, 1);

//            if (commonFunctions.Building_APTRENTOccupiedByInsured_Radio_LabelAndValue.Item2 != string.Empty)
//            {
//                if (commonFunctions.Building_APTRENTOccupiedByInsured_Radio_LabelAndValue.Item2 == "Yes")
//                {
//                    var Building_APTRENTOccupiedByInsured_Radio_LabelAndValue1 = string.Format(APTRENTOccupiedByInsured_Radio, commonFunctions.Building_APTRENTOccupiedByInsured_Radio_LabelAndValue.Item2);
//                    RadioButton.SelectRadioButton(Building_APTRENTOccupiedByInsured_Radio_LabelAndValue1, true, 1);
//                }
//                else
//                {
//                    var Building_APTRENTOccupiedByInsured_Radio_LabelAndValue1 = string.Format(APTRENTOccupiedByInsured_Radio, commonFunctions.Building_APTRENTOccupiedByInsured_Radio_LabelAndValue.Item2);
//                    RadioButton.SelectRadioButton(Building_APTRENTOccupiedByInsured_Radio_LabelAndValue1, true, 1);
//                }

//                InputField.SetTextAreaInputField(NumberOfUnits_input, commonFunctions.Building_NumberOfUnits_input_LabelAndValue.Item2, true, 1);
//                InputField.SetTextAreaInputField(NumberOfUnitsOwnedByInsured_input, commonFunctions.Building_NumberOfUnitsOwnedByInsured_input_LabelAndValue.Item2, true, 1);

//                await Task.Delay(5000);
//                if (commonFunctions.Building_StudentHousing_Radio_LabelAndValue.Item2 != string.Empty)
//                {
//                    if (commonFunctions.Building_StudentHousing_Radio_LabelAndValue.Item2 == "Yes")
//                    {
//                        var Building_StudentHousing_Radio_LabelAndValue1 = string.Format(StudentHousing_Radio, commonFunctions.Building_StudentHousing_Radio_LabelAndValue.Item2);
//                        RadioButton.SelectRadioButton(Building_StudentHousing_Radio_LabelAndValue1, true, 1);
//                    }
//                    else
//                    {
//                        var Building_StudentHousing_Radio_LabelAndValue1 = string.Format(StudentHousing_Radio, commonFunctions.Building_StudentHousing_Radio_LabelAndValue.Item2);
//                        RadioButton.SelectRadioButton(Building_StudentHousing_Radio_LabelAndValue1, true, 1);
//                    }
//                }

//                if (commonFunctions.Building_InsuredIsCondoAssociation_Radio_LabelAndValue.Item2 != string.Empty)
//                {

//                    if (commonFunctions.Building_InsuredIsCondoAssociation_Radio_LabelAndValue.Item2 == "Yes")
//                    {
//                        var Building_InsuredIsCondoAssociation_Radio_LabelAndValue1 = string.Format(InsuredIsCondoAssociation_Radio, commonFunctions.Building_InsuredIsCondoAssociation_Radio_LabelAndValue.Item2);
//                        RadioButton.SelectRadioButton(Building_InsuredIsCondoAssociation_Radio_LabelAndValue1, true, 1);
//                    }
//                    else
//                    {
//                        var Building_InsuredIsCondoAssociation_Radio_LabelAndValue1 = string.Format(InsuredIsCondoAssociation_Radio, commonFunctions.Building_InsuredIsCondoAssociation_Radio_LabelAndValue.Item2);
//                        RadioButton.SelectRadioButton(Building_InsuredIsCondoAssociation_Radio_LabelAndValue1, true, 1);
//                    }
//                }

//                await Task.Delay(5000);
//                if (commonFunctions.Building_HeldForSale_Radio_LabelAndValue.Item2 != string.Empty)
//                {

//                    if (commonFunctions.Building_HeldForSale_Radio_LabelAndValue.Item2 == "Yes")
//                    {
//                        var Building_HeldForSale_Radio_LabelAndValue1 = string.Format(HeldForSale_Radio, commonFunctions.Building_HeldForSale_Radio_LabelAndValue.Item2);
//                        RadioButton.SelectRadioButton(Building_HeldForSale_Radio_LabelAndValue1, true, 1);
//                    }
//                    else
//                    {
//                        var Building_HeldForSale_Radio_LabelAndValue1 = string.Format(HeldForSale_Radio, commonFunctions.Building_HeldForSale_Radio_LabelAndValue.Item2);
//                        RadioButton.SelectRadioButton(Building_HeldForSale_Radio_LabelAndValue1, true, 1);
//                    }
//                }

//                DropDown.SelectDropDown(LeaseType_drp, commonFunctions.Building_LeaseType_drp_LabelAndValue.Item2, true, 1);

//                await Task.Delay(10000);

//                Button.ClickButton(Continue_btn, ActionType.Click, true, 1);
//                commonFunctions.UserWaitForPageToLoadCompletly();
//            }
//        }
//    }
//}


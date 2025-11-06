using BDD.Playwright.GBIZ.PageElements;
using BDD.Playwright.GBIZ.Pages.CommonPage;
using Microsoft.Playwright;
using Reqnroll;

namespace BDD.Playwright.Origami.Pages.AgentPages
{
    public class Quote_DwellingPage : BasePage
    {
        public Quote_DwellingPage(ScenarioContext scenarioContext) : base(scenarioContext) { }

        #region Xpath
        public string Protection_Drp { get; set; } = "//select[@id='fld_loc_protection_1']";
        public string StreetAddress { get; set; } = "//textarea[@name='loc_streetAddress_1']";
        public string City { get; set; } = "//input[@name='loc_city_1']";
        public string ZipCode { get; set; } = "//input[@name='loc_zipCode_1']";
        public string RespondingFireDepartment { get; set; } = "//input[@name='loc_respondingFireDept_1']";
        public string YearOfConstruction_FO { get; set; } = "//input[@name='bld_OriginalYearBuild_1']";
        public string YearOfConstruction { get; set; } = "//input[@name='bld_riYearOfConstruction_1']";
        public string ConstructionType_Radio { get; set; } = "//input[@name='bld_constructionType_1' and @value='{0}']";
        public string BuildingType_Radio { get; set; } = "//input[@name='bld_buildingType_1' and @value='{0}']";
        public string TotalNumber_Drp { get; set; } = "//select[@name='bld_totalUnits_1']";
        public string NumberUnits_Drp { get; set; } = "//select[@name='bld_numberOfUnitsOwnedByInsured_1']";
        public string DwellingVacant_Radio { get; set; } = "//input[@name='bld_vacantOrUnoccupied_1' and @value='{0}']";
        public string BuildingConstruction_Radio { get; set; } = "//input[@name='bld_underConstruction_1' and @value='{0}']";
        public string Renovation_Radio { get; set; } = "//input[@name='bld_buildingRenovation_1' and @value='{0}']";
        public string OccupancyType_Drp { get; set; } = "//select[@name='bld_occupancyType_1']";

        public string OccupiedBy_Drp { get; set; } = "//select[@name='bld_occupiedBy_1']";
        public string PrimaryHeatType_Drp { get; set; } = "//select[@name='bld_primaryHeatType_1']";
        public string RoofPeaked_Radio { get; set; } = "//input[@name='bld_peakedRoof_1' and @value='{0}']";
        public string BuildingAsbestos_Radio { get; set; } = "//input[@name='bld_asbestosRoofing_1' and @value='{0}']";
        public string PropertyLocated_Radio { get; set; } = "//input[@name='bld_propertyLocatedFlood_1' and @value='{0}']";
        public string DogsLocation_Radio { get; set; } = "//input[@name='loc_hasDogs_1' and @value='{0}']";
        public string AnimalLocation_Radio { get; set; } = "//input[@name='bld_animalsOrExoticPets_1' and @value='{0}']";
        public string MoreFiveAcre_Radio { get; set; } = "//input[@name='bld_moreFiveAcres_1' and @value='{0}']";
        public string FireBuildingViolations_Radio { get; set; } = "//input[@name='bld_uncorrectedFireBuildingViolations_1' and @value='{0}']";
        public string Trampoline_Radio{ get; set; } = "//input[@name='bld_isTrampoline_1' and @value='{0}']";
        public string StructureConverted_Radio { get; set; } = "//input[@name='bld_structureConverted_1' and @value='{0}']";
        public string Address911_Radio { get; set; } = "//input[@name='bld_is911Address_1' and @value='{0}']";
        public string Drivingdirections { get; set; } = "//textarea[@name='bld_drivingDirections_1']";
        public string SwimmingPool_Radio { get; set; } = "//input[@name='loc_swimmingPool_1' and @value='{0}']";
        public string Zipline_Radio { get; set; } = "//input[@name='zipLine' and @value='{0}']";
        public string Fireplaces { get; set; } = "//input[@name='bld_numBuiltInFireplaces_1']";
        public string LPGasHeater { get; set; } = "//input[@name='bld_lpGasHeater_1']";
        public string LimitsCoveragesDiscountsButton { get; set; } = "//div[@class='VDPN_rightdiv']";
        public string CoverageAResidence { get; set; } = "//input[@name='bld_buildingLimit_1']";
        public string CoverageBOtherStructures { get; set; } = "//select[@name='bld_dwellingCovBBlanketFOne_1']";
        public string CoverageCPersonalProperty { get; set; } = "//input[@name='bld_personalPropertyLimit_1']";
        public string CoverageDAdditionalLimit { get; set; } = "//input[@name='bld_lossOfRentPercent_1']";
        public string EarthquakeLossAssessment { get; set; } = "//input[@name='bld_eqLossAssessmentLimit_1']";
        public string Earthquake { get; set; } = "//input[@name='bld_earthquake_1' and @value='{0}']";
        public string AuxUnit1 { get; set; } = "//div[@class='pointer' and contains(text(),'Add Auxiliary Heat')]";
        public string AuxiliaryHeatingSystem1 { get; set; } = "//input[@name='bld_ahType_1_1' and @value='{0}']";
        public string ContinueButton { get; set; } = "//button[contains(text(),'Continue')]";
        public string ContinueSummary { get; set; } = "//button[contains(text(),'Continue to Summary')]";
        public string NextButton { get; set; } = "//div[@id='bottomsubnav_nextlink']";
        //public string MyProperty { get; set; } = "//select[@id='fld_bld_location_1']";
        //pooja
        public string Location_drpdwn { get; set; } = "//select[contains(@id,'bld_location')]";
        public string OwnedByTheInsured_RadioBtn { get; set; } = "//input[contains(@id,'fld_yes_bld_IsOwnedByInsured') and @value='{0}']";
        public string AddDwelling_btn { get; set; } = "//a[contains(text(),'Add dwelling')]";
        public string OccupationType_RadioBtn { get; set; } = "//input[contains(@id,'bld_OccupancyType') and @value ='{0}']";
        public string NumberOfFamilies_drpdwn { get; set; } = "//select[contains(@id,'fld_bld_NoOfFamilies')]";
        public string DwellingUnderConstruction_RadioBtn { get; set; } = "//input[contains(@id,'bld_UnderConstruction') and @value='{0}']";
        public string FlatRoof_RadioBtn { get; set; } = "//input[contains(@id,'bld_FlatRoof') and @value='{0}']";
        public string LimitsCoveragesDiscounts_SubTab { get; set; } = "//div[contains(text(),'Limits / Coverages / Discounts') and @class='pointer']";
        public string PolicyForm_DrpDwn { get; set; } = "//select[contains(@id,'fld_bld_PolicyForm')]";
        public string PolicyPlanForm_RadioBtn { get; set; } = "//input[contains(@id,'fld_bld_PlanForm') and @Value='{0}']";
        public string PolicyDwellingCoverage_Inp { get; set; } = "//input[contains(@id,'fld_bld_dwellingCoverage')]";
        public string AllPerilDeductible_drpdwn { get; set; } = "//select[contains(@id,'fld_bld_dwellingBasicDeductible')]";
        public string WindHailDeductible_drpdwn { get; set; } = "//select[contains(@id,'fld_bld_dwellingWindHailDeductible')]";
        public string DwellingEarthquake_Radiobtn { get; set; } = "//input[contains(@name,'bld_dwellingEarthquake') and @value='{0}']";
        public string DwellingRoofSurface_Radiobtn { get; set; } = "//input[contains(@name,'bld_dwellingRoofingSurfacing') and @value='{0}']";
        #endregion

        public async Task DwellingDatafillAsync(dynamic commonFunctions)
        {
            await page.WaitForLoadStateAsync(LoadState.DOMContentLoaded);
            await DropDown.SelectDropDownAsync(Protection_Drp, commonFunctions.DwellingProtection_LabelAndValue.Item2, true, 1);
            await InputField.SetTextAreaInputFieldAsync(StreetAddress, commonFunctions.DwellingStreetAddress_LabelAndValue.Item2, true, 1);
            await InputField.SetTextAreaInputFieldAsync(City, commonFunctions.DwellingCity_LabelAndValue.Item2, true, 1);
            await InputField.SetTextAreaInputFieldAsync(ZipCode, commonFunctions.DwellingZipCode_LabelAndValue.Item2, true, 1);
            await InputField.SetTextAreaInputFieldAsync(RespondingFireDepartment, commonFunctions.DwellingRespondingFireDepartment_LabelAndValue.Item2, true, 1);
            await InputField.SetTextAreaInputFieldAsync(YearOfConstruction, commonFunctions.DwellingYearOfConstruction_LabelAndValue.Item2, true, 1);
            if (!string.IsNullOrEmpty(commonFunctions.DwellingConstructionType_LabelAndValue.Item2))
            {
                var constructionType = string.Format(ConstructionType_Radio, commonFunctions.DwellingConstructionType_LabelAndValue.Item2);
                await RadioButton.SelectRadioButtonAsync(constructionType, commonFunctions.DwellingConstructionType_LabelAndValue.Item2, true, 1);
            }

            if (!string.IsNullOrEmpty(commonFunctions.DwellingBuildingType_LabelAndValue.Item2))
            {
                var buildingType = string.Format(BuildingType_Radio, commonFunctions.DwellingBuildingType_LabelAndValue.Item2);
                await RadioButton.SelectRadioButtonAsync(buildingType, commonFunctions.DwellingBuildingType_LabelAndValue.Item2, true, 1);
            }

            await DropDown.SelectDropDownAsync(TotalNumber_Drp, commonFunctions.DwellingTotalNumberOfLiving_LabelAndValue.Item2, true, 1);
            await DropDown.SelectDropDownAsync(NumberUnits_Drp, commonFunctions.DwellingNumberOfUnits_LabelAndValue.Item2, true, 1);
            var dwellingVacant = string.Format(DwellingVacant_Radio, commonFunctions.DwellingVacant_LabelAndValue.Item2);
            await RadioButton.SelectRadioButtonAsync(dwellingVacant, commonFunctions.DwellingVacant_LabelAndValue.Item2, true, 1);

            var dwellingBuilding = string.Format(BuildingConstruction_Radio, commonFunctions.DwellingBuildingUnderConstruction_LabelAndValue.Item2);
            await RadioButton.SelectRadioButtonAsync(dwellingBuilding, commonFunctions.DwellingBuildingUnderConstruction_LabelAndValue.Item2, true, 1);

            var dwellingRenovation = string.Format(Renovation_Radio, commonFunctions.DwellingRenovation_LabelAndValue.Item2);
            await RadioButton.SelectRadioButtonAsync(dwellingRenovation, commonFunctions.DwellingRenovation_LabelAndValue.Item2, true, 1);
            await DropDown.SelectDropDownAsync(OccupancyType_Drp, commonFunctions.DwellingOccupancyType_LabelAndValue.Item2, true, 1);
            await DropDown.SelectDropDownAsync(OccupiedBy_Drp, commonFunctions.DwellingOccupiedBy_LabelAndValue.Item2, true, 1);
            await DropDown.SelectDropDownAsync(PrimaryHeatType_Drp, commonFunctions.DwellingPrimaryHeatType_LabelAndValue.Item2, true, 1);
            var dwellingRoofPeaked = string.Format(RoofPeaked_Radio, commonFunctions.DwellingRoofPeaked_LabelAndValue.Item2);
            await RadioButton.SelectRadioButtonAsync(dwellingRoofPeaked, commonFunctions.DwellingRoofPeaked_LabelAndValue.Item2, true, 1);
            var dwellingAsbestos = string.Format(BuildingAsbestos_Radio, commonFunctions.DwellingBuildingAsbestos_LabelAndValue.Item2);
            await RadioButton.SelectRadioButtonAsync(dwellingAsbestos, commonFunctions.DwellingBuildingAsbestos_LabelAndValue.Item2, true, 1);
            var dwellingPropertyLocated = string.Format(PropertyLocated_Radio, commonFunctions.DwellingPropertyLocated_LabelAndValue.Item2);
            await RadioButton.SelectRadioButtonAsync(dwellingPropertyLocated, commonFunctions.DwellingPropertyLocated_LabelAndValue.Item2, true, 1);
            var dwellingDogsLocation = string.Format(DogsLocation_Radio, commonFunctions.DwellingDogsLocation_LabelAndValue.Item2);
            await RadioButton.SelectRadioButtonAsync(dwellingDogsLocation, commonFunctions.DwellingDogsLocation_LabelAndValue.Item2, true, 1);
            var dwellingAnimalLocation = string.Format(AnimalLocation_Radio, commonFunctions.DwellingAnimalLocation_LabelAndValue.Item2);
            await RadioButton.SelectRadioButtonAsync(dwellingAnimalLocation, commonFunctions.DwellingAnimalLocation_LabelAndValue.Item2, true, 1);
            var dwellingLocationFiveYears = string.Format(MoreFiveAcre_Radio, commonFunctions.DwellingLocationMoreThanFiveYears_LabelAndValue.Item2);
            await RadioButton.SelectRadioButtonAsync(dwellingLocationFiveYears, commonFunctions.DwellingLocationMoreThanFiveYears_LabelAndValue.Item2, true, 1);
            var fireBuildingViolations = string.Format(FireBuildingViolations_Radio, commonFunctions.DwellingLocationUncorrectedFire_LabelAndValue.Item2);
            await RadioButton.SelectRadioButtonAsync(fireBuildingViolations, commonFunctions.DwellingLocationUncorrectedFire_LabelAndValue.Item2, true, 1);
            var dwellingTrampoline = string.Format(Trampoline_Radio, commonFunctions.DwellingTrampoline_LabelAndValue.Item2);
            await RadioButton.SelectRadioButtonAsync(dwellingTrampoline, commonFunctions.DwellingTrampoline_LabelAndValue.Item2, true, 1);
            var structureConverted = string.Format(StructureConverted_Radio, commonFunctions.DwellingStructureConverted_LabelAndValue.Item2);
            await RadioButton.SelectRadioButtonAsync(structureConverted, commonFunctions.DwellingStructureConverted_LabelAndValue.Item2, true, 1);
            var address911 = string.Format(Address911_Radio, commonFunctions.Dwelling911address_LabelAndValue.Item2);
            await RadioButton.SelectRadioButtonAsync(address911, commonFunctions.Dwelling911address_LabelAndValue.Item2, true, 1);
            await InputField.SetTextAreaInputFieldAsync(Drivingdirections, commonFunctions.DwellingDrivingdirections_LabelAndValue.Item2, true, 1);
            var swimmingPool = string.Format(SwimmingPool_Radio, commonFunctions.DwellingSwimmingPool_LabelAndValue.Item2);
            await RadioButton.SelectRadioButtonAsync(swimmingPool, commonFunctions.DwellingSwimmingPool_LabelAndValue.Item2, true, 1);
            var zipline = string.Format(Zipline_Radio, commonFunctions.DwellingSwimmingPool_LabelAndValue.Item2);
            await RadioButton.SelectRadioButtonAsync(zipline, commonFunctions.DwellingSwimmingPool_LabelAndValue.Item2, true, 1);
            await InputField.SetTextAreaInputFieldAsync(Fireplaces, commonFunctions.DwellingFireplaces_LabelAndValue.Item2, true, 1);
            if (commonFunctions.DwellingLPGasHeater_LabelAndValue.Item2 == "Yes")
            {
                var lpgasHeater = string.Format(LPGasHeater, commonFunctions.DwellingLPGasHeater_LabelAndValue.Item2);
                await Checkbox.SelectCheckboxAsync(lpgasHeater, true, true, 1);
            }

            await Button.ClickButtonAsync(LimitsCoveragesDiscountsButton, ActionType.Click, true, 1);
            await InputField.SetTextAreaInputFieldAsync(CoverageAResidence, commonFunctions.DwellingCoverageAResidence_LabelAndValue.Item2, true, 1);
            if (!string.IsNullOrEmpty(commonFunctions.DwellingCoverageBOtherStructures_LabelAndValue.Item2))
            {
                await DropDown.SelectDropDownAsync(CoverageBOtherStructures, commonFunctions.DwellingCoverageBOtherStructures_LabelAndValue.Item2, true, 1);
            }

            await InputField.SetTextAreaInputFieldAsync(CoverageCPersonalProperty, commonFunctions.DwellingCoverageCPersonalProperty_LabelAndValue.Item2, true, 1);
            if (!string.IsNullOrEmpty(commonFunctions.DwellingCoverageDAdditionalLimit_LabelAndValue.Item2))
            {
                await InputField.SetTextAreaInputFieldAsync(CoverageDAdditionalLimit, commonFunctions.DwellingCoverageDAdditionalLimit_LabelAndValue.Item2, true, 1);
            }

            await InputField.SetTextAreaInputFieldAsync(EarthquakeLossAssessment, commonFunctions.DwellingEarthquakeLossAssessment_LabelAndValue.Item2, true, 1);
            var earthquake = string.Format(Earthquake, commonFunctions.DwellingEarthquake_LabelAndValue.Item2);
            await RadioButton.SelectRadioButtonAsync(earthquake, commonFunctions.DwellingEarthquake_LabelAndValue.Item2, true, 1);
            await page.EvaluateAsync("window.scrollTo(0,0)");
            await page.WaitForTimeoutAsync(5000);
            await Button.ClickButtonAsync(AuxUnit1, ActionType.Click, true, 1);
            if (commonFunctions.DwellingAuxiliaryHeatingSystem1_LabelAndValue.Item2 =="FI")
            {
                var auxiliaryHS = string.Format(AuxiliaryHeatingSystem1, commonFunctions.DwellingAuxiliaryHeatingSystem1_LabelAndValue.Item2);
                await RadioButton.SelectRadioButtonAsync(auxiliaryHS, commonFunctions.DwellingAuxiliaryHeatingSystem1_LabelAndValue.Item2, true, 1);
            }
            else
            {
                var auxiliaryHS = string.Format(AuxiliaryHeatingSystem1, commonFunctions.DwellingAuxiliaryHeatingSystem1_LabelAndValue.Item2);
                await RadioButton.SelectRadioButtonAsync(auxiliaryHS, commonFunctions.DwellingAuxiliaryHeatingSystem1_LabelAndValue.Item2, true, 1);
            }

            await Button.ClickButtonAsync(ContinueButton, ActionType.Click, true, 1);
            await page.WaitForLoadStateAsync(LoadState.DOMContentLoaded);
        }
    }
}

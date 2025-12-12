using BDD.Playwright.Core.Interfaces;
using BDD.Playwright.GBIZ.PageElements;
using BDD.Playwright.GBIZ.Pages.CommonPage;
using BDD.Playwright.GBIZ.Pages.GlobalPages;
using BDD.Playwright.GBIZ.Pages.XpathProperties;
using Microsoft.Playwright;
using Reqnroll;

namespace BDD.Playwright.Origami.Pages.AgentPages
{
    public class Quote_DwellingPage : BasePage
    {
        private readonly ScenarioContext _scenarioContext;
        public FeatureContext _featureContext;
        public CommonXpath _commonXpath;
        public LoginPage _loginPage;
        private readonly IFileReader _fileReader;
        public Quote_DwellingPage(
            ScenarioContext scenarioContext,
            LoginPage loginPage,
            CommonXpath commonXpath,
            IFileReader fileReader) : base(scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _loginPage = loginPage;
            _commonXpath = commonXpath;
            _fileReader = fileReader;
        }

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
        public string Trampoline_Radio { get; set; } = "//input[@name='bld_isTrampoline_1' and @value='{0}']";
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

        public async Task DwellingDatafillAsync(string profileKey)
        {
            var filePath = "QuoteDwellingPage\\QuoteDwellingPage.json";

            var protectValue = _fileReader.GetOptionalValue(filePath, $"{profileKey}.Protection");
            if (!string.IsNullOrEmpty(protectValue))
            {
                await DropDown.SelectDropDownAsync(Protection_Drp, protectValue, true, 1);
            }

            var streetValue = _fileReader.GetOptionalValue(filePath, $"{profileKey}.StreetAddress");
            if (!string.IsNullOrEmpty(streetValue))
            {
                await InputField.SetTextAreaInputFieldAsync(StreetAddress, streetValue, true, 1);
            }

            var cityValue = _fileReader.GetOptionalValue(filePath, $"{profileKey}.City");
            if (!string.IsNullOrEmpty(cityValue))
            {
                await InputField.SetTextAreaInputFieldAsync(City, cityValue, true, 1);
            }

            var zipValue = _fileReader.GetOptionalValue(filePath, $"{profileKey}.ZipCode");
            if (!string.IsNullOrEmpty(zipValue))
            {
                await InputField.SetTextAreaInputFieldAsync(ZipCode, zipValue, true, 1);
            }

            var fireDeptValue = _fileReader.GetOptionalValue(filePath, $"{profileKey}.RespondingFireDepartment");
            if (!string.IsNullOrEmpty(fireDeptValue))
            {
                await InputField.SetTextAreaInputFieldAsync(RespondingFireDepartment, fireDeptValue, true, 1);
            }

            var yearConstrValue = _fileReader.GetOptionalValue(filePath, $"{profileKey}.Yearofconstruction");
            if (!string.IsNullOrEmpty(yearConstrValue))
            {
                await InputField.SetTextAreaInputFieldAsync(YearOfConstruction, yearConstrValue, true, 1);
            }

            var constrTypeValue = _fileReader.GetOptionalValue(filePath, $"{profileKey}.ConstructionType");
            if (!string.IsNullOrEmpty(constrTypeValue))
            {
                var radio = string.Format(ConstructionType_Radio, constrTypeValue);
                await RadioButton.SelectRadioButtonAsync(radio,"value", true, 1);
            }

            var buildingTypeValue = _fileReader.GetOptionalValue(filePath, $"{profileKey}.BuildingType");
            if (!string.IsNullOrEmpty(buildingTypeValue))
            {
                var radio = string.Format(BuildingType_Radio, buildingTypeValue);
                await RadioButton.SelectRadioButtonAsync(radio,"value", true, 1);
            }

            var totalUnitsValue = _fileReader.GetOptionalValue(filePath, $"{profileKey}.Totalnumberoflivingunitsinthebuilding");
            if (!string.IsNullOrEmpty(totalUnitsValue))
            {
                await DropDown.SelectDropDownAsync(TotalNumber_Drp, totalUnitsValue, true, 1);
            }

            var numberUnitsValue = _fileReader.GetOptionalValue(filePath, $"{profileKey}.Numberofunitsownedbytheinsured");
            if (!string.IsNullOrEmpty(numberUnitsValue))
            {
                await DropDown.SelectDropDownAsync(NumberUnits_Drp, numberUnitsValue, true, 1);
            }

            var vacantValue = _fileReader.GetOptionalValue(filePath, $"{profileKey}.Isthedwellingvacantorunoccupied");
            if (!string.IsNullOrEmpty(vacantValue))
            {
                var radio = string.Format(DwellingVacant_Radio, vacantValue);
                await RadioButton.SelectRadioButtonAsync(radio,"value", true, 1);
            }

            var underConstructionValue = _fileReader.GetOptionalValue(filePath, $"{profileKey}.Isthebuildingunderconstruction");
            if (!string.IsNullOrEmpty(underConstructionValue))
            {
                var radio = string.Format(BuildingConstruction_Radio, underConstructionValue);
                await RadioButton.SelectRadioButtonAsync(radio,"value", true, 1);
            }

            var renovationValue = _fileReader.GetOptionalValue(filePath, $"{profileKey}.Isbuildingundergoingrenovationorreconstruction");
            if (!string.IsNullOrEmpty(renovationValue))
            {
                var radio = string.Format(Renovation_Radio, renovationValue);
                await RadioButton.SelectRadioButtonAsync(radio,"value", true, 1);
            }

            var occupancyTypeValue = _fileReader.GetOptionalValue(filePath, $"{profileKey}.OccupancyType");
            if (!string.IsNullOrEmpty(occupancyTypeValue))
            {
                await DropDown.SelectDropDownAsync(OccupancyType_Drp, occupancyTypeValue, true, 1);
            }

            var occupiedByValue = _fileReader.GetOptionalValue(filePath, $"{profileKey}.OccupiedBy");
            if (!string.IsNullOrEmpty(occupiedByValue))
            {
                await DropDown.SelectDropDownAsync(OccupiedBy_Drp, occupiedByValue, true, 1);
            }

            var primaryHeatTypeValue = _fileReader.GetOptionalValue(filePath, $"{profileKey}.Primaryheattype");
            if (!string.IsNullOrEmpty(primaryHeatTypeValue))
            {
                await DropDown.SelectDropDownAsync(PrimaryHeatType_Drp, primaryHeatTypeValue, true, 1);
            }

            var peakedRoofValue = _fileReader.GetOptionalValue(filePath, $"{profileKey}.Istheroofpeaked");
            if (!string.IsNullOrEmpty(peakedRoofValue))
            {
                var radio = string.Format(RoofPeaked_Radio, peakedRoofValue);
                await RadioButton.SelectRadioButtonAsync(radio,"value", true, 1);
            }

            var asbestosValue = _fileReader.GetOptionalValue(filePath, $"{profileKey}.Doesthebuildinghaveanyasbestos");
            if (!string.IsNullOrEmpty(asbestosValue))
            {
                var radio = string.Format(BuildingAsbestos_Radio, asbestosValue);
                await RadioButton.SelectRadioButtonAsync(radio,"value", true, 1);
            }

            var propertyLocatedValue = _fileReader.GetOptionalValue(filePath, $"{profileKey}.Isthepropertylocatedwithintwomilesoftidalwater");
            if (!string.IsNullOrEmpty(propertyLocatedValue))
            {
                var radio = string.Format(PropertyLocated_Radio, propertyLocatedValue);
                await RadioButton.SelectRadioButtonAsync(radio,"value", true, 1);
            }

            var dogsLocationValue = _fileReader.GetOptionalValue(filePath, $"{profileKey}.Arethereanydogatthislocation");
            if (!string.IsNullOrEmpty(dogsLocationValue))
            {
                var radio = string.Format(DogsLocation_Radio, dogsLocationValue);
                await RadioButton.SelectRadioButtonAsync(radio,"value", true, 1);
            }

            var animalLocationValue = _fileReader.GetOptionalValue(filePath, $"{profileKey}.Arethereanyanimalsorexoticpetskeptatthislocation");
            if (!string.IsNullOrEmpty(animalLocationValue))
            {
                var radio = string.Format(AnimalLocation_Radio, animalLocationValue);
                await RadioButton.SelectRadioButtonAsync(radio,"value", true, 1);
            }

            var moreFiveAcresValue = _fileReader.GetOptionalValue(filePath, $"{profileKey}.Isthislocationsituatedonmorethanfiveacres");
            if (!string.IsNullOrEmpty(moreFiveAcresValue))
            {
                var radio = string.Format(MoreFiveAcre_Radio, moreFiveAcresValue);
                await RadioButton.SelectRadioButtonAsync(radio,"value", true, 1);
            }

            var fireViolationsValue = _fileReader.GetOptionalValue(filePath, $"{profileKey}.Doeslocationhaveanyuncorrectedfireorbuildingcodeviolations");
            if (!string.IsNullOrEmpty(fireViolationsValue))
            {
                var radio = string.Format(FireBuildingViolations_Radio, fireViolationsValue);
                await RadioButton.SelectRadioButtonAsync(radio, "value", true, 1);
            }

            var trampolineValue = _fileReader.GetOptionalValue(filePath, $"{profileKey}.Istheretrampolineatthislocation");
            if (!string.IsNullOrEmpty(trampolineValue))
            {
                var radio = string.Format(Trampoline_Radio, trampolineValue);
                await RadioButton.SelectRadioButtonAsync(radio,"value", true, 1);
            }

            var structureConvertedValue = _fileReader.GetOptionalValue(filePath, $"{profileKey}.Wereanystructuresatthislocationoriginallybuilt");
            if (!string.IsNullOrEmpty(structureConvertedValue))
            {
                var radio = string.Format(StructureConverted_Radio, structureConvertedValue);
                await RadioButton.SelectRadioButtonAsync(radio,"value", true, 1);
            }

            var address911Value = _fileReader.GetOptionalValue(filePath, $"{profileKey}.Isthis911address");
            if (!string.IsNullOrEmpty(address911Value))
            {
                var radio = string.Format(Address911_Radio, address911Value);
                await RadioButton.SelectRadioButtonAsync(radio,"value", true, 1);
            }

            var drivingDirectionsValue = _fileReader.GetOptionalValue(filePath, $"{profileKey}.Drivingdirections");
            if (!string.IsNullOrEmpty(drivingDirectionsValue))
            {
                await InputField.SetTextAreaInputFieldAsync(Drivingdirections, drivingDirectionsValue, true, 1);
            }

            var swimmingPoolValue = _fileReader.GetOptionalValue(filePath, $"{profileKey}.Isthereswimmingpoolonthepremises");
            if (!string.IsNullOrEmpty(swimmingPoolValue))
            {
                var radio = string.Format(SwimmingPool_Radio, swimmingPoolValue);
                await RadioButton.SelectRadioButtonAsync(radio,"value", true, 1);
            }

            var zipLineValue = _fileReader.GetOptionalValue(filePath, $"{profileKey}.Isthereziplineonpremises");
            if (!string.IsNullOrEmpty(zipLineValue))
            {
                var radio = string.Format(Zipline_Radio, zipLineValue);
                await RadioButton.SelectRadioButtonAsync(radio,"value", true, 1);
            }

            var fireplacesValue = _fileReader.GetOptionalValue(filePath, $"{profileKey}.NumberofBuiltFireplaces");
            if (!string.IsNullOrEmpty(fireplacesValue))
            {
                await InputField.SetTextAreaInputFieldAsync(Fireplaces, fireplacesValue, true, 1);
            }

            var lpGasHeaterValue = _fileReader.GetOptionalValue(filePath, $"{profileKey}.LPgasHeater");
            if (!string.IsNullOrEmpty(lpGasHeaterValue) && lpGasHeaterValue == "Yes")
            {
                var checkbox = string.Format(LPGasHeater, lpGasHeaterValue);
                await Checkbox.SelectCheckboxAsync(checkbox, true, true, 1, "LPgasHeater");
            }

            await Button.ClickButtonAsync(LimitsCoveragesDiscountsButton, ActionType.Click, true, 1);

            var coverageAResidenceValue = _fileReader.GetOptionalValue(filePath, $"{profileKey}.CoverageAResidence");
            if (!string.IsNullOrEmpty(coverageAResidenceValue))
            {
                await InputField.SetTextAreaInputFieldAsync(CoverageAResidence, coverageAResidenceValue, true, 1);
            }

            var coverageBOtherStructuresValue = _fileReader.GetOptionalValue(filePath, $"{profileKey}.CoverageBOtherStructures");
            if (!string.IsNullOrEmpty(coverageBOtherStructuresValue))
            {
                await DropDown.SelectDropDownAsync(CoverageBOtherStructures, coverageBOtherStructuresValue, true, 1);
            }

            var coverageCPersonalPropertyValue = _fileReader.GetOptionalValue(filePath, $"{profileKey}.CoverageCOtherStructures");
            if (!string.IsNullOrEmpty(coverageCPersonalPropertyValue))
            {
                await InputField.SetTextAreaInputFieldAsync(CoverageCPersonalProperty, coverageCPersonalPropertyValue, true, 1);
            }

            var coverageDAdditionalLimitValue = _fileReader.GetOptionalValue(filePath, $"{profileKey}.CoverageDAdditionalLimit");
            if (!string.IsNullOrEmpty(coverageDAdditionalLimitValue))
            {
                await InputField.SetTextAreaInputFieldAsync(CoverageDAdditionalLimit, coverageDAdditionalLimitValue, true, 1);
            }

            var earthquakeLossAssessmentValue = _fileReader.GetOptionalValue(filePath, $"{profileKey}.EarthquakeLossAssessment");
            if (!string.IsNullOrEmpty(earthquakeLossAssessmentValue))
            {
                await InputField.SetTextAreaInputFieldAsync(EarthquakeLossAssessment, earthquakeLossAssessmentValue, true, 1);
            }

            var earthquakeValue = _fileReader.GetOptionalValue(filePath, $"{profileKey}.Earthquake");
            if (!string.IsNullOrEmpty(earthquakeValue))
            {
                var radio = string.Format(Earthquake, earthquakeValue);
                await RadioButton.SelectRadioButtonAsync(radio, "value", true, 1);
            }

            //await _commonFunctions.ScrollUpAsync();
            await Button.ScrollIntoViewAsync(AuxUnit1, true, 1);
            await Button.ClickButtonAsync(AuxUnit1, ActionType.Click, true, 1);

            var auxiliaryHeatingSystem1Value = _fileReader.GetOptionalValue(filePath, $"{profileKey}.AuxiliaryHeatingSystem1");
            if (!string.IsNullOrEmpty(auxiliaryHeatingSystem1Value))
            {
                var radio = string.Format(AuxiliaryHeatingSystem1, auxiliaryHeatingSystem1Value);
                await RadioButton.SelectRadioButtonAsync(radio, "value", true, 1);
            }

            await Button.ClickButtonAsync(ContinueButton, ActionType.Click, true, 1);
          
        }
    }
}
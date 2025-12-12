using BDD.Playwright.Core.Interfaces;
using BDD.Playwright.GBIZ.PageElements;
using BDD.Playwright.GBIZ.Pages.CommonPage;
using BDD.Playwright.GBIZ.Pages.GlobalPages;
using BDD.Playwright.GBIZ.Pages.XpathProperties;
using Microsoft.Playwright;
using Reqnroll;

namespace bdd.playwright.gbiz.pages.agentpages
{
    public class Quote_BuildingPage : BasePage
    {
        private readonly ScenarioContext _scenariocontext;
        public FeatureContext _featurecontext;
        public CommonXpath _commonxpath;
        private readonly IFileReader _fileReader;
        public LoginPage _loginpage;
        // constructor
        public Quote_BuildingPage(ScenarioContext scenariocontext, LoginPage loginpage, CommonXpath commonxpath, IFileReader fileReader) : base(scenariocontext)
        {
            _scenariocontext = scenariocontext;
            _loginpage = loginpage;
            _commonxpath = commonxpath;
            _fileReader = fileReader;
        }
        #region xpath
        public string Addbuilding { get; set; } = "//a[text()='Add Building']";
        public string Location_drp { get; set; } = "//select[@name='bld_location_1' and @id='fld_bld_location_1']";
        public string Description_input { get; set; } = "//input[@id='fld_bld_description_1']";
        public string Checkallthatarelocated_radio { get; set; } = "//input[(@class='inputcheckbox') and @value='{0}']";

        public string Insuredownbuilding_radio { get; set; } = "//input[contains(@name,'bld_insuredOwnBuilding_1')  and @value='{0}']";
        public string Totalsquarefootage_input { get; set; } = "//input[contains(@id,'fld_bld_totalSquareFootage_1')]";

        public string Constructiontype_drp { get; set; } = "//select[@name='bld_constructionType_1' and @id='fld_bld_constructionType_1']";

        public string Isthisacondounit_radio { get; set; } = "//input[contains(@name,bld_condoUnit_1)  and @value='{0}']";

        public string IsthisacondoUnit_radio { get; set; } = "//*[@id='fld_no_bld_condoUnit_1']";
        public string Numberofstories_input { get; set; } = "//input[contains(@id,'fld_bld_numberOfStories_1')]";

        public string Limit_tab { get; set; } = "//div[@id='buildingLimits_head']";

        public string Continue_btn { get; set; } = "//button[contains(text(),'Continue')]";

        public string Building_input { get; set; } = "//input[contains(@id,'fld_bld_buildingLimit_1')]";

        public string Buildingdeductible_drP { get; set; } = "//select[@name='bld_buildingDeductible_1' and @id='fld_bld_buildingDeductible_1']";

        public string Buildingwindhaildeductible_drp { get; set; } = "//select[@name='bld_whBldDeductible_1' and @id='fld_bld_whBldDeductible_1']";

        public string Buildingpersonalproperty_limit { get; set; } = "//input[contains(@id,'fld_bld_personalPropertyLimit_1')]";

        public string Buildingpersonalpropertydeductible_drp { get; set; } = "//select[@name='bld_personalPropertyDeductible_1' and @id='fld_bld_personalPropertyDeductible_1']";
        public string Buildingrating_tab { get; set; } = "//div[@id='buildingRatingInformation_head']";

        public string Doesbuildinghavesprinklers { get; set; } = "//input[contains(@name,'bld_riSprinklers_1')  and @value='{0}']";

        public string Bld_rilessthan100amp_radio { get; set; } = "//input[contains(@name,'bld_riLessThan100Amp_1')  and @value='{0}']";

        public string Heatexist_checkboxlabel { get; set; } = "//input[contains(@name,'cbG_bld_riSourcesOfHeat_1')  and @value='G']";
        public string Yearheatsourceupdated_input { get; set; } = "//input[contains(@id,'fld_bld_riYearHeatSourceUpdated_1')]";
        public string Localpropertymanager_radio { get; set; } = "//input[contains(@name,'bld_riLocalPropertyManager_1')  and @value='{0}']";
        public string Yearofconstruction_input { get; set; } = "//input[contains(@id,'fld_bld_riYearOfConstruction_1')]";

        public string Valueofbuildinglisted100percent_radio { get; set; } = "//input[contains(@name, 'bld_riValueOfBuildingListed100Percent_1')  and @value = '{0}']";

        public string Roofpeaked_radio { get; set; } = "//input[contains(@name,'bld_riRoofPeaked_1')  and @value='{0}']";

        public string Portionofroofmaterial_radio { get; set; } = "//input[contains(@name,'bld_riPortionOfRoofMaterial_1')  and @value='{0}']";

        public string Nearfloodzone_radio { get; set; } = "//input[contains(@name,'bld_riNearFloodzone_1')  and @value='{0}']";

        public string Buildingismobilehome_radio { get; set; } = "//input[contains(@name,'bld_riBuildingIsMobileHome_1')  and @value='{0}']";
        public string Buildingistownhouse_radio { get; set; } = "//input[contains(@name,'bld_riBuildingIsTownHouse_1')  and @value='{0}']";
        public string Extendedunoccupied_radio { get; set; } = "//input[contains(@name,'bld_riExtendedUnoccupied_1')  and @value='{0}']";
        public string Hasasbestos_radio { get; set; } = "//input[contains(@name,'bld_riHasAsbestos_1')  and @value='{0}']";

        public string Doorswindowsgoodrepair_radio { get; set; } = "//input[contains(@name,'bld_riDoorsWindowsGoodRepair_1')  and @value='{0}']";

        public string Otheroccupanciesonpremises_radio { get; set; } = "//input[contains(@name,'bld_riOtherOccupanciesOnPremises_1')  and @value='{0}']";

        public string Buildingtotalsquarefootage_input { get; set; } = "//input[contains(@id,'fld_bld_riTotalSquareFootage_1')]";
        public string Workingsmokedetectorsinplace_radio { get; set; } = "//input[contains(@name,'bld_riWorkingSmokeDetectorsInPlace_1')  and @value='{0}']";

        public string Fireextinguishersinplace_radio { get; set; } = "//input[contains(@name,'bld_riFireExtinguishersInPlace_1')  and @value='{0}']";

        public string Securitysystem2_radio { get; set; } = "//input[contains(@name,'bld_riSecuritySystem2_1')  and @value='{0}']";

        public string Aptrentsquarefootage_input { get; set; } = "//input[contains(@id,'fld_bld_riAPTRENTSquareFootage_1')]";

        public string Aptrentoccupiedbyinsured_radio { get; set; } = "//input[contains(@name,'bld_riAPTRENTOccupiedByInsured_1')  and @value='{0}']";

        public string Numberofunits_input { get; set; } = "//input[contains(@id,'fld_bld_riNumberOfUnits_1')]";

        public string Numberofunitsownedbyinsured_input { get; set; } = "//input[contains(@id,'fld_bld_riNumberOfUnitsOwnedByInsured_1')]";

        public string Studenthousing_radio { get; set; } = "//input[contains(@name,'bld_riStudentHousing_1')  and @value='{0}']";

        public string Insurediscondoassociation_radio { get; set; } = "//input[contains(@name,'bld_riInsuredIsCondoAssociation_1')  and @value='{0}']";
        public string Heldforsale_radio { get; set; } = "//input[contains(@name,'bld_riHeldForSale_1')  and @value='{0}']";

        public string Leasetype_drp { get; set; } = "//select[@name='bld_riLeaseType_1' and @id='fld_bld_riLeaseType_1']";

        #endregion
        public async Task BuildingDataFillAsync(string profileKey)
        {
            if (_fileReader == null)
            {
                throw new InvalidOperationException("FileReader is not available. Use constructor with IFileReader parameter.");
            }

            var filePath = "QuoteBuildingPage\\QuoteBuildingPage.json";

            try
            {
                logger.WriteLine($"Starting Building data fill using JSON profile: {profileKey}");

                var Location_drp_value = _fileReader.GetOptionalValue(filePath, $"{profileKey}.Location");
                var Description_input_value = _fileReader.GetOptionalValue(filePath, $"{profileKey}.Description");
                var Checkallthatarelocated_radio_value = _fileReader.GetOptionalValue(filePath, $"{profileKey}.CheckAllThatAreLocated");
                var Insuredownbuilding_radio_value = _fileReader.GetOptionalValue(filePath, $"{profileKey}.InsuredOwnBuilding");
                var Totalsquarefootage_input_value = _fileReader.GetOptionalValue(filePath, $"{profileKey}.TotalSquareFootage");
                var Constructiontype_drp_value = _fileReader.GetOptionalValue(filePath, $"{profileKey}.Constructiontype");
                var Isthisacondounit_radio_value = _fileReader.GetOptionalValue(filePath, $"{profileKey}.IsthisACondoUnit");
                var Numberofstories_input_value = _fileReader.GetOptionalValue(filePath, $"{profileKey}.NumberOfStories");
                var Building_input_value = _fileReader.GetOptionalValue(filePath, $"{profileKey}.Buildinginput");
                var Buildingdeductible_drP_value = _fileReader.GetOptionalValue(filePath, $"{profileKey}.Buildingdeductibledrp");
                var Buildingwindhaildeductible_drp_value = _fileReader.GetOptionalValue(filePath, $"{profileKey}.Buildingwindhaildeductibledrp");
                var Buildingpersonalproperty_limit_value = _fileReader.GetOptionalValue(filePath, $"{profileKey}.BuildingpersonalPropertyLimitdrp");
                var Buildingpersonalpropertydeductible_drp_value = _fileReader.GetOptionalValue(filePath, $"{profileKey}.BuildingpersonalPropertyDeductibledrp");
                var Doesbuildinghavesprinklers_value = _fileReader.GetOptionalValue(filePath, $"{profileKey}.BuildingDoesbuildinghavesprinklers");
                var Bld_rilessthan100amp_radio_value = _fileReader.GetOptionalValue(filePath, $"{profileKey}.bld_riLessThan100Amp_Radio");
                var Heatexist_checkboxlabel_value = _fileReader.GetOptionalValue(filePath, $"{profileKey}.heatexist_checkboxlabel");
                var Yearheatsourceupdated_input_value = _fileReader.GetOptionalValue(filePath, $"{profileKey}.YearHeatSourceUpdated");
                var Localpropertymanager_radio_value = _fileReader.GetOptionalValue(filePath, $"{profileKey}.localPropertyManager");
                var Yearofconstruction_input_value = _fileReader.GetOptionalValue(filePath, $"{profileKey}.YearOfConstruction");
                var Valueofbuildinglisted100percent_radio_value = _fileReader.GetOptionalValue(filePath, $"{profileKey}.ValueOfBuildingListed100Percent");
                var Roofpeaked_radio_value = _fileReader.GetOptionalValue(filePath, $"{profileKey}.RoofPeaked");
                var Portionofroofmaterial_radio_value = _fileReader.GetOptionalValue(filePath, $"{profileKey}.PortionOfRoofMaterial");
                var Nearfloodzone_radio_value = _fileReader.GetOptionalValue(filePath, $"{profileKey}.NearFloodzone");
                var Buildingismobilehome_radio_value = _fileReader.GetOptionalValue(filePath, $"{profileKey}.IsMobileHome");
                var Buildingistownhouse_radio_value = _fileReader.GetOptionalValue(filePath, $"{profileKey}.IsTownHouse");
                var Extendedunoccupied_radio_value = _fileReader.GetOptionalValue(filePath, $"{profileKey}.ExtendedUnoccupied");
                var Hasasbestos_radio_value = _fileReader.GetOptionalValue(filePath, $"{profileKey}.HasAsbestos");
                var Doorswindowsgoodrepair_radio_value = _fileReader.GetOptionalValue(filePath, $"{profileKey}.DoorsWindowsGoodRepair");
                var Otheroccupanciesonpremises_radio_value = _fileReader.GetOptionalValue(filePath, $"{profileKey}.OtherOccupanciesOnPremises");
                var Buildingtotalsquarefootage_input_value = _fileReader.GetOptionalValue(filePath, $"{profileKey}.TotalSquareFootage");
                var Workingsmokedetectorsinplace_radio_value = _fileReader.GetOptionalValue(filePath, $"{profileKey}.WorkingSmokeDetectorsInPlace");
                var Fireextinguishersinplace_radio_value = _fileReader.GetOptionalValue(filePath, $"{profileKey}.FireExtinguishersInPlace");
                var Securitysystem2_radio_value = _fileReader.GetOptionalValue(filePath, $"{profileKey}.SecuritySystem2");
                var Aptrentsquarefootage_input_value = _fileReader.GetOptionalValue(filePath, $"{profileKey}.APTRENTSquareFootage");
                var Aptrentoccupiedbyinsured_radio_value = _fileReader.GetOptionalValue(filePath, $"{profileKey}.APTRENTOccupiedByInsured");
                var Numberofunits_input_value = _fileReader.GetOptionalValue(filePath, $"{profileKey}.NumberOfUnits");
                var Numberofunitsownedbyinsured_input_value = _fileReader.GetOptionalValue(filePath, $"{profileKey}.NumberOfUnitsOwnedByInsured");
                var Studenthousing_radio_value = _fileReader.GetOptionalValue(filePath, $"{profileKey}.StudentHousing_Radio");
                var Insurediscondoassociation_radio_value = _fileReader.GetOptionalValue(filePath, $"{profileKey}.InsuredIsCondoAssociation");
                var Heldforsale_radio_value = _fileReader.GetOptionalValue(filePath, $"{profileKey}.HeldForSale");
                var Leasetype_drp_value = _fileReader.GetOptionalValue(filePath, $"{profileKey}.LeaseType");

                await Button.ClickButtonAsync(Addbuilding, ActionType.Click, true, 1);
                await DropDown.SelectDropDownAsync(Location_drp, Location_drp_value, true, 1);
                await InputField.SetTextAreaInputFieldAsync(Description_input, Description_input_value, true, 1);

                if (!string.IsNullOrEmpty(Checkallthatarelocated_radio_value))
                {
                    await RadioButton.SelectRadioButtonAsync(string.Format(Checkallthatarelocated_radio, Checkallthatarelocated_radio_value), "value", true, 1);
                }

                if (!string.IsNullOrEmpty(Insuredownbuilding_radio_value))
                {
                    await page.WaitForLoadStateAsync(LoadState.NetworkIdle);
                    await RadioButton.SelectRadioButtonAsync(string.Format(Insuredownbuilding_radio, Insuredownbuilding_radio_value), "Yes", true, 1);
                    await page.WaitForLoadStateAsync(LoadState.NetworkIdle);
                }

                await InputField.SetTextAreaInputFieldAsync(Totalsquarefootage_input, Totalsquarefootage_input_value, true, 1);
                await DropDown.SelectDropDownAsync(Constructiontype_drp, Constructiontype_drp_value, true,1);

                if (!string.IsNullOrEmpty(Isthisacondounit_radio_value))
                {
                    await RadioButton.SelectRadioButtonAsync(string.Format(IsthisacondoUnit_radio, Isthisacondounit_radio_value), "No", true, 1);
                }

                await InputField.SetTextAreaInputFieldAsync(Numberofstories_input, Numberofstories_input_value, true, 1);

                await Button.ClickButtonAsync(_commonxpath.Save_btn, ActionType.Click, true, 1);
                await Task.Delay(5000);
                var radioLocator = page.Locator(string.Format(Insuredownbuilding_radio, Insuredownbuilding_radio_value));
                var isChecked = await radioLocator.IsCheckedAsync();
                if (!isChecked)
                {
                    // Try selecting again or throw an error/assert
                    await RadioButton.SelectRadioButtonAsync(string.Format(Insuredownbuilding_radio, Insuredownbuilding_radio_value), "Yes", true, 1);
                }

                await Button.ScrollIntoViewAsync(Limit_tab, true, 1);
                await Button.ClickButtonAsync(Limit_tab, ActionType.Click, true, 1);
                await Button.ScrollIntoViewAsync(Building_input, true, 1);

                await InputField.SetTextAreaInputFieldAsync(Building_input, Building_input_value, true, 1);
                await DropDown.SelectDropDownAsync(Buildingdeductible_drP, Buildingdeductible_drP_value, true, 1);
                await DropDown.SelectDropDownAsync(Buildingwindhaildeductible_drp, Buildingwindhaildeductible_drp_value, true, 1);
                await InputField.SetTextAreaInputFieldAsync(Buildingpersonalproperty_limit, Buildingpersonalproperty_limit_value, true, 1);
                await DropDown.SelectDropDownAsync(Buildingpersonalpropertydeductible_drp, Buildingpersonalpropertydeductible_drp_value, true, 1);
 

                await Button.ClickButtonAsync(Buildingrating_tab, ActionType.Click, true, 1);

                if (!string.IsNullOrEmpty(Doesbuildinghavesprinklers_value))
                {
                    await RadioButton.SelectRadioButtonAsync(string.Format(Doesbuildinghavesprinklers, Doesbuildinghavesprinklers_value), "value", true, 1);
                }

                if (!string.IsNullOrEmpty(Bld_rilessthan100amp_radio_value))
                {
                    await RadioButton.SelectRadioButtonAsync(string.Format(Bld_rilessthan100amp_radio, Bld_rilessthan100amp_radio_value), "value", true, 1);
                }

                if (!string.IsNullOrEmpty(Heatexist_checkboxlabel_value) && Heatexist_checkboxlabel_value == "Yes")
                {
                    await Checkbox.SelectCheckboxAsync(Heatexist_checkboxlabel, true, true, 1);
                }

                await InputField.SetTextAreaInputFieldAsync(Yearheatsourceupdated_input, Yearheatsourceupdated_input_value, true, 1);

                if (!string.IsNullOrEmpty(Localpropertymanager_radio_value))
                {
                    await RadioButton.SelectRadioButtonAsync(string.Format(Localpropertymanager_radio, Localpropertymanager_radio_value), "No", true, 1);
                }

                await InputField.SetTextAreaInputFieldAsync(Yearofconstruction_input, Yearofconstruction_input_value, true, 1);

                if (!string.IsNullOrEmpty(Valueofbuildinglisted100percent_radio_value))
                {
                    await RadioButton.SelectRadioButtonAsync(string.Format(Valueofbuildinglisted100percent_radio, Valueofbuildinglisted100percent_radio_value), "value", true, 1);
                }

                if (!string.IsNullOrEmpty(Roofpeaked_radio_value))
                {
                    await RadioButton.SelectRadioButtonAsync(string.Format(Roofpeaked_radio, Roofpeaked_radio_value), "value", true, 1);
                }

                if (!string.IsNullOrEmpty(Portionofroofmaterial_radio_value))
                {
                    await RadioButton.SelectRadioButtonAsync(string.Format(Portionofroofmaterial_radio, Portionofroofmaterial_radio_value), "value", true, 1);
                }

                if (!string.IsNullOrEmpty(Nearfloodzone_radio_value))
                {
                    await RadioButton.SelectRadioButtonAsync(string.Format(Nearfloodzone_radio, Nearfloodzone_radio_value), "value", true, 1);
                }

                if (!string.IsNullOrEmpty(Buildingismobilehome_radio_value))
                {
                    await RadioButton.SelectRadioButtonAsync(string.Format(Buildingismobilehome_radio, Buildingismobilehome_radio_value), "value", true, 1);
                }

                if (!string.IsNullOrEmpty(Buildingistownhouse_radio_value))
                {
                    await RadioButton.SelectRadioButtonAsync(string.Format(Buildingistownhouse_radio, Buildingistownhouse_radio_value), "value", true, 1);
                }

                if (!string.IsNullOrEmpty(Extendedunoccupied_radio_value))
                {
                    await RadioButton.SelectRadioButtonAsync(string.Format(Extendedunoccupied_radio, Extendedunoccupied_radio_value), "value", true, 1);
                }

                if (!string.IsNullOrEmpty(Hasasbestos_radio_value))
                {
                    await RadioButton.SelectRadioButtonAsync(string.Format(Hasasbestos_radio, Hasasbestos_radio_value), "value", true, 1);
                }

                if (!string.IsNullOrEmpty(Doorswindowsgoodrepair_radio_value))
                {
                    await RadioButton.SelectRadioButtonAsync(string.Format(Doorswindowsgoodrepair_radio, Doorswindowsgoodrepair_radio_value), "value", true, 1);
                }

                if (!string.IsNullOrEmpty(Otheroccupanciesonpremises_radio_value))
                {
                    await RadioButton.SelectRadioButtonAsync(string.Format(Otheroccupanciesonpremises_radio, Otheroccupanciesonpremises_radio_value), "value", true, 1);
                }

                await InputField.SetTextAreaInputFieldAsync(Buildingtotalsquarefootage_input, Buildingtotalsquarefootage_input_value, true, 1);

                if (!string.IsNullOrEmpty(Workingsmokedetectorsinplace_radio_value))
                {
                    await RadioButton.SelectRadioButtonAsync(string.Format(Workingsmokedetectorsinplace_radio, Workingsmokedetectorsinplace_radio_value), "value", true, 1);
                }

                if (!string.IsNullOrEmpty(Fireextinguishersinplace_radio_value))
                {
                    await RadioButton.SelectRadioButtonAsync(string.Format(Fireextinguishersinplace_radio, Fireextinguishersinplace_radio_value), "value", true, 1);
                }

                if (!string.IsNullOrEmpty(Securitysystem2_radio_value))
                {
                    await RadioButton.SelectRadioButtonAsync(string.Format(Securitysystem2_radio, Securitysystem2_radio_value), "value", true, 1);
                }

                await InputField.SetTextAreaInputFieldAsync(Aptrentsquarefootage_input, Aptrentsquarefootage_input_value, true, 1);

                if (!string.IsNullOrEmpty(Aptrentoccupiedbyinsured_radio_value))
                {
                    await RadioButton.SelectRadioButtonAsync(string.Format(Aptrentoccupiedbyinsured_radio, Aptrentoccupiedbyinsured_radio_value), "value", true, 1);
                }

                await InputField.SetTextAreaInputFieldAsync(Numberofunits_input, Numberofunits_input_value, true, 1);
                await InputField.SetTextAreaInputFieldAsync(Numberofunitsownedbyinsured_input, Numberofunitsownedbyinsured_input_value, true, 1);

                if (!string.IsNullOrEmpty(Studenthousing_radio_value))
                {
                    await RadioButton.SelectRadioButtonAsync(string.Format(Studenthousing_radio, Studenthousing_radio_value), "value", true, 1);
                }

                if (!string.IsNullOrEmpty(Insurediscondoassociation_radio_value))
                {
                    await RadioButton.SelectRadioButtonAsync(string.Format(Insurediscondoassociation_radio, Insurediscondoassociation_radio_value), "value", true, 1);
                }

                if (!string.IsNullOrEmpty(Heldforsale_radio_value))
                {
                    await RadioButton.SelectRadioButtonAsync(string.Format(Heldforsale_radio, Heldforsale_radio_value), "value", true, 1);
                }

                await DropDown.SelectDropDownAsync(Leasetype_drp, Leasetype_drp_value, true, 1);
                await Button.ClickButtonAsync(Continue_btn, ActionType.Click, true, 1);
                logger.WriteLine("Building data entered successfully from JSON data.");
            }
            catch (Exception ex)
            {
                logger.WriteLine($"Error filling Building Data: {ex.Message}");
                throw new Exception($"Failed to fill building data using profile '{profileKey}': {ex.Message}", ex);
            }
        }
    }
}
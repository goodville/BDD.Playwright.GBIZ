using BDD.Playwright.Core.Interfaces;
using BDD.Playwright.GBIZ.Pages.CommonPage;
using BDD.Playwright.GBIZ.PageElements;
using Reqnroll;

namespace BDD.Playwright.GBIZ.Pages.AgentPages
{
    [Binding]
    public class NewQuote_TradesmanCoverPage : BasePage
    {
        private readonly IReqnrollOutputHelper _ReqnrollLogger;
        private readonly FeatureContext _featureContext;
        private readonly ScenarioContext _scenarioContext;
        public IFileReader _fileReader;
        //public BaseElement _baseElement;
        // Constructor
        public NewQuote_TradesmanCoverPage(ScenarioContext scenarioContext, IFileReader fileReader) : base(scenarioContext)
        {
            _fileReader = fileReader;
            // _baseElement = new BaseElement(scenarioContext);
        }
        #region Xpath - Tradesman Cover
        //New Quote Page Xpaths
        public string QuoteDescription_Inp => "//input[contains(@id,'quoteDescription')]";
        public string EffectiveDate_Inp => "//input[contains(@id,'effectivedate')]";
        public string BookCode_Inp => "//input[contains(@id,'bookofbusiness')]";
        public string Office_Drp => "//select[contains(@id,'applicant_office')]";
        public string Producer_Drp => "//select[contains(@id,'applicant_producer')]"; 
        public string NamedInsured_FirstName_Inp => "//input[contains(@id,'ni_firstName')]";
        public string NamedInsured_MiddleName_Inp => "//input[contains(@id,'ni_middleName')]";
        public string NamedInsured_LastName_Inp => "//input[contains(@id,'ni_lastName')]";
        public string NamedInsured_Suffix_Drp => "//select[contains(@id,'ni_suffix')]";
        public string NamedInsured_SSN_Inp => "//input[contains(@id,'fld_ni_ssn_1') or @name='ni_socialSecurityNumbertext']";
        public string NamedInsured_DOB_Inp => "//input[contains(@name,'dob') or @name='ni_dateOfBirthtext']";
        public string AddressLine1_Inp => "//input[contains(@id,'sa_address1')]";
        public string AddressLine2_Inp => "//input[contains(@id,'sa_address2')]";
        public string City_Inp => "//input[contains(@id,'sa_city')]";
        public string State_Drp => "//select[contains(@id,'ni_state')]";
        public string State_Drp1 => "//select[contains(@id,'fld_sa_state')]";
        public string ZipCode_Inp1 => "(//input[contains(@id,'sa_zip')])[1]";
        public string ZipCode_Inp2 => "(//input[contains(@id,'sa_zip')])[2]";
        public string BusinessDescription => "//textarea[@id='fld_businessDescription']";
        public string BusinessType => "//input[contains(@id,'businessType')  and @value='{0}']";
        public string BusinessFunction => "//input[contains(@id,'businessFunction')  and @value='{0}']";
        public string Insuranceinforce => "//input[@name='addlinfoInsuranceForceWithGoodville' and @value='{0}']";
        public string InfoBusinessEndeavorBankruptcy => "//input[@name='addlinfoBusinessEndeavorBankruptcy' and @value='{0}']";
        public string InfoToolsEquipment => "//input[@name='addlinfoToolsEquipment' and @value='{0}']";
        public string InfoCanceledRefusedCoverage => "//input[@name='addlinfoCanceledRefusedCoverage' and @value='{0}']";
        public string TCpage_ExteriorSprayPainting => "//input[@name='exteriorSpray' and @value='{0}']";
        public string TCpage_GrossAnnualIncome_txt => "//input[@id='fld_addlinfoGrossAnnualReceipts']";
        public string TCpage_EmployeePayroll_txt => "//input[@id='fld_addlinfoEmployeePayroll']";
        public string ContinueButton => "//button[contains(text(),'Continue')]";

        //Add Location Xpaths
        public string TCpage_AddLocation_btn => "//a[contains(text(),'Add Location')]";
        public string TCpage_Protection_drpdwn => "//select[@id='fld_loc_protection_1']";
        public string TCpage_locationStreet_Inp => "//input[@id='fld_loc_streetAddress_1']";
        public string TCpage_locationCity_Inp => "//input[@id='fld_loc_city_1']";
        public string TCpage_locationZip_Inp => "//input[@id='fld_loc_zipCode_1']";
        public string TCpage_MilestoFireDept_Inp => "//input[@id='fld_loc_milesToFireDept_1']";
        public string TCpage_RespondingFireDept_Inp => "//input[@id='fld_loc_respondingFireDept_1']";
        public string TCpage_TrampolineorPool_RadioBtn => "//input[@id='fld_no_loc_trampolineOrPool_1']";
        public string TCpage_passagewaysList_RadioBtn => "//input[@id='fld_no_loc_passagewaysLit_1']";
        public string TCpage_porchHandrails_RadioBtn => "//input[@id='fld_no_loc_porchHandrails_1']";
        public string TCpage_stairwayHandrails_RadioBtn => "//input[@id='fld_no_loc_stairwaysHandrails_1']";
        public string TCpage_InsuredWithin70MiOfLocation_RadioBtn => "//input[@id='fld_no_loc_riInsuredWithin70MiOfLocation_1']";
        public string TCpage_ContinuetoBuilding_Btn => "//button[contains(text(),'Continue to Buildings')]";

        //Add Building Xpaths
        public string TCpage_AddBuilding_btn => "//a[text()='Add Building']";
        public string TCpage_Building_drpdwn => "//select[@id='fld_bld_location_1']";
        public string Description_input => "//input[@id='fld_bld_description_1']";
        public string TCpage_BuildingDescription_Inp => "//input[@id='fld_bld_description_1']";
        public string TCpage_LocatedIntheBuilding_Chkbox => "//input[contains(@id,'_fld_bld_businessFunction') and @value='{0}']";
        public string TCpage_ExclusiveOffice_RadioBtn => "//input[contains(@name,'bld_exclusiveOffice') and @value='{0}']";
        public string TCpage_InsuredOwnBuilding_RadioBtn => "//input[@name='bld_insuredOwnBuilding_1' and @value='{0}']";
        public string TCpage_SquareFootage_Inp => "//input[@id='fld_bld_totalSquareFootage_1']";
        public string TCpage_ConstructionTpe_drpdwn => "//select[@id='fld_bld_constructionType_1']";
        public string TCpage_CondoUnit_Radiobtn => "//input[@id='fld_no_bld_condoUnit_1']";
        public string TCpage_NumberOfStories_Inp => "//input[@id='fld_bld_numberOfStories_1']";
       
        //Building Limit Tab xpaths
        public string BuildingLimit_Tab => "//div[@id='buildingLimits_tabBox']";
        public string BuildingLimit_Inp => "//input[@id='fld_bld_buildingLimit_1']";
        public string BuildingDeductable_Inp => "//select[@id='fld_bld_buildingDeductible_1']";
        public string PersonalPropertyLimit_Inp => "//input[@id='fld_bld_personalPropertyLimit_1']";
        public string PersonalPropertyDeductable_Inp => "//select[@id='fld_bld_personalPropertyDeductible_1']";
        public string BuildingRatingInfo_Tab => "//div[@id='buildingRatingInformation_tabBox']";
        public string Buildingsprinklers_RadioButton => "//input[@name='bld_riSprinklers_1' and @value='{0}']";
        public string BuildingElectricalService_RadioButton => "//input[@name='bld_riLessThan100Amp_1' and @value='{0}']";
        public string BuildingSourceOfHeat_CheckBox => "//input[@id='cbG_fld_bld_riSourcesOfHeat_1' and @value='G']";
        public string BuildingOccupancy_CheckBox => "//input[@id='fld_bld_riOccupancyPersonalStorage_1']";
        public string BuildingYearHeatSourceUpdated_Input => "//input[@id='fld_bld_riYearHeatSourceUpdated_1']";
        public string BuildingPropertyManager_RadioButton => "//input[@name='bld_riLocalPropertyManager_1' and @value='{0}']";
        public string BuildingYearOfConstruction_Input => "//input[@id='fld_bld_riYearOfConstruction_1']";
        public string ValueOfBuilding_RadioButton => "//input[@name='bld_riValueOfBuildingListed100Percent_1' and @value='{0}']";
        public string RoofPeaked_RadioButton => "//input[@name='bld_riRoofPeaked_1' and @value='{0}']";
        public string RoofFlat_RadioButton => "//input[@name='bld_riPortionOfRoofMaterial_1' and @value='{0}']";
        public string NearFloodZoneRadioButton => "//input[@name='bld_riNearFloodzone_1' and @value='{0}']";
        public string BuildingIsMobileHome_RadioButton => "//input[@name='bld_riBuildingIsMobileHome_1' and @value='{0}']";
        public string BuildingIsTownHouse_RadioButton => "//input[@name='bld_riBuildingIsTownHouse_1' and @value='{0}']";
        public string HasAsbestos_RadioButton => "//input[@name='bld_riHasAsbestos_1' and @value='{0}']";
        public string ExtendedUnoccupied_RadioButton => "//input[@name='bld_riExtendedUnoccupied_1' and @value='{0}']";
        public string DoorsWindowsGoodRepair_RadioButton => "//input[@name='bld_riDoorsWindowsGoodRepair_1' and @value='{0}']";
        public string OtherOccupanciesOnPremises_RadioButton => "//input[@name='bld_riOtherOccupanciesOnPremises_1' and @value='{0}']";
        public string TotalSquareFootage_Input => "//input[@name='bld_riTotalSquareFootage_1']";
        public string WorkingSmokeDetectorsInPlace_RadioButton => "//input[@name='bld_riWorkingSmokeDetectorsInPlace_1' and @value='{0}']";
        public string FireExtinguishersInPlace_RadioButton => "//input[@name='bld_riFireExtinguishersInPlace_1' and @value='{0}']";
        public string SecuritySystem2_RadioButton => "//input[@name='bld_riSecuritySystem2_1' and @value='{0}']";
       
        //Coverages Tab Xpaths
        public string Coverages_Tab => "//a[normalize-space()='Coverages']";
        public string NumberOfOwners => "//input[@id='fld_numberOfOwners']";
        public string NumberOfFullTimeEmployees_Inp => "//input[@id='fld_numberOfFulltime']";
        public string NumberOfPartTimeEmployees_Inp => "//input[@id='fld_numberOfParttime']";
        public string SnowRemoval_RadioButton => "//input[@name='snowremoval' and @value='{0}']";
        public string MedicalPaymentsLimit_DropDown => "//select[@id='fld_medicalPaymentsLimit']";
        public string FireLegalLimit_DropDown => "//select[@id='fld_fireLegalLimit']";
        public string LiabilityLimit_DropDown => "//select[@id='fld_liabilityLimit']";

        //Enhancement SubTab Xpaths
        public string Enhancement_SubTab => "//div[normalize-space()='Enhancement']//div[@id='subtab_']";
        public string CommLiabEE_Radio => "//input[@name='commLiabEE' and @value='{0}']";
        public string PremierCommLiabEE_Radio => "//input[@name='premierCommLiabEE' and @value='{0}']";
        public string CommPropEE_Radio => "//input[@name='commPropEE' and @value='{0}']";
        public string PremierCommPropEE_Radio => "//input[@name='premierCommPropEE' and @value='{0}']";

        //Tools/Equipment SubTab Xpaths
        public string Tools_Equipment_SubTab => "//div[@id='subtab_' and contains(text(),'Tools/Equipment')]";
        public string Tools_EquipmentLimit_Input => "//input[@id='fld_blanketTools']";
        public string Tools_Equipment_Deductibles_DropDown => "//select[@id='fld_blanketToolsDeductibles']";
        public string Liability_Territory_Input => "//input[@id='fld_classTerritoryUWOverride']";
        
        //Summary Tab Xpaths
        public string Summary_Link => "//a[normalize-space()='Summary']";
        public string EstimatedPremiumText => "//div[@id='QuotesSummaryContentDiv']/div[contains(text(),'Estimated Premium:')]";
        public string CoveragePremiumValue => "(//div[starts-with(normalize-space(text()), '$')])[last()]";
        public string PremiumText => "//div[contains(text(),'Number of Buildings')]/following-sibling::div[1]";
        public string PremiumValue => "//div[@id='location_summaryPremium_1']";
        public string Delete_Button => "//a[normalize-space()='delete']";
        public string QuoteNumber_Text => "//div[@id='formHeaderLeft' and contains(text(),'Tradesman Cover -')]";
        public string NoRecordsText => "//span[contains(text(),'No Records Returned!')]";

        //Billing Tab Xpaths
        public string Billing_Tab => "//a[normalize-space()='Billing']";
        public string PayInFull_RadioButton => "//div[contains(., '{0}')]/input[@name='bill_paymentplan']";
        public string PaymentPlan_Text => "(//span[contains(text(),'Payment Plan')])[2]";

        //Binding Tab Xpaths
        public string Bind_Tab => "//a[normalize-space()='Bind']";
        public string BindingProducer_Dropdown => "//select[@id='fld_binding_producer']";
        public string AgentEmail_Input => "//input[@id='fld_agentEmail']";
        public string Subcontractwork_radioButton => "//input[@name='subcontractWork' and@value='{0}']";
        public string DroneUse_radioButton => "//input[@name='droneUse' and@value='{0}']";
        public string AsbestosWork_radioButton => "//input[@name='asbestosWork' and@value='{0}']";
        public string RoofOnly_radioButton => "//input[@name='roofOnly' and@value='{0}']";
        public string Demolition_radioButton => "//input[@name='demolition' and@value='{0}']";
        public string Eifs_radioButton => "//input[@name='eifs' and@value='{0}']";
        public string BindingInformation_Tab => "(//div[normalize-space()='Binding Information'])[2]";
        public string ReturnToBinding_Button => "//button[normalize-space()='Return to Binding']";
        public string AttachDocument_Tab => "(//div[normalize-space()='Attach Documents'])[2]";
        public string NumberOfYearsExperience_input => "//input[@id='fld_noYearsExperience']";
        public string BindingTermsAndConditions_checkbox => "//input[@id='fld_binding_agreetoterms']";
        public string MessageOverride_Tab => "//div[normalize-space()='Message Overrides']";
        public string ApplyOverride_Button => "//span[contains(text(),'Apply Override(s)')]";
        public string Asbestoswork_removal_checkbox => "(//div[contains(text(),'Asbestos work/removal selection is required.')])[3]";
        public string Demolition_checkbox => "(//div[contains(text(),'Demolition selection is required.')])[3]";
        public string ExteriorInstallationFinishingSystems_checkbox => "(//div[contains(text(),'Exterior installation finishing systems selection is required.')])[3]";
        public string NumberOfYearsExperience_checkbox => "(//div[contains(text(),'Number of years experience is required.')])[3]";
        public string RoofOnlyJobs_checkbox => "(//div[contains(text(),'Roof only jobs selection is required.')])[3]";
        public string Applyoverride_Button => "(//span[contains(text(),'Apply Override(s)')])[2]";
        public string BindPolicyWithGoodville_Button => "//button[@id='buttonbinding_submitbutton']";
        public string Ok_Button => "//span[normalize-space()='OK']";

        //public string NamedInsured_SSN_Inp => "//input[contains(@id,'fld_ni_ssn_1')]";

        #endregion

        public async Task NewQuoteDetailsAsync(string profileKey)
        {

            if (_fileReader == null)
            {
                throw new InvalidOperationException("FileReader is not available. Use constructor with IFileReader parameter.");
            }

            try
            {
                logger.WriteLine($"Starting to fill Tradesman Cover NewQuote information using profile: {profileKey}");

                var filePath = "TradesmanCover\\NewQuoteData.json";

                // Get values from JSON - Quote Details
                
                var quoteDescription = _fileReader.GetOptionalValue(filePath, $"{profileKey}.QuoteDescription");
                var effectiveDate = _fileReader.GetOptionalValue(filePath, $"{profileKey}.EffectiveDate");
                var bookCode = _fileReader.GetOptionalValue(filePath, $"{profileKey}.BookCode");
                var office = _fileReader.GetOptionalValue(filePath, $"{profileKey}.Office");
                var producer = _fileReader.GetOptionalValue(filePath, $"{profileKey}.Producer");
                var firstName = _fileReader.GetOptionalValue(filePath, $"{profileKey}.FirstName");
                var lastName = _fileReader.GetOptionalValue(filePath, $"{profileKey}.LastName");
                var ssn = _fileReader.GetOptionalValue(filePath, $"{profileKey}.SSN");
                var dateOfBirth = _fileReader.GetOptionalValue(filePath, $"{profileKey}.DateOfBirth");
                var address = _fileReader.GetOptionalValue(filePath, $"{profileKey}.Address");
                var city = _fileReader.GetOptionalValue(filePath, $"{profileKey}.City");
                var state = _fileReader.GetOptionalValue(filePath, $"{profileKey}.State");
                var zipCode1 = _fileReader.GetOptionalValue(filePath, $"{profileKey}.ZipCode1");
                var zipCode2 = _fileReader.GetOptionalValue(filePath, $"{profileKey}.ZipCode2");
                var businessDescription = _fileReader.GetOptionalValue(filePath, $"{profileKey}.BusinessDescription");
                var businessType = _fileReader.GetOptionalValue(filePath, $"{profileKey}.BusinessType");
                var businessFunction = _fileReader.GetOptionalValue(filePath, $"{profileKey}.BusinessFunction");
                var insuranceinforce = _fileReader.GetOptionalValue(filePath, $"{profileKey}.Insuranceinforce");
                var infoBusinessEndeavorBankruptcy = _fileReader.GetOptionalValue(filePath, $"{profileKey}.InfoBusinessEndeavorBankruptcy");
                var infoToolsEquipment = _fileReader.GetOptionalValue(filePath, $"{profileKey}.InfoToolsEquipment");
                var infoCanceledRefusedCoverage = _fileReader.GetOptionalValue(filePath, $"{profileKey}.InfoCanceledRefusedCoverage");
                var exteriorSprayPainting = _fileReader.GetOptionalValue(filePath, $"{profileKey}.ExteriorSprayPainting");
                var grossAnnualIncome = _fileReader.GetOptionalValue(filePath, $"{profileKey}.GrossAnnualIncome");
                var employeePayroll = _fileReader.GetOptionalValue(filePath, $"{profileKey}.EmployeePayroll");
                var continueButton = _fileReader.GetOptionalValue(filePath, $"{profileKey}.ContinueButton");

                await InputField.SetTextAreaInputFieldAsync(QuoteDescription_Inp, quoteDescription, true, 1);
                if (int.TryParse(effectiveDate, out var days))
                {
                    await InputField.SetTextAreaInputFieldAsync(EffectiveDate_Inp, DateTime.Now.AddDays(days).ToString("MM/dd/yyyy"), true, 1);
                }

                await InputField.SetTextAreaInputFieldAsync(BookCode_Inp, bookCode, true, 1);
                await DropDown.SelectDropDownAsync(Office_Drp, office, true, 1);
                await DropDown.SelectDropDownAsync(Producer_Drp, producer ,true, 1);
                await InputField.SetTextAreaInputFieldAsync(NamedInsured_FirstName_Inp, firstName, true, 1);
                await InputField.SetTextAreaInputFieldAsync(NamedInsured_LastName_Inp, lastName, true, 1);
                await InputField.SetTextAreaInputFieldAsync(NamedInsured_SSN_Inp, ssn, true, 1);
                Thread.Sleep(1000); // Wait for SSN input to be processed
                await InputField.SetTextAreaInputFieldAsync(NamedInsured_DOB_Inp,dateOfBirth, true, 1);
                await InputField.SetTextAreaInputFieldAsync(AddressLine1_Inp, address, true, 1);
                await InputField.SetTextAreaInputFieldAsync(City_Inp, city, true, 1);
                await DropDown.SelectDropDownAsync(State_Drp1,state, true, 1);
                await InputField.SetTextAreaInputFieldAsync(ZipCode_Inp1, zipCode1,true, 1);
                await InputField.SetTextAreaInputFieldAsync(ZipCode_Inp2, zipCode2, true, 1);
                await InputField.SetTextAreaInputFieldAsync(BusinessDescription, businessDescription, true, 1);
                await RadioButton.SelectRadioButtonAsync(BusinessType, businessType, true, 1);
                await RadioButton.SelectRadioButtonAsync(BusinessFunction, businessFunction,true, 1);
                await RadioButton.SelectRadioButtonAsync(Insuranceinforce, insuranceinforce, true, 1);
                await RadioButton.SelectRadioButtonAsync(InfoBusinessEndeavorBankruptcy,infoBusinessEndeavorBankruptcy, true, 1);
                await RadioButton.SelectRadioButtonAsync(InfoToolsEquipment, infoToolsEquipment, true, 1);
                await RadioButton.SelectRadioButtonAsync(InfoCanceledRefusedCoverage, infoCanceledRefusedCoverage, true, 1);
                await RadioButton.SelectRadioButtonAsync(TCpage_ExteriorSprayPainting,exteriorSprayPainting ,true, 1);
                await InputField.SetTextAreaInputFieldAsync(TCpage_GrossAnnualIncome_txt, grossAnnualIncome, true, 1);
                await InputField.SetTextAreaInputFieldAsync(TCpage_EmployeePayroll_txt, employeePayroll, true, 1);
                await Button.ClickButtonAsync(ContinueButton, ActionType.Click, true, 1);

                logger.WriteLine($"Retrieved Tradesman Cover NewQuote Data for: {firstName} {lastName}");

                // Note: Form filling implementation would go here using the same pattern as BasicInformationPage
                // with the page elements (Button, InputField, DropDown, etc.) once they are properly resolved

                logger.WriteLine($"Successfully filled Tradesman Cover NewQuote information using profile: {profileKey}");
                logger.WriteLine("Tradesman Cover NewQuote Page Details Entered Successfully from JSON Data");
            }
            catch (Exception ex)
            {
                logger.WriteLine($"Error filling Tradesman Cover NewQuote data: {ex.Message}");
                throw new Exception($"Failed to fill Tradesman Cover NewQuote data using profile '{profileKey}': {ex.Message}", ex);
            }
        }
        public async Task LocationDetailsAsync(string profileKey)
        {
            if (_fileReader == null)
            {
                throw new InvalidOperationException("FileReader is not available. Use constructor with IFileReader parameter.");
            }

            try
            {
                logger.WriteLine($"Starting to fill Tradesman Cover Location information using profile: {profileKey}");

                var filePath = "TradesmanCover\\LocationData.json";
                // Location Details
                
                var locationProtection = _fileReader.GetOptionalValue(filePath, $"{profileKey}.LocationProtection");
                var locationStreetAddress = _fileReader.GetOptionalValue(filePath, $"{profileKey}.LocationStreetAddress");
                var locationCity = _fileReader.GetOptionalValue(filePath, $"{profileKey}.LocationCity");
                var locationZipCode = _fileReader.GetOptionalValue(filePath, $"{profileKey}.LocationZipCode");
                var milesToFireDept = _fileReader.GetOptionalValue(filePath, $"{profileKey}.MilesToFireDept");
                var respondingFireDept = _fileReader.GetOptionalValue(filePath, $"{profileKey}.RespondingFireDept");
                var trampolineOrPool = _fileReader.GetOptionalValue(filePath, $"{profileKey}.TrampolineOrPool");
                var passagewaysLit = _fileReader.GetOptionalValue(filePath, $"{profileKey}.PassagewaysLit");
                var porchHandrails = _fileReader.GetOptionalValue(filePath, $"{profileKey}.PorchHandrails");
                var stairwayHandrails = _fileReader.GetOptionalValue(filePath, $"{profileKey}.StairwayHandrails");
                var insuredWithin70Mi = _fileReader.GetOptionalValue(filePath, $"{profileKey}.InsuredWithin70Mi");
               
                await Button.ClickButtonAsync(TCpage_AddLocation_btn, ActionType.Click, true, 1);
                await DropDown.SelectDropDownAsync(TCpage_Protection_drpdwn, locationProtection ,true, 1);
                await InputField.SetTextAreaInputFieldAsync(TCpage_locationStreet_Inp, locationStreetAddress, true, 1);
                await InputField.SetTextAreaInputFieldAsync(TCpage_locationCity_Inp, locationCity, true, 1);
                await InputField.SetTextAreaInputFieldAsync(TCpage_locationZip_Inp, locationZipCode, true, 1);
                await InputField.SetTextAreaInputFieldAsync(TCpage_MilestoFireDept_Inp, milesToFireDept, true, 1);
                await InputField.SetTextAreaInputFieldAsync(TCpage_RespondingFireDept_Inp, respondingFireDept, true, 1);
                await RadioButton.SelectRadioButtonAsync(TCpage_TrampolineorPool_RadioBtn, trampolineOrPool, true, 1);
                await RadioButton.SelectRadioButtonAsync(TCpage_passagewaysList_RadioBtn, passagewaysLit, true, 1);
                await RadioButton.SelectRadioButtonAsync(TCpage_porchHandrails_RadioBtn, porchHandrails, true, 1);
                await RadioButton.SelectRadioButtonAsync(TCpage_stairwayHandrails_RadioBtn, stairwayHandrails, true, 1);
                await RadioButton.SelectRadioButtonAsync(TCpage_InsuredWithin70MiOfLocation_RadioBtn, insuredWithin70Mi, true, 1);
                await Button.ClickButtonAsync(TCpage_ContinuetoBuilding_Btn, ActionType.Click, true, 1);
                logger.WriteLine($"Retrieved Tradesman Cover Location data for:  {locationCity} {locationZipCode} ");

                // Note: Form filling implementation would go here using the same pattern as BasicInformationPage
                // with the page elements (Button, InputField, DropDown, etc.) once they are properly resolved

                logger.WriteLine($"Successfully filled Tradesman Cover Location information using profile: {profileKey}");
                logger.WriteLine("Tradesman Cover Location Page Details Entered Successfully from JSON Data");
            }
            catch (Exception ex)
            {
                logger.WriteLine($"Error filling Tradesman Cover Location data: {ex.Message}");
                throw new Exception($"Failed to fill Tradesman Cover Location data using profile '{profileKey}': {ex.Message}", ex);
            }
        }
        public async Task BuildingDetailsAsync(string profileKey)
        {
            if (_fileReader == null)
            {
                throw new InvalidOperationException("FileReader is not available. Use constructor with IFileReader parameter.");
            }

            try
            {
                logger.WriteLine($"Starting to fill Tradesman Cover Building information using profile: {profileKey}");

                var filePath = "TradesmanCover\\BuildingData.json";

                var buildingDropdown = _fileReader.GetOptionalValue(filePath, $"{profileKey}.BuildingDropdown");
                var buildingDescription = _fileReader.GetOptionalValue(filePath, $"{profileKey}.BuildingDescription");
                var locatedInTheBuilding = _fileReader.GetOptionalValue(filePath, $"{profileKey}.LocatedInTheBuilding");
                var insuredOwnBuilding = _fileReader.GetOptionalValue(filePath, $"{profileKey}.InsuredOwnBuilding");
                var exclusiveOffice = _fileReader.GetOptionalValue(filePath, $"{profileKey}.ExclusiveOffice");
                var squareFootage = _fileReader.GetOptionalValue(filePath, $"{profileKey}.SquareFootage");
                var constructionType = _fileReader.GetOptionalValue(filePath, $"{profileKey}.ConstructionType");
                var condoUnit = _fileReader.GetOptionalValue(filePath, $"{profileKey}.CondoUnit");
                var numberOfStories = _fileReader.GetOptionalValue(filePath, $"{profileKey}.NumberOfStories");
                // Building Details

                await Button.ClickButtonAsync(TCpage_AddBuilding_btn, ActionType.Click, true, 1);
                await DropDown.SelectDropDownAsync(TCpage_Building_drpdwn, buildingDropdown, true, 1);
                await InputField.SetTextAreaInputFieldAsync(TCpage_BuildingDescription_Inp, buildingDescription, true, 1);
                await Checkbox.SelectCheckboxAsync(TCpage_LocatedIntheBuilding_Chkbox, true, true, 1);
                await RadioButton.SelectRadioButtonAsync(TCpage_InsuredOwnBuilding_RadioBtn, insuredOwnBuilding, true, 1);
                await RadioButton.SelectRadioButtonAsync(TCpage_ExclusiveOffice_RadioBtn, exclusiveOffice, true, 1);
                await InputField.SetTextAreaInputFieldAsync(TCpage_SquareFootage_Inp, squareFootage, true, 1);
                await DropDown.SelectDropDownAsync(TCpage_ConstructionTpe_drpdwn, constructionType, true, 1);
                await RadioButton.SelectRadioButtonAsync(TCpage_CondoUnit_Radiobtn, condoUnit, true, 1);
                await InputField.SetTextAreaInputFieldAsync(TCpage_NumberOfStories_Inp, numberOfStories, true, 1);

                logger.WriteLine($"Retrieved Tradesman Cover Building data for: {buildingDropdown} {numberOfStories}");

                // Note: Form filling implementation would go here using the same pattern as BasicInformationPage
                // with the page elements (Button, InputField, DropDown, etc.) once they are properly resolved

                logger.WriteLine($"Successfully filled Tradesman Cover Building information using profile: {profileKey}");
                logger.WriteLine("Tradesman Cover Building Page Details Entered Successfully from JSON Data");
            }
            catch (Exception ex)
            {
                logger.WriteLine($"Error filling Tradesman Cover Building data: {ex.Message}");
                throw new Exception($"Failed to fill Tradesman Cover Building data using profile '{profileKey}': {ex.Message}", ex);
            }
        }
        public async Task BuildingLimitsAsync(string profileKey)
        {
            if (_fileReader == null)
            {
                throw new InvalidOperationException("FileReader is not available. Use constructor with IFileReader parameter.");
            }

            try
            {
                logger.WriteLine($"Starting to fill Tradesman Cover BuildingLimits information using profile: {profileKey}");

                var filePath = "TradesmanCover\\TradesmanCoverData.json";

                var buildingLimit = _fileReader.GetOptionalValue(filePath, $"{profileKey}.BuildingLimit");
                var buildingDeductable = _fileReader.GetOptionalValue(filePath, $"{profileKey}.BuildingDeductable");
                var personalPropertyLimit = _fileReader.GetOptionalValue(filePath, $"{profileKey}.PersonalPropertyLimit");
                var personalPropertyDeductable = _fileReader.GetOptionalValue(filePath, $"{profileKey}.PersonalPropertyDeductable");

                //await Button.ScrollIntoViewAsync(BuildingLimit_Tab, true, 1);
                await Button.ClickButtonForStaleElementWithoutDepenAsync(BuildingLimit_Tab, ActionType.Click, true, 1);
                await InputField.SetTextAreaInputFieldAsync(BuildingLimit_Inp, buildingLimit, true, 1);
                await DropDown.SelectDropDownAsync(BuildingDeductable_Inp, buildingDeductable, true, 1);
                await InputField.SetTextAreaInputFieldAsync(PersonalPropertyLimit_Inp, personalPropertyLimit, true, 1);
                await DropDown.SelectDropDownAsync(PersonalPropertyDeductable_Inp, personalPropertyDeductable, true, 1);

                logger.WriteLine($"Retrieved Tradesman Cover BuildingLimits data for: {buildingLimit} {personalPropertyDeductable}");

                // Note: Form filling implementation would go here using the same pattern as BasicInformationPage
                // with the page elements (Button, InputField, DropDown, etc.) once they are properly resolved

                logger.WriteLine($"Successfully filled Tradesman Cover BuildingLimits information using profile: {profileKey}");
                logger.WriteLine("Tradesman Cover BuildingLimits Page Details Entered Successfully from JSON Data");
            }
            catch (Exception ex)
            {
                logger.WriteLine($"Error filling Tradesman Cover BuildingLimits data: {ex.Message}");
                throw new Exception($"Failed to fill Tradesman Cover BuildingLimits data using profile '{profileKey}': {ex.Message}", ex);
            }
        }
        public async Task BuildingRatingInformationAsync(string profileKey)
        {
            if (_fileReader == null)
            {
                throw new InvalidOperationException("FileReader is not available. Use constructor with IFileReader parameter.");
            }

            try
            {
                logger.WriteLine($"Starting to fill Tradesman Cover BuildingRating information using profile: {profileKey}");

                var filePath = "TradesmanCover\\BuildingData.json";

                var buildingsprinklers_RadioButton = _fileReader.GetOptionalValue(filePath, $"{profileKey}.Buildingsprinklers_RadioButton");
                var buildingElectricalService_RadioButton = _fileReader.GetOptionalValue(filePath, $"{profileKey}.BuildingElectricalService_RadioButton");
                var buildingSourceOfHeat_CheckBox = _fileReader.GetOptionalValue(filePath, $"{profileKey}.BuildingSourceOfHeat_CheckBox");
                var buildingOccupancy_CheckBox = _fileReader.GetOptionalValue(filePath, $"{profileKey}.BuildingOccupancy_CheckBox");
                var buildingYearHeatSourceUpdated_Input = _fileReader.GetOptionalValue(filePath, $"{profileKey}.BuildingYearHeatSourceUpdated_Input");
                var buildingPropertyManager_RadioButton = _fileReader.GetOptionalValue(filePath, $"{profileKey}.BuildingPropertyManager_RadioButton");
                var buildingYearOfConstruction_Input = _fileReader.GetOptionalValue(filePath, $"{profileKey}.BuildingYearOfConstruction_Input");
                var valueOfBuilding_RadioButton = _fileReader.GetOptionalValue(filePath, $"{profileKey}.ValueOfBuilding_RadioButton");
                var roofPeaked_RadioButton = _fileReader.GetOptionalValue(filePath, $"{profileKey}.RoofPeaked_RadioButton");
                var roofFlat_RadioButton = _fileReader.GetOptionalValue(filePath, $"{profileKey}.RoofFlat_RadioButton");
                var nearFloodZoneRadioButton = _fileReader.GetOptionalValue(filePath, $"{profileKey}.NearFloodZoneRadioButton");            
                var buildingIsMobileHome_RadioButton = _fileReader.GetOptionalValue(filePath, $"{profileKey}.BuildingIsMobileHome_RadioButton");
                var buildingIsTownHouse_RadioButton = _fileReader.GetOptionalValue(filePath, $"{profileKey}.BuildingIsTownHouse_RadioButton");
                var hasAsbestos_RadioButton = _fileReader.GetOptionalValue(filePath, $"{profileKey}.HasAsbestos_RadioButton");
                var extendedUnoccupied_RadioButton = _fileReader.GetOptionalValue(filePath, $"{profileKey}.ExtendedUnoccupied_RadioButton");
                var doorsWindowsGoodRepair_RadioButton = _fileReader.GetOptionalValue(filePath, $"{profileKey}.DoorsWindowsGoodRepair_RadioButton");
                var otherOccupanciesOnPremises_RadioButton = _fileReader.GetOptionalValue(filePath, $"{profileKey}.OtherOccupanciesOnPremises_RadioButton");
                var totalSquareFootage_Input = _fileReader.GetOptionalValue(filePath, $"{profileKey}.TotalSquareFootage_Input");
                var workingSmokeDetectorsInPlace_RadioButton = _fileReader.GetOptionalValue(filePath, $"{profileKey}.WorkingSmokeDetectorsInPlace_RadioButton");
                var fireExtinguishersInPlace_RadioButton = _fileReader.GetOptionalValue(filePath, $"{profileKey}.FireExtinguishersInPlace_RadioButton");
                var securitySystem2_RadioButton = _fileReader.GetOptionalValue(filePath, $"{profileKey}.SecuritySystem2_RadioButton");
                
                await Button.ClickButtonAsync(BuildingRatingInfo_Tab, ActionType.Click, true, 1);
                await RadioButton.SelectRadioButtonAsync(Buildingsprinklers_RadioButton, buildingsprinklers_RadioButton,true, 1);
                await RadioButton.SelectRadioButtonAsync(BuildingElectricalService_RadioButton,buildingElectricalService_RadioButton, true, 1);
                await Checkbox.SelectCheckboxAsync(BuildingSourceOfHeat_CheckBox, true, true, 1);
                await Checkbox.SelectCheckboxAsync(BuildingOccupancy_CheckBox, true, true, 1);
                await InputField.SetTextAreaInputFieldAsync(BuildingYearHeatSourceUpdated_Input, buildingYearHeatSourceUpdated_Input, true, 1);
                await RadioButton.SelectRadioButtonAsync(BuildingPropertyManager_RadioButton,buildingPropertyManager_RadioButton, true, 1);
                await RadioButton.SelectRadioButtonAsync(ValueOfBuilding_RadioButton,valueOfBuilding_RadioButton, true, 1);
                await InputField.SetTextAreaInputFieldAsync(BuildingYearOfConstruction_Input, buildingYearOfConstruction_Input, true, 1);
                await RadioButton.SelectRadioButtonAsync(RoofPeaked_RadioButton, roofPeaked_RadioButton,true, 1);
                await RadioButton.SelectRadioButtonAsync(RoofFlat_RadioButton,roofFlat_RadioButton, true, 1);
                await RadioButton.SelectRadioButtonAsync(NearFloodZoneRadioButton, nearFloodZoneRadioButton,true, 1);
                await RadioButton.SelectRadioButtonAsync(BuildingIsMobileHome_RadioButton, buildingIsMobileHome_RadioButton,true, 1);
                await RadioButton.SelectRadioButtonAsync(BuildingIsTownHouse_RadioButton, buildingIsTownHouse_RadioButton,true, 1);
                await RadioButton.SelectRadioButtonAsync(HasAsbestos_RadioButton, hasAsbestos_RadioButton,true, 1);
                await RadioButton.SelectRadioButtonAsync(ExtendedUnoccupied_RadioButton, extendedUnoccupied_RadioButton,true, 1);
                await RadioButton.SelectRadioButtonAsync(DoorsWindowsGoodRepair_RadioButton, doorsWindowsGoodRepair_RadioButton,true, 1);
                await RadioButton.SelectRadioButtonAsync(OtherOccupanciesOnPremises_RadioButton, otherOccupanciesOnPremises_RadioButton,true, 1);
                await InputField.SetTextAreaInputFieldAsync(TotalSquareFootage_Input, totalSquareFootage_Input, true, 1);
                await RadioButton.SelectRadioButtonAsync(WorkingSmokeDetectorsInPlace_RadioButton,workingSmokeDetectorsInPlace_RadioButton, true, 1);
                await RadioButton.SelectRadioButtonAsync(FireExtinguishersInPlace_RadioButton,fireExtinguishersInPlace_RadioButton, true, 1);
                await RadioButton.SelectRadioButtonAsync(SecuritySystem2_RadioButton, securitySystem2_RadioButton, true, 1);
                logger.WriteLine($"Retrieved Tradesman Cover BuildingRating data for:{buildingsprinklers_RadioButton} {securitySystem2_RadioButton}");

                // Note: Form filling implementation would go here using the same pattern as BasicInformationPage
                // with the page elements (Button, InputField, DropDown, etc.) once they are properly resolved

                logger.WriteLine($"Successfully filled Tradesman Cover BuildingRating information using profile: {profileKey}");
                logger.WriteLine("Tradesman Cover BuildingRating Page Details Entered Successfully from JSON Data");
            }
            catch (Exception ex)
            {
                logger.WriteLine($"Error filling Tradesman Cover BuildingRating data: {ex.Message}");
                throw new Exception($"Failed to fill Tradesman Cover BuildingRating data using profile '{profileKey}': {ex.Message}", ex);
            }
        }
        public async Task CoveragesInformationAsync(string profileKey)
        {
            if (_fileReader == null)
            {
                throw new InvalidOperationException("FileReader is not available. Use constructor with IFileReader parameter.");
            }

            try
            {
                logger.WriteLine($"Starting to fill Tradesman Cover Coverages information using profile: {profileKey}");

                var filePath = "TradesmanCover\\CoveragesData.json";
                var numberOfOwners = _fileReader.GetOptionalValue(filePath, $"{profileKey}.NumberOfOwners");
                var numberOfFullTimeEmployees_Inp = _fileReader.GetOptionalValue(filePath, $"{profileKey}.NumberOfFullTimeEmployees");
                var numberOfPartTimeEmployees_Inp = _fileReader.GetOptionalValue(filePath, $"{profileKey}.NumberOfPartTimeEmployees");
                var snowRemoval_RadioButton = _fileReader.GetOptionalValue(filePath, $"{profileKey}.SnowRemoval");
                var medicalPaymentsLimit_DropDown = _fileReader.GetOptionalValue(filePath, $"{profileKey}.MedicalPaymentsLimit");
                var fireLegalLimit_DropDown = _fileReader.GetOptionalValue(filePath, $"{profileKey}.FireLegalLimit");
                var liabilityLimit_DropDown = _fileReader.GetOptionalValue(filePath, $"{profileKey}.LiabilityLimit");

                await Button.ClickButtonAsync(Coverages_Tab, ActionType.Click, true, 1);
                await InputField.SetTextAreaInputFieldAsync(NumberOfOwners, numberOfOwners, true, 1);
                await InputField.SetTextAreaInputFieldAsync(NumberOfFullTimeEmployees_Inp, numberOfFullTimeEmployees_Inp, true, 1);
                await InputField.SetTextAreaInputFieldAsync(NumberOfPartTimeEmployees_Inp, numberOfPartTimeEmployees_Inp, true, 1);
                await RadioButton.SelectRadioButtonAsync(SnowRemoval_RadioButton, snowRemoval_RadioButton,true, 1);
                await DropDown.SelectDropDownAsync(MedicalPaymentsLimit_DropDown, medicalPaymentsLimit_DropDown, true, 1);
                await DropDown.SelectDropDownAsync(FireLegalLimit_DropDown,fireLegalLimit_DropDown , true, 1);
                await DropDown.SelectDropDownAsync(LiabilityLimit_DropDown, liabilityLimit_DropDown, true, 1);

                logger.WriteLine($"Retrieved Tradesman Cover Coverages data for: {numberOfOwners} {liabilityLimit_DropDown}");

                // Note: Form filling implementation would go here using the same pattern as BasicInformationPage
                // with the page elements (Button, InputField, DropDown, etc.) once they are properly resolved

                logger.WriteLine($"Successfully filled Tradesman Cover Coverages information using profile: {profileKey}");
                logger.WriteLine("Tradesman Cover Coverages Page Details Entered Successfully from JSON Data");
            }
            catch (Exception ex)
            {
                logger.WriteLine($"Error filling Tradesman Cover Coverages data: {ex.Message}");
                throw new Exception($"Failed to fill Tradesman Cover Coverages data using profile '{profileKey}': {ex.Message}", ex);
            }
        }
        public async Task EnhancementInformationAsync(string profileKey)
        {
            if (_fileReader == null)
            {
                throw new InvalidOperationException("FileReader is not available. Use constructor with IFileReader parameter.");
            }

            try
            {
                logger.WriteLine($"Starting to fill Tradesman Cover Enhancement information using profile: {profileKey}");

                var filePath = "TradesmanCover\\TradesmanCoverData.json";
                var commLiabEE_Radio = _fileReader.GetOptionalValue(filePath, $"{profileKey}.CommLiabEE");
                var premierCommLiabEE_Radio = _fileReader.GetOptionalValue(filePath, $"{profileKey}.PremierCommLiabEE");
                var commPropEE_Radio = _fileReader.GetOptionalValue(filePath, $"{profileKey}.CommPropEE");
                var premierCommPropEE_Radio = _fileReader.GetOptionalValue(filePath, $"{profileKey}.PremierCommPropEE");
                
                await Button.ClickButtonAsync(Enhancement_SubTab, ActionType.Click, true, 1);
                await RadioButton.SelectRadioButtonAsync(CommLiabEE_Radio, commLiabEE_Radio, true, 1);
                await RadioButton.SelectRadioButtonAsync(PremierCommLiabEE_Radio, premierCommLiabEE_Radio, true, 1);
                await RadioButton.SelectRadioButtonAsync(CommPropEE_Radio, commPropEE_Radio, true, 1);
                await RadioButton.SelectRadioButtonAsync(PremierCommPropEE_Radio, premierCommPropEE_Radio, true, 1);
               
                logger.WriteLine($"Retrieved Tradesman Cover Enhancement data for: {commLiabEE_Radio} {premierCommPropEE_Radio}");

                // Note: Form filling implementation would go here using the same pattern as BasicInformationPage
                // with the page elements (Button, InputField, DropDown, etc.) once they are properly resolved

                logger.WriteLine($"Successfully filled Tradesman Cover Enhancement information using profile: {profileKey}");
                logger.WriteLine("Tradesman Cover Enhancement Page Details Entered Successfully from JSON Data");
            }
            catch (Exception ex)
            {
                logger.WriteLine($"Error filling Tradesman Cover Enhancement data: {ex.Message}");
                throw new Exception($"Failed to fill Tradesman Cover Enhancement data using profile '{profileKey}': {ex.Message}", ex);
            }
        }
        public async Task ToolsEquipmentInformationAsync(string profileKey)
        {
            if (_fileReader == null)
            {
                throw new InvalidOperationException("FileReader is not available. Use constructor with IFileReader parameter.");
            }

            try
            {
                logger.WriteLine($"Starting to fill Tradesman Cover ToolsEquipment information using profile: {profileKey}");

                var filePath = "TradesmanCover\\TradesmanCoverData.json";
                var tools_EquipmentLimit_Input = _fileReader.GetOptionalValue(filePath, $"{profileKey}.ToolsEquipmentLimit");
                var tools_Equipment_Deductibles_DropDown = _fileReader.GetOptionalValue(filePath, $"{profileKey}.ToolsEquipmentDeductible");

                await Button.ClickButtonAsync(Tools_Equipment_SubTab, ActionType.Click, true, 1);
                await InputField.SetTextAreaInputFieldAsync(Tools_EquipmentLimit_Input, tools_EquipmentLimit_Input, true, 1);
                await DropDown.SelectDropDownAsync(Tools_Equipment_Deductibles_DropDown, tools_Equipment_Deductibles_DropDown, true, 1);
                
                logger.WriteLine($"Retrieved Tradesman Cover ToolsEquipment data for: {tools_EquipmentLimit_Input} {tools_Equipment_Deductibles_DropDown} ");

                // Note: Form filling implementation would go here using the same pattern as BasicInformationPage
                // with the page elements (Button, InputField, DropDown, etc.) once they are properly resolved

                logger.WriteLine($"Successfully filled Tradesman Cover ToolsEquipment information using profile: {profileKey}");
                logger.WriteLine("Tradesman Cover ToolsEquipment Page Details Entered Successfully from JSON Data");
            }
            catch (Exception ex)
            {
                logger.WriteLine($"Error filling Tradesman Cover ToolsEquipment data: {ex.Message}");
                throw new Exception($"Failed to fill Tradesman Cover ToolsEquipment data using profile '{profileKey}': {ex.Message}", ex);
            }
        }
        public async Task SummaryInformationAsync()
        {
            await Button.ClickButtonAsync(Summary_Link, ActionType.Click, true, 1);
            //await Button.ScrollIntoViewAsync(PremiumText, true, 1);
            //Label.VerifyText(PremiumText, "Premium", true, 1);
        }
        public async Task EstimatedPremiumValidationAsync()
        {
            /*string EstimatedPremiumText1 = Label.GetText(EstimatedPremiumText, true, 1);
            Thread.Sleep(5000);
            string EstimatedPremium = NumberExtractor.GetFirstNumber(EstimatedPremiumText1);
            //_applicationLogger.WriteLine("Estimated Premium Value is:$" + EstimatedPremiumText1);
            if (!EstimatedPremiumText1.Contains("$"))
            {
                throw new Exception("Estimated Premium has not generated");
            }*/
        }
        public async Task LocationPremiumValidationAsync()
        {
            
           /* string PremiumValueText = Driver.FindElement(OpenQA.Selenium.By.XPath(PremiumValue)).Text;

            if (PremiumValueText.Contains("$"))
            {
                _applicationLogger.WriteLine("Location Premium Value is:$" + PremiumValueText);
            }
            else
            {
                throw new Exception("Location Premium has not generated");
            }*/
        }
        public async Task DeleteQuoteAsync()
        {
            
            /*string text = Driver.FindElement(OpenQA.Selenium.By.XPath(QuoteNumber_Text)).Text;
            string QuoteNumber = NumberExtractor.GetFirstNumber(text);
            await Button.ScrollIntoViewAsync(Delete_Button, true, 1);          
            await Button.ClickButtonAsync(Delete_Button, ActionType.Click, true, 1);
            Thread.Sleep(10000);
            Driver.SwitchTo().Alert().Accept();

            await Button.ClickButtonCssAsync( ShadowHostSlidePanelShadow,SearchSidePanelShadow);

            InputField.SetTextAreaInputField(SearchPolicyPage_Keyword_Inp, QuoteNumber, true);

            await Button.ScrollIntoViewAsync(NoRecordsText, true, 1);

            if (Label.VerifyTextAsync(NoRecordsText, "No Records Returned!", true, 1) == true)
            {
                Console.WriteLine("Quote has been deleted Successfully");
            }*/
        }
        public async Task BillingInformationAsync(string profileKey)
        {                 
            if (_fileReader == null)
            {
                throw new InvalidOperationException("FileReader is not available. Use constructor with IFileReader parameter.");
            }

            try
            {
                logger.WriteLine($"Starting to fill Tradesman Cover Billing information using profile: {profileKey}");
                var filePath = "TradesmanCover\\TradesmanCoverData.json";
                var payInFull_RadioButton = _fileReader.GetOptionalValue(filePath, $"{profileKey}.PayInFull_RadioButton");
                
                await Button.ClickButtonAsync(Billing_Tab, ActionType.Click, true, 1);
                await RadioButton.SelectRadioButtonAsync(PayInFull_RadioButton, payInFull_RadioButton, true, 1);

                logger.WriteLine($"Retrieved Tradesman Cover Billing data for: {payInFull_RadioButton}");

                // Note: Form filling implementation would go here using the same pattern as BasicInformationPage
                // with the page elements (Button, InputField, DropDown, etc.) once they are properly resolved

                logger.WriteLine($"Successfully filled Tradesman Cover Billing information using profile: {profileKey}");
                logger.WriteLine("Tradesman Cover Billing Page Details Entered Successfully from JSON Data");
            }
            catch (Exception ex)
            {
                logger.WriteLine($"Error filling Tradesman Cover Billing data: {ex.Message}");
                throw new Exception($"Failed to fill Tradesman Cover Billing data using profile '{profileKey}': {ex.Message}", ex);
            }
        }
        public async Task BindingInformationAsync(string profileKey)
        {
            if (_fileReader == null)
            {
                throw new InvalidOperationException("FileReader is not available. Use constructor with IFileReader parameter.");
            }

            try
            {
                logger.WriteLine($"Starting to fill Tradesman Cover Binding information using profile: {profileKey}");

                var filePath = "TradesmanCover\\TradesmanCoverData.json";
                var bindingProducer_Dropdown = _fileReader.GetOptionalValue(filePath, $"{profileKey}.BindingProducer_Dropdown");
                var agentEmail_Input = _fileReader.GetOptionalValue(filePath, $"{profileKey}.AgentEmail_Input");
                var numberOfYearsExperience_input = _fileReader.GetOptionalValue(filePath, $"{profileKey}.NumberOfYearsExperience_input");
                var subcontractwork_radioButton = _fileReader.GetOptionalValue(filePath, $"{profileKey}.Subcontractwork_radioButton");
                var droneUse_radioButton = _fileReader.GetOptionalValue(filePath, $"{profileKey}.DroneUse_radioButton");
                var asbestosWork_radioButton = _fileReader.GetOptionalValue(filePath, $"{profileKey}.AsbestosWork_radioButton");
                var roofOnly_radioButton = _fileReader.GetOptionalValue(filePath, $"{profileKey}.RoofOnly_radioButton");              
                var demolition_radioButton = _fileReader.GetOptionalValue(filePath, $"{profileKey}.Demolition_radioButton");
                var eifs_radioButton = _fileReader.GetOptionalValue(filePath, $"{profileKey}.Eifs_radioButton");

                //await Button.ScrollIntoViewAsync(Bind_Tab, true, 1);
                //_driverwait.Until(driver => driver.FindElement(OpenQA.Selenium.By.XPath(Bind_Tab)).Displayed);
                await Button.ClickButtonAsync(Bind_Tab, ActionType.Click, true, 1);
                await DropDown.SelectDropDownAsync(BindingProducer_Dropdown, bindingProducer_Dropdown, true, 1);
                //await Button.ScrollIntoViewAsync(AgentEmail_Input, true, 1);
                await InputField.SetTextAreaInputFieldAsync(AgentEmail_Input, agentEmail_Input, true, 1);
                await InputField.SetTextAreaInputFieldAsync(NumberOfYearsExperience_input, numberOfYearsExperience_input, true, 1);
                await RadioButton.SelectRadioButtonAsync(Subcontractwork_radioButton, subcontractwork_radioButton,true, 1);
                await RadioButton.SelectRadioButtonAsync(DroneUse_radioButton, droneUse_radioButton,true, 1);
                await RadioButton.SelectRadioButtonAsync(AsbestosWork_radioButton, asbestosWork_radioButton,true, 1);
                await RadioButton.SelectRadioButtonAsync(RoofOnly_radioButton, roofOnly_radioButton,true, 1);
                await RadioButton.SelectRadioButtonAsync(Demolition_radioButton, demolition_radioButton,true, 1);
                await RadioButton.SelectRadioButtonAsync(Eifs_radioButton, eifs_radioButton, true, 1);
                //await Button.ScrollIntoViewAsync(AttachDocument_Tab, true, 1);
                //_driverwait.Until(driver => driver.FindElement(OpenQA.Selenium.By.XPath(AttachDocument_Tab)).Displayed);
                await Button.ClickButtonAsync(AttachDocument_Tab, ActionType.Click, true, 1);
                //await Button.ScrollIntoViewAsync(ReturnToBinding_Button, true, 1);
                //_driverwait.Until(driver => driver.FindElement(OpenQA.Selenium.By.XPath(ReturnToBinding_Button)).Displayed);
                await Button.ClickButtonForStaleElementWithoutDepenAsync(ReturnToBinding_Button, ActionType.Click, true, 1);
                //Thread.Sleep(5000);
                await Checkbox.SelectCheckboxAsync(BindingTermsAndConditions_checkbox, true, true, 1);
                //Thread.Sleep(5000);
                //commonFunctions.CheckAllMessageOverrideCheckboxes();
                //commonFunctions.clickAllCheckboxes();
                Thread.Sleep(2000);
                //await Button.ScrollIntoViewAsync(BindPolicyWithGoodville_Button, true, 1);
                //_driverwait.Until(driver => driver.FindElement(OpenQA.Selenium.By.XPath(BindPolicyWithGoodville_Button)).Displayed);
                await Button.ClickButtonForStaleElementWithoutDepenAsync(BindPolicyWithGoodville_Button, ActionType.Click, true, 1);
                //_driverwait.Until(driver => driver.FindElement(OpenQA.Selenium.By.XPath(Ok_Button)).Displayed);
                Thread.Sleep(5000);
                await Button.ClickButtonAsync(Ok_Button, ActionType.Click, true, 1);
                Thread.Sleep(20000);
                //commonFunctions.validateApplicantDetails();

                logger.WriteLine($"Retrieved Tradesman Cover Binding data for: {bindingProducer_Dropdown} {eifs_radioButton}");

                // Note: Form filling implementation would go here using the same pattern as BasicInformationPage
                // with the page elements (Button, InputField, DropDown, etc.) once they are properly resolved

                logger.WriteLine($"Successfully filled Tradesman Cover Binding information using profile: {profileKey}");
                logger.WriteLine("Tradesman Cover Binding Page Details Entered Successfully from JSON Data");
            }
            catch (Exception ex)
            {
                logger.WriteLine($"Error filling Tradesman Cover Binding data: {ex.Message}");
                throw new Exception($"Failed to fill Tradesman Cover Binding data using profile '{profileKey}': {ex.Message}", ex);
            }
        }
    }
}

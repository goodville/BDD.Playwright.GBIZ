using BDD.Playwright.Core.Interfaces;
using BDD.Playwright.GBIZ.PageElements;
using BDD.Playwright.GBIZ.Pages.CommonPage;
using BDD.Playwright.GBIZ.Pages.GlobalPages;
using BDD.Playwright.GBIZ.Pages.XpathProperties;
using Reqnroll;

namespace GoodVille.GBIZ.Reqnroll.Automation.Pages.AgentPages
{
    public class Quote_BindingPage : BasePage
    {
        private readonly ScenarioContext _scenarioContext;
        public FeatureContext _featureContext;
        public CommonXpath _commonXpath;
        public LoginPage _loginPage;
        private readonly IFileReader _fileReader;

        public Quote_BindingPage(ScenarioContext scenarioContext, LoginPage loginPage, CommonXpath commonXpath, IFileReader fileReader) : base(scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _loginPage = loginPage;
            _commonXpath = commonXpath;
            _fileReader = fileReader;
        }

        #region Xpath
        public string Office_Drp { get; set; } = "//select[@name='binding_office']";
        public string Producer_Drp { get; set; } = "//select[@name='binding_producer']";
        public string AgentEmail { get; set; } = "//input[@name='applicationEmail']";
        public string InsuranceTransferredAgency { get; set; } = "//input[@name='insuranceTransferred' and @value='{0}']";
        public string CoverageDeclined { get; set; } = "//input[@name='coverageDeclined' and @value='{0}']";
        public string ApplicantConvictedArson { get; set; } = "//input[@name='applicantConvictedArson' and @value='{0}']";
        public string BindingDestinationemail { get; set; } = "//input[@name='binding_destinationemail' and @value='{0}']";
        public string Remarks { get; set; } = "//textarea[@name='binding_remarks']";
        public string CoverageBound { get; set; } = "//input[@name='binding_iscoveragebound' and @value='{0}']";
        public string AgreeTerms { get; set; } = "//input[@name='binding_agreetoterms']";
        #endregion
        // Add other locators as needed, including Homeowners fields...
        #region Quote_HomeOwnerBinding
        public string HO_Phone_Input { get; set; } = "//input[@id='fld_phone']";
        public string HO_MaritalStatus_DropDown { get; set; } = "//select[@id='fld_maritalStatus']";
        public string HO_Occupation_DropDown { get; set; } = "//select[@id='fld_occupation']";
        public string HO_NoYearsCurrentEmployer_Input { get; set; } = "//input[@id='fld_noYearsCurrentEmployer']";
        public string HO_SecondMaritalStatus_DropDown { get; set; } = "//select[@id='fld_secondmaritalStatus']";
        public string HO_SecondOccupation_DropDown { get; set; } = "//select[@id='fld_secondoccupation']";
        public string HO_SecondNoYearsCurrentEmployer_Input { get; set; } = "//input[@id='fld_secondnoYearsCurrentEmployer']";
        public string HO_AddlInfoPriorInsuranceCarrier_DropDown { get; set; } = "//select[@id='fld_addlinfoPriorInsuranceCarrier']";
        public string HO_PriorPolicyExpireDate_Input { get; set; } = "//input[@id='fld_priorPolicyExpireDate']";
        public string HO_NoYearsKnown_Input { get; set; } = "//input[@id='fld_noYearsKnown']";
        #endregion

        #region
        public string HO_ResidenceEmployees_DropDown { get; set; } = "//input[@name='residenceEmployees' and @value='{0}']";
        public string HO_HadForeclosure_DropDown { get; set; } = "//input[contains(@id,'hadAForeclosure') and @value='{0}']";
        public string HO_TaxLien_DropDown { get; set; } = "//input[contains(@id,'taxLien') and @value='{0}']";
        public string HO_BusinessOnPremises_DropDown { get; set; } = "//input[contains(@id,'haveBusinessOnPremises') and @value='{0}']";
        public string HO_HasDogs_DropDown { get; set; } = "//input[@name='hasDogs' and @value='{0}']";
        public string HO_AnimalsOrExoticPets_DropDown { get; set; } = "//input[contains(@id,'animalsOrExoticPets') and @value='{0}']";
        public string HO_MoreFiveAcres_DropDown { get; set; } = "//input[contains(@id,'moreFiveAcres') and @value='{0}']";
        public string HO_RecreationalVehicles_DropDown { get; set; } = "//input[contains(@id,'recreationalVehicles') and @value='{0}']";
        public string HO_HouseForSale_DropDown { get; set; } = "//input[contains(@id,'houseForSale') and @value='{0}']";
        public string HO_BuildingRenovation_DropDown { get; set; } = "//input[contains(@id,'buildingRenovation') and @value='{0}']";
        public string HO_UncorrectedFireBuildingViolations_DropDown { get; set; } = "//input[contains(@id,'uncorrectedFireBuildingViolations') and @value='{0}']";
        public string HO_IsTrampoline_DropDown { get; set; } = "//input[contains(@id,'isTrampoline') and @value='{0}']";
        public string HO_IsPool_DropDown { get; set; } = "//input[contains(@id,'isPool') and @value='{0}']";
        public string HO_ZipLine_DropDown { get; set; } = "//input[contains(@id,'zipLine') and @value='{0}']";
        public string HO_StructureConverted_DropDown { get; set; } = "//input[contains(@id,'structureConverted') and @value='{0}']";
        public string HO_Is911Address_DropDown { get; set; } = "//input[contains(@id,'is911Address') and @value='{0}']";
        public string HO_OccupiedDaily_DropDown { get; set; } = "//input[contains(@id,'occupiedDaily') and @value='{0}']";
        public string HO_SharedProgram_DropDown { get; set; } = "//input[contains(@id,'sharedProgram') and @value='{0}']";
        public string HO_LogHome_DropDown { get; set; } = "//input[contains(@id,'logHome') and @value='{0}']";
        public string HO_HistoricRegisteredHome_DropDown { get; set; } = "//input[contains(@id,'historicRegisteredHome') and @value='{0}']";
        public string HO_DrivingDirections { get; set; } = "//textarea[@id='fld_drivingDirections']";
#endregion

        public async Task BindingDataFillAsync(string profileKey)
        {
            var filePath = "QuoteBindingPage\\QuoteBindingPage.json";

            // Office Dropdown
            var officeValue = _fileReader.GetOptionalValue(filePath, $"{profileKey}.AgencyOffice");
            if (!string.IsNullOrEmpty(officeValue))
            {
                await DropDown.SelectDropDownAsync(Office_Drp, officeValue, true, 1);
            }

            // Producer Dropdown
            var producerValue = _fileReader.GetOptionalValue(filePath, $"{profileKey}.AgencyProducer");
            if (!string.IsNullOrEmpty(producerValue))
            {
                await DropDown.SelectDropDownAsync(Producer_Drp, producerValue, true, 1);
            }

            // Agent Email
            var agentEmailValue = _fileReader.GetOptionalValue(filePath, $"{profileKey}.AgentEmail");
            if (!string.IsNullOrEmpty(agentEmailValue))
            {
                await InputField.SetInputFieldAsync(AgentEmail, agentEmailValue, true, 1);
            }

            // Insurance Transferred Agency (radio)
            var insuranceTransferredValue = _fileReader.GetOptionalValue(filePath, $"{profileKey}.HasInsurancebeenTransferredWithinAgency");
            if (!string.IsNullOrEmpty(insuranceTransferredValue))
            {
                var radioXpath = string.Format(InsuranceTransferredAgency, insuranceTransferredValue);
                await RadioButton.SelectRadioButtonAsync(radioXpath,"VALUE",true, 1);
            }

            // Coverage Declined (radio)
            var coverageDeclinedValue = _fileReader.GetOptionalValue(filePath, $"{profileKey}.CoverageDeclined");
            if (!string.IsNullOrEmpty(coverageDeclinedValue))
            {
                var radioXpath = string.Format(CoverageDeclined, coverageDeclinedValue);
                await RadioButton.SelectRadioButtonAsync(radioXpath,"VALUE", true, 1);
            }

            // Applicant Convicted Arson (radio)
            var convictedArsonValue = _fileReader.GetOptionalValue(filePath, $"{profileKey}.ApplicantConvictedArson");
            if (!string.IsNullOrEmpty(convictedArsonValue))
            {
                var radioXpath = string.Format(ApplicantConvictedArson, convictedArsonValue);
                await RadioButton.SelectRadioButtonAsync(radioXpath,"VALUE", true, 1);
            }

            // Binding Destination Email (radio)
            var destinationEmailValue = _fileReader.GetOptionalValue(filePath, $"{profileKey}.EmailRecipient");
            if (!string.IsNullOrEmpty(destinationEmailValue))
            {
                var radioXpath = string.Format(BindingDestinationemail, destinationEmailValue);
                await RadioButton.SelectRadioButtonAsync(radioXpath,"VALUE", true, 1);
            }

            // Remarks (textarea)
            var remarksValue = _fileReader.GetOptionalValue(filePath, $"{profileKey}.Remarks");
            if (!string.IsNullOrEmpty(remarksValue))
            {
                await InputField.SetTextAreaInputFieldAsync(Remarks, remarksValue, true, 1);
            }

            // Coverage Bound (radio)
            var coverageBoundValue = _fileReader.GetOptionalValue(filePath, $"{profileKey}.IsCoverageBound");
            if (!string.IsNullOrEmpty(coverageBoundValue))
            {
                var radioXpath = string.Format(CoverageBound, coverageBoundValue);
                await RadioButton.SelectRadioButtonAsync(radioXpath,"VALUE", true, 1);
            }

            // Agreement Terms Checkbox
            var agreeTermsValue = _fileReader.GetOptionalValue(filePath, $"{profileKey}.AgreeTerms");
            if (!string.IsNullOrEmpty(agreeTermsValue) && agreeTermsValue == "Yes")
            {
                await Checkbox.SelectCheckboxAsync(AgreeTerms, true, true, 1, "I agree to the above terms and conditions.");
            }

            await Checkbox.VerifyCheckboxExistAsync(AgreeTerms, true, 1, "I agree to the above terms and conditions.");

            var hoPhoneValue = _fileReader.GetOptionalValue(filePath, $"{profileKey}.HOPhone");
            if (!string.IsNullOrEmpty(hoPhoneValue))
            {
                await InputField.SetInputFieldAsync(HO_Phone_Input, hoPhoneValue, true, 1);
            }

            var hoMaritalStatusValue = _fileReader.GetOptionalValue(filePath, $"{profileKey}.HOMaritalStatus");
            if (!string.IsNullOrEmpty(hoMaritalStatusValue))
            {
                await DropDown.SelectDropDownAsync(HO_MaritalStatus_DropDown, hoMaritalStatusValue, true, 1);
            }

            var hoOccupationValue = _fileReader.GetOptionalValue(filePath, $"{profileKey}.HOOccupation");
            if (!string.IsNullOrEmpty(hoOccupationValue))
            {
                await DropDown.SelectDropDownAsync(HO_Occupation_DropDown, hoOccupationValue, true, 1);
            }

            var hoNoYearsCurrentEmployerValue = _fileReader.GetOptionalValue(filePath, $"{profileKey}.HONoYearsCurrentEmployer");
            if (!string.IsNullOrEmpty(hoNoYearsCurrentEmployerValue))
            {
                await InputField.SetInputFieldAsync(HO_NoYearsCurrentEmployer_Input, hoNoYearsCurrentEmployerValue, true, 1);
            }

            var hoSecondMaritalStatusValue = _fileReader.GetOptionalValue(filePath, $"{profileKey}.HOSecondMaritalStatus");
            if (!string.IsNullOrEmpty(hoSecondMaritalStatusValue))
            {
                await DropDown.SelectDropDownAsync(HO_SecondMaritalStatus_DropDown, hoSecondMaritalStatusValue, true, 1);
            }

            var hoSecondOccupationValue = _fileReader.GetOptionalValue(filePath, $"{profileKey}.HOSecondOccupation");
            if (!string.IsNullOrEmpty(hoSecondOccupationValue))
            {
                await DropDown.SelectDropDownAsync(HO_SecondOccupation_DropDown, hoSecondOccupationValue, true, 1);
            }

            var hoSecondNoYearsCurrentEmployerValue = _fileReader.GetOptionalValue(filePath, $"{profileKey}.HOSecondNoYearsCurrentEmployer");
            if (!string.IsNullOrEmpty(hoSecondNoYearsCurrentEmployerValue))
            {
                await InputField.SetInputFieldAsync(HO_SecondNoYearsCurrentEmployer_Input, hoSecondNoYearsCurrentEmployerValue, true, 1);
            }

            var hoAddlInfoPriorInsuranceCarrierValue = _fileReader.GetOptionalValue(filePath, $"{profileKey}.HOAddlInfoPriorInsuranceCarrier");
            if (!string.IsNullOrEmpty(hoAddlInfoPriorInsuranceCarrierValue))
            {
                await DropDown.SelectDropDownAsync(HO_AddlInfoPriorInsuranceCarrier_DropDown, hoAddlInfoPriorInsuranceCarrierValue, true, 1);
            }

            var hoPriorPolicyExpireDateValue = _fileReader.GetOptionalValue(filePath, $"{profileKey}.HOPriorPolicyExpireDate");
            if (!string.IsNullOrEmpty(hoPriorPolicyExpireDateValue))
            {
                await InputField.SetInputFieldAsync(HO_PriorPolicyExpireDate_Input, hoPriorPolicyExpireDateValue, true, 1);
            }

            var hoNoYearsKnownValue = _fileReader.GetOptionalValue(filePath, $"{profileKey}.HONoYearsKnown");
            if (!string.IsNullOrEmpty(hoNoYearsKnownValue))
            {
                await InputField.SetInputFieldAsync(HO_NoYearsKnown_Input, hoNoYearsKnownValue, true, 1);
            }

            // All Homeowner Radios (pattern: radioXpath = string.Format(...), then await RadioButton.SelectRadioButtonAsync(...))
            // HO_ResidenceEmployees (radio)
            var HO_ResidenceEmployees_Value = _fileReader.GetOptionalValue(filePath, $"{profileKey}.HO_ResidenceEmployees");
            if (!string.IsNullOrEmpty(HO_ResidenceEmployees_Value))
            {
                var radioXpath = string.Format(HO_ResidenceEmployees_DropDown, HO_ResidenceEmployees_Value);
                await RadioButton.SelectRadioButtonAsync(radioXpath, "VALUE", true, 1);
            }

            // HO_HadForeclosure (radio)
            var HO_HadForeclosure_Value = _fileReader.GetOptionalValue(filePath, $"{profileKey}.HO_HadForeclosure");
            if (!string.IsNullOrEmpty(HO_HadForeclosure_Value))
            {
                var radioXpath = string.Format(HO_HadForeclosure_DropDown, HO_HadForeclosure_Value);
                await RadioButton.SelectRadioButtonAsync(radioXpath, "VALUE", true, 1);
            }

            // HO_TaxLien (radio)
            var HO_TaxLien_Value = _fileReader.GetOptionalValue(filePath, $"{profileKey}.HO_TaxLien");
            if (!string.IsNullOrEmpty(HO_TaxLien_Value))
            {
                var radioXpath = string.Format(HO_TaxLien_DropDown, HO_TaxLien_Value);
                await RadioButton.SelectRadioButtonAsync(radioXpath, "VALUE", true, 1);
            }

            // HO_BusinessOnPremises (radio)
            var HO_BusinessOnPremises_Value = _fileReader.GetOptionalValue(filePath, $"{profileKey}.HO_BusinessOnPremises");
            if (!string.IsNullOrEmpty(HO_BusinessOnPremises_Value))
            {
                var radioXpath = string.Format(HO_BusinessOnPremises_DropDown, HO_BusinessOnPremises_Value);
                await RadioButton.SelectRadioButtonAsync(radioXpath, "VALUE", true, 1);
            }

            // HO_HasDogs (radio)
            var HO_HasDogs_Value = _fileReader.GetOptionalValue(filePath, $"{profileKey}.HO_HasDogs");
            if (!string.IsNullOrEmpty(HO_HasDogs_Value))
            {
                var radioXpath = string.Format(HO_HasDogs_DropDown, HO_HasDogs_Value);
                await RadioButton.SelectRadioButtonAsync(radioXpath, "VALUE", true, 1);
            }

            // HO_AnimalsOrExoticPets (radio)
            var HO_AnimalsOrExoticPets_Value = _fileReader.GetOptionalValue(filePath, $"{profileKey}.HO_AnimalsOrExoticPets");
            if (!string.IsNullOrEmpty(HO_AnimalsOrExoticPets_Value))
            {
                var radioXpath = string.Format(HO_AnimalsOrExoticPets_DropDown, HO_AnimalsOrExoticPets_Value);
                await RadioButton.SelectRadioButtonAsync(radioXpath, "VALUE", true, 1);
            }

            // HO_MoreFiveAcres (radio)
            var HO_MoreFiveAcres_Value = _fileReader.GetOptionalValue(filePath, $"{profileKey}.HO_MoreFiveAcres");
            if (!string.IsNullOrEmpty(HO_MoreFiveAcres_Value))
            {
                var radioXpath = string.Format(HO_MoreFiveAcres_DropDown, HO_MoreFiveAcres_Value);
                await RadioButton.SelectRadioButtonAsync(radioXpath, "VALUE", true, 1);
            }

            // HO_RecreationalVehicles (radio)
            var HO_RecreationalVehicles_Value = _fileReader.GetOptionalValue(filePath, $"{profileKey}.HO_RecreationalVehicles");
            if (!string.IsNullOrEmpty(HO_RecreationalVehicles_Value))
            {
                var radioXpath = string.Format(HO_RecreationalVehicles_DropDown, HO_RecreationalVehicles_Value);
                await RadioButton.SelectRadioButtonAsync(radioXpath, "VALUE", true, 1);
            }

            // HO_HouseForSale (radio)
            var HO_HouseForSale_Value = _fileReader.GetOptionalValue(filePath, $"{profileKey}.HO_HouseForSale");
            if (!string.IsNullOrEmpty(HO_HouseForSale_Value))
            {
                var radioXpath = string.Format(HO_HouseForSale_DropDown, HO_HouseForSale_Value);
                await RadioButton.SelectRadioButtonAsync(radioXpath, "VALUE", true, 1);
            }

            // HO_BuildingRenovation (radio)
            var HO_BuildingRenovation_Value = _fileReader.GetOptionalValue(filePath, $"{profileKey}.HO_BuildingRenovation");
            if (!string.IsNullOrEmpty(HO_BuildingRenovation_Value))
            {
                var radioXpath = string.Format(HO_BuildingRenovation_DropDown, HO_BuildingRenovation_Value);
                await RadioButton.SelectRadioButtonAsync(radioXpath, "VALUE", true, 1);
            }

            // HO_UncorrectedFireBuildingViolations (radio)
            var HO_UncorrectedFireBuildingViolations_Value = _fileReader.GetOptionalValue(filePath, $"{profileKey}.HO_UncorrectedFireBuildingViolations");
            if (!string.IsNullOrEmpty(HO_UncorrectedFireBuildingViolations_Value))
            {
                var radioXpath = string.Format(HO_UncorrectedFireBuildingViolations_DropDown, HO_UncorrectedFireBuildingViolations_Value);
                await RadioButton.SelectRadioButtonAsync(radioXpath, "VALUE", true, 1);
            }

            // HO_IsTrampoline (radio)
            var HO_IsTrampoline_Value = _fileReader.GetOptionalValue(filePath, $"{profileKey}.HO_IsTrampoline");
            if (!string.IsNullOrEmpty(HO_IsTrampoline_Value))
            {
                var radioXpath = string.Format(HO_IsTrampoline_DropDown, HO_IsTrampoline_Value);
                await RadioButton.SelectRadioButtonAsync(radioXpath, "VALUE", true, 1);
            }

            // HO_IsPool (radio)
            var HO_IsPool_Value = _fileReader.GetOptionalValue(filePath, $"{profileKey}.HO_IsPool");
            if (!string.IsNullOrEmpty(HO_IsPool_Value))
            {
                var radioXpath = string.Format(HO_IsPool_DropDown, HO_IsPool_Value);
                await RadioButton.SelectRadioButtonAsync(radioXpath, "VALUE", true, 1);
            }

            // HO_ZipLine (radio)
            var HO_ZipLine_Value = _fileReader.GetOptionalValue(filePath, $"{profileKey}.HO_ZipLine");
            if (!string.IsNullOrEmpty(HO_ZipLine_Value))
            {
                var radioXpath = string.Format(HO_ZipLine_DropDown, HO_ZipLine_Value);
                await RadioButton.SelectRadioButtonAsync(radioXpath, "VALUE", true, 1);
            }

            // HO_StructureConverted (radio)
            var HO_StructureConverted_Value = _fileReader.GetOptionalValue(filePath, $"{profileKey}.HO_StructureConverted");
            if (!string.IsNullOrEmpty(HO_StructureConverted_Value))
            {
                var radioXpath = string.Format(HO_StructureConverted_DropDown, HO_StructureConverted_Value);
                await RadioButton.SelectRadioButtonAsync(radioXpath, "VALUE", true, 1);
            }

            // HO_Is911Address (radio)
            var HO_Is911Address_Value = _fileReader.GetOptionalValue(filePath, $"{profileKey}.HO_Is911Address");
            if (!string.IsNullOrEmpty(HO_Is911Address_Value))
            {
                var radioXpath = string.Format(HO_Is911Address_DropDown, HO_Is911Address_Value);
                await RadioButton.SelectRadioButtonAsync(radioXpath, "VALUE", true, 1);
            }

            // HO_OccupiedDaily (radio)
            var HO_OccupiedDaily_Value = _fileReader.GetOptionalValue(filePath, $"{profileKey}.HO_OccupiedDaily");
            if (!string.IsNullOrEmpty(HO_OccupiedDaily_Value))
            {
                var radioXpath = string.Format(HO_OccupiedDaily_DropDown, HO_OccupiedDaily_Value);
                await RadioButton.SelectRadioButtonAsync(radioXpath, "VALUE", true, 1);
            }

            // HO_SharedProgram (radio)
            var HO_SharedProgram_Value = _fileReader.GetOptionalValue(filePath, $"{profileKey}.HO_SharedProgram");
            if (!string.IsNullOrEmpty(HO_SharedProgram_Value))
            {
                var radioXpath = string.Format(HO_SharedProgram_DropDown, HO_SharedProgram_Value);
                await RadioButton.SelectRadioButtonAsync(radioXpath, "VALUE", true, 1);
            }

            // HO_LogHome (radio)
            var HO_LogHome_Value = _fileReader.GetOptionalValue(filePath, $"{profileKey}.HO_LogHome");
            if (!string.IsNullOrEmpty(HO_LogHome_Value))
            {
                var radioXpath = string.Format(HO_LogHome_DropDown, HO_LogHome_Value);
                await RadioButton.SelectRadioButtonAsync(radioXpath, "VALUE", true, 1);
            }

            // HO_HistoricRegisteredHome (radio)
            var HO_HistoricRegisteredHome_Value = _fileReader.GetOptionalValue(filePath, $"{profileKey}.HO_HistoricRegisteredHome");
            if (!string.IsNullOrEmpty(HO_HistoricRegisteredHome_Value))
            {
                var radioXpath = string.Format(HO_HistoricRegisteredHome_DropDown, HO_HistoricRegisteredHome_Value);
                await RadioButton.SelectRadioButtonAsync(radioXpath, "VALUE", true, 1);
            }

            // Driving Directions
            var drivingDirectionsValue = _fileReader.GetOptionalValue(filePath, $"{profileKey}.HO_DrivingDirections");
            if (!string.IsNullOrEmpty(drivingDirectionsValue))
            {
                await InputField.SetTextAreaInputFieldAsync(HO_DrivingDirections, drivingDirectionsValue, true, 1);
            }
        }
    }
}
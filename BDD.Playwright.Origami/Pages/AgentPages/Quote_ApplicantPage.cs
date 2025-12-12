using BDD.Playwright.Core.Interfaces;
using BDD.Playwright.GBIZ.PageElements;
using BDD.Playwright.GBIZ.Pages.CommonPage;
using BDD.Playwright.GBIZ.Pages.GlobalPages;
using BDD.Playwright.GBIZ.Pages.XpathProperties;
using Microsoft.Playwright;
using OpenQA.Selenium.Support.UI;
using Reqnroll;
using System;
using System.Threading.Tasks;

namespace BDD.Playwright.GBIZ.Pages.AgentPages
{
    public class Quote_ApplicantPage : BasePage
    {
        private readonly IFileReader _fileReader;
        private readonly ScenarioContext _scenarioContext;
        public FeatureContext _featureContext;
        public CommonXpath _commonXpath;
        public LoginPage _loginPage;

        public Quote_ApplicantPage(
            ScenarioContext scenarioContext,
            IFileReader fileReader,
            LoginPage loginPage,
            CommonXpath commonXpath
        ) : base(scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _fileReader = fileReader;
            _loginPage = loginPage;
            _commonXpath = commonXpath;
        }

        #region xpath
        public string QuoteNumber_Text { get; set; } = "//div[@id='formheaderleft']";
        public string QuoteType_Drp { get; set; } = "//select[@name='quoteType']";
        public string QuoteDescription_Inp { get; set; } = "//input[contains(@id,'quoteDescription')]";
        public string EffectiveDate_Inp { get; set; } = "//input[contains(@id,'effectivedate')]";
        public string QuoteRollOver_Radio { get; set; } = "//input[contains(@id,'rollover') and @value='{0}']";
        public string QuoteRoolOverPreviousPremium { get; set; } = "//input[contains(@id,'rolloverpremium')]";
        public string QuoteRollOverPreviousLimit { get; set; } = "//input[contains(@id,'rolloverpremiumlimit')]";
        public string BookCode_Inp { get; set; } = "//input[contains(@id,'bookofbusiness')]";
        public string Office_Text { get; set; } = "//div[contains(@id,'descriptor_applicant_officedisplay')]";
        public string Office_Drp { get; set; } = "//select[contains(@id,'applicant_office')]";
        public string Producer_Drp { get; set; } = "//select[contains(@id,'applicant_producer')]";
        public string NamedInsured_FirstName_Inp { get; set; } = "//input[contains(@id,'fld_ni_firstName_1')]";

        public string NamedInsured_FirstName { get; set; } = "//input[contains(@id,'fld_ni_firstName')]";
        public string NamedInsured_MiddleName_Inp { get; set; } = "//input[contains(@id,'fld_ni_middleName_1')]";
        public string NamedInsured_LastName_Inp { get; set; } = "//input[contains(@id,'fld_ni_lastName_1')]";
        public string NamedInsured_LastName { get; set; } = "//input[contains(@id,'fld_ni_lastName')]";
        public string NamedInsured_Suffix_Drp { get; set; } = "//select[contains(@id,'ni_suffix')]";
        // public string NamedInsured_SSN_Inp { get; set; } = "//input[contains(@id,'ni_socialsecuritynumber')]";
        public string NamedInsured_SSN_Inp { get; set; } = "//input[contains(@id,'fld_ni_ssn_1') or @name='ni_socialsecuritynumbertext']";
        //public string Ho_NamedInsured_SSN_Inp { get; set; } = "//input[@name='ni_socialsecuritynumbertext']";

        // public string NamedInsured_DOB_Inp { get; set; } = "//input[contains(@id,'ni_dateofbirthtext')]";
        //public string NamedInsured_DOB_Inp { get; set; } = "//input[@name='ni_dob_1' or @name='ni_dateofbirthtext' ]";
        //public string NamedInsured_DOB_Inp { get; set; } = "//input[contains(@id,'fld_ni_dob_1')]";
        //public string NamedInsured_Email_Inp { get; set; } = "//input[contains(@id,'fld_ni_dob_1')]";
        //public string NamedInsured_DOB_Inp { get; set; } = "//input[contains(@name,'dob')]";
        //public string NamedInsured_Email_Inp { get; set; } = "//input[contains(@id,'fld_ni_dob_1')]";
        /* public string NamedInsured_DOB_Inp { get; set; } = "//input[contains(@id,'fld_ni_dob_1')]";
         public string NamedInsured_Email_Inp { get; set; } = "//input[contains(@id,'fld_ni_dob_1')]";*/
        //public string NamedInsured_DOB_Inp { get; set; } = "//input[@name='ni_dob_1']";
        public string NamedInsured_DOB_Inp { get; set; } = "//input[@id='fld_ni_dateOfBirthtext']";
        //public string NamedInsured_Email_Inp { get; set; } = "//input[contains(@id,'fld_ni_dob_1')]";
        //public string NamedInsured_DOB_Inp { get; set; } = "//input[@name='ni_dob_1']";

        public string NamedInsured_Email_Inp { get; set; } = "//input[@name='ni_email_1']";

        public string SecondNamedInsured_FirstName_Inp { get; set; } = "//input[contains(@id,'ci_firstname')]";
        public string SecondNamedInsured_MiddleName_Inp { get; set; } = "//input[contains(@id,'ci_middlename')]";
        public string SecondNamedInsured_LastName_Inp { get; set; } = "//input[contains(@id,'ci_lastname')]";
        public string SecondNamedInsured_Suffix_Drp { get; set; } = "//select[contains(@id,'ci_suffix')]";
        public string SecondNamedInsured_SSN_Inp { get; set; } = "//input[contains(@id,'ci_socialsecuritynumber')]";
        public string SecondNamedInsured_DOB_Inp { get; set; } = "//input[contains(@id,'ci_dateofbirthtext')]";
        public string AddOtherNamedInsured_Radio { get; set; } = "//input[contains(@id,'othernamedinsureds') and @value='{0}']";
        public string AddOtherNamedInsuredReason_Inp { get; set; } = "//textarea[contains(@id,'othernamedinsuredreason')]";
        public string AddressLine1_Inp { get; set; } = "//input[contains(@id,'sa_address1')]";
        public string AddressLine2_Inp { get; set; } = "//input[contains(@id,'sa_address2')]";
        public string City_Inp { get; set; } = "//input[contains(@id,'sa_city')]";
        public string ZipCode_Inp1 { get; set; } = "(//input[contains(@id,'sa_zip')])[1]";
        public string ZipCode_Inp2 { get; set; } = "(//input[contains(@id,'sa_zip')])[2]";
        //public string ZipCode_Inp3 { get; set; } = "//input[@name='sa_zip4']";
        public string AlsoMailingAddress_Radio { get; set; } = "//input[contains(@id,'sa_ismailingaddress') and @value='{0}']";
        public string Attention_Drp { get; set; } = "//select[contains(@id,'ma_attntype')]";
        public string Attention_Inp { get; set; } = "//input[contains(@id,'ma_attndetail')]";
        public string MailingAddressLine1_Inp { get; set; } = "//input[contains(@id,'ma_address1')]";
        public string MailingAddressLine2_Inp { get; set; } = "//input[contains(@id,'ma_address2')]";
        public string MailingZipCode_Inp { get; set; } = "//input[contains(@id,'ma_zip')]";
        public string NumberOfYears_Drp { get; set; } = "//select[contains(@id,'pa_numberyears')]";
        public string ResidenceType_Radio { get; set; } = "//div[contains(text(),'{0}')]/input[contains(@id,'residencetype')]";
        public string ReplacementCost_Radio { get; set; } = "//input[contains(@id,'useestimator') and @value='{0}']";
        public string TerritoryOverride_Inp { get; set; } = "//input[contains(@id,'territoryoverride')]";
        public string RealtionToInsured_Drp { get; set; } = "//select[contains(@id,'ci_relationshiptoinsured')]";
        public string ManualTerritory_Inp { get; set; } = "//input[contains(@id,'manualterritory')]";
        public string PolicyLimit_Drp { get; set; } = "//select[contains(@id,'pol_limit')]";
        public string Retention_Drp { get; set; } = "//select[contains(@id,'pol_retention')]";
        public string RegisterMemberPortal_Radio { get; set; } = "//input[contains(@id,'ni_registerpolicyholderaccount') and @value='{0}']";
        public string EmailAddress_Inp { get; set; } = "//input[@name='ni_email_1']";
        public string Phone_Inp { get; set; } = "//input[contains(@id,'ni_phone')]";
        public string UsePolicyAddress_Radio { get; set; } = "//input[contains(@id,'ni_usepolicyaddress') and @value='{0}']";
        public string State_Drp { get; set; } = "//select[contains(@id,'ni_state')]";
        public string State_Drp1 { get; set; } = "//select[contains(@id,'fld_sa_state')]";
        public string PrimaryHomeOwnerPolicyInsured { get; set; } = "//input[@name='addlinfoInsuranceForceWithGoodville' and @value='{0}']";
        public string InsuranceInForce { get; set; } = "//input[@name='addlinfoInsuranceForceWithGoodville' and @value='{0}']";
        public string ContinueButton { get; set; } = "//button[contains(text(),'Continue')]";
        public string NextButton { get; set; } = "//div[@id='bottomsubnav_nextlink']";
        // Shoeb_Farmowner_ApplicationPage_XPath
        public string Residence_Drpdwn { get; set; } = "//input[@id='fld_no_loc_WithResidence_1']";
        public string Farmbuil_Drp { get; set; } = "//input[@id='fld_yes_loc_WithFarmBuildings_1']";
        public string Biogas_DigesterDrp { get; set; } = "//input[@id='fld_no_loc_BiogasDigester_1']";
        public string Solarpanel_Drp { get; set; } = "//input[@id='fld_no_loc_WithSolarPanel_1']";

        // Vijay_BC_XPath
        public string Business_Type_Radio { get; set; } = "//input[contains(@id,'fld_businessType_1')  and @value='{0}']";
        public string BusinessDescription_Inp { get; set; } = "//textarea[@id='fld_businessDescription']";
        public string Business_Function_Radio { get; set; } = "//input[contains(@id,'cbAPTRENT_fld_businessFunction')  and @value='{0}']";
        public string InfoBusinessEndeavorBankruptcy_Radio { get; set; } = "//input[@name='addlinfoBusinessEndeavorBankruptcy' and @value='{0}']";
        public string InfoToolsEquipment_Radio { get; set; } = "//input[@name='addlinfoToolsEquipment' and @value='{0}']";
        public string InfoCanceledRefusedCoverage_Radio { get; set; } = "//input[@name='addlinfoCanceledRefusedCoverage' and @value='{0}']";
        public string SaveButton { get; set; } = "//a[normalize-space()='save']";

        // Rahul_WC_XPath
        public string Description_Input { get; set; } = "//textarea[contains(@id,'fld_bizDescription')]";
        //public string Office_Drp { get; set; } = "//select[@id='fld_applicant_office']";
        public string PolicyType_Dropdown { get; set; } = "//select[contains(@id,'policytype')]";
        public string QuoteNumber_Input { get; set; } = "//input[contains(@id,'fld_upy_quoteNumber_1')]";
        public string AddAnotherNamedInsured_Input { get; set; } = "//div[@id='ni_addIndividual']";
        public string FEIN_Input { get; set; } = "//input[@id='fld_ein']";
        public string ContactInfo_Name_Input { get; set; } = "//input[contains(@id,'fld_ContactInfoName')]";
        public string ContactInfo_OfficePhone_Input { get; set; } = "//input[contains(@id,'fld_ContactInfoOfficePhone')]";
        public string ContactInfo_MobilePhone_Input { get; set; } = "//input[contains(@id,'fld_ContactInfoMobilePhone')]";
        public string ContactInfo_Email_Input { get; set; } = "//input[contains(@id,'fld_ContactInfoEmail')]";
        public string UnderwritingInformationTab_Button { get; set; } = "//div[contains(text(),'Underwriting Information')]";
        public string SupportingContractClasses_Radio { get; set; } = "//input[@name='supportingcontractclasses' and @value='No']";
        public string Aircraft_Radio { get; set; } = "//input[@name='aircraft' and @value='No']";
        public string HazardousMaterial_Radio { get; set; } = "//input[@name='hazardousmaterial' and @value='No']";
        public string Underground_Radio { get; set; } = "//input[@name='underground' and @value='No']";
        public string BargesBridges_Radio { get; set; } = "//input[@name='bargesbridges' and @value='No']";
        public string OtherBusiness_Radio { get; set; } = "//input[@name='otherbusiness' and @value='No']";
        public string SafetyProgram_Radio { get; set; } = "//input[@name='safetyprogram' and @value='No']";
        public string EmployeesUnder16_Radio { get; set; } = "//input[@name='employeesunder16' and @value='No']";
        public string Seasonal_Radio { get; set; } = "//input[@name='seasonal' and @value='No']";
        public string VolunteerLabor_Radio { get; set; } = "//input[@name='volunteerlabor' and @value='No']";
        public string PhysicalHandicaps_Radio { get; set; } = "//input[@name='physicalhandicaps' and @value='No']";
        public string TravelOutOfState_Radio { get; set; } = "//input[@name='traveloutofstate' and @value='No']";
        public string AthleticTeams_Radio { get; set; } = "//input[@name='athleticteams' and @value='No']";
        public string PhysicalsRequired_Radio { get; set; } = "//input[@name='physicalsrequired' and @value='No']";
        public string OtherInsurance_Radio { get; set; } = "//input[@name='otherinsurance' and @value='No']";
        public string CoverageCancelled_Radio { get; set; } = "//input[@name='coveragecancelled' and @value='No']";
        public string HealthPlans_Radio { get; set; } = "//input[@name='healthplans' and @value='No']";
        public string OtherBusinesses_Radio { get; set; } = "//input[@name='otherbusinesses' and @value='No']";
        public string LeaseEmployees_Radio { get; set; } = "//input[@name='leaseemployees' and @value='No']";
        public string WorkAtHome_Radio { get; set; } = "//input[@name='workathome' and @value='No']";
        public string ContinuousWCcov_Select { get; set; } = "//select[@name='continuousWCcov']";
        public string Bankruptcy_Radio { get; set; } = "//input[@name='bankruptcy' and @value='No']";
        public string UndisputedPremium_Radio { get; set; } = "//input[@name='undisputedpremium' and @value='No']";
        public string Website_Radio { get; set; } = "//input[@name='website' and @value='No']";

        // Rahul HomeOwner XPath

        public string HO_FirstName_Input { get; set; } = "//input[@id='fld_ni_firstName']";
        public string HO_LastName_Input { get; set; } = "//input[@id='fld_ni_lastName']";
        public string H0_SocialSecurityNumber_Input { get; set; } = "//input[@id='fld_ni_socialSecurityNumbertext']";
        public string FirstName_Input { get; set; } = "//input[@id='fld_ci_firstName']";
        public string LastName_Input { get; set; } = "//input[@id='fld_ci_lastName']";
        public string SocialSecurityNumber_Input { get; set; } = "//input[@id='fld_ci_socialSecurityNumbertext']";
        public string DateOfBirth_Input { get; set; } = "//input[@id='fld_ci_dateOfBirthtext']";
        public string NumberYears_Dropdown { get; set; } = "//select[@id='fld_pa_numberyears']";
        public string ResidenceType1_Radio { get; set; } = "//input[@id='fld_residenceType_1']";
        public string ResidenceType2_Radio { get; set; } = "//input[@id='fld_residenceType_2']";
        public string ResidenceType3_Radio { get; set; } = "//input[@id='fld_residenceType_3']";
        public string ResidenceType4_Radio { get; set; } = "//input[@id='fld_residenceType_4']";
        public string YesUseEstimator_Radio { get; set; } = "//input[@id='fld_yes_useEstimator']";
        public string NoUseEstimator_Radio { get; set; } = "//input[@id='fld_no_useEstimator']";
        public string TerritoryOverride_Input { get; set; } = "//input[@id='fld_territoryoverride']";

        // Rahul Umbrella XPath
        public string UmbrellaEachOcc_Dropdown { get; set; } = "//select[@id='fld_umbrellaEachOcc']";
        public string ClaimsLosses_Radio { get; set; } = "//input[contains(@id,'claimsLosses') and @value='{0}']";
        //public string NoClaimsLosses_Input { get; set; } = "//input[@id='fld_no_claimslosses']";
        public string AttributesSubmit_Button { get; set; } = "//button[@id='buttonattributes.id_submitbutton']";

        public string Billing_Link { get; set; } = "//a[normalize-space()='Billing']";
        public string NoBillingUnearnedPremium_Input { get; set; } = "//input[@id='fld_no_billing_UnearnedPremium']";
        public string PaymentPlan_Input { get; set; } = "//input[@id='pp1_paymentPlan']";

        // Pooja XPath
        public string TCPage_Description_Txt { get; set; } = "//textarea[@id='fld_businessdescription']";
        public string TCPage_ExteriorSprayPainting_RadioBtn { get; set; } = "//input[@name='exteriorspray' and @value='{0}']";
        public string TCPage_GrossAnnualIncome_Txt { get; set; } = "//input[@id='fld_addlinfogrossannualreceipts']";

        // Location details
        public string TCPage_MilesToFireDept_Inp { get; set; } = "//input[@id='fld_loc_milesToFireDept_1']";
        public string TCPage_RespondingFireDept_Inp { get; set; } = "//input[@id='fld_loc_respondingFireDept_1']";
        public string FOPage_NumberOfAcres_Inp { get; set; } = "//input[contains(@id,'fld_loc_NumAcresOwned_1')]";
        // public string FOPage_Next_Btn { get; set; } = "//div[@id='bottomsubnav_nextlink']";
        public string FOPage_NumberOfAcresLeased_Inp { get; set; } = "//input[contains(@id,'fld_loc_NumAcresLeasedFrom_1')]";
        public string FOPage_NumberOfAcresRented_Inp { get; set; } = "//input[contains(@id,'fld_loc_NumAcresRentedTo_1')]";
        public string TCPage_EmployeePayroll_Txt { get; set; } = "//input[@id='fld_addlinfoemployeepayroll']";
        //public string FOPage_TypeOfBusiness_RadioBtn { get; set; } = "//input[@name='application_typeofpolicy' and @value='{0}']";
        public string FOPage_TypeOfBusiness_RadioBtn { get; set; } = "//input[@name='application_TypeofPolicy' and @value='Individual']";
        public string FORelationToInsured_Drpdwn { get; set; } = "//select[contains(@id,'fld_ni_relationshipToInsured_1')]";
        public string FOCopyToAddLocation_Btn { get; set; } = "//button[@id='buttoncopyAddrToLocButton']";
        public string FOPage_FarmOperation_Btn { get; set; } = "//a[normalize-space()='Poultry']";
        public string FOPage_FarmOperation_RadioBtn { get; set; } = "//label[@for='fld_farmOps_fields_Poultry_Broilers']";
        public string FOPage_FarmOperationPercentage_Txt { get; set; } = "//input[@id='fld_farmOps_Percentage_Poultry_Broilers']";
        // Farmowner
        public string FOPage_Save_Btn { get; set; } = "//a[text()='save']";
        public string FOPage_NumberOfDogs_Inp { get; set; } = "//input[contains(@id,'fld_loc_dogsNumber_1')]";
        public string FOPage_OutdoorWoodFurnance_RadioBtn { get; set; } = "//input[contains(@id,'fld_no_loc_FurnaceOutdoors_1') and @value='{0}']";
        public string FOPage_SwimmingPool_RadioBtn { get; set; } = "//input[contains(@name,'loc_Pool_1') and @value='{0}']";
        public string FOPage_Pond_RadioBtn { get; set; } = "//input[contains(@name,'loc_pond_1') and @value='{0}']";
        public string FOPage_Trampoline_RadioBtn { get; set; } = "//input[contains(@name,'loc_Trampoline_1') and @value='{0}']";
        public string FOPage_ZipLine_RadioBtn { get; set; } = "//input[contains(@name,'loc_zipLine_1') and @value='{0}']";
        public string FOPage_ManualPits_RadioBtn { get; set; } = "//input[contains(@id,'fld_no_loc_lagoons') and @value='{0}']";
        public string FOPage_Premises_RadioBtn { get; set; } = "//input[contains(@name,'loc_agentInspection_1') and @value='{0}']";
        public string Bind_Link { get; set; } = "//a[normalize-space()='Bind']";
        public string AgentEmail_Input { get; set; } = "//input[@id='fld_agentEmail']";
        public string BindingDestinationEmail1_Input { get; set; } = "//div[contains(normalize-space(text()), '{0}')]/input[@name='binding_destinationemail']";
        public string BindingAgreeToTerms_Input { get; set; } = "//input[@id='fld_binding_agreetoterms']";
        public string AttachDocuments_SubTab { get; set; } = "//div[normalize-space()='Attach Documents']//div[@id='subtab_']";
        public string BindingInformation_SubTab { get; set; } = "//div[normalize-space()='Binding Information']//div[@id='subtab_']";
        public string Save_Link { get; set; } = "//a[normalize-space()='save']";
        public string Continue_Btn { get; set; } = "//button[contains(text(),'Continue')]";
        public string AddressError_Close { get; set; } = "(//span[contains(text(),'close')])[1]";
        public string Premises_Dropdown { get; set; } = "//input[@id='fld_yes_loc_zipLine_1']";

        // Personal Auto XPath
        public string NumberYears_Drp { get; set; } = "//select[contains(@id,'fld_pa_numberyears')]";
        public string IsMailingAddress_Radio { get; set; } = "//input[contains(@name,'sa_ismailingaddress') and @value='{0}']";
        public string ManualTerritory_Input { get; set; } = "//input[@id='fld_manualterritory']";
        public string DiscountPackage_Dropdown { get; set; } = "//select[@id='fld_packagediscount']";
        // Pending
        public string PriorPolicyExpireDate_Input { get; set; } = "//input[@id='fld_priorpolicyexpiredate']";
        public string PriorInsuranceCarrier_Dropdown { get; set; } = "//select[@id='fld_priorinsurancecarrier']";
        public string PriorCovBIPP_Input { get; set; } = "//input[@id='fld_priorcovbipp']";
        public string PriorCovBIPO_Input { get; set; } = "//input[@id='fld_priorcovbipo']";
        public string PriorCovPD_Input { get; set; } = "//input[@id='fld_priorcovpd']";
        public string PriorCovCSL_Input { get; set; } = "//input[@id='fld_priorcovcsl']";
        public string PriorCovAge_Drp { get; set; } = "//select[@id='fld_priorcovage']";
        public string NumberYearsContinuous_Drp { get; set; } = "//select[@id='fld_numberyearscontinuous']";
        public string FinancialResponsibility_Radio { get; set; } = "//input[contains(@name,'financialresponsibility') and @value='{0}']";
        public string VehicleSharing_Radio { get; set; } = "//input[contains(@name,'vehiclesharing') and @value='{0}']";
        public string ResidenceType_Drp { get; set; } = "//select[@id='fld_residencetype']";

        //public string addresserror_close { get; set; } = "(//span[contains(text(),'close')])[1]";
        #endregion

        #region default application fill
        public async Task ApplicantDataFillAsync(string profileKey)
        {
            if (_fileReader == null)
            {
                throw new InvalidOperationException("FileReader is not available. Use constructor with IFileReader parameter.");
            }

            try
            {
                logger.WriteLine($"Starting to fill Quote Applicant information using profile: {profileKey}");

                var filePath = "QuoteApplicantPage\\QuoteApplicantPage.json";

                // Read values from JSON using profile
                var quoteType = _fileReader.GetOptionalValue(filePath, $"{profileKey}.QuoteType");
                var quoteDesc = _fileReader.GetOptionalValue(filePath, $"{profileKey}.QuoteDescription");
                var effectiveDate = _fileReader.GetOptionalValue(filePath, $"{profileKey}.EffectiveDate");
                var quoteRollover = _fileReader.GetOptionalValue(filePath, $"{profileKey}.QuoteRollOver");
                var bookBusiness = _fileReader.GetOptionalValue(filePath, $"{profileKey}.BookBusiness");
                var producer = _fileReader.GetOptionalValue(filePath, $"{profileKey}.Producer");
                var firstName = _fileReader.GetOptionalValue(filePath, $"{profileKey}.FirstName");
                var lastName = _fileReader.GetOptionalValue(filePath, $"{profileKey}.LastName");
                var ssn = _fileReader.GetOptionalValue(filePath, $"{profileKey}.SSN");
                var dob = _fileReader.GetOptionalValue(filePath, $"{profileKey}.DOB");
                var email = _fileReader.GetOptionalValue(filePath, $"{profileKey}.EmailAddress");
                var phone = _fileReader.GetOptionalValue(filePath, $"{profileKey}.Phone");
                var address1 = _fileReader.GetOptionalValue(filePath, $"{profileKey}.Address");
                var city = _fileReader.GetOptionalValue(filePath, $"{profileKey}.City");
                var state = _fileReader.GetOptionalValue(filePath, $"{profileKey}.State");
                var zip1 = _fileReader.GetOptionalValue(filePath, $"{profileKey}.Zip1");
                var zip2 = _fileReader.GetOptionalValue(filePath, $"{profileKey}.Zip2");
                var isMailingAddress = _fileReader.GetOptionalValue(filePath, $"{profileKey}.isMailingAddress_Radio");
                var numberYears = _fileReader.GetOptionalValue(filePath, $"{profileKey}.NumberYears");
                var manualTerritory = _fileReader.GetOptionalValue(filePath, $"{profileKey}.ManualTerritory_Input");
                var discountPackage = _fileReader.GetOptionalValue(filePath, $"{profileKey}.DiscountPackage_DropDown");
                var priorPolicyExpireDate = _fileReader.GetOptionalValue(filePath, $"{profileKey}.PriorPolicyExpireDate_Input");
                var priorCovBIPP = _fileReader.GetOptionalValue(filePath, $"{profileKey}.PriorCovBIPP_Input");
                var priorCovBIPO = _fileReader.GetOptionalValue(filePath, $"{profileKey}.PriorCovBIPO_Input");
                var priorCovPD = _fileReader.GetOptionalValue(filePath, $"{profileKey}.PriorCovPD_Input");
                var priorCovCSL = _fileReader.GetOptionalValue(filePath, $"{profileKey}.PriorCovCSL_Input");
                var priorCovAge = _fileReader.GetOptionalValue(filePath, $"{profileKey}.PriorCovAge_drp");
                var numberYearsContinuous = _fileReader.GetOptionalValue(filePath, $"{profileKey}.NumberYearsContinuous_drp");
                var financialResponsibility = _fileReader.GetOptionalValue(filePath, $"{profileKey}.FinancialResponsibility_Radio");
                var vehicleSharing = _fileReader.GetOptionalValue(filePath, $"{profileKey}.VehicleSharing_Radio");
                var residenceType = _fileReader.GetOptionalValue(filePath, $"{profileKey}.ResidenceType_DropDown");
                var primaryHomeOwner = _fileReader.GetOptionalValue(filePath, $"{profileKey}.IsPrimaryHomeOwnerPolicyInsured");
                var businessType = _fileReader.GetOptionalValue(filePath, $"{profileKey}.BusinessType");
                var businessDesc = _fileReader.GetOptionalValue(filePath, $"{profileKey}.BusinessDescription");
                var businessFunction = _fileReader.GetOptionalValue(filePath, $"{profileKey}.BusinessFunction");
                var insuranceInForce = _fileReader.GetOptionalValue(filePath, $"{profileKey}.Insuranceinforce");
                var infoBusinessBankruptcy = _fileReader.GetOptionalValue(filePath, $"{profileKey}.infoBusinessEndeavorBankruptcy");
                var infoToolsEquipment = _fileReader.GetOptionalValue(filePath, $"{profileKey}.infoToolsEquipment");
                var infoCanceledRefused = _fileReader.GetOptionalValue(filePath, $"{profileKey}.infoCanceledRefusedCoverage");

                // UI fill actions with Playwright helpers

                if (!string.IsNullOrEmpty(quoteType))
                {
                    await DropDown.SelectDropDownAsync(QuoteType_Drp, quoteType, true, 1);
                }

                var randDesc = quoteDesc + new Random().Next(1, 9999999);
                await InputField.SetTextAreaInputFieldAsync(QuoteDescription_Inp, randDesc, true, 1);
                await InputField.SetTextAreaInputFieldAsync(EffectiveDate_Inp, DateTime.Now.AddDays(Convert.ToInt32(effectiveDate)).ToString("MM/dd/yyyy"), true, 1);

                if (!string.IsNullOrEmpty(quoteRollover))
                {
                    var quoteRolloverSel = string.Format(QuoteRollOver_Radio, quoteRollover);
                    await RadioButton.SelectRadioButtonAsync(quoteRolloverSel, "Value", true, 1);
                }

                await InputField.SetTextAreaInputFieldAsync(BookCode_Inp, bookBusiness, true, 1);
                await DropDown.SelectDropDownAsync(Producer_Drp, producer, true, 1);
                await Task.Delay(5000);
                await InputField.SetTextAreaInputFieldAsync(NamedInsured_FirstName, firstName, true, 1);
                await InputField.SetTextAreaInputFieldAsync(NamedInsured_LastName, lastName, true, 1);
                await InputField.SetTextAreaInputFieldAsync(NamedInsured_SSN_Inp, ssn, true, 1);
                await Task.Delay(3000);
                await InputField.SetTextAreaInputFieldAsync(NamedInsured_DOB_Inp, dob, true, 1);
                await Task.Delay(2000);
                await InputField.SetTextAreaInputFieldAsync(NamedInsured_Email_Inp, email, true, 1);
                await InputField.SetTextAreaInputFieldAsync(Phone_Inp, phone, true, 1);
                await InputField.SetTextAreaInputFieldAsync(AddressLine1_Inp, address1, true, 1);
                await InputField.SetTextAreaInputFieldAsync(City_Inp, city, true, 1);
                if (!string.IsNullOrEmpty(state))
                {
                    await DropDown.SelectDropDownAsync(State_Drp1, state, true, 1);
                }

                await InputField.SetTextAreaInputFieldAsync(ZipCode_Inp1, zip1, true, 1);

                if (!string.IsNullOrEmpty(isMailingAddress))
                {
                    var isMailingAddressSel = string.Format(IsMailingAddress_Radio, isMailingAddress);
                    await RadioButton.SelectRadioButtonAsync(isMailingAddressSel, "Value", true, 1);
                }

                if (!string.IsNullOrEmpty(numberYears))
                {
                    await DropDown.SelectDropDownAsync(NumberYears_Drp, numberYears, true, 1);
                }

                if (!string.IsNullOrEmpty(manualTerritory))
                {
                    await InputField.SetTextAreaInputFieldAsync(ManualTerritory_Input, manualTerritory, true, 1);
                }

                if (!string.IsNullOrEmpty(discountPackage))
                {
                    await DropDown.SelectDropDownAsync(DiscountPackage_Dropdown, discountPackage, true, 1);
                }

                if (!string.IsNullOrEmpty(priorPolicyExpireDate))
                {
                    await InputField.SetTextAreaInputFieldAsync(PriorPolicyExpireDate_Input, priorPolicyExpireDate, true, 1);
                }

                if (!string.IsNullOrEmpty(priorCovBIPP))
                {
                    await InputField.SetTextAreaInputFieldAsync(PriorCovBIPP_Input, priorCovBIPP, true, 1);
                }

                if (!string.IsNullOrEmpty(priorCovBIPO))
                {
                    await InputField.SetTextAreaInputFieldAsync(PriorCovBIPO_Input, priorCovBIPO, true, 1);
                }

                if (!string.IsNullOrEmpty(priorCovPD))
                {
                    await InputField.SetTextAreaInputFieldAsync(PriorCovPD_Input, priorCovPD, true, 1);
                }

                if (!string.IsNullOrEmpty(priorCovCSL))
                {
                    await InputField.SetTextAreaInputFieldAsync(PriorCovCSL_Input, priorCovCSL, true, 1);
                }

                if (!string.IsNullOrEmpty(priorCovAge))
                {
                    await DropDown.SelectDropDownAsync(PriorCovAge_Drp, priorCovAge, true, 1);
                }

                if (!string.IsNullOrEmpty(numberYearsContinuous))
                {
                    await DropDown.SelectDropDownAsync(NumberYearsContinuous_Drp, numberYearsContinuous, true, 1);
                }

                if (!string.IsNullOrEmpty(financialResponsibility))
                {
                    var financialResponsibilitySel = string.Format(FinancialResponsibility_Radio, financialResponsibility);
                    await RadioButton.SelectRadioButtonAsync(financialResponsibilitySel, "value", true, 1);
                }

                if (!string.IsNullOrEmpty(vehicleSharing))
                {
                    var vehicleSharingSel = string.Format(VehicleSharing_Radio, vehicleSharing);
                    await RadioButton.SelectRadioButtonAsync(vehicleSharingSel, "value", true, 1);
                }

                if (!string.IsNullOrEmpty(residenceType))
                {
                    await DropDown.SelectDropDownAsync(ResidenceType_Drp, residenceType, true, 1);
                }

                if (!string.IsNullOrEmpty(zip2))
                {
                    await InputField.SetTextAreaInputFieldAsync(ZipCode_Inp2, zip2, true, 1);
                }

                if (!string.IsNullOrEmpty(primaryHomeOwner))
                {
                    var primaryHomeOwnerSel = string.Format(PrimaryHomeOwnerPolicyInsured, primaryHomeOwner);
                    await RadioButton.SelectRadioButtonAsync(primaryHomeOwnerSel, "value", true, 1);
                }

                // Business details
                if (!string.IsNullOrEmpty(businessType))
                {
                    var businessTypeSel = string.Format(Business_Type_Radio, businessType);
                    await RadioButton.SelectRadioButtonAsync(businessTypeSel, "value", true, 1);

                    if (!string.IsNullOrEmpty(businessDesc))
                    {
                        await InputField.SetTextAreaInputFieldAsync(BusinessDescription_Inp, businessDesc, true, 1);
                    }

                    if (!string.IsNullOrEmpty(businessFunction))
                    {
                        var businessFunctionSel = string.Format(Business_Function_Radio, businessFunction);
                        await RadioButton.SelectRadioButtonAsync(businessFunctionSel, "value", true, 1);
                    }

                    if (!string.IsNullOrEmpty(insuranceInForce))
                    {
                        var insuranceInForceSel = string.Format(InsuranceInForce, insuranceInForce);
                        await RadioButton.SelectRadioButtonAsync(insuranceInForceSel, "value", true, 1);
                    }

                    if (!string.IsNullOrEmpty(infoBusinessBankruptcy))
                    {
                        var infoBusinessBankruptcySel = string.Format(InfoBusinessEndeavorBankruptcy_Radio, infoBusinessBankruptcy);
                        await RadioButton.SelectRadioButtonAsync(infoBusinessBankruptcySel, "value", true, 1);
                    }

                    if (!string.IsNullOrEmpty(infoToolsEquipment))
                    {
                        var infoToolsEquipmentSel = string.Format(InfoToolsEquipment_Radio, infoToolsEquipment);
                        await RadioButton.SelectRadioButtonAsync(infoToolsEquipmentSel, "value", true, 1);
                    }

                    if (!string.IsNullOrEmpty(infoCanceledRefused))
                    {
                        var infoCanceledRefusedSel = string.Format(InfoCanceledRefusedCoverage_Radio, infoCanceledRefused);
                        await RadioButton.SelectRadioButtonAsync(infoCanceledRefusedSel, "value", true, 1);
                    }
                }

               
                await Button.ClickButtonAsync(_commonXpath.Save_btn, ActionType.Click, true, 1);
                await Task.Delay(5000);
                await Button.ClickButtonAsync(Continue_Btn, ActionType.Click,true, 1);
                logger.WriteLine($"Successfully filled Quote Applicant information using profile: {profileKey}");

            }
            catch (Exception ex)
            {
                logger.WriteLine($"Error filling ApplicantDataFillAsync: {ex.Message}");
                throw new Exception($"Failed to fill Applicant data using profile '{profileKey}': {ex.Message}", ex);
            }
        }
        #endregion

        public async Task PAApplicantDataFillAsync(string profileKey)
        {
            if (_fileReader == null)
            {
                throw new InvalidOperationException("FileReader is not available. Use constructor with IFileReader parameter.");
            }

            try
            {
                logger.WriteLine($"Starting PAApplicantDataFill using JSON data and profile: {profileKey}");

                var filePath = "ApplicantPage\\ApplicantPage.json";

                var quoteType = _fileReader.GetOptionalValue(filePath, $"{profileKey}.ApplicantQuoteType_LabelAndValue");
                var quoteDesc = _fileReader.GetOptionalValue(filePath, $"{profileKey}.ApplicantQuoteDescription_LabelAndValue");
                var effectiveDate = _fileReader.GetOptionalValue(filePath, $"{profileKey}.ApplicantEffectiveDate_LabelAndValue");
                var quoteRollover = _fileReader.GetOptionalValue(filePath, $"{profileKey}.ApplicantQuoteRollOver_LabelAndValue");
                var bookBusiness = _fileReader.GetOptionalValue(filePath, $"{profileKey}.ApplicantBookBusiness_LabelAndValue");
                var office = _fileReader.GetOptionalValue(filePath, $"{profileKey}.ApplicantOffice_LabelAndValue");
                var producer = _fileReader.GetOptionalValue(filePath, $"{profileKey}.ApplicantBookProducer_LabelAndValue");
                var firstName = _fileReader.GetOptionalValue(filePath, $"{profileKey}.ApplicantFirstName_LabelAndValue");
                var lastName = _fileReader.GetOptionalValue(filePath, $"{profileKey}.ApplicantLastName_LabelAndValue");
                var ssn = _fileReader.GetOptionalValue(filePath, $"{profileKey}.ApplicantSSN_LabelAndValue");
                var dob = _fileReader.GetOptionalValue(filePath, $"{profileKey}.ApplicantDOB1_LabelAndValue");
                var email = _fileReader.GetOptionalValue(filePath, $"{profileKey}.ApplicantEmail_LabelAndValue");
                var phone = _fileReader.GetOptionalValue(filePath, $"{profileKey}.ApplicantPhone_LabelAndValue");
                var address1 = _fileReader.GetOptionalValue(filePath, $"{profileKey}.ApplicantAddress1_LabelAndValue");
                var city = _fileReader.GetOptionalValue(filePath, $"{profileKey}.ApplicantCity_LabelAndValue");
                var state = _fileReader.GetOptionalValue(filePath, $"{profileKey}.ApplicantState_LabelAndValue");
                var zip1 = _fileReader.GetOptionalValue(filePath, $"{profileKey}.ApplicantZip1_LabelAndValue");
                var zip2 = _fileReader.GetOptionalValue(filePath, $"{profileKey}.ApplicantZip2_LabelAndValue");

                var isMailingAddress = _fileReader.GetOptionalValue(filePath, $"{profileKey}.IsMailingAddress_Radio_LabelAndValue");
                var numberYears = _fileReader.GetOptionalValue(filePath, $"{profileKey}.NumberYears_Drp_LabelAndValue");
                var manualTerritory = _fileReader.GetOptionalValue(filePath, $"{profileKey}.ManualTerritory_Input_LabelAndValue");
                var discountPackage = _fileReader.GetOptionalValue(filePath, $"{profileKey}.DiscountPackage_Dropdown_LabelAndValue");
                var priorPolicyExpireDate = _fileReader.GetOptionalValue(filePath, $"{profileKey}.PriorPolicyExpireDate_Input_LabelAndValue");
                var priorCovBIPP = _fileReader.GetOptionalValue(filePath, $"{profileKey}.PriorCovBIPP_Input_LabelAndValue");
                var priorCovBIPO = _fileReader.GetOptionalValue(filePath, $"{profileKey}.PriorCovBIPO_Input_LabelAndValue");
                var priorCovPD = _fileReader.GetOptionalValue(filePath, $"{profileKey}.PriorCovPD_Input_LabelAndValue");
                var priorCovCSL = _fileReader.GetOptionalValue(filePath, $"{profileKey}.PriorCovCSL_Input_LabelAndValue");
                var priorCovAge = _fileReader.GetOptionalValue(filePath, $"{profileKey}.PriorCovAge_Drp_LabelAndValue");
                var numberYearsContinuous = _fileReader.GetOptionalValue(filePath, $"{profileKey}.NumberYearsContinuous_Drp_LabelAndValue");
                var financialResponsibility = _fileReader.GetOptionalValue(filePath, $"{profileKey}.FinancialResponsibility_Radio_LabelAndValue");
                var vehicleSharing = _fileReader.GetOptionalValue(filePath, $"{profileKey}.VehicleSharing_Radio_LabelAndValue");
                var residenceType = _fileReader.GetOptionalValue(filePath, $"{profileKey}.ResidenceType_Drp_LabelAndValue");
                var primaryHomeOwnerPolicyInsured = _fileReader.GetOptionalValue(filePath, $"{profileKey}.ApplicantPrimaryHomeOwnerPolicyInsured_LabelAndValue");
                var businessType = _fileReader.GetOptionalValue(filePath, $"{profileKey}.ApplicantBusinessType_LabelAndValue");
                var businessDesc = _fileReader.GetOptionalValue(filePath, $"{profileKey}.BusinessDescription_Inp_LabelAndValue");
                var businessFunction = _fileReader.GetOptionalValue(filePath, $"{profileKey}.ApplicantBusinessFunction_LabelAndValue");
                var insuranceInForce = _fileReader.GetOptionalValue(filePath, $"{profileKey}.ApplicantInsuranceInForce_LabelAndValue");
                var infoBusinessBankruptcy = _fileReader.GetOptionalValue(filePath, $"{profileKey}.ApplicantInfoBusinessEndeavorBankruptcy_LabelAndValue");
                var infoToolsEquipment = _fileReader.GetOptionalValue(filePath, $"{profileKey}.ApplicantInfoToolsEquipment_LabelAndValue");
                var infoCanceledRefused = _fileReader.GetOptionalValue(filePath, $"{profileKey}.ApplicantInfoCanceledRefusedCoverage_LabelAndValue");

                if (!string.IsNullOrEmpty(quoteType))
                {
                    await DropDown.SelectDropDownAsync(QuoteType_Drp, quoteType, true, 1);
                }

                await InputField.SetTextAreaInputFieldAsync(QuoteDescription_Inp, quoteDesc, true, 1);
                await InputField.SetTextAreaInputFieldAsync(EffectiveDate_Inp, DateTime.Now.AddDays(Convert.ToInt32(effectiveDate)).ToString("MM/dd/yyyy"), true, 1);

                if (!string.IsNullOrEmpty(quoteRollover))
                {
                    var quoteRolloverSel = string.Format(QuoteRollOver_Radio, quoteRollover);
                    await RadioButton.SelectRadioButtonAsync(quoteRolloverSel, "value", true, 1);
                }

                await InputField.SetTextAreaInputFieldAsync(BookCode_Inp, bookBusiness, true, 1);

                if (!string.IsNullOrEmpty(office))
                {
                    await DropDown.SelectDropDownAsync(Office_Drp, office, true, 1);
                }

                await DropDown.SelectDropDownAsync(Producer_Drp, producer, true, 1);
                await InputField.SetTextAreaInputFieldAsync(NamedInsured_FirstName_Inp, firstName, true, 1);
                await InputField.SetTextAreaInputFieldAsync(NamedInsured_LastName_Inp, lastName, true, 1);

                if (!string.IsNullOrEmpty(ssn))
                {
                    await InputField.SetTextAreaInputFieldAsync(NamedInsured_SSN_Inp, ssn, true, 1);
                }

                await InputField.SetTextAreaInputFieldAsync(NamedInsured_DOB_Inp, dob, true, 1);

                await InputField.SetTextAreaInputFieldAsync(NamedInsured_SSN_Inp, ssn, true, 1); // Intentional duplicate from source
                await InputField.SetTextAreaInputFieldAsync(NamedInsured_DOB_Inp, dob, true, 1);   // Intentional duplicate from source
                await InputField.SetTextAreaInputFieldAsync(NamedInsured_Email_Inp, email, true, 1);
                await InputField.SetTextAreaInputFieldAsync(Phone_Inp, phone, true, 1);

                if (!string.IsNullOrEmpty(ssn))
                {
                    await InputField.SetTextAreaInputFieldAsync(NamedInsured_SSN_Inp, ssn, true, 1);
                }

                if (!string.IsNullOrEmpty(dob))
                {
                    await InputField.SetTextAreaInputFieldAsync(NamedInsured_DOB_Inp, dob, true, 1);
                }

                await Task.Delay(2000);

                if (!string.IsNullOrEmpty(email))
                {
                    await InputField.SetTextAreaInputFieldAsync(NamedInsured_Email_Inp, email, true, 1);
                }

                if (!string.IsNullOrEmpty(phone))
                {
                    await InputField.SetTextAreaInputFieldAsync(Phone_Inp, phone, true, 1);
                }

                await InputField.SetTextAreaInputFieldAsync(AddressLine1_Inp, address1, true, 1);
                await InputField.SetTextAreaInputFieldAsync(City_Inp, city, true, 1);

                if (!string.IsNullOrEmpty(state))
                {
                    await Button.ScrollIntoViewAsync(State_Drp1, true, 1);
                    await DropDown.SelectDropDownAsync(State_Drp1, state, true, 1);
                }

                await InputField.SetTextAreaInputFieldAsync(ZipCode_Inp1, zip1, true, 1);

                await Task.Delay(1000);

                await Button.ClickButtonAsync(AddressError_Close, ActionType.Click,true, 1);
                await Task.Delay(1000);

                if (!string.IsNullOrEmpty(isMailingAddress))
                {
                    var isMailingAddressSel = string.Format(IsMailingAddress_Radio, isMailingAddress);
                    await RadioButton.SelectRadioButtonAsync(isMailingAddressSel, "value", true, 1);
                }

                if (!string.IsNullOrEmpty(numberYears))
                {
                    await DropDown.SelectDropDownAsync(NumberYears_Drp, numberYears, true, 1);
                }

                if (!string.IsNullOrEmpty(manualTerritory))
                {
                    await InputField.SetTextAreaInputFieldAsync(ManualTerritory_Input, manualTerritory, true, 1);
                }

                if (!string.IsNullOrEmpty(discountPackage))
                {
                    await DropDown.SelectDropDownAsync(DiscountPackage_Dropdown, discountPackage, true, 1);
                }

                if (!string.IsNullOrEmpty(priorPolicyExpireDate))
                {
                    await InputField.SetTextAreaInputFieldAsync(PriorPolicyExpireDate_Input, priorPolicyExpireDate, true, 1);
                }

                if (!string.IsNullOrEmpty(priorCovBIPP))
                {
                    await InputField.SetTextAreaInputFieldAsync(PriorCovBIPP_Input, priorCovBIPP, true, 1);
                }

                if (!string.IsNullOrEmpty(priorCovBIPO))
                {
                    await InputField.SetTextAreaInputFieldAsync(PriorCovBIPO_Input, priorCovBIPO, true, 1);
                }

                if (!string.IsNullOrEmpty(priorCovPD))
                {
                    await InputField.SetTextAreaInputFieldAsync(PriorCovPD_Input, priorCovPD, true, 1);
                }

                if (!string.IsNullOrEmpty(priorCovCSL))
                {
                    await InputField.SetTextAreaInputFieldAsync(PriorCovCSL_Input, priorCovCSL, true, 1);
                }

                if (!string.IsNullOrEmpty(priorCovAge))
                {
                    await DropDown.SelectDropDownAsync(PriorCovAge_Drp, priorCovAge, true, 1);
                }

                if (!string.IsNullOrEmpty(numberYearsContinuous))
                {
                    await DropDown.SelectDropDownAsync(NumberYearsContinuous_Drp, numberYearsContinuous, true, 1);
                }

                if (!string.IsNullOrEmpty(financialResponsibility))
                {
                    var financialResponsibilitySel = string.Format(FinancialResponsibility_Radio, financialResponsibility);
                    await RadioButton.SelectRadioButtonAsync(financialResponsibilitySel,"Value", true, 1);
                }

                if (!string.IsNullOrEmpty(vehicleSharing))
                {
                    var vehicleSharingSel = string.Format(VehicleSharing_Radio, vehicleSharing);
                    await RadioButton.SelectRadioButtonAsync(vehicleSharingSel, "value", true, 1);
                }

                if (!string.IsNullOrEmpty(residenceType))
                {
                    await DropDown.SelectDropDownAsync(ResidenceType_Drp, residenceType, true, 1);
                }

                if (!string.IsNullOrEmpty(zip2))
                {
                    await InputField.SetTextAreaInputFieldAsync(ZipCode_Inp2, zip2, true, 1);
                }

                if (!string.IsNullOrEmpty(primaryHomeOwnerPolicyInsured))
                {
                    var primaryHomeOwnerSel = string.Format(PrimaryHomeOwnerPolicyInsured, primaryHomeOwnerPolicyInsured);
                    await RadioButton.SelectRadioButtonAsync(primaryHomeOwnerSel, "Value", true, 1);
                }

                if (!string.IsNullOrEmpty(businessType))
                {
                    var businessTypeSel = string.Format(Business_Type_Radio, businessType);
                    await RadioButton.SelectRadioButtonAsync(businessTypeSel, "Value", true, 1);

                    if (!string.IsNullOrEmpty(businessDesc))
                    {
                        await InputField.SetTextAreaInputFieldAsync(BusinessDescription_Inp, businessDesc, true, 1);
                    }

                    if (!string.IsNullOrEmpty(businessFunction))
                    {
                        var businessFunctionSel = string.Format(Business_Function_Radio, businessFunction);
                        await RadioButton.SelectRadioButtonAsync(businessFunctionSel, "Value",true, 1);
                    }

                    if (!string.IsNullOrEmpty(insuranceInForce))
                    {
                        var insuranceInForceSel = string.Format(InsuranceInForce, insuranceInForce);
                        await RadioButton.SelectRadioButtonAsync(insuranceInForceSel,"Value", true, 1);
                    }

                    if (!string.IsNullOrEmpty(infoBusinessBankruptcy))
                    {
                        var infoBusinessBankruptcySel = string.Format(InfoBusinessEndeavorBankruptcy_Radio, infoBusinessBankruptcy);
                        await RadioButton.SelectRadioButtonAsync(infoBusinessBankruptcySel, "Value",true,1);
                    }

                    if (!string.IsNullOrEmpty(infoToolsEquipment))
                    {
                        var infoToolsEquipmentSel = string.Format(InfoToolsEquipment_Radio, infoToolsEquipment);
                        await RadioButton.SelectRadioButtonAsync(infoToolsEquipmentSel,"Value", true, 1);
                    }

                    if (!string.IsNullOrEmpty(infoCanceledRefused))
                    {
                        var infoCanceledRefusedSel = string.Format(InfoCanceledRefusedCoverage_Radio, infoCanceledRefused);
                        await RadioButton.SelectRadioButtonAsync(infoCanceledRefusedSel,"Value", true, 1);
                    }
                }

                await Button.ClickButtonAsync(Continue_Btn, ActionType.Click , true,1);
                await Task.Delay(5000);
                logger.WriteLine($"Successfully filled PAApplicant Data information using profile: {profileKey}");
            }
            catch (Exception ex)
            {
                logger.WriteLine($"Error in PAApplicantDataFillAsync: {ex.Message}");
                throw new Exception($"Failed to fill PAApplicant data using profile '{profileKey}': {ex.Message}", ex);
            }
        }

        #region worker comp applicant info fill
        public async Task WorkersCompApplicantDatafillAsync(string profileKey)
        {
            if (_fileReader == null)
            {
                throw new InvalidOperationException("FileReader is not available. Use constructor with IFileReader parameter.");
            }

            try
            {
                logger.WriteLine($"Starting WorkersCompApplicantDatafill using JSON data and profile: {profileKey}");

                var filePath = "QuoteApplicantPage\\QuoteApplicantPage.json";

                var quoteType = _fileReader.GetOptionalValue(filePath, $"{profileKey}.QuoteType");
                var quoteDesc = _fileReader.GetOptionalValue(filePath, $"{profileKey}.QuoteDescription");
                var effectiveDate = _fileReader.GetOptionalValue(filePath, $"{profileKey}.EffectiveDate");
                var bookBusiness = _fileReader.GetOptionalValue(filePath, $"{profileKey}.BookBusiness");
                var producer = _fileReader.GetOptionalValue(filePath, $"{profileKey}.Producer");
                var policyType = _fileReader.GetOptionalValue(filePath, $"{profileKey}.PolicyType");
                var quoteNumber = _fileReader.GetOptionalValue(filePath, $"{profileKey}.QuoteNumber");
                var addAnotherNamedInsured = _fileReader.GetOptionalValue(filePath, $"{profileKey}.AddAnotherNamedInsured");
                var firstName = _fileReader.GetOptionalValue(filePath, $"{profileKey}.FirstName");
                var lastName = _fileReader.GetOptionalValue(filePath, $"{profileKey}.LastName");
                var ssn = _fileReader.GetOptionalValue(filePath, $"{profileKey}.SSN");
                var dob = _fileReader.GetOptionalValue(filePath, $"{profileKey}.DOB");
                var email = _fileReader.GetOptionalValue(filePath, $"{profileKey}.EmailAddress");
                var phone = _fileReader.GetOptionalValue(filePath, $"{profileKey}.Phone");
                var fein = _fileReader.GetOptionalValue(filePath, $"{profileKey}.FEIN");
                var description = _fileReader.GetOptionalValue(filePath, $"{profileKey}.Description");
                var address1 = _fileReader.GetOptionalValue(filePath, $"{profileKey}.Address");
                var city = _fileReader.GetOptionalValue(filePath, $"{profileKey}.City");
                var state = _fileReader.GetOptionalValue(filePath, $"{profileKey}.State");
                var zip1 = _fileReader.GetOptionalValue(filePath, $"{profileKey}.Zip1");
                var contactName = _fileReader.GetOptionalValue(filePath, $"{profileKey}.ContactInfo_Name");
                var contactOfficePhone = _fileReader.GetOptionalValue(filePath, $"{profileKey}.ContactInfo_OfficePhone");
                var contactMobilePhone = _fileReader.GetOptionalValue(filePath, $"{profileKey}.ContactInfo_MobilePhone");
                var contactEmail = _fileReader.GetOptionalValue(filePath, $"{profileKey}.ContactInfo_Email");

        
                if (!string.IsNullOrEmpty(quoteType))
                {
                    await DropDown.SelectDropDownAsync(QuoteType_Drp, quoteType, true, 1);
                }

                await InputField.SetTextAreaInputFieldAsync(QuoteDescription_Inp, quoteDesc, true, 1);
                 var dateToEnter = DateTime.Now.ToString("MM/dd/yyyy");
                 if (!string.IsNullOrEmpty(effectiveDate) && effectiveDate == "0")
                 {
                     dateToEnter = DateTime.Now.AddDays(Convert.ToInt32(effectiveDate)).ToString("MM/dd/yyyy");
                 }
               
                await InputField.SetTextAreaInputFieldAsync(EffectiveDate_Inp, dateToEnter, true, 1);
                await InputField.SetTextAreaInputFieldAsync(BookCode_Inp, bookBusiness, true, 1);

                try
                {
                    await DropDown.SelectDropDownAsync(Producer_Drp, producer, true, 1);
                }
                catch (Exception ex)
                {
                    logger.WriteLine($"Error selecting Producer dropdown: {ex.Message} - retrying...");
                    await DropDown.SelectDropDownAsync(Producer_Drp, producer, true, 1);
                }

               /* if (!string.IsNullOrEmpty(policyType))
                {
                    await DropDown.SelectDropDownAsync(PolicyType_DropDown, policyType, true, 1);
                }*/

                if (!string.IsNullOrEmpty(quoteNumber))
                {
                    await InputField.SetTextAreaInputFieldAsync(QuoteNumber_Input, quoteNumber, true, 1);
                }

                if (!string.IsNullOrEmpty(addAnotherNamedInsured))
                {
                    await Task.Delay(3000);
                    var namedInsuredInput = page.Locator(AddAnotherNamedInsured_Input);
                    await namedInsuredInput.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Visible });
                    await namedInsuredInput.ScrollIntoViewIfNeededAsync();
                    await Task.Delay(3000);
                    await namedInsuredInput.ClickAsync();

                    // If you must use your framework's helpers:
                    // await Button.ScrollIntoViewAsync(AddAnotherNamedInsured_Input, true, 1);
                    // await TextLink.ClickTextLinkAsync(AddAnotherNamedInsured_Input, true, 1);
                }

                //await PlaywrightExtras.WaitUntilEnabledAsync(Page, NamedInsured_FirstName_Inp);
                await InputField.SetTextAreaInputFieldAsync(NamedInsured_FirstName_Inp, firstName, true, 1);
                await InputField.SetTextAreaInputFieldAsync(NamedInsured_LastName_Inp, lastName, true, 1);
                await InputField.SetTextAreaInputFieldAsync(NamedInsured_SSN_Inp, ssn, true, 1);
                await InputField.SetTextAreaInputFieldAsync(NamedInsured_DOB_Inp, dob, true, 1);
                await InputField.SetTextAreaInputFieldAsync(NamedInsured_Email_Inp, email, true, 1);
                await InputField.SetTextAreaInputFieldAsync(Phone_Inp, phone, true, 1);
                await InputField.SetTextAreaInputFieldAsync(FEIN_Input, fein, true, 1);
                await InputField.SetTextAreaInputFieldAsync(Description_Input, description, true, 1);
                await InputField.SetTextAreaInputFieldAsync(AddressLine1_Inp, address1, true, 1);
                await InputField.SetTextAreaInputFieldAsync(City_Inp, city, true, 1);
                await DropDown.SelectDropDownAsync(State_Drp1, state, true, 1);
                await InputField.SetTextAreaInputFieldAsync(ZipCode_Inp1, zip1, true, 1);
                await InputField.SetTextAreaInputFieldAsync(ContactInfo_Name_Input, contactName, true, 1);
                await InputField.SetTextAreaInputFieldAsync(ContactInfo_OfficePhone_Input, contactOfficePhone, true, 1);
                await InputField.SetTextAreaInputFieldAsync(ContactInfo_MobilePhone_Input, contactMobilePhone, true, 1);
                await InputField.SetTextAreaInputFieldAsync(ContactInfo_Email_Input, contactEmail, true, 1);

                logger.WriteLine($"Successfully filled WorkersCompApplicantData using profile: {profileKey}");
            
            }
            catch (Exception ex)
            {
                logger.WriteLine($"Error in WorkersCompApplicantDatafillAsync: {ex.Message}");
                throw new Exception($"Failed to fill WorkersComp applicant data using profile '{profileKey}': {ex.Message}", ex);
            }
        }
        #endregion

        #region worker comp underwriting info fill
        public async Task WorkersCompUnderwritingInfoFillAsync(string profileKey)
        {
            if (_fileReader == null)
            {
                throw new InvalidOperationException("FileReader is not available. Use constructor with IFileReader parameter.");
            }

            try
            {
                logger.WriteLine($"Starting WorkersCompUnderwritingInfoFillAsync using profile: {profileKey}");

                var filePath = "QuoteApplicantPage\\QuoteApplicantPage.json";

                await Button.ScrollIntoViewAsync(UnderwritingInformationTab_Button, true, 1);
                await Button.ClickButtonAsync(UnderwritingInformationTab_Button, ActionType.Click, true, 1);
                await Task.Delay(2000);
                await RadioButton.SelectRadioButtonAsync(SupportingContractClasses_Radio,"value", true, 1);
                await RadioButton.SelectRadioButtonAsync(Aircraft_Radio,"value", true, 1);
                await RadioButton.SelectRadioButtonAsync(HazardousMaterial_Radio,"value", true, 1);
                await RadioButton.SelectRadioButtonAsync(Underground_Radio,"value", true, 1);
                await RadioButton.SelectRadioButtonAsync(BargesBridges_Radio,"value", true, 1);
                await RadioButton.SelectRadioButtonAsync(OtherBusiness_Radio,"value", true, 1);
                await RadioButton.SelectRadioButtonAsync(SafetyProgram_Radio,"value", true, 1);
                await RadioButton.SelectRadioButtonAsync(EmployeesUnder16_Radio,"value", true, 1);
                await RadioButton.SelectRadioButtonAsync(Seasonal_Radio,"value", true, 1);
                await RadioButton.SelectRadioButtonAsync(VolunteerLabor_Radio,"value", true, 1);
                await RadioButton.SelectRadioButtonAsync(PhysicalHandicaps_Radio,"value", true, 1);
                await RadioButton.SelectRadioButtonAsync(TravelOutOfState_Radio,"value", true, 1);
                await RadioButton.SelectRadioButtonAsync(AthleticTeams_Radio,"value", true, 1);
                await RadioButton.SelectRadioButtonAsync(PhysicalsRequired_Radio,"value", true, 1);
                await RadioButton.SelectRadioButtonAsync(OtherInsurance_Radio,"value", true, 1);
                await RadioButton.SelectRadioButtonAsync(CoverageCancelled_Radio,"value", true, 1);
                await RadioButton.SelectRadioButtonAsync(HealthPlans_Radio,"value", true, 1);
                await RadioButton.SelectRadioButtonAsync(OtherBusinesses_Radio,"value", true, 1);
                await RadioButton.SelectRadioButtonAsync(LeaseEmployees_Radio,"value", true, 1);
                await RadioButton.SelectRadioButtonAsync(WorkAtHome_Radio,"value", true, 1);

                var continuousWCcov = _fileReader.GetOptionalValue(filePath, $"{profileKey}.ContinuousWCcov");
                if (!string.IsNullOrEmpty(continuousWCcov))
                {
                    await DropDown.SelectDropDownAsync(ContinuousWCcov_Select, continuousWCcov, true, 1);
                }

                await RadioButton.SelectRadioButtonAsync(Bankruptcy_Radio,"value", true, 1);
                await RadioButton.SelectRadioButtonAsync(UndisputedPremium_Radio,"value", true, 1);
                await RadioButton.SelectRadioButtonAsync(Website_Radio,"value", true, 1);

                logger.WriteLine($"Successfully filled WorkersCompUnderwriting information using profile: {profileKey}");
            }
            catch (Exception ex)
            {
                logger.WriteLine($"Error in WorkersCompUnderwritingInfoFillAsync: {ex.Message}");
                throw new Exception($"Failed to fill WorkersComp Underwriting Info using profile '{profileKey}': {ex.Message}", ex);
            }
        }
        #endregion

        public async Task CommercialUmbrellaApplicantDatafillAsync(string profileKey)
        {
            var filePath = "QuoteApplicantPage\\QuoteApplicantPage.json";

            // Get all relevant values from JSON
            var quoteDescription = _fileReader.GetOptionalValue(filePath, $"{profileKey}.QuoteDescription");
            var effectiveDateOffset = _fileReader.GetOptionalValue(filePath, $"{profileKey}.EffectiveDate");
            var bookBusiness = _fileReader.GetOptionalValue(filePath, $"{profileKey}.BookBusiness");
            var producer = _fileReader.GetOptionalValue(filePath, $"{profileKey}.Producer");
            // Add other fields as needed
            var umbrellaEachOcc = _fileReader.GetOptionalValue(filePath, $"{profileKey}.UmbrellaEachOcc");
            var claimsLosses = _fileReader.GetOptionalValue(filePath, $"{profileKey}.ClaimsLosses");
            //var noClaimsLosses = _fileReader.GetOptionalValue(filePath, $"{profileKey}.NoClaimsLosses");
            var noBillingUnearnedPremium = _fileReader.GetOptionalValue(filePath, $"{profileKey}.NoBillingUnearnedPremium");
            var agentEmail = _fileReader.GetOptionalValue(filePath, $"{profileKey}.AgentEmail");
            var bindingDestinationEmail1 = _fileReader.GetOptionalValue(filePath, $"{profileKey}.BindingDestinationEmail1");
            var bindingAgreeToTerms = _fileReader.GetOptionalValue(filePath, $"{profileKey}.BindingAgreeToTerms");

            // Application Info
            await InputField.SetTextAreaInputFieldAsync(QuoteDescription_Inp, quoteDescription, true, 1);
            var effectiveDate = DateTime.Now.AddDays(Convert.ToInt32(effectiveDateOffset)).ToString("MM/dd/yyyy");
            await InputField.SetTextAreaInputFieldAsync(EffectiveDate_Inp, effectiveDate, true, 1);
            await InputField.SetTextAreaInputFieldAsync(BookCode_Inp, bookBusiness, true, 1);
            await DropDown.SelectDropDownAsync(Producer_Drp, producer, true, 1);

            // Uncomment and add named insured fields if needed

            await DropDown.SelectDropDownAsync(UmbrellaEachOcc_Dropdown, umbrellaEachOcc, true, 1);

            await RadioButton.SelectRadioButtonAsync(string.Format(ClaimsLosses_Radio, claimsLosses), "No",true, 1);
            //await InputField.SetTextAreaInputFieldAsync(NoClaimsLosses_Input, noClaimsLosses, true, 1);

            // Billing Section
            await TextLink.ClickTextLinkAsync(Billing_Link, true, 1);
            await page.WaitForLoadStateAsync(LoadState.NetworkIdle);
            await Task.Delay(2000);
            await RadioButton.SelectRadioButtonAsync(string.Format(NoBillingUnearnedPremium_Input, noBillingUnearnedPremium), "No",true, 1);
            await Button.ClickButtonAsync(PaymentPlan_Input, ActionType.Click, true, 1);

            // Bind Section
            await TextLink.ClickTextLinkAsync(Bind_Link, true, 1);
            await page.WaitForLoadStateAsync(LoadState.NetworkIdle);
            await Task.Delay(2000);
            await InputField.SetTextAreaInputFieldAsync(AgentEmail_Input, agentEmail, true, 1);
            await RadioButton.SelectRadioButtonAsync(string.Format(BindingDestinationEmail1_Input, bindingDestinationEmail1), "value",true, 1);
            if (!string.IsNullOrEmpty(bindingAgreeToTerms))
            {
                await Checkbox.SelectCheckboxAsync(BindingAgreeToTerms_Input, true, true, 1);
            }

            // Sub-tabs
            await TextLink.ClickTextLinkAsync(AttachDocuments_SubTab, true, 1);
            await page.WaitForLoadStateAsync(LoadState.NetworkIdle);
            await Task.Delay(2000);
            await TextLink.ClickTextLinkAsync(BindingInformation_SubTab, true, 1);
            await page.WaitForLoadStateAsync(LoadState.NetworkIdle);
            await Task.Delay(2000);

            // Save
            await TextLink.ClickTextLinkAsync(Save_Link, true, 1);
        }

        public async Task HomeOwnersApplicantDatafillAsync(string profileKey)
        {
            if (_fileReader == null)
            {
                throw new InvalidOperationException("FileReader is not available. Use constructor with IFileReader parameter.");
            }

            try
            {
                logger.WriteLine($"Starting HomeOwnersApplicantDatafill using JSON data and profile: {profileKey}");

                var filePath = "QuoteApplicantPage\\QuoteApplicantPage.json";

                var quoteType = _fileReader.GetOptionalValue(filePath, $"{profileKey}.QuoteType");
                var quoteDesc = _fileReader.GetOptionalValue(filePath, $"{profileKey}.QuoteDescription");
                var effectiveDate = _fileReader.GetOptionalValue(filePath, $"{profileKey}.EffectiveDate");
                var quoteRollover = _fileReader.GetOptionalValue(filePath, $"{profileKey}.QuoteRollOver");
                var bookBusiness = _fileReader.GetOptionalValue(filePath, $"{profileKey}.BookBusiness");
                var producer = _fileReader.GetOptionalValue(filePath, $"{profileKey}.Producer");
                var firstName = _fileReader.GetOptionalValue(filePath, $"{profileKey}.FirstName");
                var lastName = _fileReader.GetOptionalValue(filePath, $"{profileKey}.LastName");
                var ssn = _fileReader.GetOptionalValue(filePath, $"{profileKey}.SSN");
                var dob = _fileReader.GetOptionalValue(filePath, $"{profileKey}.DOB");
                var firstNameHO = _fileReader.GetOptionalValue(filePath, $"{profileKey}.SecondFirstName");
                var lastNameHO = _fileReader.GetOptionalValue(filePath, $"{profileKey}.SecondLastName");
                var ssnHO = _fileReader.GetOptionalValue(filePath, $"{profileKey}.SocialSecurityNumber");
                var dobHO = _fileReader.GetOptionalValue(filePath, $"{profileKey}.DateOfBirth");
                var address1 = _fileReader.GetOptionalValue(filePath, $"{profileKey}.Address");
                var city = _fileReader.GetOptionalValue(filePath, $"{profileKey}.City");
                var zip1 = _fileReader.GetOptionalValue(filePath, $"{profileKey}.Zip1");
                var numberYears = _fileReader.GetOptionalValue(filePath, $"{profileKey}.NumberYears");
                var residenceType1 = _fileReader.GetOptionalValue(filePath, $"{profileKey}.ResidenceType1");
                var residenceType2 = _fileReader.GetOptionalValue(filePath, $"{profileKey}.ResidenceType2");
                var residenceType3 = _fileReader.GetOptionalValue(filePath, $"{profileKey}.ResidenceType3");
                var residenceType4 = _fileReader.GetOptionalValue(filePath, $"{profileKey}.ResidenceType4");
                var useEstimator = _fileReader.GetOptionalValue(filePath, $"{profileKey}.UseEstimator");
                var territoryOverride = _fileReader.GetOptionalValue(filePath, $"{profileKey}.TerritoryOverride");

                if (!string.IsNullOrEmpty(quoteType))
                {
                    await DropDown.SelectDropDownAsync(QuoteType_Drp, quoteType, true, 1);
                }

                await InputField.SetTextAreaInputFieldAsync(QuoteDescription_Inp, quoteDesc, true, 1);
                await InputField.SetTextAreaInputFieldAsync(EffectiveDate_Inp, DateTime.Now.AddDays(Convert.ToInt32(effectiveDate)).ToString("MM/dd/yyyy"), true, 1);

                if (!string.IsNullOrEmpty(quoteRollover))
                {
                    var quoteRolloverSel = string.Format(QuoteRollOver_Radio, quoteRollover);
                    await RadioButton.SelectRadioButtonAsync(quoteRolloverSel,"value", true, 1);
                }

                await InputField.SetTextAreaInputFieldAsync(BookCode_Inp, bookBusiness, true, 1);
                await DropDown.SelectDropDownAsync(Producer_Drp, producer, true, 1);
                await Task.Delay(2000);
                await InputField.SetTextAreaInputFieldAsync(HO_FirstName_Input, firstName, true, 1);
                await Task.Delay(2000);
                await InputField.SetTextAreaInputFieldAsync(HO_LastName_Input, lastName, true, 1);
                await Task.Delay(2000);
                await InputField.SetTextAreaInputFieldAsync(H0_SocialSecurityNumber_Input, ssn, true, 1);
                await Task.Delay(2000);
                await InputField.SetTextAreaInputFieldAsync(NamedInsured_DOB_Inp, dob, true, 1);
                await Task.Delay(2000);
                await InputField.SetTextAreaInputFieldAsync(FirstName_Input, firstNameHO, true, 1);
                await Task.Delay(2000);
                await InputField.SetTextAreaInputFieldAsync(LastName_Input, lastNameHO, true, 1);
                await Task.Delay(2000);
                await InputField.SetTextAreaInputFieldAsync(SocialSecurityNumber_Input, ssnHO, true, 1);
                await Task.Delay(2000);
                await InputField.SetTextAreaInputFieldAsync(DateOfBirth_Input, dobHO, true, 1);
                await Task.Delay(2000);
                await InputField.SetTextAreaInputFieldAsync(AddressLine1_Inp, address1, true, 1);
                await Task.Delay(2000);
                await InputField.SetTextAreaInputFieldAsync(City_Inp, city, true, 1);
                await Task.Delay(2000);
                await InputField.SetTextAreaInputFieldAsync(ZipCode_Inp1, zip1, true, 1);

                //await DropDown.SelectDropDownAsync(NumberYears_DropDown,"value", numberYears, true, 1);

                if (!string.IsNullOrEmpty(residenceType1))
                {
                    await RadioButton.SelectRadioButtonAsync(ResidenceType1_Radio,"value", true, 1);
                }

                if (!string.IsNullOrEmpty(residenceType2))
                {
                    await RadioButton.SelectRadioButtonAsync(ResidenceType2_Radio,"value", true, 1);
                }

                if (!string.IsNullOrEmpty(residenceType3))
                {
                    await RadioButton.SelectRadioButtonAsync(ResidenceType3_Radio,"value", true, 1);
                }

                if (!string.IsNullOrEmpty(residenceType4))
                {
                    await RadioButton.SelectRadioButtonAsync(ResidenceType4_Radio,"value", true, 1);
                }

                if (useEstimator == "Yes")
                {
                    await RadioButton.SelectRadioButtonAsync(YesUseEstimator_Radio,"value", true, 1);
                }

                if (useEstimator == "No")
                {
                    await RadioButton.SelectRadioButtonAsync(NoUseEstimator_Radio,"value", true, 1);
                }

                if (!string.IsNullOrEmpty(territoryOverride))
                {
                    await InputField.SetTextAreaInputFieldAsync(TerritoryOverride_Inp, territoryOverride, true, 1);
                }

                await Button.ClickButtonAsync(ContinueButton,ActionType.Click,true, 1);

                logger.WriteLine($"Successfully filled HomeOwnersApplicantData using profile: {profileKey}");
            }
            catch (Exception ex)
            {
                logger.WriteLine($"Error in HomeOwnersApplicantDatafillAsync: {ex.Message}");
                throw new Exception($"Failed to fill HomeOwnersApplicantData using profile '{profileKey}': {ex.Message}", ex);
            }
        }
    }
}

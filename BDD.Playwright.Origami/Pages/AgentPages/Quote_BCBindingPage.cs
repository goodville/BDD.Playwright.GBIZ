using BDD.Playwright.GBIZ.PageElements;
using BDD.Playwright.Origami.Pages.CommonPage;
using Reqnroll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using static OpenQA.Selenium.BiDi.Modules.BrowsingContext.Locator;

namespace BDD.Playwright.GBIZ.Pages.AgentPages
{
    public class Quote_ApplicantPage : BasePage
    {
        private CommonFunctions _commonFunctions;
        private readonly ScenarioContext _scenarioContext;
        public FeatureContext _featureContext;
        public CommonXpath _commonXpath;
        private readonly IReqnrollOutputHelper _ReqnrollLogger;
        public LoginPage _loginPage;

        // Constructor
        public Quote_ApplicantPage(ScenarioContext scenarioContext, CommonFunctions commonFunctions, IReqnrollOutputHelper ReqnrollOutputHelper, LoginPage loginPage, CommonXpath commonXpath) : base(scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _commonFunctions = commonFunctions;
            _ReqnrollLogger = ReqnrollOutputHelper;
            _loginPage = loginPage;
            _commonXpath = commonXpath;
        }
        #region Xpath
        public string QuoteNumber_Text { get; set; } = "//div[@id='formHeaderLeft']";
        public string QuoteType_Drp { get; set; } = "//select[contains(@id,'quoteType')]";
        public string QuoteDescription_Inp { get; set; } = "//input[contains(@id,'quoteDescription')]";
        public string EffectiveDate_Inp { get; set; } = "//input[contains(@id,'effectivedate')]";
        public string QuoteRollOver_Radio { get; set; } = "//input[contains(@id,'rollover') and @value='{0}']";
        public string QuoteRoolOverPreviousPremium { get; set; } = "//input[contains(@id,'rolloverPremium')]";
        public string QuoteRollOverPreviousLimit { get; set; } = "//input[contains(@id,'rolloverPremiumLimit')]";
        public string BookCode_Inp { get; set; } = "//input[contains(@id,'bookofbusiness')]";
        public string Office_Text { get; set; } = "//div[contains(@id,'descriptor_applicant_officedisplay')]";

        public string Office_Drp { get; set; } = "//select[contains(@id,'applicant_office')]";
        public string Producer_Drp { get; set; } = "//select[contains(@id,'applicant_producer')]";
        public string NamedInsured_FirstName_Inp { get; set; } = "//input[contains(@id,'ni_firstName')]";
        public string NamedInsured_MiddleName_Inp { get; set; } = "//input[contains(@id,'ni_middleName')]";
        public string NamedInsured_LastName_Inp { get; set; } = "//input[contains(@id,'ni_lastName')]";
        public string NamedInsured_Suffix_Drp { get; set; } = "//select[contains(@id,'ni_suffix')]";
        // public string NamedInsured_SSN_Inp { get; set; } = "//input[contains(@id,'ni_socialSecurityNumber')]";
        public string NamedInsured_SSN_Inp { get; set; } = "//input[contains(@id,'fld_ni_ssn_1') or @name='ni_socialSecurityNumbertext']";
        //public string HO_NamedInsured_SSN_Inp { get; set; } = "//input[@name='ni_socialSecurityNumbertext']";

        // public string NamedInsured_DOB_Inp { get; set; } = "//input[contains(@id,'ni_dateOfBirthtext')]";
        //public string NamedInsured_DOB_Inp { get; set; } = "//input[@name='ni_dob_1' or @name='ni_dateOfBirthtext' ]";
        //public string NamedInsured_DOB_Inp { get; set; } = "//input[contains(@id,'fld_ni_dob_1')]";
        //public string NamedInsured_Email_Inp { get; set; } = "//input[contains(@id,'fld_ni_dob_1')]";
        //public string NamedInsured_DOB_Inp { get; set; } = "//input[contains(@name,'dob')]";
        //public string NamedInsured_Email_Inp { get; set; } = "//input[contains(@id,'fld_ni_dob_1')]";
        /* public string NamedInsured_DOB_Inp { get; set; } = "//input[contains(@id,'fld_ni_dob_1')]";
         public string NamedInsured_Email_Inp { get; set; } = "//input[contains(@id,'fld_ni_dob_1')]";*/
        //public string NamedInsured_DOB_Inp { get; set; } = "//input[@name='ni_dob_1']";
        public string NamedInsured_DOB_Inp { get; set; } = "//input[contains(@name,'dob') or @name='ni_dateOfBirthtext']";
        //public string NamedInsured_Email_Inp { get; set; } = "//input[contains(@id,'fld_ni_dob_1')]";
        //public string NamedInsured_DOB_Inp { get; set; } = "//input[@name='ni_dob_1']";

        public string NamedInsured_Email_Inp { get; set; } = "//input[@name='ni_email_1']";

        public string SecondNamedInsured_FirstName_Inp { get; set; } = "//input[contains(@id,'ci_firstName')]";
        public string SecondNamedInsured_MiddleName_Inp { get; set; } = "//input[contains(@id,'ci_middleName')]";
        public string SecondNamedInsured_LastName_Inp { get; set; } = "//input[contains(@id,'ci_lastName')]";
        public string SecondNamedInsured_Suffix_Drp { get; set; } = "//select[contains(@id,'ci_suffix')]";
        public string SecondNamedInsured_SSN_Inp { get; set; } = "//input[contains(@id,'ci_socialSecurityNumber')]";
        public string SecondNamedInsured_DOB_Inp { get; set; } = "//input[contains(@id,'ci_dateOfBirthtext')]";
        public string AddOtherNamedInsured_Radio { get; set; } = "//input[contains(@id,'otherNamedInsureds') and @value='{0}']";
        public string AddOtherNamedInsuredReason_Inp { get; set; } = "//textarea[contains(@id,'otherNamedInsuredReason')]";
        public string AddressLine1_Inp { get; set; } = "//input[contains(@id,'sa_address1')]";
        public string AddressLine2_Inp { get; set; } = "//input[contains(@id,'sa_address2')]";
        public string City_Inp { get; set; } = "//input[contains(@id,'sa_city')]";
        public string ZipCode_Inp1 { get; set; } = "(//input[contains(@id,'sa_zip')])[1]";
        public string ZipCode_Inp2 { get; set; } = "(//input[contains(@id,'sa_zip')])[2]";
        //public string ZipCode_Inp3 { get; set; } = "//input[@name='sa_zip4']";
        public string AlsoMailingAddress_Radio { get; set; } = "//input[contains(@id,'sa_isMailingAddress') and @value='{0}']";
        public string Attention_Drp { get; set; } = "//select[contains(@id,'ma_AttnType')]";
        public string Attention_Inp { get; set; } = "//input[contains(@id,'ma_AttnDetail')]";
        public string MailingAddressLine1_Inp { get; set; } = "//input[contains(@id,'ma_address1')]";
        public string MailingAddressLine2_Inp { get; set; } = "//input[contains(@id,'ma_address2')]";
        public string MailingZipCode_Inp { get; set; } = "//input[contains(@id,'ma_zip')]";
        public string NumberofYears_Drp { get; set; } = "//select[contains(@id,'pa_numberyears')]";
        public string ResidenceType_Radio { get; set; } = "//div[contains(text(),'{0}')]/input[contains(@id,'residenceType')]";
        public string ReplacementCost_Radio { get; set; } = "//input[contains(@id,'useEstimator') and @value='{0}']";
        public string TerritoryOverride_Inp { get; set; } = "//input[contains(@id,'territoryOverride')]";
        public string RealtionToInsured_Drp { get; set; } = "//select[contains(@id,'ci_relationshipToInsured')]";
        public string ManualTerritory_Inp { get; set; } = "//input[contains(@id,'manualTerritory')]";
        public string PolicyLimit_Drp { get; set; } = "//select[contains(@id,'pol_limit')]";
        public string Retention_Drp { get; set; } = "//select[contains(@id,'pol_retention')]";
        public string RegisterMemberPortal_Radio { get; set; } = "//input[contains(@id,'ni_registerPolicyholderaccount') and @value='{0}']";
        public string EmailAddress_Inp { get; set; } = "//input[@name='ni_email_1']";
        public string Phone_Inp { get; set; } = "//input[contains(@id,'ni_phone')]";
        public string UsePolicyAddress_Radio { get; set; } = "//input[contains(@id,'ni_usePolicyAddress') and @value='{0}']";
        public string State_Drp { get; set; } = "//select[contains(@id,'ni_state')]";
        public string State_Drp1 { get; set; } = "//select[contains(@id,'fld_sa_state')]";
        public string PrimaryHomeOwnerPolicyInsured { get; set; } = "//input[@name='addlinfoInsuranceForceWithGoodville' and @value='{0}']";
        public string Insuranceinforce { get; set; } = "//input[@name='addlinfoInsuranceForceWithGoodville' and @value='{0}']";
        public string ContinueButton { get; set; } = "//button[contains(text(),'Continue')]";
        public string NextButton { get; set; } = "//div[@id='bottomsubnav_nextlink']";
        //Shoeb_Farmowner_ApplicationPAge_xpath
        public string Residence_Drpdwn { get; set; } = "//input[@id='fld_no_loc_WithResidence_1']";
        public string Farmbuil_Drp { get; set; } = "//input[@id='fld_no_loc_WithFarmBuildings_1']";
        public string Biogas_digesterDrp { get; set; } = "//input[@id='fld_no_loc_BiogasDigester_1']";
        public string Solarpanel_drp { get; set; } = "//input[@id='fld_no_loc_WithSolarPanel_1']";

        //Vijay_BC_Xpath

        public string Business_type_Radio { get; set; } = "//input[contains(@id,'businessType')  and @value='{0}']";

        public string Businessdescription_Inp { get; set; } = "//textarea[@id='fld_businessDescription']";

        public string Business_Function_Radio { get; set; } = "//input[contains(@id,'businessFunction')  and @value='{0}']";

        public string InfoBusinessEndeavorBankruptcy_Radio { get; set; } = "//input[@name='addlinfoBusinessEndeavorBankruptcy' and @value='{0}']";

        public string InfoToolsEquipment_Radio { get; set; } = "//input[@name='addlinfoToolsEquipment' and @value='{0}']";

        public string InfoCanceledRefusedCoverage_Radio { get; set; } = "//input[@name='addlinfoCanceledRefusedCoverage' and @value='{0}']";
        public string SaveButton { get; set; } = "//a[normalize-space()='save']";
        //Rahul_WC_Xpath
        public string Description_Input { get; set; } = "//textarea[contains(@id,'Description')]";
        //public string Office_Drp { get; set; } = "//select[@id='fld_applicant_office']";
        public string PolicyType_DropDown { get; set; } = "//select[contains(@id,'policytype')]";
        public string QuoteNumber_Input { get; set; } = "//input[contains(@id,'quoteNumber')]";
        public string AddanotherNamedInsured_Input { get; set; } = "//div[@id='ni_addIndividual']";
        public string FEIN_Input { get; set; } = "//input[@id='fld_ein']";
        public string ContactInfo_Name_Input { get; set; } = "//input[contains(@id,'ContactInfoName')]";
        public string ContactInfo_OfficePhone_Input { get; set; } = "//input[contains(@id,'ContactInfoOfficePhone')]";
        public string ContactInfo_MobilePhone_Input { get; set; } = "//input[contains(@id,'ContactInfoMobilePhone')]";
        public string ContactInfo_Email_Input { get; set; } = "//input[contains(@id,'ContactInfoEmail')]";
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

        //Rahul HomeOwner Xpath
        public string FirstName_Input { get; set; } = "//input[@id='fld_ci_firstName']";
        public string LastName_Input { get; set; } = "//input[@id='fld_ci_lastName']";
        public string SocialSecurityNumber_Input { get; set; } = "//input[@id='fld_ci_socialSecurityNumbertext']";
        public string DateOfBirth_Input { get; set; } = "//input[@id='fld_ci_dateOfBirthtext']";
        public string NumberYears_DropDown { get; set; } = "//select[@id='fld_pa_numberyears']";
        // public string NumberYears_DropDown { get; set; } = "//select[contains(@id,'fld_pa_numberyears')]";
        public string ResidenceType1_Radio { get; set; } = "//input[@id='fld_residenceType_1']";
        public string ResidenceType2_Radio { get; set; } = "//input[@id='fld_residenceType_2']";
        public string ResidenceType3_Radio { get; set; } = "//input[@id='fld_residenceType_3']";
        public string ResidenceType4_Radio { get; set; } = "//input[@id='fld_residenceType_4']";
        public string YesUseEstimator_Radio { get; set; } = "//input[@id='fld_yes_useEstimator']";
        public string NoUseEstimator_Radio { get; set; } = "//input[@id='fld_no_useEstimator']";
        public string TerritoryOverride_Input { get; set; } = "//input[@id='fld_territoryOverride']";

        //Rahul Umbrella Xpath
        public string UmbrellaEachOcc_DropDown { get; set; } = "//select[@id='fld_umbrellaEachOcc']";
        public string ClaimsLosses_Radio { get; set; } = "//input[contains(@id,'claimsLosses') and @value='{0}']";
        //public string NoClaimsLosses_Input { get; set; } = "//input[@id='fld_no_claimsLosses']";
        public string AttributesSubmit_Button { get; set; } = "//button[@id='buttonattributes.id_submitbutton']";

        public string Billing_Link { get; set; } = "//a[normalize-space()='Billing']";
        public string NoBillingUnearnedPremium_Input { get; set; } = "//input[@id='fld_no_billing_UnearnedPremium']";
        public string PaymentPlan_Input { get; set; } = "//input[@id='pp1_paymentPlan']";

        //pooja Xpath
        public string TCpage_Description_txt { get; set; } = "//textarea[@id='fld_businessDescription']";
        public string TCpage_ExteriorSprayPainting_Radiobtn { get; set; } = "//input[@name='exteriorSpray' and @value='{0}']";
        public string TCpage_GrossAnnualIncome_txt { get; set; } = "//input[@id='fld_addlinfoGrossAnnualReceipts']";

        //location details
        public string TCpage_MilestoFireDept_Inp { get; set; } = "//input[@id='fld_loc_milesToFireDept_1']";
        public string TCpage_RespondingFireDept_Inp { get; set; } = "//input[@id='fld_loc_respondingFireDept_1']";
        public string FOpage_NumberOfAcres_Inp { get; set; } = "//input[contains(@id,'fld_loc_NumAcresOwned')]";
        // public string FOpage_Next_Btn { get; set; } = "//div[@id='bottomsubnav_nextlink']";
        public string FOpage_NumberOfAcresLeased_Inp { get; set; } = "//input[contains(@id,'fld_loc_NumAcresLeasedFrom')]";
        public string FOpage_NumberOfAcresRented_Inp { get; set; } = "//input[contains(@id,'fld_loc_NumAcresRentedTo')]";
        public string TCpage_EmployeePayroll_txt { get; set; } = "//input[@id='fld_addlinfoEmployeePayroll']";
        //public string FOpage_TypeofBusiness_RadioBtn { get; set; } = "//input[@name='application_TypeofPolicy' and @value='{0}']";
        public string FOpage_TypeofBusiness_RadioBtn { get; set; } = "//input[@name='application_TypeofPolicy' and @value='Individual']";
        public string FORelationToInsured_Drpdwn { get; set; } = "//select[contains(@id,'ni_relationshipToInsured')]";
        public string FOCopyToAddLocation_Btn { get; set; } = "//button[@id='buttoncopyAddrToLocButton']";
        public string FOpage_FarmOperation_Btn { get; set; } = "//a[normalize-space()='Poultry']";
        public string FOpage_FarmOperation_RadioBtn { get; set; } = "//label[@for='fld_farmOps_fields_Poultry_Broilers']";
        public string FOpage_FarmOperationPercentage_txt { get; set; } = "//input[@id='fld_farmOps_Percentage_Poultry_Broilers']";
        //Farmowner

        public string FOpage_Save_Btn { get; set; } = "//a[text()='save']";
        public string FOpage_NumberOfDogs_Inp { get; set; } = "//input[contains(@id,'loc_dogsNumber')]";
        public string FOpage_OutdoorWoodFurnance_RadioBtn { get; set; } = "//input[contains(@id,'loc_FurnaceOutdoors') and @value='{0}']";
        public string FOpage_SwimmingPool_RadioBtn { get; set; } = "//input[contains(@name,'loc_Pool_1') and @value='{0}']";
        public string FOpage_pond_RadioBtn { get; set; } = "//input[contains(@name,'loc_pond_1') and @value='{0}']";
        public string FOpage_Trampoline_RadioBtn { get; set; } = "//input[contains(@name,'loc_Trampoline') and @value='{0}']";
        public string FOpage_ZipLine_Radiobtn { get; set; } = "//input[contains(@name,'loc_zipLine_1') and @value='{0}']";
        public string FOpage_ManualPits_RadioBtn { get; set; } = "//input[contains(@id,'fld_no_loc_lagoons') and @value='{0}']";
        public string Fopage_Premises_RadioBtn { get; set; } = "//input[contains(@name,'loc_agentInspection') and @value='{0}']";
        public string Bind_Link { get; set; } = "//a[normalize-space()='Bind']";
        public string AgentEmail_Input { get; set; } = "//input[@id='fld_agentEmail']";
        public string BindingDestinationEmail1_Input { get; set; } = "//div[contains(normalize-space(text()), '{0}')]/input[@name='binding_destinationemail']";
        public string BindingAgreeToTerms_Input { get; set; } = "//input[@id='fld_binding_agreetoterms']";
        public string AttachDocuments_SubTab { get; set; } = "//div[normalize-space()='Attach Documents']//div[@id='subtab_']";
        public string BindingInformation_SubTab { get; set; } = "//div[normalize-space()='Binding Information']//div[@id='subtab_']";
        public string Save_Link { get; set; } = "//a[normalize-space()='save']";
        public string Continue_btn { get; set; } = "//button[contains(text(),'Continue')]";
        public string AddressError_close { get; set; } = "(//span[contains(text(),'Close')])[1]";
        public string Premises_dropDown { get; set; } = "//input[@id='fld_no_loc_zipLine_1']";
        //Personal Auto Xpath

        public string Numberyears_DRP { get; set; } = "//select[contains(@id,'fld_pa_numberyears')]";

        public string IsMailingAddress_Radio { get; set; } = "//input[contains(@name,'sa_isMailingAddress') and @value='{0}']";

        public string ManualTerritory_Input { get; set; } = "//input[@id='fld_manualTerritory']";

        public string DiscountPackage_DropDown { get; set; } = "//select[@id='fld_packageDiscount']";
        //pending
        public string PriorPolicyExpireDate_Input { get; set; } = "//input[@id='fld_priorPolicyExpireDate']";
        public string PriorInsuranceCarrier_DropDown { get; set; } = "//select[@id='fld_priorInsuranceCarrier']";
        public string PoriorCovBIPP_Input { get; set; } = "//input[@id='fld_priorCovBIPP']";
        public string PriorCovBIPO_Input { get; set; } = "//input[@id='fld_priorCovBIPO']";
        public string PriorCovPD_Input { get; set; } = "//input[@id='fld_priorCovPD']";
        public string PriorCovCSL_Input { get; set; } = "//input[@id='fld_priorCovCSL']";
        public string PriorCovAge_drp { get; set; } = "//select[@id='fld_priorCovAge']";
        public string NumberYearsContinuous_drp { get; set; } = "//select[@id='fld_numberYearsContinuous']";

        public string FinancialResponsibility_radio { get; set; } = "//input[contains(@name,'financialResponsibility') and @value='{0}']";
        public string VehicleSharing_radio { get; set; } = "//input[contains(@name,'vehicleSharing') and @value='{0}']";
        public string ResidenceType_drp { get; set; } = "//select[@id='fld_residenceType']";

        //public string AddressError_close { get; set; } = "(//span[contains(text(),'Close')])[1]";

        #endregion

        #region Default Application Fill
        public async Task ApplicantDatafillAsync()
        {
            commonFunctions.ReadTestDataForApplicantPage();
            commonFunctions.UserWaitForPageToLoadCompletly();
            if (commonFunctions.ApplicantQuoteType_LabelAndValue.Item2 != string.Empty)
            {
                DropDown.SelectDropDown(QuoteType_Drp, commonFunctions.ApplicantQuoteType_LabelAndValue.Item2, true, 1);

            }

            //DropDown.SelectDropDown(QuoteType_Drp, commonFunctions.ApplicantQuoteType_LabelAndValue.Item2, true, 1);
            var a = new Random();
            var b = a.Next(1, 9999999);
            string c = commonFunctions.ApplicantQuoteDescription_LabelAndValue.Item2 + b.ToString();
            InputField.SetTextAreaInputField(QuoteDescription_Inp, c, true, 1);
            InputField.SetTextAreaInputField(EffectiveDate_Inp, DateTime.Now.AddDays(Convert.ToInt32(commonFunctions.ApplicantEffectiveDate_LabelAndValue.Item2)).ToString("MM/dd/yyyy"), true, 1);
            if (commonFunctions.ApplicantQuoteRollOver_LabelAndValue.Item2 != string.Empty)
            {
                if (commonFunctions.ApplicantQuoteRollOver_LabelAndValue.Item2 == "Yes")
                {
                    var QuoteRollOver = string.Format(QuoteRollOver_Radio, commonFunctions.ApplicantQuoteRollOver_LabelAndValue.Item2);
                    RadioButton.SelectRadioButton(QuoteRollOver, true, 1);
                }
                else
                {
                    var QuoteRollOver = string.Format(QuoteRollOver_Radio, commonFunctions.ApplicantQuoteRollOver_LabelAndValue.Item2);
                    RadioButton.SelectRadioButton(QuoteRollOver, true, 1);
                }
            }

            InputField.SetTextAreaInputField(BookCode_Inp, commonFunctions.ApplicantBookBusiness_LabelAndValue.Item2, true, 1);
            /* if (commonFunctions.ApplicantOffice_LabelAndValue.Item2 != string.Empty)
             {
                 DropDown.SelectDropDown(Office_Drp, commonFunctions.ApplicantOffice_LabelAndValue.Item2, true, 1);
             }*/
            DropDown.SelectDropDown(Producer_Drp, commonFunctions.ApplicantBookProducer_LabelAndValue.Item2, true, 1);
            InputField.SetTextAreaInputField(NamedInsured_FirstName_Inp, commonFunctions.ApplicantFirstName_LabelAndValue.Item2, true, 1);
            InputField.SetTextAreaInputField(NamedInsured_LastName_Inp, commonFunctions.ApplicantLastName_LabelAndValue.Item2, true, 1);
            InputField.SetTextAreaInputField(NamedInsured_SSN_Inp, commonFunctions.ApplicantSSN_LabelAndValue.Item2, true, 1);
            InputField.SetTextAreaInputField(NamedInsured_DOB_Inp, commonFunctions.ApplicantDOB1_LabelAndValue.Item2, true, 1);
            InputField.SetTextAreaInputField(NamedInsured_Email_Inp, commonFunctions.ApplicantEmail_LabelAndValue.Item2, true, 1);
            InputField.SetTextAreaInputField(Phone_Inp, commonFunctions.ApplicantPhone_LabelAndValue.Item2, true, 1);
            if (commonFunctions.ApplicantSSN_LabelAndValue.Item2 != string.Empty)
            {
                InputField.SetTextAreaInputField(NamedInsured_SSN_Inp, commonFunctions.ApplicantSSN_LabelAndValue.Item2, true, 1);
            }

            if (commonFunctions.ApplicantDOB1_LabelAndValue.Item2 != string.Empty)
            {
                InputField.SetTextAreaInputField(NamedInsured_DOB_Inp, commonFunctions.ApplicantDOB1_LabelAndValue.Item2, true, 1);
            }

            if (commonFunctions.ApplicantEmail_LabelAndValue.Item2 != string.Empty)
            {
                InputField.SetTextAreaInputField(NamedInsured_Email_Inp, commonFunctions.ApplicantEmail_LabelAndValue.Item2, true, 1);
            }

            if (commonFunctions.ApplicantPhone_LabelAndValue.Item2 != string.Empty)
            {
                InputField.SetTextAreaInputField(Phone_Inp, commonFunctions.ApplicantPhone_LabelAndValue.Item2, true, 1);
            }
            InputField.SetTextAreaInputField(AddressLine1_Inp, commonFunctions.ApplicantAddress1_LabelAndValue.Item2, true, 1);
            InputField.SetTextAreaInputField(City_Inp, commonFunctions.ApplicantCity_LabelAndValue.Item2, true, 1);
            if (commonFunctions.ApplicantState_LabelAndValue.Item2 != string.Empty)
            {
                DropDown.SelectDropDown(State_Drp1, commonFunctions.ApplicantState_LabelAndValue.Item2, true, 1);
            }

            InputField.SetTextAreaInputField(ZipCode_Inp1, commonFunctions.ApplicantZip1_LabelAndValue.Item2, true, 1);
            //personal auto

            if (commonFunctions.isMailingAddress_Radio_LabelAndValue.Item2 != string.Empty)
            {
                if (commonFunctions.isMailingAddress_Radio_LabelAndValue.Item2 == "Yes")
                {
                   var isMailingAddress_Radio1 = string.Format(isMailingAddress_Radio, commonFunctions.isMailingAddress_Radio_LabelAndValue.Item2);
                    RadioButton.SelectRadioButton(isMailingAddress_Radio1, true, 1);
                }
                else
                {
                    var isMailingAddress_Radio1 = string.Format(isMailingAddress_Radio, commonFunctions.isMailingAddress_Radio_LabelAndValue.Item2);
                    RadioButton.SelectRadioButton(isMailingAddress_Radio1, true, 1);
                }
            }
            //NUMBEROFYEARS_PA
            if (commonFunctions.numberyears_DRP_LabelAndValue.Item2 != string.Empty)
            {
                DropDown.SelectDropDown(numberyears_DRP, commonFunctions.numberyears_DRP_LabelAndValue.Item2, true, 1);
            }

            //MANUAL_TERRITORY

            if (commonFunctions.ManualTerritory_Input_LabelAndValue.Item2 != string.Empty)
            {

                InputField.SetTextAreaInputField(ManualTerritory_Input, commonFunctions.ManualTerritory_Input_LabelAndValue.Item2, true, 1);
            }

            if (commonFunctions.DiscountPackage_DropDown_LabelAndValue.Item2 != string.Empty)
            {
                DropDown.SelectDropDown(DiscountPackage_DropDown, commonFunctions.DiscountPackage_DropDown_LabelAndValue.Item2, true, 1);
            }

            if (commonFunctions.PriorPolicyExpireDate_Input_LabelAndValue.Item2 != string.Empty)
            {
                InputField.SetTextAreaInputField(PriorPolicyExpireDate_Input, commonFunctions.PriorPolicyExpireDate_Input_LabelAndValue.Item2, true, 1);
            }

            if (commonFunctions.priorCovBIPP_Input_LabelAndValue.Item2 != string.Empty)
            {
                InputField.SetTextAreaInputField(priorCovBIPP_Input, commonFunctions.priorCovBIPP_Input_LabelAndValue.Item2, true, 1);
            }
            if (commonFunctions.priorCovBIPO_Input_LabelAndValue.Item2 != string.Empty)
            {
                InputField.SetTextAreaInputField(priorCovBIPO_Input, commonFunctions.priorCovBIPO_Input_LabelAndValue.Item2, true, 1);
            }
            if (commonFunctions.priorCovPD_Input_LabelAndValue.Item2 != string.Empty)
            {
                InputField.SetTextAreaInputField(priorCovPD_Input, commonFunctions.priorCovPD_Input_LabelAndValue.Item2, true, 1);
            }
            if (commonFunctions.priorCovCSL_Input_LabelAndValue.Item2 != string.Empty)
            {
                InputField.SetTextAreaInputField(priorCovCSL_Input, commonFunctions.priorCovCSL_Input_LabelAndValue.Item2, true, 1);
            }

            if (commonFunctions.priorCovAge_drp_LabelAndValue.Item2 != string.Empty)
            {
                DropDown.SelectDropDown(priorCovAge_drp, commonFunctions.priorCovAge_drp_LabelAndValue.Item2, true, 1);
            }
            if (commonFunctions.numberYearsContinuous_drp_LabelAndValue.Item2 != string.Empty)
            {
                DropDown.SelectDropDown(numberYearsContinuous_drp, commonFunctions.numberYearsContinuous_drp_LabelAndValue.Item2, true, 1);
            }
            if (commonFunctions.financialResponsibility_radio_LabelAndValue.Item2 != string.Empty)
            {
                if (commonFunctions.financialResponsibility_radio_LabelAndValue.Item2 == "Yes")
                {
                    string financialResponsibility_Radio1 = string.Format(financialResponsibility_radio, commonFunctions.financialResponsibility_radio_LabelAndValue.Item2);
                    RadioButton.SelectRadioButton(financialResponsibility_Radio1, true, 1);
                }
                else
                {
                    string financialResponsibility_Radio1 = string.Format(financialResponsibility_radio, commonFunctions.financialResponsibility_radio_LabelAndValue.Item2);
                    RadioButton.SelectRadioButton(financialResponsibility_Radio1, true, 1);
                }

            }

            if (commonFunctions.vehicleSharing_radio_LabelAndValue.Item2 != string.Empty)
            {
                if (commonFunctions.vehicleSharing_radio_LabelAndValue.Item2 == "Yes")
                {
                    string vehicleSharing_Radio1 = string.Format(vehicleSharing_radio, commonFunctions.vehicleSharing_radio_LabelAndValue.Item2);
                    RadioButton.SelectRadioButton(vehicleSharing_Radio1, true, 1);
                }
                else
                {
                    string vehicleSharing_Radio1 = string.Format(vehicleSharing_radio, commonFunctions.vehicleSharing_radio_LabelAndValue.Item2);
                    RadioButton.SelectRadioButton(vehicleSharing_Radio1, true, 1);
                }
            }

            if (commonFunctions.residenceType_drp_LabelAndValue.Item2 != string.Empty)
            {
                DropDown.SelectDropDown(residenceType_drp, commonFunctions.residenceType_drp_LabelAndValue.Item2, true, 1);
            }






            if (commonFunctions.ApplicantZip2_LabelAndValue.Item2 != string.Empty)
            {
                InputField.SetTextAreaInputField(ZipCode_Inp2, commonFunctions.ApplicantZip2_LabelAndValue.Item2, true, 1);
            }
            if (commonFunctions.ApplicantPrimaryHomeOwnerPolicyInsured_LabelAndValue.Item2 != string.Empty)
            {
                if (commonFunctions.ApplicantPrimaryHomeOwnerPolicyInsured_LabelAndValue.Item2 == "Yes")
                {
                    string HomeOwnerPolicyInsured = string.Format(PrimaryHomeOwnerPolicyInsured, commonFunctions.ApplicantPrimaryHomeOwnerPolicyInsured_LabelAndValue.Item2);
                    RadioButton.SelectRadioButton(HomeOwnerPolicyInsured, true, 1);
                }
                else
                {
                    string HomeOwnerPolicyInsured = string.Format(PrimaryHomeOwnerPolicyInsured, commonFunctions.ApplicantPrimaryHomeOwnerPolicyInsured_LabelAndValue.Item2);
                    RadioButton.SelectRadioButton(HomeOwnerPolicyInsured, true, 1);
                }

            }
            if (commonFunctions.ApplicantBusinessType_LabelAndValue.Item2 != string.Empty)
            {
                {
                    if (commonFunctions.ApplicantBusinessType_LabelAndValue.Item2 == "Yes")

                    //BC_BUSINESS_TYPE
                    {
                        string BusinessType = string.Format(Business_type_Radio, commonFunctions.ApplicantBusinessType_LabelAndValue.Item2);
                        RadioButton.SelectRadioButton(BusinessType, true, 1);
                    }
                    else
                    {
                        string BusinessType = string.Format(Business_type_Radio, commonFunctions.ApplicantBusinessType_LabelAndValue.Item2);
                        RadioButton.SelectRadioButton(BusinessType, true, 1);
                    }
                }

                if (commonFunctions.Businessdescription_Inp_LabelAndValue.Item2 != string.Empty)
                {
                    InputField.SetTextAreaInputField(Businessdescription_Inp, commonFunctions.Businessdescription_Inp_LabelAndValue.Item2, true, 1);
                }
                //BC_BUSINESS_Fuction
                if (commonFunctions.ApplicantBusinessType_LabelAndValue.Item2 != string.Empty)
                {
                    if (commonFunctions.ApplicantBusinessFunction_LabelAndValue.Item2 == "Yes")
                    {
                        string BusinessFunction = string.Format(Business_Function_Radio, commonFunctions.ApplicantBusinessFunction_LabelAndValue.Item2);
                        RadioButton.SelectRadioButton(BusinessFunction, true, 1);
                    }
                    else
                    {
                        string BusinessFunction = string.Format(Business_Function_Radio, commonFunctions.ApplicantBusinessFunction_LabelAndValue.Item2);
                        RadioButton.SelectRadioButton(BusinessFunction, true, 1);
                    }
                }
                if (commonFunctions.ApplicantInsuranceinforce_LabelAndValue.Item2 != string.Empty)
                {
                    if (commonFunctions.ApplicantInsuranceinforce_LabelAndValue.Item2 == "Yes")
                    {
                        string Insuranceinforce1 = string.Format(Insuranceinforce, commonFunctions.ApplicantInsuranceinforce_LabelAndValue.Item2);
                        RadioButton.SelectRadioButton(Insuranceinforce1, true, 1);
                    }
                    else
                    {
                        string Insuranceinforce1 = string.Format(Insuranceinforce, commonFunctions.ApplicantInsuranceinforce_LabelAndValue.Item2);
                        RadioButton.SelectRadioButton(Insuranceinforce1, true, 1);
                    }

                }
                if (commonFunctions.ApplicantinfoBusinessEndeavorBankruptcy_LabelAndValue.Item2 != string.Empty)
                {
                    if (commonFunctions.ApplicantinfoBusinessEndeavorBankruptcy_LabelAndValue.Item2 == "Yes")
                    {
                        string infoBusinessEndeavorBankruptcy = string.Format(infoBusinessEndeavorBankruptcy_Radio, commonFunctions.ApplicantinfoBusinessEndeavorBankruptcy_LabelAndValue.Item2);
                        RadioButton.SelectRadioButton(infoBusinessEndeavorBankruptcy, true, 1);
                    }
                    else
                    {
                        string infoBusinessEndeavorBankruptcy = string.Format(infoBusinessEndeavorBankruptcy_Radio, commonFunctions.ApplicantinfoBusinessEndeavorBankruptcy_LabelAndValue.Item2);
                        RadioButton.SelectRadioButton(infoBusinessEndeavorBankruptcy, true, 1);
                    }
                }
                if (commonFunctions.ApplicantinfoToolsEquipment_LabelAndValue.Item2 != string.Empty)
                {
                    if (commonFunctions.ApplicantinfoToolsEquipment_LabelAndValue.Item2 == "Yes")
                    {
                        string infoToolsEquipment = string.Format(infoToolsEquipment_Radio, commonFunctions.ApplicantinfoToolsEquipment_LabelAndValue.Item2);
                        RadioButton.SelectRadioButton(infoToolsEquipment, true, 1);
                    }
                    else
                    {
                        string infoToolsEquipment = string.Format(infoToolsEquipment_Radio, commonFunctions.ApplicantinfoToolsEquipment_LabelAndValue.Item2);
                        RadioButton.SelectRadioButton(infoToolsEquipment, true, 1);
                    }
                }

                if (commonFunctions.ApplicantinfoCanceledRefusedCoverage_LabelAndValue.Item2 != string.Empty)
                {
                    if (commonFunctions.ApplicantinfoCanceledRefusedCoverage_LabelAndValue.Item2 == "Yes")
                    {
                        string infoCanceledRefusedCoverage = string.Format(infoCanceledRefusedCoverage_Radio, commonFunctions.ApplicantinfoCanceledRefusedCoverage_LabelAndValue.Item2);
                        RadioButton.SelectRadioButton(infoCanceledRefusedCoverage, true, 1);
                    }
                    else
                    {
                        string infoCanceledRefusedCoverage = string.Format(infoCanceledRefusedCoverage_Radio, commonFunctions.ApplicantinfoCanceledRefusedCoverage_LabelAndValue.Item2);
                        RadioButton.SelectRadioButton(infoCanceledRefusedCoverage, true, 1);
                    }
                }






            }


            Button.ClickButton(Continue_btn, ActionType.Click, true, 1);
            commonFunctions.UserWaitForPageToLoadCompletly();
        }
        #endregion

        #region PA Application Fill
        public async Task PAApplicantDatafillAsync()
        {
            commonFunctions.ReadTestDataForApplicantPage();
            commonFunctions.UserWaitForPageToLoadCompletly();
            if (commonFunctions.ApplicantQuoteType_LabelAndValue.Item2 != string.Empty)
            {
                DropDown.SelectDropDown(QuoteType_Drp, commonFunctions.ApplicantQuoteType_LabelAndValue.Item2, true, 1);

            }

            //DropDown.SelectDropDown(QuoteType_Drp, commonFunctions.ApplicantQuoteType_LabelAndValue.Item2, true, 1);
            InputField.SetTextAreaInputField(QuoteDescription_Inp, commonFunctions.ApplicantQuoteDescription_LabelAndValue.Item2, true, 1);
            InputField.SetTextAreaInputField(EffectiveDate_Inp, DateTime.Now.AddDays(Convert.ToInt32(commonFunctions.ApplicantEffectiveDate_LabelAndValue.Item2)).ToString("MM/dd/yyyy"), true, 1);
            if (commonFunctions.ApplicantQuoteRollOver_LabelAndValue.Item2 != string.Empty)
            {
                if (commonFunctions.ApplicantQuoteRollOver_LabelAndValue.Item2 == "Yes")
                {
                    string QuoteRollOver = string.Format(QuoteRollOver_Radio, commonFunctions.ApplicantQuoteRollOver_LabelAndValue.Item2);
                    RadioButton.SelectRadioButton(QuoteRollOver, true, 1);
                }
                else
                {
                    string QuoteRollOver = string.Format(QuoteRollOver_Radio, commonFunctions.ApplicantQuoteRollOver_LabelAndValue.Item2);
                    RadioButton.SelectRadioButton(QuoteRollOver, true, 1);
                }
            }

            InputField.SetTextAreaInputField(BookCode_Inp, commonFunctions.ApplicantBookBusiness_LabelAndValue.Item2, true, 1);
            if (commonFunctions.ApplicantOffice_LabelAndValue.Item2 != string.Empty)
            {
                DropDown.SelectDropDown(Office_Drp, commonFunctions.ApplicantOffice_LabelAndValue.Item2, true, 1);
            }

            DropDown.SelectDropDown(Producer_Drp, commonFunctions.ApplicantBookProducer_LabelAndValue.Item2, true, 1);
            /* if (commonFunctions.ApplicantOffice_LabelAndValue.Item2 != string.Empty)
             {
                 DropDown.SelectDropDown(Office_Drp, commonFunctions.ApplicantOffice_LabelAndValue.Item2, true, 1);
             }*/
            DropDown.SelectDropDown(Producer_Drp, commonFunctions.ApplicantBookProducer_LabelAndValue.Item2, true, 1);
            InputField.SetTextAreaInputField(NamedInsured_FirstName_Inp, commonFunctions.ApplicantFirstName_LabelAndValue.Item2, true, 1);
            InputField.SetTextAreaInputField(NamedInsured_LastName_Inp, commonFunctions.ApplicantLastName_LabelAndValue.Item2, true, 1);
            if (commonFunctions.ApplicantSSN_LabelAndValue.Item2 != string.Empty)
            {
                InputField.SetTextAreaInputField(NamedInsured_SSN_Inp, commonFunctions.ApplicantSSN_LabelAndValue.Item2, true, 1);
            }

            InputField.SetTextAreaInputField(NamedInsured_DOB_Inp, commonFunctions.ApplicantDOB1_LabelAndValue.Item2, true, 1);
            InputField.SetTextAreaInputField(NamedInsured_SSN_Inp, commonFunctions.ApplicantSSN_LabelAndValue.Item2, true, 1);
            InputField.SetTextAreaInputField(NamedInsured_DOB_Inp, commonFunctions.ApplicantDOB1_LabelAndValue.Item2, true, 1);
            InputField.SetTextAreaInputField(NamedInsured_Email_Inp, commonFunctions.ApplicantEmail_LabelAndValue.Item2, true, 1);
            InputField.SetTextAreaInputField(Phone_Inp, commonFunctions.ApplicantPhone_LabelAndValue.Item2, true, 1);
            if (commonFunctions.ApplicantSSN_LabelAndValue.Item2 != string.Empty)
            {
                InputField.SetTextAreaInputField(NamedInsured_SSN_Inp, commonFunctions.ApplicantSSN_LabelAndValue.Item2, true, 1);
            }

            if (commonFunctions.ApplicantDOB1_LabelAndValue.Item2 != string.Empty)
            {
                InputField.SetTextAreaInputField(NamedInsured_DOB_Inp, commonFunctions.ApplicantDOB1_LabelAndValue.Item2, true, 1);
            }

            if (commonFunctions.ApplicantEmail_LabelAndValue.Item2 != string.Empty)
            {
                InputField.SetTextAreaInputField(NamedInsured_Email_Inp, commonFunctions.ApplicantEmail_LabelAndValue.Item2, true, 1);
            }

            if (commonFunctions.ApplicantPhone_LabelAndValue.Item2 != string.Empty)
            {
                InputField.SetTextAreaInputField(Phone_Inp, commonFunctions.ApplicantPhone_LabelAndValue.Item2, true, 1);
            }

            InputField.SetTextAreaInputField(AddressLine1_Inp, commonFunctions.ApplicantAddress1_LabelAndValue.Item2, true, 1);
            InputField.SetTextAreaInputField(City_Inp, commonFunctions.ApplicantCity_LabelAndValue.Item2, true, 1);
            if (commonFunctions.ApplicantState_LabelAndValue.Item2 != string.Empty)
            {
                //For scolling:
                Button.ScrollIntoView(State_Drp1, true, 1);
                DropDown.SelectDropDown(State_Drp1, commonFunctions.ApplicantState_LabelAndValue.Item2, true, 1);
            }

            InputField.SetTextAreaInputField(ZipCode_Inp1, commonFunctions.ApplicantZip1_LabelAndValue.Item2, true, 1);

            await Task.Delay(1000);

            Button.ClickButton(AddressError_close, ActionType.Click, true, 1);
            await Task.Delay(1000);
            //personal auto

            if (commonFunctions.isMailingAddress_Radio_LabelAndValue.Item2 != string.Empty)
            {
                if (commonFunctions.isMailingAddress_Radio_LabelAndValue.Item2 == "Yes")
                {
                    var isMailingAddress_Radio1 = string.Format(isMailingAddress_Radio, commonFunctions.isMailingAddress_Radio_LabelAndValue.Item2);
                    RadioButton.SelectRadioButton(isMailingAddress_Radio1, true, 1);
                }
                else
                {
                    var isMailingAddress_Radio1 = string.Format(isMailingAddress_Radio, commonFunctions.isMailingAddress_Radio_LabelAndValue.Item2);
                    RadioButton.SelectRadioButton(isMailingAddress_Radio1, true, 1);
                }
            }
            //NUMBEROFYEARS_PA
            if (commonFunctions.numberyears_DRP_LabelAndValue.Item2 != string.Empty)
            {
                DropDown.SelectDropDown(numberyears_DRP, commonFunctions.numberyears_DRP_LabelAndValue.Item2, true, 1);
            }

            //MANUAL_TERRITORY

            if (commonFunctions.ManualTerritory_Input_LabelAndValue.Item2 != string.Empty)
            {

                InputField.SetTextAreaInputField(ManualTerritory_Input, commonFunctions.ManualTerritory_Input_LabelAndValue.Item2, true, 1);
            }

            if (commonFunctions.DiscountPackage_DropDown_LabelAndValue.Item2 != string.Empty)
            {
                DropDown.SelectDropDown(DiscountPackage_DropDown, commonFunctions.DiscountPackage_DropDown_LabelAndValue.Item2, true, 1);
            }

            if (commonFunctions.PriorPolicyExpireDate_Input_LabelAndValue.Item2 != string.Empty)
            {
                InputField.SetTextAreaInputField(PriorPolicyExpireDate_Input, commonFunctions.PriorPolicyExpireDate_Input_LabelAndValue.Item2, true, 1);
            }

            if (commonFunctions.priorCovBIPP_Input_LabelAndValue.Item2 != string.Empty)
            {
                InputField.SetTextAreaInputField(priorCovBIPP_Input, commonFunctions.priorCovBIPP_Input_LabelAndValue.Item2, true, 1);
            }

            if (commonFunctions.priorCovBIPO_Input_LabelAndValue.Item2 != string.Empty)
            {
                InputField.SetTextAreaInputField(priorCovBIPO_Input, commonFunctions.priorCovBIPO_Input_LabelAndValue.Item2, true, 1);
            }

            if (commonFunctions.priorCovPD_Input_LabelAndValue.Item2 != string.Empty)
            {
                InputField.SetTextAreaInputField(priorCovPD_Input, commonFunctions.priorCovPD_Input_LabelAndValue.Item2, true, 1);
            }

            if (commonFunctions.priorCovCSL_Input_LabelAndValue.Item2 != string.Empty)
            {
                InputField.SetTextAreaInputField(priorCovCSL_Input, commonFunctions.priorCovCSL_Input_LabelAndValue.Item2, true, 1);
            }

            if (commonFunctions.priorCovAge_drp_LabelAndValue.Item2 != string.Empty)
            {
                DropDown.SelectDropDown(priorCovAge_drp, commonFunctions.priorCovAge_drp_LabelAndValue.Item2, true, 1);
            }

            if (commonFunctions.numberYearsContinuous_drp_LabelAndValue.Item2 != string.Empty)
            {
                DropDown.SelectDropDown(numberYearsContinuous_drp, commonFunctions.numberYearsContinuous_drp_LabelAndValue.Item2, true, 1);
            }

            if (commonFunctions.financialResponsibility_radio_LabelAndValue.Item2 != string.Empty)
            {
                if (commonFunctions.financialResponsibility_radio_LabelAndValue.Item2 == "Yes")
                {
                    var financialResponsibility_Radio1 = string.Format(financialResponsibility_radio, commonFunctions.financialResponsibility_radio_LabelAndValue.Item2);
                    RadioButton.SelectRadioButton(financialResponsibility_Radio1, true, 1);
                }
                else
                {
                    var financialResponsibility_Radio1 = string.Format(financialResponsibility_radio, commonFunctions.financialResponsibility_radio_LabelAndValue.Item2);
                    RadioButton.SelectRadioButton(financialResponsibility_Radio1, true, 1);
                }
            }

            if (commonFunctions.vehicleSharing_radio_LabelAndValue.Item2 != string.Empty)
            {
                if (commonFunctions.vehicleSharing_radio_LabelAndValue.Item2 == "Yes")
                {
                    var vehicleSharing_Radio1 = string.Format(vehicleSharing_radio, commonFunctions.vehicleSharing_radio_LabelAndValue.Item2);
                    RadioButton.SelectRadioButton(vehicleSharing_Radio1, true, 1);
                }
                else
                {
                    var vehicleSharing_Radio1 = string.Format(vehicleSharing_radio, commonFunctions.vehicleSharing_radio_LabelAndValue.Item2);
                    RadioButton.SelectRadioButton(vehicleSharing_Radio1, true, 1);
                }
            }

            if (commonFunctions.residenceType_drp_LabelAndValue.Item2 != string.Empty)
            {
                DropDown.SelectDropDown(residenceType_drp, commonFunctions.residenceType_drp_LabelAndValue.Item2, true, 1);
            }

            if (commonFunctions.ApplicantZip2_LabelAndValue.Item2 != string.Empty)
            {
                InputField.SetTextAreaInputField(ZipCode_Inp2, commonFunctions.ApplicantZip2_LabelAndValue.Item2, true, 1);
            }

            if (commonFunctions.ApplicantPrimaryHomeOwnerPolicyInsured_LabelAndValue.Item2 != string.Empty)
            {
                if (commonFunctions.ApplicantPrimaryHomeOwnerPolicyInsured_LabelAndValue.Item2 == "Yes")
                {
                    var HomeOwnerPolicyInsured = string.Format(PrimaryHomeOwnerPolicyInsured, commonFunctions.ApplicantPrimaryHomeOwnerPolicyInsured_LabelAndValue.Item2);
                    RadioButton.SelectRadioButton(HomeOwnerPolicyInsured, true, 1);
                }
                else
                {
                    var HomeOwnerPolicyInsured = string.Format(PrimaryHomeOwnerPolicyInsured, commonFunctions.ApplicantPrimaryHomeOwnerPolicyInsured_LabelAndValue.Item2);
                    RadioButton.SelectRadioButton(HomeOwnerPolicyInsured, true, 1);
                }
            }

            if (commonFunctions.ApplicantBusinessType_LabelAndValue.Item2 != string.Empty)
            {
                {
                    if (commonFunctions.ApplicantBusinessType_LabelAndValue.Item2 == "Yes")

                    //BC_BUSINESS_TYPE
                    {
                        var BusinessType = string.Format(Business_type_Radio, commonFunctions.ApplicantBusinessType_LabelAndValue.Item2);
                        RadioButton.SelectRadioButton(BusinessType, true, 1);
                    }
                    else
                    {
                        var BusinessType = string.Format(Business_type_Radio, commonFunctions.ApplicantBusinessType_LabelAndValue.Item2);
                        RadioButton.SelectRadioButton(BusinessType, true, 1);
                    }
                }

                if (commonFunctions.Businessdescription_Inp_LabelAndValue.Item2 != string.Empty)
                {
                    InputField.SetTextAreaInputField(Businessdescription_Inp, commonFunctions.Businessdescription_Inp_LabelAndValue.Item2, true, 1);
                }
                //BC_BUSINESS_Fuction
                if (commonFunctions.ApplicantBusinessType_LabelAndValue.Item2 != string.Empty)
                {
                    if (commonFunctions.ApplicantBusinessFunction_LabelAndValue.Item2 == "Yes")
                    {
                        var BusinessFunction = string.Format(Business_Function_Radio, commonFunctions.ApplicantBusinessFunction_LabelAndValue.Item2);
                        RadioButton.SelectRadioButton(BusinessFunction, true, 1);
                    }
                    else
                    {
                        var BusinessFunction = string.Format(Business_Function_Radio, commonFunctions.ApplicantBusinessFunction_LabelAndValue.Item2);
                        RadioButton.SelectRadioButton(BusinessFunction, true, 1);
                    }
                }

                if (commonFunctions.ApplicantInsuranceinforce_LabelAndValue.Item2 != string.Empty)
                {
                    if (commonFunctions.ApplicantInsuranceinforce_LabelAndValue.Item2 == "Yes")
                    {
                        var Insuranceinforce1 = string.Format(Insuranceinforce, commonFunctions.ApplicantInsuranceinforce_LabelAndValue.Item2);
                        RadioButton.SelectRadioButton(Insuranceinforce1, true, 1);
                    }
                    else
                    {
                        var Insuranceinforce1 = string.Format(Insuranceinforce, commonFunctions.ApplicantInsuranceinforce_LabelAndValue.Item2);
                        RadioButton.SelectRadioButton(Insuranceinforce1, true, 1);
                    }
                }

                if (commonFunctions.ApplicantinfoBusinessEndeavorBankruptcy_LabelAndValue.Item2 != string.Empty)
                {
                    if (commonFunctions.ApplicantinfoBusinessEndeavorBankruptcy_LabelAndValue.Item2 == "Yes")
                    {
                       var infoBusinessEndeavorBankruptcy = string.Format(infoBusinessEndeavorBankruptcy_Radio, commonFunctions.ApplicantinfoBusinessEndeavorBankruptcy_LabelAndValue.Item2);
                        RadioButton.SelectRadioButton(infoBusinessEndeavorBankruptcy, true, 1);
                    }
                    else
                    {
                        var infoBusinessEndeavorBankruptcy = string.Format(infoBusinessEndeavorBankruptcy_Radio, commonFunctions.ApplicantinfoBusinessEndeavorBankruptcy_LabelAndValue.Item2);
                        RadioButton.SelectRadioButton(infoBusinessEndeavorBankruptcy, true, 1);
                    }
                }

                if (commonFunctions.ApplicantinfoToolsEquipment_LabelAndValue.Item2 != string.Empty)
                {
                    if (commonFunctions.ApplicantinfoToolsEquipment_LabelAndValue.Item2 == "Yes")
                    {
                        var infoToolsEquipment = string.Format(infoToolsEquipment_Radio, commonFunctions.ApplicantinfoToolsEquipment_LabelAndValue.Item2);
                        RadioButton.SelectRadioButton(infoToolsEquipment, true, 1);
                    }
                    else
                    {
                        var infoToolsEquipment = string.Format(infoToolsEquipment_Radio, commonFunctions.ApplicantinfoToolsEquipment_LabelAndValue.Item2);
                        RadioButton.SelectRadioButton(infoToolsEquipment, true, 1);
                    }
                }

                if (commonFunctions.ApplicantinfoCanceledRefusedCoverage_LabelAndValue.Item2 != string.Empty)
                {
                    if (commonFunctions.ApplicantinfoCanceledRefusedCoverage_LabelAndValue.Item2 == "Yes")
                    {
                        var infoCanceledRefusedCoverage = string.Format(infoCanceledRefusedCoverage_Radio, commonFunctions.ApplicantinfoCanceledRefusedCoverage_LabelAndValue.Item2);
                        RadioButton.SelectRadioButton(infoCanceledRefusedCoverage, true, 1);
                    }
                    else
                    {
                        var infoCanceledRefusedCoverage = string.Format(infoCanceledRefusedCoverage_Radio, commonFunctions.ApplicantinfoCanceledRefusedCoverage_LabelAndValue.Item2);
                        RadioButton.SelectRadioButton(infoCanceledRefusedCoverage, true, 1);
                    }
                }
            }

            Button.ClickButton(Continue_btn, ActionType.Click, true, 1);
            commonFunctions.UserWaitForPageToLoadCompletly();
        }
        #endregion

        #region Worker Comp Applicant Info fill
        public async Task WorkersCompApplicantDatafillAsync()
        {
            commonFunctions.ReadTestDataForApplicantPage();
            //commonFunctions.UserWaitForPageToLoadCompletly();
            DropDown.SelectDropDown(QuoteType_Drp, commonFunctions.ApplicantQuoteType_LabelAndValue.Item2, true, 1);
            //Thread.Sleep(3000);
            commonFunctions.WaitForOverlayToDisappear(Driver.InnerDriver);
            /*By overlaySelector = By.CssSelector("div.blockUI.blockOverlay");
            commonFunctions.WaitUntilInvisible(Driver.InnerDriver, overlaySelector, 30);*/
            InputField.SetTextAreaInputField(QuoteDescription_Inp, commonFunctions.ApplicantQuoteDescription_LabelAndValue.Item2, true, 1);
            InputField.SetTextAreaInputField(EffectiveDate_Inp, DateTime.Now.AddDays(Convert.ToInt32(commonFunctions.ApplicantEffectiveDate_LabelAndValue.Item2)).ToString("MM/dd/yyyy"), true, 1);
            InputField.SetTextAreaInputField(BookCode_Inp, commonFunctions.ApplicantBookBusiness_LabelAndValue.Item2, true, 1);
            try
            {
                DropDown.SelectDropDown(Producer_Drp, commonFunctions.ApplicantBookProducer_LabelAndValue.Item2, true, 1);
            }
            catch (StaleElementReferenceException ex)
            {
                DropDown.SelectDropDown(Producer_Drp, commonFunctions.ApplicantBookProducer_LabelAndValue.Item2, true, 1);
            }
            //DropDown.SelectDropDown(Office_Drp, commonFunctions.ApplicantOffice_LabelAndValue.Item2, true, 1);
            if (commonFunctions.PolicyType_LabelAndValue.Item2 != string.Empty)
            {
                DropDown.SelectDropDown(PolicyType_DropDown, commonFunctions.PolicyType_LabelAndValue.Item2, true, 1);
            }

            if (commonFunctions.QuoteNumber_LabelAndValue.Item2 != string.Empty)
            {
                InputField.SetTextAreaInputField(QuoteNumber_Input, commonFunctions.QuoteNumber_LabelAndValue.Item2, true, 1);
            }

            if (commonFunctions.AddAnotherNamedInsured_LabelAndValue.Item2 != string.Empty)
            {
                await Task.Delay(3000);
                commonFunctions.WaitForOverlayToDisappear(Driver);
                Button.ScrollIntoView(AddanotherNamedInsured_Input, true, 1);
                _driverWait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(AddanotherNamedInsured_Input)));
                TextLink.ClickTextLink(AddanotherNamedInsured_Input, true, 1);
            }

            _driverWait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(NamedInsured_FirstName_Inp)));
            InputField.SetTextAreaInputField(NamedInsured_FirstName_Inp, commonFunctions.ApplicantFirstName_LabelAndValue.Item2, true, 1);
            InputField.SetTextAreaInputField(NamedInsured_LastName_Inp, commonFunctions.ApplicantLastName_LabelAndValue.Item2, true, 1);
            InputField.SetTextAreaInputField(NamedInsured_SSN_Inp, commonFunctions.ApplicantSSN_LabelAndValue.Item2, true, 1);
            InputField.SetTextAreaInputField(NamedInsured_DOB_Inp, commonFunctions.ApplicantDOB1_LabelAndValue.Item2, true, 1);
            InputField.SetTextAreaInputField(NamedInsured_Email_Inp, commonFunctions.ApplicantEmail_LabelAndValue.Item2, true, 1);
            InputField.SetTextAreaInputField(Phone_Inp, commonFunctions.ApplicantPhone_LabelAndValue.Item2, true, 1);
            InputField.SetTextAreaInputField(FEIN_Input, commonFunctions.FEIN_LabelAndValue.Item2, true, 1);
            InputField.SetTextAreaInputField(Description_Input, commonFunctions.Description_LabelAndValue.Item2, true, 1);
            InputField.SetTextAreaInputField(AddressLine1_Inp, commonFunctions.ApplicantAddress1_LabelAndValue.Item2, true, 1);
            InputField.SetTextAreaInputField(City_Inp, commonFunctions.ApplicantCity_LabelAndValue.Item2, true, 1);
            DropDown.SelectDropDown(State_Drp1, commonFunctions.ApplicantState_LabelAndValue.Item2, true, 1);
            InputField.SetTextAreaInputField(ZipCode_Inp1, commonFunctions.ApplicantZip1_LabelAndValue.Item2, true, 1);
            InputField.SetTextAreaInputField(ContactInfo_Name_Input, commonFunctions.ContactInfo_Name_LabelAndValue.Item2, true, 1);
            InputField.SetTextAreaInputField(ContactInfo_OfficePhone_Input, commonFunctions.ContactInfo_OfficePhone_LabelAndValue.Item2, true, 1);
            InputField.SetTextAreaInputField(ContactInfo_MobilePhone_Input, commonFunctions.ContactInfo_MobilePhone_LabelAndValue.Item2, true, 1);
            InputField.SetTextAreaInputField(ContactInfo_Email_Input, commonFunctions.ContactInfo_Email_LabelAndValue.Item2, true, 1);
            commonFunctions.UserWaitForPageToLoadCompletly();
        }
        #endregion

        #region Worker Comp Underwriting Info fill
        public async Task WorkersCompUnderwritngInfofillAsync()
        {
            commonFunctions.ReadTestDataForApplicantPage();
            commonFunctions.UserWaitForPageToLoadCompletly();
            //commonFunctions.WaitForOverlayToDisappear(Driver);
            Button.ScrollIntoView(UnderwritingInformationTab_Button, true, 1);
            _driverWait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(UnderwritingInformationTab_Button)));
            Button.ClickButton(UnderwritingInformationTab_Button, ActionType.Click, true, 1);
            commonFunctions.WaitForOverlayToDisappear(Driver);
            //Below xpaths are for no radios only
            RadioButton.SelectRadioButton(SupportingContractClasses_Radio, true, 1);
            RadioButton.SelectRadioButton(Aircraft_Radio, true, 1);
            RadioButton.SelectRadioButton(HazardousMaterial_Radio, true, 1);
            RadioButton.SelectRadioButton(Underground_Radio, true, 1);
            RadioButton.SelectRadioButton(BargesBridges_Radio, true, 1);
            RadioButton.SelectRadioButton(OtherBusiness_Radio, true, 1);
            RadioButton.SelectRadioButton(SafetyProgram_Radio, true, 1);
            RadioButton.SelectRadioButton(EmployeesUnder16_Radio, true, 1);
            RadioButton.SelectRadioButton(Seasonal_Radio, true, 1);
            RadioButton.SelectRadioButton(VolunteerLabor_Radio, true, 1);
            RadioButton.SelectRadioButton(PhysicalHandicaps_Radio, true, 1);
            RadioButton.SelectRadioButton(TravelOutOfState_Radio, true, 1);
            RadioButton.SelectRadioButton(AthleticTeams_Radio, true, 1);
            RadioButton.SelectRadioButton(PhysicalsRequired_Radio, true, 1);
            RadioButton.SelectRadioButton(OtherInsurance_Radio, true, 1);
            RadioButton.SelectRadioButton(CoverageCancelled_Radio, true, 1);
            RadioButton.SelectRadioButton(HealthPlans_Radio, true, 1);
            RadioButton.SelectRadioButton(OtherBusinesses_Radio, true, 1);
            RadioButton.SelectRadioButton(LeaseEmployees_Radio, true, 1);
            RadioButton.SelectRadioButton(WorkAtHome_Radio, true, 1);
            DropDown.SelectDropDown(ContinuousWCcov_Select, commonFunctions.ContinuousWCcov_LabelAndValue.Item2, true, 1);
            RadioButton.SelectRadioButton(Bankruptcy_Radio, true, 1);
            RadioButton.SelectRadioButton(UndisputedPremium_Radio, true, 1);
            RadioButton.SelectRadioButton(Website_Radio, true, 1);
            commonFunctions.UserWaitForPageToLoadCompletly();
        }
        #endregion

        #region Commercial Umbrella Info Fill
        public async Task CommercialUmbrellaApplicantDatafill()
        {
            commonFunctions.ReadTestDataForApplicantPage();
            commonFunctions.ReadTestDataForUmbrellaBindPage();
            commonFunctions.UserWaitForPageToLoadCompletly();
            //DropDown.SelectDropDown(QuoteType_Drp, commonFunctions.ApplicantQuoteType_LabelAndValue.Item2, true, 1);
            InputField.SetTextAreaInputField(QuoteDescription_Inp, commonFunctions.ApplicantQuoteDescription_LabelAndValue.Item2, true, 1);
            InputField.SetTextAreaInputField(EffectiveDate_Inp, DateTime.Now.AddDays(Convert.ToInt32(commonFunctions.ApplicantEffectiveDate_LabelAndValue.Item2)).ToString("MM/dd/yyyy"), true, 1);
            InputField.SetTextAreaInputField(BookCode_Inp, commonFunctions.ApplicantBookBusiness_LabelAndValue.Item2, true, 1);
            DropDown.SelectDropDown(Producer_Drp, commonFunctions.ApplicantBookProducer_LabelAndValue.Item2, true, 1);
            /*InputField.SetTextAreaInputField(NamedInsured_FirstName_Inp, commonFunctions.ApplicantFirstName_LabelAndValue.Item2, true, 1);
            InputField.SetTextAreaInputField(NamedInsured_LastName_Inp, commonFunctions.ApplicantLastName_LabelAndValue.Item2, true, 1);
            InputField.SetTextAreaInputField(NamedInsured_SSN_Inp, commonFunctions.ApplicantSSN_LabelAndValue.Item2, true, 1);
            InputField.SetTextAreaInputField(NamedInsured_DOB_Inp, commonFunctions.ApplicantDOB_LabelAndValue.Item2, true, 1);
            InputField.SetTextAreaInputField(NamedInsured_Email_Inp, commonFunctions.ApplicantEmail_LabelAndValue.Item2, true, 1);
            InputField.SetTextAreaInputField(Phone_Inp, commonFunctions.ApplicantPhone_LabelAndValue.Item2, true, 1);
            InputField.SetTextAreaInputField(AddressLine1_Inp, commonFunctions.ApplicantAddress1_LabelAndValue.Item2, true, 1);
            InputField.SetTextAreaInputField(City_Inp, commonFunctions.ApplicantCity_LabelAndValue.Item2, true, 1);
            DropDown.SelectDropDown(State_Drp1, commonFunctions.ApplicantState_LabelAndValue.Item2, true, 1);
            InputField.SetTextAreaInputField(ZipCode_Inp1, commonFunctions.ApplicantZip1_LabelAndValue.Item2, true, 1);*/
            // For dropdowns
            DropDown.SelectDropDown(UmbrellaEachOcc_DropDown, commonFunctions.UmbrellaEachOcc_LabelAndValue.Item2, true, 1);

            // For input fields (radio-like, but by ID and not type='radio')
            RadioButton.SelectRadioButton(string.Format(ClaimsLosses_Radio, commonFunctions.ClaimsLosses_LabelAndValue.Item2), true, 1);
            //InputField.SetTextAreaInputField(NoClaimsLosses_Input, commonFunctions.NoClaimsLosses_LabelAndValue.Item2, true, 1);

            // For button
            //Button.ClickButton(AttributesSubmit_Button, ActionType.Click, true, 1);

            // For links
            TextLink.ClickTextLink(Billing_Link, true, 1);
            commonFunctions.UserWaitForPageToLoadCompletly();
            Thread.Sleep(5000); // Wait for the Billing page to load
            // For input fields
            RadioButton.SelectRadioButton(string.Format(NoBillingUnearnedPremium_Input, commonFunctions.NoBillingUnearnedPremium_LabelAndValue.Item2), true, 1);
            Button.ClickButton(PaymentPlan_Input, ActionType.Click, true, 1);

            // For Bind section
            TextLink.ClickTextLink(Bind_Link, true, 1);
            commonFunctions.UserWaitForPageToLoadCompletly();
            await Task.Delay(3000);
            InputField.SetTextAreaInputField(AgentEmail_Input, commonFunctions.AgentEmail_LabelAndValue.Item2, true, 1);
            RadioButton.SelectRadioButton(string.Format(BindingDestinationEmail1_Input, commonFunctions.BindingDestinationEmail1_LabelAndValue.Item2), true, 1);
            if (commonFunctions.BindingAgreeToTerms_LabelAndValue.Item2 != string.Empty)
            {
                Checkbox.SelectCheckbox(BindingAgreeToTerms_Input, true, true, 1);
            }

            // For sub-tabs (if these are clickable)
            TextLink.ClickTextLink(AttachDocuments_SubTab, true, 1);
            commonFunctions.UserWaitForPageToLoadCompletly();
            await Task.Delay(3000);
            TextLink.ClickTextLink(BindingInformation_SubTab, true, 1);
            commonFunctions.UserWaitForPageToLoadCompletly();
            await Task.Delay(3000);
            // For Save
            TextLink.ClickTextLink(Save_Link, true, 1);
        }
        #endregion

        #region HomeOwners
        public async Task HomeOwnersApplicantDatafillAsync()
        {
            commonFunctions.ReadTestDataForApplicantPage();
            commonFunctions.UserWaitForPageToLoadCompletly();
            DropDown.SelectDropDown(QuoteType_Drp, commonFunctions.ApplicantQuoteType_LabelAndValue.Item2, true, 1);
            InputField.SetTextAreaInputField(QuoteDescription_Inp, commonFunctions.ApplicantQuoteDescription_LabelAndValue.Item2, true, 1);
            //InputField.SetTextAreaInputField(EffectiveDate_Inp, commonFunctions.ApplicantEffectiveDate_LabelAndValue.Item2, true, 1);
            InputField.SetTextAreaInputField(EffectiveDate_Inp, DateTime.Now.AddDays(Convert.ToInt32(commonFunctions.ApplicantEffectiveDate_LabelAndValue.Item2)).ToString("MM/dd/yyyy"), true, 1);

            if (commonFunctions.ApplicantQuoteRollOver_LabelAndValue.Item2 == "Yes")
            {
                var QuoteRollOver = string.Format(QuoteRollOver_Radio, commonFunctions.ApplicantQuoteRollOver_LabelAndValue.Item2);
                RadioButton.SelectRadioButton(QuoteRollOver, true, 1);
            }
            else
            {
                var QuoteRollOver = string.Format(QuoteRollOver_Radio, commonFunctions.ApplicantQuoteRollOver_LabelAndValue.Item2);
                RadioButton.SelectRadioButton(QuoteRollOver, true, 1);
            }

            InputField.SetTextAreaInputField(BookCode_Inp, commonFunctions.ApplicantBookBusiness_LabelAndValue.Item2, true, 1);
            DropDown.SelectDropDown(Producer_Drp, commonFunctions.ApplicantBookProducer_LabelAndValue.Item2, true, 1);
            InputField.SetTextAreaInputField(NamedInsured_FirstName_Inp, commonFunctions.ApplicantFirstName_LabelAndValue.Item2, true, 1);
            InputField.SetTextAreaInputField(NamedInsured_LastName_Inp, commonFunctions.ApplicantLastName_LabelAndValue.Item2, true, 1);
            InputField.SetTextAreaInputField(NamedInsured_SSN_Inp, commonFunctions.ApplicantSSN_LabelAndValue.Item2, true, 1);
            InputField.SetTextAreaInputField(NamedInsured_DOB_Inp, commonFunctions.ApplicantDOB1_LabelAndValue.Item2, true, 1);
            InputField.SetTextAreaInputField(FirstName_Input, commonFunctions.FirstName_LabelAndValue.Item2, true, 1);
            InputField.SetTextAreaInputField(LastName_Input, commonFunctions.LastName_LabelAndValue.Item2, true, 1);
            InputField.SetTextAreaInputField(SocialSecurityNumber_Input, commonFunctions.SocialSecurityNumber_LabelAndValue.Item2, true, 1);
            InputField.SetTextAreaInputField(DateOfBirth_Input, commonFunctions.DateOfBirth_LabelAndValue.Item2, true, 1);
            //DropDown.SelectDropDown(NumberYears_DropDown, commonFunctions.NumberYears_LabelAndValue.Item2, true, 1);
            //InputField.SetTextAreaInputField(NamedInsured_Email_Inp, commonFunctions.ApplicantEmail_LabelAndValue.Item2, true, 1);
            //InputField.SetTextAreaInputField(Phone_Inp, commonFunctions.ApplicantPhone_LabelAndValue.Item2, true, 1);
            InputField.SetTextAreaInputField(AddressLine1_Inp, commonFunctions.ApplicantAddress1_LabelAndValue.Item2, true, 1);
            InputField.SetTextAreaInputField(City_Inp, commonFunctions.ApplicantCity_LabelAndValue.Item2, true, 1);
            //DropDown.SelectDropDown(State_Drp1, commonFunctions.ApplicantState_LabelAndValue.Item2, true, 1);
            InputField.SetTextAreaInputField(ZipCode_Inp1, commonFunctions.ApplicantZip1_LabelAndValue.Item2, true, 1);
            // Button.ClickButton(NumberYears_DropDown, ActionType.Click, true, 1);
            //New
            /*if (commonFunctions.ApplicantIsThisMailingAddress1_LabelAndValue.Item2 != string.Empty)
            {
                if (commonFunctions.ApplicantIsThisMailingAddress1_LabelAndValue.Item2 == "Yes")
                {
                    string MailingAddress = string.Format(isMailingAddress_Radio, commonFunctions.ApplicantIsThisMailingAddress1_LabelAndValue.Item2);
                    RadioButton.SelectRadioButton(MailingAddress, true, 1);
                }
                else
                {
                    string MailingAddress = string.Format(isMailingAddress_Radio, commonFunctions.ApplicantIsThisMailingAddress1_LabelAndValue.Item2);
                    RadioButton.SelectRadioButton(MailingAddress, true, 1);
                }
            }*/
            //Button.ScrollIntoView(NumberYears_DropDown, true, 1);
            DropDown.SelectDropDown(NumberYears_DropDown, commonFunctions.NumberYears_LabelAndValue.Item2, true, 1);
            if (commonFunctions.ResidenceType1_LabelAndValue.Item2 != string.Empty)
            {
                RadioButton.SelectRadioButton(ResidenceType1_Radio, true, 1);
            }

            if (commonFunctions.ResidenceType2_LabelAndValue.Item2 != string.Empty)
            {
                RadioButton.SelectRadioButton(ResidenceType2_Radio, true, 1);
            }

            if (commonFunctions.ResidenceType3_LabelAndValue.Item2 != string.Empty)
            {
                RadioButton.SelectRadioButton(ResidenceType3_Radio, true, 1);
            }

            if (commonFunctions.ResidenceType4_LabelAndValue.Item2 != string.Empty)
            {
                RadioButton.SelectRadioButton(ResidenceType4_Radio, true, 1);
            }

            if (commonFunctions.UseEstimator_LabelAndValue.Item2 == "Yes")
            {
                RadioButton.SelectRadioButton(YesUseEstimator_Radio, true, 1);
            }

            if (commonFunctions.UseEstimator_LabelAndValue.Item2 == "No")
            {
                RadioButton.SelectRadioButton(NoUseEstimator_Radio, true, 1);
            }

            if (commonFunctions.TerritoryOverride_LabelAndValue.Item2 != string.Empty)
            {
                InputField.SetTextAreaInputField(TerritoryOverride_Inp, commonFunctions.TerritoryOverride_LabelAndValue.Item2, true, 1);
            }

            Button.ClickButton(ContinueButton, ActionType.Click, true, 1);
            commonFunctions.UserWaitForPageToLoadCompletly();
        }
        #endregion
        /* Button.ClickButton(ContinueButton, ActionType.Click, true, 1);
         Thread.Sleep(5000);*/
        //Button.ClickButton(NextButton, ActionType.Click, true, 1);
        //commonFunctions.UserWaitForPageToLoadCompletly();
        #region HomeOwners
        public async Task HomeOwnersApplicantDatafill1Async()
        {
            commonFunctions.ReadTestDataForApplicantPage();
            commonFunctions.UserWaitForPageToLoadCompletly();
            DropDown.SelectDropDown(QuoteType_Drp, commonFunctions.ApplicantQuoteType_LabelAndValue.Item2, true, 1);
            InputField.SetTextAreaInputField(QuoteDescription_Inp, commonFunctions.ApplicantQuoteDescription_LabelAndValue.Item2, true, 1);
            //InputField.SetTextAreaInputField(EffectiveDate_Inp, commonFunctions.ApplicantEffectiveDate_LabelAndValue.Item2, true, 1);
            InputField.SetTextAreaInputField(EffectiveDate_Inp, DateTime.Now.AddDays(Convert.ToInt32(commonFunctions.ApplicantEffectiveDate_LabelAndValue.Item2)).ToString("MM/dd/yyyy"), true, 1);

            if (commonFunctions.ApplicantQuoteRollOver_LabelAndValue.Item2 == "Yes")
            {
                var QuoteRollOver = string.Format(QuoteRollOver_Radio, commonFunctions.ApplicantQuoteRollOver_LabelAndValue.Item2);
                RadioButton.SelectRadioButton(QuoteRollOver, true, 1);
            }
            else
            {
                var QuoteRollOver = string.Format(QuoteRollOver_Radio, commonFunctions.ApplicantQuoteRollOver_LabelAndValue.Item2);
                RadioButton.SelectRadioButton(QuoteRollOver, true, 1);
            }

            InputField.SetTextAreaInputField(BookCode_Inp, commonFunctions.ApplicantBookBusiness_LabelAndValue.Item2, true, 1);
            DropDown.SelectDropDown(Producer_Drp, commonFunctions.ApplicantBookProducer_LabelAndValue.Item2, true, 1);
            InputField.SetTextAreaInputField(NamedInsured_FirstName_Inp, commonFunctions.ApplicantFirstName_LabelAndValue.Item2, true, 1);
            InputField.SetTextAreaInputField(NamedInsured_LastName_Inp, commonFunctions.ApplicantLastName_LabelAndValue.Item2, true, 1);
            InputField.SetTextAreaInputField(NamedInsured_SSN_Inp, commonFunctions.ApplicantSSN_LabelAndValue.Item2, true, 1);
            InputField.SetTextAreaInputField(NamedInsured_DOB_Inp, commonFunctions.ApplicantDOB1_LabelAndValue.Item2, true, 1);
            InputField.SetTextAreaInputField(FirstName_Input, commonFunctions.FirstName_LabelAndValue.Item2, true, 1);
            InputField.SetTextAreaInputField(LastName_Input, commonFunctions.LastName_LabelAndValue.Item2, true, 1);
            InputField.SetTextAreaInputField(SocialSecurityNumber_Input, commonFunctions.SocialSecurityNumber_LabelAndValue.Item2, true, 1);
            InputField.SetTextAreaInputField(DateOfBirth_Input, commonFunctions.DateOfBirth_LabelAndValue.Item2, true, 1);
            DropDown.SelectDropDown(NumberYears_DropDown, commonFunctions.NumberYears_LabelAndValue.Item2, true, 1);
            //InputField.SetTextAreaInputField(NamedInsured_Email_Inp, commonFunctions.ApplicantEmail_LabelAndValue.Item2, true, 1);
            //InputField.SetTextAreaInputField(Phone_Inp, commonFunctions.ApplicantPhone_LabelAndValue.Item2, true, 1);
            InputField.SetTextAreaInputField(AddressLine1_Inp, commonFunctions.ApplicantAddress1_LabelAndValue.Item2, true, 1);
            InputField.SetTextAreaInputField(City_Inp, commonFunctions.ApplicantCity_LabelAndValue.Item2, true, 1);
            //DropDown.SelectDropDown(State_Drp1, commonFunctions.ApplicantState_LabelAndValue.Item2, true, 1);
            InputField.SetTextAreaInputField(ZipCode_Inp1, commonFunctions.ApplicantZip1_LabelAndValue.Item2, true, 1);
            //Thread.Sleep(40000);
            await Task.Delay(1000);

            Button.ClickButton(AddressError_close, ActionType.Click, true, 1);
            await Task.Delay(1000);
            if (commonFunctions.ResidenceType1_LabelAndValue.Item2 != string.Empty)
            {
                RadioButton.SelectRadioButton(ResidenceType1_Radio, true, 1);
            }

            if (commonFunctions.ResidenceType2_LabelAndValue.Item2 != string.Empty)
            {
                RadioButton.SelectRadioButton(ResidenceType2_Radio, true, 1);
            }

            if (commonFunctions.ResidenceType3_LabelAndValue.Item2 != string.Empty)
            {
                RadioButton.SelectRadioButton(ResidenceType3_Radio, true, 1);
            }

            if (commonFunctions.ResidenceType4_LabelAndValue.Item2 != string.Empty)
            {
                RadioButton.SelectRadioButton(ResidenceType4_Radio, true, 1);
            }

            if (commonFunctions.UseEstimator_LabelAndValue.Item2 == "Yes")
            {
                RadioButton.SelectRadioButton(YesUseEstimator_Radio, true, 1);
            }

            if (commonFunctions.UseEstimator_LabelAndValue.Item2 == "No")
            {
                RadioButton.SelectRadioButton(NoUseEstimator_Radio, true, 1);
            }

            if (commonFunctions.TerritoryOverride_LabelAndValue.Item2 != string.Empty)
            {
                InputField.SetTextAreaInputField(TerritoryOverride_Inp, commonFunctions.TerritoryOverride_LabelAndValue.Item2, true, 1);
            }

            Button.ClickButton(ContinueButton, ActionType.Click, true, 1);
            commonFunctions.UserWaitForPageToLoadCompletly();
        }
        #endregion

        /* Button.ClickButton(ContinueButton, ActionType.Click, true, 1);
         Thread.Sleep(5000);*/
        //Button.ClickButton(NextButton, ActionType.Click, true, 1);
        //commonFunctions.UserWaitForPageToLoadCompletly();
    }
}
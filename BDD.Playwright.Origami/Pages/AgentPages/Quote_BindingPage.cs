//using BDD.Playwright.GBIZ.PageElements;
//using BDD.Playwright.Origami.Pages.CommonPage;
//using Reqnroll;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace BDD.Playwright.GBIZ.Pages.AgentPages
//{
//    public class Quote_BindingPage : BasePage
//    {
//        private CommonFunctions _commonFunctions;
//        private readonly ScenarioContext _scenarioContext;
//        public FeatureContext _featureContext;
//        public CommonXpath _commonXpath;
//        private readonly IReqnrollOutputHelper _ReqnrollLogger;
//        public LoginPage _loginPage;
//        // Constructor
//        public Quote_BindingPage(ScenarioContext scenarioContext, CommonFunctions commonFunctions, IReqnrollOutputHelper ReqnrollOutputHelper, LoginPage loginPage, CommonXpath commonXpath) : base(scenarioContext)
//        {
//            _scenarioContext = scenarioContext;
//            _commonFunctions = commonFunctions;
//            _ReqnrollLogger = ReqnrollOutputHelper;
//            _loginPage = loginPage;
//            _commonXpath = commonXpath;
//        }
//        #region Xpath
//        public string Office_Drp { get; set; } = "//select[@name='binding_office']";
//        public string Producer_Drp { get; set; } = "//select[@name='binding_producer']";
//        public string AgentEmail { get; set; } = "//input[@name='agentEmail']";
//        public string InsuranceTransferredAgency { get; set; } = "//input[@name='insuranceTransferred' and @value='{0}']";
//        public string CoverageDeclined { get; set; } = "//input[@name='coverageDeclined' and @value='{0}']";
//        public string ApplicantConvictedArson { get; set; } = "//input[@name='applicantConvictedArson' and @value='{0}']";
//        public string BindingDestinationemail { get; set; } = "//input[@name='binding_destinationemail' and @value='{0}']";
//        public string Remarks { get; set; } = "//textarea[@name='binding_remarks']";
//        public string CoverageBound { get; set; } = "//input[@name='binding_iscoveragebound' and @value='{0}']";
//        public string AgreeTerms { get; set; } = "//input[@name='binding_agreetoterms']";

//        #endregion
//        #region Quote_HomeOwnerBinding
//        public string HO_Phone_Input { get; set; } = "//input[@id='fld_phone']";
//        public string HO_MaritalStatus_DropDown { get; set; } = "//select[@id='fld_maritalStatus']";
//        public string HO_Occupation_DropDown { get; set; } = "//select[@id='fld_occupation']";
//        public string HO_NoYearsCurrentEmployer_Input { get; set; } = "//input[@id='fld_noYearsCurrentEmployer']";
//        public string HO_SecondMaritalStatus_DropDown { get; set; } = "//select[@id='fld_secondmaritalStatus']";
//        public string HO_SecondOccupation_DropDown { get; set; } = "//select[@id='fld_secondoccupation']";
//        public string HO_SecondNoYearsCurrentEmployer_Input { get; set; } = "//input[@id='fld_secondnoYearsCurrentEmployer']";
//        public string HO_AddlInfoPriorInsuranceCarrier_DropDown { get; set; } = "//select[@id='fld_addlinfoPriorInsuranceCarrier']";
//        public string HO_PriorPolicyExpireDate_Input { get; set; } = "//input[@id='fld_priorPolicyExpireDate']";
//        public string HO_NoYearsKnown_Input { get; set; } = "//input[@id='fld_noYearsKnown']";
//        #endregion

//        #region HomeOwner_Radio
//        public string HO_ResidenceEmployees_DropDown { get; set; } = "//input[@name='residenceEmployees' and @value='{0}']";
//        public string HO_HadForeclosure_DropDown { get; set; } = "//input[contains(@id,'hadAForeclosure') and @value='{0}']";
//        public string HO_TaxLien_DropDown { get; set; } = "//input[contains(@id,'taxLien') and @value='{0}']";
//        public string HO_BusinessOnPremises_DropDown { get; set; } = "//input[contains(@id,'haveBusinessOnPremises') and @value='{0}']";
//        public string HO_HasDogs_DropDown { get; set; } = "//input[@name='hasDogs' and @value='{0}']";
//        public string HO_AnimalsOrExoticPets_DropDown { get; set; } = "//input[contains(@id,'animalsOrExoticPets') and @value='{0}']";
//        public string HO_MoreFiveAcres_DropDown { get; set; } = "//input[contains(@id,'moreFiveAcres') and @value='{0}']";
//        public string HO_RecreationalVehicles_DropDown { get; set; } = "//input[contains(@id,'recreationalVehicles') and @value='{0}']";
//        public string HO_HouseForSale_DropDown { get; set; } = "//input[contains(@id,'houseForSale') and @value='{0}']";
//        public string HO_BuildingRenovation_DropDown { get; set; } = "//input[contains(@id,'buildingRenovation') and @value='{0}']";
//        public string HO_UncorrectedFireBuildingViolations_DropDown { get; set; } = "//input[contains(@id,'uncorrectedFireBuildingViolations') and @value='{0}']";
//        public string HO_IsTrampoline_DropDown { get; set; } = "//input[contains(@id,'isTrampoline') and @value='{0}']";
//        public string HO_IsPool_DropDown { get; set; } = "//input[contains(@id,'isPool') and @value='{0}']";
//        public string HO_ZipLine_DropDown { get; set; } = "//input[contains(@id,'zipLine') and @value='{0}']";
//        public string HO_StructureConverted_DropDown { get; set; } = "//input[contains(@id,'structureConverted') and @value='{0}']";
//        public string HO_Is911Address_DropDown { get; set; } = "//input[contains(@id,'is911Address') and @value='{0}']";
//        public string HO_OccupiedDaily_DropDown { get; set; } = "//input[contains(@id,'occupiedDaily') and @value='{0}']";
//        public string HO_SharedProgram_DropDown { get; set; } = "//input[contains(@id,'sharedProgram') and @value='{0}']";
//        public string HO_LogHome_DropDown { get; set; } = "//input[contains(@id,'logHome') and @value='{0}']";
//        public string HO_HistoricRegisteredHome_DropDown { get; set; } = "//input[contains(@id,'historicRegisteredHome') and @value='{0}']";
//        public string HO_DrivingDirections { get; set; } = "//textarea[@id='fld_drivingDirections']";

//        #endregion
//        public async Task BindingDataFillAsync()
//        {
//            commonFunctions.ReadTestDataForBinding();
//            commonFunctions.ScrollUp();
//            DropDown.SelectDropDown(Office_Drp, commonFunctions.BindingOffice_LabelAndValue.Item2, true, 1);
//            DropDown.SelectDropDown(Producer_Drp, commonFunctions.BindingProducer_LabelAndValue.Item2, true, 1);
//            if (commonFunctions.BindingInsuranceTransferredAgency_LabelAndValue.Item2 == "Yes")
//            {
//                var TransferredAgency = string.Format(InsuranceTransferredAgency, commonFunctions.BindingInsuranceTransferredAgency_LabelAndValue.Item2);
//                RadioButton.SelectRadioButton(TransferredAgency, true, 1);
//            }
//            else
//            {
//                var TransferredAgency = string.Format(InsuranceTransferredAgency, commonFunctions.BindingInsuranceTransferredAgency_LabelAndValue.Item2);
//                RadioButton.SelectRadioButton(TransferredAgency, true, 1);
//            }

//            if (commonFunctions.BindingCoverageDeclined_LabelAndValue.Item2 == "Yes")
//            {
//                var CoverageDecline = string.Format(CoverageDeclined, commonFunctions.BindingCoverageDeclined_LabelAndValue.Item2);
//                RadioButton.SelectRadioButton(CoverageDecline, true, 1);
//            }
//            else
//            {
//                var CoverageDecline = string.Format(CoverageDeclined, commonFunctions.BindingCoverageDeclined_LabelAndValue.Item2);
//                RadioButton.SelectRadioButton(CoverageDecline, true, 1);
//            }

//            if (commonFunctions.BindingApplicantConvictedArson_LabelAndValue.Item2 == "Yes")
//            {
//                var CoverageDecline = string.Format(CoverageDeclined, commonFunctions.BindingApplicantConvictedArson_LabelAndValue.Item2);
//                RadioButton.SelectRadioButton(CoverageDecline, true, 1);
//            }
//            else
//            {
//                var ApplicantConvicteArson = string.Format(ApplicantConvictedArson, commonFunctions.BindingApplicantConvictedArson_LabelAndValue.Item2);
//                RadioButton.SelectRadioButton(ApplicantConvicteArson, true, 1);
//            }

//            if (commonFunctions.BindingBindingDestinationemail_LabelAndValue.Item2 != string.Empty)
//            {
//                if (commonFunctions.BindingBindingDestinationemail_LabelAndValue.Item2 == "Agent")
//                {
//                    var Destinationemail = string.Format(BindingDestinationemail, commonFunctions.BindingBindingDestinationemail_LabelAndValue.Item2);
//                    RadioButton.SelectRadioButton(Destinationemail, true, 1);
//                }
//                else
//                {
//                    var Destinationemail = string.Format(BindingDestinationemail, commonFunctions.BindingBindingDestinationemail_LabelAndValue.Item2);
//                    RadioButton.SelectRadioButton(Destinationemail, true, 1);
//                }
//            }

//            InputField.SetTextAreaInputField(Remarks, commonFunctions.BindingRemarks_LabelAndValue.Item2, true, 1);
//            if (commonFunctions.BindingCoverageBound_LabelAndValue.Item2 == "Yes")
//            {
//                var CoverageBound = string.Format(coverageBound, commonFunctions.BindingCoverageBound_LabelAndValue.Item2);
//                RadioButton.SelectRadioButton(CoverageBound, true, 1);
//            }
//            else
//            {
//                var CoverageBound = string.Format(coverageBound, commonFunctions.BindingCoverageBound_LabelAndValue.Item2);
//                RadioButton.SelectRadioButton(CoverageBound, true, 1);
//            }

//            //commonFunctions.ScrollUp();

//            //HomeOwner
//            if (commonFunctions.BindingHOPhone_LabelAndValue.Item2 != string.Empty)
//            {
//                InputField.SetTextAreaInputField(HO_Phone_Input, commonFunctions.BindingHOPhone_LabelAndValue.Item2, true, 1);
//            }

//            if (commonFunctions.BindingHOMaritalStatus_LabelAndValue.Item2 != string.Empty)
//            {
//                DropDown.SelectDropDown(HO_MaritalStatus_DropDown, commonFunctions.BindingHOMaritalStatus_LabelAndValue.Item2, true, 1);
//            }

//            if (commonFunctions.BindingHOOccupation_LabelAndValue.Item2 != string.Empty)
//            {
//                DropDown.SelectDropDown(HO_Occupation_DropDown, commonFunctions.BindingHOOccupation_LabelAndValue.Item2, true, 1);
//            }

//            if (commonFunctions.BindingHONoYearsCurrentEmployer_LabelAndValue.Item2 != string.Empty)
//            {
//                InputField.SetTextAreaInputField(HO_NoYearsCurrentEmployer_Input, commonFunctions.BindingHONoYearsCurrentEmployer_LabelAndValue.Item2, true, 1);
//            }

//            if (commonFunctions.BindingHOSecondMaritalStatus_LabelAndValue.Item2 != string.Empty)
//            {
//                DropDown.SelectDropDown(HO_SecondMaritalStatus_DropDown, commonFunctions.BindingHOSecondMaritalStatus_LabelAndValue.Item2, true, 1);
//            }

//            if (commonFunctions.BindingHOSecondOccupations_LabelAndValue.Item2 != string.Empty)
//            {
//                DropDown.SelectDropDown(HO_SecondOccupation_DropDown, commonFunctions.BindingHOSecondOccupations_LabelAndValue.Item2, true, 1);
//            }

//            if (commonFunctions.BindingHOSecondNoYearsCurrentEmployer_LabelAndValue.Item2 != string.Empty)
//            {
//                InputField.SetTextAreaInputField(HO_SecondNoYearsCurrentEmployer_Input, commonFunctions.BindingHOSecondNoYearsCurrentEmployer_LabelAndValue.Item2, true, 1);
//            }

//            if (commonFunctions.BindingHOAddlInfoPriorInsuranceCarrier_LabelAndValue.Item2 != string.Empty)
//            {
//                DropDown.SelectDropDown(HO_AddlInfoPriorInsuranceCarrier_DropDown, commonFunctions.BindingHOAddlInfoPriorInsuranceCarrier_LabelAndValue.Item2, true, 1);
//            }

//            if (commonFunctions.BindingHOPriorPolicyExpireDate_LabelAndValue.Item2 != string.Empty)
//            {
//                InputField.SetTextAreaInputField(HO_PriorPolicyExpireDate_Input, commonFunctions.BindingHOPriorPolicyExpireDate_LabelAndValue.Item2, true, 1);
//            }

//            if (commonFunctions.BindingHONoYearsKnown_LabelAndValue.Item2 != string.Empty)
//            {
//                InputField.SetTextAreaInputField(HO_NoYearsKnown_Input, commonFunctions.BindingHONoYearsKnown_LabelAndValue.Item2, true, 1);
//            }
//            //HomeOwner_Radio
//            if (commonFunctions.HO_ResidenceEmployees_LabelAndValue.Item2 != string.Empty)
//            {

//                if (commonFunctions.HO_ResidenceEmployees_LabelAndValue.Item2 == "Yes")
//                {
//                    var HO_ResidenceEmployees = string.Format(HO_ResidenceEmployees_DropDown, commonFunctions.HO_ResidenceEmployees_LabelAndValue.Item2);
//                    RadioButton.SelectRadioButton(HO_ResidenceEmployees, true, 1);
//                }
//                else
//                {
//                    var HO_ResidenceEmployees = string.Format(HO_ResidenceEmployees_DropDown, commonFunctions.HO_ResidenceEmployees_LabelAndValue.Item2);
//                    RadioButton.SelectRadioButton(HO_ResidenceEmployees, true, 1);
//                }
//            }

//            if (commonFunctions.HO_HadForeclosure_LabelAndValue.Item2 != string.Empty)
//            {

//                if (commonFunctions.HO_HadForeclosure_LabelAndValue.Item2 == "Yes")
//                {
//                    var HO_HadForeclosure = string.Format(HO_HadForeclosure_DropDown, commonFunctions.HO_HadForeclosure_LabelAndValue.Item2);
//                    RadioButton.SelectRadioButton(HO_HadForeclosure, true, 1);
//                }
//                else
//                {
//                    var HO_HadForeclosure = string.Format(HO_HadForeclosure_DropDown, commonFunctions.HO_HadForeclosure_LabelAndValue.Item2);
//                    RadioButton.SelectRadioButton(HO_HadForeclosure, true, 1);
//                }
//            }

//            if (commonFunctions.HO_TaxLien_LabelAndValue.Item2 != string.Empty)
//            {
//                if (commonFunctions.HO_TaxLien_LabelAndValue.Item2 == "Yes")
//                {
//                    var HO_TaxLien = string.Format(HO_TaxLien_DropDown, commonFunctions.HO_TaxLien_LabelAndValue.Item2);
//                    RadioButton.SelectRadioButton(HO_TaxLien, true, 1);
//                }
//                else
//                {
//                    var HO_TaxLien = string.Format(HO_TaxLien_DropDown, commonFunctions.HO_TaxLien_LabelAndValue.Item2);
//                    RadioButton.SelectRadioButton(HO_TaxLien, true, 1);
//                }
//            }

//            if (commonFunctions.HO_BusinessOnPremises_LabelAndValue.Item2 != string.Empty)
//            {
//                if (commonFunctions.HO_BusinessOnPremises_LabelAndValue.Item2 == "Yes")
//                {
//                    var HO_BusinessOnPremises = string.Format(HO_BusinessOnPremises_DropDown, commonFunctions.HO_BusinessOnPremises_LabelAndValue.Item2);
//                    RadioButton.SelectRadioButton(HO_BusinessOnPremises, true, 1);
//                }
//                else
//                {
//                    var HO_BusinessOnPremises = string.Format(HO_BusinessOnPremises_DropDown, commonFunctions.HO_BusinessOnPremises_LabelAndValue.Item2);
//                    RadioButton.SelectRadioButton(HO_BusinessOnPremises, true, 1);
//                }
//            }

//            if (commonFunctions.HO_HasDogs_LabelAndValue.Item2 != string.Empty)
//            {
//                if (commonFunctions.HO_HasDogs_LabelAndValue.Item2 == "Yes")
//                {
//                    var HO_HasDogs = string.Format(HO_HasDogs_DropDown, commonFunctions.HO_HasDogs_LabelAndValue.Item2);
//                    RadioButton.SelectRadioButton(HO_HasDogs, true, 1);
//                }
//                else
//                {
//                    var HO_HasDogs = string.Format(HO_HasDogs_DropDown, commonFunctions.HO_HasDogs_LabelAndValue.Item2);
//                    RadioButton.SelectRadioButton(HO_HasDogs, true, 1);
//                }
//            }

//            if (commonFunctions.HO_AnimalsOrExoticPets_LabelAndValue.Item2 != string.Empty)
//            {
//                if (commonFunctions.HO_AnimalsOrExoticPets_LabelAndValue.Item2 == "Yes")
//                {
//                    var HO_AnimalsOrExoticPets = string.Format(HO_AnimalsOrExoticPets_DropDown, commonFunctions.HO_AnimalsOrExoticPets_LabelAndValue.Item2);
//                    RadioButton.SelectRadioButton(HO_AnimalsOrExoticPets, true, 1);
//                }
//                else
//                {
//                    var HO_AnimalsOrExoticPets = string.Format(HO_AnimalsOrExoticPets_DropDown, commonFunctions.HO_AnimalsOrExoticPets_LabelAndValue.Item2);
//                    RadioButton.SelectRadioButton(HO_AnimalsOrExoticPets, true, 1);
//                }
//            }

//            if (commonFunctions.HO_MoreFiveAcres_LabelAndValue.Item2 != string.Empty)
//            {
//                if (commonFunctions.HO_MoreFiveAcres_LabelAndValue.Item2 == "Yes")
//                {
//                    var HO_MoreFiveAcres = string.Format(HO_MoreFiveAcres_DropDown, commonFunctions.HO_MoreFiveAcres_LabelAndValue.Item2);
//                    RadioButton.SelectRadioButton(HO_MoreFiveAcres, true, 1);
//                }
//                else
//                {
//                    var HO_MoreFiveAcres = string.Format(HO_MoreFiveAcres_DropDown, commonFunctions.HO_MoreFiveAcres_LabelAndValue.Item2);
//                    RadioButton.SelectRadioButton(HO_MoreFiveAcres, true, 1);
//                }
//            }

//            if (commonFunctions.HO_RecreationalVehicles_LabelAndValue.Item2 != string.Empty)
//            {
//                if (commonFunctions.HO_RecreationalVehicles_LabelAndValue.Item2 == "Yes")
//                {
//                    var HO_RecreationalVehicles = string.Format(HO_RecreationalVehicles_DropDown, commonFunctions.HO_RecreationalVehicles_LabelAndValue.Item2);
//                    RadioButton.SelectRadioButton(HO_RecreationalVehicles, true, 1);
//                }
//                else
//                {
//                    var HO_RecreationalVehicles = string.Format(HO_RecreationalVehicles_DropDown, commonFunctions.HO_RecreationalVehicles_LabelAndValue.Item2);
//                    RadioButton.SelectRadioButton(HO_RecreationalVehicles, true, 1);
//                }
//            }

//            if (commonFunctions.HO_HouseForSale_LabelAndValue.Item2 != string.Empty)
//            {
//                if (commonFunctions.HO_HouseForSale_LabelAndValue.Item2 == "Yes")
//                {
//                    var HO_HouseForSale = string.Format(HO_HouseForSale_DropDown, commonFunctions.HO_HouseForSale_LabelAndValue.Item2);
//                    RadioButton.SelectRadioButton(HO_HouseForSale, true, 1);
//                }
//                else
//                {
//                    var HO_HouseForSale = string.Format(HO_HouseForSale_DropDown, commonFunctions.HO_HouseForSale_LabelAndValue.Item2);
//                    RadioButton.SelectRadioButton(HO_HouseForSale, true, 1);
//                }
//            }

//            if (commonFunctions.HO_BuildingRenovation_LabelAndValue.Item2 != string.Empty)
//            {
//                if (commonFunctions.HO_BuildingRenovation_LabelAndValue.Item2 == "Yes")
//                {
//                    var HO_BuildingRenovation = string.Format(HO_BuildingRenovation_DropDown, commonFunctions.HO_BuildingRenovation_LabelAndValue.Item2);
//                    RadioButton.SelectRadioButton(HO_BuildingRenovation, true, 1);
//                }
//                else
//                {
//                    var HO_BuildingRenovation = string.Format(HO_BuildingRenovation_DropDown, commonFunctions.HO_BuildingRenovation_LabelAndValue.Item2);
//                    RadioButton.SelectRadioButton(HO_BuildingRenovation, true, 1);
//                }
//            }

//            if (commonFunctions.HO_UncorrectedFireBuildingViolations_LabelAndValue.Item2 != string.Empty)
//            {
//                if (commonFunctions.HO_UncorrectedFireBuildingViolations_LabelAndValue.Item2 == "Yes")
//                {
//                    var HO_UncorrectedFireBuildingViolations = string.Format(HO_UncorrectedFireBuildingViolations_DropDown, commonFunctions.HO_UncorrectedFireBuildingViolations_LabelAndValue.Item2);
//                    RadioButton.SelectRadioButton(HO_UncorrectedFireBuildingViolations, true, 1);
//                }
//                else
//                {
//                    var HO_UncorrectedFireBuildingViolations = string.Format(HO_UncorrectedFireBuildingViolations_DropDown, commonFunctions.HO_UncorrectedFireBuildingViolations_LabelAndValue.Item2);
//                    RadioButton.SelectRadioButton(HO_UncorrectedFireBuildingViolations, true, 1);
//                }
//            }

//            if (commonFunctions.HO_IsTrampoline_LabelAndValue.Item2 != string.Empty)
//            {
//                if (commonFunctions.HO_IsTrampoline_LabelAndValue.Item2 == "Yes")
//                {
//                    var HO_IsTrampoline = string.Format(HO_IsTrampoline_DropDown, commonFunctions.HO_IsTrampoline_LabelAndValue.Item2);
//                    RadioButton.SelectRadioButton(HO_IsTrampoline, true, 1);
//                }
//                else
//                {
//                    var HO_IsTrampoline = string.Format(HO_IsTrampoline_DropDown, commonFunctions.HO_IsTrampoline_LabelAndValue.Item2);
//                    RadioButton.SelectRadioButton(HO_IsTrampoline, true, 1);
//                }
//            }

//            if (commonFunctions.HO_IsPool_LabelAndValue.Item2 != string.Empty)
//            {
//                if (commonFunctions.HO_IsPool_LabelAndValue.Item2 == "Yes")
//                {
//                    var HO_IsPool = string.Format(HO_IsPool_DropDown, commonFunctions.HO_IsPool_LabelAndValue.Item2);
//                    RadioButton.SelectRadioButton(HO_IsPool, true, 1);
//                }
//                else
//                {
//                    var HO_IsPool = string.Format(HO_IsPool_DropDown, commonFunctions.HO_IsPool_LabelAndValue.Item2);
//                    RadioButton.SelectRadioButton(HO_IsPool, true, 1);
//                }
//            }

//            if (commonFunctions.HO_ZipLine_LabelAndValue.Item2 != string.Empty)
//            {
//                if (commonFunctions.HO_ZipLine_LabelAndValue.Item2 == "Yes")
//                {
//                    var HO_ZipLine = string.Format(HO_ZipLine_DropDown, commonFunctions.HO_ZipLine_LabelAndValue.Item2);
//                    RadioButton.SelectRadioButton(HO_ZipLine, true, 1);
//                }
//                else
//                {
//                    var HO_ZipLine = string.Format(HO_ZipLine_DropDown, commonFunctions.HO_ZipLine_LabelAndValue.Item2);
//                    RadioButton.SelectRadioButton(HO_ZipLine, true, 1);
//                }
//            }

//            if (commonFunctions.HO_StructureConverted_LabelAndValue.Item2 != string.Empty)
//            {
//                if (commonFunctions.HO_StructureConverted_LabelAndValue.Item2 == "Yes")
//                {
//                    var HO_StructureConverted = string.Format(HO_StructureConverted_DropDown, commonFunctions.HO_StructureConverted_LabelAndValue.Item2);
//                    RadioButton.SelectRadioButton(HO_StructureConverted, true, 1);
//                }
//                else
//                {
//                    var HO_StructureConverted = string.Format(HO_StructureConverted_DropDown, commonFunctions.HO_StructureConverted_LabelAndValue.Item2);
//                    RadioButton.SelectRadioButton(HO_StructureConverted, true, 1);
//                }
//            }

//            if (commonFunctions.HO_Is911Address_LabelAndValue.Item2 != string.Empty)
//            {
//                if (commonFunctions.HO_Is911Address_LabelAndValue.Item2 == "Yes")
//                {
//                    var HO_Is911Address = string.Format(HO_Is911Address_DropDown, commonFunctions.HO_Is911Address_LabelAndValue.Item2);
//                    RadioButton.SelectRadioButton(HO_Is911Address, true, 1);
//                }
//                else
//                {
//                    var HO_Is911Address = string.Format(HO_Is911Address_DropDown, commonFunctions.HO_Is911Address_LabelAndValue.Item2);
//                    RadioButton.SelectRadioButton(HO_Is911Address, true, 1);
//                }
//            }
//            //Driving Directions:

//            if (commonFunctions.HO_DrivingDirections_LabelAndValue.Item2 != string.Empty)
//            {
//                InputField.SetTextAreaInputField(HO_DrivingDirections, commonFunctions.HO_DrivingDirections_LabelAndValue.Item2, true, 1);
//            }

//            if (commonFunctions.HO_OccupiedDaily_LabelAndValue.Item2 != string.Empty)
//            {
//                if (commonFunctions.HO_OccupiedDaily_LabelAndValue.Item2 == "Yes")
//                {
//                    var HO_OccupiedDaily = string.Format(HO_OccupiedDaily_DropDown, commonFunctions.HO_OccupiedDaily_LabelAndValue.Item2);
//                    RadioButton.SelectRadioButton(HO_OccupiedDaily, true, 1);
//                }
//                else
//                {
//                    var HO_OccupiedDaily = string.Format(HO_OccupiedDaily_DropDown, commonFunctions.HO_OccupiedDaily_LabelAndValue.Item2);
//                    RadioButton.SelectRadioButton(HO_OccupiedDaily, true, 1);
//                }
//            }

//            if (commonFunctions.HO_SharedProgram_LabelAndValue.Item2 != string.Empty)
//            {
//                if (commonFunctions.HO_SharedProgram_LabelAndValue.Item2 == "Yes")
//                {
//                    var HO_SharedProgram = string.Format(HO_SharedProgram_DropDown, commonFunctions.HO_SharedProgram_LabelAndValue.Item2);
//                    RadioButton.SelectRadioButton(HO_SharedProgram, true, 1);
//                }
//                else
//                {
//                    var HO_SharedProgram = string.Format(HO_SharedProgram_DropDown, commonFunctions.HO_SharedProgram_LabelAndValue.Item2);
//                    RadioButton.SelectRadioButton(HO_SharedProgram, true, 1);
//                }
//            }

//            if (commonFunctions.HO_LogHome_LabelAndValue.Item2 != string.Empty)
//            {
//                if (commonFunctions.HO_LogHome_LabelAndValue.Item2 == "Yes")
//                {
//                    var HO_LogHome = string.Format(HO_LogHome_DropDown, commonFunctions.HO_LogHome_LabelAndValue.Item2);
//                    RadioButton.SelectRadioButton(HO_LogHome, true, 1);
//                }
//                else
//                {
//                    var HO_LogHome = string.Format(HO_LogHome_DropDown, commonFunctions.HO_LogHome_LabelAndValue.Item2);
//                    RadioButton.SelectRadioButton(HO_LogHome, true, 1);
//                }
//            }

//            if (commonFunctions.HO_HistoricRegisteredHome_LabelAndValue.Item2 != string.Empty)
//            {
//                if (commonFunctions.HO_HistoricRegisteredHome_LabelAndValue.Item2 == "Yes")
//                {
//                    var HO_HistoricRegisteredHome = string.Format(HO_HistoricRegisteredHome_DropDown, commonFunctions.HO_HistoricRegisteredHome_LabelAndValue.Item2);
//                    RadioButton.SelectRadioButton(HO_HistoricRegisteredHome, true, 1);
//                }
//                else
//                {
//                    var HO_HistoricRegisteredHome = string.Format(HO_HistoricRegisteredHome_DropDown, commonFunctions.HO_HistoricRegisteredHome_LabelAndValue.Item2);
//                    RadioButton.SelectRadioButton(HO_HistoricRegisteredHome, true, 1);
//                }
//            }

//            if (commonFunctions.BindingAgreeTerms_LabelAndValue.Item2 == "Yes")
//            {
//                var AgreeTerm = string.Format(AgreeTerms, commonFunctions.BindingAgreeTerms_LabelAndValue.Item2);
//                Checkbox.SelectCheckbox(AgreeTerm, true, true, 1, "I agree to the above terms and conditions.");
//            }

//            Checkbox.VerifyCheckboxExist(AgreeTerms, true, 1, "I agree to the above terms and conditions.");
//        }
//    }
//}


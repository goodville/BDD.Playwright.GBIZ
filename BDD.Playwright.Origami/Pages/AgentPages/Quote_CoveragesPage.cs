using BDD.Playwright.GBIZ.Pages.CommonPage;
using BDD.Playwright.GBIZ.Pages.GlobalPages;
using BDD.Playwright.GBIZ.Pages.XpathProperties;
using BDD.Playwright.Origami.Pages.CommonPage;
using Reqnroll;

namespace GoodVille.GBIZ.Reqnroll.Automation.Pages.AgentPages
{
    public class Quote_CoveragesPage : BasePage
    {
      
        private readonly ScenarioContext _scenarioContext;
        public FeatureContext _featureContext;
        public CommonXpath _commonXpath;
        public LoginPage _loginPage;
        // Constructor
        public Quote_CoveragesPage(ScenarioContext scenarioContext,LoginPage loginPage, CommonXpath commonXpath) : base(scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _loginPage = loginPage;
            _commonXpath = commonXpath;
        }
        #region Xpath
        public string PolicyForm_Drp { get; set; } = "//select[@name='policyForm']";
        public string PremisesLiability_Drp { get; set; } = "//select[@id='fld_premisesLiability']";
        public string ExtendPremisesLiability_Radio { get; set; } = "//input[@name='extendedliamed' and @value='{0}']";
        public string MedicalPayments_Drp { get; set; } = "//select[@id='fld_medicalPayments']";
        public string AllPerilsDeductible_Drp { get; set; } = "//select[@id='fld_basicDeductible']";
        public string WindHailDeductible_Drp { get; set; } = "//select[@id='fld_windHailDeductible']";
        public string ContinueButton { get; set; } = "//button[contains(text(),'Continue')]";
        public string NextButton { get; set; } = "//div[@id='bottomsubnav_nextlink']";

        //Rahul WC Xpaths:
        public string Coverages_Link { get; set; } = "//a[normalize-space()='Coverages']";
        public string ELEachAccident_Select { get; set; } = "//select[@id='fld_cov_ELEachAccindent']";
        public string ELDiseasePL_Select { get; set; } = "//select[@id='fld_cov_ELDiseasePL']";
        public string ELDiseaseEachEmployee_Select { get; set; } = "//select[@id='fld_cov_ELDiseaseEachEmployee']";
        public string IndividualInclusion_Select { get; set; } = "//select[@id='fld_ind_inclusion_1']";
        public string IndividualLocation_Select { get; set; } = "//select[@id='fld_ind_location_1']";
        public string IndividualFirstName_Input { get; set; } = "//input[@id='fld_ind_firstName_1']";
        public string IndividualLastName_Input { get; set; } = "//input[@id='fld_ind_lastName_1']";
        public string IndividualRelationship_Select { get; set; } = "//select[@id='fld_IND_relationship_1']";
        public string IndividualDuties_Input { get; set; } = "//input[@id='fld_ind_duties_1']";
        public string IndividualDOB_Input { get; set; } = "//input[@id='fld_ind_dob_1']";
        public string IndividualClassCodeUW_Input { get; set; } = "//input[@id='fld_ind_classCodeUW_1']";
        public string IndividualClassCodeUWDesc_Input { get; set; } = "//input[@id='fld_ind_classCodeUWDesc_1']";
        public string IndividualOwnership_Input { get; set; } = "//input[@id='fld_ind_ownership_1']";
        public string IndividualPayroll_Input { get; set; } = "//input[@id='fld_ind_payroll_1']";

        //Rahul HO Xpaths:
        public string PolicyForm_DropDown { get; set; } = "//select[@id='fld_policyForm']";
        public string CoverageA_Input { get; set; } = "//input[@id='fld_coverageA12358']";
        public string CoverageCAddlLimit_Input { get; set; } = "//input[@id='fld_coverageCAddlLimit']";
        public string LiabilityLimitHigh_DropDown { get; set; } = "//select[@id='fld_liabilityLimitHigh']";
        public string MedicalLimit_DropDown { get; set; } = "//select[@id='fld_medicalLimit']";
        public string BasicDeductible_DropDown { get; set; } = "//select[@id='fld_basicDeductible']";
        public string WindHailDeductible_DropDown { get; set; } = "//select[@id='fld_windHailDeductible']";
        public string PolicyPlan_Radio { get; set; } = "//input[@name='plan' and @value='{0}']";

        //Coverages

        #endregion
        public string CoverageA_Dwelling { get; set; } = "//input[@id='fld_coverageA6']";
        public string CoverageC_PersonalProperty { get; set; } = "//input[@id='fld_coverageCAddlLimit46']";
        public string  AllPerilsDeductible { get; set; } = "//select[@id='fld_basicDeductible']";

        public async Task CoveragesDatafillAsync()
        {
           
          /*  await DropDown.SelectDropDownAsync(PolicyForm_Drp, commonFunctions.CoveragesPolicyForm_LabelAndValue.Item2, true, 1);
            await DropDown.SelectDropDownAsync(PremisesLiability_Drp, commonFunctions.CoveragesPremisesLiability_LabelAndValue.Item2, true, 1);
            await DropDown.SelectDropDownAsync(MedicalPayments_Drp, commonFunctions.CoveragesMedicalPayments_LabelAndValue.Item2, true, 1);
            await DropDown.SelectDropDownAsync(AllPerilsDeductible_Drp, commonFunctions.CoveragesAllPerilsDeductible_LabelAndValue.Item2, true, 1);
            await DropDown.SelectDropDownAsync(WindHailDeductible_Drp, commonFunctions.CoveragesWindorHailDeductible_LabelAndValue.Item2, true, 1);
            //Button.ClickButton(NextButton, ActionType.Click, true, 1);
            await Button.ClickButtonAsync(ContinueButton, ActionType.Click, true, 1);*/
          
        }

        #region Workers Compensation Coverages Fill
        // Rahul WC
        public async Task WorkersCompCoveragesDatafillAsync()
        {
           
         /*   await TextLink.ClickTextLinkAsync(Coverages_Link, true, 1);
            await DropDown.SelectDropDownAsync(ELEachAccident_Select, commonFunctions.CoveragesELEachAccident_LabelAndValue.Item2, true, 1);
            await DropDown.SelectDropDownAsync(ELDiseasePL_Select, commonFunctions.CoveragesELDiseasePL_LabelAndValue.Item2, true, 1);
            await DropDown.SelectDropDownAsync(ELDiseaseEachEmployee_Select, commonFunctions.CoveragesELDiseaseEachEmployee_LabelAndValue.Item2, true, 1);
            await DropDown.SelectDropDownAsync(IndividualInclusion_Select, commonFunctions.CoveragesIndividualInclusion_LabelAndValue.Item2, true, 1);
            await DropDown.SelectDropDownAsync(IndividualLocation_Select, commonFunctions.CoveragesIndividualLocation_LabelAndValue.Item2, true, 1);
            await InputField.SetInputFieldAsync(IndividualFirstName_Input, commonFunctions.CoveragesIndividualFirstName_LabelAndValue.Item2, true, 1);
            await InputField.SetInputFieldAsync(IndividualLastName_Input, commonFunctions.CoveragesIndividualLastName_LabelAndValue.Item2, true, 1);
            await DropDown.SelectDropDownAsync(IndividualRelationship_Select, commonFunctions.CoveragesIndividualRelationship_LabelAndValue.Item2, true, 1);
            await InputField.SetInputFieldAsync(IndividualDuties_Input, commonFunctions.CoveragesIndividualDuties_LabelAndValue.Item2, true, 1);
            await InputField.SetInputFieldAsync(IndividualDOB_Input, commonFunctions.CoveragesIndividualDOB_LabelAndValue.Item2, true, 1);
            await InputField.SetInputFieldAsync(IndividualClassCodeUW_Input, commonFunctions.CoveragesIndividualClassCodeUW_LabelAndValue.Item2, true, 1);
            await InputField.SetInputFieldAsync(IndividualClassCodeUWDesc_Input, commonFunctions.CoveragesIndividualClassCodeUWDesc_LabelAndValue.Item2, true, 1);
            await InputField.SetInputFieldAsync(IndividualOwnership_Input, commonFunctions.CoveragesIndividualOwnership_LabelAndValue.Item2, true, 1);
            await InputField.SetInputFieldAsync(IndividualPayroll_Input, commonFunctions.CoveragesIndividualPayroll_LabelAndValue.Item2, true, 1);
            await commonFunctions.UserWaitForPageToLoadCompletlyAsync();*/
        }
        #endregion

        #region HomeOwners Coverages Fill
        // Rahul HO
        public async Task HomeOwnersCoveragesDatafillAsync()
        {
           
           /* if (commonFunctions.PolicyForm_LabelAndValue.Item2 != string.Empty)
            {
                await DropDown.SelectDropDownAsync(PolicyForm_DropDown, commonFunctions.PolicyForm_LabelAndValue.Item2, true, 1);
            }

            if (commonFunctions.PolicyPlan_LabelAndValue.Item2 != string.Empty)
            {
                if (commonFunctions.PolicyPlan_LabelAndValue.Item2 == "HC")
                {
                    var PolicyPlan = string.Format(PolicyPlan_Radio, commonFunctions.PolicyPlan_LabelAndValue.Item2);
                    await RadioButton.SelectRadioButtonAsync(PolicyPlan, true, 1);
                }
                else if (commonFunctions.PolicyPlan_LabelAndValue.Item2 == "HCX")
                {
                    var PolicyPlan = string.Format(PolicyPlan_Radio, commonFunctions.PolicyPlan_LabelAndValue.Item2);
                    await RadioButton.SelectRadioButtonAsync(PolicyPlan, true, 1);
                }
                else
                {
                    var PolicyPlan = string.Format(PolicyPlan_Radio, commonFunctions.PolicyPlan_LabelAndValue.Item2);
                    await RadioButton.SelectRadioButtonAsync(PolicyPlan, true, 1);
                }
            }

            if (commonFunctions.CoverageA_LabelAndValue.Item2 != string.Empty)
            {
                await InputField.SetTextAreaInputFieldAsync(CoverageA_Input, commonFunctions.CoverageA_LabelAndValue.Item2, true, 1);
            }

            if (commonFunctions.CoverageCAddlLimit_LabelAndValue.Item2 != string.Empty)
            {
                await InputField.SetTextAreaInputFieldAsync(CoverageCAddlLimit_Input, commonFunctions.CoverageCAddlLimit_LabelAndValue.Item2, true, 1);
            }

            if (commonFunctions.LiabilityLimitHigh_LabelAndValue.Item2 != string.Empty)
            {
                await DropDown.SelectDropDownAsync(LiabilityLimitHigh_DropDown, commonFunctions.LiabilityLimitHigh_LabelAndValue.Item2, true, 1);
            }

            if (commonFunctions.MedicalLimit_LabelAndValue.Item2 != string.Empty)
            {
                await DropDown.SelectDropDownAsync(MedicalLimit_DropDown, commonFunctions.MedicalLimit_LabelAndValue.Item2, true, 1);
            }

            if (commonFunctions.BasicDeductible_LabelAndValue.Item2 != string.Empty)
            {
                await DropDown.SelectDropDownAsync(BasicDeductible_DropDown, commonFunctions.BasicDeductible_LabelAndValue.Item2, true, 1);
            }

            if (commonFunctions.WindHailDeductible_LabelAndValue.Item2 != string.Empty)
            {
                await DropDown.SelectDropDownAsync(WindHailDeductible_DropDown, commonFunctions.WindHailDeductible_LabelAndValue.Item2, true, 1);
            }

            await commonFunctions.UserWaitForPageToLoadCompletlyAsync();
            await Button.ClickButtonAsync(ContinueButton, ActionType.Click, true, 1);*/
        }
        #endregion
        #region HomeOwners Coverages Fill1
        public async Task HomeOwnersCoveragesDatafill1Async()
        {
           /* commonFunctions.ReadTestDataForCoveragePage();
            commonFunctions.UserWaitForPageToLoadCompletly();
            if (commonFunctions.PolicyForm_LabelAndValue.Item2 != string.Empty)
            {
                await DropDown.SelectDropDownAsync(PolicyForm_DropDown, commonFunctions.PolicyForm_LabelAndValue.Item2, true, 1);
            }

            if (commonFunctions.PolicyPlan_LabelAndValue.Item2 != string.Empty)
            {
                if (commonFunctions.PolicyPlan_LabelAndValue.Item2 == "HC")
                {
                    var PolicyPlan = string.Format(PolicyPlan_Radio, commonFunctions.PolicyPlan_LabelAndValue.Item2);
                    await RadioButton.SelectRadioButtonAsync(PolicyPlan, true, 1);
                }
                else if (commonFunctions.PolicyPlan_LabelAndValue.Item2 == "HCX")
                {
                    var PolicyPlan = string.Format(PolicyPlan_Radio, commonFunctions.PolicyPlan_LabelAndValue.Item2);
                    await RadioButton.SelectRadioButtonAsync(PolicyPlan, true, 1);
                }
                else
                {
                    var PolicyPlan = string.Format(PolicyPlan_Radio, commonFunctions.PolicyPlan_LabelAndValue.Item2);
                    await RadioButton.SelectRadioButtonAsync(PolicyPlan, true, 1);
                }
            }

            if (commonFunctions.CoverageA_LabelAndValue.Item2 != string.Empty)
            {
                await InputField.SetTextAreaInputFieldAsync(CoverageA_Dwelling, commonFunctions.CoverageA_LabelAndValue.Item2, true, 1);
            }

            if (commonFunctions.CoverageCAddlLimit_LabelAndValue.Item2 != string.Empty)
            {
                await InputField.SetTextAreaInputFieldAsync(CoverageC_PersonalProperty, commonFunctions.CoverageCAddlLimit_LabelAndValue.Item2, true, 1);
            }

            if (commonFunctions.LiabilityLimitHigh_LabelAndValue.Item2 != string.Empty)
            {
                await DropDown.SelectDropDownAsync(LiabilityLimitHigh_DropDown, commonFunctions.LiabilityLimitHigh_LabelAndValue.Item2, true, 1);
            }

            if (commonFunctions.MedicalLimit_LabelAndValue.Item2 != string.Empty)
            {
                await DropDown.SelectDropDownAsync(MedicalLimit_DropDown, commonFunctions.MedicalLimit_LabelAndValue.Item2, true, 1);
            }

            if (commonFunctions.BasicDeductible_LabelAndValue.Item2 != string.Empty)
            {
                await DropDown.SelectDropDownAsync(BasicDeductible_DropDown, commonFunctions.BasicDeductible_LabelAndValue.Item2, true, 1);
            }

            commonFunctions.UserWaitForPageToLoadCompletly();
            await Button.ClickButtonAsync(ContinueButton, ActionType.Click, true, 1);*/
        }
        #endregion

    }
}

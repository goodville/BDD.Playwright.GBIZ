using BDD.Playwright.Core.Interfaces;
using BDD.Playwright.GBIZ.PageElements;
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
        private readonly IFileReader _fileReader;
        // Constructor
        public Quote_CoveragesPage(ScenarioContext scenarioContext,LoginPage loginPage, CommonXpath commonXpath, IFileReader fileReader) : base(scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _loginPage = loginPage;
            _commonXpath = commonXpath;
            _fileReader = fileReader;
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

        public async Task CoveragesDataFillAsync(string profileKey)
        {
            var filePath = "QuoteCoveragesPage\\QuoteCoveragesPage.json";

            // Policy Form Dropdown
            var policyFormValue = _fileReader.GetOptionalValue(filePath, $"{profileKey}.PolicyForms");
            if (!string.IsNullOrEmpty(policyFormValue))
            {
                await DropDown.SelectDropDownAsync(PolicyForm_Drp, policyFormValue, true, 1);
            }

            // Premises Liability Dropdown
            var premisesLiabilityValue = _fileReader.GetOptionalValue(filePath, $"{profileKey}.PremisesLiabilities");
            if (!string.IsNullOrEmpty(premisesLiabilityValue))
            {
                await DropDown.SelectDropDownAsync(PremisesLiability_Drp, premisesLiabilityValue, true, 1);
            }

            // Medical Payments Dropdown
            var medicalPaymentsValue = _fileReader.GetOptionalValue(filePath, $"{profileKey}.MedicalPayments");
            if (!string.IsNullOrEmpty(medicalPaymentsValue))
            {
                await DropDown.SelectDropDownAsync(MedicalPayments_Drp, medicalPaymentsValue, true, 1);
            }

            // All Perils Deductible Dropdown
            var allPerilsDeductibleValue = _fileReader.GetOptionalValue(filePath, $"{profileKey}.AllPerilsDeductible");
            if (!string.IsNullOrEmpty(allPerilsDeductibleValue))
            {
                await DropDown.SelectDropDownAsync(AllPerilsDeductible_Drp, allPerilsDeductibleValue, true, 1);
            }

            // Wind/Hail Deductible Dropdown
            var windHailDeductibleValue = _fileReader.GetOptionalValue(filePath, $"{profileKey}.WindorHailDeductible");
            if (!string.IsNullOrEmpty(windHailDeductibleValue))
            {
                await DropDown.SelectDropDownAsync(WindHailDeductible_Drp, windHailDeductibleValue, true, 1);
            }

            await Button.ClickButtonAsync(ContinueButton, ActionType.Click, true, 1);
        }

        #region Workers Compensation Coverages Fill

        public async Task WorkersCompCoveragesDataFillAsync(string profileKey)
        {
            var filePath = "QuoteCoveragesPage\\QuoteCoveragesPage.json";

            await TextLink.ClickTextLinkAsync(Coverages_Link, true, 1);

            var eachAccidentValue = _fileReader.GetOptionalValue(filePath, $"{profileKey}.CoveragesELEachAccident");
            if (!string.IsNullOrEmpty(eachAccidentValue))
            {
                await DropDown.SelectDropDownAsync(ELEachAccident_Select, eachAccidentValue, true, 1);
            }

            var diseasePLValue = _fileReader.GetOptionalValue(filePath, $"{profileKey}.CoveragesELDiseasePL");
            if (!string.IsNullOrEmpty(diseasePLValue))
            {
                await DropDown.SelectDropDownAsync(ELDiseasePL_Select, diseasePLValue, true, 1);
            }

            var diseaseEachEmpValue = _fileReader.GetOptionalValue(filePath, $"{profileKey}.CoveragesELDiseaseEachEmployee");
            if (!string.IsNullOrEmpty(diseaseEachEmpValue))
            {
                await DropDown.SelectDropDownAsync(ELDiseaseEachEmployee_Select, diseaseEachEmpValue, true, 1);
            }

            var inclusionValue = _fileReader.GetOptionalValue(filePath, $"{profileKey}.CoveragesIndividualInclusion");
            if (!string.IsNullOrEmpty(inclusionValue))
            {
                await DropDown.SelectDropDownAsync(IndividualInclusion_Select, inclusionValue, true, 1);
            }

            var locationValue = _fileReader.GetOptionalValue(filePath, $"{profileKey}.CoveragesIndividualLocation");
            if (!string.IsNullOrEmpty(locationValue))
            {
                await DropDown.SelectDropDownAsync(IndividualLocation_Select, locationValue, true, 1);
            }

            var firstNameValue = _fileReader.GetOptionalValue(filePath, $"{profileKey}.CoveragesIndividualFirstName");
            if (!string.IsNullOrEmpty(firstNameValue))
            {
                await InputField.SetInputFieldAsync(IndividualFirstName_Input, firstNameValue, true, 1);
            }

            var lastNameValue = _fileReader.GetOptionalValue(filePath, $"{profileKey}.CoveragesIndividualLastName");
            if (!string.IsNullOrEmpty(lastNameValue))
            {
                await InputField.SetInputFieldAsync(IndividualLastName_Input, lastNameValue, true, 1);
            }

            var DOB= _fileReader.GetOptionalValue(filePath, $"{profileKey}.CoveragesIndividualDOB");
            if (!string.IsNullOrEmpty(lastNameValue))
            {
                await InputField.SetInputFieldAsync(IndividualDOB_Input, DOB, true, 1);
            }

            var relationshipValue = _fileReader.GetOptionalValue(filePath, $"{profileKey}.CoveragesIndividualRelationship");
            if (!string.IsNullOrEmpty(relationshipValue))
            {
                await DropDown.SelectDropDownAsync(IndividualRelationship_Select, relationshipValue, true, 1);
            }

            var ClassCode = _fileReader.GetOptionalValue(filePath, $"{profileKey}.CoveragesIndividualClassCodeUW");
            if (!string.IsNullOrEmpty(ClassCode))
            {
                await InputField.SetInputFieldAsync(IndividualClassCodeUW_Input, ClassCode, true, 1);
            }

            var ClassCodeUWDesc = _fileReader.GetOptionalValue(filePath, $"{profileKey}.CoveragesIndividualClassCodeUWDesc");
            /*if (!string.IsNullOrEmpty(ClassCodeUWDesc))
            {
                await InputField.SetInputFieldAsync(IndividualClassCodeUWDesc_Input, ClassCodeUWDesc, true, 1);
            }*/
            //var locator = page.Locator(IndividualClassCodeUWDesc_Input);
            await page.Locator("body").ClickAsync();
            var isVisible = await page.Locator("//input[@id='fld_ind_classCodeUWDesc_1']").IsVisibleAsync();
            var locator = page.Locator(IndividualClassCodeUWDesc_Input);
            await locator.ClickAsync();
            await locator.FillAsync(ClassCodeUWDesc);
            await Task.Delay(5000);
            var Ownership = _fileReader.GetOptionalValue(filePath, $"{profileKey}.CoveragesIndividualOwnership");
            if (!string.IsNullOrEmpty(Ownership))
            {
                await InputField.SetInputFieldAsync(IndividualOwnership_Input, Ownership, true, 1);
            }

        var dutiesValue = _fileReader.GetOptionalValue(filePath, $"{profileKey}.CoveragesIndividualDuties");
            if (!string.IsNullOrEmpty(dutiesValue))
            {
                await InputField.SetInputFieldAsync(IndividualDuties_Input, dutiesValue, true, 1);
            }

            var payrollValue = _fileReader.GetOptionalValue(filePath, $"{profileKey}.CoveragesIndividualPayroll");
            if (!string.IsNullOrEmpty(payrollValue))
            {
                await InputField.SetInputFieldAsync(IndividualPayroll_Input, payrollValue, true, 1);
            }
            #endregion
        }

        #region HomeOwners Coverages Fill
        // Rahul HO
        public async Task HomeOwnersCoveragesDatafillAsync(string profileKey)
        {
            var filePath = "QuoteCoveragesPage/QuoteCoveragesPage.json";

            // PolicyForm Dropdown
            var policyFormValue = _fileReader.GetOptionalValue(filePath, $"{profileKey}.PolicyForm");
            if (!string.IsNullOrEmpty(policyFormValue))
            {
                await DropDown.SelectDropDownAsync(PolicyForm_DropDown, policyFormValue, true, 1);
            }

            // PolicyPlan Radio
            var policyPlanValue = _fileReader.GetOptionalValue(filePath, $"{profileKey}.PolicyPlan");
            if (!string.IsNullOrEmpty(policyPlanValue))
            {
                var locator = string.Format(PolicyPlan_Radio, policyPlanValue);
                await RadioButton.SelectRadioButtonAsync(locator,"value", true, 1);
            }

            // CoverageA Input
            var coverageAValue = _fileReader.GetOptionalValue(filePath, $"{profileKey}.CoverageA");
            if (!string.IsNullOrEmpty(coverageAValue))
            {
                await InputField.SetTextAreaInputFieldAsync(CoverageA_Input, coverageAValue, true, 1);
            }

            // CoverageCAddlLimit Input
            var coverageCAddlLimitValue = _fileReader.GetOptionalValue(filePath, $"{profileKey}.CoverageCAddlLimit");
            if (!string.IsNullOrEmpty(coverageCAddlLimitValue))
            {
                await InputField.SetTextAreaInputFieldAsync(CoverageCAddlLimit_Input, coverageCAddlLimitValue, true, 1);
            }

            // LiabilityLimitHigh DropDown
            var liabilityLimitHighValue = _fileReader.GetOptionalValue(filePath, $"{profileKey}.LiabilityLimitHigh");
            if (!string.IsNullOrEmpty(liabilityLimitHighValue))
            {
                await DropDown.SelectDropDownAsync(LiabilityLimitHigh_DropDown, liabilityLimitHighValue, true, 1);
            }

            // MedicalLimit DropDown
            var medicalLimitValue = _fileReader.GetOptionalValue(filePath, $"{profileKey}.MedicalLimit");
            if (!string.IsNullOrEmpty(medicalLimitValue))
            {
                await DropDown.SelectDropDownAsync(MedicalLimit_DropDown, medicalLimitValue, true, 1);
            }

            // BasicDeductible DropDown
            var basicDeductibleValue = _fileReader.GetOptionalValue(filePath, $"{profileKey}.BasicDeductible");
            if (!string.IsNullOrEmpty(basicDeductibleValue))
            {
                await DropDown.SelectDropDownAsync(BasicDeductible_DropDown, basicDeductibleValue, true, 1);
            }

            // WindHailDeductible DropDown
            var windHailDeductibleValue = _fileReader.GetOptionalValue(filePath, $"{profileKey}.WindHailDeductible");
            if (!string.IsNullOrEmpty(windHailDeductibleValue))
            {
                await DropDown.SelectDropDownAsync(WindHailDeductible_DropDown, windHailDeductibleValue, true, 1);
            }

            await Button.ClickButtonAsync(ContinueButton, ActionType.Click, true, 1);
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

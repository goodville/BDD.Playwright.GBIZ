using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BDD.Playwright.Core.Enums;
using BDD.Playwright.Core.Interfaces;
using BDD.Playwright.Origami.Pages.CommonPage;
using BDD.Playwright.GBIZ.PageElements;
using Microsoft.Playwright;
using Reqnroll;
using BDD.Playwright.GBIZ.Pages.CommonPage;

namespace BDD.Playwright.GBIZ.Pages.AgentPages
{
    /// <summary>
    /// Playwright migration of legacy Selenium Quote_PACoveragesPage.
    /// Data driven via JSON or ScenarioContext["PACoveragesData"] (Dictionary&lt;string,string&gt;).
    /// Supported keys: covbi, covpd, covcsl, covuninsuredmotorist, covunderinsuredmotorist, covmedexp, 
    /// covfpbmedical, covfpbworkloss, covfpbfuneralbenefits, covfpbaccidentaldeath, covfpbextraordinarymedical,
    /// covtort, covpersonalautoplus, cpvcomprehensivedeductible, cpvcollisiondeductible, fld_covpape, continue
    /// </summary>
    public class Quote_PACoveragesPage : BasePage
    {
        private readonly ScenarioContext scenarioContext;
        private readonly IFileReader fileReader;

        // Selectors
        public string Coverages_Link { get; set; } = "//a[normalize-space()='Coverages']";
        public string CovBI_DropDown { get; set; } = "//select[@id='fld_covBI']";
        public string CovPD_DropDown { get; set; } = "//select[@id='fld_covPD']";
        public string CovCSL_DropDown { get; set; } = "//select[@id='fld_covCSL']";
        public string CovUninsuredMotorist_DropDown { get; set; } = "//select[@id='fld_covUBIsplit']";
        public string Covmedexp_Dropdown { get; set; } = "//select[@id='fld_covMedicalExpense']";
        public string CovUninsuredMotorist_Radio { get; set; } = "//div[contains(text(),'{0}')]/input[@name='covUninsuredMotorist']";
        public string CovUnderInsuredMotorist_Radio { get; set; } = "//div[contains(text(),'{0}')]/input[@name='covUnderInsuredMotorist']";
        public string CovFPBMedical_DropDown { get; set; } = "//select[@id='fld_covFPBMedical']";
        public string CovFPBWorkLoss_DropDown { get; set; } = "//select[@id='fld_covFPBWorkLoss']";
        public string CovFPBFuneralBenefits_DropDown { get; set; } = "//select[@id='fld_covFPBFuneralBenefits']";
        public string CovFPBAccidentalDeath_DropDown { get; set; } = "//select[@id='fld_covFPBAccidentalDeath']";
        public string CovFPBCombination_DropDown { get; set; } = "//select[@id='fld_covFPBCombination']";
        public string CovFPBExtraordinaryMedical_DropDown { get; set; } = "//select[@id='fld_covFPBExtraordinaryMedical']";
        public string CovTort_Radio { get; set; } = "//div[contains(text(),'{0}')]/input[@name='covTort']";
        public string CovPersonalAutoPlus_Radio { get; set; } = "//input[contains(@name,'covPersonalAutoPlus')  and @value='{0}']";
        public string CpvComprehensiveOnly_Checkbox { get; set; } = "//input[@id='fld_cpv_comprehensiveOnly_1']";
        public string CpvComprehensiveDeductible_DropDown { get; set; } = "//select[@id='fld_cpv_comprehensiveDeductible_1']";
        public string CpvCollisionDeductible_DropDown { get; set; } = "//select[@id='fld_cpv_collisionDeductible_1']";
        public string CpvTowingLimit_DropDown { get; set; } = "//select[@id='fld_cpv_towingLimit_1']";
        public string CpvTransExpenseLimit_DropDown { get; set; } = "//select[@id='fld_cpv_transExpenseLimit_1']";
        public string CpvCustomizingEquipment_DropDown { get; set; } = "//select[@id='fld_cpv_customizingEquipment_1']";
        public string CpvExcessElectronicEquip_DropDown { get; set; } = "//select[@id='fld_cpv_excessElectronicEquip_1']";
        public string FldCovPAPE_DropDown { get; set; } = "//select[@id='fld_covPAPE']";
        public string PAcoverageContinue_btn { get; set; } = "//button[contains(.,'Continue')]";

        // Constructor - Playwright pattern
        public Quote_PACoveragesPage(ScenarioContext scenarioContext, IFileReader fileReader) : base(scenarioContext)
        {
            this.scenarioContext = scenarioContext;
            this.fileReader = fileReader;
        }

        /// <summary>
        /// Synchronous wrapper for backward compatibility
        /// </summary>
        public void PACoveragesFillData() => PACoveragesFillDataAsync().GetAwaiter().GetResult();

        /// <summary>
        /// Fill Coverages page data using the provided profile key from JSON file or ScenarioContext dictionary.
        /// </summary>
        public async Task PACoveragesFillDataAsync(string profileKey = "PACoverages")
        {
            Dictionary<string, string> data;

            // Try to load from JSON file first if IFileReader is available
            if (fileReader != null)
            {
                try
                {
                    logger.WriteLine($"Starting to fill PA Coverages data using profile: {profileKey}");

                    var filePath = "PACoverages\\PACoveragesData.json";

                    // Get values from JSON
                    var covBI = fileReader.GetOptionalValue(filePath, $"{profileKey}.CovBI");
                    var covPD = fileReader.GetOptionalValue(filePath, $"{profileKey}.CovPD");
                    var covCSL = fileReader.GetOptionalValue(filePath, $"{profileKey}.CovCSL");
                    var covUninsuredMotoristDropdown = fileReader.GetOptionalValue(filePath, $"{profileKey}.CovUninsuredMotoristDropdown");
                    var covmedexp = fileReader.GetOptionalValue(filePath, $"{profileKey}.Covmedexp");
                    var covUninsuredMotorist = fileReader.GetOptionalValue(filePath, $"{profileKey}.CovUninsuredMotorist");
                    var covUnderInsuredMotorist = fileReader.GetOptionalValue(filePath, $"{profileKey}.CovUnderInsuredMotorist");
                    var covFPBMedical = fileReader.GetOptionalValue(filePath, $"{profileKey}.CovFPBMedical");
                    var covFPBWorkLoss = fileReader.GetOptionalValue(filePath, $"{profileKey}.CovFPBWorkLoss");
                    var covFPBFuneralBenefits = fileReader.GetOptionalValue(filePath, $"{profileKey}.CovFPBFuneralBenefits");
                    var covFPBAccidentalDeath = fileReader.GetOptionalValue(filePath, $"{profileKey}.CovFPBAccidentalDeath");
                    var covFPBCombination = fileReader.GetOptionalValue(filePath, $"{profileKey}.CovFPBCombination");
                    var covFPBExtraordinaryMedical = fileReader.GetOptionalValue(filePath, $"{profileKey}.CovFPBExtraordinaryMedical");
                    var covTort = fileReader.GetOptionalValue(filePath, $"{profileKey}.CovTort");
                    var covPersonalAutoPlus = fileReader.GetOptionalValue(filePath, $"{profileKey}.CovPersonalAutoPlus");
                    var cpvComprehensiveDeductible = fileReader.GetOptionalValue(filePath, $"{profileKey}.CpvComprehensiveDeductible");
                    var cpvCollisionDeductible = fileReader.GetOptionalValue(filePath, $"{profileKey}.CpvCollisionDeductible");
                    var fldCovPape = fileReader.GetOptionalValue(filePath, $"{profileKey}.FldCovPape");
                    var cpvTowingLimit = fileReader.GetOptionalValue(filePath, $"{profileKey}.CpvTowingLimit");
                    var cpvTransExpenseLimit = fileReader.GetOptionalValue(filePath, $"{profileKey}.CpvTransExpenseLimit");
                    var cpvCustomizingEquipment = fileReader.GetOptionalValue(filePath, $"{profileKey}.CpvCustomizingEquipment");
                    var cpvExcessElectronicEquip = fileReader.GetOptionalValue(filePath, $"{profileKey}.CpvExcessElectronicEquip");

                    logger.WriteLine($"Retrieved PA Coverages data from JSON");

                    // Create data dictionary from JSON
                    data = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
                    {
                        ["covbi"] = covBI,
                        ["covpd"] = covPD,
                        ["covcsl"] = covCSL,
                        ["covuninsuredmotorist_dropdown"] = covUninsuredMotoristDropdown,
                        ["covmedexp"] = covmedexp,
                        ["covuninsuredmotorist"] = covUninsuredMotorist,
                        ["covunderinsuredmotorist"] = covUnderInsuredMotorist,
                        ["covfpbmedical"] = covFPBMedical,
                        ["covfpbworkloss"] = covFPBWorkLoss,
                        ["covfpbfuneralbenefits"] = covFPBFuneralBenefits,
                        ["covfpbaccidentaldeath"] = covFPBAccidentalDeath,
                        ["covfpbcombination"] = covFPBCombination,
                        ["covfpbextraordinarymedical"] = covFPBExtraordinaryMedical,
                        ["covtort"] = covTort,
                        ["covpersonalautoplus"] = covPersonalAutoPlus,
                        ["cpvcomprehensivedeductible"] = cpvComprehensiveDeductible,
                        ["cpvcollisiondeductible"] = cpvCollisionDeductible,
                        ["fld_covpape"] = fldCovPape,
                        ["cpvtowinglimit"] = cpvTowingLimit,
                        ["cpvtransexpenselimit"] = cpvTransExpenseLimit,
                        ["cpvcustomizingequipment"] = cpvCustomizingEquipment,
                        ["cpvexcesselectronicequip"] = cpvExcessElectronicEquip
                    };
                }
                catch (Exception ex)
                {
                    logger.WriteLine($"Could not load from JSON file, falling back to ScenarioContext: {ex.Message}");
                    data = scenarioContext.TryGetValue("PACoveragesData", out Dictionary<string, string>? ctxData) 
                        ? ctxData 
                        : new Dictionary<string, string>();
                }
            }
            else
            {
                // Fall back to ScenarioContext dictionary
                data = scenarioContext.TryGetValue("PACoveragesData", out Dictionary<string, string>? ctxData) 
                    ? ctxData 
                    : new Dictionary<string, string>();
            }

            await FillCoveragesDataAsync(data);
        }

        /// <summary>
        /// Overload that accepts custom data dictionary for flexibility
        /// </summary>
        public async Task PACoveragesFillDataAsync(Dictionary<string, string> data)
        {
            await FillCoveragesDataAsync(data);
        }

        private async Task FillCoveragesDataAsync(Dictionary<string, string> data)
        {
            string Get(string key) => data.TryGetValue(key, out var v) ? v : string.Empty;

            await WaitForPageToBeReadyAsync();

            // Dropdown selections - using inherited DropDown from BasePage
            if (!string.IsNullOrWhiteSpace(Get("covbi")))
            {
                await DropDown.SelectDropDownAsync(CovBI_DropDown, Get("covbi"), true, 1);
                logger.WriteLine($"Selected Bodily Injury: {Get("covbi")}");
            }

            if (!string.IsNullOrWhiteSpace(Get("covpd")))
            {
                await DropDown.SelectDropDownAsync(CovPD_DropDown, Get("covpd"), true, 1);
                logger.WriteLine($"Selected Property Damage: {Get("covpd")}");
            }

            if (!string.IsNullOrWhiteSpace(Get("covcsl")))
            {
                await DropDown.SelectDropDownAsync(CovCSL_DropDown, Get("covcsl"), true, 1);
                logger.WriteLine($"Selected Combined Single Limit: {Get("covcsl")}");
            }

            if (!string.IsNullOrWhiteSpace(Get("covuninsuredmotorist_dropdown")))
            {
                await DropDown.SelectDropDownAsync(CovUninsuredMotorist_DropDown, Get("covuninsuredmotorist_dropdown"), true, 1);
                logger.WriteLine($"Selected Uninsured Motorist Dropdown: {Get("covuninsuredmotorist_dropdown")}");
            }

            if (!string.IsNullOrWhiteSpace(Get("covmedexp")))
            {
                await DropDown.SelectDropDownAsync(Covmedexp_Dropdown, Get("covmedexp"), true, 1);
                logger.WriteLine($"Selected Medical Expense: {Get("covmedexp")}");
            }

            // Radio button selections - using inherited RadioButton from BasePage
            if (!string.IsNullOrWhiteSpace(Get("covuninsuredmotorist")))
            {
                await RadioButton.SelectRadioButtonAsync(string.Format(CovUninsuredMotorist_Radio, Get("covuninsuredmotorist")), Get("covuninsuredmotorist"), true, 1);
                logger.WriteLine($"Selected Uninsured Motorist: {Get("covuninsuredmotorist")}");
            }

            if (!string.IsNullOrWhiteSpace(Get("covunderinsuredmotorist")))
            {
                await RadioButton.SelectRadioButtonAsync(string.Format(CovUnderInsuredMotorist_Radio, Get("covunderinsuredmotorist")), Get("covunderinsuredmotorist"), true, 1);
                logger.WriteLine($"Selected Under-Insured Motorist: {Get("covunderinsuredmotorist")}");
            }

            // FPB Coverages
            if (!string.IsNullOrWhiteSpace(Get("covfpbmedical")))
            {
                await DropDown.SelectDropDownAsync(CovFPBMedical_DropDown, Get("covfpbmedical"), true, 1);
                logger.WriteLine($"Selected FPB Medical: {Get("covfpbmedical")}");
            }

            if (!string.IsNullOrWhiteSpace(Get("covfpbworkloss")))
            {
                await DropDown.SelectDropDownAsync(CovFPBWorkLoss_DropDown, Get("covfpbworkloss"), true, 1);
                logger.WriteLine($"Selected FPB Work Loss: {Get("covfpbworkloss")}");
            }

            if (!string.IsNullOrWhiteSpace(Get("covfpbfuneralbenefits")))
            {
                await DropDown.SelectDropDownAsync(CovFPBFuneralBenefits_DropDown, Get("covfpbfuneralbenefits"), true, 1);
                logger.WriteLine($"Selected FPB Funeral Benefits: {Get("covfpbfuneralbenefits")}");
            }

            if (!string.IsNullOrWhiteSpace(Get("covfpbaccidentaldeath")))
            {
                await DropDown.SelectDropDownAsync(CovFPBAccidentalDeath_DropDown, Get("covfpbaccidentaldeath"), true, 1);
                logger.WriteLine($"Selected FPB Accidental Death: {Get("covfpbaccidentaldeath")}");
            }

            if (!string.IsNullOrWhiteSpace(Get("covfpbcombination")))
            {
                await DropDown.SelectDropDownAsync(CovFPBCombination_DropDown, Get("covfpbcombination"), true, 1);
                logger.WriteLine($"Selected FPB Combination: {Get("covfpbcombination")}");
            }

            if (!string.IsNullOrWhiteSpace(Get("covfpbextraordinarymedical")))
            {
                await DropDown.SelectDropDownAsync(CovFPBExtraordinaryMedical_DropDown, Get("covfpbextraordinarymedical"), true, 1);
                logger.WriteLine($"Selected FPB Extraordinary Medical: {Get("covfpbextraordinarymedical")}");
            }

            // Tort and Personal Auto Plus
            if (!string.IsNullOrWhiteSpace(Get("covtort")))
            {
                await RadioButton.SelectRadioButtonAsync(string.Format(CovTort_Radio, Get("covtort")), Get("covtort"), true, 1);
                logger.WriteLine($"Selected Tort: {Get("covtort")}");
            }

            if (!string.IsNullOrWhiteSpace(Get("covpersonalautoplus")))
            {
                await RadioButton.SelectRadioButtonAsync(string.Format(CovPersonalAutoPlus_Radio, Get("covpersonalautoplus")), Get("covpersonalautoplus"), true, 1);
                logger.WriteLine($"Selected Personal Auto Plus: {Get("covpersonalautoplus")}");
            }

            if (!string.IsNullOrWhiteSpace(Get("fld_covpape")))
            {
                await DropDown.SelectDropDownAsync(FldCovPAPE_DropDown, Get("fld_covpape"), true, 1);
                logger.WriteLine($"Selected PAPE: {Get("fld_covpape")}");
            }

            // Vehicle specific coverages
            if (!string.IsNullOrWhiteSpace(Get("cpvcomprehensivedeductible")))
            {
                await DropDown.SelectDropDownAsync(CpvComprehensiveDeductible_DropDown, Get("cpvcomprehensivedeductible"), true, 1);
                logger.WriteLine($"Selected Comprehensive Deductible: {Get("cpvcomprehensivedeductible")}");
            }

            if (!string.IsNullOrWhiteSpace(Get("cpvcollisiondeductible")))
            {
                await DropDown.SelectDropDownAsync(CpvCollisionDeductible_DropDown, Get("cpvcollisiondeductible"), true, 1);
                logger.WriteLine($"Selected Collision Deductible: {Get("cpvcollisiondeductible")}");
            }

            // Additional vehicle coverages (if needed)
            if (!string.IsNullOrWhiteSpace(Get("cpvtowinglimit")))
            {
                await DropDown.SelectDropDownAsync(CpvTowingLimit_DropDown, Get("cpvtowinglimit"), true, 1);
                logger.WriteLine($"Selected Towing Limit: {Get("cpvtowinglimit")}");
            }

            if (!string.IsNullOrWhiteSpace(Get("cpvtransexpenselimit")))
            {
                await DropDown.SelectDropDownAsync(CpvTransExpenseLimit_DropDown, Get("cpvtransexpenselimit"), true, 1);
                logger.WriteLine($"Selected Transportation Expense Limit: {Get("cpvtransexpenselimit")}");
            }

            if (!string.IsNullOrWhiteSpace(Get("cpvcustomizingequipment")))
            {
                await DropDown.SelectDropDownAsync(CpvCustomizingEquipment_DropDown, Get("cpvcustomizingequipment"), true, 1);
                logger.WriteLine($"Selected Customizing Equipment: {Get("cpvcustomizingequipment")}");
            }

            if (!string.IsNullOrWhiteSpace(Get("cpvexcesselectronicequip")))
            {
                await DropDown.SelectDropDownAsync(CpvExcessElectronicEquip_DropDown, Get("cpvexcesselectronicequip"), true, 1);
                logger.WriteLine($"Selected Excess Electronic Equipment: {Get("cpvexcesselectronicequip")}");
            }

            // Click Continue button twice (as in original code) - using inherited Button from BasePage
            await Button.ClickButtonAsync(PAcoverageContinue_btn, ActionType.Click, true, 1);
            logger.WriteLine("Clicked Continue button (first time).");
            await WaitForPageToBeReadyAsync();

            await Task.Delay(3000); // Wait for page to process

            await Button.ClickButtonAsync(PAcoverageContinue_btn, ActionType.Click, true, 1);
            logger.WriteLine("Clicked Continue button (second time).");
            await WaitForPageToBeReadyAsync();

            logger.WriteLine("Successfully filled PA Coverages page data");
        }

        private async Task WaitForPageToBeReadyAsync()
        {
            try
            {
                await page.WaitForLoadStateAsync(LoadState.DOMContentLoaded);
                await page.WaitForLoadStateAsync(LoadState.NetworkIdle, new() { Timeout = 30000 });
            }
            catch (TimeoutException)
            {
                logger.WriteLine("Page load timeout (NetworkIdle) - continuing anyway");
            }
            catch (Exception ex)
            {
                logger.WriteLine($"Error waiting for page to be ready: {ex.Message}");
            }
        }
    }
}

using BDD.Playwright.Core.Interfaces;
using BDD.Playwright.GBIZ.PageElements;
using BDD.Playwright.GBIZ.Pages.CommonPage;
using BDD.Playwright.GBIZ.Pages.GlobalPages;
using BDD.Playwright.GBIZ.Pages.XpathProperties;
using Microsoft.Playwright;
using Reqnroll;

namespace Bdd.Playwright.GBIZ.Pages.AgentPages
{
    public class Quote_BusinesscoveragePage : BasePage
    {
        private readonly ScenarioContext _scenarioContext;
        public FeatureContext _featureContext;
        public CommonXpath _commonXpath;
        private readonly IFileReader _fileReader;
        public LoginPage _loginPage;
        public CommonPage _commonPage;

        public Quote_BusinesscoveragePage(ScenarioContext scenarioContext, LoginPage loginPage, CommonPage commonPage, CommonXpath commonXpath, IFileReader fileReader)
            : base(scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _loginPage = loginPage;
            _commonPage = commonPage;
            _commonXpath = commonXpath;
            _fileReader = fileReader;
        }

        #region Xpath
        public string NumberOfOwners_input { get; set; } = "//input[contains(@id,'fld_numberOfOwners')]";
        public string NumberOfFulltime_input { get; set; } = "//input[contains(@id,'fld_numberOfFulltime')]";
        public string NumberOfParttime_input { get; set; } = "//input[contains(@id,'fld_numberOfParttime')]";
        public string CovCyberliab_Radio { get; set; } = "//input[contains(@name,'covCyberliab')  and @value='{0}']";
        public string CovCyberLimit_drp { get; set; } = "//select[@name='covCyberLimit' and @id='fld_covCyberLimit']";
        public string CovCyberClaims_drp { get; set; } = "//input[contains(@name,'covCyberClaims')  and @value='{0}']";
        public string MechancialSystemsBreakdown_Radio { get; set; } = "//input[contains(@name,'mechancialSystemsBreakdown')  and @value='{0}']";
        public string Terrorism_Radio { get; set; } = "//input[contains(@name,'terrorism')  and @value='{0}']";
        public string MedicalPaymentsLimit_drp { get; set; } = "//select[@name='medicalPaymentsLimit' and @id='fld_medicalPaymentsLimit']";
        public string FireLegalLimit_drp { get; set; } = "//select[@name='fireLegalLimit' and @id='fld_fireLegalLimit']";
        public string LiabilityLimit_drp { get; set; } = "//select[@name='liabilityLimit' and @id='fld_liabilityLimit']";
        public string Message_btn { get; set; } = "//div[normalize-space()='Message Overrides']";
        public string Quote_OverrideR1_btn { get; set; } = "(//div[contains(text(),'Call underwriter due to Apartment class.')]//input[@type='checkbox'])[2]";
        public string Quote_OverrideR2_btn { get; set; } = "(//div[contains(text(),'Electrical service, building 1.')]//input[@type='checkbox'])[2]";
        public string Quote_OverrideR3_btn { get; set; } = "(//div[contains(text(),'Condition of windows and doors at building 1.')]//input[@type='checkbox'])[2]";
        public string Quote_OverrideR4_btn { get; set; } = "(//div[contains(text(),'No fire extinguishers, building 1.')]//input[@type='checkbox'])[2]";
        public string Quote_OverrideR5_btn { get; set; } = "(//div[contains(text(),' No property manager, building 1.')]//input[@type='checkbox'])[2]";
        public string Quote_OverrideR6_btn { get; set; } = "(//div[contains(text(),'Roof not peaked, building 1.')]//input[@type='checkbox'])[2]";
        public string Quote_OverrideR7_btn { get; set; } = "(//div[contains(text(),'Building 1 limit requires underwriter approval.')]//input[@type='checkbox'])[2]";
        public string Quote_OverrideR8_btn { get; set; } = "(//div[contains(text(),'Coverage amount does not represent total replacement cost.')]//input[@type='checkbox'])[2]";
        public string Quote_OverrideR9_btn { get; set; } = "(//div[contains(text(),'No smoke detectors, building 1.')]//input[@type='checkbox'])[2]";
        public string Quote_OverrideR15_btn { get; set; } = "(//div[contains(text(),'Condo unit selection is required, building 1.')]//input[@type='checkbox'])[2]";

        public string Quote_OverrideR16_btn { get; set; } = "(//div[@id='Quote_Override_r12' and @title='SCR_471']//input[@type='checkbox'])[2]";
        public string Quote_OverrideR17_btn { get; set; } = "(//div[@id='Quote_Override_r13' and @title='SCR_471']//input[@type='checkbox'])[2]";
        public string Quote_OverrideR10_btn { get; set; } = "(//div[contains(text(),' Passageways at location 1.')]//input[@type='checkbox'])[2]";
        public string Quote_OverrideR11_btn { get; set; } = "(//div[contains(text(),' Porches, decks and walkways on location 1')]//input[@type='checkbox'])[2]";
        public string Quote_OverrideR12_btn { get; set; } = "(//div[contains(text(),' Handrails/stairways at location 1.')]//input[@type='checkbox'])[2]";
        public string Quote_OverrideR13_btn { get; set; } = "(//div[contains(text(),' Location 1 state must match book of business state.')]//input[@type='checkbox'])[2]";
        public string Apply_Override_btn { get; set; } = "//span[contains(text(),'Apply Override')]";
        public string Apply_Cancel_btn { get; set; } = "(//button[.//span[normalize-space(text())='Cancel']])[4]";
        public string Continueclaims_btn { get; set; } = "//button[@id='buttonattributes.id_submitbutton']";
        public string Continueumberlla_btn { get; set; } = "//button[@id='buttonattributes.id_submitbutton']";
        public string Continuesummary2_btn { get; set; } = "(//button[normalize-space()='Continue to Summary'])[1]";
        #endregion

        public async Task BusinesscoverageDataFillAsync(string profileKey)
        {
            if (_fileReader == null)
            {
                throw new InvalidOperationException("FileReader is not available.");
            }

            var filePath = "QuoteBusinessCoveragePage\\QuoteBusinessCoveragePage.json";

            await InputField.SetTextAreaInputFieldAsync(NumberOfOwners_input, _fileReader.GetOptionalValue(filePath, $"{profileKey}.numberOfOwner"), true, 1);
            await InputField.SetTextAreaInputFieldAsync(NumberOfFulltime_input, _fileReader.GetOptionalValue(filePath, $"{profileKey}.numberOfFulltime"), true, 1);
            await InputField.SetTextAreaInputFieldAsync(NumberOfParttime_input, _fileReader.GetOptionalValue(filePath, $"{profileKey}.numberOfParttime"), true, 1);

            var covCyberliab = _fileReader.GetOptionalValue(filePath, $"{profileKey}.covCyberLiab");
            if (!string.IsNullOrEmpty(covCyberliab))
            {
                var covCyberliabRadio = string.Format(CovCyberliab_Radio, covCyberliab);
                await RadioButton.SelectRadioButtonAsync(covCyberliabRadio,"Value", true, 1);
            }

            var covCyberLimit = _fileReader.GetOptionalValue(filePath, $"{profileKey}.covCyberLimit_drp");
            if (!string.IsNullOrEmpty(covCyberLimit))
            {
                await DropDown.SelectDropDownAsync(CovCyberLimit_drp, covCyberLimit, true, 1);
            }

            var covCyberClaims = _fileReader.GetOptionalValue(filePath, $"{profileKey}.covCyberClaims");
            if (!string.IsNullOrEmpty(covCyberClaims))
            {
                var covCyberClaimsRadio = string.Format(CovCyberClaims_drp, covCyberClaims);
                await RadioButton.SelectRadioButtonAsync(covCyberClaimsRadio,"value", true, 1);
            }

            var mechancialSystemsBreakdown = _fileReader.GetOptionalValue(filePath, $"{profileKey}.mechancialSystemsBreakdown");
            if (!string.IsNullOrEmpty(mechancialSystemsBreakdown))
            {
                var mechanicalRadio = string.Format(MechancialSystemsBreakdown_Radio, mechancialSystemsBreakdown);
                await RadioButton.SelectRadioButtonAsync(mechanicalRadio, "value", true, 1);
            }

            var terrorism = _fileReader.GetOptionalValue(filePath, $"{profileKey}.terrorism");
            if (!string.IsNullOrEmpty(terrorism))
            {
                var terrorismRadio = string.Format(Terrorism_Radio, terrorism);
                await RadioButton.SelectRadioButtonAsync(terrorismRadio, "value", true, 1);
            }

            await DropDown.SelectDropDownAsync(MedicalPaymentsLimit_drp, _fileReader.GetOptionalValue(filePath, $"{profileKey}.medicalPaymentsLimit"), true, 1);
            await DropDown.SelectDropDownAsync(FireLegalLimit_drp, _fileReader.GetOptionalValue(filePath, $"{profileKey}.fireLegalLimit"), true, 1);
            await DropDown.SelectDropDownAsync(LiabilityLimit_drp, _fileReader.GetOptionalValue(filePath, $"{profileKey}.liabilityLimit"), true, 1);

            // Message Overrides & checkboxes
            await Button.ClickButtonAsync(Message_btn, ActionType.Click, true, 1);
            await Task.Delay(3000);
            await _commonPage.CheckAllMessageOverrideCheckboxes1Async();

            // await Button.ClickButtonAsync(Apply_Cancel_btn, ActionType.Click, true, 1);

            //page.Dialog += async (_, dialog) => await dialog.AcceptAsync();
            // Now click the button
            //await Button.ClickButtonAsync(Apply_Override_btn, ActionType.Click, true, 1);

            // (You may want to unsubscribe afterwards if this is a one-off)
            page.Dialog += async (_, dialog) =>
            {
                try
                {
                    await dialog.AcceptAsync();
                }
                catch (PlaywrightException ex)
                {
                    Console.WriteLine("Dialog already handled: " + ex.Message);
                    logger.WriteLine("Dialog already handled: " + ex.Message);
                }
            };

            await Button.ClickButtonAsync(Apply_Override_btn, ActionType.Click, true, 1);
            await Task.Delay(3000);
            await Button.ClickButtonAsync(Continueclaims_btn, ActionType.Click, true, 1);
            await Task.Delay(5000);
            await Button.ClickButtonAsync(Continueumberlla_btn, ActionType.Click, true, 1);
            await Task.Delay(5000);
            await Button.ClickButtonAsync(Continuesummary2_btn, ActionType.Click, true, 1);
            await Task.Delay(5000);
        }
    }
}
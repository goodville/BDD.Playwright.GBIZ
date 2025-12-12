using BDD.Playwright.Core.Interfaces;
using BDD.Playwright.GBIZ.PageElements;
using BDD.Playwright.GBIZ.Pages.CommonPage;
using BDD.Playwright.GBIZ.Pages.GlobalPages;
using BDD.Playwright.GBIZ.Pages.XpathProperties;
using Microsoft.Playwright;
using Reqnroll;
using System.Threading.Tasks;

namespace GoodVille.GBIZ.Reqnroll.Automation.Pages.AgentPages
{
    public class Quote_PADriversPage : BasePage
    {
        private readonly IFileReader _fileReader;
        public FeatureContext _featureContext;
        public CommonXpath _commonXpath;
        public LoginPage _loginPage;

        // Constructor
        public Quote_PADriversPage(
            ScenarioContext scenarioContext,
            IFileReader fileReader,
            LoginPage loginPage,
            CommonXpath commonXpath
        ) : base(scenarioContext)
        {
            _fileReader = fileReader;
            _loginPage = loginPage;
            _commonXpath = commonXpath;
        }
        #region Xpath
        public string PAgender_radio => "//input[contains(@name,'dr_gender_1')  and @value='{0}']";
        public string PAmaritalStatus_drp => "//select[@id='fld_dr_maritalStatus_1']";
        public string PAoperatorType_radio => "//input[contains(@name,'dr_operatorType_1')  and @value='{0}']";
        public string PAnumberOfYearsNoAccident_Drp => "//select[@id='fld_dr_numberOfYearsNoAccident_1']";
        public string PAContinue_btn => "//button[contains(text(),'Continue')]";
        #endregion

        public async Task PADriversDatafillAsync(string profileKey)
        {
            var filePath = "Quote_PADriversPage/Quote_PADriversPage.json";

            // Get values from JSON using IFileReader and profileKey
            var gender = _fileReader.GetOptionalValue(filePath, $"{profileKey}.PAgender");
            var maritalStatus = _fileReader.GetOptionalValue(filePath, $"{profileKey}.PAmaritalStatus");
            var operatorType = _fileReader.GetOptionalValue(filePath, $"{profileKey}.PAoperatorType");
            var noAccidentYears = _fileReader.GetOptionalValue(filePath, $"{profileKey}.PAnumberOfYearsNoAccident");

            // Gender radio
            if (!string.IsNullOrEmpty(gender))
            {
                var locator = string.Format(PAgender_radio, gender);
                await RadioButton.SelectRadioButtonAsync(locator,"value", true, 1);
            }
            // Marital Status dropdown
            if (!string.IsNullOrEmpty(maritalStatus))
            {
                await DropDown.SelectDropDownAsync(PAmaritalStatus_drp, maritalStatus, true, 1);
            }
            // Operator Type radio
            if (!string.IsNullOrEmpty(operatorType))
            {
                var locator = string.Format(PAoperatorType_radio, operatorType);
                await RadioButton.SelectRadioButtonAsync(locator,"value", true, 1);
            }
            // No Accident Years dropdown
            if (!string.IsNullOrEmpty(noAccidentYears))
            {
                await DropDown.SelectDropDownAsync(PAnumberOfYearsNoAccident_Drp, noAccidentYears, true, 1);
            }
            // Continue button
            await Button.ClickButtonAsync(PAContinue_btn, ActionType.Click, true, 1);
        }
    }
}
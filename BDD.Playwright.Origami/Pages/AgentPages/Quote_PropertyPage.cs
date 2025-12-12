using System;
using System.Threading.Tasks;
using BDD.Playwright.Origami.Pages.CommonPage;
using BDD.Playwright.Core.Interfaces;
using Microsoft.Playwright;
using Reqnroll;
using BDD.Playwright.GBIZ.PageElements;
using BDD.Playwright.GBIZ.Pages.CommonPage;

namespace BDD.Playwright.GBIZ.Pages.AgentPages
{
    public class Quote_PropertyPage : BasePage
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly IReqnrollOutputHelper _ReqnrollLogger;
        private readonly IFileReader _fileReader;

        /// <summary>
        /// Constructor with IFileReader support for data-driven tests
        /// </summary>
        public Quote_PropertyPage(ScenarioContext scenarioContext, IFileReader fileReader, IReqnrollOutputHelper ReqnrollOutputHelper) : base(scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _fileReader = fileReader;
            _ReqnrollLogger = ReqnrollOutputHelper;
        }

        /// <summary>
        /// Constructor without IFileReader for direct parameter-based tests
        /// </summary>
        public Quote_PropertyPage(ScenarioContext scenarioContext, IReqnrollOutputHelper ReqnrollOutputHelper) : base(scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _ReqnrollLogger = ReqnrollOutputHelper;
            _fileReader = null;
        }

        #region XPath Selectors
        public string PropertyLocatedFlood_Radio { get; set; } = "//input[@name='propertyLocatedFlood' and @value='{0}']";
        public string YearOfConstruction_Input { get; set; } = "//input[@id='fld_yearOfConstruction']";
        public string NumberOfFamilies_DropDown { get; set; } = "//select[@id='fld_numberOfFamilies']";
        public string ConstructionType_Radio { get; set; } = "//input[@name='constructionType' and @value='{0}']";
        public string UnderConstruction_Radio { get; set; } = "//input[@name='underConstruction' and @value='{0}']";
        public string UniqueConstruction_Radio { get; set; } = "//input[@name='uniqueConstruction' and @value='{0}']";
        public string LogHome_Radio { get; set; } = "//input[@name='logHome' and @value='{0}']";
        public string RoofType_Radio { get; set; } = "//input[@name='roofType' and @value='{0}']";
        public string HistoricRegisteredHome_Radio { get; set; } = "//input[@name='historicRegisteredHome' and @value='{0}']";
        public string OccupancyType_Radio { get; set; } = "//input[@name='occupancyType' and @value='{0}']";
        public string FireDepartment_Input { get; set; } = "//input[@id='fld_fireDepartment']";
        public string ProtectionClass_DropDown { get; set; } = "//select[@name='protectionClass']";
        public string PrimaryHeatType_DropDown { get; set; } = "//select[@name='primaryHeatType']";
        public string SmokeDetector_Input { get; set; } = "//input[@name='smokeDetector']";
        public string NumBuiltInFireplaces_Input { get; set; } = "//input[@name='numBuiltInFireplaces']";
        public string LiquidFuel_Input { get; set; } = "//input[@name='liquidFuel']";
        public string ContinueCoverage { get; set; } = "//button[@id='buttonid_nextbutton']";
        #endregion

        /// <summary>
        /// Fills Property data using JSON file
        /// </summary>
        /// <param name="profileKey">Profile key to read from JSON file (default: "Property")</param>
        public async Task PropertyDatafillAsync(string profileKey)
        {
            var filePath = "QuotePropertyPage/QuotePropertyPage.json";

            // PropertyLocatedFlood Radio
            var propertyLocatedFloodValue = _fileReader.GetOptionalValue(filePath, $"{profileKey}.PropertyLocatedFlood");
            if (!string.IsNullOrEmpty(propertyLocatedFloodValue))
            {
                var locator = string.Format(PropertyLocatedFlood_Radio, propertyLocatedFloodValue);
                await RadioButton.SelectRadioButtonAsync(locator, "value", true, 1);
            }

            // YearOfConstruction Input
            var yearOfConstructionValue = _fileReader.GetOptionalValue(filePath, $"{profileKey}.YearOfConstruction");
            if (!string.IsNullOrEmpty(yearOfConstructionValue))
            {
                await InputField.SetInputFieldAsync(YearOfConstruction_Input, yearOfConstructionValue, true, 1);
            }

            // NumberOfFamilies Dropdown
            var numberOfFamiliesValue = _fileReader.GetOptionalValue(filePath, $"{profileKey}.NumberOfFamilies");
            if (!string.IsNullOrEmpty(numberOfFamiliesValue))
            {
                await DropDown.SelectDropDownAsync(NumberOfFamilies_DropDown, numberOfFamiliesValue, true, 1);
            }

            // ConstructionType Radio
            var constructionTypeValue = _fileReader.GetOptionalValue(filePath, $"{profileKey}.ConstructionType");
            if (!string.IsNullOrEmpty(constructionTypeValue))
            {
                var locator = string.Format(ConstructionType_Radio, constructionTypeValue);
                await RadioButton.SelectRadioButtonAsync(locator, "value", true, 1);
            }

            // UnderConstruction Radio
            var underConstructionValue = _fileReader.GetOptionalValue(filePath, $"{profileKey}.UnderConstruction");
            if (!string.IsNullOrEmpty(underConstructionValue))
            {
                var locator = string.Format(UnderConstruction_Radio, underConstructionValue);
                await RadioButton.SelectRadioButtonAsync(locator, "value", true, 1);
            }

            // UniqueConstruction Radio
            var uniqueConstructionValue = _fileReader.GetOptionalValue(filePath, $"{profileKey}.UniqueConstruction");
            if (!string.IsNullOrEmpty(uniqueConstructionValue))
            {
                var locator = string.Format(UniqueConstruction_Radio, uniqueConstructionValue);
                await RadioButton.SelectRadioButtonAsync(locator, "value", true, 1);
            }

            // LogHome Radio
            var logHomeValue = _fileReader.GetOptionalValue(filePath, $"{profileKey}.LogHome");
            if (!string.IsNullOrEmpty(logHomeValue))
            {
                var locator = string.Format(LogHome_Radio, logHomeValue);
                await RadioButton.SelectRadioButtonAsync(locator,"value", true, 1);
            }

            // RoofType Radio
            var roofTypeValue = _fileReader.GetOptionalValue(filePath, $"{profileKey}.RoofType");
            if (!string.IsNullOrEmpty(roofTypeValue))
            {
                var locator = string.Format(RoofType_Radio, roofTypeValue);
                await RadioButton.SelectRadioButtonAsync(locator,"value",true, 1);
            }

            // HistoricRegisteredHome Radio
            var historicRegisteredHomeValue = _fileReader.GetOptionalValue(filePath, $"{profileKey}.HistoricRegisteredHome");
            if (!string.IsNullOrEmpty(historicRegisteredHomeValue))
            {
                var locator = string.Format(HistoricRegisteredHome_Radio, historicRegisteredHomeValue);
                await RadioButton.SelectRadioButtonAsync(locator, "value", true, 1);
            }

            // OccupancyType Radio
            var occupancyTypeValue = _fileReader.GetOptionalValue(filePath, $"{profileKey}.OccupancyType");
            if (!string.IsNullOrEmpty(occupancyTypeValue))
            {
                var locator = string.Format(OccupancyType_Radio, occupancyTypeValue);
                await RadioButton.SelectRadioButtonAsync(locator, "value", true, 1);
            }

            // FireDepartment Input
            var fireDepartmentValue = _fileReader.GetOptionalValue(filePath, $"{profileKey}.FireDepartment");
            if (!string.IsNullOrEmpty(fireDepartmentValue))
            {
                await InputField.SetInputFieldAsync(FireDepartment_Input, fireDepartmentValue, true, 1);
            }

            // ProtectionClass DropDown
            var protectionClassValue = _fileReader.GetOptionalValue(filePath, $"{profileKey}.ProtectionClass");
            if (!string.IsNullOrEmpty(protectionClassValue))
            {
                await DropDown.SelectDropDownAsync(ProtectionClass_DropDown, protectionClassValue, true, 1);
            }

            // PrimaryHeatType DropDown
            var primaryHeatTypeValue = _fileReader.GetOptionalValue(filePath, $"{profileKey}.PrimaryHeatType");
            if (!string.IsNullOrEmpty(primaryHeatTypeValue))
            {
                await DropDown.SelectDropDownAsync(PrimaryHeatType_DropDown, primaryHeatTypeValue, true, 1);
            }

            // SmokeDetector Checkbox
            var smokeDetectorValue = _fileReader.GetOptionalValue(filePath, $"{profileKey}.SmokeDetector");
            if (!string.IsNullOrEmpty(smokeDetectorValue) && smokeDetectorValue.Equals("Yes", StringComparison.InvariantCultureIgnoreCase))
            {
                await Checkbox.SelectCheckboxAsync(SmokeDetector_Input, true, true, 1, "SmokeDetector");
            }

            // NumBuiltInFireplaces Input
            var numBuiltInFireplacesValue = _fileReader.GetOptionalValue(filePath, $"{profileKey}.NumBuiltInFireplaces");
            if (!string.IsNullOrEmpty(numBuiltInFireplacesValue))
            {
                await InputField.SetInputFieldAsync(NumBuiltInFireplaces_Input, numBuiltInFireplacesValue, true, 1);
            }

            // LiquidFuel Checkbox
            var liquidFuelValue = _fileReader.GetOptionalValue(filePath, $"{profileKey}.LiquidFuel");
            if (!string.IsNullOrEmpty(liquidFuelValue) && liquidFuelValue.Equals("Yes", StringComparison.InvariantCultureIgnoreCase))
            {
                await Checkbox.SelectCheckboxAsync(LiquidFuel_Input, true, true, 1, "LiquidFuel");
            }

            // Click Continue button
            await Button.ClickButtonAsync(ContinueCoverage, ActionType.Click, true, 1);
            await Task.Delay(20000);
        }
        /// <summary>
        /// Fills Property data with explicit parameters
        /// </summary>
        
        #region Private Helper Methods

        /// <summary>
        /// Selects a radio button using dynamic locator with value
        /// </summary>
       

        #endregion

        #region Verification Methods

        /// <summary>
        /// Verifies if the Property page is visible
        /// </summary>
       
        /// <summary>
        /// Gets the Year of Construction value
        /// </summary>
        
        /// <summary>
        /// Gets the Fire Department value
        /// </summary>
        public async Task<string> GetFireDepartmentAsync()
        {
            try
            {
                var fireDeptInput = page.Locator(FireDepartment_Input);
                var value = await fireDeptInput.GetAttributeAsync("value");
                logger.WriteLine($"Retrieved Fire Department: {value}");
                return value ?? string.Empty;
            }
            catch (Exception ex)
            {
                logger.WriteLine($"Error getting Fire Department: {ex.Message}");
                return string.Empty;
            }
        }

        /// <summary>
        /// Verifies if a specific radio button is selected
        /// </summary>
        public async Task<bool> IsRadioButtonSelectedAsync(string radioButtonTemplate, string value)
        {
            try
            {
                var radioButtonLocator = string.Format(radioButtonTemplate, value);
                var radioButton = page.Locator(radioButtonLocator);
                var isChecked = await radioButton.IsCheckedAsync();

                logger.WriteLine($"Radio button with value '{value}' is {(isChecked ? "selected" : "not selected")}");
                return isChecked;
            }
            catch (Exception ex)
            {
                logger.WriteLine($"Error checking radio button selection: {ex.Message}");
                return false;
            }
        }

        #endregion
    }
}

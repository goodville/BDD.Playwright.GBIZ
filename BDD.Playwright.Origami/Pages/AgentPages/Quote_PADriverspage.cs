using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BDD.Playwright.Core.Enums;
using BDD.Playwright.Core.Interfaces;
using BDD.Playwright.Origami.Pages.CommonPage;
using Microsoft.Playwright;
using Reqnroll;

namespace BDD.Playwright.Origami.Pages.AgentPages
{
    /// <summary>
    /// Playwright migration of legacy Selenium Quote_PADriversPage.
    /// Removes WebDriver + Thread.Sleep usage. Data driven via JSON or ScenarioContext["PADriversData"] (Dictionary&lt;string,string&gt;).
    /// Supported (case-insensitive) keys:
    ///  - gender (radio value)
    ///  - maritalstatus (dropdown label or value)
    ///  - operatortype (radio value)
    ///  - numberofyearsnoaccident (dropdown label or value)
    ///  - continue ("true" to click Continue)
    /// </summary>
    public class Quote_PADriversPage : BasePage
    {
        private readonly ScenarioContext scenarioContext;
        private readonly IFileReader fileReader;

        // Selectors
        public readonly string PAgender_Radio = "//input[contains(@name,'dr_gender_1')  and @value='{0}']";
        public readonly string PAmaritalStatus_DropDown = "//select[@id='fld_dr_maritalStatus_1']";
        public readonly string PAoperatorType_Radio = "//input[contains(@name,'dr_operatorType_1')  and @value='{0}']";
        public readonly string PAnumberOfYearsNoAccident_DropDown = "//select[@id='fld_dr_numberOfYearsNoAccident_1']";
        public readonly string PAContinue_Button = "//button[contains(text(),'Continue')]";

        public Quote_PADriversPage(ScenarioContext scenarioContext, IFileReader fileReader) : base(scenarioContext)
        {
            this.scenarioContext = scenarioContext;
            this.fileReader = fileReader;
        }

        /// <summary>
        /// Synchronous wrapper for backward compatibility
        /// </summary>
        public void PADriversDatafill() => PADriversDataFillAsync().GetAwaiter().GetResult();

        /// <summary>
        /// Fill Drivers page data using the provided profile key from JSON file or ScenarioContext dictionary.
        /// </summary>
        public async Task PADriversDataFillAsync(string profileKey = "PADrivers")
        {
            Dictionary<string, string> data;

            // Try to load from JSON file first if IFileReader is available
            if (fileReader != null)
            {
                try
                {
                    logger.WriteLine($"Starting to fill PA Drivers data using profile: {profileKey}");

                    var filePath = "PADrivers\\PADriversData.json";

                    // Get values from JSON
                    var genderValue = fileReader.GetOptionalValue(filePath, $"{profileKey}.Gender");
                    var maritalStatusValue = fileReader.GetOptionalValue(filePath, $"{profileKey}.MaritalStatus");
                    var operatorTypeValue = fileReader.GetOptionalValue(filePath, $"{profileKey}.OperatorType");
                    var numberOfYearsNoAccidentValue = fileReader.GetOptionalValue(filePath, $"{profileKey}.NumberOfYearsNoAccident");
                    var shouldContinue = fileReader.GetOptionalValue(filePath, $"{profileKey}.Continue");

                    logger.WriteLine($"Retrieved PA Drivers data from JSON: Gender={genderValue}, MaritalStatus={maritalStatusValue}");

                    // Create data dictionary from JSON
                    data = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
                    {
                        ["gender"] = genderValue,
                        ["maritalstatus"] = maritalStatusValue,
                        ["operatortype"] = operatorTypeValue,
                        ["numberofyearsnoaccident"] = numberOfYearsNoAccidentValue,
                        ["continue"] = shouldContinue
                    };
                }
                catch (Exception ex)
                {
                    logger.WriteLine($"Could not load from JSON file, falling back to ScenarioContext: {ex.Message}");
                    data = scenarioContext.TryGetValue("PADriversData", out Dictionary<string, string>? ctxData) 
                        ? ctxData 
                        : new Dictionary<string, string>();
                }
            }
            else
            {
                // Fall back to ScenarioContext dictionary
                data = scenarioContext.TryGetValue("PADriversData", out Dictionary<string, string>? ctxData) 
                    ? ctxData 
                    : new Dictionary<string, string>();
            }

            string Get(string key) => data.TryGetValue(key, out var v) ? v : string.Empty;

            await WaitForPageToBeReadyAsync();

            // Gender radio - using inherited RadioButton from BasePage
            var gender = Get("gender");
            if (!string.IsNullOrWhiteSpace(gender))
            {
                await RadioButton.SelectRadioButtonAsync(string.Format(PAgender_Radio, gender), gender, true, 1);
                logger.WriteLine($"Selected Gender: {gender}");
            }

            // Marital status dropdown - using inherited DropDown from BasePage
            var maritalStatus = Get("maritalstatus");
            if (!string.IsNullOrWhiteSpace(maritalStatus))
            {
                await DropDown.SelectDropDownAsync(PAmaritalStatus_DropDown, maritalStatus, true, 1);
                logger.WriteLine($"Selected Marital Status: {maritalStatus}");
            }

            // Operator type radio
            var operatorType = Get("operatortype");
            if (!string.IsNullOrWhiteSpace(operatorType))
            {
                await RadioButton.SelectRadioButtonAsync(string.Format(PAoperatorType_Radio, operatorType), operatorType, true, 1);
                logger.WriteLine($"Selected Operator Type: {operatorType}");
            }

            // Years no accident dropdown
            var yearsNoAccident = Get("numberofyearsnoaccident");
            if (!string.IsNullOrWhiteSpace(yearsNoAccident))
            {
                await DropDown.SelectDropDownAsync(PAnumberOfYearsNoAccident_DropDown, yearsNoAccident, true, 1);
                logger.WriteLine($"Selected Years No Accident: {yearsNoAccident}");
            }

            // Continue - using inherited Button from BasePage
            if (Get("continue").Equals("true", StringComparison.OrdinalIgnoreCase))
            {
                await Button.ClickButtonAsync(PAContinue_Button, ActionType.Click, true, 1);
                logger.WriteLine("Clicked Continue on Drivers page.");
                await WaitForPageToBeReadyAsync();
            }

            logger.WriteLine("Successfully filled PA Drivers page data");
        }

        /// <summary>
        /// Overload that accepts custom data dictionary for flexibility
        /// </summary>
        public async Task PADriversDataFillAsync(Dictionary<string, string> data)
        {
            string Get(string key) => data.TryGetValue(key, out var v) ? v : string.Empty;

            await WaitForPageToBeReadyAsync();

            // Gender radio
            var gender = Get("gender");
            if (!string.IsNullOrWhiteSpace(gender))
            {
                await RadioButton.SelectRadioButtonAsync(string.Format(PAgender_Radio, gender), gender, true, 1);
            }

            // Marital status dropdown
            var maritalStatus = Get("maritalstatus");
            if (!string.IsNullOrWhiteSpace(maritalStatus))
            {
                await DropDown.SelectDropDownAsync(PAmaritalStatus_DropDown, maritalStatus, true, 1);
            }

            // Operator type radio
            var operatorType = Get("operatortype");
            if (!string.IsNullOrWhiteSpace(operatorType))
            {
                await RadioButton.SelectRadioButtonAsync(string.Format(PAoperatorType_Radio, operatorType), operatorType, true, 1);
            }

            // Years no accident dropdown
            var yearsNoAccident = Get("numberofyearsnoaccident");
            if (!string.IsNullOrWhiteSpace(yearsNoAccident))
            {
                await DropDown.SelectDropDownAsync(PAnumberOfYearsNoAccident_DropDown, yearsNoAccident, true, 1);
            }

            // Continue
            if (Get("continue").Equals("true", StringComparison.OrdinalIgnoreCase))
            {
                await Button.ClickButtonAsync(PAContinue_Button, ActionType.Click, true, 1);
                await WaitForPageToBeReadyAsync();
            }
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

using System;
using System.Threading.Tasks;
using BDD.Playwright.Origami.Pages.CommonPage;
using BDD.Playwright.Core.Interfaces;
using Microsoft.Playwright;
using Reqnroll;
using BDD.Playwright.GBIZ.PageElements;

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
        public async Task PropertyDatafillAsync(string profileKey = "Property")
        {
            if (_fileReader == null)
            {
                throw new InvalidOperationException("FileReader is not available. Use constructor with IFileReader parameter or call the method with explicit parameters.");
            }

            try
            {
                logger.WriteLine($"=== Starting Property Data Fill using profile: {profileKey} ===");

                var filePath = "Property\\PropertyData.json";

                // Get values from JSON
                var propertyLocatedFlood = _fileReader.GetOptionalValue(filePath, $"{profileKey}.PropertyLocatedFlood");
                var yearOfConstruction = _fileReader.GetOptionalValue(filePath, $"{profileKey}.YearOfConstruction");
                var numberOfFamilies = _fileReader.GetOptionalValue(filePath, $"{profileKey}.NumberOfFamilies");
                var constructionType = _fileReader.GetOptionalValue(filePath, $"{profileKey}.ConstructionType");
                var underConstruction = _fileReader.GetOptionalValue(filePath, $"{profileKey}.UnderConstruction");
                var uniqueConstruction = _fileReader.GetOptionalValue(filePath, $"{profileKey}.UniqueConstruction");
                var logHome = _fileReader.GetOptionalValue(filePath, $"{profileKey}.LogHome");
                var roofType = _fileReader.GetOptionalValue(filePath, $"{profileKey}.RoofType");
                var historicRegisteredHome = _fileReader.GetOptionalValue(filePath, $"{profileKey}.HistoricRegisteredHome");
                var occupancyType = _fileReader.GetOptionalValue(filePath, $"{profileKey}.OccupancyType");
                var fireDepartment = _fileReader.GetOptionalValue(filePath, $"{profileKey}.FireDepartment");
                var protectionClass = _fileReader.GetOptionalValue(filePath, $"{profileKey}.ProtectionClass");
                var primaryHeatType = _fileReader.GetOptionalValue(filePath, $"{profileKey}.PrimaryHeatType");
                var smokeDetector = _fileReader.GetOptionalValue(filePath, $"{profileKey}.SmokeDetector");
                var numBuiltInFireplaces = _fileReader.GetOptionalValue(filePath, $"{profileKey}.NumBuiltInFireplaces");
                var liquidFuel = _fileReader.GetOptionalValue(filePath, $"{profileKey}.LiquidFuel");

                logger.WriteLine($"Retrieved property data - Year: {yearOfConstruction}, Construction Type: {constructionType}");

                // Fill the form with JSON data
                await PropertyDatafillAsync(
                    propertyLocatedFlood,
                    yearOfConstruction,
                    numberOfFamilies,
                    constructionType,
                    underConstruction,
                    uniqueConstruction,
                    logHome,
                    roofType,
                    historicRegisteredHome,
                    occupancyType,
                    fireDepartment,
                    protectionClass,
                    primaryHeatType,
                    smokeDetector,
                    numBuiltInFireplaces,
                    liquidFuel
                );

                logger.WriteLine($"✅ Successfully filled property information using profile: {profileKey}");
                logger.WriteLine("=== Property Data Fill Completed ===");
            }
            catch (Exception ex)
            {
                logger.WriteLine($"❌ Error filling property data: {ex.Message}");
                logger.WriteLine($"Stack Trace: {ex.StackTrace}");
                throw new Exception($"Failed to fill property data using profile '{profileKey}': {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Fills Property data with explicit parameters
        /// </summary>
        public async Task PropertyDatafillAsync(
            string propertyLocatedFlood = null,
            string yearOfConstruction = null,
            string numberOfFamilies = null,
            string constructionType = null,
            string underConstruction = null,
            string uniqueConstruction = null,
            string logHome = null,
            string roofType = null,
            string historicRegisteredHome = null,
            string occupancyType = null,
            string fireDepartment = null,
            string protectionClass = null,
            string primaryHeatType = null,
            string smokeDetector = null,
            string numBuiltInFireplaces = null,
            string liquidFuel = null)
        {
            try
            {
                logger.WriteLine("=== Starting Property Data Fill ===");

                // Wait for page to be ready
                await page.WaitForLoadStateAsync(LoadState.NetworkIdle, new PageWaitForLoadStateOptions
                {
                    Timeout = 30000
                });

                // Property Located in Flood Zone
                if (!string.IsNullOrEmpty(propertyLocatedFlood))
                {
                    logger.WriteLine($"Setting Property Located Flood: {propertyLocatedFlood}");
                    await SelectRadioButtonAsync(PropertyLocatedFlood_Radio, propertyLocatedFlood);
                }

                // Year of Construction
                if (!string.IsNullOrEmpty(yearOfConstruction))
                {
                    logger.WriteLine($"Setting Year of Construction: {yearOfConstruction}");
                    await InputField.SetInputFieldAsync(YearOfConstruction_Input, yearOfConstruction, true, 1);
                }

                // Number of Families
                if (!string.IsNullOrEmpty(numberOfFamilies))
                {
                    logger.WriteLine($"Setting Number of Families: {numberOfFamilies}");
                    await DropDown.SelectDropDownAsync(NumberOfFamilies_DropDown, numberOfFamilies, true, 1);
                }

                // Construction Type (1, 3, or 6)
                if (!string.IsNullOrEmpty(constructionType))
                {
                    logger.WriteLine($"Setting Construction Type: {constructionType}");
                    await SelectRadioButtonAsync(ConstructionType_Radio, constructionType);
                }

                // Under Construction
                if (!string.IsNullOrEmpty(underConstruction))
                {
                    logger.WriteLine($"Setting Under Construction: {underConstruction}");
                    await SelectRadioButtonAsync(UnderConstruction_Radio, underConstruction);
                }

                // Unique Construction
                if (!string.IsNullOrEmpty(uniqueConstruction))
                {
                    logger.WriteLine($"Setting Unique Construction: {uniqueConstruction}");
                    await SelectRadioButtonAsync(UniqueConstruction_Radio, uniqueConstruction);
                }

                // Log Home
                if (!string.IsNullOrEmpty(logHome))
                {
                    logger.WriteLine($"Setting Log Home: {logHome}");
                    await SelectRadioButtonAsync(LogHome_Radio, logHome);
                }

                // Roof Type
                if (!string.IsNullOrEmpty(roofType))
                {
                    logger.WriteLine($"Setting Roof Type: {roofType}");
                    await SelectRadioButtonAsync(RoofType_Radio, roofType);
                }

                // Historic Registered Home
                if (!string.IsNullOrEmpty(historicRegisteredHome))
                {
                    logger.WriteLine($"Setting Historic Registered Home: {historicRegisteredHome}");
                    await SelectRadioButtonAsync(HistoricRegisteredHome_Radio, historicRegisteredHome);
                }

                // Occupancy Type
                if (!string.IsNullOrEmpty(occupancyType))
                {
                    logger.WriteLine($"Setting Occupancy Type: {occupancyType}");
                    await SelectRadioButtonAsync(OccupancyType_Radio, occupancyType);
                }

                // Fire Department
                if (!string.IsNullOrEmpty(fireDepartment))
                {
                    logger.WriteLine($"Setting Fire Department: {fireDepartment}");
                    await InputField.SetInputFieldAsync(FireDepartment_Input, fireDepartment, true, 1);
                }

                // Protection Class
                if (!string.IsNullOrEmpty(protectionClass))
                {
                    logger.WriteLine($"Setting Protection Class: {protectionClass}");
                    await DropDown.SelectDropDownAsync(ProtectionClass_DropDown, protectionClass, true, 1);
                }

                // Primary Heat Type
                if (!string.IsNullOrEmpty(primaryHeatType))
                {
                    logger.WriteLine($"Setting Primary Heat Type: {primaryHeatType}");
                    await DropDown.SelectDropDownAsync(PrimaryHeatType_DropDown, primaryHeatType, true, 1);
                }

                // Smoke Detector
                if (!string.IsNullOrEmpty(smokeDetector) && smokeDetector.Equals("Yes", StringComparison.OrdinalIgnoreCase))
                {
                    logger.WriteLine("Selecting Smoke Detector checkbox");
                    await SelectCheckboxAsync(SmokeDetector_Input);
                }

                // Number of Built-in Fireplaces
                if (!string.IsNullOrEmpty(numBuiltInFireplaces))
                {
                    logger.WriteLine($"Setting Number of Built-in Fireplaces: {numBuiltInFireplaces}");
                    await InputField.SetInputFieldAsync(NumBuiltInFireplaces_Input, numBuiltInFireplaces, true, 1);
                }

                // Liquid Fuel
                if (!string.IsNullOrEmpty(liquidFuel) && liquidFuel.Equals("Yes", StringComparison.OrdinalIgnoreCase))
                {
                    logger.WriteLine("Selecting Liquid Fuel checkbox");
                    await SelectCheckboxAsync(LiquidFuel_Input);
                }

                // Click Continue button
                logger.WriteLine("Clicking Continue Coverage button");
                await ClickContinueButtonAsync();

                logger.WriteLine("✅ Property data fill completed successfully");
                logger.WriteLine("=== Property Data Fill Completed ===");
            }
            catch (Exception ex)
            {
                logger.WriteLine($"❌ Error filling Property data: {ex.Message}");
                logger.WriteLine($"Stack Trace: {ex.StackTrace}");
                throw new Exception($"Failed to fill Property data: {ex.Message}", ex);
            }
        }

        #region Private Helper Methods

        /// <summary>
        /// Selects a radio button using dynamic locator with value
        /// </summary>
        private async Task SelectRadioButtonAsync(string radioButtonTemplate, string value)
        {
            try
            {
                var radioButtonLocator = string.Format(radioButtonTemplate, value);
                var radioButton = page.Locator(radioButtonLocator);

                await radioButton.WaitForAsync(new LocatorWaitForOptions
                {
                    State = WaitForSelectorState.Visible,
                    Timeout = 10000
                });

                var isChecked = await radioButton.IsCheckedAsync();
                if (!isChecked)
                {
                    await radioButton.ClickAsync();
                    logger.WriteLine($"Radio button selected with value: {value}");
                }
                else
                {
                    logger.WriteLine($"Radio button already selected with value: {value}");
                }
            }
            catch (Exception ex)
            {
                logger.WriteLine($"Error selecting radio button with value '{value}': {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Selects a checkbox
        /// </summary>
        private async Task SelectCheckboxAsync(string checkboxLocator)
        {
            try
            {
                var checkbox = page.Locator(checkboxLocator);

                await checkbox.WaitForAsync(new LocatorWaitForOptions
                {
                    State = WaitForSelectorState.Visible,
                    Timeout = 10000
                });

                var isChecked = await checkbox.IsCheckedAsync();
                if (!isChecked)
                {
                    await checkbox.ClickAsync();
                    logger.WriteLine($"Checkbox selected");
                }
                else
                {
                    logger.WriteLine($"Checkbox already selected");
                }
            }
            catch (Exception ex)
            {
                logger.WriteLine($"Error selecting checkbox: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Clicks the Continue Coverage button
        /// </summary>
        private async Task ClickContinueButtonAsync()
        {
            try
            {
                var continueButton = page.Locator(ContinueCoverage);

                await continueButton.WaitForAsync(new LocatorWaitForOptions
                {
                    State = WaitForSelectorState.Visible,
                    Timeout = 10000
                });

                await continueButton.ClickAsync();

                // Wait for page to load after clicking
                await page.WaitForLoadStateAsync(LoadState.NetworkIdle, new PageWaitForLoadStateOptions
                {
                    Timeout = 30000
                });

                // Additional wait for page stability
                await page.WaitForTimeoutAsync(5000);

                logger.WriteLine("Continue Coverage button clicked successfully");
            }
            catch (Exception ex)
            {
                logger.WriteLine($"Error clicking Continue Coverage button: {ex.Message}");
                throw;
            }
        }

        #endregion

        #region Verification Methods

        /// <summary>
        /// Verifies if the Property page is visible
        /// </summary>
        public async Task<bool> IsPropertyPageVisibleAsync()
        {
            try
            {
                var yearInput = page.Locator(YearOfConstruction_Input);
                var isVisible = await yearInput.IsVisibleAsync();

                logger.WriteLine($"Property page visible: {isVisible}");
                return isVisible;
            }
            catch (Exception ex)
            {
                logger.WriteLine($"Error checking Property page visibility: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Gets the Year of Construction value
        /// </summary>
        public async Task<string> GetYearOfConstructionAsync()
        {
            try
            {
                var yearInput = page.Locator(YearOfConstruction_Input);
                var value = await yearInput.GetAttributeAsync("value");
                logger.WriteLine($"Retrieved Year of Construction: {value}");
                return value ?? string.Empty;
            }
            catch (Exception ex)
            {
                logger.WriteLine($"Error getting Year of Construction: {ex.Message}");
                return string.Empty;
            }
        }

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

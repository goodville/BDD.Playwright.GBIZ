using System;
using System.Threading.Tasks;
using BDD.Playwright.Core.Enums;
using BDD.Playwright.Core.Interfaces;
using BDD.Playwright.Origami.Pages.CommonPage;
using Microsoft.Playwright;
using Reqnroll;

namespace BDD.Playwright.GBIZ.Pages.AgentPages
{
    public class Quote_ScheduledPage : BasePage
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly IReqnrollOutputHelper _ReqnrollLogger;
        private readonly IFileReader _fileReader;

        // Constructor with IFileReader support
        public Quote_ScheduledPage(ScenarioContext scenarioContext, IFileReader fileReader, IReqnrollOutputHelper reqnrollOutputHelper) : base(scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _fileReader = fileReader;
            _ReqnrollLogger = reqnrollOutputHelper;
        }

        // Constructor without IFileReader (for backward compatibility)
        public Quote_ScheduledPage(ScenarioContext scenarioContext, IReqnrollOutputHelper reqnrollOutputHelper) : base(scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _ReqnrollLogger = reqnrollOutputHelper;
            _fileReader = null;
        }

        #region XPath Selectors
        public string AddPersonalProperty_Link { get; set; } = "//a[normalize-space()='Add Personal Property']";
        public string PersonalPropertyType_DropDown { get; set; } = "//select[@id='fld_pp_type_1']";
        public string PersonalPropertyDescription_Input { get; set; } = "//input[@id='fld_pp_description_1']";
        public string PersonalPropertyLimit_Input { get; set; } = "//input[@id='fld_pp_limit_1']";
        public string ScheduledSubmit_Button { get; set; } = "//button[@id='buttonscheduled_submitbutton']";
        #endregion

        #region Home Owners Scheduled Info Fill
        
        /// <summary>
        /// Main method to verify and fill the Scheduled Quotes Page
        /// Determines whether to use JSON data or scenario context data
        /// </summary>
        public async Task VerifyScheduledQuotesPageAsync()
        {
            if (_fileReader != null)
            {
                await VerifyScheduledQuotesPageAsync("ScheduledProperty");
            }
            else
            {
                await VerifyScheduledQuotesPageWithContextDataAsync();
            }
        }

        /// <summary>
        /// Verifies and fills the Scheduled Quotes Page using JSON file data
        /// </summary>
        /// <param name="profileKey">Profile key in the JSON file (e.g., "ScheduledProperty", "Jewelry", etc.)</param>
        public async Task VerifyScheduledQuotesPageAsync(string profileKey)
        {
            if (_fileReader == null)
            {
                throw new InvalidOperationException("FileReader is not available. Use constructor with IFileReader parameter.");
            }

            try
            {
                logger.WriteLine($"Starting to fill Scheduled Quotes Page using profile: {profileKey}");

                var filePath = "JsonTestData\\ScheduledProperty\\ScheduledPropertyData.json";

                // Get values from JSON
                var personalPropertyType = _fileReader.GetOptionalValue(filePath, $"{profileKey}.PersonalPropertyType");
                var personalPropertyDescription = _fileReader.GetOptionalValue(filePath, $"{profileKey}.PersonalPropertyDescription");
                var personalPropertyLimit = _fileReader.GetOptionalValue(filePath, $"{profileKey}.PersonalPropertyLimit");

                logger.WriteLine($"Retrieved scheduled property data - Type: {personalPropertyType}, Description: {personalPropertyDescription}, Limit: {personalPropertyLimit}");

                // Store values in scenario context for later use if needed
                if (!string.IsNullOrEmpty(personalPropertyType))
                {
                    _scenarioContext.Set(personalPropertyType, "PersonalPropertyType");
                }

                if (!string.IsNullOrEmpty(personalPropertyDescription))
                {
                    _scenarioContext.Set(personalPropertyDescription, "PersonalPropertyDescription");
                }

                if (!string.IsNullOrEmpty(personalPropertyLimit))
                {
                    _scenarioContext.Set(personalPropertyLimit, "PersonalPropertyLimit");
                }

                // Wait for page to load
                await page.WaitForLoadStateAsync(LoadState.NetworkIdle, new PageWaitForLoadStateOptions
                {
                    Timeout = 30000
                });

                // Scroll to Add Personal Property link
                await page.Locator(AddPersonalProperty_Link).ScrollIntoViewIfNeededAsync();
                
                // Click Add Personal Property link
                await TextLink.ClickTextLinkAsync(AddPersonalProperty_Link, true, 1, "Add Personal Property");
                
                // Wait for form to appear
                await page.WaitForTimeoutAsync(1000);

                // Select Personal Property Type
                await DropDown.SelectDropDownAsync(PersonalPropertyType_DropDown, personalPropertyType, true, 1, "Personal Property Type");

                // Fill Personal Property Description
                await InputField.SetTextAreaInputFieldAsync(PersonalPropertyDescription_Input, personalPropertyDescription, true, 1, "Personal Property Description");

                // Fill Personal Property Limit
                await InputField.SetTextAreaInputFieldAsync(PersonalPropertyLimit_Input, personalPropertyLimit, true, 1, "Personal Property Limit");

                // Click Submit button
                await Button.ClickButtonAsync(ScheduledSubmit_Button, ActionType.Click, true, 1, "Scheduled Submit");

                // Wait for submission to complete
                await page.WaitForLoadStateAsync(LoadState.NetworkIdle, new PageWaitForLoadStateOptions
                {
                    Timeout = 30000
                });

                logger.WriteLine($"Successfully filled and submitted Scheduled Quotes Page using profile: {profileKey}");
                logger.WriteLine("Scheduled Quotes Page Details Entered Successfully from JSON Data");
            }
            catch (Exception ex)
            {
                logger.WriteLine($"Error filling Scheduled Quotes Page from JSON: {ex.Message}");
                throw new Exception($"Failed to fill Scheduled Quotes Page using profile '{profileKey}': {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Verifies and fills the Scheduled Quotes Page using data from scenario context
        /// </summary>
        private async Task VerifyScheduledQuotesPageWithContextDataAsync()
        {
            try
            {
                logger.WriteLine("Starting to fill Scheduled Quotes Page using scenario context data");

                // Get data from scenario context with fallback defaults
                var personalPropertyType = _scenarioContext.ContainsKey("PersonalPropertyType") 
                    ? _scenarioContext.Get<string>("PersonalPropertyType") 
                    : "Jewelry";
                
                var personalPropertyDescription = _scenarioContext.ContainsKey("PersonalPropertyDescription") 
                    ? _scenarioContext.Get<string>("PersonalPropertyDescription") 
                    : "Wedding Ring";
                
                var personalPropertyLimit = _scenarioContext.ContainsKey("PersonalPropertyLimit") 
                    ? _scenarioContext.Get<string>("PersonalPropertyLimit") 
                    : "5000";

                logger.WriteLine($"Retrieved data from context - Type: {personalPropertyType}, Description: {personalPropertyDescription}, Limit: {personalPropertyLimit}");

                // Wait for page to load
                await page.WaitForLoadStateAsync(LoadState.NetworkIdle, new PageWaitForLoadStateOptions
                {
                    Timeout = 30000
                });

                // Scroll to Add Personal Property link
                await page.Locator(AddPersonalProperty_Link).ScrollIntoViewIfNeededAsync();
                
                // Click Add Personal Property link
                await TextLink.ClickTextLinkAsync(AddPersonalProperty_Link, true, 1, "Add Personal Property");
                
                // Wait for form to appear
                await page.WaitForTimeoutAsync(1000);

                // Select Personal Property Type
                await DropDown.SelectDropDownAsync(PersonalPropertyType_DropDown, personalPropertyType, true, 1, "Personal Property Type");

                // Fill Personal Property Description
                await InputField.SetTextAreaInputFieldAsync(PersonalPropertyDescription_Input, personalPropertyDescription, true, 1, "Personal Property Description");

                // Fill Personal Property Limit
                await InputField.SetTextAreaInputFieldAsync(PersonalPropertyLimit_Input, personalPropertyLimit, true, 1, "Personal Property Limit");

                // Click Submit button
                await Button.ClickButtonAsync(ScheduledSubmit_Button, ActionType.Click, true, 1, "Scheduled Submit");

                // Wait for submission to complete
                await page.WaitForLoadStateAsync(LoadState.NetworkIdle, new PageWaitForLoadStateOptions
                {
                    Timeout = 30000
                });

                logger.WriteLine("Successfully filled and submitted Scheduled Quotes Page from context data");
            }
            catch (Exception ex)
            {
                logger.WriteLine($"Error filling Scheduled Quotes Page from context: {ex.Message}");
                throw new Exception($"Failed to fill Scheduled Quotes Page from context: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Verifies and fills the Scheduled Quotes Page with specific parameters
        /// </summary>
        /// <param name="personalPropertyType">Type of personal property</param>
        /// <param name="personalPropertyDescription">Description of personal property</param>
        /// <param name="personalPropertyLimit">Limit for personal property</param>
        public async Task VerifyScheduledQuotesPageAsync(string personalPropertyType, string personalPropertyDescription, string personalPropertyLimit)
        {
            try
            {
                logger.WriteLine("Starting to fill Scheduled Quotes Page with provided parameters");
                logger.WriteLine($"Type: {personalPropertyType}, Description: {personalPropertyDescription}, Limit: {personalPropertyLimit}");

                // Wait for page to load
                await page.WaitForLoadStateAsync(LoadState.NetworkIdle, new PageWaitForLoadStateOptions
                {
                    Timeout = 30000
                });

                // Scroll to Add Personal Property link
                await page.Locator(AddPersonalProperty_Link).ScrollIntoViewIfNeededAsync();
                
                // Click Add Personal Property link
                await TextLink.ClickTextLinkAsync(AddPersonalProperty_Link, true, 1, "Add Personal Property");
                
                // Wait for form to appear
                await page.WaitForTimeoutAsync(1000);

                // Select Personal Property Type
                await DropDown.SelectDropDownAsync(PersonalPropertyType_DropDown, personalPropertyType, true, 1, "Personal Property Type");

                // Fill Personal Property Description
                await InputField.SetTextAreaInputFieldAsync(PersonalPropertyDescription_Input, personalPropertyDescription, true, 1, "Personal Property Description");

                // Fill Personal Property Limit
                await InputField.SetTextAreaInputFieldAsync(PersonalPropertyLimit_Input, personalPropertyLimit, true, 1, "Personal Property Limit");

                // Click Submit button
                await Button.ClickButtonAsync(ScheduledSubmit_Button, ActionType.Click, true, 1, "Scheduled Submit");

                // Wait for submission to complete
                await page.WaitForLoadStateAsync(LoadState.NetworkIdle, new PageWaitForLoadStateOptions
                {
                    Timeout = 30000
                });

                logger.WriteLine("Successfully filled and submitted Scheduled Quotes Page");
            }
            catch (Exception ex)
            {
                logger.WriteLine($"Error filling Scheduled Quotes Page: {ex.Message}");
                throw new Exception($"Failed to fill Scheduled Quotes Page: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Verifies if the Add Personal Property link exists
        /// </summary>
        /// <returns>True if the link exists, false otherwise</returns>
        public async Task<bool> VerifyAddPersonalPropertyLinkExistsAsync()
        {
            try
            {
                logger.WriteLine("Checking if Add Personal Property link exists");
                
                var linkExists = await page.Locator(AddPersonalProperty_Link).CountAsync() > 0;
                
                if (linkExists)
                {
                    logger.WriteLine("✅ Add Personal Property link exists");
                }
                else
                {
                    logger.WriteLine("❌ Add Personal Property link does not exist");
                }
                
                return linkExists;
            }
            catch (Exception ex)
            {
                logger.WriteLine($"Error checking Add Personal Property link: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Verifies if the Scheduled Submit button is enabled
        /// </summary>
        /// <returns>True if the button is enabled, false otherwise</returns>
        public async Task<bool> VerifyScheduledSubmitButtonEnabledAsync()
        {
            try
            {
                logger.WriteLine("Checking if Scheduled Submit button is enabled");
                
                var button = page.Locator(ScheduledSubmit_Button);
                var isEnabled = await button.IsEnabledAsync();
                
                if (isEnabled)
                {
                    logger.WriteLine("✅ Scheduled Submit button is enabled");
                }
                else
                {
                    logger.WriteLine("❌ Scheduled Submit button is disabled");
                }
                
                return isEnabled;
            }
            catch (Exception ex)
            {
                logger.WriteLine($"Error checking Scheduled Submit button: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Gets the current value of Personal Property Type dropdown
        /// </summary>
        /// <returns>Selected value in the dropdown</returns>
        public async Task<string> GetPersonalPropertyTypeAsync()
        {
            try
            {
                logger.WriteLine("Getting Personal Property Type value");
                var dropdown = page.Locator(PersonalPropertyType_DropDown);
                var selectedValue = await dropdown.InputValueAsync();
                logger.WriteLine($"Current Personal Property Type: {selectedValue}");
                return selectedValue;
            }
            catch (Exception ex)
            {
                logger.WriteLine($"Error getting Personal Property Type: {ex.Message}");
                return string.Empty;
            }
        }

        /// <summary>
        /// Gets the current value of Personal Property Description input
        /// </summary>
        /// <returns>Value in the input field</returns>
        public async Task<string> GetPersonalPropertyDescriptionAsync()
        {
            try
            {
                logger.WriteLine("Getting Personal Property Description value");
                var input = page.Locator(PersonalPropertyDescription_Input);
                var value = await input.InputValueAsync();
                logger.WriteLine($"Current Personal Property Description: {value}");
                return value;
            }
            catch (Exception ex)
            {
                logger.WriteLine($"Error getting Personal Property Description: {ex.Message}");
                return string.Empty;
            }
        }

        /// <summary>
        /// Gets the current value of Personal Property Limit input
        /// </summary>
        /// <returns>Value in the input field</returns>
        public async Task<string> GetPersonalPropertyLimitAsync()
        {
            try
            {
                logger.WriteLine("Getting Personal Property Limit value");
                var input = page.Locator(PersonalPropertyLimit_Input);
                var value = await input.InputValueAsync();
                logger.WriteLine($"Current Personal Property Limit: {value}");
                return value;
            }
            catch (Exception ex)
            {
                logger.WriteLine($"Error getting Personal Property Limit: {ex.Message}");
                return string.Empty;
            }
        }

        #endregion
    }
}

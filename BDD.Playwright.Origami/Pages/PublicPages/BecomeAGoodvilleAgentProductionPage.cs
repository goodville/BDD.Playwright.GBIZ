using System;
using System.Threading.Tasks;
using BDD.Playwright.Core.Enums;
using BDD.Playwright.Core.Interfaces;
using BDD.Playwright.Origami.Pages.CommonPage;
using Microsoft.Playwright;
using Reqnroll;

namespace BDD.Playwright.GBIZ.Pages.PublicPages
{
    public class BecomeAGoodvilleAgentProductionPage : BasePage
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly IReqnrollOutputHelper _ReqnrollLogger;
        private readonly IFileReader _fileReader;

        // Constructor with IFileReader support
        public BecomeAGoodvilleAgentProductionPage(ScenarioContext scenarioContext, IFileReader fileReader, IReqnrollOutputHelper reqnrollOutputHelper) : base(scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _fileReader = fileReader;
            _ReqnrollLogger = reqnrollOutputHelper;
        }

        // Constructor without IFileReader (for backward compatibility)
        public BecomeAGoodvilleAgentProductionPage(ScenarioContext scenarioContext, IReqnrollOutputHelper reqnrollOutputHelper) : base(scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _ReqnrollLogger = reqnrollOutputHelper;
            _fileReader = null;
        }

        #region XPath Selectors
        public string NameOfCarrier_Input { get; set; } = "//input[@aria-label='Name of Carrier']";
        public string AddAnotherCarrier_Link { get; set; } = "//*[@class='modifyButton addButton']";
        public string CurrentPremium_Input { get; set; } = "//input[@aria-label='Current Premium Volume ($)']";
        public string AddCarrier_Link { get; set; } = "//a[normalize-space()='Add Carrier']";
        public string ContinueToReview_Button { get; set; } = "//button[normalize-space()='Continue to Review']";
        #endregion

        #region Add Carriers Methods

        /// <summary>
        /// Main method to add carriers - determines whether to use JSON data or scenario context data
        /// </summary>
        public async Task AddCarriersAsync()
        {
            if (_fileReader != null)
            {
                await AddCarriersAsync("AgentProduction");
            }
            else
            {
                await AddCarriersWithContextDataAsync();
            }
        }

        /// <summary>
        /// Adds carriers using JSON file data
        /// </summary>
        /// <param name="profileKey">Profile key in the JSON file (e.g., "AgentProduction", "MultiCarrier", etc.)</param>
        public async Task AddCarriersAsync(string profileKey)
        {
            if (_fileReader == null)
            {
                throw new InvalidOperationException("FileReader is not available. Use constructor with IFileReader parameter.");
            }

            try
            {
                logger.WriteLine($"Starting to add carriers using profile: {profileKey}");

                var filePath = "JsonTestData\\AgentProduction\\AgentProductionData.json";

                // Get number of carriers from JSON
                var noOfCarriersStr = _fileReader.GetOptionalValue(filePath, $"{profileKey}.NoOfCarriers");
                
                if (string.IsNullOrEmpty(noOfCarriersStr) || !int.TryParse(noOfCarriersStr, out var noOfCarriers))
                {
                    logger.WriteLine("No carriers to add or invalid NoOfCarriers value");
                    return;
                }

                logger.WriteLine($"Number of carriers to add: {noOfCarriers}");

                // Wait for page to load
                await page.WaitForLoadStateAsync(LoadState.NetworkIdle, new PageWaitForLoadStateOptions
                {
                    Timeout = 30000
                });

                for (var i = 1; i <= noOfCarriers; i++)
                {
                    logger.WriteLine($"Adding carrier {i} of {noOfCarriers}");

                    // Get carrier data from JSON
                    var carrierName = _fileReader.GetOptionalValue(filePath, $"{profileKey}.Carrier{i}");
                    var premiumVolume = _fileReader.GetOptionalValue(filePath, $"{profileKey}.Premium{i}");

                    if (string.IsNullOrEmpty(carrierName) || string.IsNullOrEmpty(premiumVolume))
                    {
                        logger.WriteLine($"Skipping carrier {i} - missing data");
                        continue;
                    }

                    // Add carrier link click (if not first carrier)
                    if (i > 1)
                    {
                        await TextLink.ClickTextLinkAsync(AddCarrier_Link, true, 1, "Add Carrier");
                        await page.WaitForTimeoutAsync(1000); // Wait for new carrier fields to appear
                    }

                    // Fill carrier name
                    await InputField.SetTextAreaInputFieldAsync(NameOfCarrier_Input, carrierName, true, i, $"Carrier {i} Name");

                    // Fill premium volume
                    await InputField.SetTextAreaInputFieldAsync(CurrentPremium_Input, premiumVolume, true, i, $"Carrier {i} Premium");

                    logger.WriteLine($"Added carrier {i}: {carrierName} with premium ${premiumVolume}");
                }

                logger.WriteLine($"Successfully added {noOfCarriers} carriers using profile: {profileKey}");
            }
            catch (Exception ex)
            {
                logger.WriteLine($"Error adding carriers from JSON: {ex.Message}");
                throw new Exception($"Failed to add carriers using profile '{profileKey}': {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Adds carriers using data from scenario context
        /// </summary>
        private async Task AddCarriersWithContextDataAsync()
        {
            try
            {
                logger.WriteLine("Starting to add carriers using scenario context data");

                // Get number of carriers from context with fallback default
                var noOfCarriers = _scenarioContext.ContainsKey("NoOfCarriers") 
                    ? _scenarioContext.Get<int>("NoOfCarriers") 
                    : 1;

                logger.WriteLine($"Number of carriers to add: {noOfCarriers}");

                // Wait for page to load
                await page.WaitForLoadStateAsync(LoadState.NetworkIdle, new PageWaitForLoadStateOptions
                {
                    Timeout = 30000
                });

                for (var i = 1; i <= noOfCarriers; i++)
                {
                    logger.WriteLine($"Adding carrier {i} of {noOfCarriers}");

                    // Get carrier data from context with fallback defaults
                    var carrierName = _scenarioContext.ContainsKey($"Carrier{i}") 
                        ? _scenarioContext.Get<string>($"Carrier{i}") 
                        : $"Test Carrier {i}";
                    
                    var premiumVolume = _scenarioContext.ContainsKey($"Premium{i}") 
                        ? _scenarioContext.Get<string>($"Premium{i}") 
                        : "50000";

                    // Add carrier link click (if not first carrier)
                    if (i > 1)
                    {
                        await TextLink.ClickTextLinkAsync(AddCarrier_Link, true, 1, "Add Carrier");
                        await page.WaitForTimeoutAsync(1000); // Wait for new carrier fields to appear
                    }

                    // Fill carrier name
                    await InputField.SetTextAreaInputFieldAsync(NameOfCarrier_Input, carrierName, true, i, $"Carrier {i} Name");

                    // Fill premium volume
                    await InputField.SetTextAreaInputFieldAsync(CurrentPremium_Input, premiumVolume, true, i, $"Carrier {i} Premium");

                    logger.WriteLine($"Added carrier {i}: {carrierName} with premium ${premiumVolume}");
                }

                logger.WriteLine($"Successfully added {noOfCarriers} carriers from context data");
            }
            catch (Exception ex)
            {
                logger.WriteLine($"Error adding carriers from context: {ex.Message}");
                throw new Exception($"Failed to add carriers from context: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Adds carriers with specific data provided as parameters
        /// </summary>
        /// <param name="carriers">Array of carrier data (name, premium volume pairs)</param>
        public async Task AddCarriersAsync(params (string name, string premium)[] carriers)
        {
            try
            {
                logger.WriteLine($"Starting to add {carriers.Length} carriers with provided parameters");

                // Wait for page to load
                await page.WaitForLoadStateAsync(LoadState.NetworkIdle, new PageWaitForLoadStateOptions
                {
                    Timeout = 30000
                });

                for (var i = 0; i < carriers.Length; i++)
                {
                    var carrierIndex = i + 1;
                    var (carrierName, premiumVolume) = carriers[i];

                    logger.WriteLine($"Adding carrier {carrierIndex} of {carriers.Length}: {carrierName}");

                    // Add carrier link click (if not first carrier)
                    if (i > 0)
                    {
                        await TextLink.ClickTextLinkAsync(AddCarrier_Link, true, 1, "Add Carrier");
                        await page.WaitForTimeoutAsync(1000); // Wait for new carrier fields to appear
                    }

                    // Fill carrier name
                    await InputField.SetTextAreaInputFieldAsync(NameOfCarrier_Input, carrierName, true, carrierIndex, $"Carrier {carrierIndex} Name");

                    // Fill premium volume
                    await InputField.SetTextAreaInputFieldAsync(CurrentPremium_Input, premiumVolume, true, carrierIndex, $"Carrier {carrierIndex} Premium");

                    logger.WriteLine($"Added carrier {carrierIndex}: {carrierName} with premium ${premiumVolume}");
                }

                logger.WriteLine($"Successfully added {carriers.Length} carriers");
            }
            catch (Exception ex)
            {
                logger.WriteLine($"Error adding carriers: {ex.Message}");
                throw new Exception($"Failed to add carriers: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Clicks the Continue to Review button
        /// </summary>
        public async Task ClickContinueToReviewAsync()
        {
            try
            {
                logger.WriteLine("Clicking Continue to Review button");

                await Button.ClickButtonAsync(ContinueToReview_Button, ActionType.Click, true, 1, "Continue to Review");

                // Wait for page to load after clicking
                await page.WaitForLoadStateAsync(LoadState.NetworkIdle, new PageWaitForLoadStateOptions
                {
                    Timeout = 30000
                });

                logger.WriteLine("Continue to Review button clicked successfully");
            }
            catch (Exception ex)
            {
                logger.WriteLine($"Error clicking Continue to Review button: {ex.Message}");
                throw new Exception($"Failed to click Continue to Review button: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Verifies if the Add Carrier link exists
        /// </summary>
        /// <returns>True if the link exists, false otherwise</returns>
        public async Task<bool> VerifyAddCarrierLinkExistsAsync()
        {
            try
            {
                logger.WriteLine("Checking if Add Carrier link exists");
                
                var linkExists = await page.Locator(AddCarrier_Link).CountAsync() > 0;
                
                if (linkExists)
                {
                    logger.WriteLine("✅ Add Carrier link exists");
                }
                else
                {
                    logger.WriteLine("❌ Add Carrier link does not exist");
                }
                
                return linkExists;
            }
            catch (Exception ex)
            {
                logger.WriteLine($"Error checking Add Carrier link: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Verifies if the Continue to Review button is enabled
        /// </summary>
        /// <returns>True if the button is enabled, false otherwise</returns>
        public async Task<bool> VerifyContinueToReviewButtonEnabledAsync()
        {
            try
            {
                logger.WriteLine("Checking if Continue to Review button is enabled");
                
                var button = page.Locator(ContinueToReview_Button);
                var isEnabled = await button.IsEnabledAsync();
                
                if (isEnabled)
                {
                    logger.WriteLine("✅ Continue to Review button is enabled");
                }
                else
                {
                    logger.WriteLine("❌ Continue to Review button is disabled");
                }
                
                return isEnabled;
            }
            catch (Exception ex)
            {
                logger.WriteLine($"Error checking Continue to Review button: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Gets the current value of a carrier name input
        /// </summary>
        /// <param name="index">Index of the carrier (1-based)</param>
        /// <returns>Carrier name value</returns>
        public async Task<string> GetCarrierNameAsync(int index = 1)
        {
            try
            {
                logger.WriteLine($"Getting Carrier {index} name value");
                var inputs = await page.Locator(NameOfCarrier_Input).AllAsync();
                
                if (index <= inputs.Count)
                {
                    var value = await inputs[index - 1].InputValueAsync();
                    logger.WriteLine($"Carrier {index} name: {value}");
                    return value;
                }
                
                logger.WriteLine($"Carrier {index} not found");
                return string.Empty;
            }
            catch (Exception ex)
            {
                logger.WriteLine($"Error getting Carrier {index} name: {ex.Message}");
                return string.Empty;
            }
        }

        /// <summary>
        /// Gets the current value of a carrier premium input
        /// </summary>
        /// <param name="index">Index of the carrier (1-based)</param>
        /// <returns>Premium volume value</returns>
        public async Task<string> GetCarrierPremiumAsync(int index = 1)
        {
            try
            {
                logger.WriteLine($"Getting Carrier {index} premium value");
                var inputs = await page.Locator(CurrentPremium_Input).AllAsync();
                
                if (index <= inputs.Count)
                {
                    var value = await inputs[index - 1].InputValueAsync();
                    logger.WriteLine($"Carrier {index} premium: ${value}");
                    return value;
                }
                
                logger.WriteLine($"Carrier {index} not found");
                return string.Empty;
            }
            catch (Exception ex)
            {
                logger.WriteLine($"Error getting Carrier {index} premium: {ex.Message}");
                return string.Empty;
            }
        }

        /// <summary>
        /// Gets the total number of carriers currently added
        /// </summary>
        /// <returns>Number of carriers</returns>
        public async Task<int> GetCarrierCountAsync()
        {
            try
            {
                logger.WriteLine("Getting total carrier count");
                var count = await page.Locator(NameOfCarrier_Input).CountAsync();
                logger.WriteLine($"Total carriers: {count}");
                return count;
            }
            catch (Exception ex)
            {
                logger.WriteLine($"Error getting carrier count: {ex.Message}");
                return 0;
            }
        }

        #endregion
    }
}

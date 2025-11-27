using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BDD.Playwright.Origami.Pages.CommonPage;
using BDD.Playwright.Core.Interfaces;
using Microsoft.Playwright;
using Reqnroll;
using BDD.Playwright.GBIZ.Pages.CommonPage;

namespace BDD.Playwright.GBIZ.Pages.AgentPages
{
    public class Quote_PriorCarriersPage : BasePage
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly IReqnrollOutputHelper _ReqnrollLogger;
        private readonly IFileReader _fileReader;

        /// <summary>
        /// Constructor with IFileReader support for data-driven tests
        /// </summary>
        public Quote_PriorCarriersPage(ScenarioContext scenarioContext, IFileReader fileReader, IReqnrollOutputHelper ReqnrollOutputHelper) : base(scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _fileReader = fileReader;
            _ReqnrollLogger = ReqnrollOutputHelper;
        }

        /// <summary>
        /// Constructor without IFileReader for direct parameter-based tests
        /// </summary>
        public Quote_PriorCarriersPage(ScenarioContext scenarioContext, IReqnrollOutputHelper ReqnrollOutputHelper) : base(scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _ReqnrollLogger = ReqnrollOutputHelper;
            _fileReader = null;
        }

        #region XPath Selectors
        public string PriorCarriers_Link { get; set; } = "//a[normalize-space()='Prior Carriers']";
        public string PriorCarrierLossYear_Input { get; set; } = "//input[@id='fld_newCarrier_LossYear']";
        public string PriorCarrierName_Input { get; set; } = "//input[@id='fld_newCarrier_Carrier']";
        public string PriorCarrierPolicyNumber_Input { get; set; } = "//input[@id='fld_newCarrier_PolicyNumber']";
        public string PriorCarrierAnnualPremium_Input { get; set; } = "//input[@id='fld_newCarrier_AnnualPremium']";
        public string PriorCarrierModFactor_Input { get; set; } = "//input[@id='fld_newCarrier_ModFactor']";
        public string PriorCarrierQuestionNo_Radio { get; set; } = "//input[contains(@id,'priorC_question') and @value=\"No\"]";
        public string PriorCarrierQuestionYes_Radio { get; set; } = "//input[contains(@id,'priorC_question') and @value=\"Yes\"]";
        #endregion

        /// <summary>
        /// Fills Workers Compensation Prior Carriers data using JSON file
        /// </summary>
        /// <param name="profileKey">Profile key to read from JSON file (default: "PriorCarriers")</param>
        public async Task WorkersCompPriorCarriersDatafillAsync(string profileKey = "PriorCarriers")
        {
            if (_fileReader == null)
            {
                throw new InvalidOperationException("FileReader is not available. Use constructor with IFileReader parameter or call the method with explicit parameters.");
            }

            try
            {
                logger.WriteLine($"=== Starting Workers Comp Prior Carriers Data Fill using profile: {profileKey} ===");

                var filePath = "PriorCarriers\\PriorCarriersData.json";

                // Get values from JSON
                var lossYear = _fileReader.GetOptionalValue(filePath, $"{profileKey}.LossYear");
                var carrierName = _fileReader.GetOptionalValue(filePath, $"{profileKey}.CarrierName");
                var policyNumber = _fileReader.GetOptionalValue(filePath, $"{profileKey}.PolicyNumber");
                var annualPremium = _fileReader.GetOptionalValue(filePath, $"{profileKey}.AnnualPremium");
                var modFactor = _fileReader.GetOptionalValue(filePath, $"{profileKey}.ModFactor");
                var questionAnswer = _fileReader.GetOptionalValue(filePath, $"{profileKey}.QuestionAnswer");

                logger.WriteLine($"Retrieved prior carriers data - Loss Year: {lossYear}, Carrier: {carrierName}");

                // Fill the form with JSON data
                await WorkersCompPriorCarriersDatafillAsync(lossYear, carrierName, policyNumber, annualPremium, modFactor, questionAnswer);

                logger.WriteLine($"✅ Successfully filled prior carriers information using profile: {profileKey}");
                logger.WriteLine("=== Workers Comp Prior Carriers Data Fill Completed ===");
            }
            catch (Exception ex)
            {
                logger.WriteLine($"❌ Error filling prior carriers data: {ex.Message}");
                logger.WriteLine($"Stack Trace: {ex.StackTrace}");
                throw new Exception($"Failed to fill prior carriers data using profile '{profileKey}': {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Fills Workers Compensation Prior Carriers data with explicit parameters
        /// </summary>
        /// <param name="lossYear">Loss Year value</param>
        /// <param name="carrierName">Carrier Name value</param>
        /// <param name="policyNumber">Policy Number value</param>
        /// <param name="annualPremium">Annual Premium value</param>
        /// <param name="modFactor">Mod Factor value</param>
        /// <param name="questionAnswer">Question Answer ('Yes' or 'No', default: 'No')</param>
        public async Task WorkersCompPriorCarriersDatafillAsync(
            string lossYear = null,
            string carrierName = null,
            string policyNumber = null,
            string annualPremium = null,
            string modFactor = null,
            string questionAnswer = "No")
        {
            try
            {
                logger.WriteLine("=== Starting Workers Comp Prior Carriers Data Fill ===");

                // Wait for page to be ready
                await page.WaitForLoadStateAsync(LoadState.NetworkIdle, new PageWaitForLoadStateOptions
                {
                    Timeout = 30000
                });

                // Additional wait for page stability
                await page.WaitForTimeoutAsync(3000);

                // Click Prior Carriers link
                logger.WriteLine("Navigating to Prior Carriers section");
                await ClickPriorCarriersLinkAsync();
                
                // Wait for Prior Carriers section to load
                await page.WaitForTimeoutAsync(2000);

                // Fill in Loss Year if provided
                if (!string.IsNullOrEmpty(lossYear))
                {
                    logger.WriteLine($"Setting Loss Year: {lossYear}");
                    await InputField.SetInputFieldAsync(PriorCarrierLossYear_Input, lossYear, true, 1);
                }

                // Fill in Carrier Name if provided
                if (!string.IsNullOrEmpty(carrierName))
                {
                    logger.WriteLine($"Setting Carrier Name: {carrierName}");
                    await InputField.SetInputFieldAsync(PriorCarrierName_Input, carrierName, true, 1);
                }

                // Fill in Policy Number if provided
                if (!string.IsNullOrEmpty(policyNumber))
                {
                    logger.WriteLine($"Setting Policy Number: {policyNumber}");
                    await InputField.SetInputFieldAsync(PriorCarrierPolicyNumber_Input, policyNumber, true, 1);
                }

                // Fill in Annual Premium if provided
                if (!string.IsNullOrEmpty(annualPremium))
                {
                    logger.WriteLine($"Setting Annual Premium: {annualPremium}");
                    await InputField.SetInputFieldAsync(PriorCarrierAnnualPremium_Input, annualPremium, true, 1);
                }

                // Fill in Mod Factor if provided
                if (!string.IsNullOrEmpty(modFactor))
                {
                    logger.WriteLine($"Setting Mod Factor: {modFactor}");
                    await InputField.SetInputFieldAsync(PriorCarrierModFactor_Input, modFactor, true, 1);
                }

                // Select radio button for question
                if (!string.IsNullOrEmpty(questionAnswer))
                {
                    logger.WriteLine($"Selecting '{questionAnswer}' for Prior Carrier question");
                    await SelectQuestionRadioButtonAsync(questionAnswer);
                }

                logger.WriteLine("✅ Workers Comp Prior Carriers data fill completed successfully");
                logger.WriteLine("=== Workers Comp Prior Carriers Data Fill Completed ===");
            }
            catch (Exception ex)
            {
                logger.WriteLine($"❌ Error filling Workers Comp Prior Carriers data: {ex.Message}");
                logger.WriteLine($"Stack Trace: {ex.StackTrace}");
                throw new Exception($"Failed to fill Workers Comp Prior Carriers data: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Clicks the Prior Carriers link to navigate to the section
        /// </summary>
        public async Task ClickPriorCarriersLinkAsync()
        {
            try
            {
                logger.WriteLine("Clicking Prior Carriers link");
                var priorCarriersLink = page.Locator(PriorCarriers_Link);
                
                // Scroll into view if needed
                await priorCarriersLink.ScrollIntoViewIfNeededAsync();
                
                // Wait for link to be visible
                await priorCarriersLink.WaitForAsync(new LocatorWaitForOptions
                {
                    State = WaitForSelectorState.Visible,
                    Timeout = 10000
                });
                
                await priorCarriersLink.ClickAsync();
                
                // Wait for section to load
                await page.WaitForTimeoutAsync(2000);
                
                logger.WriteLine("Prior Carriers link clicked successfully");
            }
            catch (Exception ex)
            {
                logger.WriteLine($"Error clicking Prior Carriers link: {ex.Message}");
                throw new Exception($"Failed to click Prior Carriers link: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Selects the radio button for Prior Carrier question
        /// </summary>
        /// <param name="answer">Answer to select ('Yes' or 'No')</param>
        private async Task SelectQuestionRadioButtonAsync(string answer)
        {
            try
            {
                var radioButtonLocator = answer.Equals("Yes", StringComparison.OrdinalIgnoreCase)
                    ? PriorCarrierQuestionYes_Radio
                    : PriorCarrierQuestionNo_Radio;

                var radioButton = page.Locator(radioButtonLocator);
                
                // Wait for radio button to be available
                await radioButton.WaitForAsync(new LocatorWaitForOptions
                {
                    State = WaitForSelectorState.Visible,
                    Timeout = 10000
                });

                // Check if not already selected
                var isChecked = await radioButton.IsCheckedAsync();
                if (!isChecked)
                {
                    await radioButton.ClickAsync();
                    logger.WriteLine($"'{answer}' radio button selected successfully");
                }
                else
                {
                    logger.WriteLine($"'{answer}' radio button is already selected");
                }
            }
            catch (Exception ex)
            {
                logger.WriteLine($"Error selecting '{answer}' radio button: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Verifies if the Prior Carriers section is visible
        /// </summary>
        public async Task<bool> IsPriorCarriersSectionVisibleAsync()
        {
            try
            {
                var lossYearInput = page.Locator(PriorCarrierLossYear_Input);
                var isVisible = await lossYearInput.IsVisibleAsync();
                
                logger.WriteLine($"Prior Carriers section visible: {isVisible}");
                return isVisible;
            }
            catch (Exception ex)
            {
                logger.WriteLine($"Error checking Prior Carriers section visibility: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Gets the entered value from Loss Year field
        /// </summary>
        public async Task<string> GetLossYearAsync()
        {
            try
            {
                var lossYearInput = page.Locator(PriorCarrierLossYear_Input);
                var value = await lossYearInput.GetAttributeAsync("value");
                logger.WriteLine($"Retrieved Loss Year value: {value}");
                return value ?? string.Empty;
            }
            catch (Exception ex)
            {
                logger.WriteLine($"Error getting Loss Year: {ex.Message}");
                return string.Empty;
            }
        }

        /// <summary>
        /// Gets the entered value from Carrier Name field
        /// </summary>
        public async Task<string> GetCarrierNameAsync()
        {
            try
            {
                var carrierNameInput = page.Locator(PriorCarrierName_Input);
                var value = await carrierNameInput.GetAttributeAsync("value");
                logger.WriteLine($"Retrieved Carrier Name value: {value}");
                return value ?? string.Empty;
            }
            catch (Exception ex)
            {
                logger.WriteLine($"Error getting Carrier Name: {ex.Message}");
                return string.Empty;
            }
        }

        /// <summary>
        /// Clears all Prior Carriers fields
        /// </summary>
        public async Task ClearPriorCarriersFieldsAsync()
        {
            try
            {
                logger.WriteLine("Clearing all Prior Carriers fields");

                await page.Locator(PriorCarrierLossYear_Input).FillAsync("");
                await page.Locator(PriorCarrierName_Input).FillAsync("");
                await page.Locator(PriorCarrierPolicyNumber_Input).FillAsync("");
                await page.Locator(PriorCarrierAnnualPremium_Input).FillAsync("");
                await page.Locator(PriorCarrierModFactor_Input).FillAsync("", new LocatorFillOptions
                {
                    Timeout = 5000 // Set a specific timeout for this action
                });

                logger.WriteLine("All Prior Carriers fields cleared successfully");
            }
            catch (Exception ex)
            {
                logger.WriteLine($"Error clearing Prior Carriers fields: {ex.Message}");
                throw new Exception($"Failed to clear Prior Carriers fields: {ex.Message}", ex);
            }
        }
    }
}

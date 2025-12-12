
using BDD.Playwright.Origami.Pages.CommonPage;
using BDD.Playwright.Core.Interfaces;
using BDD.Playwright.GBIZ.PageElements;
using Reqnroll;
using System;
using System.Threading.Tasks;
using Microsoft.Playwright;
using BDD.Playwright.Core.Enums;
using BDD.Playwright.GBIZ.Pages.CommonPage;

namespace BDD.Playwright.GBIZ.Pages.AgentPages
{
    public class Claims_FarmownerPage : BasePage
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly IFileReader _fileReader;
        
        // PageElement instances
        private readonly InputField InputField;
        private readonly DropDown DropDown;
        private readonly Button Button;

        // Constructor - migrated to Playwright pattern
        public Claims_FarmownerPage(ScenarioContext scenarioContext, IFileReader fileReader) : base(scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _fileReader = fileReader;
            
            // Initialize PageElements
            InputField = new InputField(scenarioContext);
            DropDown = new DropDown(scenarioContext);
            Button = new Button(scenarioContext);
        }

        #region XPath Selectors
        public string Date_Claims { get; set; } = "//input[@id='fld_claim_lossDate']";
        public string Type_Claims { get; set; } = "//select[@name='claim_type']";
        public string Amount_Claims { get; set; } = "//input[@id='fld_claim_lossAmount']";
        public string Description_Claims { get; set; } = "//textarea[@id='fld_claim_description' and @name='claim_description' and @class='inputtextbox' and @tabindex='1']";
        public string AddClaim_button { get; set; } = "//button[@id='claims']";
        #endregion

        /// <summary>
        /// Fills Farmowner Claims page data using the provided profile key from JSON file.
        /// </summary>
        public async Task ClaimsFarmOwnerPageAsync(string profileKey = "FarmOwnerClaims")
        {
            if (_fileReader == null)
            {
                throw new InvalidOperationException("FileReader is not available. Use constructor with IFileReader parameter.");
            }

            try
            {
                logger.WriteLine($"Starting to fill Farmowner Claims data using profile: {profileKey}");

                var filePath = "Claims\\FarmOwnerClaimsData.json";

                // Get values from JSON
                var claimDate = _fileReader.GetOptionalValue(filePath, $"{profileKey}.Date");
                var claimType = _fileReader.GetOptionalValue(filePath, $"{profileKey}.Type");
                var claimAmount = _fileReader.GetOptionalValue(filePath, $"{profileKey}.Amount");
                var claimDescription = _fileReader.GetOptionalValue(filePath, $"{profileKey}.Description");

                logger.WriteLine($"Retrieved Farmowner Claims data - Date: {claimDate}, Type: {claimType}");

                // Fill the form with JSON data
                await InputField.SetTextAreaInputFieldAsync(Date_Claims, claimDate, true, 1, "Claim Date");
                await DropDown.SelectDropDownAsync(Type_Claims, claimType, true, 1, "Claim Type");
                await InputField.SetTextAreaInputFieldAsync(Amount_Claims, claimAmount, true, 1, "Claim Amount");
                await InputField.SetTextAreaInputFieldAsync(Description_Claims, claimDescription, true, 1, "Claim Description");
                await Button.ClickButtonAsync(AddClaim_button, ActionType.Click, true, 1);

                logger.WriteLine($"Successfully filled Farmowner Claims data using profile: {profileKey}");
                logger.WriteLine("Farmowner Claims Page Details Entered Successfully from JSON Data");
            }
            catch (Exception ex)
            {
                logger.WriteLine($"Error filling Farmowner Claims data: {ex.Message}");
                throw new Exception($"Failed to fill Farmowner Claims data using profile '{profileKey}': {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Synchronous wrapper for backward compatibility
        /// </summary>
        public void ClaimsFarmoWnErPaGE()
        {
            ClaimsFarmOwnerPageAsync().GetAwaiter().GetResult();
        }

        /// <summary>
        /// Overload that accepts custom data values for flexibility
        /// </summary>
        public async Task ClaimsFarmOwnerPageAsync(string date, string type, string amount, string description)
        {
            try
            {
                logger.WriteLine("Starting to fill Farmowner Claims data with custom values");

                await InputField.SetTextAreaInputFieldAsync(Date_Claims, date, true, 1, "Claim Date");
                await DropDown.SelectDropDownAsync(Type_Claims, type, true, 1, "Claim Type");
                await InputField.SetTextAreaInputFieldAsync(Amount_Claims, amount, true, 1, "Claim Amount");
                await InputField.SetTextAreaInputFieldAsync(Description_Claims, description, true, 1, "Claim Description");
                await Button.ClickButtonAsync(AddClaim_button, ActionType.Click, true, 1);

                logger.WriteLine("Successfully filled Farmowner Claims data with custom values");
            }
            catch (Exception ex)
            {
                logger.WriteLine($"Error filling Farmowner Claims data: {ex.Message}");
                throw new Exception($"Failed to fill Farmowner Claims data: {ex.Message}", ex);
            }
        }
    }
}

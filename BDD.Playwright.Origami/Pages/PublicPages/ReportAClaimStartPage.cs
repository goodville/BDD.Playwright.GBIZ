using BDD.Playwright.Core.Interfaces;
using BDD.Playwright.GBIZ.Pages.CommonPage;
using Microsoft.Playwright;
using Reqnroll;
using System;
using System.Reflection.Emit;
using System.Threading;

namespace BDD.Playwright.GBIZ.Pages.PublicPages
{
    public class ReportAClaimStartPage : BasePage
    {
        private readonly IReqnrollOutputHelper _ReqnrollLogger;
        private readonly FeatureContext _featureContext;
        private readonly ScenarioContext _scenarioContext;
        private readonly IFileReader _fileReader;
        //public BaseElement _baseElement;
        // Constructor
        public ReportAClaimStartPage(ScenarioContext scenarioContext, IFileReader fileReader) : base(scenarioContext)
        {
            _fileReader = fileReader;
            // _baseElement = new BaseElement(scenarioContext);
        }

        public string PolicyNumber_Input => "//input[@id='pcyInput']";
        public string ZipCode_Input => "//input[@id='zip']";
        public string OccurrenceDate_Input => "//input[@id='occDate']";
        public string ErrorMessage_Text => "//div[@class='errorAlertText']";

        public async Task EnterPolicyDetailsInReportAClaimStartPageAsync(string profileKey)
        {
            if (_fileReader == null)
            {
                throw new InvalidOperationException("FileReader is not available. Use constructor with IFileReader parameter.");
            }

            try
            {
                logger.WriteLine($"Starting to fill PolicyDetailsInReportAClaimStartPage information using profile: {profileKey}");

                var filePath = "ReportAClaimStartPage\\ReportAClaimStartPage.json";

                // Get values from JSON - Quote Details
                var policyNumber_Input = _fileReader.GetOptionalValue(filePath, $"{profileKey}.policyNumber_Input");
                var zipCode_Input = _fileReader.GetOptionalValue(filePath, $"{profileKey}.zipCode_Input");
                var dateOfLoss = _fileReader.GetOptionalValue(filePath, $"{profileKey}.DateOfLoss");

                await InputField.SetTextAreaInputFieldAsync(PolicyNumber_Input, policyNumber_Input, true, 1);
                await InputField.SetTextAreaInputFieldAsync(ZipCode_Input, zipCode_Input, true, 1);
                await InputField.SetTextAreaInputFieldAsync(OccurrenceDate_Input, dateOfLoss, true, 1);
                logger.WriteLine($"Retrieved PolicyDetailsInReportAClaimStartPage data for:{policyNumber_Input} {zipCode_Input}{OccurrenceDate_Input} ");

                logger.WriteLine($"Successfully filled PolicyDetailsInReportAClaimStartPage information using profile: {profileKey}");
                logger.WriteLine("PolicyDetailsInReportAClaimStartPage Details Entered Successfully from JSON Data");
            }
            catch (Exception ex)
            {
                logger.WriteLine($"Error filling Tradesman Cover data: {ex.Message}");
                throw new Exception($"Failed to fill Tradesman Cover data using profile '{profileKey}': {ex.Message}", ex);
            }
        }
        public async Task EnterPolicyDetailsWithHardcodedDataAsync()
        {
            try
            {
                logger.WriteLine("Filling Policy Details with hardcoded data...");

                var policyNumber = "ABC12345";
                var zipCode = "60007";
                var dateOfLoss = DateTime.Now.AddDays(0).ToString("MMddyyyy");

                await InputField.SetTextAreaInputFieldAsync(PolicyNumber_Input, policyNumber, true, 1);
                await InputField.SetTextAreaInputFieldAsync(ZipCode_Input, zipCode, true, 1);
                await InputField.SetTextAreaInputFieldAsync(OccurrenceDate_Input, dateOfLoss, true, 1);

                logger.WriteLine($"Hardcoded Data Entered: PolicyNumber={policyNumber}, ZipCode={zipCode}");
            }
            catch (Exception ex)
            {
                logger.WriteLine($"Error entering hardcoded data: {ex.Message}");
                throw;
            }
        }

        public async Task EnterPolicyDetailsInReportsAClaimStartPageAsync(string profileKey)
        {
            if (_fileReader == null)
            {
                throw new InvalidOperationException("FileReader is not available. Use constructor with IFileReader parameter.");
            }

            try
            {
                logger.WriteLine($"Starting to fill PolicyDetailsInReportAClaimStartPage information using profile: {profileKey}");
                var filePath = "ReportAClaimStartPage\\ReportAClaimStartPage.json";
                var policyNumber_Input = _fileReader.GetOptionalValue(filePath, $"{profileKey}.policyNumber_Input");
                var zipCode_Input = _fileReader.GetOptionalValue(filePath, $"{profileKey}.zipCode_Input");
                await InputField.SetTextAreaInputFieldAsync(PolicyNumber_Input, policyNumber_Input, true, 2);
                await InputField.SetTextAreaInputFieldAsync(ZipCode_Input, zipCode_Input, true, 2);

                logger.WriteLine($"Policy Number: {policyNumber_Input}, Zip Code: {zipCode_Input} entered successfully.");
            }
            catch (Exception ex)
            {
                throw new Exception($"Error while filling PolicyDetailsInReportAClaimStartPage for profile {profileKey}: {ex.Message}", ex);
            }
        }
    }
}

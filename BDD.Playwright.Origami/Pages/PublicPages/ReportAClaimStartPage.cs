using BDD.Playwright.Core.Interfaces;
using BDD.Playwright.GBIZ.Pages.CommonPage;
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
                var policyNumber_Input = _fileReader.GetOptionalValue(filePath, $"{profileKey}.PolicyNumber");
                var zipCode_Input = _fileReader.GetOptionalValue(filePath, $"{profileKey}.ZipCode");

                await InputField.SetTextAreaInputFieldAsync(PolicyNumber_Input, policyNumber_Input, true, 1);
                await InputField.SetTextAreaInputFieldAsync(ZipCode_Input, zipCode_Input, true, 1);
                await InputField.SetTextAreaInputFieldAsync(OccurrenceDate_Input, DateTime.Now.AddDays(Convert.ToInt32()).ToString("MMddyyyy"), true, 1);

                /* if (commonFunctions.AccountName_LabelAndValue.Item2 != "Agents")
                {
                    IFrame.switchToIframe();
                    Checkbox.SelectCheckbox(_commonXpath.ReCaptcha_CheckBox, true, true, 1);
                    Thread.Sleep(3000);
                    IFrame.close();
                }*/
                logger.WriteLine($"Retrieved PolicyDetailsInReportAClaimStartPage data for:{policyNumber_Input} {zipCode_Input} ");

                // Note: Form filling implementation would go here using the same pattern as BasicInformationPage
                // with the page elements (Button, InputField, DropDown, etc.) once they are properly resolved

                logger.WriteLine($"Successfully filled PolicyDetailsInReportAClaimStartPage information using profile: {profileKey}");
                logger.WriteLine("PolicyDetailsInReportAClaimStartPage Details Entered Successfully from JSON Data");
            }
            catch (Exception ex)
            {
                logger.WriteLine($"Error filling Tradesman Cover data: {ex.Message}");
                throw new Exception($"Failed to fill Tradesman Cover data using profile '{profileKey}': {ex.Message}", ex);
            }
        }

        public async Task EnterPolicyDetailsInMakeAPaymentStartPageAsync(string profileKey)
        {
            if (_fileReader == null)
            {
                throw new InvalidOperationException("FileReader is not available. Use constructor with IFileReader parameter.");
            }

            try
            {
                logger.WriteLine($"Starting to fill PolicyDetailsInMakeAPaymentStartPage information using profile: {profileKey}");

                var filePath = "ReportAClaimStartPage\\MakeAPaymentStartPage.json";

                // Get values from JSON - Quote Details
                var policyNumber_Input = _fileReader.GetOptionalValue(filePath, $"{profileKey}.PolicyNumber");
                var zipCode_Input = _fileReader.GetOptionalValue(filePath, $"{profileKey}.ZipCode");

                await InputField.SetTextAreaInputFieldAsync(PolicyNumber_Input, policyNumber_Input, true, 2);
                await InputField.SetTextAreaInputFieldAsync(ZipCode_Input, zipCode_Input, true, 2);
                /*IFrame.switchToIframe();
                Checkbox.SelectCheckbox(_commonXpath.ReCaptcha_CheckBox, true, true, 1);
                Thread.Sleep(3000);
                IFrame.close();*/
                logger.WriteLine($"Retrieved PolicyDetailsInMakeAPaymentStartPage data for: {policyNumber_Input} {zipCode_Input}");

                // Note: Form filling implementation would go here using the same pattern as BasicInformationPage
                // with the page elements (Button, InputField, DropDown, etc.) once they are properly resolved

                logger.WriteLine($"Successfully filled PolicyDetailsInMakeAPaymentStartPage information using profile: {profileKey}");
                logger.WriteLine("PolicyDetailsnMakeAPaymentStartPage Entered Successfully from JSON Data");
            }
            catch (Exception ex)
            {
                logger.WriteLine($"Error filling PolicyDetailsInMakeAPaymentStartPage data: {ex.Message}");
                throw new Exception($"Failed to fill PolicyDetailsInMakeAPaymentStartPage data using profile '{profileKey}': {ex.Message}", ex);
            }
        }
    }
}

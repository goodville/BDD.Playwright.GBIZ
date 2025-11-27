using BDD.Playwright.Core.Interfaces;
using BDD.Playwright.GBIZ.PageElements;
using BDD.Playwright.GBIZ.Pages.CommonPage;
using BDD.Playwright.GBIZ.Pages.GlobalPages;
using BDD.Playwright.GBIZ.Pages.XpathProperties;
using Microsoft.Playwright;
using Reqnroll;
using System;
using System.Threading.Tasks;

namespace BDD.Playwright.GBIZ.Pages.AgentsPages
{
    public class PersonalAutoQuoteInformation : BasePage
    {
        private readonly IFileReader _fileReader;
        private readonly ScenarioContext _scenarioContext;
        private readonly LoginPage _loginPage;
        public FeatureContext _featureContext;
        public CommonXpath _commonXpath;

        public PersonalAutoQuoteInformation(
            ScenarioContext scenarioContext,
            LoginPage loginPage,
            IFileReader fileReader,
            CommonXpath commonXpath
        ) : base(scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _fileReader = fileReader;
            _loginPage = loginPage;
            _commonXpath = commonXpath;
        }

        #region Xpath
        public string QuoteInformedInsured_Checkbox => "//label[normalize-space()='I have informed the insured']";
        public string QuoteType_Dropdown => "//select[@name='quoteType']";
        public string Producer_Dropdown => "//select[@name='prefillProducer']";
        public string InsuredFirstName_Input => "//input[@name='prefillFirstName']";
        public string InsuredMiddleName_Input => "//input[@name='prefillMiddleName']";
        public string InsuredLastName_Input => "//input[@name='prefillLastName']";
        public string InsuredSuffix_Dropdown => "//select[@name='prefillSuffix']";
        public string InsuredSSN_Input => "//input[@name='prefillSocialSecurityNumber']";
        public string InsuredDOB_Input => "//input[@name='prefillDateOfBirth']";
        public string InsuredLicenseNumber_Input => "//input[@name='prefillLicenseNumber']";
        public string InsuredLicensedState_Dropdown => "//select[@name='prefillLicensedState']";
        public string InsuredAddress1_Input => "//input[@name='prefillAddress1']";
        public string InsuredAddress2_Input => "//input[@name='prefillAddress2']";
        public string InsuredCity_Input => "//input[@name='prefillCity']";
        public string InsuredZip_Input => "//input[@name='prefillZip']";
        public string InformedApplicant_Checkbox => "//strong[contains(text(),'I have informed the applicant that an auto data pr')]";
        public string InformedApplicant_Checkbox1 => "//strong[contains(text(),'I have informed the applicant that an auto data prefill report will be ordered through LexisNexis to look up vehicle, driver, and coverage information.')]";
        public string OrderData_Button => "//button[@id='buttonid_OrderData']";
        #endregion

        public async Task PersonalAutonewQuotePrefillAsync(string profileKey)
        {
            var filePath = "PAQuoteInformation\\PAQuoteInformation.json";
            // Get all needed field values from JSON
            var informedInsured = _fileReader.GetOptionalValue(filePath, $"{profileKey}.InformationInsured");
            var quoteType = _fileReader.GetOptionalValue(filePath, $"{profileKey}.QuoteType");
            var producer = _fileReader.GetOptionalValue(filePath, $"{profileKey}.Producer");
            var firstName = _fileReader.GetOptionalValue(filePath, $"{profileKey}.FirstName");
            var middleName = _fileReader.GetOptionalValue(filePath, $"{profileKey}.MiddleName");
            var lastName = _fileReader.GetOptionalValue(filePath, $"{profileKey}.LastName");
            var suffix = _fileReader.GetOptionalValue(filePath, $"{profileKey}.Suffix");
            var ssn = _fileReader.GetOptionalValue(filePath, $"{profileKey}.SSN");
            var dob = _fileReader.GetOptionalValue(filePath, $"{profileKey}.DOB");
            var licenseNumber = _fileReader.GetOptionalValue(filePath, $"{profileKey}.DriverLicenseNumber");
            var licensedState = _fileReader.GetOptionalValue(filePath, $"{profileKey}.LicensedState");
            var address1 = _fileReader.GetOptionalValue(filePath, $"{profileKey}.Address");
            var address2 = _fileReader.GetOptionalValue(filePath, $"{profileKey}.QuoteAddress2");
            var city = _fileReader.GetOptionalValue(filePath, $"{profileKey}.City");
            var zip = _fileReader.GetOptionalValue(filePath, $"{profileKey}.Zip");
            var informedApplicant = _fileReader.GetOptionalValue(filePath, $"{profileKey}.InformedApplicant");

            // Simulate your logic, calling Playwright-enabled helper methods
            if (informedInsured == "Yes")
            {
                await Checkbox.VerifyCheckboxExistAsync(QuoteInformedInsured_Checkbox, true, 1, "I have informed the insured");
                await Label.VerifyTextAsync(QuoteInformedInsured_Checkbox, "I have informed the insured", true, 1);
                await Button.ClickButtonAsync(QuoteInformedInsured_Checkbox, ActionType.Click, true, 1);
            }

            await DropDown.SelectDropDownAsync(QuoteType_Dropdown, quoteType, true, 1);
            await DropDown.SelectDropDownAsync(Producer_Dropdown, producer, true, 1);
            await InputField.SetTextAreaInputFieldAsync(InsuredFirstName_Input, firstName, true, 1);
            await InputField.SetTextAreaInputFieldAsync(InsuredMiddleName_Input, middleName, true, 1);
            await InputField.SetTextAreaInputFieldAsync(InsuredLastName_Input, lastName, true, 1);
            if (!string.IsNullOrEmpty(suffix))
            {
                await DropDown.SelectDropDownAsync(InsuredSuffix_Dropdown, suffix, true, 1);
            }

            await InputField.SetTextAreaInputFieldAsync(InsuredSSN_Input, ssn, true, 1);
            await InputField.SetTextAreaInputFieldAsync(InsuredDOB_Input, dob, true, 1);
            await InputField.SetTextAreaInputFieldAsync(InsuredLicenseNumber_Input, licenseNumber, true, 1);
            if (!string.IsNullOrEmpty(licensedState))
            {
                await DropDown.SelectDropDownAsync(InsuredLicensedState_Dropdown, licensedState, true, 1);
            }

            await InputField.SetTextAreaInputFieldAsync(InsuredAddress1_Input, address1, true, 1);
            // If you want address2, uncomment line below:
            // await InputField.SetTextAreaInputFieldAsync(_page, InsuredAddress2_Input, address2, true, 1);
            await InputField.SetTextAreaInputFieldAsync(InsuredCity_Input, city, true, 1);
            await InputField.SetTextAreaInputFieldAsync(InsuredZip_Input, zip, true, 1);

            if (informedApplicant == "Yes")
            {
                await Checkbox.VerifyCheckboxExistAsync(InformedApplicant_Checkbox, true, 1, "I have informed the applicant");
                await Label.VerifyTextAsync(InformedApplicant_Checkbox1, "I have informed the applicant that an auto data prefill report will be ordered through LexisNexis to look up vehicle, driver, and coverage information.", true, 1);
                await Button.ClickButtonAsync(InformedApplicant_Checkbox, ActionType.Click, true, 1);
            }
        }

        public async Task ClickOrderDataAsync()
        {
            await Button.ClickButtonAsync(OrderData_Button, ActionType.Click, true, 1);
        }
    }
}
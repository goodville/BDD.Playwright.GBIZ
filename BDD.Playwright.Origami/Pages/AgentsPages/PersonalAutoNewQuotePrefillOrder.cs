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
    public class PersonalAutoNewQuotePrefillOrder : BasePage
    {
        private readonly ScenarioContext _scenarioContext;
        public FeatureContext _featureContext;
        public CommonXpath _commonXpath;
        public LoginPage _loginPage;
        private readonly IFileReader _fileReader;

        public PersonalAutoNewQuotePrefillOrder(
            ScenarioContext scenarioContext,
            LoginPage loginPage,
            CommonXpath commonXpath,
            IFileReader fileReader
        ) : base(scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _loginPage = loginPage;
            _commonXpath = commonXpath;
            _fileReader = fileReader;
        }

        public string InformedInsured_Checkbox => "//label[normalize-space()='I have informed the insured']";
        public string PrefillProducer_Dropdown => "//select[@name='prefillProducer']";
        public string PrefillFirstName_Input => "//input[@name='prefillFirstName']";
        public string PrefillMiddleName_Input => "//input[@name='prefillMiddleName']";
        public string PrefillLastName_Input => "//input[@name='prefillLastName']";
        public string PrefillSuffix_Dropdown => "//select[@name='prefillSuffix']";
        public string PrefillSSN_Input => "//input[@name='prefillSocialSecurityNumber']";
        public string PrefillDOB_Input => "//input[@name='prefillDateOfBirth']";
        public string PrefillLicenseNumber_Input => "//input[@name='prefillLicenseNumber']";
        public string PrefillLicensedState_Dropdown => "//select[@name='prefillLicensedState']";
        public string PrefillAddress1_Input => "//input[@name='prefillAddress1']";
        public string PrefillAddress2_Input => "//input[@name='prefillAddress2']";
        public string PrefillCity_Input => "//input[@name='prefillCity']";
        public string PrefillZip_Input => "//input[@name='prefillZip']";
        public string InformedApplicant_Checkbox => "//strong[contains(text(),'I have informed the applicant that an auto data pr')]";
        public string OrderData_Button => "//button[@id='buttonid_OrderData']";
        // error messages
        public string FCRAInformed_ErrorMsg => "//div[@id='FCRAInformedError']";
        public string Producer_ErrorMsg => "//div[@id='producerError']";
        public string FirstName_ErrorMsg => "//div[@id='fNameError']";
        public string LastName_ErrorMsg => "//div[@id='lNameError']";
        public string Address_ErrorMsg => "//div[@id='addrError']";
        public string ZipCode_ErrorMsg => "//div[@id='zipError']";
        public string PrefillInformed_ErrorMsg => "//div[@id='prefillInformedError']";

        // The Playwright version using JSON file data
        public async Task PersonalAutonewQuotePrefillAsync(string profileKey)
        {
            if (_fileReader == null)
            {
                throw new InvalidOperationException("FileReader is not available. Use constructor with IFileReader parameter.");
            }

            var filePath = "PANewQuotePrefillOrderPage\\PANewQuotePrefillOrderPage.json";
            var informedInsured = _fileReader.GetOptionalValue(filePath, $"{profileKey}.InformedInsured");
            if (informedInsured == "Yes")
            {
                await RadioButton.SelectRadioButtonAsync(InformedInsured_Checkbox,"InformedUnsured", true, 1);
            }

            var prefillProducer = _fileReader.GetOptionalValue(filePath, $"{profileKey}.PrefillProducer");
            await DropDown.SelectDropDownAsync(PrefillProducer_Dropdown, prefillProducer, true, 1);

            var prefillFirstName = _fileReader.GetOptionalValue(filePath, $"{profileKey}.PrefillFirstName");
            await InputField.SetTextAreaInputFieldAsync(PrefillFirstName_Input, prefillFirstName, true, 1);

            var prefillMiddleName = _fileReader.GetOptionalValue(filePath, $"{profileKey}.PrefillMiddleName");
            await InputField.SetTextAreaInputFieldAsync(PrefillMiddleName_Input, prefillMiddleName, true, 1);

            var prefillLastName = _fileReader.GetOptionalValue(filePath, $"{profileKey}.PrefillLastName");
            await InputField.SetTextAreaInputFieldAsync(PrefillLastName_Input, prefillLastName, true, 1);

            var prefillSuffix = _fileReader.GetOptionalValue(filePath, $"{profileKey}.PrefillSuffix");
            if (!string.IsNullOrEmpty(prefillSuffix))
            {
                await DropDown.SelectDropDownAsync(PrefillSuffix_Dropdown, prefillSuffix, true, 1);
            }

            var prefillSSN = _fileReader.GetOptionalValue(filePath, $"{profileKey}.PrefillSSN");
            await InputField.SetTextAreaInputFieldAsync(PrefillSSN_Input, prefillSSN, true, 1);

            var prefillDOB = _fileReader.GetOptionalValue(filePath, $"{profileKey}.PrefillDOB");
            await InputField.SetTextAreaInputFieldAsync(PrefillDOB_Input, prefillDOB, true, 1);

            var prefillLicenseNumber = _fileReader.GetOptionalValue(filePath, $"{profileKey}.PrefillLicenseNumber");
            await InputField.SetTextAreaInputFieldAsync(PrefillLicenseNumber_Input, prefillLicenseNumber, true, 1);

            var prefillLicensedState = _fileReader.GetOptionalValue(filePath, $"{profileKey}.PrefillLicensedState");
            if (!string.IsNullOrEmpty(prefillLicensedState))
            {
                await DropDown.SelectDropDownAsync(PrefillLicensedState_Dropdown, prefillLicensedState, true, 1);
            }

            var prefillAddress1 = _fileReader.GetOptionalValue(filePath, $"{profileKey}.PrefillAddress1");
            await InputField.SetTextAreaInputFieldAsync(PrefillAddress1_Input, prefillAddress1, true, 1);

            var prefillAddress2 = _fileReader.GetOptionalValue(filePath, $"{profileKey}.PrefillAddress2");
            await InputField.SetTextAreaInputFieldAsync(PrefillAddress2_Input, prefillAddress2, true, 1);

            var prefillCity = _fileReader.GetOptionalValue(filePath, $"{profileKey}.PrefillCity");
            await InputField.SetTextAreaInputFieldAsync(PrefillCity_Input, prefillCity, true, 1);

            var prefillZip = _fileReader.GetOptionalValue(filePath, $"{profileKey}.PrefillZip");
            await InputField.SetTextAreaInputFieldAsync(PrefillZip_Input, prefillZip, true, 1);

            var informedApplicant = _fileReader.GetOptionalValue(filePath, $"{profileKey}.InformedApplicant");
            if (informedApplicant == "Yes")
            {
                await RadioButton.SelectRadioButtonAsync(InformedApplicant_Checkbox, "InformedApplicant", true, 1);
            }
        }

        public async Task ClickOrderDataAsync()
        {
            
            await Button.ClickButtonAsync(OrderData_Button, ActionType.Click, true, 1);
            
        }

        public async Task ClickCancelAsync()
        {
            
            await Button.ClickButtonAsync(_commonXpath.CancelButton, ActionType.Click, true, 1);
            
        }

        public async Task VerifyErrorMessagesDisplayedAsync()
        {
            await Label.VerifyLabelExistAsync(FCRAInformed_ErrorMsg, true, 1);
            await Label.VerifyLabelExistAsync(Producer_ErrorMsg, true, 1);
            await Label.VerifyLabelExistAsync(FirstName_ErrorMsg, true, 1);
            await Label.VerifyLabelExistAsync(LastName_ErrorMsg, true, 1);
            await Label.VerifyLabelExistAsync(Address_ErrorMsg, true, 1);
            await Label.VerifyLabelExistAsync(ZipCode_ErrorMsg, true, 1);
            await Label.VerifyLabelExistAsync(PrefillInformed_ErrorMsg, true, 1);
            
        }
    }
}
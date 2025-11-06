using BDD.Playwright.Origami.PageElements;
using BDD.Playwright.Origami.Pages.CommonPage;
using BDD.Playwright.Core.Interfaces;
using BDD.Playwright.GBIZ.PageElements;
using Reqnroll;
using System;
using System.Threading.Tasks;
using Microsoft.Playwright;

namespace BDD.Playwright.Origami.Pages.AgentPages
{
    public class Quote_PABindingPage : BasePage
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly IFileReader _fileReader;
        
        // PageElement instances
        private readonly InputField InputField;
        private readonly DropDown DropDown;
        private readonly RadioButton RadioButton;
        private readonly Checkbox Checkbox;
        private readonly Button Button;

        // Constructor - migrated to Playwright pattern
        public Quote_PABindingPage(ScenarioContext scenarioContext, IFileReader fileReader) : base(scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _fileReader = fileReader;
            
            // Initialize PageElements
            InputField = new InputField(scenarioContext);
            DropDown = new DropDown(scenarioContext);
            RadioButton = new RadioButton(scenarioContext);
            Checkbox = new Checkbox(scenarioContext);
            Button = new Button(scenarioContext);
        }

        #region XPath Selectors

        public string PAbookofbusiness_Inp { get; set; } = "//input[@id='fld_binding_bookofbusinesstext']";
        public string PAOffice_Drp { get; set; } = "//select[@id='fld_binding_office']";
        public string PAProducer_Drp { get; set; } = "//select[@id='fld_binding_producer']";
        public string PAAgentEmail_Input { get; set; } = "//input[@id='fld_applicationEmail']";
        public string PAbinding_phone_Inp { get; set; } = "//input[@id='fld_binding_phone']";
        public string PAbinding_employer_Input { get; set; } = "//input[@id='fld_binding_employer']";
        public string PAbinding_employeryears_Input { get; set; } = "//input[@id='fld_binding_employeryears']";

        public string PAbinding_carmodified_Radio { get; set; } = "//input[contains(@name,'binding_carmodified') and @value='{0}']";
        public string PAbinding_transportGoods_Radio { get; set; } = "//input[contains(@name,'binding_transportGoods') and @value='{0}']";
        public string PAbinding_carexistingdamage_Radio { get; set; } = "//input[contains(@name,'binding_carexistingdamage') and @value='{0}']";
        public string PAbinding_carparked_Radio { get; set; } = "//input[contains(@name,'binding_carparked') and @value='{0}']";
        public string PAbinding_militaryservice_Radio { get; set; } = "//input[contains(@name,'binding_militaryservice') and @value='{0}']";
        public string PAbinding_otherautoinsurance_Radio { get; set; } = "//input[contains(@name,'binding_otherautoinsurance') and @value='{0}']";
        public string PAbinding_coveragecanceled_Radio { get; set; } = "//input[contains(@name,'binding_coveragecanceled') and @value='{0}']";
        public string PAbinding_brokeredbusiness_Radio { get; set; } = "//input[contains(@name,'binding_brokeredbusiness') and @value='{0}']";
        public string PAbinding_yearsknown_Input { get; set; } = "//input[@id='fld_binding_yearsknown']";
        public string PAbinding_licenserevoked_Radio { get; set; } = "//input[contains(@name,'binding_licenserevoked') and @value='{0}']";
        public string PAbinding_insurancetransfered_Radio { get; set; } = "//input[contains(@name,'binding_insurancetransfered') and @value='{0}']";
        public string PAbinding_driverimpairment_Radio { get; set; } = "//input[contains(@name,'binding_driverimpairment') and @value='{0}']";

        public string PABindingDestinationemail { get; set; } = "//input[@name='binding_destinationemail' and @value='{0}']";

        public string PAbinding_remarks_TextArea { get; set; } = "//textarea[@id='fld_binding_remarks']";

        public string PAAgreeTerms { get; set; } = "//input[@name='binding_agreetoterms']";
        public string PAoccupationDropDown { get; set; } = "//select[@id='fld_binding_occupationDropDown']";

        #endregion

        /// <summary>
        /// Fills PA Binding data using the provided profile key from JSON file.
        /// </summary>
        public async Task PABindingDataFillAsync(string profileKey = "PABinding")
        {
            if (_fileReader == null)
            {
                throw new InvalidOperationException("FileReader is not available. Use constructor with IFileReader parameter.");
            }

            try
            {
                logger.WriteLine($"Starting to fill PA Binding data using profile: {profileKey}");

                var filePath = "PABinding\\PABindingData.json";

                // Get values from JSON
                var bookOfBusiness = _fileReader.GetOptionalValue(filePath, $"{profileKey}.BookOfBusiness");
                var office = _fileReader.GetOptionalValue(filePath, $"{profileKey}.Office");
                var producer = _fileReader.GetOptionalValue(filePath, $"{profileKey}.Producer");
                var agentEmail = _fileReader.GetOptionalValue(filePath, $"{profileKey}.AgentEmail");
                var phone = _fileReader.GetOptionalValue(filePath, $"{profileKey}.Phone");
                var occupation = _fileReader.GetOptionalValue(filePath, $"{profileKey}.Occupation");
                var employer = _fileReader.GetOptionalValue(filePath, $"{profileKey}.Employer");
                var employerYears = _fileReader.GetOptionalValue(filePath, $"{profileKey}.EmployerYears");
                var carModified = _fileReader.GetOptionalValue(filePath, $"{profileKey}.CarModified");
                var transportGoods = _fileReader.GetOptionalValue(filePath, $"{profileKey}.TransportGoods");
                var carExistingDamage = _fileReader.GetOptionalValue(filePath, $"{profileKey}.CarExistingDamage");
                var carParked = _fileReader.GetOptionalValue(filePath, $"{profileKey}.CarParked");
                var militaryService = _fileReader.GetOptionalValue(filePath, $"{profileKey}.MilitaryService");
                var otherAutoInsurance = _fileReader.GetOptionalValue(filePath, $"{profileKey}.OtherAutoInsurance");
                var coverageCanceled = _fileReader.GetOptionalValue(filePath, $"{profileKey}.CoverageCanceled");
                var brokeredBusiness = _fileReader.GetOptionalValue(filePath, $"{profileKey}.BrokeredBusiness");
                var yearsKnown = _fileReader.GetOptionalValue(filePath, $"{profileKey}.YearsKnown");
                var licenseRevoked = _fileReader.GetOptionalValue(filePath, $"{profileKey}.LicenseRevoked");
                var insuranceTransferred = _fileReader.GetOptionalValue(filePath, $"{profileKey}.InsuranceTransferred");
                var driverImpairment = _fileReader.GetOptionalValue(filePath, $"{profileKey}.DriverImpairment");
                var destinationEmail = _fileReader.GetOptionalValue(filePath, $"{profileKey}.DestinationEmail");
                var remarks = _fileReader.GetOptionalValue(filePath, $"{profileKey}.Remarks");

                logger.WriteLine($"Retrieved PA Binding data for: {bookOfBusiness}");

                // Fill the form with JSON data
                await InputField.SetInputFieldAsync(PAbookofbusiness_Inp, bookOfBusiness, true, 1);
                await DropDown.SelectDropDownAsync(PAOffice_Drp, office, true, 1);
                await DropDown.SelectDropDownAsync(PAProducer_Drp, producer, true, 1);
                await InputField.SetInputFieldAsync(PAAgentEmail_Input, agentEmail, true, 1);

                if (!string.IsNullOrEmpty(phone))
                {
                    await InputField.SetInputFieldAsync(PAbinding_phone_Inp, phone, true, 1);
                }

                await DropDown.SelectDropDownAsync(PAoccupationDropDown, occupation, true, 1);
                await InputField.SetInputFieldAsync(PAbinding_employer_Input, employer, true, 1);
                await InputField.SetInputFieldAsync(PAbinding_employeryears_Input, employerYears, true, 1);

                await RadioButton.SelectRadioButtonAsync(string.Format(PAbinding_carmodified_Radio, carModified), carModified, true, 1);
                await RadioButton.SelectRadioButtonAsync(string.Format(PAbinding_transportGoods_Radio, transportGoods), transportGoods, true, 1);
                await RadioButton.SelectRadioButtonAsync(string.Format(PAbinding_carexistingdamage_Radio, carExistingDamage), carExistingDamage, true, 1);
                await RadioButton.SelectRadioButtonAsync(string.Format(PAbinding_carparked_Radio, carParked), carParked, true, 1);
                await RadioButton.SelectRadioButtonAsync(string.Format(PAbinding_militaryservice_Radio, militaryService), militaryService, true, 1);
                await RadioButton.SelectRadioButtonAsync(string.Format(PAbinding_otherautoinsurance_Radio, otherAutoInsurance), otherAutoInsurance, true, 1);
                await RadioButton.SelectRadioButtonAsync(string.Format(PAbinding_coveragecanceled_Radio, coverageCanceled), coverageCanceled, true, 1);
                await RadioButton.SelectRadioButtonAsync(string.Format(PAbinding_brokeredbusiness_Radio, brokeredBusiness), brokeredBusiness, true, 1);
                await InputField.SetInputFieldAsync(PAbinding_yearsknown_Input, yearsKnown, true, 1);
                await RadioButton.SelectRadioButtonAsync(string.Format(PAbinding_licenserevoked_Radio, licenseRevoked), licenseRevoked, true, 1);
                await RadioButton.SelectRadioButtonAsync(string.Format(PAbinding_insurancetransfered_Radio, insuranceTransferred), insuranceTransferred, true, 1);
                await RadioButton.SelectRadioButtonAsync(string.Format(PAbinding_driverimpairment_Radio, driverImpairment), driverImpairment, true, 1);

                await RadioButton.SelectRadioButtonAsync(string.Format(PABindingDestinationemail, destinationEmail), destinationEmail, true, 1);

                await InputField.SetTextAreaInputFieldAsync(PAbinding_remarks_TextArea, remarks, true, 1);

                await Checkbox.SelectCheckboxAsync(PAAgreeTerms, true, true, 1);

                logger.WriteLine($"Successfully filled PA Binding data using profile: {profileKey}");
                logger.WriteLine("PA Binding Page Details Entered Successfully from JSON Data");
            }
            catch (Exception ex)
            {
                logger.WriteLine($"Error filling PA Binding data: {ex.Message}");
                throw new Exception($"Failed to fill PA Binding data using profile '{profileKey}': {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Synchronous wrapper for backward compatibility
        /// </summary>
        public void PABindingDataFill()
        {
            PABindingDataFillAsync().GetAwaiter().GetResult();
        }
    }
}

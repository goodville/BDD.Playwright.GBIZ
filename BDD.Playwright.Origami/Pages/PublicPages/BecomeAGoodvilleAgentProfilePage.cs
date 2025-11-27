using System;
using System.Threading.Tasks;
using BDD.Playwright.Core.Enums;
using BDD.Playwright.Core.Interfaces;
using BDD.Playwright.GBIZ.PageElements;
using BDD.Playwright.GBIZ.Pages.CommonPage;
using BDD.Playwright.Origami.Pages.CommonPage;
using Microsoft.Playwright;
using Reqnroll;

namespace BDD.Playwright.GBIZ.Pages.PublicPages
{
    public class BecomeAGoodvilleAgentProfilePage : BasePage
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly IReqnrollOutputHelper _ReqnrollLogger;
        private readonly IFileReader _fileReader;

        // Constructor with IFileReader support
        public BecomeAGoodvilleAgentProfilePage(ScenarioContext scenarioContext, IFileReader fileReader, IReqnrollOutputHelper reqnrollOutputHelper) : base(scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _fileReader = fileReader;
            _ReqnrollLogger = reqnrollOutputHelper;
        }

        // Constructor without IFileReader (for backward compatibility)
        public BecomeAGoodvilleAgentProfilePage(ScenarioContext scenarioContext, IReqnrollOutputHelper reqnrollOutputHelper) : base(scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _ReqnrollLogger = reqnrollOutputHelper;
            _fileReader = null;
        }

        #region XPath Selectors
        public string AgencyName_Input { get; set; } = "//input[@id='gg-input-0']";
        public string Proprietorship_RadioButton { get; set; } = "//gg-radio-button[@value='Sole Proprietorship']";
        public string Partnership_RadioButton { get; set; } = "//gg-radio-button[contains(@value,'Partnership')]";
        public string Corporation_RadioButton { get; set; } = "//gg-radio-button[contains(@value,'Corporation')]";
        public string YearsInBusiness_Input { get; set; } = "//input[@formcontrolname='yearsInBusiness']";
        public string FirstName_Input { get; set; } = "//input[@id='gg-input-2']";
        public string LastName_Input { get; set; } = "//input[@id='gg-input-3']";
        public string Principal_RadioButton { get; set; } = "//gg-radio-button[@value='Principal']";
        public string Other_RadioButton { get; set; } = "//gg-radio-button[@id='gg-radio-7']";
        public string Street_Input { get; set; } = "//input[@id='gg-input-4']";
        public string City_Input { get; set; } = "//input[@id='gg-input-5']";
        public string State_Dropdown { get; set; } = "//input[@id='gg-input-6']";
        public string Select_StateDropDown { get; set; } = "//*[@id=\"gg-combobox-0\"]";
        public string ZipCode_Input { get; set; } = "//input[@id='gg-input-7']";
        public string ContactPhone_Input { get; set; } = "//input[@id='gg-input-8']";
        public string ContactFax_Input { get; set; } = "//input[@id='gg-input-9']";
        public string EmailAddress_Input { get; set; } = "//input[@id='gg-input-10']";
        public string WebsiteAddress_Input { get; set; } = "//input[@id='gg-input-11']";
        public string CurrentLongTermInterests_TextArea { get; set; } = "//textarea[@id='gg-input-12']";
        public string LearnAboutGoodville_TextArea { get; set; } = "//textarea[@id='gg-input-13']";
        public string Continue_Button { get; set; } = "//button[normalize-space()='Continue']";
        #endregion

        #region Add Agency Details Profile Methods

        /// <summary>
        /// Main method to add agency details - determines whether to use JSON data or scenario context data
        /// </summary>
        public async Task AddAgencyDetailsProfileAsync()
        {
            if (_fileReader != null)
            {
                await AddAgencyDetailsProfileAsync("AgentProfile");
            }
            else
            {
                await AddAgencyDetailsProfileWithContextDataAsync();
            }
        }

        /// <summary>
        /// Adds agency details using JSON file data
        /// </summary>
        /// <param name="profileKey">Profile key in the JSON file (e.g., "AgentProfile", "CorporateProfile", etc.)</param>
        public async Task AddAgencyDetailsProfileAsync(string profileKey)
        {
            if (_fileReader == null)
            {
                throw new InvalidOperationException("FileReader is not available. Use constructor with IFileReader parameter.");
            }

            try
            {
                logger.WriteLine($"Starting to add agency details using profile: {profileKey}");

                var filePath = "AgentProfile\\AgentProfileData.json";

                // Get values from JSON
                var agencyName = _fileReader.GetOptionalValue(filePath, $"{profileKey}.AgencyName");
                var businessType = _fileReader.GetOptionalValue(filePath, $"{profileKey}.BusinessType");
                var yearsInBusiness = _fileReader.GetOptionalValue(filePath, $"{profileKey}.YearsInBusiness");
                var firstName = _fileReader.GetOptionalValue(filePath, $"{profileKey}.FirstName");
                var lastName = _fileReader.GetOptionalValue(filePath, $"{profileKey}.LastName");
                var title = _fileReader.GetOptionalValue(filePath, $"{profileKey}.Title");
                var street = _fileReader.GetOptionalValue(filePath, $"{profileKey}.Street");
                var city = _fileReader.GetOptionalValue(filePath, $"{profileKey}.City");
                var state = _fileReader.GetOptionalValue(filePath, $"{profileKey}.State");
                var zipCode = _fileReader.GetOptionalValue(filePath, $"{profileKey}.ZipCode");
                var contactPhone = _fileReader.GetOptionalValue(filePath, $"{profileKey}.ContactPhone");
                var contactFax = _fileReader.GetOptionalValue(filePath, $"{profileKey}.ContactFax");
                var emailAddress = _fileReader.GetOptionalValue(filePath, $"{profileKey}.EmailAddress");
                var websiteAddress = _fileReader.GetOptionalValue(filePath, $"{profileKey}.WebsiteAddress");
                var currentLongTermInterests = _fileReader.GetOptionalValue(filePath, $"{profileKey}.CurrentLongTermInterests");
                var learnAboutGoodville = _fileReader.GetOptionalValue(filePath, $"{profileKey}.LearnAboutGoodville");

                logger.WriteLine($"Retrieved agency profile data for: {agencyName}");

                // Wait for page to load
                await page.WaitForLoadStateAsync(LoadState.NetworkIdle, new PageWaitForLoadStateOptions
                {
                    Timeout = 30000
                });

                // Fill Agency Name
                await InputField.SetTextAreaInputFieldAsync(AgencyName_Input, agencyName, true, 1, "Agency Name");

                await SelectBusinessTypeAsync(businessType);

                // Fill Years in Business
                await InputField.SetTextAreaInputFieldAsync(YearsInBusiness_Input, yearsInBusiness, true, 1, "Years in Business");

                // Fill First Name
                await InputField.SetTextAreaInputFieldAsync(FirstName_Input, firstName, true, 1, "First Name");

                // Fill Last Name
                await InputField.SetTextAreaInputFieldAsync(LastName_Input, lastName, true, 1, "Last Name");

                // Select Title
                await SelectTitleAsync(title);

                // Fill Street Address
                await InputField.SetTextAreaInputFieldAsync(Street_Input, street, true, 1, "Street");

                // Fill City
                await InputField.SetTextAreaInputFieldAsync(City_Input, city, true, 1, "City");

                // Select State
                await InputField.SetDropdownFieldForListLoadAsync(State_Dropdown, state, true, 1, "State");

                await Button.ClickButtonAsync(Select_StateDropDown, ActionType.Click, true, 1);

                // Fill Zip Code
                await InputField.SetTextAreaInputFieldAsync(ZipCode_Input, zipCode, true, 1, "Zip Code");

                // Fill Contact Phone
                await InputField.SetTextAreaInputFieldAsync(ContactPhone_Input, contactPhone, true, 1, "Contact Phone");

                // Fill Contact Fax
                await InputField.SetTextAreaInputFieldAsync(ContactFax_Input, contactFax, true, 1, "Contact Fax");

                // Fill Email Address
                await InputField.SetTextAreaInputFieldAsync(EmailAddress_Input, emailAddress, true, 1, "Email Address");

                // Fill Website Address
                await InputField.SetTextAreaInputFieldAsync(WebsiteAddress_Input, websiteAddress, true, 1, "Website Address");

                // Fill Current Long Term Interests
                await InputField.SetTextAreaInputFieldAsync(CurrentLongTermInterests_TextArea, currentLongTermInterests, true, 1, "Current Long Term Interests");

                // Fill Learn About Goodville
                await InputField.SetTextAreaInputFieldAsync(LearnAboutGoodville_TextArea, learnAboutGoodville, true, 1, "Learn About Goodville");

                logger.WriteLine($"Successfully added agency details using profile: {profileKey}");
                logger.WriteLine("Agency Profile Details Entered Successfully from JSON Data");
            }
            catch (Exception ex)
            {
                logger.WriteLine($"Error adding agency details from JSON: {ex.Message}");
                throw new Exception($"Failed to add agency details using profile '{profileKey}': {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Adds agency details using data from scenario context
        /// </summary>
        private async Task AddAgencyDetailsProfileWithContextDataAsync()
        {
            try
            {
                logger.WriteLine("Starting to add agency details using scenario context data");

                // Get data from scenario context with fallback defaults
                var agencyName = _scenarioContext.ContainsKey("AgencyName") 
                    ? _scenarioContext.Get<string>("AgencyName") 
                    : "Test Insurance Agency";
                
                var businessType = _scenarioContext.ContainsKey("BusinessType") 
                    ? _scenarioContext.Get<string>("BusinessType") 
                    : "Sole Proprietorship";
                
                var yearsInBusiness = _scenarioContext.ContainsKey("YearsInBusiness") 
                    ? _scenarioContext.Get<string>("YearsInBusiness") 
                    : "5";
                
                var firstName = _scenarioContext.ContainsKey("FirstName") 
                    ? _scenarioContext.Get<string>("FirstName") 
                    : "John";
                
                var lastName = _scenarioContext.ContainsKey("LastName") 
                    ? _scenarioContext.Get<string>("LastName") 
                    : "Doe";
                
                var title = _scenarioContext.ContainsKey("Title") 
                    ? _scenarioContext.Get<string>("Title") 
                    : "Principal";
                
                var street = _scenarioContext.ContainsKey("Street") 
                    ? _scenarioContext.Get<string>("Street") 
                    : "123 Main Street";
                
                var city = _scenarioContext.ContainsKey("City") 
                    ? _scenarioContext.Get<string>("City") 
                    : "Springfield";
                
                var state = _scenarioContext.ContainsKey("State") 
                    ? _scenarioContext.Get<string>("State") 
                    : "Illinois";
                
                var zipCode = _scenarioContext.ContainsKey("ZipCode") 
                    ? _scenarioContext.Get<string>("ZipCode") 
                    : "62701";
                
                var contactPhone = _scenarioContext.ContainsKey("ContactPhone") 
                    ? _scenarioContext.Get<string>("ContactPhone") 
                    : "(217) 555-1234";
                
                var contactFax = _scenarioContext.ContainsKey("ContactFax") 
                    ? _scenarioContext.Get<string>("ContactFax") 
                    : "(217) 555-1235";
                
                var emailAddress = _scenarioContext.ContainsKey("EmailAddress") 
                    ? _scenarioContext.Get<string>("EmailAddress") 
                    : "john.doe@testagency.com";
                
                var websiteAddress = _scenarioContext.ContainsKey("WebsiteAddress") 
                    ? _scenarioContext.Get<string>("WebsiteAddress") 
                    : "www.testagency.com";
                
                var currentLongTermInterests = _scenarioContext.ContainsKey("CurrentLongTermInterests") 
                    ? _scenarioContext.Get<string>("CurrentLongTermInterests") 
                    : "Expanding commercial lines and increasing market share";
                
                var learnAboutGoodville = _scenarioContext.ContainsKey("LearnAboutGoodville") 
                    ? _scenarioContext.Get<string>("LearnAboutGoodville") 
                    : "Industry referral and strong reputation";

                logger.WriteLine($"Retrieved agency profile data from context: {agencyName}");

                // Wait for page to load
                await page.WaitForLoadStateAsync(LoadState.NetworkIdle, new PageWaitForLoadStateOptions
                {
                    Timeout = 30000
                });

                // Fill all fields
                await InputField.SetTextAreaInputFieldAsync(AgencyName_Input, agencyName, true, 1, "Agency Name");
                await SelectBusinessTypeAsync(businessType);
                await InputField.SetTextAreaInputFieldAsync(YearsInBusiness_Input, yearsInBusiness, true, 1, "Years in Business");
                await InputField.SetTextAreaInputFieldAsync(FirstName_Input, firstName, true, 1, "First Name");
                await InputField.SetTextAreaInputFieldAsync(LastName_Input, lastName, true, 1, "Last Name");
                await SelectTitleAsync(title);
                await InputField.SetTextAreaInputFieldAsync(Street_Input, street, true, 1, "Street");
                await InputField.SetTextAreaInputFieldAsync(City_Input, city, true, 1, "City");
                await InputField.SetDropdownFieldAsync(State_Dropdown, state, true, 1, "State");
                await InputField.SetTextAreaInputFieldAsync(ZipCode_Input, zipCode, true, 1, "Zip Code");
                await InputField.SetTextAreaInputFieldAsync(ContactPhone_Input, contactPhone, true, 1, "Contact Phone");
                await InputField.SetTextAreaInputFieldAsync(ContactFax_Input, contactFax, true, 1, "Contact Fax");
                await InputField.SetTextAreaInputFieldAsync(EmailAddress_Input, emailAddress, true, 1, "Email Address");
                await InputField.SetTextAreaInputFieldAsync(WebsiteAddress_Input, websiteAddress, true, 1, "Website Address");
                await InputField.SetTextAreaInputFieldAsync(CurrentLongTermInterests_TextArea, currentLongTermInterests, true, 1, "Current Long Term Interests");
                await InputField.SetTextAreaInputFieldAsync(LearnAboutGoodville_TextArea, learnAboutGoodville, true, 1, "Learn About Goodville");

                logger.WriteLine("Successfully added agency details from context data");
            }
            catch (Exception ex)
            {
                logger.WriteLine($"Error adding agency details from context: {ex.Message}");
                throw new Exception($"Failed to add agency details from context: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Selects the business type radio button
        /// </summary>
        private async Task SelectBusinessTypeAsync(string businessType)
        {
            try
            {
                logger.WriteLine($"Selecting business type: {businessType}");

                switch (businessType?.ToLower())
                {
                    case "sole proprietorship":
                    case "proprietorship":
                        await Button.ClickButtonAsync(Proprietorship_RadioButton, ActionType.Click, true, 1, "Sole Proprietorship");
                        break;
                    case "partnership":
                        await RadioButton.SelectRadioButtonAsync(Partnership_RadioButton, "Yes", true, 1);
                        break;
                    case "corporation":
                        await RadioButton.SelectRadioButtonAsync(Corporation_RadioButton, "Yes", true, 1);
                        break;
                    default:
                        logger.WriteLine($"Unknown business type: {businessType}, defaulting to Sole Proprietorship");
                        await Button.ClickButtonAsync(Proprietorship_RadioButton, ActionType.Click, true, 1, "Sole Proprietorship");
                        break;
                }

                logger.WriteLine($"Business type selected: {businessType}");
            }
            catch (Exception ex)
            {
                logger.WriteLine($"Error selecting business type: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Selects the title radio button
        /// </summary>
        private async Task SelectTitleAsync(string title)
        {
            try
            {
                logger.WriteLine($"Selecting title: {title}");

                switch (title?.ToLower())
                {
                    case "principal":
                        await Button.ClickButtonAsync(Principal_RadioButton, ActionType.Click, true, 1);
                        break;
                    case "other":
                        await RadioButton.SelectRadioButtonAsync(Other_RadioButton, "Yes", true, 1);
                        break;
                    default:
                        logger.WriteLine($"Unknown title: {title}, defaulting to Principal");
                        await RadioButton.SelectRadioButtonAsync(Principal_RadioButton, "Yes", true, 1);
                        break;
                }

                logger.WriteLine($"Title selected: {title}");
            }
            catch (Exception ex)
            {
                logger.WriteLine($"Error selecting title: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Clicks the Continue button
        /// </summary>
        public async Task ClickContinueButtonAsync()
        {
            try
            {
                logger.WriteLine("Clicking Continue button");

                await Button.ClickButtonAsync(Continue_Button, ActionType.Click, true, 1, "Continue");

                // Wait for page to load after clicking
                await page.WaitForLoadStateAsync(LoadState.NetworkIdle, new PageWaitForLoadStateOptions
                {
                    Timeout = 30000
                });

                logger.WriteLine("Continue button clicked successfully");
            }
            catch (Exception ex)
            {
                logger.WriteLine($"Error clicking Continue button: {ex.Message}");
                throw new Exception($"Failed to click Continue button: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Gets the current value of agency name input
        /// </summary>
        public async Task<string> GetAgencyNameAsync()
        {
            try
            {
                logger.WriteLine("Getting Agency Name value");
                var input = page.Locator(AgencyName_Input);
                var value = await input.InputValueAsync();
                logger.WriteLine($"Agency Name: {value}");
                return value;
            }
            catch (Exception ex)
            {
                logger.WriteLine($"Error getting Agency Name: {ex.Message}");
                return string.Empty;
            }
        }

        /// <summary>
        /// Verifies if all required fields are filled
        /// </summary>
        public async Task<bool> VerifyAllRequiredFieldsFilledAsync()
        {
            try
            {
                logger.WriteLine("Verifying all required fields are filled");

                var agencyName = await page.Locator(AgencyName_Input).InputValueAsync();
                var firstName = await page.Locator(FirstName_Input).InputValueAsync();
                var lastName = await page.Locator(LastName_Input).InputValueAsync();
                var street = await page.Locator(Street_Input).InputValueAsync();
                var city = await page.Locator(City_Input).InputValueAsync();
                var zipCode = await page.Locator(ZipCode_Input).InputValueAsync();
                var email = await page.Locator(EmailAddress_Input).InputValueAsync();

                var allFilled = !string.IsNullOrEmpty(agencyName) &&
                               !string.IsNullOrEmpty(firstName) &&
                               !string.IsNullOrEmpty(lastName) &&
                               !string.IsNullOrEmpty(street) &&
                               !string.IsNullOrEmpty(city) &&
                               !string.IsNullOrEmpty(zipCode) &&
                               !string.IsNullOrEmpty(email);

                if (allFilled)
                {
                    logger.WriteLine("✅ All required fields are filled");
                }
                else
                {
                    logger.WriteLine("❌ Some required fields are missing");
                }

                return allFilled;
            }
            catch (Exception ex)
            {
                logger.WriteLine($"Error verifying required fields: {ex.Message}");
                return false;
            }
        }

        #endregion
    }
}

using BDD.Playwright.Core.Interfaces;
using BDD.Playwright.GBIZ.PageElements;
using BDD.Playwright.GBIZ.Pages.CommonPage;
using Reqnroll;

namespace BDD.Playwright.GBIZ.Pages.AgentsPages
{
    public class JsonMyBusinessHomePage : BasePage
    {
        private readonly IFileReader _fileReader;

        #region Xpath
        public string LastName_Input { get; set; } = "//input[@name='LastName']";
        public string Name_Input { get; set; } = "//input[@name='Name']";
        public string QuickSearchNumber_Input { get; set; } = "//input[@id='qs_number']";
        public string QuickSearchType_Dropdown { get; set; } = "//select[@id='quicksearchtype']";
        public string QuickSearch_Button { get; set; } = "//label[@class='label']//input[@value='Search']";
        #endregion

        public JsonMyBusinessHomePage(ScenarioContext scenarioContext, IFileReader fileReader) : base(scenarioContext)
        {
            _fileReader = fileReader;
        }

        /// <summary>
        /// Fills quick search section using JSON data by profileKey
        /// </summary>
        public async Task PolicySearchAsync(string profileKey)
        {
            var filePath = "MyBusinessHomePage\\MyBusinessHomePage.json"; // Set your relative path as needed

            logger.WriteLine($"Starting to fill MyBusinessHomePage QuickSearch fields using profile: {profileKey}");

            try
            {
                // Get values from JSON by profile key
                var lastName = _fileReader.GetOptionalValue(filePath, $"{profileKey}.LastName");
                var firstName = _fileReader.GetOptionalValue(filePath, $"{profileKey}.FirstName");
                var quickSearchNumber = _fileReader.GetOptionalValue(filePath, $"{profileKey}.QuickSearchNumber");
                var quickSearchType = _fileReader.GetOptionalValue(filePath, $"{profileKey}.QuickSearchType");

                await InputField.SetTextAreaInputFieldAsync(LastName_Input, lastName, true, 1);
                await InputField.SetTextAreaInputFieldAsync(Name_Input, firstName, true, 1);
                await InputField.SetTextAreaInputFieldAsync(QuickSearchNumber_Input, quickSearchNumber, true, 1);
                await DropDown.SelectDropDownAsync(QuickSearchType_Dropdown, quickSearchType, true, 1);
                await Button.ClickButtonAsync(QuickSearch_Button, ActionType.Click, true, 1);

                logger.WriteLine($"QuickSearch Details Entered from JSON for {profileKey}: LastName={lastName}, FirstName={firstName}, QuickSearchNumber={quickSearchNumber}, QuickSearchType={quickSearchType}");
            }
            catch (Exception ex)
            {
                logger.WriteLine($"Error filling MyBusinessHomePage QuickSearch data: {ex.Message}");
                throw new Exception($"Failed to fill QuickSearch fields with profile '{profileKey}'", ex);
            }
        }
    }
}
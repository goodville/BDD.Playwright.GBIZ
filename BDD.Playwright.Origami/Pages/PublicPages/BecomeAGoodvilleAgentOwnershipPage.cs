using BDD.Playwright.Core.Interfaces;
using BDD.Playwright.Core.Loggers;
using BDD.Playwright.GBIZ.Pages.CommonPage;
using Reqnroll;

namespace BDD.Playwright.GBIZ.Pages.PublicPages
{
    public class BecomeAGoodvilleAgentOwnershipPage : BasePage
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly IFileReader _fileReader;
        private readonly ApplicationLogger _logger;

        public BecomeAGoodvilleAgentOwnershipPage(ScenarioContext scenarioContext, IFileReader fileReader)
            : base(scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _fileReader = fileReader;
            _logger = scenarioContext.Get<ApplicationLogger>("Logger");
        }

        private readonly string _firstNameInput = "//input[@aria-label='First Name']";
        private readonly string _lastNameInput = "//input[@aria-label='Last Name']";
        private readonly string _titleInput = "//input[@aria-label='title']";
        private readonly string _percentOwnershipInput = "//input[@aria-label='Percent of Ownership']";
        private readonly string _emailAddressInput = "//input[@aria-label='Email Address']";
        private readonly string _addOwnerLinkDefault = "//*[contains(text(),'+ Add another owner')]";

        public async Task FillOwnershipDataAsync()
        {
            if (_fileReader != null)
            {
                await FillOwnershipDataFromJsonAsync("AgentOwner");
            }
            else
            {
                await FillOwnershipDataFromContextAsync();
            }
        }

        private async Task FillOwnershipDataFromJsonAsync(string recordKey)
        {
            try
            {
                var filePath = "AgentOwner\\AgentOwnerData.json";
                _logger.WriteLine($"Reading ownership details for {recordKey} from {filePath}");

                var noOfOwners = int.Parse(_fileReader.GetOptionalValue(filePath, $"{recordKey}.NoOfOwners"));
                _logger.WriteLine($"Found {noOfOwners} owners in JSON.");

                for (var i = 1; i <= noOfOwners; i++)
                {
                    if (i > 1)
                    {
                        var addOwner = page.Locator(_addOwnerLinkDefault).First;
                        if (await addOwner.CountAsync() > 0)
                        {
                            await addOwner.ClickAsync();
                            await Task.Delay(1000); 
                        }
                    }

                    await FillIfAsync(_firstNameInput, _fileReader.GetOptionalValue(filePath, $"{recordKey}.Owner{i}FirstName"), i, "First Name");
                    await FillIfAsync(_lastNameInput, _fileReader.GetOptionalValue(filePath, $"{recordKey}.Owner{i}LastName"), i, "Last Name");
                    await FillIfAsync(_titleInput, _fileReader.GetOptionalValue(filePath, $"{recordKey}.Owner{i}Title"), i, "Title");
                    await FillIfAsync(_percentOwnershipInput, _fileReader.GetOptionalValue(filePath, $"{recordKey}.Owner{i}PercentOfOwnership"), i, "Percent Ownership");
                    await FillIfAsync(_emailAddressInput, _fileReader.GetOptionalValue(filePath, $"{recordKey}.Owner{i}EmailAddress"), i, "Email");
                }
            }
            catch (Exception ex)
            {
                _logger.WriteLine($"Error reading ownership data from JSON: {ex.Message}");
                throw;
            }
        }

        private async Task FillOwnershipDataFromContextAsync()
        {
            try
            {
                _logger.WriteLine("Filling ownership data from ScenarioContext");

                var noOfOwners = _scenarioContext.ContainsKey("NoOfOwners")
                    ? int.Parse(_scenarioContext.Get<string>("NoOfOwners"))
                    : 1;

                for (var i = 1; i <= noOfOwners; i++)
                {
                    await FillIfAsync(_firstNameInput, _scenarioContext.Get<string>($"Owner{i}FirstName"), i, "First Name");
                    await FillIfAsync(_lastNameInput, _scenarioContext.Get<string>($"Owner{i}LastName"), i, "Last Name");
                    await FillIfAsync(_titleInput, _scenarioContext.Get<string>($"Owner{i}Title"), i, "Title");
                    await FillIfAsync(_percentOwnershipInput, _scenarioContext.Get<string>($"Owner{i}PercentOfOwnership"), i, "Percent Ownership");
                    await FillIfAsync(_emailAddressInput, _scenarioContext.Get<string>($"Owner{i}EmailAddress"), i, "Email");
                }
            }
            catch (Exception ex)
            {
                _logger.WriteLine($"Error reading ownership data from ScenarioContext: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Fills the field for a specific owner index using positional XPath.
        /// </summary>
        private async Task FillIfAsync(string locator, string value, int ownerIndex, string label)
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
               
                var indexedLocator = $"({locator})[{ownerIndex}]";

                await page.FillAsync(indexedLocator, value);
                _logger.WriteLine($"Filled {label} for Owner {ownerIndex}: {value}");
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BDD.Playwright.Core.Loggers;
using BDD.Playwright.Origami.Pages.CommonPage;
using Microsoft.Playwright;
using Reqnroll;

namespace BDD.Playwright.Origami.Pages.PublicPages
{
    /// <summary>
    /// Playwright migration of legacy BecomeAGoodvilleAgentOwnershipPage.
    /// Replaces Selenium WebDriver + Excel test data usage with Playwright and ScenarioContext dictionaries.
    /// Test data expected in ScenarioContext under key "OwnershipData" (Dictionary&lt;string,string&gt;).
    /// Required keys:
    ///  - noofowners (int)
    ///  - For each owner i (1..n): owner{i}firstname, owner{i}lastname, owner{i}title, owner{i}percentofownership, owner{i}emailaddress
    /// Optional keys:
    ///  - addowner_link_override (override selector for add owner link)
    /// </summary>
    public class BecomeAGoodvilleAgentOwnershipPage : BasePage
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly ApplicationLogger _logger;
        private readonly IPage _page;

        // Selectors
        private readonly string _firstNameInput = "//input[@aria-label='First Name']";
        private readonly string _lastNameInput = "//input[@aria-label='Last Name']";
        private readonly string _titleInput = "//input[@aria-label='title']";
        private readonly string _percentOwnershipInput = "//input[@aria-label='Percent of Ownership']";
        private readonly string _emailAddressInput = "//input[@aria-label='Email Address']";
        private readonly string _addOwnerLinkDefault = "//*[contains(text(),'+ Add another owner')]";

        public BecomeAGoodvilleAgentOwnershipPage(ScenarioContext scenarioContext) : base(scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _logger = scenarioContext.Get<ApplicationLogger>("Logger");
            _page = scenarioContext.Get<IPage>("Page");
        }

        /// <summary>
        /// Legacy style sync wrapper.
        /// </summary>
        public void FillOwnershipData() => FillOwnershipDataAsync().GetAwaiter().GetResult();

        /// <summary>
        /// Fills ownership data form using provided dictionary or ScenarioContext["OwnershipData"].
        /// </summary>
        /// <param name="data">Optional ownership data dictionary.</param>
        public async Task FillOwnershipDataAsync(Dictionary<string, string>? data = null)
        {
            data ??= _scenarioContext.TryGetValue("OwnershipData", out Dictionary<string, string>? ctxData) ? ctxData : new Dictionary<string, string>();
            string Get(string key) => data.TryGetValue(key, out var v) ? v : string.Empty;

            if (!int.TryParse(Get("noofowners"), out var noOfOwners) || noOfOwners <= 0)
            {
                _logger.WriteLine("OwnershipData: 'noofowners' missing or invalid. Nothing to fill.");
                return;
            }

            var addOwnerLink = Get("addowner_link_override");
            if (string.IsNullOrWhiteSpace(addOwnerLink))
            {
                addOwnerLink = _addOwnerLinkDefault;
            }

            for (var i = 1; i <= noOfOwners; i++)
            {
                if (i > 1)
                {
                    var addOwner = _page.Locator(addOwnerLink).First;
                    if (await addOwner.CountAsync() > 0)
                    {
                        await addOwner.ClickAsync();
                        _logger.WriteLine($"Clicked Add Owner link for owner #{i}.");
                    }
                }

                await FillIfAsync(_firstNameInput, Get($"owner{i}firstname"), i, "First Name");
                await FillIfAsync(_lastNameInput, Get($"owner{i}lastname"), i, "Last Name");
                await FillIfAsync(_titleInput, Get($"owner{i}title"), i, "Title");
                await FillIfAsync(_percentOwnershipInput, Get($"owner{i}percentofownership"), i, "Percent Of Ownership");
                await FillIfAsync(_emailAddressInput, Get($"owner{i}emailaddress"), i, "Email Address");
            }
        }

        private async Task FillIfAsync(string selector, string value, int ownerIndex, string logicalName)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                _logger.WriteLine($"OwnershipData: value for {logicalName} (owner #{ownerIndex}) empty. Skipping.");
                return;
            }

            var loc = _page.Locator(selector).Nth(ownerIndex - 1); // Assumes sequential inputs per owner
            if (await loc.CountAsync() == 0)
            {
                // Fallback to first if no multiple index present
                loc = _page.Locator(selector).First;
            }

            await loc.FillAsync(value);
            _logger.WriteLine($"Filled {logicalName} for owner #{ownerIndex} -> {value}");
        }
    }
}

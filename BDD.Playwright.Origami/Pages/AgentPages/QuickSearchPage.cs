
using BDD.Playwright.Core.Loggers;
using BDD.Playwright.GBIZ.Pages.CommonPage;
using Microsoft.Playwright;
using Reqnroll;

namespace BDD.Playwright.Origami.Pages.AgentPages
{
    public class QuickSearchPage : BasePage
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly ApplicationLogger logger;
        public QuickSearchPage(ScenarioContext scenarioContext) : base(scenarioContext)
        {
            _scenarioContext = scenarioContext;
            logger = scenarioContext.Get<ApplicationLogger>("Logger");
        }

        #region Xpath
        public string SearchPolicy_Inp { get; set; } = "//input[@id='search_term']";
        public string Search_Radio { get; set; } = "//input[@id='search' and @type='radio']";
        public string Claim_Radio { get; set; } = "//input[@id='claim' and @type='radio']";
        public string Quote_Radio { get; set; } = "//input[@id='quote' and @type='radio']";
        public string Continue_Btn { get; set; } = "//input[contains(@value,'Continue')]";
        public string PolicyClick_Text { get; set; } = "//td[contains(text(),'{0}')]";
        #endregion

        public async Task QuickSearchMethodAsync(string radio, string input)
        {
            // Wait for page to load
            await page.WaitForLoadStateAsync(LoadState.DOMContentLoaded);
            // Enter policy number
            var inputField = page.Locator(SearchPolicy_Inp);
            await inputField.FillAsync(input);
            // Select radio button
            var radioLocator = radio switch
            {
                "Quote" => Quote_Radio,
                "Claim" => Claim_Radio,
                _ => Search_Radio
            };
            var radioButton = page.Locator(radioLocator);
            await radioButton.CheckAsync();
            // Click Continue
            var continueBtn = page.Locator(Continue_Btn);
            await continueBtn.ClickAsync();
            await page.WaitForLoadStateAsync(LoadState.DOMContentLoaded);
            // Click policy row
            var policyClickLocator = string.Format(PolicyClick_Text, input);
            var policyRow = page.Locator(policyClickLocator);
            await policyRow.ClickAsync();
            await page.WaitForLoadStateAsync(LoadState.DOMContentLoaded);
        }
    }
}
namespace BDD.Playwright.Core.Helpers
{
    using System.Threading.Tasks;
    using Microsoft.Playwright;
    using Reqnroll;

    public static class JavaScriptExecutor
    {
        // Execute JavaScript on the page asynchronously
        public static async Task<object> ExecuteScriptAsync(this ScenarioContext scenarioContext, string script) => await scenarioContext.Get<IPage>("Page").EvaluateAsync(script);

        // Execute JavaScript on the page with arguments asynchronously
        public static async Task<object> ExecuteScriptAsync(this ScenarioContext scenarioContext, string script, params object[] args) => await scenarioContext.Get<IPage>("Page").EvaluateAsync(script, args);

        // Scroll to the element and click asynchronously
        public static async Task ScrollToAndClickAsync(this ScenarioContext scenarioContext, string selector)
        {
            var element = scenarioContext.Get<IPage>("Page").Locator(selector);
            await element.ScrollIntoViewIfNeededAsync();  // Playwright's scroll
            await element.ClickAsync();  // Playwright's click
        }

        // Scroll into the view and click asynchronously
        public static async Task ScrollIntoViewAndClickAsync(this ScenarioContext scenarioContext, string selector)
        {
            var element = scenarioContext.Get<IPage>("Page").Locator(selector);
            await element.ScrollIntoViewIfNeededAsync();  // Scroll element into view
            await element.ClickAsync();  // Playwright's click
        }

        // Scroll into the view asynchronously
        public static async Task ScrollIntoViewAsync(this ScenarioContext scenarioContext, string selector)
        {
            var element = scenarioContext.Get<IPage>("Page").Locator(selector);
            await element.ScrollIntoViewIfNeededAsync();  // Scroll the element into view
        }

        // Scroll into the view and send keys asynchronously (e.g., filling input)
        public static async Task ScrollIntoViewSendKeysAsync(this ScenarioContext scenarioContext, string selector, string value)
        {
            var element = scenarioContext.Get<IPage>("Page").Locator(selector);
            await element.ScrollIntoViewIfNeededAsync();  // Scroll element into view
            await element.FillAsync(value);  // Set value in the element (Playwright's way)
        }
    }
}

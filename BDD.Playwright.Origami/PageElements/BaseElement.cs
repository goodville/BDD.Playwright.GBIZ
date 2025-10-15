using BDD.Playwright.Core.Loggers;
using Microsoft.Playwright;
using Reqnroll;
using static System.Net.Mime.MediaTypeNames;

namespace BDD.Playwright.GBIZ.PageElements
{
    public class BaseElement(ScenarioContext scenarioContext)
    {
        protected readonly IPage _page = scenarioContext.Get<IPage>("Page");
        protected static IFrameLocator? _frameLocator;
        protected readonly ApplicationLogger logger = scenarioContext.Get<ApplicationLogger>("Logger");

        public async Task SetIframeAsync(IEnumerable<string>? iframeSelectors = null, int timeout = 30000)
        {
            if (iframeSelectors == null || !iframeSelectors.Any())
            {
                _frameLocator = null;
                return;
            }

            IFrameLocator? locator = null;

            foreach (var selector in iframeSelectors)
            {
                if (locator == null)
                {

                    var frameElement = await _page.WaitForSelectorAsync(selector, new() { Timeout = timeout, State = WaitForSelectorState.Visible });
                    if (frameElement == null)
                    {
                        throw new TimeoutException($"No iframe found on the page with selector '{selector}'.");
                    }

                    locator = _page.FrameLocator(selector);
                }
                else
                {
                  
                    await locator.Locator(selector).WaitForAsync(new() { Timeout = 30000, State = WaitForSelectorState.Visible });
                    if (!await locator.Locator(selector).IsVisibleAsync())
                    {
                        throw new TimeoutException($"No nested iframe found with selector '{selector}'.");
                    }

                    locator = locator.FrameLocator(selector);
                }
            }

            _frameLocator = locator;
        }
    }
}
using System;
using System.IO;
using System.Threading.Tasks;
using BDD.Playwright.Core.Loggers;
using BDD.Playwright.GBIZ.PageElements;
using PageElementsIFrame = GoodVille.GBIZ.Reqnroll.Automation.PageElements.IFrame;
using Microsoft.Playwright;
using Reqnroll;

namespace BDD.Playwright.GBIZ.Pages.CommonPage
{
    /// <summary>
    /// Playwright BasePage migrated from legacy Selenium BasePage.
    /// Provides core helpers (navigation, button click, page load wait) and exposes
    /// migrated PageElements for use by derived page classes.
    /// </summary>
    public class BasePage
    {
        protected readonly ScenarioContext _scenarioContext;
        protected readonly ApplicationLogger logger;
        protected IPage page;

        // Environment / configuration flags (mirroring legacy usage)
        public string PageLevelScreenshot;
        public string Environment;

        // PageElement instances - Playwright versions
        protected Button Button;
        protected CustomButtonLink CustomButtonLink;
        protected Checkbox Checkbox;
        protected DatePicker DatePicker;
        protected DropDown DropDown;
        protected InputField InputField;
        protected Label Label;
        protected RadioButton RadioButton;
        protected TextLink TextLink;
        protected MenuItem MenuItem;
        protected Icon Icon;
        protected TextArea TextArea;
        protected PageElementsIFrame IFrame;

        public BasePage(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            logger = scenarioContext.Get<ApplicationLogger>("Logger");
            page = scenarioContext.Get<IPage>("Page");

            // Legacy env variable support
            PageLevelScreenshot = System.Environment.GetEnvironmentVariable("PageLevelScreenshot") ?? "No";
            Environment = System.Environment.GetEnvironmentVariable("Environment", EnvironmentVariableTarget.Process) ?? string.Empty;

            PageElementsSetup();
        }

        /// <summary>
        /// Initializes all PageElement objects with Playwright constructors
        /// </summary>
        private void PageElementsSetup()
        {
            Button = new Button(_scenarioContext);
            CustomButtonLink = new CustomButtonLink(_scenarioContext);
            Checkbox = new Checkbox(_scenarioContext);
            DatePicker = new DatePicker(_scenarioContext);
            DropDown = new DropDown(_scenarioContext);
            InputField = new InputField(_scenarioContext);
            Label = new Label(_scenarioContext);
            RadioButton = new RadioButton(_scenarioContext);
            TextLink = new TextLink(_scenarioContext);
            MenuItem = new MenuItem(_scenarioContext);
            Icon = new Icon(_scenarioContext);
            TextArea = new TextArea(_scenarioContext);
            IFrame = new PageElementsIFrame(_scenarioContext);

        }

        /// <summary>
        /// Navigate to a URL (async).
        /// </summary>
        protected async Task NavigateToUrlAsync(string url)
        {
            await page.GotoAsync(url);
            logger.WriteLine($"Navigated to URL: {url}");
        }

        /// <summary>
        /// Legacy style synchronous wrapper for NavigateToUrl.
        /// </summary>
        protected void NavigateToUrl(string url) => NavigateToUrlAsync(url).GetAwaiter().GetResult();

        /// <summary>
        /// Click "Next" button - async version
        /// </summary>
        public async Task NextAsync()
        {
            if (PageLevelScreenshot.Equals("Yes", StringComparison.InvariantCultureIgnoreCase))
            {
                await TakeScreenshotAsync();
            }

            await ClickButtonAsync("Next");
        }

        /// <summary>
        /// Legacy synchronous wrapper for Next
        /// </summary>
        public void Next() => NextAsync().GetAwaiter().GetResult();

        /// <summary>
        /// Click a button by its visible text (async)
        /// </summary>
        public async Task ClickButtonAsync(string buttonName, int timeoutMs = 60000)
        {
            try
            {
                // Try multiple selector strategies
                var selectors = new[]
                {
                    $"//span[text()='{buttonName}']",
                    $"//button[normalize-space(.)='{buttonName}']",
                    $"//a[normalize-space(.)='{buttonName}']",
                    $"//*[self::button or self::span or self::a][normalize-space(.)='{buttonName}']"
                };

                ILocator buttonLocator = null;
                foreach (var selector in selectors)
                {
                    var locator = page.Locator(selector).First;
                    if (await locator.CountAsync() > 0)
                    {
                        buttonLocator = locator;
                        break;
                    }
                }

                if (buttonLocator == null)
                {
                    throw new Exception($"Button '{buttonName}' not found with any selector strategy");
                }

                // Wait for button to be visible and enabled
                await buttonLocator.WaitForAsync(new LocatorWaitForOptions
                {
                    State = WaitForSelectorState.Visible,
                    Timeout = timeoutMs
                });

                // Scroll into view if needed
                await buttonLocator.ScrollIntoViewIfNeededAsync();

                // Click the button
                await buttonLocator.ClickAsync();

                logger.WriteLine($"Clicked button: {buttonName}");
            }
            catch (Exception ex)
            {
                logger.WriteLine($"Error clicking button '{buttonName}': {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Legacy synchronous wrapper for ClickButton
        /// </summary>
        public void ClickButton(string buttonName) => ClickButtonAsync(buttonName).GetAwaiter().GetResult();

        /// <summary>
        /// Wait for page to load completely (async)
        /// </summary>
        public async Task UserWaitForPageToLoadCompletelyAsync()
        {
            try
            {
                // Playwright's page.WaitForLoadStateAsync is more reliable than checking readyState
                await page.WaitForLoadStateAsync(LoadState.Load);
                await page.WaitForLoadStateAsync(LoadState.DOMContentLoaded);
                await page.WaitForLoadStateAsync(LoadState.NetworkIdle, new() { Timeout = 30000 });
                
                logger.WriteLine("Page loaded completely");
            }
            catch (TimeoutException)
            {
                logger.WriteLine("Page load timeout (NetworkIdle) - continuing anyway");
            }
            catch (Exception ex)
            {
                logger.WriteLine($"Error waiting for page to load: {ex.Message}");
            }
        }

        /// <summary>
        /// Legacy synchronous wrapper
        /// </summary>
        public void UserWaitForPageToLoadCompletly() => UserWaitForPageToLoadCompletelyAsync().GetAwaiter().GetResult();

        /// <summary>
        /// Take a screenshot (async)
        /// </summary>
        public async Task TakeScreenshotAsync(string? fileName = null)
        {
            try
            {
                if (string.IsNullOrEmpty(fileName))
                {
                    fileName = $"screenshot_{DateTime.Now:yyyyMMdd_HHmmss}.png";
                }

                var screenshotPath = Path.Combine(
                    System.Environment.GetEnvironmentVariable("ScreenshotPath") ?? "Screenshots",
                    fileName
                );

                // Ensure directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(screenshotPath));

                await page.ScreenshotAsync(new PageScreenshotOptions
                {
                    Path = screenshotPath,
                    FullPage = true
                });

                logger.WriteLine($"Screenshot saved: {screenshotPath}");
            }
            catch (Exception ex)
            {
                logger.WriteLine($"Error taking screenshot: {ex.Message}");
            }
        }

        /// <summary>
        /// Legacy synchronous wrapper
        /// </summary>
        public void TakeScreenshot(string? fileName = null) => TakeScreenshotAsync(fileName).GetAwaiter().GetResult();

        /// <summary>
        /// Wait for a loading icon to disappear (async)
        /// </summary>
        public async Task WaitForLoadingIconNotVisibleAsync(int timeoutMs = 30000)
        {
            var loadingSelectors = new[]
            {
                "//div[contains(@class,'loading')]",
                "//div[contains(@class,'spinner')]",
                "//div[contains(@class,'loader')]",
                "//*[@id='loading']",
                ".loading-indicator",
                ".spinner"
            };

            foreach (var selector in loadingSelectors)
            {
                try
                {
                    var locator = page.Locator(selector);
                    if (await locator.CountAsync() > 0)
                    {
                        await locator.WaitForAsync(new LocatorWaitForOptions
                        {
                            State = WaitForSelectorState.Hidden,
                            Timeout = timeoutMs
                        });
                        logger.WriteLine($"Loading icon disappeared: {selector}");
                        return;
                    }
                }
                catch (TimeoutException)
                {
                    // Continue to next selector
                }
            }
        }

        /// <summary>
        /// Scroll to top of page (async)
        /// </summary>
        public async Task ScrollToTopAsync()
        {
            await page.EvaluateAsync("window.scrollTo(0, 0)");
            logger.WriteLine("Scrolled to top of page");
        }

        /// <summary>
        /// Scroll to bottom of page (async)
        /// </summary>
        public async Task ScrollToBottomAsync()
        {
            await page.EvaluateAsync("window.scrollTo(0, document.body.scrollHeight)");
            logger.WriteLine("Scrolled to bottom of page");
        }

        /// <summary>
        /// Scroll element into view (async)
        /// </summary>
        public async Task ScrollIntoViewAsync(string selector)
        {
            var element = page.Locator(selector).First;
            await element.ScrollIntoViewIfNeededAsync();
            logger.WriteLine($"Scrolled element into view: {selector}");
        }

        /// <summary>
        /// Wait for element to be visible (async)
        /// </summary>
        public async Task<bool> WaitForElementVisibleAsync(string selector, int timeoutMs = 30000)
        {
            try
            {
                var element = page.Locator(selector).First;
                await element.WaitForAsync(new LocatorWaitForOptions
                {
                    State = WaitForSelectorState.Visible,
                    Timeout = timeoutMs
                });
                return true;
            }
            catch (TimeoutException)
            {
                logger.WriteLine($"Element not visible within timeout: {selector}");
                return false;
            }
        }

        /// <summary>
        /// Check if element exists (async)
        /// </summary>
        public async Task<bool> ElementExistsAsync(string selector)
        {
            var element = page.Locator(selector);
            return await element.CountAsync() > 0;
        }

        /// <summary>
        /// Get page title (async)
        /// </summary>
        public async Task<string> GetPageTitleAsync()
        {
            return await page.TitleAsync();
        }

        /// <summary>
        /// Get current URL (async)
        /// </summary>
        public string GetCurrentUrl()
        {
            return page.Url;
        }

        /// <summary>
        /// Refresh the page (async)
        /// </summary>
        public async Task RefreshPageAsync()
        {
            await page.ReloadAsync();
            logger.WriteLine("Page refreshed");
        }

        /// <summary>
        /// Go back in browser history (async)
        /// </summary>
        public async Task GoBackAsync()
        {
            await page.GoBackAsync();
            logger.WriteLine("Navigated back");
        }

        /// <summary>
        /// Go forward in browser history (async)
        /// </summary>
        public async Task GoForwardAsync()
        {
            await page.GoForwardAsync();
            logger.WriteLine("Navigated forward");
        }

        /// <summary>
        /// Execute JavaScript (async)
        /// </summary>
        public async Task<T> ExecuteJavaScriptAsync<T>(string script)
        {
            return await page.EvaluateAsync<T>(script);
        }

        /// <summary>
        /// Close page/browser (async)
        /// </summary>
        public async Task CloseAsync()
        {
            await page.CloseAsync();
            logger.WriteLine("Page closed");
        }
    }
}

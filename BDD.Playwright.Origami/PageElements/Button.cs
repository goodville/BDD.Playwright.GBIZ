using Microsoft.Playwright;
using Reqnroll;
using BDD.Playwright.Core.Loggers;
using BDD.Playwright.Core.Enums;

namespace BDD.Playwright.GBIZ.PageElements
{
    public class Button : BaseElement
    {
        public Button(ScenarioContext scenarioContext) : base(scenarioContext) { }

        public async Task ClickButtonAsync(string labelnameorlocator, ActionType action = ActionType.Click, bool islocator = false, int index = 1, string displayname = null, bool continueonerror = false)
        {
            var element = await GetButtonByLabelAsync(labelnameorlocator, islocator, index);
            var labelnameorlocator1 = displayname ?? labelnameorlocator;
            var a = DateTime.Now;
            logger.WriteLine(string.Format("Button click starts with value '{0}' on Button field with locator '{1}' at {2}", action, labelnameorlocator1, DateTime.Now.ToString("hh:mm:ss")));
            if (element != null)
            {
                try
                {
                    await element.ClickAsync();
                }
                catch
                {
                    await Task.Delay(1000);
                    await element.ClickAsync();
                }

                logger.WriteLine(string.Format("Button click performed with value '{0}' on Button field with locator '{1}'", action, labelnameorlocator1));
            }
            else
            {
                if (continueonerror)
                {
                    logger.WriteLine("Ignore Error @ Button.ClickButton. Didn't match any element with locator " + labelnameorlocator);
                }
                else
                {
                    throw new Exception("Error @ Button.ClickButton. Didn't match any element with locator " + labelnameorlocator);

                }
            }

            var b = DateTime.Now;
            logger.WriteLine(string.Format("Button click ends with value '{0}' on Button field with locator '{1}' at {2}", action, labelnameorlocator1, DateTime.Now.ToString("hh:mm:ss")));
            var c = b - a;
            logger.WriteLine(string.Format("Time Difference Between Click and ClickEnd {0}", c.TotalSeconds));
        }

        public async Task ClickButtonForStaleElementWithoutDepenAsync(string locator, ActionType actionType, bool islocator = false, int index = 1, string displayname = null)
        {
            var retries = 0;
            const int maxRetries = 5;
            const int delayBetweenRetries = 5000;
            const int maxWaitTime = 180;
            var a = DateTime.Now;
            var labelnameorlocator1 = displayname ?? locator;
            logger.WriteLine(string.Format("Stale Button click starts with value '{0}' on Button field with locator '{1}' at {2}", actionType, labelnameorlocator1, DateTime.Now.ToString("hh:mm:ss")));
            while (retries < maxRetries)
            {
                try
                {
                    var element = await GetButtonByLabelAsync(locator, islocator, index);

                    if (element == null)
                    {
                        throw new Exception($"Element not found with locator '{locator}'");
                    }

                    await element.ClickAsync();
                    logger.WriteLine(string.Format("Button click performed on element with locator '{0}'", labelnameorlocator1));
                    return;
                }
                catch (Exception ex)
                {
                    retries++;
                    logger.WriteLine(string.Format("Retrying due to error with locator '{0}': {1}", labelnameorlocator1, ex.Message));
                    Thread.Sleep(delayBetweenRetries);
                }
            }

            var b = DateTime.Now;
            logger.WriteLine(string.Format("Failed to click button with locator '{0}' after {1} retries", locator, maxRetries));
            var c = b - a;
            logger.WriteLine(string.Format("Stale Element Time Difference Between Click and ClickEnd {0}", c.TotalSeconds));
        }
        public async Task ClickButtonForStaleElementAsync(string labelnameorlocator, bool islocator = false, int index = 1, string displayname = null)
        {
            var retries = 0;
            const int maxRetries = 5;
            const int delayBetweenRetries = 2000;
            const int maxWaitTime = 180;
            var labelnameorlocator1 = displayname ?? labelnameorlocator;
            var a = DateTime.Now;
            while (retries < maxRetries)
            {
                try
                {
                    var element = await GetButtonByLabelAsync(labelnameorlocator, islocator, index);

                    if (element == null)
                    {
                        throw new Exception($"Element not found with locator '{labelnameorlocator}'");
                    }

                    await element.ClickAsync();
                    logger.WriteLine(string.Format("Button click performed on element with locator '{0}'", labelnameorlocator));

                    return;
                }
                catch (Exception ex)
                {
                    retries++;
                    logger.WriteLine(string.Format("Retrying due to error with locator '{0}': {1}", labelnameorlocator1, ex.Message));
                    Thread.Sleep(delayBetweenRetries);
                }
            }

            var b = DateTime.Now;
            logger.WriteLine(string.Format("Failed to click button with locator '{0}' after {1} retries", labelnameorlocator, maxRetries));
            var c = b - a;
            logger.WriteLine(string.Format("Stale Element Time Difference Between Click and ClickEnd {0}", c.TotalSeconds));
        }

        public async Task ClickAlertButtonAsync(string labelnameorlocator, ActionType action = ActionType.Click, bool islocator = false, int index = 1, string displayname = null)
        {
            var element = await GetAlertButtonByLabelAsync(labelnameorlocator, islocator, index);
            var labelnameorlocator1 = displayname ?? labelnameorlocator;
            if (element != null)
            {
                await element.ClickAsync();
                logger.WriteLine(string.Format("Button click performed with value '{0}' on Button field with locator '{1}'", action, labelnameorlocator1));
            }
        }

        /// <summary>
        /// Verifies the button exist.
        /// </summary>
        /// <param name="labelnameorlocator">The labelnameorlocator.</param>
        /// <param name="islocator">if set to <c>true</c> [islocator].</param>
        /// <param name="index">The index.</param>
        /// <returns> bool value</returns>
        public async Task<bool> VerifyButtonExistAsync(string labelnameorlocator, bool islocator = false, int index = 1, string displayname = null)
        {
            var elementTask = GetButtonByLabelAsync(labelnameorlocator, islocator, index);
            var element = elementTask.GetAwaiter().GetResult();
            var labelnameorlocator1 = displayname ?? labelnameorlocator;
            if (element != null)
            {
                logger.WriteLine(string.Format("'{0}' button exist ", labelnameorlocator1));
                return true;
            }
            else
            {
                logger.WriteLine(string.Format("'{0}' button does not exist ", labelnameorlocator1));
                return false;
            }
        }

        public async Task ScrollIntoViewAsync(string labelnameorlocator, bool islocator = false, int index = 1, string displayname = null)
        {
            var element = await GetButtonByLabelAsync(labelnameorlocator, islocator, index);
            var labelnameorlocator1 = displayname ?? labelnameorlocator;
            var a = DateTime.Now;
            logger.WriteLine($"Scroll into view starts with locator '{labelnameorlocator1}' at {DateTime.Now:hh:mm:ss}");
            if (element != null)
            {
                try
                {
                    await element.ScrollIntoViewIfNeededAsync();
                    logger.WriteLine($"Scrolled into view with locator '{labelnameorlocator1}'");
                }
                catch (Exception ex)
                {
                    logger.WriteLine($"Error scrolling into view with locator '{labelnameorlocator1}': {ex.Message}");
                }
            }
            else
            {
                logger.WriteLine($"Error @ ScrollButtonIntoView. Didn't match any element with locator {labelnameorlocator}");
            }

            var b = DateTime.Now;
            logger.WriteLine($"Scroll into view ends with locator '{labelnameorlocator1}' at {DateTime.Now:hh:mm:ss}");
            var c = b - a;
            logger.WriteLine($"Time Difference Between Scroll and ScrollEnd {c.TotalSeconds}");
        }
        public async Task ClickButtonCssAsync(string shadowHostSelector, string buttonSelector, ActionType action = ActionType.Click, string displayname = null, bool continueonerror = false)
        {
            var labelnameorlocator1 = displayname ?? buttonSelector;
            var a = DateTime.Now;
            logger.WriteLine($"Button click starts with value '{action}' on Button field with locator '{labelnameorlocator1}' at {DateTime.Now:hh:mm:ss}");
            try
            {
                var shadowHandle = await _page.QuerySelectorAsync(shadowHostSelector);
                if (shadowHandle == null)
                {
                    throw new Exception($"Shadow host not found: {shadowHostSelector}");
                }

                // get the shadow root
                var shadowRoot = await shadowHandle.EvaluateHandleAsync("el => el.shadowRoot");
                if (shadowRoot == null)
                {
                    throw new Exception($"Shadow root not found for host: {shadowHostSelector}");
                }

                // query inside the shadow root for the button
                var buttonHandle = await shadowRoot.AsElement().QuerySelectorAsync(buttonSelector);
                if (buttonHandle == null)
                {
                    if (continueonerror)
                    {
                        logger.WriteLine($"Ignore Error @ Button.ClickButtonCssAsync. Didn't match any element with locator {buttonSelector}");
                        return;
                    }
                    else
                    {
                        throw new Exception($"Error @ Button.ClickButtonCssAsync. Didn't match any element with locator {buttonSelector}");
                    }
                }

                try
                {
                    await buttonHandle.ClickAsync();
                }
                catch
                {
                    await Task.Delay(3000);
                    await buttonHandle.ClickAsync();
                }

                  logger.WriteLine($"Button click performed with value '{action}' on Button field with locator '{labelnameorlocator1}'");
            }
            catch (Exception ex)
            {
                if (continueonerror)
                {
                    logger.WriteLine($"Ignore Error @ Button.ClickButtonCssAsync. {ex.Message}");
                }
                else
                {
                    throw;
                }
            }

            var b = DateTime.Now;
            logger.WriteLine($"Button click ends with value '{action}' on Button field with locator '{labelnameorlocator1}' at {DateTime.Now:hh:mm:ss}");
            var c = b - a;
            logger.WriteLine($"Time Difference Between Click and ClickEnd {c.TotalSeconds}");
        }

        public async Task<bool> VerifyButtonExistCssAsync(string shadowHostSelector, string buttonSelector, string displayname = null)
        {
            var labelnameorlocator1 = displayname ?? buttonSelector;
            try
            {
                var shadowHost = await _page.QuerySelectorAsync(shadowHostSelector);
                if (shadowHost == null)
                {
                    logger.WriteLine($"'{labelnameorlocator1}' button does not exist (shadow host not found) ");
                    return false;
                }

                var shadowRoot = await shadowHost.EvaluateHandleAsync("el => el.shadowRoot");
                if (shadowRoot == null)
                {
                     logger.WriteLine($"'{labelnameorlocator1}' button does not exist (shadow root not found) ");
                    return false;
                }

                var element = await shadowRoot.AsElement().QuerySelectorAsync(buttonSelector);
                if (element != null)
                {
                    logger.WriteLine($"'{labelnameorlocator1}' button exist ");
                    return true;
                }
                else
                {
                    logger.WriteLine($"'{labelnameorlocator1}' button does not exist ");
                    return false;
                }
            }
            catch (Exception ex)
            {
                logger.WriteLine($"Error verifying button {labelnameorlocator1}: {ex.Message}");
                return false;
            }
        }

        public async Task VerifyButtonNotExistAsync(string labelnameorlocator, bool islocator = false, int index = 1, string displayname = null)
        {
            var element = await GetButtonByLabelAsync(labelnameorlocator, islocator, index);
            var labelnameorlocator1 = displayname ?? labelnameorlocator;
            if (element != null)
            {
                logger.WriteLine(string.Format("'{0}' button exist ", labelnameorlocator1));
                throw new Exception("Error: Button Exist");
            }
            else
            {
                logger.WriteLine(string.Format("'{0}' button does not exist ", labelnameorlocator1));
            }
        }

        /// <summary>
        /// Gets the button by label.
        /// </summary>
        /// <param name="labelnameorlocator">The labelnameorlocator.</param>
        /// <param name="islocator">if set to <c>true</c> [islocator].</param>
        /// <param name="index">The index.</param>
        /// <returns>IWeb Element</returns>
        private async Task<ILocator?> GetButtonByLabelAsync(string labelnameorlocator, bool islocator = false, int index = 1)
        {
            var XPathLocator = string.Empty;
            try
            {
                XPathLocator = islocator
                    ? string.Format("({0})[{1}]", labelnameorlocator, index)
                    : string.Format("(//button//*[.=normalize-space(\"{0}\")])[{1}]", labelnameorlocator, index);
                var element = _frameLocator != null
                    ? _frameLocator.Locator($"xpath={XPathLocator}")
                    : _page.Locator($"xpath={XPathLocator}");

                await element.WaitForAsync(new LocatorWaitForOptions
                {
                    State = WaitForSelectorState.Visible,
                    Timeout = 10000
                });
                return element;
            }
            catch (Exception ex)
            {
                logger.WriteLine("Error:Element locator " + labelnameorlocator + " did not match any elements.");
                logger.WriteLine("Error:Details: " + ex.Message);
                return null;
            }
        }

        private async Task<ILocator?> GetAlertButtonByLabelAsync(string labelnameorlocator, bool islocator = false, int index = 1)
        {
            var XPathLocator = string.Empty;
            try
            {
                XPathLocator = islocator
                    ? string.Format("({0})[{1}]", labelnameorlocator, index)
                    : string.Format("(//button[contains(text(),\"{0}\")])[{1}]", labelnameorlocator, index);
                var element = _frameLocator != null
                    ? _frameLocator.Locator($"xpath={XPathLocator}")
                    : _page.Locator($"xpath={XPathLocator}");

                await element.WaitForAsync(new LocatorWaitForOptions
                {
                    State = WaitForSelectorState.Visible,
                    Timeout = 10000
                });
                //var element = _driverWait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(XPathLocator)));
                return element;
            }
            catch (Exception ex)
            {
                logger.WriteLine("Error:Element locator " + labelnameorlocator + " did not match any elements.");
                logger.WriteLine("Error:Details: " + ex.Message);
                return null;
            }
        }
    }
}
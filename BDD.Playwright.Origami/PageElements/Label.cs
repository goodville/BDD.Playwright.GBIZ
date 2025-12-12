using BDD.Playwright.Core.Loggers;
using BDD.Playwright.GBIZ.Pages.AgentPages;
using Microsoft.Playwright;
using Reqnroll;
using System.Text.RegularExpressions;

namespace BDD.Playwright.GBIZ.PageElements
{
    public class Label(ScenarioContext scenarioContext) : BaseElement(scenarioContext)
    {
      
        /// <summary>
        /// Initializes a new instance of the <see cref="Label"/> class.
        /// <summary>
        /// Verifies the policy number text.
        /// </summary>
        /// <param name="expectedValue">The expected value.</param>
        /// <returns>bool value</returns>

        public async Task<bool> VerifyTextAsync(string labelnameorlocator, string expectedValue, bool islocator = false, int index = 1, string? displayname = null)
        {
            var labelnameorlocator1 = displayname ?? labelnameorlocator;

            try
            {
                var element = islocator
                  ? _page.Locator(labelnameorlocator).Nth(index - 1)
                  : _page.GetByText(labelnameorlocator).Nth(index - 1);
                await element.WaitForAsync(new LocatorWaitForOptions
                {
                    Timeout = 10000,
                    State = WaitForSelectorState.Visible
                });

                var actualText = await element.InnerTextAsync();

                if (actualText == expectedValue)
                {
                    logger.WriteLine($"'{expectedValue}' Text exists");
                    return true;
                }
                else
                {
                    logger.WriteLine($"'{expectedValue}' Text does not match actual text '{actualText}' in '{labelnameorlocator1}'");
                    return false;
                }
            }
            catch (TimeoutException)
            {
                throw new Exception($"Timeout: '{expectedValue}' Text not found in '{labelnameorlocator1}'");
            }
        }

        public async Task<bool> VerifyTextLinesAsync(string labelnameorlocator, string expectedValue, bool isLocator = false, int index = 1, string displayname = null)
        {
            // Get the element based on locator or label
            var element = isLocator ? _page.Locator(labelnameorlocator).Nth(index - 1) : _page.GetByText(labelnameorlocator).Nth(index - 1);
            var labelnameorlocator1 = displayname ?? labelnameorlocator;
            var actualValue = (await element.InnerTextAsync()).Trim()
                .Replace("\r\n", "\n")
                .Replace("\n", " ");

            expectedValue = expectedValue.Trim()
                .Replace("\r\n", "\n")
                .Replace("\n", " ");

            if (actualValue == expectedValue)
            {
                Console.WriteLine($"'{expectedValue}' Text exists.");
                return true;
            }
            else
            {
                throw new Exception($"Text doesn't match! \nExpected: '{expectedValue}'\nActual: '{actualValue}'");
            }
        }

        /// <summary>
        /// Gets the policy number text.
        /// </summary>
        /// <returns>policy number- </returns>
        public async Task <string> GetTextAsync(string labelnameorlocator, bool islocator = false, int index = 1)
        {
            var element = await GetLabelFieldByLabelAsync(labelnameorlocator, islocator, index);
            var result = await element.InnerTextAsync();
            return result;
        }

        /// <summary>
        /// Verifies the label exist.
        /// </summary>
        /// <param name="labelnameorlocator">The labelnameorlocator.</param>
        /// <param name="islocator">if set to <c>true</c> [islocator].</param>
        /// <param name="index">The index.</param>
        /// <returns>bool value</returns>
        public async Task <bool> VerifyLabelExistAsync(string labelnameorlocator, bool islocator = false, int index = 1, string displayname = null)
        {
            var element = await GetLabelFieldByLabelAsync(labelnameorlocator, islocator, index);
            var labelnameorlocator1 = displayname ?? labelnameorlocator;
            if (element != null)
            {
                logger.WriteLine(string.Format("'{0}' Label exist ", labelnameorlocator1));
                return true;
            }
            else
            {
                logger.WriteLine(string.Format("'{0}' Label does not exist ", labelnameorlocator1));
                return false;
            }
        }

        public async Task VerifyValueAsync(string labelnameorlocator, string expectedValue, bool islocator = false, int index = 1, string displayname = null)
        {
            var element = await GetLabelFieldByLabelAsync(labelnameorlocator, islocator, index);
            var a = await element.InnerTextAsync();
            var c = @"[0-9]{1,9},[0-9]{1,9}|[0-9]{1,9}";
            var b = new Regex(c);
            var match = b.Match(a);
            var labelnameorlocator1 = displayname ?? labelnameorlocator;
            try
            {
                if (match.Value == expectedValue)
                {
                    logger.WriteLine(string.Format("'{0}' value is matching with '{1}' with Locator '{2}'", match.Value, expectedValue, labelnameorlocator1));
                }
                else
                {
                    throw new Exception(string.Format("'{0}' value is not matching with '{1}' with Locator '{2}'", match.Value, expectedValue, labelnameorlocator1));
                }
            }
            catch (Exception e)
            {
                logger.WriteLine(e.Message);
                throw;
            }
        }
        public async Task<bool> VerifyTextFormatAsync(string labelnameorlocator, string regexPattern, bool islocator = false, int index = 1, string displayname = null)
        {
            try
            {
                var element = await GetLabelFieldByLabelTextAsync(labelnameorlocator, islocator, index);
                if (element == null)
                {
                    logger.WriteLine($"FAIL: Element '{displayname ?? labelnameorlocator}' not found.");
                    return false;
                }

                var actualText = await element.InnerTextAsync();
                var isMatch = Regex.IsMatch(actualText, regexPattern);

                if (isMatch)
                {
                    logger.WriteLine($"PASS: Text matches the expected format '{regexPattern}': {actualText}");
                }
                else
                {
                    logger.WriteLine($"FAIL: Text does not match format '{regexPattern}'. Actual: {actualText}");
                }

                return isMatch;
            }
            catch (Exception ex)
            {
                logger.WriteLine($"Exception in VerifyTextFormat: {ex.Message}");
                return false;
            }
        }

        private async Task<ILocator> GetLabelFieldByLabelTextAsync(string labelnameorlocator, bool islocator = false, int index =1)
        {
            var XPathLocator = islocator ? $"({labelnameorlocator})[{index}]" : $"(//*[text()=normalize-space(\"{labelnameorlocator}\")])[{index}]";

            try
            {
                var locator = _page.Locator(XPathLocator);
                await locator.WaitForAsync(new LocatorWaitForOptions { Timeout = 3000 });
                // Confirm the element exists and is visible
                var isVisible = await locator.IsVisibleAsync();
                return !isVisible ? null : locator;
            }
            catch (Exception ex)
            {
                logger.WriteLine("Error:Element locator " + labelnameorlocator + " did not match any elements.");
                return null;
            }
        }

        /* public async Task<bool> VerifyTextCssAsync(
      string shadowLocator,
      string labelNameOrLocator,
      string expectedValue,
      string displayName = null,
      bool continueOnError = false)
         {
             var element = await GetLabelByCssAsync(shadowLocator, labelNameOrLocator);
             var labelNameOrLocator1 = displayName ?? labelNameOrLocator;
             var result = await element.InnerTextAsync();
             if (result.Contains(expectedValue))
             {
                 logger.WriteLine($"'{expectedValue}' Text exist ");
                 return true;
             }
             else
             {
                 var msg = $"'{result}' Text Doesn't match with '{expectedValue}'";
                 logger.WriteLine(msg);
                 return !continueOnError ? throw new Exception(msg) : false;
             }
         }

         public async Task<ILocator> GetLabelByCssAsync(
             string shadowLocator,
             string labelNameOrLocator)
         {
             try
             {
                 var shadowHost = context.Locator(shadowLocator);
                 await shadowHost.WaitForAsync(new() { State = Microsoft.Playwright.WaitForSelectorState.Attached });

                var element = shadowHost.Locator($">>> {labelNameOrLocator}");
                 await element.WaitForAsync(new() { State = Microsoft.Playwright.WaitForSelectorState.Visible });
                 return element;
             }
             catch (Exception ex)
             {
                 logger.WriteLine("Error:Shadow Element locator " + labelNameOrLocator + " did not match any elements.");
                 logger.WriteLine("Error:Details: " + ex.Message);
                 return null;
             }
         }*/

        /// <summary>
        /// Gets the label field by label.
        /// </summary>
        /// <param name="labelnameorlocator">The labelnameorlocator.</param>
        /// <param name="islocator">if set to <c>true</c> [islocator].</param>
        /// <param name="index">The index.</param>
        /// <returns>IWebElement Response</returns>
        private async Task <ILocator> GetLabelFieldByLabelAsync(string labelnameorlocator, bool islocator = false, int index = 1)
        {
            var XPathLocator = string.Empty;

            try
            {
                XPathLocator = islocator
                    ? string.Format("({0})[{1}]", labelnameorlocator, index)
                    : string.Format("(//*[text()=normalize-space(\"{0}\")])[{1}]", labelnameorlocator, index);

                var element = _frameLocator != null ? _frameLocator.Locator($"xpath={XPathLocator}") : _page.Locator($"xpath={XPathLocator}");
                await element.WaitForAsync(new()
                { 
                    Timeout = 10000,
                    State = WaitForSelectorState.Visible,
                });
                return element;
            }
            catch (Exception ex)
            {
                logger.WriteLine("Error:Element locator " + labelnameorlocator + " did not match any elements." + ex);
                return null;
            }
        }

        private async Task <ILocator> GetLabelFieldByLabelTextAsync(string labelnameorlocator, bool islocator = false, int index = 1, int timeout = 1)
        {
            var XPathLocator = string.Empty;

            try
            {
                XPathLocator = islocator
                    ? string.Format("({0})[{1}]", labelnameorlocator, index)
                    : string.Format("(//*[text()=normalize-space(\"{0}\")])[{1}]", labelnameorlocator, index);
                var element = _frameLocator != null ? _frameLocator.Locator($"xpath={XPathLocator}") : _page.Locator($"xpath={XPathLocator}");

                await element.WaitForAsync(new()
                {
                    State = WaitForSelectorState.Attached, 
                    Timeout = timeout * 1000 });
                return element;
            }
            catch (Exception ex)
            {
                logger.WriteLine("Error:Element locator " + labelnameorlocator + " did not match any elements.");
                return null;
            }
        }
    }
}

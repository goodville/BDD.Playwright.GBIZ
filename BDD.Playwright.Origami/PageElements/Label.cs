using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Playwright;
using Reqnroll;

namespace GoodVille.GBIZ.Reqnroll.Automation.PageElements
{
    public class Label : BaseElement
    {
        private new readonly ScenarioContext _scenarioContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="Label"/> class.
        /// </summary>
        /// <param name="scenarioContext">The scenario context.</param>
        public Label(ScenarioContext scenarioContext) : base(scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        /// <summary>
        /// Verifies the label text contains expected value.
        /// </summary>
        /// <param name="labelNameOrLocator">The label name or locator.</param>
        /// <param name="expectedValue">The expected value.</param>
        /// <param name="isLocator">Whether the parameter is a locator.</param>
        /// <param name="index">The index when multiple elements match.</param>
        /// <param name="displayName">Display name for logging.</param>
        /// <returns>True if text contains expected value.</returns>
        public async Task<bool> VerifyTextAsync(string labelNameOrLocator, string expectedValue, bool isLocator = false, int index = 1, string? displayName = null)
        {
            var element = await GetLabelFieldByLabelAsync(labelNameOrLocator, isLocator, index);
            var displayText = displayName ?? labelNameOrLocator;
            
            if (element == null)
            {
                throw new Exception($"Element with locator '{displayText}' not found");
            }

            var actualText = await element.TextContentAsync() ?? string.Empty;
            
            if (actualText.Contains(expectedValue))
            {
                _applicationLogger.WriteLine($"'{expectedValue}' Text exists");
                return true;
            }
            else
            {
                throw new Exception($"'{actualText}' Text doesn't match with '{expectedValue}'");
            }
        }

        /// <summary>
        /// Verifies text in shadow DOM element.
        /// </summary>
        /// <param name="shadowLocator">The shadow host locator.</param>
        /// <param name="labelNameOrLocator">The label name or locator within shadow DOM.</param>
        /// <param name="expectedValue">The expected value.</param>
        /// <param name="displayName">Display name for logging.</param>
        /// <param name="continueOnError">Whether to continue on error.</param>
        /// <returns>True if text contains expected value.</returns>
        public async Task<bool> VerifyTextCssAsync(string shadowLocator, string labelNameOrLocator, string expectedValue, string? displayName = null, bool continueOnError = false)
        {
            var element = await GetLabelByCssAsync(shadowLocator, labelNameOrLocator);
            var displayText = displayName ?? labelNameOrLocator;
            
            if (element == null)
            {
                if (continueOnError)
                {
                    _applicationLogger.WriteLine($"Element with shadow locator '{displayText}' not found");
                    return false;
                }

                throw new Exception($"Element with shadow locator '{displayText}' not found");
            }

            var actualText = await element.TextContentAsync() ?? string.Empty;
            
            if (actualText.Contains(expectedValue))
            {
                _applicationLogger.WriteLine($"'{expectedValue}' Text exists");
                return true;
            }
            else
            {
                if (continueOnError)
                {
                    _applicationLogger.WriteLine($"'{actualText}' Text doesn't match with '{expectedValue}'");
                    return false;
                }

                throw new Exception($"'{actualText}' Text doesn't match with '{expectedValue}'");
            }
        }

        /// <summary>
        /// Verifies text with line normalization.
        /// </summary>
        /// <param name="labelNameOrLocator">The label name or locator.</param>
        /// <param name="expectedValue">The expected value.</param>
        /// <param name="isLocator">Whether the parameter is a locator.</param>
        /// <param name="index">The index when multiple elements match.</param>
        /// <param name="displayName">Display name for logging.</param>
        /// <returns>True if text matches expected value exactly.</returns>
        public async Task<bool> VerifyTextLinesAsync(string labelNameOrLocator, string expectedValue, bool isLocator = false, int index = 1, string? displayName = null)
        {
            var element = await GetLabelFieldByLabelAsync(labelNameOrLocator, isLocator, index);
            var displayText = displayName ?? labelNameOrLocator;
            
            if (element == null)
            {
                throw new Exception($"Element with locator '{displayText}' not found");
            }

            var actualText = await element.TextContentAsync() ?? string.Empty;
            var actualValue = actualText.Trim().Replace("\r\n", "\n").Replace("\n", " ");
            expectedValue = expectedValue.Trim().Replace("\r\n", "\n").Replace("\n", " ");

            if (actualValue == expectedValue)
            {
                _applicationLogger.WriteLine($"'{expectedValue}' Text exists.");
                return true;
            }
            else
            {
                throw new Exception($"Text doesn't match! \nExpected: '{expectedValue}'\nActual: '{actualValue}'");
            }
        }

        /// <summary>
        /// Gets the text content of a label.
        /// </summary>
        /// <param name="labelNameOrLocator">The label name or locator.</param>
        /// <param name="isLocator">Whether the parameter is a locator.</param>
        /// <param name="index">The index when multiple elements match.</param>
        /// <param name="displayName">Display name for logging.</param>
        /// <returns>The text content of the element.</returns>
        public async Task<string> GetTextAsync(string labelNameOrLocator, bool isLocator = false, int index = 1, string? displayName = null)
        {
            var element = await GetLabelFieldByLabelAsync(labelNameOrLocator, isLocator, index);
            
            if (element == null)
            {
                throw new Exception($"Element with locator '{displayName ?? labelNameOrLocator}' not found");
            }

            var result = await element.TextContentAsync() ?? string.Empty;
            _applicationLogger.WriteLine($"'{result}' Text exists.");
            return result;
        }

        /// <summary>
        /// Gets the page title.
        /// </summary>
        /// <returns>The page title.</returns>
        public async Task<string> GetTitleAsync()
        {
            var result = await _page.TitleAsync();
            return result;
        }

        /// <summary>
        /// Verifies if a label exists.
        /// </summary>
        /// <param name="labelNameOrLocator">The label name or locator.</param>
        /// <param name="isLocator">Whether the parameter is a locator.</param>
        /// <param name="index">The index when multiple elements match.</param>
        /// <param name="displayName">Display name for logging.</param>
        /// <returns>True if the label exists.</returns>
        public async Task<bool> VerifyLabelExistAsync(string labelNameOrLocator, bool isLocator = false, int index = 1, string? displayName = null)
        {
            var element = await GetLabelFieldByLabelAsync(labelNameOrLocator, isLocator, index);
            var displayText = displayName ?? labelNameOrLocator;
            
            if (element != null)
            {
                var isVisible = await element.IsVisibleAsync();
                if (isVisible)
                {
                    _applicationLogger.WriteLine($"'{displayText}' Label exists");
                    return true;
                }
            }
            
            _applicationLogger.WriteLine($"'{displayText}' Label does not exist");
            return false;
        }

        /// <summary>
        /// Verifies a numeric value using regex pattern.
        /// </summary>
        /// <param name="labelNameOrLocator">The label name or locator.</param>
        /// <param name="expectedValue">The expected value.</param>
        /// <param name="isLocator">Whether the parameter is a locator.</param>
        /// <param name="index">The index when multiple elements match.</param>
        /// <param name="displayName">Display name for logging.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task VerifyValueAsync(string labelNameOrLocator, string expectedValue, bool isLocator = false, int index = 1, string? displayName = null)
        {
            var element = await GetLabelFieldByLabelAsync(labelNameOrLocator, isLocator, index);
            var displayText = displayName ?? labelNameOrLocator;
            
            if (element == null)
            {
                throw new Exception($"Element with locator '{displayText}' not found");
            }

            var actualText = await element.TextContentAsync() ?? string.Empty;
            var pattern = @"[0-9]{1,9},[0-9]{1,9}|[0-9]{1,9}";
            var regex = new Regex(pattern);
            var match = regex.Match(actualText);
            
            try
            {
                if (match.Value == expectedValue)
                {
                    _applicationLogger.WriteLine($"'{match.Value}' value is matching with '{expectedValue}' with Locator '{displayText}'");
                }
                else
                {
                    throw new Exception($"'{match.Value}' value is not matching with '{expectedValue}' with Locator '{displayText}'");
                }
            }
            catch (Exception e)
            {
                _applicationLogger.WriteLine(e.Message);
                throw;
            }
        }

        /// <summary>
        /// Verifies if label text exists with custom timeout.
        /// </summary>
        /// <param name="labelNameOrLocator">The label name or locator.</param>
        /// <param name="isLocator">Whether the parameter is a locator.</param>
        /// <param name="index">The index when multiple elements match.</param>
        /// <param name="timeout">Timeout in seconds.</param>
        /// <returns>True if the label text exists.</returns>
        public async Task<bool> VerifyLabelTextExistAsync(string labelNameOrLocator, bool isLocator = false, int index = 1, int timeout = 1)
        {
            var element = await GetLabelFieldByLabelTextAsync(labelNameOrLocator, isLocator, index, timeout);
            
            if (element != null)
            {
                _applicationLogger.WriteLine($"'{labelNameOrLocator}' Label exists");
                return true;
            }
            else
            {
                _applicationLogger.WriteLine($"'{labelNameOrLocator}' Label does not exist");
                return false;
            }
        }

        /// <summary>
        /// Verifies text format using regex pattern.
        /// </summary>
        /// <param name="labelNameOrLocator">The label name or locator.</param>
        /// <param name="regexPattern">The regex pattern to match.</param>
        /// <param name="isLocator">Whether the parameter is a locator.</param>
        /// <param name="index">The index when multiple elements match.</param>
        /// <param name="displayName">Display name for logging.</param>
        /// <returns>True if text matches the regex pattern.</returns>
        public async Task<bool> VerifyTextFormatAsync(string labelNameOrLocator, string regexPattern, bool isLocator = false, int index = 1, string? displayName = null)
        {
            try
            {
                var element = await GetLabelFieldByLabelTextAsync(labelNameOrLocator, isLocator, index);
                if (element == null)
                {
                    _applicationLogger.WriteLine($"FAIL: Element '{displayName ?? labelNameOrLocator}' not found.");
                    return false;
                }

                var actualText = await element.TextContentAsync() ?? string.Empty;
                var isMatch = Regex.IsMatch(actualText, regexPattern);

                if (isMatch)
                {
                    _applicationLogger.WriteLine($"PASS: Text matches the expected format '{regexPattern}': {actualText}");
                }
                else
                {
                    _applicationLogger.WriteLine($"FAIL: Text does not match format '{regexPattern}'. Actual: {actualText}");
                }

                return isMatch;
            }
            catch (Exception ex)
            {
                _applicationLogger.WriteLine($"Exception in VerifyTextFormat: {ex.Message}");
                return false;
            }
        }

        #region Private Helper Methods

        /// <summary>
        /// Gets label field locator by label.
        /// </summary>
        /// <param name="labelNameOrLocator">The label name or locator.</param>
        /// <param name="isLocator">Whether the parameter is a locator.</param>
        /// <param name="index">The index when multiple elements match.</param>
        /// <returns>ILocator for the label field or null if not found.</returns>
        private async Task<ILocator?> GetLabelFieldByLabelAsync(string labelNameOrLocator, bool isLocator = false, int index = 1)
        {
            try
            {
                var locator = isLocator
                    ? (index > 1 ? _page.Locator($"({labelNameOrLocator}) >> nth={index - 1}") : _page.Locator(labelNameOrLocator))
                    : (index > 1 ? _page.Locator($"text='{labelNameOrLocator}' >> nth={index - 1}") : _page.Locator($"text='{labelNameOrLocator}'"));

                await locator.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Attached });
                return locator;
            }
            catch (Exception ex)
            {
                _applicationLogger.WriteLine($"Error: Element locator {labelNameOrLocator} did not match any elements. {ex.Message}");
                return null;
            }
        }

        /// <summary>
        /// Gets label by CSS selector within shadow DOM.
        /// </summary>
        /// <param name="shadowLocator">The shadow host locator.</param>
        /// <param name="labelNameOrLocator">The label name or locator within shadow DOM.</param>
        /// <returns>ILocator for the shadow element or null if not found.</returns>
        private async Task<ILocator?> GetLabelByCssAsync(string shadowLocator, string labelNameOrLocator)
        {
            try
            {
                var shadowHost = _page.Locator(shadowLocator);
                await shadowHost.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Attached });
                
                // For shadow DOM, we need to pierce into the shadow root
                var shadowElement = _page.Locator($"{shadowLocator} >> pierceAll={labelNameOrLocator}");
                await shadowElement.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Attached });
                
                return shadowElement;
            }
            catch (Exception ex)
            {
                _applicationLogger.WriteLine($"Error: Shadow Element locator {labelNameOrLocator} did not match any elements.");
                _applicationLogger.WriteLine($"Error: Details: {ex.Message}");
                return null;
            }
        }

        /// <summary>
        /// Gets label field locator by label text with custom timeout.
        /// </summary>
        /// <param name="labelNameOrLocator">The label name or locator.</param>
        /// <param name="isLocator">Whether the parameter is a locator.</param>
        /// <param name="index">The index when multiple elements match.</param>
        /// <param name="timeout">Timeout in seconds.</param>
        /// <returns>ILocator for the label field or null if not found.</returns>
        private async Task<ILocator?> GetLabelFieldByLabelTextAsync(string labelNameOrLocator, bool isLocator = false, int index = 1, int timeout = 1)
        {
            try
            {
                var locator = isLocator
                    ? (index > 1 ? _page.Locator($"({labelNameOrLocator}) >> nth={index - 1}") : _page.Locator(labelNameOrLocator))
                    : (index > 1 ? _page.Locator($"text='{labelNameOrLocator}' >> nth={index - 1}") : _page.Locator($"text='{labelNameOrLocator}'"));

                await locator.WaitForAsync(new LocatorWaitForOptions 
                { 
                    State = WaitForSelectorState.Attached, 
                    Timeout = timeout * 1000 
                });
                return locator;
            }
            catch (Exception ex)
            {
                _applicationLogger.WriteLine($"Error: Element locator {labelNameOrLocator} did not match any elements.");
                return null;
            }
        }

        #endregion
    }
}

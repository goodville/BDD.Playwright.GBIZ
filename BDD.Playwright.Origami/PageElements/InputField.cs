using System;
using System.Threading.Tasks;
using Microsoft.Playwright;
using Reqnroll;

namespace GoodVille.GBIZ.Reqnroll.Automation.PageElements
{
    public class InputField : BaseElement
    {
        private new readonly ScenarioContext _scenarioContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="InputField"/> class.
        /// </summary>
        /// <param name="scenarioContext">The scenario context.</param>
        public InputField(ScenarioContext scenarioContext) : base(scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        /// <summary>
        /// Sets value in an input field (TextBox).
        /// </summary>
        /// <param name="labelNameOrLocator">The label name or locator.</param>
        /// <param name="value">The value to enter.</param>
        /// <param name="isLocator">Whether the parameter is a locator.</param>
        /// <param name="index">The index when multiple elements match.</param>
        /// <param name="displayName">Display name for logging.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task SetInputFieldAsync(string labelNameOrLocator, string value, bool isLocator = false, int index = 1, string? displayName = null)
        {
            var element = GetInputFieldByLabel(labelNameOrLocator, isLocator, index);
            var displayText = displayName ?? labelNameOrLocator;
            
            await element.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Visible });
            await element.FillAsync(value);
            await element.PressAsync("Tab");
            
            // Verify the value was entered
            var enteredValue = await element.InputValueAsync();
            if (string.IsNullOrEmpty(enteredValue))
            {
                await Task.Delay(2000);
                await element.FillAsync(value);
            }
            
            _applicationLogger.WriteLine($"Entered value '{value}' to Input field with locator '{displayText}'");
        }

        /// <summary>
        /// Sets value by replacing existing content using select all and type.
        /// </summary>
        /// <param name="labelNameOrLocator">The label name or locator.</param>
        /// <param name="value">The value to enter.</param>
        /// <param name="isLocator">Whether the parameter is a locator.</param>
        /// <param name="index">The index when multiple elements match.</param>
        /// <param name="displayName">Display name for logging.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task SetInputFieldReplaceValueAsync(string labelNameOrLocator, string value, bool isLocator = false, int index = 1, string? displayName = null)
        {
            var element = GetInputFieldByLabel(labelNameOrLocator, isLocator, index);
            var displayText = displayName ?? labelNameOrLocator;
            
            await element.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Visible });
            await element.PressAsync("Control+a"); // Select all
            await element.TypeAsync(value);
            
            var enteredValue = await element.InputValueAsync();
            if (string.IsNullOrEmpty(enteredValue))
            {
                await Task.Delay(2000);
                await element.TypeAsync(value);
            }
            
            _applicationLogger.WriteLine($"Entered value '{value}' to Input field with locator '{displayText}'");
        }

        /// <summary>
        /// Sets value in a dropdown field.
        /// </summary>
        /// <param name="labelNameOrLocator">The label name or locator.</param>
        /// <param name="value">The value to enter.</param>
        /// <param name="isLocator">Whether the parameter is a locator.</param>
        /// <param name="index">The index when multiple elements match.</param>
        /// <param name="displayName">Display name for logging.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task SetDropdownFieldAsync(string labelNameOrLocator, string value, bool isLocator = false, int index = 1, string? displayName = null)
        {
            var element = GetDropDownByLabel(labelNameOrLocator, isLocator, index);
            var displayText = displayName ?? labelNameOrLocator;
            
            await element.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Visible });
            await element.FillAsync(value);
            await Task.Delay(2000);
            await element.PressAsync("Tab");
            
            var enteredValue = await element.InputValueAsync();
            if (string.IsNullOrEmpty(enteredValue))
            {
                await Task.Delay(2000);
                await element.FillAsync(value);
            }
            
            _applicationLogger.WriteLine($"Entered value '{value}' to Dropdown field with locator '{displayText}'");
        }

        /// <summary>
        /// Sets value in a hyperlink input field.
        /// </summary>
        /// <param name="labelNameOrLocator">The label name or locator.</param>
        /// <param name="value">The value to enter.</param>
        /// <param name="isLocator">Whether the parameter is a locator.</param>
        /// <param name="index">The index when multiple elements match.</param>
        /// <param name="displayName">Display name for logging.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task SetHyperLinkInputFieldAsync(string labelNameOrLocator, string value, bool isLocator = false, int index = 1, string? displayName = null)
        {
            var displayText = displayName ?? labelNameOrLocator;
            if (!string.IsNullOrEmpty(value))
            {
                var element = GetHyperLinkInputFieldByLabel(labelNameOrLocator, isLocator, index);
                await element.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Visible });
                await element.FillAsync(value);
                await element.PressAsync("Tab");
                
                var enteredValue = await element.InputValueAsync();
                if (string.IsNullOrEmpty(enteredValue))
                {
                    await Task.Delay(2000);
                    await element.FillAsync(value);
                }
                
                _applicationLogger.WriteLine($"Entered value '{value}' to Hyperlink Input field with locator '{displayText}'");
            }
        }

        /// <summary>
        /// Sets value in a textarea input field.
        /// </summary>
        /// <param name="labelNameOrLocator">The label name or locator.</param>
        /// <param name="value">The value to enter.</param>
        /// <param name="isLocator">Whether the parameter is a locator.</param>
        /// <param name="index">The index when multiple elements match.</param>
        /// <param name="displayName">Display name for logging.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task SetTextAreaInputFieldAsync(string labelNameOrLocator, string value, bool isLocator = false, int index = 1, string? displayName = null)
        {
            var displayText = displayName ?? labelNameOrLocator;
            if (!string.IsNullOrEmpty(value))
            {
                var element = GetTextAreaInputFieldByLabel(labelNameOrLocator, isLocator, index);
                await element.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Visible });
                await element.FillAsync(value);
                await element.PressAsync("Tab");
                
                _applicationLogger.WriteLine($"Entered value '{value}' to Text Area Input field with locator '{displayText}'");
            }
        }

        /// <summary>
        /// Types input character by character with delay.
        /// </summary>
        /// <param name="labelNameOrLocator">The label name or locator.</param>
        /// <param name="value">The value to type.</param>
        /// <param name="isLocator">Whether the parameter is a locator.</param>
        /// <param name="index">The index when multiple elements match.</param>
        /// <param name="displayName">Display name for logging.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task TypeInputFieldAsync(string labelNameOrLocator, string value, bool isLocator = false, int index = 1, string? displayName = null)
        {
            var displayText = displayName ?? labelNameOrLocator;
            if (!string.IsNullOrEmpty(value))
            {
                var element = GetTextAreaInputFieldByLabel(labelNameOrLocator, isLocator, index);
                await element.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Visible });
                await element.ClickAsync();
                await element.TypeAsync(value, new LocatorTypeOptions { Delay = 100 });
                
                _applicationLogger.WriteLine($"Typed value '{value}' to Text Area Input field with locator '{displayText}'");
            }
        }

        /// <summary>
        /// Sets input field value using JavaScript.
        /// </summary>
        /// <param name="labelNameOrLocator">The label name or locator.</param>
        /// <param name="value">The value to set.</param>
        /// <param name="isLocator">Whether the parameter is a locator.</param>
        /// <param name="index">The index when multiple elements match.</param>
        /// <param name="displayName">Display name for logging.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task SetInputFieldByJavaScriptAsync(string labelNameOrLocator, string value, bool isLocator = false, int index = 1, string? displayName = null)
        {
            var displayText = displayName ?? labelNameOrLocator;
            if (!string.IsNullOrEmpty(value))
            {
                var element = GetTextAreaInputFieldByLabel(labelNameOrLocator, isLocator, index);
                await element.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Visible });
                await element.EvaluateAsync("(el, value) => el.value = value", value);
                await element.PressAsync("Enter");
                await element.PressAsync("Tab");
                
                _applicationLogger.WriteLine($"Set value '{value}' to Text Area Input field with locator '{displayText}' using JavaScript");
            }
        }

        /// <summary>
        /// Adds text to textarea without clearing existing content.
        /// </summary>
        /// <param name="labelNameOrLocator">The label name or locator.</param>
        /// <param name="value">The value to add.</param>
        /// <param name="isLocator">Whether the parameter is a locator.</param>
        /// <param name="index">The index when multiple elements match.</param>
        /// <param name="displayName">Display name for logging.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task TextAreaInputFieldWithoutClearingDataAsync(string labelNameOrLocator, string value, bool isLocator = false, int index = 1, string? displayName = null)
        {
            var displayText = displayName ?? labelNameOrLocator;
            if (!string.IsNullOrEmpty(value))
            {
                var element = GetTextAreaInputFieldByLabel(labelNameOrLocator, isLocator, index);
                await element.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Visible });
                await element.TypeAsync(value);
                await element.PressAsync("Tab");
                
                _applicationLogger.WriteLine($"Entered value '{value}' to Text Area Input field without clearing existing data with locator '{displayText}'");
            }
        }

        /// <summary>
        /// Verifies the input field value matches expected text.
        /// </summary>
        /// <param name="labelNameOrLocator">The label name or locator.</param>
        /// <param name="expectedText">The expected text.</param>
        /// <param name="isLocator">Whether the parameter is a locator.</param>
        /// <param name="index">The index when multiple elements match.</param>
        /// <param name="displayName">Display name for logging.</param>
        /// <returns>True if values match, false otherwise.</returns>
        public async Task<bool> VerifyInputFieldValueAsync(string labelNameOrLocator, string expectedText, bool isLocator = false, int index = 1, string? displayName = null)
        {
            var element = GetInputFieldByLabel(labelNameOrLocator, isLocator, index);
            var displayText = displayName ?? labelNameOrLocator;
            
            await element.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Visible });
            var actualValue = await element.InputValueAsync();
            
            if (actualValue.Equals(expectedText))
            {
                _applicationLogger.WriteLine($"'{displayText}' Input field validation success");
                return true;
            }
            else
            {
                _applicationLogger.WriteLine($"'{displayText}' Input field validation failed. Expected: '{expectedText}', Actual: '{actualValue}'");
                return false;
            }
        }

        /// <summary>
        /// Verifies if the input field exists.
        /// </summary>
        /// <param name="labelNameOrLocator">The label name or locator.</param>
        /// <param name="isLocator">Whether the parameter is a locator.</param>
        /// <param name="index">The index when multiple elements match.</param>
        /// <param name="displayName">Display name for logging.</param>
        /// <returns>True if element exists, false otherwise.</returns>
        public async Task<bool> VerifyInputFieldExistAsync(string labelNameOrLocator, bool isLocator = false, int index = 1, string? displayName = null)
        {
            try
            {
                var element = GetInputFieldByLabel(labelNameOrLocator, isLocator, index);
                var displayText = displayName ?? labelNameOrLocator;
                
                await element.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Attached, Timeout = 5000 });
                var isVisible = await element.IsVisibleAsync();
                
                if (isVisible)
                {
                    _applicationLogger.WriteLine($"'{displayText}' Text box exists");
                    return true;
                }
                else
                {
                    _applicationLogger.WriteLine($"'{displayText}' Text box does not exist");
                    return false;
                }
            }
            catch
            {
                _applicationLogger.WriteLine($"'{displayName ?? labelNameOrLocator}' Text box does not exist");
                return false;
            }
        }

        /// <summary>
        /// Verifies if the dropdown field exists.
        /// </summary>
        /// <param name="labelNameOrLocator">The label name or locator.</param>
        /// <param name="isLocator">Whether the parameter is a locator.</param>
        /// <param name="index">The index when multiple elements match.</param>
        /// <param name="displayName">Display name for logging.</param>
        /// <returns>True if element exists, false otherwise.</returns>
        public async Task<bool> VerifyDropdownFieldExistAsync(string labelNameOrLocator, bool isLocator = false, int index = 1, string? displayName = null)
        {
            try
            {
                var element = GetDropDownByLabel(labelNameOrLocator, isLocator, index);
                var displayText = displayName ?? labelNameOrLocator;
                
                await element.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Attached, Timeout = 5000 });
                var isVisible = await element.IsVisibleAsync();
                
                if (isVisible)
                {
                    _applicationLogger.WriteLine($"'{displayText}' Dropdown Field exists");
                    return true;
                }
                else
                {
                    _applicationLogger.WriteLine($"'{displayText}' Dropdown Field does not exist");
                    return false;
                }
            }
            catch
            {
                _applicationLogger.WriteLine($"'{displayName ?? labelNameOrLocator}' Dropdown Field does not exist");
                return false;
            }
        }

        /// <summary>
        /// Sets input field without clearing first.
        /// </summary>
        /// <param name="labelNameOrLocator">The label name or locator.</param>
        /// <param name="value">The value to enter.</param>
        /// <param name="isLocator">Whether the parameter is a locator.</param>
        /// <param name="index">The index when multiple elements match.</param>
        /// <param name="displayName">Display name for logging.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task SetInputFieldWithoutClearAsync(string labelNameOrLocator, string value, bool isLocator = false, int index = 1, string? displayName = null)
        {
            var element = GetInputFieldByLabel(labelNameOrLocator, isLocator, index);
            var displayText = displayName ?? labelNameOrLocator;
            
            await element.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Visible });
            await element.TypeAsync(value);
            await element.PressAsync("Tab");
            
            _applicationLogger.WriteLine($"Entered value '{value}' to Input field with locator '{displayText}'");
        }

        /// <summary>
        /// Sets input field with explicit clear.
        /// </summary>
        /// <param name="labelNameOrLocator">The label name or locator.</param>
        /// <param name="value">The value to enter.</param>
        /// <param name="isLocator">Whether the parameter is a locator.</param>
        /// <param name="index">The index when multiple elements match.</param>
        /// <param name="displayName">Display name for logging.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task SetInputFieldWithClearAsync(string labelNameOrLocator, string value, bool isLocator = false, int index = 1, string? displayName = null)
        {
            var element = GetInputFieldByLabel(labelNameOrLocator, isLocator, index);
            var displayText = displayName ?? labelNameOrLocator;
            
            await element.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Visible });
            await element.FillAsync(value);
            await element.PressAsync("Tab");
            
            _applicationLogger.WriteLine($"Entered value '{value}' to Input field with locator '{displayText}'");
        }

        #region Private Helper Methods

        /// <summary>
        /// Gets input field locator by label.
        /// </summary>
        /// <param name="labelNameOrLocator">The label name or locator.</param>
        /// <param name="isLocator">Whether the parameter is a locator.</param>
        /// <param name="index">The index when multiple elements match.</param>
        /// <returns>ILocator for the input field.</returns>
        private ILocator GetInputFieldByLabel(string labelNameOrLocator, bool isLocator = false, int index = 1)
        {
            try
            {
                return isLocator
                    ? (index > 1 ? _page.Locator($"({labelNameOrLocator}) >> nth={index - 1}") : _page.Locator(labelNameOrLocator))
                    : (index > 1 ? _page.Locator($"text='{labelNameOrLocator}' >> .. >> input >> nth={index - 1}") : _page.Locator($"text='{labelNameOrLocator}' >> .. >> input"));
            }
            catch (Exception ex)
            {
                _applicationLogger.WriteLine($"Error: Element locator {labelNameOrLocator} did not match any elements. {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Gets hyperlink input field locator by label.
        /// </summary>
        /// <param name="labelNameOrLocator">The label name or locator.</param>
        /// <param name="isLocator">Whether the parameter is a locator.</param>
        /// <param name="index">The index when multiple elements match.</param>
        /// <returns>ILocator for the hyperlink input field.</returns>
        private ILocator GetHyperLinkInputFieldByLabel(string labelNameOrLocator, bool isLocator = false, int index = 1)
        {
            try
            {
                return isLocator
                    ? (index > 1 ? _page.Locator($"({labelNameOrLocator}) >> nth={index - 1}") : _page.Locator(labelNameOrLocator))
                    : (index > 1 ? _page.Locator($"label >> text='{labelNameOrLocator}' >> .. >> .. >> div >> input >> nth={index - 1}") : _page.Locator($"label >> text='{labelNameOrLocator}' >> .. >> .. >> div >> input"));
            }
            catch (Exception ex)
            {
                _applicationLogger.WriteLine($"Error: Element locator {labelNameOrLocator} did not match any elements. {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Gets dropdown locator by label.
        /// </summary>
        /// <param name="labelNameOrLocator">The label name or locator.</param>
        /// <param name="isLocator">Whether the parameter is a locator.</param>
        /// <param name="index">The index when multiple elements match.</param>
        /// <returns>ILocator for the dropdown.</returns>
        private ILocator GetDropDownByLabel(string labelNameOrLocator, bool isLocator = false, int index = 1)
        {
            try
            {
                return isLocator
                    ? (index > 1 ? _page.Locator($"({labelNameOrLocator}) >> nth={index - 1}") : _page.Locator(labelNameOrLocator))
                    : _page.Locator($"label:has-text('{labelNameOrLocator}') >> .. >> div >> input[type='text']");
            }
            catch (Exception ex)
            {
                _applicationLogger.WriteLine($"Error: Element locator {labelNameOrLocator} did not match any elements. {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Gets textarea input field locator by label.
        /// </summary>
        /// <param name="labelNameOrLocator">The label name or locator.</param>
        /// <param name="isLocator">Whether the parameter is a locator.</param>
        /// <param name="index">The index when multiple elements match.</param>
        /// <returns>ILocator for the textarea.</returns>
        private ILocator GetTextAreaInputFieldByLabel(string labelNameOrLocator, bool isLocator = false, int index = 1)
        {
            try
            {
                return isLocator
                    ? (index > 1 ? _page.Locator($"({labelNameOrLocator}) >> nth={index - 1}") : _page.Locator(labelNameOrLocator))
                    : (index > 1 ? _page.Locator($"text='{labelNameOrLocator}' >> .. >> textarea >> nth={index - 1}") : _page.Locator($"text='{labelNameOrLocator}' >> .. >> textarea"));
            }
            catch (Exception ex)
            {
                _applicationLogger.WriteLine($"Error: Element locator {labelNameOrLocator} did not match any elements. {ex.Message}");
                throw;
            }
        }

        #endregion
    }
}

using System;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Playwright;
using Reqnroll;

namespace BDD.Playwright.Origami.PageElements
{
    /// <summary>
    /// Playwright migration of legacy Selenium DatePicker.
    /// Supports selection by label, verification and popup calendar interactions.
    /// </summary>
    public class DatePicker : BaseElement
    {
        public DatePicker(ScenarioContext scenarioContext) : base(scenarioContext) { }

        // --- Original Selenium style synchronous wrappers for backward compatibility ---
        public void SelectDate(string labelname, string value, int index = 1) => SelectDateAsync(labelname, value, false, index).GetAwaiter().GetResult();
        public bool VerifyLabelText(string labelname, string expectedText, int index = 1) => VerifyLabelTextAsync(labelname, expectedText, false, index).GetAwaiter().GetResult();
        public bool VerifyLabelExist(string labelname, int index = 1) => VerifyExistAsync(labelname, false, index).GetAwaiter().GetResult();
        // -------------------------------------------------------------------------------

        /// <summary>
        /// Select date given label text (label for input) and value (supports MM/dd/yyyy or dd/MM/yyyy or yyyy/MM/dd with / - . separators).
        /// </summary>
        public async Task SelectDateAsync(string labelOrLocator, string value, bool isLocator = false, int index = 1, string? displayName = null)
        {
            try
            {
                var trigger = await GetDatePickerButtonAsync(labelOrLocator, isLocator, index);
                if (trigger == null)
                {
                    _applicationLogger.WriteLine($"DatePicker: Unable to resolve locator for '{labelOrLocator}'.");
                    return;
                }

                await trigger.ClickAsync();

                var parts = value.Split('/', '-', '.');
                if (parts.Length != 3)
                {
                    throw new ArgumentException($"Unsupported date format: {value}");
                }

                var year = Array.Find(parts, p => p.Length == 4) ?? parts[2];
                var month = parts[0].Length <= 2 && parts[0] != year ? parts[0] : parts[1];
                var day = parts[0] == month ? parts[1] : parts[0];

                await SelectCalendarDateAsync(year, month, day);
                _applicationLogger.WriteLine($"DatePicker: Selected '{value}' for '{displayName ?? labelOrLocator}'.");
            }
            catch (Exception ex)
            {
                _applicationLogger.WriteLine($"DatePicker: Failed selecting '{value}' -> {ex.Message}");
            }
        }

        private async Task SelectCalendarDateAsync(string year, string month, string day)
        {
            var yearLocator = _page.Locator("div#ui-datepicker-div select.ui-datepicker-year");
            if (await yearLocator.CountAsync() > 0)
            {
                await yearLocator.SelectOptionAsync(new SelectOptionValue { Label = year });
            }

            var monthLocator = _page.Locator("div#ui-datepicker-div select.ui-datepicker-month");
            if (await monthLocator.CountAsync() > 0)
            {
                if (Regex.IsMatch(month, "^\\d{1,2}$"))
                {
                    var m = int.Parse(month, CultureInfo.InvariantCulture) - 1; // jQuery UI months 0-11
                    await monthLocator.SelectOptionAsync(new SelectOptionValue { Value = m.ToString(CultureInfo.InvariantCulture) });
                }
                else
                {
                    await monthLocator.SelectOptionAsync(new SelectOptionValue { Label = month });
                }
            }

            var dayCell = _page.Locator($"//table[contains(@class,'ui-datepicker-calendar')]//td[not(contains(@class,'ui-datepicker-other-month'))]//*[text()='{day}']");
            await dayCell.First.ClickAsync();
        }

        public async Task<bool> VerifyLabelTextAsync(string labelOrLocator, string expectedText, bool isLocator = false, int index = 1)
        {
            var input = await GetDatePickerInputAsync(labelOrLocator, isLocator, index);
            if (input == null)
            {
                return false;
            }

            var actual = await input.InputValueAsync();
            var ok = string.Equals(actual, expectedText, StringComparison.OrdinalIgnoreCase);
            _applicationLogger.WriteLine(ok
                ? $"DatePicker: Value validation success for '{labelOrLocator}'."
                : $"DatePicker: Value validation FAILED for '{labelOrLocator}'. Expected '{expectedText}' got '{actual}'.");
            return ok;
        }

        public async Task<bool> VerifyExistAsync(string labelOrLocator, bool isLocator = false, int index = 1)
        {
            var input = await GetDatePickerInputAsync(labelOrLocator, isLocator, index);
            var exists = input != null && await input.CountAsync() > 0;
            _applicationLogger.WriteLine(exists
                ? $"DatePicker: '{labelOrLocator}' exists."
                : $"DatePicker: '{labelOrLocator}' NOT found.");
            return exists;
        }

        private async Task<ILocator?> GetDatePickerButtonAsync(string labelOrLocator, bool isLocator, int index)
        {
            if (isLocator)
            {
                var loc = _page.Locator($"({labelOrLocator})[{index}]");
                return await loc.CountAsync() > 0 ? loc.First : null;
            }

            var locator = _page.Locator($"(//label[normalize-space(.)='{labelOrLocator}']/..//input)[{index}]//following-sibling::button");
            return await locator.CountAsync() == 0 ? null : locator.First;
        }

        private async Task<ILocator?> GetDatePickerInputAsync(string labelOrLocator, bool isLocator, int index)
        {
            if (isLocator)
            {
                var loc = _page.Locator($"({labelOrLocator})[{index}]");
                return await loc.CountAsync() > 0 ? loc.First : null;
            }

            var locator = _page.Locator($"(//label[normalize-space(.)='{labelOrLocator}']/..//input)[{index}]");
            return await locator.CountAsync() == 0 ? null : locator.First;
        }
    }
}

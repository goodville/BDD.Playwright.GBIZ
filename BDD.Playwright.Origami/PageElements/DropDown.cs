using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Playwright;
using Reqnroll;

namespace BDD.Playwright.Origami.PageElements
{
    public class DropDown : BaseElement
    {
        public DropDown(ScenarioContext scenarioContext) : base(scenarioContext) { }

        // Backward-compatible sync wrappers
        public void SelectDropDown(string labelnameorlocator, string value, bool islocator = false, int index = 1, string displayname = null) => SelectAsync(labelnameorlocator, value, islocator, index, displayname).GetAwaiter().GetResult();
        public bool VerifyDropDownValue(string labelnameorlocator, string value, bool islocator = false, int index = 1, string displayname = null) => VerifyValueAsync(labelnameorlocator, value, islocator, index, displayname).GetAwaiter().GetResult();
        public bool VerifyDropDownExist(string labelnameorlocator, bool islocator = false, int index = 1, string displayname = null) => VerifyExistAsync(labelnameorlocator, islocator, index, displayname).GetAwaiter().GetResult();
        public void VerifyDropDownValues(string labelnameorlocator, string expectedList, bool islocator = false, string displayname = null) => VerifyValuesAsync(labelnameorlocator, expectedList, islocator, displayname).GetAwaiter().GetResult();
        public void SelectDropDownByValue(string labelOrLocator, string value, bool isLocator = false, int index = 1) => SelectByValueAsync(labelOrLocator, value, isLocator, index).GetAwaiter().GetResult();

        public async Task SelectAsync(string labelOrLocator, string value, bool isLocator = false, int index = 1, string? displayName = null)
        {
            var select = await ResolveSelectAsync(labelOrLocator, isLocator, index);
            var name = displayName ?? labelOrLocator;
            if (select == null)
            {
                _applicationLogger.WriteLine($"DropDown: Unable to locate '{name}'.");
                return;
            }

            try
            {
                if (value.StartsWith("#") && int.TryParse(value[1..], out var idx))
                {
                    await select.SelectOptionAsync(new SelectOptionValue { Index = idx - 1 });
                }
                else
                {
                    var optionTexts = await select.Locator("option").AllInnerTextsAsync();
                    string Normalize(string s) => Regex.Replace((s ?? string.Empty).Replace("\u00A0", " "), "\\s+", " ").Trim().ToLowerInvariant();
                    var normValue = Normalize(value);
                    var match = optionTexts.Select((t, i) => new { Text = t, Index = i })
                                           .FirstOrDefault(o => Normalize(o.Text) == normValue)
                               ?? optionTexts.Select((t, i) => new { Text = t, Index = i })
                                             .FirstOrDefault(o => Normalize(o.Text).Contains(normValue));
                    if (match != null)
                    {
                        await select.SelectOptionAsync(new SelectOptionValue { Index = match.Index });
                    }
                    else
                    {
                        throw new Exception($"Option '{value}' not found. Available: {string.Join(" | ", optionTexts)}");
                    }
                }

                _applicationLogger.WriteLine($"DropDown: Selected '{value}' in '{name}'.");
            }
            catch (Exception ex)
            {
                _applicationLogger.WriteLine($"DropDown: Error selecting '{value}' in '{name}' -> {ex.Message}");
                throw;
            }
        }

        public async Task SelectByValueAsync(string labelOrLocator, string value, bool isLocator = false, int index = 1)
        {
            var select = await ResolveSelectAsync(labelOrLocator, isLocator, index);
            if (select == null)
            {
                _applicationLogger.WriteLine($"DropDown: Unable to locate '{labelOrLocator}'.");
                return;
            }

            if (value.StartsWith("#") && int.TryParse(value[1..], out var idx))
            {
                await select.SelectOptionAsync(new SelectOptionValue { Index = idx - 1 });
            }
            else
            {
                await select.SelectOptionAsync(new SelectOptionValue { Value = value });
            }

            _applicationLogger.WriteLine($"DropDown: Selected value '{value}' in '{labelOrLocator}'.");
        }

        public async Task<bool> VerifyValueAsync(string labelOrLocator, string expected, bool isLocator = false, int index = 1, string? displayName = null)
        {
            var select = await ResolveSelectAsync(labelOrLocator, isLocator, index);
            var name = displayName ?? labelOrLocator;
            if (select == null)
            {
                return false;
            }

            var selected = await select.EvaluateAsync<string>("e => e.options[e.selectedIndex].text");
            var ok = string.Equals(selected?.Trim(), expected?.Trim(), StringComparison.OrdinalIgnoreCase);
            _applicationLogger.WriteLine(ok
                ? $"DropDown: Value '{expected}' is selected in '{name}'."
                : $"DropDown: Expected '{expected}' but found '{selected}' in '{name}'.");
            return ok;
        }

        public async Task VerifyValuesAsync(string labelOrLocator, string expectedPipeList, bool isLocator = false, string? displayName = null)
        {
            var select = await ResolveSelectAsync(labelOrLocator, isLocator, 1);
            var name = displayName ?? labelOrLocator;
            if (select == null)
            {
                return;
            }

            var expected = expectedPipeList.Split('|').Select(v => v.Trim()).Where(v => v.Length > 0).ToList();
            var actual = await select.Locator("option").AllInnerTextsAsync();
            var missing = expected.Where(e => !actual.Contains(e)).ToList();
            if (missing.Any())
            {
                _applicationLogger.WriteLine($"DropDown: Missing options in '{name}': {string.Join(", ", missing)}");
            }
            else
            {
                _applicationLogger.WriteLine($"DropDown: All expected options present in '{name}'.");
            }
        }

        public async Task<bool> VerifyExistAsync(string labelOrLocator, bool isLocator = false, int index = 1, string? displayName = null)
        {
            var select = await ResolveSelectAsync(labelOrLocator, isLocator, index);
            var name = displayName ?? labelOrLocator;
            var exists = select != null && await select.CountAsync() > 0;
            _applicationLogger.WriteLine(exists
                ? $"DropDown: '{name}' exists."
                : $"DropDown: '{name}' NOT found.");
            return exists;
        }

        private async Task<ILocator?> ResolveSelectAsync(string labelOrLocator, bool isLocator, int index)
        {
            if (isLocator)
            {
                var loc = _page.Locator($"({labelOrLocator})[{index}]");
                return await loc.CountAsync() > 0 ? loc.First : null;
            }

            var locator = _page.Locator($"(//select[@aria-label=normalize-space('{labelOrLocator}')] | //*[normalize-space(.)='{labelOrLocator}']/../descendant::select)[{index}]");
            return await locator.CountAsync() == 0 ? null : locator.First;
        }
    }
}

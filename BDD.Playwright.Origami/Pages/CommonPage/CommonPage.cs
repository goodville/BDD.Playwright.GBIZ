using Reqnroll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BDD.Playwright.GBIZ.Pages.CommonPage
{
    public class CommonPage :BasePage
    {
        private readonly ScenarioContext _scenarioContext;
        public CommonPage(ScenarioContext scenarioContext) : base(scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        public async Task CheckAllMessageOverrideCheckboxesAsync()
        {
            var messageOverrides = page.Locator("//span[normalize-space()='Message Overrides']");
            await messageOverrides.ClickAsync();

            var checkboxes = page.Locator("//span[contains(text(),'Message Overrides')]//following::input[@type='checkbox']");
            var checkboxCount = await checkboxes.CountAsync();

            for (var i = 0; i < checkboxCount; i++)
            {
                var checkbox = checkboxes.Nth(i);
                var isChecked = await checkbox.IsCheckedAsync();
                var isEnabled = await checkbox.IsEnabledAsync();
                var isVisible = await checkbox.IsVisibleAsync();

                if (!isChecked && isEnabled && isVisible)
                {
                    await Task.Delay(2000);
                    await checkbox.ClickAsync();
                    Console.WriteLine($"Checkbox {i + 1} selected.");
                }
                else if (!isEnabled || !isVisible)
                {
                    Console.WriteLine($"Checkbox {i + 1} not selectable (either not enabled or not displayed).");
                }
                else
                {
                    Console.WriteLine($"Checkbox {i + 1} was already selected.");
                }
            }

            await Task.Delay(5000);

            var applyButton = page.Locator("//span[normalize-space()='Apply Override(s)']");
            var applyButtonEnabled = await applyButton.IsEnabledAsync();
            var applyButtonVisible = await applyButton.IsVisibleAsync();

            if (applyButtonEnabled && applyButtonVisible)
            {
                page.Dialog += async (_, dialog) => await dialog.AcceptAsync();
                await applyButton.ClickAsync();

                // Accept any alert/dialog that appears
                
                Console.WriteLine("Apply Override(s) button clicked.");
            }
            else
            {
                Console.WriteLine("Apply Override(s) button is not enabled or not displayed.");
            }
        }

        public async Task CheckAllMessageOverrideCheckboxes1Async()
        {
            // Select ONLY the visible "Message Overrides" dialog
            var dialog = page.Locator("div.ui-dialog:has(span:text('Message Overrides')):visible");

            // Click the title or open if needed (optional)
            await dialog.Locator("span:text('Message Overrides')").ClickAsync();

            // Now get ONLY the checkboxes inside the visible dialog
            var checkboxes = dialog.Locator("input[type='checkbox']");

            var count = await checkboxes.CountAsync();

            for (var i = 0; i < count; i++)
            {
                var cb = checkboxes.Nth(i);

                if (!await cb.IsCheckedAsync())
                {
                    await cb.CheckAsync();
                    Console.WriteLine($"Checkbox {i + 1} selected.");
                }
                else
                {
                    Console.WriteLine($"Checkbox {i + 1} is already selected.");
                }
            }
        }
    }
}

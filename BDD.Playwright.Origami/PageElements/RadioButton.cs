using Microsoft.Playwright;
using Reqnroll;
using System;

namespace BDD.Playwright.GBIZ.PageElements
{
    public class RadioButton(ScenarioContext scenarioContext) : BaseElement(scenarioContext)
    {
        public async Task SelectRadioButtonAsync(string labelNameOrLocator, string value, bool isLocator, int index)
        {
            var element = await GetRadioButtonByLabelAsync(labelNameOrLocator, isLocator, index, value);

            if (element != null && !await element.IsCheckedAsync())
            {
                await element.ClickAsync();
                logger.WriteLine($"RadioButton Selected with locator '{labelNameOrLocator}'");
            }
            else if (element != null && await element.IsCheckedAsync())
            {
                logger.WriteLine($"RadioButton with locator '{labelNameOrLocator}' is already selected.");
            }
            else
            {
                throw new Exception("Error @ RadioButton.SelectRadioButtonAsync. Didn't match any element with locator " + labelNameOrLocator);
            }
        }

        public async Task<bool> VerifyRadioButtonSelectionAsync(string labelNameOrLocator, bool expectedResult, bool isLocator = false, int index = 1, string displayName = null, string yesOrNo = "yes")
        {
            // Assuming you have a method similar to GetRadioButtonByLabelAsync
            var element = await GetRadioButtonByLabelAsync(labelNameOrLocator, isLocator, index, yesOrNo);

            var labelDisplayName = displayName ?? labelNameOrLocator;

            if (element == null)
            {
                logger.WriteLine($"'{labelDisplayName}' Radio button not found for validation.");
                return false;
            }

            var isChecked = await element.IsCheckedAsync();

            if (isChecked == expectedResult)
            {
                logger.WriteLine($"'{labelDisplayName}' Radio button validation success");
                return true;
            }
            else
            {
                logger.WriteLine($"'{labelDisplayName}' Radio button validation is not success");
                return false;
            }
        }

        public async Task<bool> VerifyRadioButtonExistAsync(string labelNameOrLocator, bool isLocator = false, int index = 1, string displayName = null)
        {
            // Try to find either Yes or No radio button for the given label
            var element = await GetRadioButtonByLabelAsync(labelNameOrLocator, isLocator, index, "yes");

            var labelDisplayName = displayName ?? labelNameOrLocator;

            if (element != null)
            {
                logger.WriteLine($"'{labelDisplayName}' Radio button exists.");
                return true;
            }
            else
            {
                logger.WriteLine($"'{labelDisplayName}' Radio button does not exist.");
                return false;
            }
        }

        private async Task<ILocator> GetRadioButtonByLabelAsync(string labelNameOrLocator, bool isLocator, int index, string yesOrNo)
        {
            string xPathLocator;
            try
            {
                if (isLocator)
                {
                    xPathLocator = $"({labelNameOrLocator})[{index}]";
                }
                else
                {
                    var radioValue = yesOrNo.Equals("yes", StringComparison.OrdinalIgnoreCase) ? "Yes" : "No";
                    xPathLocator = $"(//div[./div[normalize-space(text())='{labelNameOrLocator}']]//div[@role='radio' and @aria-label='{radioValue}'])[{index}]";
                    Console.WriteLine(xPathLocator);
                }

                var element = _frameLocator != null ? _frameLocator.Locator(xPathLocator) : _page.Locator(xPathLocator);

                await element.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Visible });
                return element;
            }
            catch (Exception err)
            {
                logger.WriteLine($"WriteLine: Element locator '{labelNameOrLocator}' did not match any elements.{err.Message}");
                return null;
            }
        }
    }
}

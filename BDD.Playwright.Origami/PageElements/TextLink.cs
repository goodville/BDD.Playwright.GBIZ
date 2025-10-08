using Microsoft.Playwright;
using Reqnroll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BDD.Playwright.GBIZ.PageElements
{
    public class TextLink(ScenarioContext scenarioContext) : BaseElement(scenarioContext)
    {

        /// <summary>
        /// Clicks the text link.
        /// </summary>
        public async Task ClickTextLinkAsync(string labelnameorlocator, bool islocator = false, int index = 1, string? displayname = null, bool continueOnError = false)
        {
            var label = displayname ?? labelnameorlocator;
            try
            {
                var element = await GetTextLinkByLabelAsync(labelnameorlocator, islocator, index).ConfigureAwait(false);

                if (element is not null)
                {
                    await element.ClickAsync().ConfigureAwait(false);
                    await Task.Delay(2000).ConfigureAwait(false);
                    logger.WriteLine($"TextLink click performed on TextLink field with locator '{label}'");
                }
                else
                {
                    throw new Exception($"Text link with locator '{label}' not found.");
                }
            }
            catch (Exception ex)
            {
                if (continueOnError)
                {
                    logger.WriteLine($"Ignore Error clicking TextLink with locator '{label}': Error Message : {ex.Message}");
                }
                else
                {
                    await Task.Delay(1000).ConfigureAwait(false);
                    throw new Exception($"Error clicking TextLink with locator '{label}': {ex.Message}");
                }
            }
        }

        /// <summary>
        /// Verifies the text link exists.
        /// </summary>
        public async Task VerifyTextLinkExistAsync(string labelnameorlocator, bool islocator = false, int index = 1, string? displayname = null)
        {
            var label = displayname ?? labelnameorlocator;
            var element = await GetTextLinkByLabelAsync(labelnameorlocator, islocator, index).ConfigureAwait(false);

            if (element is not null)
            {
                logger.WriteLine($"'{label}' Text link exists");
            }
            else
            {
                logger.WriteLine($"'{label}' Text link does not exist");
                throw new Exception("Text link does not exist");
            }
        }

        /// <summary>
        /// Gets the text link by label.
        /// </summary>
        private async Task<IElementHandle?> GetTextLinkByLabelAsync(string labelnameorlocator, bool islocator = false, int index = 1)
        {
            var xpathLocator = islocator
                ? $"({labelnameorlocator})[{index}]"
                : $"(//a[contains(text(),\"{labelnameorlocator}\")])[{index}]";

            try
            {
                IElementHandle? element;
                if (_frameLocator != null)
                {
                    var locator = _frameLocator.Locator(xpathLocator);
                    await locator.WaitForAsync(new LocatorWaitForOptions
                    {
                        State = WaitForSelectorState.Visible,
                        Timeout = 5000
                    });
                    element = await locator.ElementHandleAsync().ConfigureAwait(false);
                }
                else
                {
                    var locator = _page.Locator($"xpath={xpathLocator}");
                    await locator.WaitForAsync(new LocatorWaitForOptions
                    {
                        State = WaitForSelectorState.Visible,
                        Timeout = 5000
                    });
                    return await _page.QuerySelectorAsync($"xpath={xpathLocator}").ConfigureAwait(false);
                }

                return element;
            }
            catch (Exception ex)
            {
                logger.WriteLine($"Error: Element locator {labelnameorlocator} did not match any elements. {ex}");
                return null;
            }
        }
    }
}

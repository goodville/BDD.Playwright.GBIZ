using Microsoft.Playwright;
using Reqnroll;

namespace BDD.Playwright.GBIZ.PageElements
{
    public class Checkbox(ScenarioContext scenarioContext) : BaseElement(scenarioContext)
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="Checkbox"/> class.
        /// </summary>
        /// <param name="driver">The driver.</param>
        /// <param name="ReqnrollOutputHelper">The spec flow output helper.</param>
        /// <param name="driverwait">The driverwait.</param>

        /// <summary>
        /// Selects the checkbox.
        /// </summary>
        /// <param name="labelnameorlocator">The labelnameorlocator.</param>
        /// <param name="value">if set to <c>true</c> [value].</param>
        /// <param name="islocator">if set to <c>true</c> [islocator].</param>
        /// <param name="index">The index.</param>
        public async Task SelectCheckboxAsync(string labelnameorlocator, bool value, bool islocator = false, int index = 1, string displayname = null)
        {
            var element = await GetCheckboxByLabelAsync(labelnameorlocator, islocator, index);
            var labelnameorlocator1 = displayname ?? labelnameorlocator;
            if (element != null)
            {
                var isChecked = await element.IsCheckedAsync();
                if (value)
                {
                    if (!isChecked)
                    {
                        await element.CheckAsync();
                        logger.WriteLine(string.Format("Checkbox Selected with value '{0}' on Checkbox field with locator '{1}'", value, labelnameorlocator1));
                    }
                }
                else
                {
                    if (isChecked)
                    {
                        await element.UncheckAsync();
                        specLogger.WriteLine(string.Format("Checkbox Un-Selected with value '{0}' on Checkbox field with locator '{1}'", value, labelnameorlocator1));
                    }
                }
            }
            else
            {
                throw new Exception("Unable to Locate the element" + labelnameorlocator1);
            }
        }

        /// <summary>
        /// Verifies the checkbox selection.
        /// </summary>
        /// <param name="labelnameorlocator">The labelnameorlocator.</param>
        /// <param name="expectedresult">if set to <c>true</c> [expectedresult].</param>
        /// <param name="islocator">if set to <c>true</c> [islocator].</param>
        /// <param name="index">The index.</param>
        /// <returns>bool value </returns>
        public async Task<bool> VerifyCheckboxSelectionAsync(string labelnameorlocator, bool expectedresult, bool islocator = false, int index = 1, string displayname = null)
        {
            var element = await GetCheckboxByLabelAsync(labelnameorlocator, islocator, index);
            var labelnameorlocator1 = displayname ?? labelnameorlocator;
            var selection = await element?.GetAttributeAsync("checked");

            var isChecked = selection != null;
            if (isChecked == expectedresult)
            {
                logger.WriteLine(string.Format("'{0}' Check box validation success ", labelnameorlocator1));
                return true;
            }
            else
            {
                logger.WriteLine(string.Format("'{0}' Check box validation is not success ", labelnameorlocator1));
                return false;
            }
        }

        /// <summary>
        /// Verifies the checkbox exist.
        /// </summary>
        /// <param name="labelnameorlocator">The labelnameorlocator.</param>
        /// <param name="islocator">if set to <c>true</c> [islocator].</param>
        /// <param name="index">The index.</param>
        /// <returns>boolean value</returns>
        public async Task<bool> VerifyCheckboxExistAsync(string labelnameorlocator, bool islocator = false, int index = 1, string displayname = null)
        {
            var element = GetCheckboxByLabelAsync(labelnameorlocator, islocator, index);
            var labelnameorlocator1 = displayname ?? labelnameorlocator;
            if (element != null)
            {
                logger.WriteLine(string.Format("'{0}' Check box exist ", labelnameorlocator1));
                return true;
            }
            else
            {
                logger.WriteLine(string.Format("'{0}' Check box not exist ", labelnameorlocator1));
                return false;
            }
        }

        /// <summary>
        /// Gets the checkbox by label.
        /// </summary>
        /// <param name="labelnameorlocator">The labelnameorlocator.</param>
        /// <param name="islocator">if set to <c>true</c> [islocator].</param>
        /// <param name="index">The index.</param>
        /// <returns>IWebElement response</returns>
        private async Task<ILocator> GetCheckboxByLabelAsync(string labelnameorlocator, bool islocator = false, int index = 1)
        {
            var XPathLocator = islocator
                    ? string.Format("({0})[{1}]", labelnameorlocator, index)
                    : string.Format("(//*[.=normalize-space(\"{0}\")]/ancestor::*/input)[{1}]");

            try
            {
                var element = _frameLocator != null ? _frameLocator.Locator(XPathLocator) : _page.Locator(XPathLocator);
                await element.WaitForAsync(new()
                {
                    Timeout = 20000,
                    State = WaitForSelectorState.Visible
                });
                return element;
            }
            catch (Exception ex)
            {
                logger.WriteLine("Error:Element locator " + labelnameorlocator + " did not match any elements." + ex);
                return null;
            }
        }
    }
}

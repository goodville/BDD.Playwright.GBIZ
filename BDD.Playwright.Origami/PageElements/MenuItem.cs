using BDD.Playwright.Origami.PageElements;
using Microsoft.Playwright;
using Reqnroll;

namespace BDD.Playwright.Origami.PageElements
{
    public class MenuItem(ScenarioContext scenarioContext) : BaseElement(scenarioContext)
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MenuItem"/> class.
        /// </summary>
        /// <summary>
        /// Clicks the menu item.
        /// </summary>
        /// <param name="labelnameorlocator">The labelnameorlocator.</param>
        /// <param name="action">The action.</param>
        /// <param name="islocator">if set to <c>true</c> [islocator].</param>
        /// <param name="index">The index.</param>
        public async Task ClickMenuItemAsync(string labelnameorlocator, ActionType action = ActionType.Click, bool islocator = false, int index = 1)
        {
            var element = await GetMenuItemByLabelAsync(labelnameorlocator, islocator, index);

            if (element != null)
            {
                await element.ClickAsync();
                logger.WriteLine(string.Format("Button click performed with value '{0}' on Button field with locator '{1}'", action, labelnameorlocator));
            }
        }

        /// <summary>
        /// Verifies the menu item.
        /// </summary>
        /// <param name="labelnameorlocator">The labelnameorlocator.</param>
        /// <param name="islocator">if set to <c>true</c> [islocator].</param>
        /// <param name="index">The index.</param>
        /// <returns>bool value</returns>
        public async Task <bool> VerifyMenuItemAsync(string labelnameorlocator, bool islocator = false, int index = 1)
        {
            var element = await GetMenuItemByLabelAsync(labelnameorlocator, islocator, index);

            if (element != null)
            {
                logger.WriteLine(string.Format("'{0}' button exist ", labelnameorlocator));
                return true;
            }
            else
            {
                logger.WriteLine(string.Format("'{0}' button does not exist ", labelnameorlocator));
                return false;
            }
        }

        /// <summary>
        /// Gets the menu item by label.
        /// </summary>
        /// <param name="labelnameorlocator">The labelnameorlocator.</param>
        /// <param name="islocator">if set to <c>true</c> [islocator].</param>
        /// <param name="index">The index.</param>
        /// <returns>IWebElement Response</returns>
        private async Task <ILocator> GetMenuItemByLabelAsync(string labelnameorlocator, bool islocator = false, int index = 1)
        {
            var XPathLocator = string.Empty;
            try
            {
                XPathLocator = islocator
                    ? string.Format("({0})[{1}]", labelnameorlocator, index)
                    : string.Format("(//*[.=normalize-space(\"{0}\")]/parent::div)[{1}]", labelnameorlocator, index);
                ILocator element;
                if (_frameLocator != null)
                {
                    element = _frameLocator.Locator($"xpath={XPathLocator}");
                }
                else
                {
                    element = _page.Locator($"xpath={XPathLocator}");
                }

                await element.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Visible });
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

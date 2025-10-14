using Reqnroll;
using BDD.Playwright.Origami.PageElements;
using Microsoft.Playwright;

namespace BDD.Playwright.GBIZ.PageElements
{
    public class Icon(ScenarioContext scenarioContext) : BaseElement(scenarioContext)
    {
        
       
        /// <summary>
        /// Initializes a new instance of the <see cref="Icon"/> class.
        
        /// Clicks the icon.
        /// </summary>
        /// <param name="labelnameorlocator">The labelnameorlocator.</param>
        /// <param name="action">The action.</param>
        /// <param name="islocator">if set to <c>true</c> [islocator].</param>
        /// <param name="index">The index.</param>
        public async Task ClickIconAsync(string labelnameorlocator, ActionType action = ActionType.Click, bool islocator = false, int index = 1, string displayname = null)
        {
            var element = await GetIconByLabelAsync(labelnameorlocator, islocator, index);
            var labelnameorlocator1 = displayname ?? labelnameorlocator;
            if (element != null)
            {
                await element.ClickAsync();
                logger.WriteLine(string.Format("Icon click performed with value '{0}' on Button field with locator '{1}'", action, labelnameorlocator));
            }
        }

        /// <summary>
        /// Verifies the icon exist.
        /// </summary>
        /// <param name="labelnameorlocator">The labelnameorlocator.</param>
        /// <param name="islocator">if set to <c>true</c> [islocator].</param>
        /// <param name="index">The index.</param>
        /// <returns>bool value</returns>
        public async Task <bool> VerifyIconExistAsync(string labelnameorlocator, bool islocator = false, int index = 1, string displayname = null)
        {
           var element = GetIconByLabelAsync(labelnameorlocator, islocator, index);
           var labelnameorlocator1 = displayname ?? labelnameorlocator;
            if (element != null)
            {
                logger.WriteLine(string.Format("'{0}' Icon exist ", labelnameorlocator));
                return true;
            }
            else
            {
                logger.WriteLine(string.Format("'{0}' Icon does not exist ", labelnameorlocator));
                return false;
            }
        }

        /// <summary>
        /// Gets the icon by label.
        /// </summary>
        /// <param name="labelnameorlocator">The labelnameorlocator.</param>
        /// <param name="islocator">if set to <c>true</c> [islocator].</param>
        /// <param name="index">The index.</param>
        /// <returns>IWebElement response</returns>
        private async Task <ILocator> GetIconByLabelAsync(string labelnameorlocator, bool islocator = false, int index = 1)
        {
            var XPathLocator = string.Empty;
            try
            {
                XPathLocator = islocator
                    ? string.Format("({0})[{1}]", labelnameorlocator, index)
                    : string.Format("(//*[.=normalize-space(\"{0}\")]/../../descendant::div[contains(@class,'gw-icon gw-icon--expand')])[{1}]", labelnameorlocator, index);

                ILocator element;
                if (_frameLocator != null)
                {
                    element = _frameLocator.Locator($"xpath={XPathLocator}");
                }
                else
                {
                    element = _page.Locator($"xpath={XPathLocator}");
                }

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

using Microsoft.Playwright;
using Reqnroll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDD.Playwright.GBIZ.PageElements
{
    public class CustomButtonLink(ScenarioContext scenarioContext) : BaseElement(scenarioContext)
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomButtonLink"/> class.
        /// </summary>
        /// <param name="driver">The driver.</param>
        /// <param name="ReqnrollOutputHelper">The spec flow output helper.</param>
        /// <param name="driverwait">The driverwait.</param>

        /// <summary>
        /// Clicks the custom button link.
        /// </summary>
        /// <param name="labelnameorlocator">The labelnameorlocator.</param>
        /// <param name="action">The action.</param>
        /// <param name="islocator">if set to <c>true</c> [islocator].</param>
        /// <param name="index">The index.</param>
        public async Task ClickCustomButtonLinkAsync(string labelnameorlocator, ActionType action = ActionType.Click, bool islocator = false, int index = 1, string displayname = null)
        {
            var element = await GetCustomButtonLinkByLabelAsync(labelnameorlocator, islocator, index);
            var labelnameorlocator1 = displayname ?? labelnameorlocator;
            if (element != null)
            {
                await element.ClickAsync();
                logger.WriteLine(string.Format("Button click performed with value '{0}' on Button field with locator '{1}'", action, labelnameorlocator1));
            }
        }

        /// <summary>
        /// Verifies the custom button link exist.
        /// </summary>
        /// <param name="labelnameorlocator">The labelnameorlocator.</param>
        /// <param name="islocator">if set to <c>true</c> [islocator].</param>
        /// <param name="index">The index.</param>
        /// <returns>bool value</returns>
        public async Task<bool> VerifyCustomButtonLinkExistAsync(string labelnameorlocator, bool islocator = false, int index = 1, string displayname = null)
        {
            var element = await GetCustomButtonLinkByLabelAsync(labelnameorlocator, islocator, index);
            var labelnameorlocator1 = displayname ?? labelnameorlocator;
            if (element != null)
            {
                logger.WriteLine(string.Format("'{0}' button exist ", labelnameorlocator1));
                return true;
            }
            else
            {
                logger.WriteLine(string.Format("'{0}' button does not exist ", labelnameorlocator1));
                return false;
            }
        }



        private async Task<ILocator?> GetCustomButtonLinkByLabelAsync(string labelnameorlocator, bool islocator = false, int index = 1)
        {
            var XPathLocator = islocator
                    ? $"({labelnameorlocator})[{index}]"
                    : $"(//div[(@role='link') or (@role='button')]/descendant-or-self::*[.=normalize-space(\"{labelnameorlocator}\")])[{index}]";
            try
            {
                var locator = _frameLocator != null ? _frameLocator.Locator(XPathLocator) : _page.Locator(XPathLocator);

                // Wait for the element to be visible
                await locator.WaitForAsync(new LocatorWaitForOptions
                {
                    State = WaitForSelectorState.Visible,
                    Timeout = 10000
                });
                return await locator.CountAsync() > 0 ? locator : null;
            }
            catch (Exception ex)
            {
                logger.WriteLine("Error:Element locator " + labelnameorlocator + " did not match any elements." + ex);
                return null;
            }
        }
    }
}


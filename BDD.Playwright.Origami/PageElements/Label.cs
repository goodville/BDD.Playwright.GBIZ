using BDD.Playwright.Core.Loggers;
using Microsoft.Playwright;
using Reqnroll;
using System.Text.RegularExpressions;

namespace BDD.Playwright.GBIZ.PageElements
{
    public class Label(ScenarioContext scenarioContext) : BaseElement(scenarioContext)
    {
      
        /// <summary>
        /// Initializes a new instance of the <see cref="Label"/> class.
        /// <summary>
        /// Verifies the policy number text.
        /// </summary>
        /// <param name="expectedValue">The expected value.</param>
        /// <returns>bool value</returns>

        public async Task<bool> VerifyTextAsync(string labelnameorlocator, string expectedValue, bool islocator = false, int index = 1, string? displayname = null)
        {
            var labelnameorlocator1 = displayname ?? labelnameorlocator;

            try
            {
                var element = islocator
                  ? _page.Locator(labelnameorlocator).Nth(index - 1)
                  : _page.GetByText(labelnameorlocator).Nth(index - 1);
                await element.WaitForAsync(new LocatorWaitForOptions
                {
                    Timeout = 10000,
                    State = WaitForSelectorState.Visible
                });

                var actualText = await element.InnerTextAsync();

                if (actualText == expectedValue)
                {
                    logger.WriteLine($"'{expectedValue}' Text exists");
                    return true;
                }
                else
                {
                    logger.WriteLine($"'{expectedValue}' Text does not match actual text '{actualText}' in '{labelnameorlocator1}'");
                    return false;
                }
            }
            catch (TimeoutException)
            {
                throw new Exception($"Timeout: '{expectedValue}' Text not found in '{labelnameorlocator1}'");
            }
        }

    /// <summary>
    /// Gets the policy number text.
    /// </summary>
    /// <returns>policy number- </returns>
    public async Task <string> GetTextAsync(string labelnameorlocator, bool islocator = false, int index = 1)
        {
            var element = await GetLabelFieldByLabelAsync(labelnameorlocator, islocator, index);
            var result = await element.InnerTextAsync();
            return result;
        }

        /// <summary>
        /// Verifies the label exist.
        /// </summary>
        /// <param name="labelnameorlocator">The labelnameorlocator.</param>
        /// <param name="islocator">if set to <c>true</c> [islocator].</param>
        /// <param name="index">The index.</param>
        /// <returns>bool value</returns>
        public async Task <bool> VerifyLabelExistAsync(string labelnameorlocator, bool islocator = false, int index = 1, string displayname = null)
        {
            var element = await GetLabelFieldByLabelAsync(labelnameorlocator, islocator, index);
            var labelnameorlocator1 = displayname ?? labelnameorlocator;
            if (element != null)
            {
                logger.WriteLine(string.Format("'{0}' Label exist ", labelnameorlocator1));
                return true;
            }
            else
            {
                logger.WriteLine(string.Format("'{0}' Label does not exist ", labelnameorlocator1));
                return false;
            }
        }

        public async Task VerifyValueAsync(string labelnameorlocator, string expectedValue, bool islocator = false, int index = 1, string displayname = null)
        {
            var element = await GetLabelFieldByLabelAsync(labelnameorlocator, islocator, index);
            var a = await element.InnerTextAsync();
            var c = @"[0-9]{1,9},[0-9]{1,9}|[0-9]{1,9}";
            var b = new Regex(c);
            var match = b.Match(a);
            var labelnameorlocator1 = displayname ?? labelnameorlocator;
            try
            {
                if (match.Value == expectedValue)
                {
                    logger.WriteLine(string.Format("'{0}' value is matching with '{1}' with Locator '{2}'", match.Value, expectedValue, labelnameorlocator1));
                }
                else
                {
                    throw new Exception(string.Format("'{0}' value is not matching with '{1}' with Locator '{2}'", match.Value, expectedValue, labelnameorlocator1));
                }
            }
            catch (Exception e)
            {
                logger.WriteLine(e.Message);
                throw;
            }
        }

        public async Task <bool> VerifyLabelTextExistAsync(string labelnameorlocator, bool islocator = false, int index = 1, int timeout = 1)
        {
            var element = await GetLabelFieldByLabelTextAsync(labelnameorlocator, islocator, index, timeout);

            if (element != null)
            {
                logger.WriteLine(string.Format("'{0}' Label exist ", labelnameorlocator));
                return true;
            }
            else
            {
                logger.WriteLine(string.Format("'{0}' Label does not exist ", labelnameorlocator));
                return false;
            }
        }

        /// <summary>
        /// Gets the label field by label.
        /// </summary>
        /// <param name="labelnameorlocator">The labelnameorlocator.</param>
        /// <param name="islocator">if set to <c>true</c> [islocator].</param>
        /// <param name="index">The index.</param>
        /// <returns>IWebElement Response</returns>
        private async Task <ILocator> GetLabelFieldByLabelAsync(string labelnameorlocator, bool islocator = false, int index = 1)
        {
            var XPathLocator = string.Empty;

            try
            {
                XPathLocator = islocator
                    ? string.Format("({0})[{1}]", labelnameorlocator, index)
                    : string.Format("(//*[text()=normalize-space(\"{0}\")])[{1}]", labelnameorlocator, index);

                ILocator element;
                if (_frameLocator != null)
                {
                    element = _frameLocator.Locator($"xpath={XPathLocator}");
                }
                else
                {
                    element = _page.Locator($"xpath={XPathLocator}");
                }

                await element.WaitForAsync(new()
                { 
                    Timeout = 10000,
                    State = WaitForSelectorState.Visible,
                });
                return element;
            }
            catch (Exception ex)
            {
                logger.WriteLine("Error:Element locator " + labelnameorlocator + " did not match any elements." + ex);
                return null;
            }
        }

        private async Task <ILocator> GetLabelFieldByLabelTextAsync(string labelnameorlocator, bool islocator = false, int index = 1, int timeout = 1)
        {
            var XPathLocator = string.Empty;

            try
            {
                XPathLocator = islocator
                    ? string.Format("({0})[{1}]", labelnameorlocator, index)
                    : string.Format("(//*[text()=normalize-space(\"{0}\")])[{1}]", labelnameorlocator, index);
                ILocator element;
                if (_frameLocator != null)
                {
                    element = _frameLocator.Locator($"xpath={XPathLocator}");
                }
                else
                {
                    element = _page.Locator($"xpath={XPathLocator}");
                }

                await element.WaitForAsync(new()
                {
                    State = WaitForSelectorState.Attached, 
                    Timeout = timeout * 1000 });
                return element;
            }
            catch (Exception ex)
            {
                logger.WriteLine("Error:Element locator " + labelnameorlocator + " did not match any elements.");
                return null;
            }
        }
    }
}

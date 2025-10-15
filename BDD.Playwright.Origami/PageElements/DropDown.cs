using Microsoft.Playwright;
using Reqnroll;
using System.Collections.ObjectModel;

namespace BDD.Playwright.GBIZ.PageElements
{
    public class DropDown(ScenarioContext scenarioContext) : BaseElement(scenarioContext)
    {
        public async Task SelectDropDownAsync(string labelnameorlocator, string value, bool islocator = false, int index = 1, string displayname = null)
        {
            var labelnameorlocator1 = displayname ?? labelnameorlocator;
            
            // Skip if value is null or empty
            if (string.IsNullOrEmpty(value))
            {
                logger.WriteLine($"⊘ Skipped '{labelnameorlocator1}' dropdown - value is empty");
                return;
            }

            var element = await GetDropDownByLabelAsync(labelnameorlocator, islocator, index);
            try
            {
                if (value.StartsWith("#") && int.TryParse(value.Substring(1), out var count))
                {
                    count--;
                    await element.SelectOptionAsync(new SelectOptionValue { Index = count });
                }
                else
                {
                    await element.SelectOptionAsync(new SelectOptionValue { Label = value });
                }

                logger.WriteLine($"✓ Selected '{value}' from '{labelnameorlocator1}' dropdown");
            }
            catch (Exception ex)
            {
                logger.WriteLine("Error @ DropDown.SelectDropDown. Didn't match any element with locator " + labelnameorlocator1 + ". Error Message : " + ex.Message);
                throw ex;
            }
        }

        // Replace usage of SelectElement with Playwright API to get selected option text
        public async Task<bool> VerifyDropDownValueAsync(string labelnameorlocator, string value, bool islocator = false, int index = 1, string displayname = null)
        {
            var element = await GetDropDownByLabelAsync(labelnameorlocator, islocator, index);
            var labelnameorlocator1 = displayname ?? labelnameorlocator;
            var selectedOptions = await element.Locator("checked").AllAsync();
            string selectedvalue = null;
            if (selectedOptions != null && selectedOptions.Count > 0)
            {
                selectedvalue = await selectedOptions[0].TextContentAsync();
            }

            if (selectedvalue != null && selectedvalue.Equals(value))
            {
                logger.WriteLine(string.Format("Value '{0}' is identified as selected in '{1}' dropdown", value, labelnameorlocator1));
                return true;
            }
            else
            {
                logger.WriteLine(string.Format("Value '{0}' is not identified as selected in '{1}' dropdown", value, labelnameorlocator1));
                return false;
            }
        }

        /// <summary>
        /// Verifies the drop down values.
        /// </summary>
        /// <param name="labelnameorlocator">The labelnameorlocator.</param>
        /// <param name="expectedList">The expected list.</param>
        /// <param name="islocator">if set to <c>true</c> [islocator].</param>
        public async Task VerifyDropDownValuesAsync(string labelnameorlocator, string expectedList, bool islocator = false, string displayname = null)
        {
            string actualtext = null;
            var options = expectedList.Split("|").ToList();
            var dropdownList = await GetDropDownOptionsByLabelAsync(labelnameorlocator, islocator);
            var labelnameorlocator1 = displayname ?? labelnameorlocator;
            foreach (var option in options)
            { 
                var found = false;
                foreach (var a in dropdownList)
                {
                    var text = await a.GetAttributeAsync("text");
                    if (text == option)
                    {
                        found = true;
                        break;
                    }
                }

                if (!found)
                {
                    actualtext += option + "|";
                }
            }

            if (actualtext != null)
            {
                logger.WriteLine(string.Format("Drop down options '{1}' are not identified these options '{0}' dropdown", labelnameorlocator1, actualtext));
            }
            else
            {
                logger.WriteLine(string.Format("All options '{0}' are identified in '{1}' dropdown", expectedList, labelnameorlocator1));
            }
        }

        /// <summary>
        /// Verifies the drop down exist.
        /// </summary>
        /// <param name="labelnameorlocator">The labelnameorlocator.</param>
        /// <param name="islocator">if set to <c>true</c> [islocator].</param>
        /// <param name="index">The index.</param>
        /// <returns>bool value</returns>
        public async Task <bool> VerifyDropDownExistAsync(string labelnameorlocator, bool islocator = false, int index = 1, string displayname = null)
        {
            var element = GetDropDownByLabelAsync(labelnameorlocator, islocator, index);
            var labelnameorlocator1 = displayname ?? labelnameorlocator;
            if (element != null)
            {
                logger.WriteLine(string.Format("'{0}' Drop down exist ", labelnameorlocator1));
                return true;
            }
            else
            {
                logger.WriteLine(string.Format("'{0}' Drop down does not exist ", labelnameorlocator1));
                return false;
            }
        }

        // Replace the following method to fix CS0266

        /// <summary>
        /// Gets the drop down options by label.
        /// </summary>
        /// <param name="labelnameorlocator">The labelnameorlocator.</param>
        /// <param name="islocator">if set to <c>true</c> [islocator].</param>
        /// <returns>  IReadOnlyList<ILocator> </returns>
        private async Task<IReadOnlyList<ILocator>> GetDropDownOptionsByLabelAsync(string labelnameorlocator, bool islocator = false)
        {
            var XPathLocator = string.Empty;

            try
            {
                XPathLocator = islocator
                    ? string.Format("{0}//option", labelnameorlocator)
                    : string.Format("(//select[@aria-label=normalize-space(\"{0}\")]//option | //*[.=normalize-space(\"{0}\")]/../descendant-or-self::select)[1]//option", labelnameorlocator);
                ILocator element;
                if (_frameLocator != null)
                {
                    element = _frameLocator.Locator($"xpath={XPathLocator}");
                }
                else
                {
                    element = _page.Locator($"xpath={XPathLocator}");
                }

                return await element.AllAsync();
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Gets the drop down by label.
        /// </summary>
        /// <param name="labelnameorlocator">The labelnameorlocator.</param>
        /// <param name="islocator">if set to <c>true</c> [islocator].</param>
        /// <param name="index">The index.</param>
        /// <returns>IWebElement response</returns>
        private async Task<ILocator> GetDropDownByLabelAsync(string labelnameorlocator, bool islocator = false, int index = 1)
        {
            var XPathLocator = string.Empty;
            await Task.Delay(1000);
            try
            {
                XPathLocator = islocator
                    ? string.Format("({0})[{1}]", labelnameorlocator, index)
                    : string.Format("(//label[.=normalize-space(\"{0}\")]/../following-sibling::div//input[@type='text'])[1]", labelnameorlocator);
                ILocator element;
                if (_frameLocator != null)
                {
                    element = _frameLocator.Locator($"xpath={XPathLocator}");
                }
                else
                {
                    element = _page.Locator($"xpath={XPathLocator}");
                }

                await element.WaitForAsync(new LocatorWaitForOptions
                { State = WaitForSelectorState.Visible
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

using Microsoft.Playwright;
using Reqnroll;
using System.Threading.Tasks;

namespace BDD.Playwright.GBIZ.PageElements
{
    public class TextArea(ScenarioContext scenarioContext):BaseElement(scenarioContext)
    {
        
        /// <summary>
        /// Initializes a new instance of the <see cref="TextArea"/> class.
        /// helps to enter a value into input field(TextBox).
        /// </summary>
        /// <param name="labelname"></param>
        /// <param name="value"></param>
        /// <param name="index"></param>
        public async Task SetTextAreaFieldAsync(string labelnameorlocator, string value, bool islocator = false, int index = 1, string displayname = null)
        {
           var labelnameorlocator1 = displayname ?? labelnameorlocator;
           
           // Skip if value is null or empty
           if (string.IsNullOrEmpty(value))
           {
               logger.WriteLine($"⊘ Skipped '{labelnameorlocator1}' text area - value is empty");
               return;
           }

            var element = await GetTextAreaFieldByLabelAsync(labelnameorlocator, islocator, index);
            await element.ClickAsync();
            await element.ClearAsync();
            await element.FillAsync("");
            await element.FillAsync(value);
            logger.WriteLine($"✓ Set '{labelnameorlocator1}' text area with value: {value}");
        }

        public async Task SetDOBFieldAsync(string labelnameorlocator, string value, bool isLocator = false, int index = 1, string displayname = null)
        {
            var labelnameorlocator1 = displayname ?? labelnameorlocator;
            if (!string.IsNullOrEmpty(value))
            {
                var element = await GetTextAreaFieldByLabelAsync(labelnameorlocator, isLocator, index);
                await element.ClearAsync();
                await element.ClickAsync();
                await Task.Delay(2000);
                await element.FillAsync(value);
                logger.WriteLine($"✓ Set '{labelnameorlocator1}' DOB field with value: {value}");
            }
            else
            {
                logger.WriteLine($"⊘ Skipped '{labelnameorlocator1}' DOB field - value is empty");
            }
        }

        /// <summary>
        /// helps to enter a value into custom input field (TextBox) like VIN,SSN etc
        /// </summary>
        /// <param name="labelnameorlocator">The labelnameorlocator.</param>
        /// <param name="value">The value.</param>
        /// <param name="islocator">if set to <c>true</c> [islocator].</param>
        /// <param name="index">The index.</param>
        public async Task SetCustomTextAreaFieldAsync(string labelnameorlocator, string value, bool islocator = false, int index = 1, string displayname = null)
        {
            var labelnameorlocator1 = displayname ?? labelnameorlocator;
            if (!string.IsNullOrEmpty(value))
            {
                var element = await GetCustomTextAreaFieldByLabelAsync(labelnameorlocator, islocator, index);
              
                await element.ClearAsync();
                await element.ClickAsync();
               await Task.Delay(2000);
                await element.FillAsync(value);
                logger.WriteLine($"✓ Set '{labelnameorlocator1}' custom text area with value: {value}");
            }
            else
            {
                logger.WriteLine($"⊘ Skipped '{labelnameorlocator1}' custom text area - value is empty");
            }
        }

        /// <summary>
        /// helps to validate the text available in input field with expected value.
        /// </summary>
        /// <param name="labelname"></param>
        /// <param name="expectedText"></param>
        public async Task<bool> VerifyTextAreaFieldValueAsync(string labelnameorlocator, string expectedText, bool islocator = false, int index = 1, string displayname = null)
        {
            var element = await GetTextAreaFieldByLabelAsync(labelnameorlocator, islocator, index);
            var labelnameorlocator1 = displayname ?? labelnameorlocator;
            var actualValue = await element.GetAttributeAsync("value");
            if (actualValue == expectedText)
            {
                logger.WriteLine(string.Format("'{0}' Input field Validation success", labelnameorlocator1));
                return true;
            }
            else
            {
                logger.WriteLine(string.Format("'{0}' Input field Validation is not success ", labelnameorlocator1));
                return false;
            }
        }

        /// <summary>
        /// helps to validate the element existance or not with expected value
        /// </summary>
        /// <param name="labelnameorlocator">The labelnameorlocator.</param>
        /// <param name="islocator">if set to <c>true</c> [islocator].</param>
        /// <param name="index">The index.</param>
        /// <returns>bool value </returns>
        public async Task <bool> VerifyTextAreaFieldExistAsync(string labelnameorlocator, bool islocator = false, int index = 1, string displayname = null)
        {
            var element = await GetTextAreaFieldByLabelAsync(labelnameorlocator, islocator, index);
             var labelnameorlocator1 = displayname ?? labelnameorlocator;
            if (element != null)
            {
                logger.WriteLine(string.Format("'{0}' Text box exist ", labelnameorlocator1));
                return true;
            }
            else
            {
                logger.WriteLine(string.Format("'{0}' Text box does not exist ", labelnameorlocator1));
                return false;
            }
        }

        /// <summary>
        /// helps to formulate the xpath for input field(TextBox).
        /// </summary>
        /// <param name="labelnameorlocator">The labelnameorlocator.</param>
        /// <param name="islocator">if set to <c>true</c> [islocator].</param>
        /// <param name="index">The index.</param>
        /// <returns></returns>
        private async Task <ILocator> GetTextAreaFieldByLabelAsync(string labelnameorlocator, bool islocator = false, int index = 1)
        {
            var XPathLocator = string.Empty;
            try
            {
                if (islocator)
                {
                    XPathLocator = string.Format("({0})[{1}]", labelnameorlocator, index);
                }
                else
                {
                    // XPathLocator = string.Format("(//label[.=normalize-space(\"{0}\")]/..//input)[{1}]", labelnameorlocator, index);
                    XPathLocator = string.Format("(//*[.=normalize-space(\"{0}\")]//following::textarea)[{1}]", labelnameorlocator, index);
                }

                ILocator element;
                if (_frameLocator != null)
                {
                    element = _frameLocator.Locator(XPathLocator);
                }
                else
                {
                    element = _page.Locator(XPathLocator);
                }

                await element.WaitForAsync(new() { State = WaitForSelectorState.Visible });
                return element;
            }
            catch (Exception ex)
            {
                logger.WriteLine("Error:Element locator " + labelnameorlocator + " did not match any elements." + ex);
                return null;
            }
        }

        /// <summary>
        /// helps to formulate the xpath for custom input field(TextBox).
        /// </summary>
        /// <param name="labelnameorlocator">The labelnameorlocator.</param>
        /// <param name="islocator">if set to <c>true</c> [islocator].</param>
        /// <param name="index">The index.</param>
        /// <returns></returns>
        private async Task <ILocator> GetCustomTextAreaFieldByLabelAsync(string labelnameorlocator, bool islocator = false, int index = 1)
        {
            var XPathLocator = string.Empty;
            try
            {
                XPathLocator = islocator
                    ? string.Format("({0})[{1}]", labelnameorlocator, index)
                    : string.Format("(//*[.=normalize-space(\"{0}\")]/../parent::div/following::textarea)[{1}]", labelnameorlocator, index);

                ILocator element;
                if (_frameLocator != null)
                {
                    element = _frameLocator.Locator(XPathLocator);
                }
                else
                {
                    element = _page.Locator(XPathLocator);
                }

                await element.WaitForAsync(new() { State = WaitForSelectorState.Visible });
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

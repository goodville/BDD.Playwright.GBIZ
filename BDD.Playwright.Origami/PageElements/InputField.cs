using Microsoft.Playwright;
using Reqnroll;
using System.Threading.Tasks;

namespace BDD.Playwright.GBIZ.PageElements
{
    public class InputField(ScenarioContext scenarioContext): BaseElement(scenarioContext)
    {
       
       
        /// <summary>
        /// Initializes a new instance of the <see cref="InputField"/> class.
        /// helps to enter a value into input field(TextBox).
        /// </summary>
        /// <param name="labelname"></param>
        /// <param name="value"></param>
        /// <param name="index"></param>
        public async Task SetInputFieldAsync(string labelnameorlocator, string value, bool islocator = false, int index = 1, string displayname = null)
        {
            var labelnameorlocator1 = displayname ?? labelnameorlocator;
            
            // Skip if value is null or empty
            if (string.IsNullOrEmpty(value))
            {
                logger.WriteLine($"⊘ Skipped '{labelnameorlocator1}' input field - value is empty");
                return;
            }

            var element = await GetInputFieldByLabelAsync(labelnameorlocator, islocator, index);
            await element.ClearAsync();
            await element.FillAsync(value);
            var Enteredvalue = await element.GetAttributeAsync("value");
            if (string.IsNullOrEmpty(Enteredvalue))
            {
                await Task.Delay(1000);
                await element.FillAsync(value);
            }

            Enteredvalue = await element.GetAttributeAsync("value");
            logger.WriteLine($"✓ Set '{labelnameorlocator1}' input field with value: {value}");
        }

        public async Task SetInputFieldReplaceValueAsync(string labelnameorlocator, string value, bool islocator = false, int index = 1, string displayname = null)
        {
            var labelnameorlocator1 = displayname ?? labelnameorlocator;
            
            // Skip if value is null or empty
            if (string.IsNullOrEmpty(value))
            {
                logger.WriteLine($"⊘ Skipped '{labelnameorlocator1}' input field replace - value is empty");
                return;
            }

            var element = await GetInputFieldByLabelAsync(labelnameorlocator, islocator, index);
            await element.PressAsync("Control+A");
            await element.FillAsync(value);
            var Enteredvalue = await element.GetAttributeAsync("value");
            if (string.IsNullOrEmpty(Enteredvalue))
            {
                await Task.Delay(2000);
                await element.FillAsync(value);
            }

            Enteredvalue = await element.GetAttributeAsync("value");
            logger.WriteLine($"✓ Replaced '{labelnameorlocator1}' input field with value: {value}");
        }

        /// <summary>
        /// helps to enter a value into input field(TextBox).
        /// </summary>
        /// <param name="labelname"></param>
        /// <param name="value"></param>
        /// <param name="index"></param>
        public async Task SetDropdownFieldAsync(string labelnameorlocator, string value, bool islocator = false, int index = 1, string displayname = null)
        {
            var labelnameorlocator1 = displayname ?? labelnameorlocator;
            
            // Skip if value is null or empty
            if (string.IsNullOrEmpty(value))
            {
                logger.WriteLine($"⊘ Skipped '{labelnameorlocator1}' dropdown field - value is empty");
                return;
            }

            var element = await GetDropDownByLabelAsync(labelnameorlocator, islocator, index);
            await element.ClearAsync();
            await element.FillAsync("");
            await element.FillAsync(value);
            await Task.Delay(2000); 
            await element.PressAsync("Tab");
            var Enteredvalue = await element.GetAttributeAsync("value");
            if (string.IsNullOrEmpty(Enteredvalue))
            {
                await Task.Delay(2000);
                await element.FillAsync(value);
            }

            Enteredvalue = await element.GetAttributeAsync("value");
            logger.WriteLine($"✓ Set '{labelnameorlocator1}' dropdown field with value: {value}");
        }

        public async Task SetDropdownFieldForListLoadAsync(string labelnameorlocator, string value, bool islocator = false, int index = 1, string displayname = null)
        {
            var labelnameorlocator1 = displayname ?? labelnameorlocator;
            
            // Skip if value is null or empty
            if (string.IsNullOrEmpty(value))
            {
                logger.WriteLine($"⊘ Skipped '{labelnameorlocator1}' dropdown field for list load - value is empty");
                return;
            }

            var element = await GetDropDownByLabelAsync(labelnameorlocator, islocator, index);
            await element.ClearAsync();
            await element.FillAsync("");
            await element.FillAsync(value);
           
            try
            {
                await element.Page.WaitForSelectorAsync(".ac_results", new() { State = WaitForSelectorState.Visible, Timeout = 10000 });
            }
            catch (TimeoutException)
            {
                logger.WriteLine("No suggestion list appeared for the entered value.");
            }

            await element.PressAsync("Tab");
            var Enteredvalue = await element.GetAttributeAsync("value");
            if (string.IsNullOrEmpty(Enteredvalue))
            {
                await Task.Delay(2000);
                await element.FillAsync(value);
            }

            Enteredvalue = await element.GetAttributeAsync("value");
            logger.WriteLine($"Set '{labelnameorlocator1}' dropdown field with list load - value: {value}");
        }

        /// <summary>
        /// helps to enter a value into custom input field (TextBox) like VIN,SSN etc
        /// </summary>
        /// <param name="labelname"></param>
        /// <param name="value"></param>
        /// <param name="index"></param>
        public async Task SetHyperLinkInputFieldAsync(string labelnameorlocator, string value, bool islocator = false, int index = 1, string displayname = null)
        {
            var labelnameorlocator1 = displayname ?? labelnameorlocator;
            if (!string.IsNullOrEmpty(value))
            {
                var element = await GetHyperLinkInputFieldByLabelAsync(labelnameorlocator, islocator, index);
                await element.ClearAsync();
                await element.FillAsync("");
                await element.FillAsync(value);
                await element.PressAsync("Tab");
                var Enteredvalue = await element.GetAttributeAsync("value");
                if (string.IsNullOrEmpty(Enteredvalue))
                {
                    Thread.Sleep(2000);
                    await element.FillAsync(value);
                }

                Enteredvalue = await element.GetAttributeAsync("value");
                logger.WriteLine($"✓ Set '{labelnameorlocator1}' hyperlink input field with value: {value}");
            }
            else
            {
                logger.WriteLine($"⊘ Skipped '{labelnameorlocator1}' hyperlink input field - value is empty");
            }
        }

        /// <summary>
        /// helps to enter a value into custom input field (TextArea) like VIN,SSN etc
        /// </summary>
        /// <param name="labelname"></param>
        /// <param name="value"></param>
        /// <param name="index"></param>
        public async Task SetTextAreaInputFieldAsync(string labelnameorlocator, string value, bool islocator = false, int index = 1, string displayname = null)
        {
           var labelnameorlocator1 = displayname ?? labelnameorlocator;
            if (!string.IsNullOrEmpty(value))
            {
                var element = await GetTextAreaInputFieldByLabelAsync(labelnameorlocator, islocator, index);
                await element.ClearAsync();
                await element.FillAsync("");
                await element.FillAsync(value);
                await element.PressAsync("Tab");
                logger.WriteLine($"✓ Set '{labelnameorlocator1}' text area input field with value: {value}");
            }
            else
            {
                logger.WriteLine($"⊘ Skipped '{labelnameorlocator1}' text area input field - value is empty");
            }
        }

        public async Task TextAreaInputFieldWithoutClearingDataAsync(string labelnameorlocator, string value, bool islocator = false, int index = 1, string displayname = null)
        {
           var labelnameorlocator1 = displayname ?? labelnameorlocator;
            if (!string.IsNullOrEmpty(value))
            {
                var element = await GetTextAreaInputFieldByLabelAsync(labelnameorlocator, islocator, index);
                await element.FillAsync(value);
                await element.PressAsync("Tab");
                logger.WriteLine($"✓ Appended to '{labelnameorlocator1}' text area input field with value: {value}");
            }
            else
            {
                logger.WriteLine($"⊘ Skipped '{labelnameorlocator1}' text area append - value is empty");
            }
        }

        /// <summary>
        /// helps to validate the text available in input field with expected value.
        /// </summary>
        /// <param name="labelname"></param>
        /// <param name="expectedText"></param>
        public async Task <bool> VerifyInputFieldValueAsync(string labelnameorlocator, string expectedText, bool islocator = false, int index = 1, string displayname = null)
        {
            var element = await GetInputFieldByLabelAsync(labelnameorlocator, islocator, index);
           var labelnameorlocator1 = displayname ?? labelnameorlocator;
           var actualValue = await element.GetAttributeAsync("value");
            if (actualValue != expectedText) 
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
        /// <param name="labelname"></param>
        public async Task <bool> VerifyInputFieldExistAsync(string labelnameorlocator, bool islocator = false, int index = 1, string displayname = null)
        {
           var element = await GetInputFieldByLabelAsync(labelnameorlocator, islocator, index);
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
        /// <param name="labelname"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        /// <exception cref="NotFoundException"></exception>
        private async Task <ILocator> GetInputFieldByLabelAsync(string labelnameorlocator, bool islocator = false, int index = 1)
        {
            var XPathLocator = string.Empty;
            try
            {
                XPathLocator = islocator
                    ? string.Format("({0})[{1}]", labelnameorlocator, index)
                    : string.Format("(//*[contains(text(),\"{0}\")]//following::input)[{1}]", labelnameorlocator, index);

                var element = _frameLocator != null ? _frameLocator.Locator($"xpath={XPathLocator}") : _page.Locator($"xpath={XPathLocator}");

                await element.WaitForAsync(new() 
                { 
                  Timeout = 10000,
                  State = WaitForSelectorState.Visible });
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
        /// <param name="labelname"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        /// <exception cref="NotFoundException"></exception>
        private async Task <ILocator> GetHyperLinkInputFieldByLabelAsync(string labelnameorlocator, bool islocator = false, int index = 1)
        {
            var XPathLocator = string.Empty;
            try
            {
                XPathLocator = islocator
                    ? string.Format("({0})[{1}]", labelnameorlocator, index)
                    : string.Format("(//label/a[contains(text(),\"{0}\")]/../../following-sibling::div//input)[{1}]", labelnameorlocator, index);

                var element = _frameLocator != null ? _frameLocator.Locator($"xpath={XPathLocator}") : _page.Locator($"xpath={XPathLocator}");

                await element.WaitForAsync(new()
                {
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

        /// <summary>
        /// Gets the drop down by label.
        /// </summary>
        /// <param name="labelnameorlocator">The labelnameorlocator.</param>
        /// <param name="islocator">if set to <c>true</c> [islocator].</param>
        /// <param name="index">The index.</param>
        /// <returns>IWebElement response</returns>
        private async Task <ILocator> GetDropDownByLabelAsync(string labelnameorlocator, bool islocator = false, int index = 1)
        {
            var XPathLocator = string.Empty;
            try
            {
                XPathLocator = islocator
                    ? string.Format("({0})[{1}]", labelnameorlocator, index)
                    : string.Format("(//label[contains(text(),\"{0}\")]/../following-sibling::div//input[@type='text'])[1]", labelnameorlocator);

                var element = _frameLocator != null ? _frameLocator.Locator($"xpath={XPathLocator}") : _page.Locator($"xpath={XPathLocator}");

                await element.WaitForAsync(new()
                {
                    Timeout = 10000,
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

        public async Task <bool> VerifyDropdownFieldExistAsync(string labelnameorlocator, bool islocator = false, int index = 1, string displayname = null)
        {
            var element = await GetDropDownByLabelAsync(labelnameorlocator, islocator, index);
            var labelnameorlocator1 = displayname ?? labelnameorlocator;
            if (element != null)
            {
                logger.WriteLine(string.Format("'{0}' Dropdown Field exist", labelnameorlocator1));
                return true;
            }
            else
            {
                logger.WriteLine(string.Format("'{0}' Dropdown Field does not exist ", labelnameorlocator1));
                return false;
            }
        }

        /// <summary>
        /// helps to formulate the xpath for custom input field(TextBox).
        /// </summary>
        /// <param name="labelname"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        /// <exception cref="NotFoundException"></exception>
        private async Task <ILocator> GetTextAreaInputFieldByLabelAsync(string labelnameorlocator, bool islocator = false, int index = 1)
        {
            var XPathLocator = string.Empty;
            try
            {
                XPathLocator = islocator
                    ? string.Format("({0})[{1}]", labelnameorlocator, index)
                    : string.Format("(//*[contains(text(),\"{0}\")]//following::textarea)[{1}]", labelnameorlocator, index);
                var element = _frameLocator != null ? _frameLocator.Locator($"xpath={XPathLocator}") : _page.Locator($"xpath={XPathLocator}");

                await element.WaitForAsync(new()
                {
                    Timeout = 10000,
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

        /// <summary>
        /// helps to enter a value into input field(TextBox).
        /// </summary>
        /// <param name="labelname"></param>
        /// <param name="value"></param>
        /// <param name="index"></param>
        public async Task SetInputFieldWithoutClearAsync(string labelnameorlocator, string value, bool islocator = false, int index = 1, string displayname = null)
        {
            var labelnameorlocator1 = displayname ?? labelnameorlocator;
            
            // Skip if value is null or empty
            if (string.IsNullOrEmpty(value))
            {
                logger.WriteLine($"⊘ Skipped '{labelnameorlocator1}' input field without clear - value is empty");
                return;
            }

            var element = await GetInputFieldByLabelAsync(labelnameorlocator, islocator, index);
            await element.FillAsync("");
            await element.FillAsync(value);
            await element.PressAsync("Tab");
            logger.WriteLine($"✓ Set '{labelnameorlocator1}' input field without clear - value: {value}");
        }
        
        public async Task SetInputFieldWithClearAsync(string labelnameorlocator, string value, bool islocator = false, int index = 1, string displayname = null)
        {
            var labelnameorlocator1 = displayname ?? labelnameorlocator;
            
            // Skip if value is null or empty
            if (string.IsNullOrEmpty(value))
            {
                logger.WriteLine($"⊘ Skipped '{labelnameorlocator1}' input field with clear - value is empty");
                return;
            }

            var element = await GetInputFieldByLabelAsync(labelnameorlocator, islocator, index);
            await element.ClearAsync();
            await element.FillAsync("");
            await element.FillAsync(value);
            await element.PressAsync("Tab");
            logger.WriteLine($"✓ Set '{labelnameorlocator1}' input field with clear - value: {value}");
        }

        internal async Task GetTextAreaInputFieldByLabelAsync(string item1, string item2)
        {
            throw new NotImplementedException();
        }

        internal async Task<bool>WaitForElementAsync(ILocator element)
        { 
            {
                try
                {
                    await element.WaitForAsync(new()
                    { State = WaitForSelectorState.Visible });

                    var isVisible = await element.IsVisibleAsync();
                    var isEnabled = await element.IsEnabledAsync();

                    return isVisible && isEnabled;
                   
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }
    }
}

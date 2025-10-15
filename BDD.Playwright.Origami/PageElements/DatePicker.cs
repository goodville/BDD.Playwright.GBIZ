using Microsoft.Playwright;
using Reqnroll;

namespace BDD.Playwright.GBIZ.PageElements
{
    public class DatePicker(ScenarioContext scenarioContext) : BaseElement(scenarioContext)
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="DatePicker"/> class.
        /// </summary>
        /// <param name="driver">The driver.</param>
        /// <param name="ReqnrollOutputHelper">The spec flow output helper.</param>
        /// <param name="driverwait">The driverwait.</param>
      

        /// <summary>
        /// Selects the date.
        /// </summary>
        /// <param name="labelname">The labelname.</param>
        /// <param name="value">The value.</param>
        /// <param name="index">The index.</param>
        public async Task SelectDateAsync(string labelname, string value, int index = 1)
        {
            try
            {
                var element = await GetDatePickerByLabelAsync(labelname, index);

                if (element != null)
                {
                    await element.ClickAsync();
                }

                var datelist = value.Split("/");

                await SelectCalenderDateAsync(datelist[2], datelist[1], datelist[0]);
            }
            catch (Exception ex)
            {
                logger.WriteLine(string.Format("Unable to select date '{0}' in calender\n Error : {1}", value, ex.Message));
            }
        }

        private async Task SelectCalenderDateAsync(string year, string month, string date)
        {
           
            var yearLocator = _page.Locator("//div[@id='ui-datepicker-div']//select[@class='ui-datepicker-year']");
            await yearLocator.SelectOptionAsync(new SelectOptionValue { Label = year });

            var monthLocator = _page.Locator("//div[@id='ui-datepicker-div']//select[@class='ui-datepicker-month']");
            await monthLocator.SelectOptionAsync(new SelectOptionValue { Label = month });

            var dateLocator = _page.Locator($"//table[@class='ui-datepicker-calendar']//td/span[contains(text(),\"{date}\")]");
            await dateLocator.ClickAsync();
        }

        /// <summary>
        /// Verifies the label text.
        /// </summary>
        /// <param name="labelname">The labelname.</param>
        /// <param name="expectedText">The expected text.</param>
        /// <param name="index">The index.</param>
        /// <returns>bool value</returns>
        public async Task<bool> VerifyLabelTextAsync(string labelname, string expectedText, int index = 1)
        {
            var element = await GetDatePickerByLabelAsync(labelname, index);

            if (element != null)
            {
                var actualText = await element.TextContentAsync();
                if (actualText != null && actualText.Equals(expectedText))
                {
                    logger.WriteLine(string.Format("'{0}' DatePicker Value validation is success", labelname));
                    return true;
                }
                else
                {
                    logger.WriteLine(string.Format("'{0}' DatePicker value validation is not success ", labelname));
                    return false;
                }
            }
            else
            {
                logger.WriteLine(string.Format("'{0}' DatePicker element not found ", labelname));
                return false;
            }
        }

        /// <summary>
        /// Verifies the label exist.
        /// </summary>
        /// <param name="labelname">The labelname.</param>
        /// <param name="index">The index.</param>
        /// <returns>bool value</returns>
        public async Task<bool> VerifyLabelExistAsync(string labelname, int index = 1)
        {
            var element = await GetDatePickerByLabelAsync(labelname, index);

            if (element != null)
            {
                logger.WriteLine(string.Format("'{0}' Date picker exist ", labelname));
                return true;
            }
            else
            {
                logger.WriteLine(string.Format("'{0}' Date picker does not exist ", labelname));
                return false;
            }
        }

        private async Task<ILocator> GetDatePickerByLabelAsync(string labelname, int index = 1)
        {
            try
            {
                var XPathLocator = $"(//label[normalize-space(text())=\"{labelname}\"]/..//input)[{index}]/following-sibling::button";
                ILocator element;
                if (_frameLocator != null)
                {
                    element = _frameLocator.Locator($"xpath={XPathLocator}");
                }
                else
                {
                    element = _page.Locator($"xpath={XPathLocator}");
                }

                if (await element.CountAsync() > 0)
                {
                    return element;
                }
                else
                {
                    logger.WriteLine("Error:Element locator " + labelname + " did not match any elements.");
                    throw new Exception("Element not found");
                }
            }
            catch (Exception ex)
            {
                logger.WriteLine("Error:Element locator " + labelname + " did not match any elements.");
                throw new Exception(ex.Message, ex.InnerException);
            }
        }
    }
}

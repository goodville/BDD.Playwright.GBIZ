using Microsoft.Playwright;
using Reqnroll;
using System;
using System.Threading.Tasks;

namespace BDD.Playwright.POM.Helpers
{
    /// <summary>
    /// Helper methods for general functions.
    /// </summary>
    public class GenericHelper
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly ApplicationLogger _applicationLogger; 
        private readonly IPage _page; 

        public GenericHelper(ScenarioContext scenarioContext, ApplicationLogger applicationLogger) 
        {
            _scenarioContext = scenarioContext;
            _applicationLogger = applicationLogger;
            _page = scenarioContext.Get<IPage>("Page");
        }

        

        public async Task TypeInTextBoxAsync(ILocator element, string text) // Use selector string
        {
            try
            {
                await element.FillAsync(text); // Use FillAsync (clears automatically)
                await element.PressAsync("Tab"); // Simulate Tab key press
            }
            catch (Exception e)
            {
                _applicationLogger.WriteLine(e.Message);
            }
            _applicationLogger.WriteLine($"Type in Textbox @ {element.ToString()} : value : {text}");
        }

        public async Task TypeInTextBoxWithKeysActionAsync(string selector, string text)
        {
            try
            {
                ILocator element = _page.Locator(selector);
                await element.ClickAsync();
                for (int i = 0; i < 15; i++)
                {
                    await element.PressAsync("Backspace");
                    await element.PressAsync("Delete");
                }
                await element.FillAsync(text);
                await element.PressAsync("Tab");
            }
            catch (Exception e)
            {
                _applicationLogger.WriteLine(e.Message);
            }
            _applicationLogger.WriteLine($"Type in Textbox @ {selector} : value : {text}");
        }

        public async Task TypeInTextBoxUnderwriterAsync(string selector, string text)
        {
            try
            {
                ILocator element = _page.Locator(selector);
                await element.FillAsync(text); // Use FillAsync
                await element.PressAsync("Tab");
            }
            catch (Exception e)
            {
                _applicationLogger.WriteLine(e.Message);
            }
            _applicationLogger.WriteLine($"Type in Textbox @ {selector} : value : {text}");
        }


        public async Task ScrollToElementAsync(ILocator locator)
        {
            await locator.ScrollIntoViewIfNeededAsync();
        }

        public async Task WaitForElementToBeInteractableAsync(string selector, int timeoutInSeconds = 60)
        {
            await _page.WaitForSelectorAsync(selector, new PageWaitForSelectorOptions { State = WaitForSelectorState.Visible, Timeout = timeoutInSeconds * 1000 }); // Wait for visibility
            ILocator locator = _page.Locator(selector);
            await locator.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Visible, Timeout = timeoutInSeconds * 1000 }); // Wait until enabled, interactable
        }
        

        public async Task UserWaitForPageToLoadCompletelyAsync()
        {
            await _page.WaitForLoadStateAsync(LoadState.DOMContentLoaded); // Or LoadState.Load
        }

        
    }
}

using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Playwright;
using Reqnroll;

namespace GoodVille.GBIZ.Reqnroll.Automation.PageElements
{
    public class IFrame : BaseElement
    {
        private new readonly ScenarioContext _scenarioContext;
        private readonly IPage _mainPage;

        public IFrame(ScenarioContext scenarioContext) : base(scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _mainPage = _page;
        }

        /// <summary>
        /// Switches to the first iframe found on the page.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task SwitchToIframeAsync()
        {
            try
            {
                var frameElement = _page.Locator("iframe").First;
                await frameElement.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Attached });
                
                var frameElementHandle = await frameElement.ElementHandleAsync();
                var frame = await frameElementHandle!.ContentFrameAsync();
                if (frame != null)
                {
                    _scenarioContext.Set(frame, "CurrentFrame");
                    _applicationLogger.WriteLine("Successfully switched to iframe");
                }
                else
                {
                    throw new Exception("Unable to get frame content");
                }
            }
            catch (Exception ex)
            {
                throw new TimeoutException("Unable to Switch to Frame", ex);
            }
        }

        /// <summary>
        /// Switches to iframe using XPath selector.
        /// </summary>
        /// <param name="xpath">The XPath selector for the iframe.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task SwitchToIframeByXpathAsync(string xpath)
        {
            try
            {
                var frameElement = _page.Locator($"xpath={xpath}");
                await frameElement.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Attached });
                
                var frameElementHandle = await frameElement.ElementHandleAsync();
                var frame = await frameElementHandle!.ContentFrameAsync();
                if (frame != null)
                {
                    _scenarioContext.Set(frame, "CurrentFrame");
                    _applicationLogger.WriteLine($"Successfully switched to iframe using XPath: {xpath}");
                }
                else
                {
                    throw new Exception("Unable to get frame content");
                }
            }
            catch (Exception ex)
            {
                throw new TimeoutException("Unable to Switch to Frame", ex);
            }
        }

        /// <summary>
        /// Switches back to the parent frame.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task SwitchToParentFrameAsync()
        {
            try
            {
                _scenarioContext.Set(_mainPage, "Page");
                _applicationLogger.WriteLine("Successfully switched to parent frame");
                await Task.CompletedTask;
            }
            catch (Exception ex)
            {
                throw new TimeoutException("Unable to Switch to Parent Frame", ex);
            }
        }

        /// <summary>
        /// Switches back to the default content (main page).
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task CloseAsync()
        {
            try
            {
                _scenarioContext.Set(_mainPage, "Page");
                _applicationLogger.WriteLine("Successfully switched to default content");
                await Task.CompletedTask;
            }
            catch (Exception ex)
            {
                _applicationLogger.WriteLine($"Error switching to default content: {ex.Message}");
            }
        }

        /// <summary>
        /// Switches to a new window/tab.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task SwitchToWindowAsync()
        {
            try
            {
                var context = _page.Context;
                var pages = context.Pages;
                
                if (pages.Count > 1)
                {
                    // Switch to the latest opened page
                    var newPage = pages.Last();
                    _scenarioContext.Set(newPage, "Page");
                    _applicationLogger.WriteLine("Switched to new window");
                }
                else
                {
                    // Wait for new page to open
                    var newPageTask = context.WaitForPageAsync();
                    var newPage = await newPageTask;
                    _scenarioContext.Set(newPage, "Page");
                    _applicationLogger.WriteLine("Switched to new window");
                }
            }
            catch (Exception ex)
            {
                throw new TimeoutException("Unable to Switch to Window", ex);
            }
        }

        /// <summary>
        /// Closes the current window and switches back to the main window.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task CurrentWindowCloseAsync()
        {
            try
            {
                var context = _page.Context;
                var currentPage = _page;
                
                await currentPage.CloseAsync();
                _applicationLogger.WriteLine("Current window has been closed");
                
                // Switch back to the first page
                var pages = context.Pages;
                if (pages.Count > 0)
                {
                    _scenarioContext.Set(pages.First(), "Page");
                    _applicationLogger.WriteLine("Switched back to main window");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to close the Window", ex);
            }
        }
    }
}

namespace BDD.Playwright.Core.Helpers
{
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.Playwright;

    /// <summary>
    /// Browser Helper.
    /// </summary>
    public static class BrowserHelper
    {
        /// <summary>
        /// Maximize the Browser.
        /// </summary>
        /// <param name="page">Playwright Page Instance</param>
        /// <example>How to use it: <code>
        /// BrowserHelper.BrowserMaximize(page);
        /// </code></example>
        /// <returns>void.</returns>
        public static async Task BrowserMaximizeAsync(this IPage page) => await page.SetViewportSizeAsync(1920, 1080); // Maximizing the window by setting a large viewport

        /// <summary>
        /// Navigated Back.
        /// </summary>
        /// <param name="page">Playwright Page Instance</param>
        /// <example>How to use it: <code>
        /// BrowserHelper.GoBack(page);
        /// </code></example>
        /// <returns>void.</returns>
        public static async Task GoBackAsync(this IPage page) => await page.GoBackAsync();

        /// <summary>
        /// Navigated Forward.
        /// </summary>
        /// <param name="page">Playwright Page Instance</param>
        /// <example>How to use it: <code>
        /// BrowserHelper.Forward(page);
        /// </code></example>
        /// <returns>void.</returns>
        public static async Task ForwardAsync(this IPage page) => await page.GoForwardAsync();

        /// <summary>
        /// Refresh Browser Page.
        /// </summary>
        /// <param name="page">Playwright Page Instance</param>
        /// <example>How to use it: <code>
        /// BrowserHelper.RefreshPage(page);
        /// </code></example>
        /// <returns>void.</returns>
        public static async Task RefreshPageAsync(this IPage page) => await page.ReloadAsync();

        /// <summary>
        /// Get Title of browser page.
        /// </summary>
        /// <param name="page">Playwright Page Instance</param>
        /// <returns>Returns title of browser page. String</returns>
        public static string GetTitle(this IPage page) => page.GetTitle();

        /// <summary>
        /// Switch to Browser Tab Window
        /// </summary>
        /// <param name="browserContext">Playwright Browser Instance</param>
        /// <param name="index">index value of window</param>
        /// <example>How to use it: <code>
        /// BrowserHelper.SwitchToWindow(browser, 1);
        /// </code></example>
        /// <returns>Void.</returns>
        public static async Task SwitchToWindowAsync(this IBrowserContext browserContext, int index = 0)
        {
            var pages = browserContext.Pages;
            if (pages.Count > index)
            {
                var page = pages[index];
                await page.BringToFrontAsync();
            }
            else
            {
                throw new System.Exception("Invalid Browser Window Index");
            }
        }

        /// <summary>
        /// Switch to Parent browser window
        /// </summary>
        /// <param name="browserContext">Playwright Browser Instance</param>
        /// <example>How to use it: <code>
        /// BrowserHelper.SwitchToParent(browser);
        /// </code></example>
        /// <returns>void.</returns>
        public static async Task SwitchToParentAsync(this IBrowserContext browserContext)
        {
            var pages = browserContext.Pages;
            if (pages.Count > 1)
            {
                var parentPage = pages[0];
                await parentPage.BringToFrontAsync();
                for (var i = pages.Count - 1; i > 0; i--)
                {
                    await pages[i].CloseAsync();
                }
            }
        }

        /// <summary>
        /// Switch to Frame.
        /// </summary>
        /// <param name="page">Playwright Page Instance</param>
        /// <param name="frameName">Frame name or locator</param>
        /// <example>How to use it: <code>
        /// BrowserHelper.SwitchToFrame(page, "frameName");
        /// </code></example>
        /// <returns>IFrame.</returns>
        public static IFrame SwitchToFrame(this IPage page, string frameName) => page.Frames.FirstOrDefault(f => f.Name == frameName);
    }
}

namespace BDD.Playwright.POM.Helpers
{
    /// <summary>
    /// Helper methods for Alerts handling
    /// </summary>
    public static class AlertHelper
    {
        /// <summary>
        /// Verify the Alert Popup is present
        /// </summary>
        /// <param name="page">IPage Instance</param>
        /// <returns>Return boolean true/false for alert displayed</returns>
        public static async Task<bool> IsPopupPresentAsync(this IPage page)
        {
            try
            {
                var alert = await page.WaitForEventAsync(PageEvent.Dialog, new PageWaitForEventOptions { Timeout = 5000 });
                return alert != null;
            }
            catch (TimeoutException)
            {
                return false;
            }
        }

        /// <summary>
        /// Return text present on alert
        /// </summary>
        /// <param name="page">IPage Instance</param>
        /// <returns>Return string if alert present</returns>
        public static async Task<string> GetPopUpTextAsync(this IPage page)
        {
            if (!await page.IsPopupPresentAsync())
            {
                return string.Empty;
            }

            var dialog = await page.WaitForEventAsync(PageEvent.Dialog);
            return dialog.Message;
        }

        /// <summary>
        /// Click Ok button on alert
        /// </summary>
        /// <param name="page">IPage Instance</param>
        public static async Task ClickOkOnPopupAsync(this IPage page)
        {
            if (!await page.IsPopupPresentAsync())
            {
                return;
            }

            var dialog = await page.WaitForEventAsync(PageEvent.Dialog);
            await dialog.AcceptAsync();
        }

        /// <summary>
        /// Click Cancel button on alert
        /// </summary>
        /// <param name="page">IPage Instance</param>
        public static async Task ClickCancelOnPopupAsync(this IPage page)
        {
            if (!await page.IsPopupPresentAsync())
            {
                return;
            }

            var dialog = await page.WaitForEventAsync(PageEvent.Dialog);
            await dialog.DismissAsync();
        }

        /// <summary>
        /// Enter text when alert text box is present
        /// </summary>
        /// <param name="page">IPage Instance</param>
        /// <param name="text">Text to enter</param>
        public static async Task SendKeysAsync(this IPage page, string text)
        {
            if (!await page.IsPopupPresentAsync())
            {
                return;
            }

            var dialog = await page.WaitForEventAsync(PageEvent.Dialog);
            await dialog.AcceptAsync(text);
        }
    }
}
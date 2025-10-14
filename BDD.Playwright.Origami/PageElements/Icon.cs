using System.Threading.Tasks;
using Microsoft.Playwright;
using Reqnroll;

namespace BDD.Playwright.Origami.PageElements
{
    /// <summary>
    /// Playwright migration of Selenium Icon element.
    /// </summary>
    public class Icon : BaseElement
    {
        public Icon(ScenarioContext scenarioContext) : base(scenarioContext)
        {
        }

        // Backward-compatible sync wrappers
        public void ClickIcon(string labelnameorlocator, ActionType action = ActionType.Click, bool islocator = false, int index = 1, string displayname = null) => ClickAsync(labelnameorlocator, action, islocator, index, displayname).GetAwaiter().GetResult();
        public bool VerifyIconExist(string labelnameorlocator, bool islocator = false, int index = 1, string displayname = null) => VerifyExistAsync(labelnameorlocator, islocator, index, displayname).GetAwaiter().GetResult();

        public async Task ClickAsync(string labelOrLocator, ActionType action = ActionType.Click, bool isLocator = false, int index = 1, string? displayName = null)
        {
            var icon = await ResolveIconAsync(labelOrLocator, isLocator, index);
            var name = displayName ?? labelOrLocator;
            if (icon == null)
            {
                _applicationLogger.WriteLine($"Icon: '{name}' not found.");
                return;
            }

            if (action == ActionType.Click)
            {
                await icon.ClickAsync();
            }
            else if (action == ActionType.Hover)
            {
                await icon.HoverAsync();
            }

            _applicationLogger.WriteLine($"Icon: Performed {action} on '{name}'.");
        }

        public async Task<bool> VerifyExistAsync(string labelOrLocator, bool isLocator = false, int index = 1, string? displayName = null)
        {
            var icon = await ResolveIconAsync(labelOrLocator, isLocator, index);
            var name = displayName ?? labelOrLocator;
            var exists = icon != null && await icon.CountAsync() > 0;
            _applicationLogger.WriteLine(exists
                ? $"Icon: '{name}' exists."
                : $"Icon: '{name}' NOT found.");
            return exists;
        }

        private async Task<ILocator?> ResolveIconAsync(string labelOrLocator, bool isLocator, int index)
        {
            if (isLocator)
            {
                var loc = _page.Locator($"({labelOrLocator})[{index}]");
                return await loc.CountAsync() > 0 ? loc.First : null;
            }

            var locator = _page.Locator($"(//*[normalize-space(.)='{labelOrLocator}']/../../descendant::div[contains(@class,'gw-icon gw-icon--expand')])[{index}]");
            return await locator.CountAsync() == 0 ? null : locator.First;
        }
    }
}

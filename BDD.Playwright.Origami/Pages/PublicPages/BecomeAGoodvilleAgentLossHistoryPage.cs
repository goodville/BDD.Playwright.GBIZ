using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BDD.Playwright.Core.Loggers;
using BDD.Playwright.Origami.Pages.CommonPage;
using Microsoft.Playwright;
using Reqnroll;

namespace BDD.Playwright.Origami.Pages.PublicPages
{
    /// <summary>
    /// Playwright migration of legacy BecomeAGoodvilleAgentLossHistoryPage.
    /// Data driven via ScenarioContext["LossHistoryData"] dictionary.
    /// Expected keys:
    ///  - noofcarriers (int)
    ///  - For i (1..n*5) premium{i}, losshistory{i}
    /// </summary>
    public class BecomeAGoodvilleAgentLossHistoryPage : BasePage
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly ApplicationLogger _logger;
        private readonly IPage _page;

        private readonly string _premiumVolumeInput = "//input[@aria-label=\"Premium Volume ($)\"]"; // repeated list
        private readonly string _lossRatioInput = "//input[@aria-label=\"Loss Ratio (%)\"]"; // repeated list
        private readonly string _continueButton = "//button[contains(@class,'solid button-theme-primary')]";

        public BecomeAGoodvilleAgentLossHistoryPage(ScenarioContext scenarioContext) : base(scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _logger = scenarioContext.Get<ApplicationLogger>("Logger");
            _page = scenarioContext.Get<IPage>("Page");
        }

        public void FillLossHistoryData() => FillLossHistoryDataAsync().GetAwaiter().GetResult();

        public async Task FillLossHistoryDataAsync(Dictionary<string, string>? data = null, bool clickContinue = false)
        {
            data ??= _scenarioContext.TryGetValue("LossHistoryData", out Dictionary<string, string>? ctxData) ? ctxData : new Dictionary<string, string>();
            string Get(string key) => data.TryGetValue(key, out var v) ? v : string.Empty;

            if (!int.TryParse(Get("noofcarriers"), out var carrierCount) || carrierCount <= 0)
            {
                _logger.WriteLine("LossHistoryData: 'noofcarriers' missing or invalid. Nothing to fill.");
                return;
            }

            var totalRows = carrierCount * 5; // as per legacy logic
            for (var i = 1; i <= totalRows; i++)
            {
                var premium = Get($"premium{i}");
                var loss = Get($"losshistory{i}");
                await FillIndexedAsync(_premiumVolumeInput, i, premium, $"Premium {i}");
                await FillIndexedAsync(_lossRatioInput, i, loss, $"Loss Ratio {i}");
            }

            if (clickContinue && await _page.Locator(_continueButton).CountAsync() > 0)
            {
                await _page.Locator(_continueButton).First.ClickAsync();
                _logger.WriteLine("Clicked Continue on Loss History page.");
            }
        }

        private async Task FillIndexedAsync(string selector, int index, string value, string logicalName)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                _logger.WriteLine($"LossHistoryData: value empty for {logicalName}. Skipping.");
                return;
            }

            var loc = _page.Locator(selector).Nth(index - 1);
            if (await loc.CountAsync() == 0)
            {
                loc = _page.Locator(selector).First; // fallback
            }

            await loc.FillAsync(value);
            _logger.WriteLine($"Filled {logicalName} -> {value}");
        }
    }
}

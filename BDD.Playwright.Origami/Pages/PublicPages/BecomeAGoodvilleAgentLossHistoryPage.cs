using BDD.Playwright.Core.Interfaces;
using BDD.Playwright.Core.Loggers;
using BDD.Playwright.GBIZ.Pages.CommonPage;
using BDD.Playwright.Origami.Pages.CommonPage;
using Microsoft.Playwright;
using Reqnroll;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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
        private readonly IFileReader _fileReader;

        private readonly string _premiumVolumeInput = "//input[@aria-label=\"Premium Volume ($)\"]"; // repeated list
        private readonly string _lossRatioInput = "//input[@aria-label=\"Loss Ratio (%)\"]"; // repeated list
        private readonly string _continueButton = "//button[contains(@class,'solid button-theme-primary')]";

        public BecomeAGoodvilleAgentLossHistoryPage(ScenarioContext scenarioContext, IFileReader fileReader) : base(scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _logger = scenarioContext.Get<ApplicationLogger>("Logger");
            _page = scenarioContext.Get<IPage>("Page");
            _fileReader = fileReader;
        }
        public async Task FillLossHistoryDataAsync()
        {
            if (_fileReader != null)
            {
                await FillLossHistoryFromJsonDataAsync("AgentLossHistoryData");
            }
            else
            {
                await FillLossHistoryDataWithContextDataAsync();
            }
        }

        public async Task FillLossHistoryFromJsonDataAsync(string profileKey)
        {
            if (_fileReader == null)
            {
                throw new InvalidOperationException("FileReader is not available. Use constructor with IFileReader parameter.");
            }

            try
            {
                  var filePath = "AgentLossHistory\\AgentLossHistoryData.json";
                    _logger.WriteLine($"Reading Loss History data for profile '{profileKey}' from {filePath}");

                    var index = 1;
                    while (true)
                    {
                    string? premium = null;
                    string? loss = null;

                    try
                    {
                        premium = _fileReader.GetValue(filePath, $"{profileKey}.Premium{index}");
                        loss = _fileReader.GetValue(filePath, $"{profileKey}.LossHistory{index}");
                    }
                    catch (InvalidOperationException)
                    {
                        break;
                    }

                    if (string.IsNullOrWhiteSpace(premium) && string.IsNullOrWhiteSpace(loss))
                    {
                        break;
                    }
                        
                    // Fill values if present
                    if (!string.IsNullOrWhiteSpace(premium))
                        {
                            await FillIndexedAsync(_premiumVolumeInput, index, premium, $"Premium {index}");
                        }

                        if (!string.IsNullOrWhiteSpace(loss))
                        {
                            await FillIndexedAsync(_lossRatioInput, index, loss, $"Loss History {index}");
                        }

                        _logger.WriteLine($"Filled row {index}: Premium={premium ?? "N/A"}, Loss={loss ?? "N/A"}");
                        index++;
                    }

                    if (index == 1)
                    {
                        _logger.WriteLine($"No loss history data found for profile '{profileKey}'.");
                        return;
                    }

                   
                    var continueButton = _page.Locator(_continueButton);
                    if (await continueButton.CountAsync() > 0)
                    {
                        await continueButton.First.ClickAsync();
                        _logger.WriteLine("Clicked Continue on Loss History page.");
                    }

                    _logger.WriteLine($"Successfully filled Loss History rows from JSON.");
                }
                catch (Exception ex)
                {
                    _logger.WriteLine($"Error filling Loss History data from JSON: {ex.Message}");
                    throw new Exception($"Failed to fill Loss History data using profile '{profileKey}': {ex.Message}", ex);
                }
            }

        private async Task FillLossHistoryDataWithContextDataAsync()
        {
            var data = _scenarioContext.TryGetValue("AgencyLossHistoryData", out Dictionary<string, string>? ctxData)
                ? ctxData
                : new Dictionary<string, string>();

            string Get(string key) => data.TryGetValue(key, out var v) ? v : string.Empty;

            if (!int.TryParse(Get("noofcarriers"), out var carrierCount) || carrierCount <= 0)
            {
                _logger.WriteLine("LossHistoryData: 'noofcarriers' missing or invalid. Nothing to fill.");
                return;
            }

            var totalRows = carrierCount * 5;
            for (var i = 1; i <= totalRows; i++)
            {
                var premium = Get($"premium{i}");
                var loss = Get($"losshistory{i}");

                await FillIndexedAsync(_premiumVolumeInput, i, premium, $"Premium {i}");
                await FillIndexedAsync(_lossRatioInput, i, loss, $"Loss Ratio {i}");
            }

            if (await _page.Locator(_continueButton).CountAsync() > 0)
            {
                await _page.Locator(_continueButton).First.ClickAsync();
                _logger.WriteLine("Clicked Continue on Loss History page.");
            }

            _logger.WriteLine("Successfully filled Loss History data from ScenarioContext.");
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
                loc = _page.Locator(selector).First; 
            }

            await loc.FillAsync(value);
            _logger.WriteLine($"Filled {logicalName} -> {value}");
        }
    }
}

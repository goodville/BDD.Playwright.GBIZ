using BDD.Playwright.Core.Interfaces;
using BDD.Playwright.GBIZ.PageElements;
using BDD.Playwright.GBIZ.Pages.CommonPage;
using BDD.Playwright.GBIZ.Pages.GlobalPages;
using BDD.Playwright.GBIZ.Pages.PublicPages;
using BDD.Playwright.GBIZ.Pages.XpathProperties;
using Microsoft.Playwright;
using Reqnroll;
using System;
using System.Threading.Tasks;

namespace BDD.Playwright.GBIZ.Pages.AgentPages
{
    public class QuickSearchPage : BasePage
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly CommonXpath _commonXpath;
        private readonly LoginPage _loginPage;
        private readonly ReportAClaimStartPage _reportAClaimStartPage;
        private readonly ReportAClaimFormPage _reportAClaimFormPage;
        private readonly IFileReader _fileReader;

        public QuickSearchPage(
            ScenarioContext scenarioContext,
            LoginPage loginPage,
            CommonXpath commonXpath,
            ReportAClaimStartPage reportAClaimStartPage,
            ReportAClaimFormPage reportAClaimFormPage,
            IFileReader fileReader)
            : base(scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _loginPage = loginPage;
            _commonXpath = commonXpath;
            _reportAClaimStartPage = reportAClaimStartPage;
            _reportAClaimFormPage = reportAClaimFormPage;
            _fileReader = fileReader;
        }

        #region Xpath
        public string SearchPolicy_Inp => "//input[@id='search_term']";
        public string Search_Radio => "//input[@id='search' and @type='radio']";
        public string Claim_Radio => "//input[@id='claim' and @type='radio']";
        public string Quote_Radio => "//input[@id='quote' and @type='radio']";
        public string Continue_Btn => "//input[contains(@value,'Continue')]";
        public string PolicyClick_Text => "//td[contains(text(),'{0}')]";
        #endregion

        /// <summary>
        /// Uses test data from QuickSearchPage/QuickSearchPage.json and acts accordingly.
        /// </summary>
        public async Task QuickSearchMethodAsync(string profileKey)
        {
            var filePath = "QuickSearchPage\\QuickSearchPage.json";
            var policyNumber = _fileReader.GetOptionalValue(filePath, $"{profileKey}.PolicyNumberSearch");
            var searchType = _fileReader.GetOptionalValue(filePath, $"{profileKey}.SearchClaimQuote_Radio"); // Should be "Quote", "Claim", or "Policy"

            await InputField.SetTextAreaInputFieldAsync(SearchPolicy_Inp, policyNumber, true, 1);

            if (searchType == "Quote")
            {
                await RadioButton.SelectRadioButtonAsync(Quote_Radio, "Quote", true, 1);
            }
            else if (searchType == "Claim")
            {
                await RadioButton.SelectRadioButtonAsync(Claim_Radio, "Claim", true, 1);
            }
            else
            {
                await RadioButton.SelectRadioButtonAsync(Search_Radio, "Default", true, 1);
            }

            await Button.ClickButtonAsync(Continue_Btn, ActionType.Click, true, 1);
            var policyClick = string.Format(PolicyClick_Text, policyNumber);
            await Button.ClickButtonAsync(policyClick, ActionType.Click, true, 1);
        }

        /// <summary>
        /// Run a quick search but with directly supplied strings, NOT with JSON.
        /// </summary>
        public async Task QuickSearchMethodWithStringAsync(string radio, string input)
        {
            await InputField.SetTextAreaInputFieldAsync(SearchPolicy_Inp, input, true, 1);

            if (radio == "Quote")
            {
                await RadioButton.SelectRadioButtonAsync(Quote_Radio, "Quote", true, 1);
            }
            else if (radio == "Claim")
            {
                await RadioButton.SelectRadioButtonAsync(Claim_Radio, "Claim", true, 1);
            }
            else
            {
                await RadioButton.SelectRadioButtonAsync(Search_Radio, "Default", true, 1);
            }

            await Button.ClickButtonAsync(Continue_Btn, ActionType.Click, true, 1);

            // Format and clean the policy click text
            var policyClick = string.Format(PolicyClick_Text, input)
                                 .Replace("\u200C", ""); // Remove ZWNJ
            if (await Button.VerifyButtonExistAsync(policyClick, true, 1))
            {
                await Button.ClickButtonAsync(policyClick, ActionType.Click, true, 1);
            }
            else
            {
                Console.WriteLine($"PolicyClick button not found for input: {input}");
            }
        

            //var policyClick = string.Format(PolicyClick_Text, input);
            //await Button.ClickButtonAsync(policyClick, ActionType.Click, true, 1);
        }
    }
}
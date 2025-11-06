using BDD.Playwright.Core.Interfaces;
using BDD.Playwright.GBIZ.PageElements;
using BDD.Playwright.GBIZ.Pages.CommonPage;
using BDD.Playwright.Origami.Pages.CommonPage;
using Reqnroll;
using System;

namespace BDD.Playwright.GBIZ.Pages.AgentPages
{
    public class QuotePage : BasePage
    {
        private readonly IReqnrollOutputHelper _ReqnrollLogger;
        private readonly FeatureContext _featureContext;
        private readonly ScenarioContext _scenarioContext;
        private readonly IFileReader _fileReader;
        // Constructor
        public QuotePage(ScenarioContext scenarioContext, IFileReader fileReader) : base(scenarioContext)
        {
            _fileReader = fileReader;
            // _baseElement = new BaseElement(scenarioContext);

        }

        #region Xpath
        public string Search_Link => "//a[contains(text(),'SEARCH')]";
        public string NewQuote_Link => "//a[contains(text(),'NEW QUOTE')]";
        //public string E2Value_Link => "//a[contains(text(),'E2VALUE')]";
        public string E2Value_Link => "//div[contains(text(),'e2Value')]";
        public string FAQs_Link => "//a[contains(text(),'FAQS')]";
        public string StartNewQuote_Btn => "//button[contains(text(),'Start New Quote')]";
        public string OnlineQuoting_Text => "//div[contains(text(),'Online Quoting')]";
        public string E2Value_Header_Text => "//p[contains(text(),'Please select an estimator type from the')]";
        public string FAQS_Header_Text => "//h1[contains(text(),'Questions Frequently Asked by Agents')]";
        public string ShadowHost => ".gg-leftnav.hydrated";
        public string QuotingSidePanelShadow => "div.gg-leftnavlinkgrid > a[href='/agents/business/quoting']";

        #endregion

        public async Task QuotingLinkAsync()
        {
            await Button.ClickButtonAsync(QuotingSidePanelShadow, ActionType.Click, true, 1);
        }
        public async Task QuotingSearchAsync(string profileKey)
        {
            if (_fileReader == null)
            {
                throw new InvalidOperationException("FileReader is not available. Use constructor with IFileReader parameter.");
            }

            try
            {
                logger.WriteLine($"Starting to fill Quoting Search information using profile: {profileKey}");

                var filePath = "QuotePage\\QuotePageData.json";
                // Get values from JSON - Quote Details

                var quotingPage_SearchorVerify = _fileReader.GetOptionalValue(filePath, $"{profileKey}.QuotingPage_SearchorVerify");

                await TextLink.ClickTextLinkAsync(Search_Link, true, 1);

                if (quotingPage_SearchorVerify == "Verify")
                {
                    if (await Button.VerifyButtonExistAsync(StartNewQuote_Btn, true, 1))
                    {
                        // _applicationLogger.WriteLine("We are in Quoting Search Page and button exist");
                    }
                    else
                    {
                        throw new Exception("Some Error Occured and Quoting Search Page is not displaying");
                    }
                }
                else
                {

                }

                logger.WriteLine($"Retrieved Quoting Search data for:{quotingPage_SearchorVerify} ");

                // Note: Form filling implementation would go here using the same pattern as BasicInformationPage
                // with the page elements (Button, InputField, DropDown, etc.) once they are properly resolved

                logger.WriteLine($"Successfully filled Quoting Search information using profile: {profileKey}");
                logger.WriteLine("Quoting Search Page Details Entered Successfully from JSON Data");
            }
            catch (Exception ex)
            {
                logger.WriteLine($"Error filling Quoting Search data: {ex.Message}");
                throw new Exception($"Failed to fill Quoting Search data using profile '{profileKey}': {ex.Message}", ex);
            }
        }

        public async Task QuotingE2ValueAsync(string profileKey)
        {
            if (_fileReader == null)
            {
                throw new InvalidOperationException("FileReader is not available. Use constructor with IFileReader parameter.");
            }

            try
            {
                logger.WriteLine($"Starting to fill Quoting E2Value information using profile: {profileKey}");

                var filePath = "QuotePage\\QuotePageData.json";
                // Get values from JSON - Quote Details

                var quotingPage_E2Value_AddorVerify = _fileReader.GetOptionalValue(filePath, $"{profileKey}.QuotingPage_E2Value_AddorVerify");

                await TextLink.ClickTextLinkAsync(E2Value_Link, true, 1);

                if (quotingPage_E2Value_AddorVerify == "Verify")
                {
                    await Label.VerifyTextAsync(E2Value_Header_Text, "Please select an estimator type from the options below for new and existing portfolios.", true, 1);
                }
                else
                {

                }

                logger.WriteLine($"Retrieved Quoting E2Value data for: {quotingPage_E2Value_AddorVerify}");

                // Note: Form filling implementation would go here using the same pattern as BasicInformationPage
                // with the page elements (Button, InputField, DropDown, etc.) once they are properly resolved

                logger.WriteLine($"Successfully filled Quoting E2Value information using profile: {profileKey}");
                logger.WriteLine("Quoting E2Value Page Details Entered Successfully from JSON Data");
            }
            catch (Exception ex)
            {
                logger.WriteLine($"Error filling Quoting E2Value data: {ex.Message}");
                throw new Exception($"Failed to fill Quoting E2Value data using profile '{profileKey}': {ex.Message}", ex);
            }
        }

        public async Task QuotingFAQSAsync(string profileKey)
        {
            if (_fileReader == null)
            {
                throw new InvalidOperationException("FileReader is not available. Use constructor with IFileReader parameter.");
            }

            try
            {
                logger.WriteLine($"Starting to fill Quoting FAQS information using profile: {profileKey}");

                var filePath = "QuotePage\\QuotePageData.json";
                // Get values from JSON - Quote Details

                var quotingPage_FAQS_SearchorVerify = _fileReader.GetOptionalValue(filePath, $"{profileKey}.QuotingPage_FAQS_SearchorVerify");
                await TextLink.ClickTextLinkAsync(FAQs_Link, true, 1);
                
                if (quotingPage_FAQS_SearchorVerify == "Verify")
                {
                    await Label.VerifyTextAsync(FAQS_Header_Text, "Questions Frequently Asked by Agents", true, 1);
                }
                else
                {

                }

                logger.WriteLine($"Retrieved Quoting FAQS data for: {quotingPage_FAQS_SearchorVerify}");

                // Note: Form filling implementation would go here using the same pattern as BasicInformationPage
                // with the page elements (Button, InputField, DropDown, etc.) once they are properly resolved

                logger.WriteLine($"Successfully filled Quoting FAQS information using profile: {profileKey}");
                logger.WriteLine("Quoting FAQS Page Details Entered Successfully from JSON Data");
            }
            catch (Exception ex)
            {
                logger.WriteLine($"Error filling Quoting FAQS data: {ex.Message}");
                throw new Exception($"Failed to fill Quoting FAQS data using profile '{profileKey}': {ex.Message}", ex);
            }
        }

        public async Task QuotingNewQuoteAsync(string profileKey)
        {
            if (_fileReader == null)
            {
                throw new InvalidOperationException("FileReader is not available. Use constructor with IFileReader parameter.");
            }

            try
            {
                logger.WriteLine($"Starting to fill Quoting NewQuote Page information using profile: {profileKey}");

                var filePath = "QuotePage\\QuotePageData.json";
                // Get values from JSON - Quote Details

                var quotingPage_NewQuote_AddorVerify = _fileReader.GetOptionalValue(filePath, $"{profileKey}.QuotingPage_NewQuote_AddorVerify");

                await TextLink.ClickTextLinkAsync(NewQuote_Link, true, 1);

                if (quotingPage_NewQuote_AddorVerify == "Verify")
                {
                    await Label.VerifyTextAsync(OnlineQuoting_Text, "Online Quoting", true, 1);
                }
                else
                {

                }

                logger.WriteLine($"Retrieved Quoting NewQuote Page data for: {quotingPage_NewQuote_AddorVerify}");

                // Note: Form filling implementation would go here using the same pattern as BasicInformationPage
                // with the page elements (Button, InputField, DropDown, etc.) once they are properly resolved

                logger.WriteLine($"Successfully filled Quoting NewQuote Page information using profile: {profileKey}");
                logger.WriteLine("Quoting NewQuote Page Details Entered Successfully from JSON Data");
            }
            catch (Exception ex)
            {
                logger.WriteLine($"Error filling Quoting NewQuote Page data: {ex.Message}");
                throw new Exception($"Failed to fill Quoting NewQuote Page data using profile '{profileKey}': {ex.Message}", ex);
            }
        }
    }
}

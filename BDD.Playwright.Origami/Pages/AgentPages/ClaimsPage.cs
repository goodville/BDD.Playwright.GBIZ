using BDD.Playwright.Core.Interfaces;
using BDD.Playwright.Core.Loggers;
using BDD.Playwright.GBIZ.PageElements;
using BDD.Playwright.GBIZ.Pages.CommonPage;
using BDD.Playwright.GBIZ.Pages.GlobalPages;
using BDD.Playwright.GBIZ.Pages.XpathProperties;
using Microsoft.Playwright;
using Reqnroll;
using System;
using System.Threading.Tasks;

namespace BDD.Playwright.GBIZ.Pages.PublicPages
{
    public class ClaimsPage : BasePage
    {
        private readonly ScenarioContext _scenarioContext;
        public FeatureContext _featureContext;
        public CommonXpath _commonXpath;
        public LoginPage _loginPage;
        public ReportAClaimStartPage _reportAClaimStartPage;
        public ReportAClaimFormPage _reportAClaimFormPage;
        private readonly IFileReader _fileReader;

        public ClaimsPage(
            ScenarioContext scenarioContext,
            LoginPage loginPage,
            CommonXpath commonXpath,
            ReportAClaimStartPage reportAClaimStartPage,
            ReportAClaimFormPage reportAClaimFormPage,
            IFileReader fileReader
        ) : base(scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _loginPage = loginPage;
            _commonXpath = commonXpath;
            _reportAClaimStartPage = reportAClaimStartPage;
            _reportAClaimFormPage = reportAClaimFormPage;
            _fileReader = fileReader;
            // Optionally: await _commonFunctions.ReadTestDataForClaimPageAsync();
        }

        #region Xpath
        public string ReportLoss_Link => "//a[contains(text(),'REPORT LOSS')]";
        public string Service_Link => "//a[contains(text(),'SERVICE')]";
        public string DirectPay_Link => "//a[contains(text(),'DIRECT PAY')]";
        public string YTDLoss_Link => "//a[contains(text(),'YTD LOSS')]";
        public string Payments_Link => "//a[contains(text(),'PAYMENTS')]";
        public string Search_Link => "//a[contains(text(),'SEARCH')]";
        public string ReportLoss_Header_Text => "//h4[contains(text(),'Policy Look Up')]";
        public string Service_Header_Text => "//gg-panel-title[contains(text(),'Loss Prevention')]";
        public string Service_LossPrevention_Text => "//gg-expansion-panel-header[./span[./gg-panel-title[contains(text(),'Loss Prevention')]]]/span[2]";
        public string DirectPay_Header_Text => "//p[contains(text(),'Direct-Pay Repair Shops listed')]";
        public string YTDLoss_Header_Text => "//p[contains(text(),'Change in loss incurred is calculated from previous month')]";
        public string Payments_Header_Text => "//p[contains(text(),'Claim payments by book')]";
        public string Payments_AgentBook_Inp => "//input[contains(@formcontrolname,'book')]";
        public string Payments_StartDate_Inp => "//input[contains(@formcontrolname,'fromDate')]";
        public string Payments_EndDate_Inp => "//input[contains(@formcontrolname,'toDate')]";
        public string Payments_NoofPayments => "//div[contains(@class,'totalNumber')]";
        public string Payments_TotalAmountClaimed => "//div[contains(@class,'totalAmount')]";
        public string Search_ClaimNumber_Inp => "//input[@formcontrolname='claimNumber']";
        public string Search_PolicyNumber_Inp => "//input[@formcontrolname='policyNumber']";
        public string Search_FirstName_Inp => "//input[@formcontrolname='firstName']";
        public string Search_LastName_Inp => "//input[@formcontrolname='lastName']";
        public string Search_StartDate_Inp => "//input[@formcontrolname='lossDateRangeStart']";
        public string Search_EndDate_Inp => "//input[@formcontrolname='lossDateRangeEnd']";
        public string Search_ClaimStatus_Btn => "//div[./span/label[contains(text(),'Claim Status')]]/div/a[contains(text(),'{0}')]";
        public string Search_PolicyStatus_Btn => "//div[./span/label[contains(text(),'Policy Status')]]/div/a[contains(text(),'{0}')]";
        public string Serach_NoData_Text => "//td[contains(text(),'No data was returned with your query.')]";
        #endregion

        public async Task ClaimButtonAsync()
        {
            await Button.ClickButtonCssAsync(_commonXpath.ShadowHost, _commonXpath.ClaimsSidePanelShadow);
            await Task.Delay(5000);
            await Button.ClickButtonCssAsync(_commonXpath.ShadowHost, _commonXpath.ClaimsSidePanelShadow);
            await Task.Delay(5000);
            await page.WaitForLoadStateAsync(LoadState.NetworkIdle);
            var actualTitle = await page.TitleAsync();
            if (actualTitle != "Goodville Mutual Casualty Company - Claims")
            {
                throw new Exception($"Title does not match! Expected: 'Goodville Mutual Casualty Company - Claims', Actual: '{actualTitle}'");
            }
        }

        public async Task ReportLossAsync(string profileKey)
        {
            // Load which action from JSON for this profile
            var filePath = "ClaimPage\\ClaimPage.json";
            var reportAClaimFilePath = "ReportAClaimFormPage\\ReportAClaimFormPage.json";
            var reportLossAction = _fileReader.GetOptionalValue(filePath, $"{profileKey}.ReportLossAddorVerify");
            var policyInfoSection = _fileReader.GetOptionalValue(reportAClaimFilePath, $"{profileKey}.PolicyInformationSection");

            await TextLink.ClickTextLinkAsync(ReportLoss_Link, true, 1);

            if (reportLossAction == "Verify")
            {
                await Label.VerifyTextAsync(ReportLoss_Header_Text, "POLICY LOOK UP", true, 1);
            }
            else
            {
                await _reportAClaimStartPage.EnterPolicyDetailsInReportAClaimStartPageAsync(profileKey);
                await Button.ClickButtonAsync(_commonXpath.Submit_Btn, ActionType.Click, true, 1);
                await _reportAClaimFormPage.ReportAClaimAsync(profileKey);

                if (!string.IsNullOrEmpty(policyInfoSection) && policyInfoSection.Contains("Home"))
                {
                    await _reportAClaimFormPage.HomeClaimInformationAsync(profileKey);
                }

                if (!string.IsNullOrEmpty(policyInfoSection) && policyInfoSection.Contains("Personal"))
                {
                    await _reportAClaimFormPage.AutoClaimInformationAsync(profileKey);
                }

                await _reportAClaimFormPage.ClaimSubmitAsync();
            }
        }

        public async Task ServiceAsync(string profileKey)
        {
            var filePath = "ClaimPage\\ClaimPage.json";
            var serviceAction = _fileReader.GetOptionalValue(filePath, $"{profileKey}.ServiceAddorVerify");

            await TextLink.ClickTextLinkAsync(Service_Link, true, 1);
            if (serviceAction == "Verify")
            {
                await Label.VerifyTextAsync(Service_Header_Text, "Loss Prevention & Vehicle Values Links", true, 1);
            }
            else
            {
                // Additional actions for Add if needed
            }
        }

        public async Task DirectPayShopAsync(string profileKey)
        {
            var filePath = "ClaimPage\\ClaimPage.json";
            var directPayAction = _fileReader.GetOptionalValue(filePath, $"{profileKey}.DirectPayAddorVerify");

            await TextLink.ClickTextLinkAsync(DirectPay_Link, true, 1);
            if (directPayAction == "Verify")
            {
                await Label.VerifyTextAsync(DirectPay_Header_Text, "Direct-Pay Repair Shops listed here are under", true, 1);
            }
            else
            {
                // Additional actions for Add if needed
            }
        }

        public async Task YTDLossAsync(string profileKey)
        {
            var filePath = "ClaimPage\\ClaimPage.json";
            var ytdLossAction = _fileReader.GetOptionalValue(filePath, $"{profileKey}.YTDLossAddorVerify");

            await TextLink.ClickTextLinkAsync(YTDLoss_Link, true, 1);
            if (ytdLossAction == "Verify")
            {
                await Label.VerifyTextAsync(YTDLoss_Header_Text, "Change in loss incurred", true, 1);
            }
            else
            {
                // Additional actions for Add if needed
            }
        }

        public async Task PaymentsAsync(string profileKey)
        {
            var filePath = "ClaimPage\\ClaimPage.json";
            var paymentAction = _fileReader.GetOptionalValue(filePath, $"{profileKey}.PaymentSearchorVerify");
            var agentBook = _fileReader.GetOptionalValue(filePath, $"{profileKey}.AgentBook");
            var startDateOffset = _fileReader.GetOptionalValue(filePath, $"{profileKey}.StartDate");
            var endDateOffset = _fileReader.GetOptionalValue(filePath, $"{profileKey}.EndDate");

            await TextLink.ClickTextLinkAsync(Payments_Link, true, 1);

            if (paymentAction == "Verify")
            {
                await Label.VerifyTextAsync(Payments_Header_Text, "Claim payments by book of business and by date range. Payments older than 2 years old are only for active policies.", true, 1);
            }
            else
            {
                await page.EvaluateAsync("() => window.scrollTo(0,0)");
                await Label.VerifyTextAsync(Payments_Header_Text, "Claim payments by book of business and by date range. Payments older than 2 years old are only for active policies.", true, 1);
                await InputField.SetTextAreaInputFieldAsync(Payments_AgentBook_Inp, agentBook, true, 1);
                //var startDate = (int.Parse(startDateOffset)).ToString("MM/dd/yyyy");
                //var endDate = (int.Parse(endDateOffset)).ToString("MM/dd/yyyy");
                await InputField.SetTextAreaInputFieldAsync(Payments_StartDate_Inp, startDateOffset, true, 1);
                await InputField.SetTextAreaInputFieldAsync(Payments_EndDate_Inp, endDateOffset, true, 1);
                await Task.Delay(2000);
                var noOfPayments = await Label.GetTextAsync(Payments_NoofPayments, true, 1);
                if (noOfPayments.Contains("0"))
                {
                    logger.WriteLine("Total Number of Payments for this Book Code is 0");
                }
                else
                {
                    logger.WriteLine(noOfPayments);
                }

                var totalAmountClaimed = await Label.GetTextAsync(Payments_TotalAmountClaimed, true, 1);
                if (totalAmountClaimed.Contains("0"))
                {
                    logger.WriteLine("Total Amount Claimed for this Book Code is 0");
                }
                else
                {
                    logger.WriteLine(totalAmountClaimed);
                }
            }
        }

        public async Task SearchAsync(string profileKey)
        {
            var filePath = "ClaimPage\\ClaimPage.json";
            var searchAction = _fileReader.GetOptionalValue(filePath, $"{profileKey}.Claim_SearchAddorVerify");

            await TextLink.ClickTextLinkAsync(Search_Link, true, 1);
            if (searchAction == "Verify")
            {
                // Only navigation, no further action for verification
            }
            else
            {
                // Additional actions for Add if needed
            }
        }
    }
}
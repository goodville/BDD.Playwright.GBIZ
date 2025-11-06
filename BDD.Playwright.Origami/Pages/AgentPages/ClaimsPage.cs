using System;
using System.Threading.Tasks;
using BDD.Playwright.Core.Enums;
using BDD.Playwright.Core.Loggers;
using BDD.Playwright.Origami.Pages.CommonPage;
using Microsoft.Playwright;
using Reqnroll;
using OrigamiButton = BDD.Playwright.Origami.PageElements.Button;
using GBIZTextLink = BDD.Playwright.GBIZ.PageElements.TextLink;
using GBIZInputField = BDD.Playwright.GBIZ.PageElements.InputField;
using GBIZLabel = BDD.Playwright.GBIZ.PageElements.Label;

namespace BDD.Playwright.GBIZ.Pages.ClaimsPage
{
    public class ClaimsPage : BasePage
    {
        private readonly ApplicationLogger _applicationLogger;

        // Playwright Page Elements
        public OrigamiButton Button { get; private set; }
        public GBIZTextLink TextLink { get; private set; }
        public GBIZInputField InputFieldElement { get; private set; }
        public GBIZLabel LabelElement { get; private set; }

        // Constructor
        public ClaimsPage(ScenarioContext scenarioContext, ApplicationLogger applicationLogger) : base(scenarioContext)
        {
            _applicationLogger = applicationLogger;
            InitializePageElements();
        }

        private void InitializePageElements()
        {
            Button = new OrigamiButton(_scenarioContext);
            TextLink = new GBIZTextLink(_scenarioContext);
            InputFieldElement = new GBIZInputField(_scenarioContext);
            LabelElement = new GBIZLabel(_scenarioContext);
        }

        #region Locators
        public string ReportLoss_Link { get; set; } = "//a[contains(text(),'REPORT LOSS')]";
        public string Service_Link { get; set; } = "//a[contains(text(),'SERVICE')]";
        public string DirectPay_Link { get; set; } = "//a[contains(text(),'DIRECT PAY')]";
        public string YTDLoss_Link { get; set; } = "//a[contains(text(),'YTD LOSS')]";
        public string Payments_Link { get; set; } = "//a[contains(text(),'PAYMENTS')]";
        public string Search_Link { get; set; } = "//a[contains(text(),'SEARCH')]";
        public string ReportLoss_Header_Text { get; set; } = "//h4[contains(text(),'Policy Look Up')]";
        public string Service_Header_Text { get; set; } = "//gg-panel-title[contains(text(),'Loss Prevention')]";
        public string Service_LossPrevention_Text { get; set; } = "//gg-expansion-panel-header[./span[./gg-panel-title[contains(text(),'Loss Prevention')]]]/span[2]";
        public string DirectPay_Header_Text { get; set; } = "//p[contains(text(),'Direct-Pay Repair Shops listed')]";
        public string YTDLoss_Header_Text { get; set; } = "//p[contains(text(),'Change in loss incurred is calculated from previous month')]";
        public string Payments_Header_Text { get; set; } = "//p[contains(text(),'Claim payments by book')]";
        public string Payments_AgentBook_Inp { get; set; } = "//input[contains(@formcontrolname,'book')]";
        public string Payments_StartDate_Inp { get; set; } = "//input[contains(@formcontrolname,'fromDate')]";
        public string Payments_EndDate_Inp { get; set; } = "//input[contains(@formcontrolname,'toDate')]";
        public string Payments_NoofPayments { get; set; } = "//div[contains(@class,'totalNumber')]";
        public string Payments_TotalAmountClaimed { get; set; } = "//div[contains(@class,'totalAmount')]";
        public string Search_ClaimNumber_Inp { get; set; } = "//input[@formcontrolname='claimNumber']";
        public string Search_PolicyNumber_Inp { get; set; } = "//input[@formcontrolname='policyNumber']";
        public string Search_FirstName_Inp { get; set; } = "//input[@formcontrolname='firstName']";
        public string Search_LastName_Inp { get; set; } = "//input[@formcontrolname='lastName']";
        public string Search_StartDate_Inp { get; set; } = "//input[@formcontrolname='lossDateRangeStart']";
        public string Search_EndDate_Inp { get; set; } = "//input[@formcontrolname='lossDateRangeEnd']";
        public string Search_ClaimStatus_Btn { get; set; } = "//div[./span/label[contains(text(),'Claim Status')]]/div/a[contains(text(),'{0}')]";
        public string Search_PolicyStatus_Btn { get; set; } = "//div[./span/label[contains(text(),'Policy Status')]]/div/a[contains(text(),'{0}')]";
        public string Serach_NoData_Text { get; set; } = "//td[contains(text(),'No data was returned with your query.')]";

        // Common elements (to be replaced with actual xpath values from CommonXpath)
        public string ShadowHost { get; set; } = "//shadow-root-host";
        public string ClaimsSidePanelShadow { get; set; } = "//claims-side-panel";
        public string Submit_Btn { get; set; } = "//button[contains(@class,'submit')]";
        #endregion

        public async Task ClaimButtonAsync()
        {
            await Button.ClickButtonAsync(ShadowHost, ActionType.Click, true);
            await Button.ClickButtonAsync(ClaimsSidePanelShadow, ActionType.Click, true);
            await Task.Delay(3000); // Wait for page to load
        }

        public async Task ReportLossAsync()
        {
            await TextLink.ClickTextLinkAsync(ReportLoss_Link, true, 1);
            await Task.Delay(3000); // Wait for page to load
            
            // Example verification - replace with actual logic from CommonFunctions
            await LabelElement.VerifyTextAsync(ReportLoss_Header_Text, "POLICY LOOK UP", true, 1);
            
            // Additional form interactions would go here
            // For example:
            // await _reportAClaimStartPage.EnterPolicyDetailsInReportAClaimStartPageAsync();
            // await Button.ClickButtonAsync(Submit_Btn, ActionType.Click, true, 1);
            
            logger.WriteLine("Report Loss functionality executed successfully");
        }

        public async Task ServiceAsync()
        {
            await TextLink.ClickTextLinkAsync(Service_Link, true, 1);
            await LabelElement.VerifyTextAsync(Service_Header_Text, "Loss Prevention & Vehicle Values Links", true, 1);
            logger.WriteLine("Service functionality executed successfully");
        }

        public async Task DirectPayShopAsync()
        {
            await TextLink.ClickTextLinkAsync(DirectPay_Link, true, 1);
            await LabelElement.VerifyTextAsync(DirectPay_Header_Text, "Direct-Pay Repair Shops listed here are under", true, 1);
            logger.WriteLine("Direct Pay Shop functionality executed successfully");
        }

        public async Task YTDLossAsync()
        {
            await TextLink.ClickTextLinkAsync(YTDLoss_Link, true, 1);
            await LabelElement.VerifyTextAsync(YTDLoss_Header_Text, "Change in loss incurred", true, 1);
            logger.WriteLine("YTD Loss functionality executed successfully");
        }
        public async Task PaymentsAsync()
        {
            await TextLink.ClickTextLinkAsync(Payments_Link, true, 1);
            await LabelElement.VerifyTextAsync(Payments_Header_Text, "Claim payments by book of business and by date range. Payments older than 2 years old are only for active policies.", true, 1);
            
            // Maximize window equivalent
            await page.SetViewportSizeAsync(1920, 1080);
            
            // Example form filling - replace with actual data values
            await InputFieldElement.SetTextAreaInputFieldAsync(Payments_AgentBook_Inp, "12345", true, 1);
            await InputFieldElement.SetTextAreaInputFieldAsync(Payments_StartDate_Inp, DateTime.Now.AddDays(-30).ToString("MM/dd/yyyy"), true, 1);
            await InputFieldElement.SetTextAreaInputFieldAsync(Payments_EndDate_Inp, DateTime.Now.ToString("MM/dd/yyyy"), true, 1);
            
            await Task.Delay(2000);
            
            var noOfPayments = await LabelElement.GetTextAsync(Payments_NoofPayments, true, 1);
            if (noOfPayments.Contains("0"))
            {
                _applicationLogger.WriteLine("Total Number of Payments for this Book Code is 0");
            }
            else
            {
                _applicationLogger.WriteLine(noOfPayments);
            }

            var totalAmountClaimed = await LabelElement.GetTextAsync(Payments_TotalAmountClaimed, true, 1);
            if (totalAmountClaimed.Contains("0"))
            {
                _applicationLogger.WriteLine("Total Amount Claimed for this Book Code is 0");
            }
            else
            {
                _applicationLogger.WriteLine(totalAmountClaimed);
            }
            
            logger.WriteLine("Payments functionality executed successfully");
        }

        public async Task SearchAsync()
        {
            await TextLink.ClickTextLinkAsync(Search_Link, true, 1);
            logger.WriteLine("Search functionality executed successfully");
        }
    }
}

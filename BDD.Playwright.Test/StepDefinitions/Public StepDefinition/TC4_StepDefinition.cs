using BDD.Playwright.GBIZ.PageElements;
using BDD.Playwright.GBIZ.Pages.CommonPage;
using BDD.Playwright.GBIZ.Pages.XpathProperties;
using Microsoft.Playwright;
using OpenQA.Selenium.DevTools.V139.Page;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDD.Playwright.Test.StepDefinitions.Public_StepDefinition
{
    [Binding]
    public class TC4_StepDefinition : BasePage
    {
        private readonly ScenarioContext _scenarioContext;
        public CommonXpath _commonXpath;
        public TC4_StepDefinition(ScenarioContext scenarioContext, CommonXpath commonXpath) : base(scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _commonXpath = commonXpath;
        }

        [When(@"User Click on the About Us and Verify the Ward 50 Link")]
        public async Task WHenUserClickontheAboutUsandVerifytheWard50LinkAsync()
        {
            await TextLink.ClickTextLinkAsync(_commonXpath.AboutUS_Link, true, 1);
            var AboutUSPageTitle = await page.TitleAsync();

            if (AboutUSPageTitle == "Goodville Mutual Casualty Company - About Us")
            {
                logger.WriteLine("About us Page Title is Goodville Mutual Casualty Company - About Us");
            }
            else
            {
                throw new Exception("About Us page Title is not Matching it is displaying " + AboutUSPageTitle);
            }

            await TextLink.ClickTextLinkAsync(_commonXpath.Ward50_Link, true, 1);
            var popup = await page.RunAndWaitForPopupAsync(async () =>
            {
                await TextLink.ClickTextLinkAsync(_commonXpath.WardGroup_Link, true, 1);
            });
            await page.WaitForLoadStateAsync(LoadState.DOMContentLoaded);
            await page.WaitForLoadStateAsync(LoadState.NetworkIdle);
            var WardGroupPageTitle = await popup.TitleAsync();
            if (WardGroupPageTitle == "Benchmarking Solutions for Insurers | Aon")
            {
                logger.WriteLine("Ward Group Page Title is Benchmarking Solutions for Insurers | Aon");
            }
            else
            {
                throw new Exception("Ward Group page Title is not Matching it is displaying " + AboutUSPageTitle);
            }

            await popup.CloseAsync();

            // IFrame.CurrentWindowClose(
            // );
        }

        [When(@"User Click on the Company History and Verify the AM Best Link")]
        public async Task WhenUserClickontheCompanyHistoryandVerifytheAMBestLinkAsync()
        {
            await TextLink.ClickTextLinkAsync(_commonXpath.CompanyHistory_Link, true, 1);
            await TextLink.ClickTextLinkAsync(_commonXpath.CompanyHistory_AMBest_Link, true, 1);
           // IFrame.switchToWindow();
            var AMBestPageTitle = await page.TitleAsync();
            if (AMBestPageTitle == "Goodville Mutual Casualty Company - Company Profile - Best's Credit Rating Center")
            {
                logger.WriteLine("AM Best Page Title is Goodville Mutual Casualty Company - Company Profile - Best's Credit Rating Center");
            }
            else
            {
                throw new Exception("AM Best page Title is not Matching it is displaying " + AMBestPageTitle);
            }

           // IFrame.CurrentWindowClose();
        }

        [When(@"User Click on Insurance Fraud Link and Verify the Title")]
        public async Task WhenUserClickonInsuranceFraudLinkandVerifytheTitleAsync()
        {
            await TextLink.ClickTextLinkAsync(_commonXpath.InsuranceFraud_Link, true, 1);
            var InsuranceFraudPageTitle = await page.TitleAsync();
            if (InsuranceFraudPageTitle == "Goodville Mutual Casualty Company - Fraud")
            {
                logger.WriteLine("Insurance Fraud Page Title is Goodville Mutual Casualty Company - Fraud");
            }
            else
            {
                throw new Exception("Insurance Fraud page Title is not Matching it is displaying " + InsuranceFraudPageTitle);
            }
        }

        [When(@"User Click on President Message Link and Verify the Title")]
        public async Task WhenUserClickonPresidentMessageLinkandVerifytheTitleAsync()
        {
            await TextLink.ClickTextLinkAsync(_commonXpath.PresidentMessage_Link, true, 1);
            var PresidentMessagePageTitle = await page.TitleAsync();
            if (PresidentMessagePageTitle == "Goodville Mutual Casualty Company - President's Message")
            {
                logger.WriteLine("President Message Page Title is Goodville Mutual Casualty Company - President's Message");
            }
            else
            {
                throw new Exception("President Message page Title is not Matching it is displaying " + PresidentMessagePageTitle);
            }
        }

        [When(@"User Click on Become an Goodville Agent and Verify the Title")]
        public async Task WhenUserClickonBecomeanGoodvilleAgentandVerifytheTitleAsync()
        {
            await TextLink.ClickTextLinkAsync(_commonXpath.BecomeaGoodvilleAgent_Link, true, 1);
            var BecomeGoodvilleAgentPageTitle = await page.TitleAsync();
            if (BecomeGoodvilleAgentPageTitle == "ProspectiveAgentsApp")
            {
                logger.WriteLine("Become an GoodVille Agent Page Title is ProspectiveAgentsApp");
            }
            else
            {
                throw new Exception("Become an GoodVille Agent page Title is not Matching it is displaying " + BecomeGoodvilleAgentPageTitle);
            }
        }

        [When(@"User Click On Annual Report and in that 2024 Annual Report and Verify the Title")]
        public async Task WhenUserClickonAnnualReportandinthat2024AnnualReportandVerifytheTitleAsync()
        {
            await TextLink.ClickTextLinkAsync(_commonXpath.AnnualReport_Link, true, 1);
           // IFrame.switchToWindow();
            var AnnualReportPageTitle = await page.TitleAsync();
            if (AnnualReportPageTitle == "2024_Annual_Report_FINAL_Flip_Version_(2)")
            {
                logger.WriteLine("Annual Report Page Title is 2024_Annual_Report_FINAL_Flip_Version_(2)");
            }
            else
            {
                throw new Exception("Annual Report page Title is not Matching it is displaying " + AnnualReportPageTitle);
            }

            await TextLink.ClickTextLinkAsync(_commonXpath.AnnualReportDownloadPDF_Icon, true, 1);
            await Task.Delay(5000);
            //IFrame.CurrentWindowClose();
        }

        [When(@"User Click on Credit History and Verify the Text")]
        public async Task WhenUserClickonCreditHistoryandVerifytheTextAsync()
        {
            await TextLink.ClickTextLinkAsync(_commonXpath.CreditHistory_Link, true, 1);
            await Label.VerifyTextAsync(_commonXpath.CreditHistoryValidationMessage, "YOUR CREDIT HISTORY AND HOW IT AFFECTS YOUR PREMIUM", true, 1);
        }

        [When(@"User Click on Careers and Verify the Title")]
        public async Task WhenUserClickonCareersandVerifytheTitleAsync()
        {
            await TextLink.ClickTextLinkAsync(_commonXpath.Careers_Link, true, 1);
            var CareersPageTitle = await page.TitleAsync();
            if (CareersPageTitle == "Goodville Mutual Casualty Company - Careers")
            {
                logger.WriteLine("Careers page Title is Goodville Mutual Casualty Company - Careers");
            }
            else
            {
                throw new Exception("Careers page Title is not Matching it is displaying " + CareersPageTitle);
            }
        }
    }
}

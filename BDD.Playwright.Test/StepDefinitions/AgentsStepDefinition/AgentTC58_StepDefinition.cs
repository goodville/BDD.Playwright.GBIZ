using BDD.Playwright.GBIZ.PageElements;
using BDD.Playwright.GBIZ.Pages.AgentPages;
using BDD.Playwright.GBIZ.Pages.CommonPage;
using BDD.Playwright.GBIZ.Pages.GlobalPages;
using BDD.Playwright.GBIZ.Pages.PublicPages;
using BDD.Playwright.GBIZ.Pages.XpathProperties;
using Microsoft.Playwright;
using NUnit.Framework;
using Reqnroll;
using System;
using System.Threading.Tasks;

namespace BDD.Playwright.GBIZ.Steps.AgentsStepDefinition
{
    [Binding]
    public class AgentTC58_StepDefinition : BasePage
    {
        public CommonXpath _commonXpath;
        private readonly ScenarioContext _scenarioContext;

        public AgentTC58_StepDefinition(
            ScenarioContext scenarioContext,
            CommonXpath commonXpath) : base(scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _commonXpath = commonXpath;
        }

        public async Task NextPageTitleVerifyMethodAsync(string RequiredXpath, string ExpectedPageTitle)
        {
            await TextLink.ClickTextLinkAsync(RequiredXpath, true, 1);
            var ActualPageTitle = await page.TitleAsync();
            if (ActualPageTitle == ExpectedPageTitle)
            {
                logger.WriteLine(ExpectedPageTitle);
            }
            else
            {
                throw new Exception("About Us page Title is not Matching it is displaying " + ActualPageTitle);
            }
        }

        public async Task TitleVerifyMethodAsync(string ExpectedPageTitle)
        {
            var ActualPageTitle = await page.TitleAsync();
            Console.WriteLine("actual page title:" + ActualPageTitle);

            if (ActualPageTitle.Equals(ExpectedPageTitle))
            {
                logger.WriteLine(ExpectedPageTitle);
            }
            else
            {
                throw new Exception("Privacy policy page Title is not Matching it is displaying " + ActualPageTitle);
            }
        }

        [When(@"User Click on Reports and Verify Daily transactions page was displayed")]
        public async Task UserClickonReportsandVerifyDailytransactionspagewasdisplayedAsync()
        {
            await Button.ClickButtonCssAsync(_commonXpath.ShadowHostTopPanelShadow, _commonXpath.HomePage_Report_Link);
            await Label.VerifyTextAsync(_commonXpath.Report_DailyTransaction_Link, "Daily Transactions", true, 1);
        }

        [When(@"User Verify the Daily Transactions page elements")]
        public async Task UserVerifytheDailyTransactionspageelementsAsync()
        {
            await InputField.SetTextAreaInputFieldAsync(_commonXpath.Allbooks_input, "3700", true, 1);
            await Button.ClickButtonAsync(_commonXpath.Policytype_all, ActionType.Click, true, 1);
            await Button.ClickButtonAsync(_commonXpath.Date_today, ActionType.Click, true, 1);
            await Button.ClickButtonAsync(_commonXpath.TransactionType_all, ActionType.Click, true, 1);
            await Button.ClickButtonAsync(_commonXpath.Policynumbersearch, ActionType.Click, true, 1);
        }

        [When(@"User search the daily transactions documents within the last three months")]
        public async Task UsersearchthedailytransactionsdocumentswithinthelastthreemonthsAsync()
        {
            await InputField.SetTextAreaInputFieldAsync(_commonXpath.Allbooks_input, "3700", true, 1);
            await Button.ClickButtonAsync(_commonXpath.Policytype_all, ActionType.Click, true, 1);
            await Button.ClickButtonAsync(_commonXpath.Date_Last3months, ActionType.Click, true, 1);
            await Button.ClickButtonAsync(_commonXpath.TransactionType_policy, ActionType.Click, true, 1);
            await Button.ClickButtonAsync(_commonXpath.Policynumbersearch, ActionType.Click, true, 1);
        }

        [When(@"User search the daily transactions documents for the policy number")]
        public async Task UsersearchthedailytransactionsdocumentsforthepolicynumberAsync()
        {
            await InputField.SetTextAreaInputFieldAsync(_commonXpath.Allbooks_input, "0704", true, 1);
            await Task.Delay(2000);
            await Button.ClickButtonAsync(_commonXpath.Date_DateRange, ActionType.Click, true, 1);
            await InputField.SetTextAreaInputFieldAsync(_commonXpath.Claimstartdate, "1/1/2015", true, 1);
            await Task.Delay(2000);
            await InputField.SetTextAreaInputFieldAsync(_commonXpath.Policynumber, "906271", true, 1);
            await Task.Delay(2000);
            await Button.ClickButtonAsync(_commonXpath.Policynumbersearch, ActionType.Click, true, 1);
        }

        [When(@"User clicks on Privacy Policy link and verify page title")]
        public async Task WhenUserClicksOnPrivacyPolicyLinkAndverifyPageTitleAsync()
        {
            //await _commonFunctions.ScrollDownAsync();
            await Button.ClickButtonCssAsync(_commonXpath.ShadowHost_2, _commonXpath.FooterPrivacyPolicyDailytransactions_Link);
            await TitleVerifyMethodAsync("Goodville Mutual Casualty Company - Privacy Policy");
            await page.GoBackAsync();
        }

        [When(@"User clicks on Contact us link and verify page title")]
        public async Task WhenUserClicksOnContactuslinkandverifypagetitleAsync()
        {
            //await _commonFunctions.ScrollDownAsync();
            await Button.ClickButtonCssAsync(_commonXpath.ShadowHost_2, _commonXpath.FooterContactus_Link);
            await TitleVerifyMethodAsync("Goodville Mutual Casualty Company - Contact Us");
            await page.GoBackAsync();
        }

        [When(@"User clicks on Terms & Conditions link and verify page title")]
        public async Task UserclicksonTermsConditionslinkandverifypagetitleAsync()
        {
            //await _commonFunctions.ScrollDownAsync();
            await Button.ClickButtonCssAsync(_commonXpath.ShadowHost_2, _commonXpath.FooterTermscondition_Link);
            await TitleVerifyMethodAsync("Goodville Mutual Casualty Company - Terms & Conditions");
            await page.GoBackAsync();
        }

        [When(@"User verify Footer Copyright and Best logo is displayed")]
        public async Task UserverifyFooterCopyrightandBestlogoisdisplayedAsync()
        {
            //await _commonFunctions.ScrollDownAsync();

            var shadowHost = await page.QuerySelectorAsync("gg-footer");
            var copyrightScript = @"el => {
                const shadowRoot = el.shadowRoot;
                const el2 = shadowRoot.querySelector('div[part=""gg-footer-copyright""]');
                return el2 ? el2.textContent.trim() : null;
            }";
            var copyrightText = await page.EvaluateAsync<string>(copyrightScript, shadowHost);

            Console.WriteLine("> Copyright Text: " + copyrightText);

            //await _commonFunctions.FooterlogoverificationAsync();
        }

        [When("User logout from Agent Account")]
        public async Task UserlogoutfromAgentAccountAsync()
        {
            await Button.ClickButtonCssAsync("gg-navigation", "a[href*='logout']");
            await Task.Delay(2000);
        }
    }
}
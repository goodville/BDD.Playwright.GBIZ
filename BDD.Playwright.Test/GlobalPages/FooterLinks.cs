using BDD.Playwright.GBIZ.PageElements;
using BDD.Playwright.GBIZ.Pages.CommonPage;
using BDD.Playwright.GBIZ.Pages.XpathProperties;
using Microsoft.Playwright;
using Reqnroll;
using System.Threading.Tasks;

namespace BDD.Playwright.GBIZ.Pages.GlobalPages
{
    public class FooterLink : BasePage
    {
        public CommonXpath _commonXpath;

        public FooterLink(ScenarioContext scenarioContext, CommonXpath commonXpath) : base(scenarioContext)
        {
            _commonXpath = commonXpath;
        }

        #region Xpath
        public string ShadowHost_Text => ".gg-footer.hydrated";
        public string PrivacyPolicy_Link => "div.footernav> a[href='/help/privacypolicy/']";
        public string ContactUs_Link => "div.footernav> a[href='/contactus/']";
        public string TermsandConditions_Link => "div.footernav> a[href='/help/terms/']";
        public string RetrySign_Btn => "//a[contains(text(),'Retry Sign in')]";
        #endregion

        public async Task PrivacyMethodAsync()
        {
            await Button.ClickButtonCssAsync(ShadowHost_Text, PrivacyPolicy_Link);
            await page.GoBackAsync();
            await page.WaitForLoadStateAsync(LoadState.NetworkIdle);
            await RetrySigninAsync();
        }

        public async Task ContactUsMethodAsync()
        {
            await Button.ClickButtonCssAsync(ShadowHost_Text, ContactUs_Link);
            await page.GoBackAsync();
            await page.WaitForLoadStateAsync(LoadState.NetworkIdle);
            await RetrySigninAsync();
        }

        public async Task TermMethodAsync()
        {
            await Button.ClickButtonCssAsync(ShadowHost_Text, TermsandConditions_Link);
            await page.GoBackAsync();
            await page.WaitForLoadStateAsync(LoadState.NetworkIdle);
            await RetrySigninAsync();
        }

        public async Task RetrySigninAsync()
        {
            // If Terms and Conditions exists, page loaded and signed in to Agent Home
            if (await Button.VerifyButtonExistCssAsync(ShadowHost_Text, TermsandConditions_Link))
            {
                logger.WriteLine("Page is Loaded Successfully and signed to Agent Home");
            }
            else
            {
                await Button.ClickButtonAsync(RetrySign_Btn, ActionType.Click, true, 1);
            }
        }
    }
}
using BDD.Playwright.GBIZ.PageElements;
using BDD.Playwright.GBIZ.Pages.CommonPage;
using BDD.Playwright.GBIZ.Pages.XpathProperties;
using Reqnroll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDD.Playwright.GBIZ.Pages.GlobalPages
{
    public class FooterLinks : BasePage
    {
        public CommonXpath _commonXpath;
        public FooterLinks(ScenarioContext scenarioContext, CommonXpath commonXpath) : base(scenarioContext)
        {

            //PageFactory.InitElements(Driver, this);
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
            //commonFunctions.UserWaitForPageToLoadCompletly();
           // Button.ClickButtonCss(ShadowHost_Text, PrivacyPolicy_Link);
            //Driver.Navigate().Back();
            //commonFunctions.UserWaitForPageToLoadCompletly();
            await RetrySigninAsync();
        }

        public async Task ContactUsMethodAsync()
        {
            //commonFunctions.UserWaitForPageToLoadCompletly();
           // Button.ClickButtonCss(ShadowHost_Text, ContactUs_Link);
            //Driver.Navigate().Back();
            //commonFunctions.UserWaitForPageToLoadCompletly();
            //RetrySignin();
        }

        public async Task TermMethodAsync()
        {
            //commonFunctions.UserWaitForPageToLoadCompletly();
          //  Button.ClickButtonCss(ShadowHost_Text, TermsandConditions_Link);
            //Driver.Navigate().Back();
            //commonFunctions.UserWaitForPageToLoadCompletly();
            await RetrySigninAsync();
        }

        public async Task RetrySigninAsync()
        {
           /* if (await Button.VerifyButtonExistCssAsync(ShadowHost_Text, TermsandConditions_Link))
            {
                logger.WriteLine("Page is Loaded Successfully and signed to Agent Home");
            }
            else
            {
                Button.ClickButtonAsync(RetrySign_Btn, ActionType.Click, true, 1);
                //commonFunctions.UserWaitForPageToLoadCompletly();
            }*/
        }
    }
}

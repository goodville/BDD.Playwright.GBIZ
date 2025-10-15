using GoodVille.GBIZ.Reqnroll.Automation.PageElements;
using GoodVille.GBIZ.Reqnroll.Automation.Pages.CommonPage;
using GoodVille.GBIZ.Reqnroll.Automation.Pages.XpathProperties;
using Microsoft.CodeAnalysis.CSharp;
using Reqnroll;
using SeleniumExtras.PageObjects;

namespace BDD.Playwright.Test.GlobalPages
{
    public class FooterLink : BasePage
    {
        public CommonXpath _commonXpath;
        public FooterLink(ScenarioContext scenarioContext, CommonXpath commonXpath) : base(scenarioContext)
        {

            PageFactory.InitElements(Driver, this);
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
            Button.ClickButtonCss(ShadowHost_Text, PrivacyPolicy_Link);
            //Driver.Navigate().Back();
            commonFunctions.UserWaitForPageToLoadCompletly();
            RetrySignin();
        }

        public async Task ContactUsMethodAsync()
        {
            //commonFunctions.UserWaitForPageToLoadCompletly();
            Button.ClickButtonCss(ShadowHost_Text, ContactUs_Link);
            //Driver.Navigate().Back();
            //commonFunctions.UserWaitForPageToLoadCompletly();
            RetrySignin();
        }

        public async Task TermMethodAsync()
        {
            //commonFunctions.UserWaitForPageToLoadCompletly();
            Button.ClickButtonCss(ShadowHost_Text, TermsandConditions_Link);
            //Driver.Navigate().Back();
            //commonFunctions.UserWaitForPageToLoadCompletly();
            RetrySignin();
        }

        public async Task RetrySigninAsync()
        {
            if (Button.VerifyButtonExistCss(ShadowHost_Text, TermsandConditions_Link))
            {
                SpecLogger.WriteLine("Page is Loaded Successfully and signed to Agent Home");
            }
            else
            {
                Button.ClickButton(RetrySign_Btn, ActionType.Click, true, 1);
                //commonFunctions.UserWaitForPageToLoadCompletly();
            }
        }
    }
}

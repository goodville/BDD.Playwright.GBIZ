using BDD.Playwright.GBIZ.PageElements;
using BDD.Playwright.GBIZ.Pages.CommonPage;
using BDD.Playwright.GBIZ.Pages.PublicPages;
using BDD.Playwright.GBIZ.Pages.XpathProperties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDD.Playwright.Test.StepDefinitions.Public_StepDefinition
{
    [Binding]
    public class TC14_StepDefinition : BasePage
    {
        private readonly ScenarioContext _scenarioContext;
        public CommonXpath _commonXpath;
        private readonly ReportAClaimStartPage _reportAClaimStartPage;
        public TC14_StepDefinition(ScenarioContext scenarioContext, CommonXpath commonXpath, ReportAClaimStartPage reportAClaimStartPage) : base(scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _commonXpath = commonXpath;
            _reportAClaimStartPage = reportAClaimStartPage;
        }

        [When(@"User verify Active BreadCrumb to verify Make a Payment page opened")]
        public async Task WhenUserVerifyActiveBreadCrumbToVerifyMakeAPaymentPageOpenedAsync()
        {
            await Label.VerifyTextAsync(_commonXpath.MakeaPayment_Link_BreadCrumb, "MAKE A PAYMENT", true, 2);
            await TextLink.ClickTextLinkAsync(_commonXpath.MakeaPayment_Link_BreadCrumb, true, 1);
        }

        [When(@"User enters policy details in policy lookup section in Payments Page")]
        public async Task WhenUserEntersPolicyDetailsInPolicyLookupSectionInPaymentsPageAsync()
        {
            await InputField.SetTextAreaInputFieldAsync(_reportAClaimStartPage.PolicyNumber_Input, "GMQA100032863", true, 2);
            await InputField.SetTextAreaInputFieldAsync(_reportAClaimStartPage.ZipCode_Input, "46947", true, 2);
            await Button.ClickButtonAsync(_commonXpath.Submit_Btn, ActionType.Click, true, 2);
            await Task.Delay(12000);
            await Label.VerifyTextAsync(_commonXpath.MakeaPayment_PolicyTitle, "POLICY INFORMATION", true, 2);
            await Label.VerifyTextAsync(_commonXpath.MakeaPayment_PolicyInsuredName, "Regression IN Individual Farm", true, 2);
            await Label.VerifyTextAsync(_commonXpath.MakeaPayment_PolicyNumber, "GMQA100032863", true, 2);
        }
    }
}

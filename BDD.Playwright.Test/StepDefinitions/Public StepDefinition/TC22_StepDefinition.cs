using BDD.Playwright.Core.Interfaces;
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
    public class TC22_StepDefinition : BasePage
    {
        private readonly ScenarioContext _scenarioContext;
        public CommonXpath _commonXpath;
        private readonly ReportAClaimFormPage _reportAClaimFormPage;
        public TC22_StepDefinition(ScenarioContext scenarioContext, CommonXpath commonXpath, ReportAClaimFormPage reportAClaimFormPage) : base(scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _commonXpath = commonXpath;
            _reportAClaimFormPage = reportAClaimFormPage;
        }

        [When(@"User Verify the Loss Message, Policy Information, Agent Information and Goodville Mutual Information")]
        public async Task WhenUserVerifytheLossMessagePolicyInformationAgentInformationandGoodvilleMutualInformationAsync()
        {
            await Label.VerifyTextAsync(_reportAClaimFormPage.LossNoticeRecived_Text, "We have received the claim that you reported on our website. A claims adjuster has been assigned and will contact you within 8 working hours. We have also sent a copy of the claim report to your agent. If you have any questions concerning your claim, please contact your agent or our claims department.", true, 1);
            await Label.VerifyTextLinesAsync(_reportAClaimFormPage.PolicyHolderInformation_Text, "Personal Auto Policy 765475\r\nBetty Smith\r\nDavid Smith\r\n433 Front Hwy\r\nNarvonPA17555", true, 1);
            await Label.VerifyTextLinesAsync(_reportAClaimFormPage.AgentInformation_Text, "Goodville Mutual Casualty Company\r\n625 W Main St\r\nNew HollandPA17557-0489\r\nPhone:(717) 354-4921", true, 1);
            await Label.VerifyTextLinesAsync(_reportAClaimFormPage.GoodvilleInformation_Text, "Goodville Mutual Casualty Company 625 W Main Street PO Box 489 New Holland, PA 17557-0489 Phone:  (717) 354-4921  Toll Free:  (800) 448-4622  Fax:  (717) 354-5158  Email:  claims@goodville.com https://www.goodville.com", true, 1);
        }
        }
}

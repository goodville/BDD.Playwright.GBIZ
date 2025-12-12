using BDD.Playwright.GBIZ.PageElements;
using BDD.Playwright.GBIZ.Pages.CommonPage;
using BDD.Playwright.GBIZ.Pages.XpathProperties;
using Microsoft.Playwright;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDD.Playwright.Test.StepDefinitions.Public_StepDefinition
{
    [Binding]
    public class TC7_StepDefinition : BasePage
    {
        private readonly ScenarioContext _scenarioContext;
        public CommonXpath _commonXpath;
        public TC7_StepDefinition(ScenarioContext scenarioContext, CommonXpath commonXpath) : base(scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _commonXpath = commonXpath;
        }

        [When(@"User Click on Risk Address Grouping")]
        public async Task WhenUserClickonRiskAddressGroupingAsync()
        {
            await TextLink.ClickTextLinkAsync(_commonXpath.RiskAddressGrouping_Link, true, 1);
            await InputField.SetTextAreaInputFieldAsync(_commonXpath.RAGPage_Street_Inp, "635 W Main St", true, 1);
            await InputField.SetTextAreaInputFieldAsync(_commonXpath.RAGPage_StreetLine2_Inp, "433 S Kinzer Ave", true, 1);
            await InputField.SetTextAreaInputFieldAsync(_commonXpath.RAGPage_City_Inp, "New Holland", true, 1);
            await InputField.SetTextAreaInputFieldAsync(_commonXpath.RAGPage_State_Inp, "PA", true, 1);
            await InputField.SetTextAreaInputFieldAsync(_commonXpath.RAGPage_Zip_Inp, "17557-8736", true, 1);
            await Button.ClickButtonAsync(_commonXpath.RAGPage_LookUp_Btn, ActionType.Click, true, 1);
            if (await Label.VerifyTextAsync(_commonXpath.AddressSearched_Validation, "FOUND LOCATION:", true, 1))
            {
                logger.WriteLine("Address Found");
            }
            else
            {
                throw new Exception("Address Not Found and No Other Address is displayed");
            }
        }
    }
}

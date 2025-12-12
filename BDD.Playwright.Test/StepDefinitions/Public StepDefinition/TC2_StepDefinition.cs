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
    public class TC2_StepDefinition : BasePage
    {
        private readonly ScenarioContext _scenarioContext;
        public CommonXpath _commonXpath;
        public TC2_StepDefinition(ScenarioContext scenarioContext, CommonXpath commonXpath) : base(scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _commonXpath = commonXpath;
        }

        [When(@"User Enter the Invalid Address and it will be show no address")]
        public async Task WhenUserEntertheZipcodetoFindAgentinthatLocationAsync()
        {
            await InputField.SetTextAreaInputFieldAsync(_commonXpath.Address_Inp, "East Main Street, Johnstown, NY, USA", true, 1);
            await Button.ClickButtonAsync(_commonXpath.Search_Button, ActionType.Click, true, 1);
            await Task.Delay(5000);
            await Label.VerifyTextAsync(_commonXpath.NoAgentValidation, "No Results. Goodville does not offer insurance in this state.", true, 1);
        }
    }
}

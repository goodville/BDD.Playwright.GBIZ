using BDD.Playwright.Core.Loggers;
using BDD.Playwright.GBIZ.PageElements;
using Microsoft.Playwright;
using Reqnroll;

namespace BDD.Playwright.GBIZ.Pages.CommonPage
{
    public class BasePage
    {
        public ScenarioContext _scenarioContext;
        public IReqnrollOutputHelper SpecLogger;
        public string Environment;
        public string PageLevelScreenshot;
        public string TakeScreenshot;
        public Button Button;
        public CustomButtonLink CustomButtonLink;
        public Checkbox Checkbox;
        public DatePicker DatePicker;
        public DropDown DropDown;
        public InputField InputField;
        public Label Label;
        public RadioButton RadioButton;
        public TextLink TextLink;
        public MenuItem MenuItem;
        public Icon Icon;
        public TextArea TextArea;
        //public IPage Driver;
        protected IPage page;
        protected readonly ApplicationLogger logger;

        public BasePage(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            PageLevelScreenshot = System.Environment.GetEnvironmentVariable("PageLevelScreenshot");
            Environment = System.Environment.GetEnvironmentVariable("Environment", EnvironmentVariableTarget.Process);
            //Environment = TestContext.Parameters["Environment"];
            //commonFunctions = _scenarioContext.Get<CommonFunctions>("CommonFunctions");
            //Driver = _scenarioContext.Get<IPage>("Driver");
            logger = scenarioContext.Get<ApplicationLogger>("Logger");
            page = scenarioContext.Get<IPage>("Page");
            PageElementsSetup();

        }

        /// <summary>
        /// Pages the object setup.
        /// </summary>
        public void PageElementsSetup()
        {
            Button = new Button(_scenarioContext);
            CustomButtonLink = new CustomButtonLink(_scenarioContext);
            Checkbox = new Checkbox(_scenarioContext);
            DatePicker = new DatePicker(_scenarioContext);
            DropDown = new DropDown(_scenarioContext);
            InputField = new InputField(_scenarioContext);
            Label = new Label(_scenarioContext);
            RadioButton = new RadioButton(_scenarioContext);
            TextLink = new TextLink(_scenarioContext);
            MenuItem = new MenuItem(_scenarioContext);
            Icon = new Icon(_scenarioContext);
            TextArea = new TextArea(_scenarioContext);
        }

        protected async Task NavigateToURLAsync(string url)
        {
            await page.GotoAsync(url);
        }
    }
}

using BDD.Playwright.Core.Loggers;
using BDD.Playwright.GBIZ.Pages.CommonPage;
using BDD.Playwright.GBIZ.Pages.XpathProperties;
using BDD.Playwright.Origami.Pages.CommonPage;
using GoodVille.GBIZ.Reqnroll.Automation.Pages.GlobalPages;
using Microsoft.Playwright;

namespace GoodVille.GBIZ.Reqnroll.Automation.Steps.AgentsStepDefinition
{
    [Binding]
    public class AgentTC42_StepDefinition : BasePage
    {
        private readonly ScenarioContext _scenarioContext;
        public FeatureContext _featureContext;
        public CommonXpath _commonXpath;
        public LoginPage _loginPage;
        public SecureEmailRegistrationPage _secureEmailRegistrationPage;

        // Constructor
        public AgentTC42_StepDefinition(
            ScenarioContext scenarioContext,
            LoginPage loginPage,
            CommonXpath commonXpath,
            SecureEmailRegistrationPage secureEmailRegistrationPage
        ) : base(scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _loginPage = loginPage;
            _commonXpath = commonXpath;
            _secureEmailRegistrationPage = secureEmailRegistrationPage;
        }

        #region Xpath
        public string VerificationMessageSent { get; set; } =
            "//p[text()='A verification message was sent to your email address which contains a URL you must use to activate your account.  Once active, you will be able to send your secure message.']";

        public string DoNotReceiveMessage { get; set; } =
            "//p[text()='If you do not receive this message within a few moments, please check your spam folder or other filtering tools you may be using as this activation message sometimes gets blocked. ']";
        #endregion

        [When(@"User Verify the Title and sends an email to company for email activation from {string}")]
        public async Task UserVerifyTheTitleAndSendsAnEmailToCompanyForEmailActivationAsync(string profileKey)
        {
            await _secureEmailRegistrationPage.RegistrationMethodAsync(profileKey);
            await Label.VerifyTextAsync(
                VerificationMessageSent,
                "A verification message was sent to your email address which contains a URL you must use to activate your account. Once active, you will be able to send your secure message.",
                true,
                1
            );
            await Label.VerifyTextAsync(
                DoNotReceiveMessage,
                "If you do not receive this message within a few moments, please check your spam folder or other filtering tools you may be using as this activation message sometimes gets blocked.",
                true,
                1
            );
        }
    }
}
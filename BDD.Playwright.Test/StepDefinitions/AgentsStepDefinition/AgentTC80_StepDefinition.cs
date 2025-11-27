//using AventStack.ExtentReports.Gherkin.Model;
//using BDD.Playwright.Core.Loggers;
//using BDD.Playwright.GBIZ.PageElements;
//using BDD.Playwright.GBIZ.Pages.AgentsPages;
//using BDD.Playwright.GBIZ.Pages.CommonPage;
//using BDD.Playwright.GBIZ.Pages.XpathProperties;
//using BDD.Playwright.Origami.Pages.AgentPages;
//using GoodVille.GBIZ.Reqnroll.Automation.Pages.GlobalPages;
//using Microsoft.Playwright;

//namespace GoodVille.GBIZ.Specflow.Automation.Steps.AgentsStepDefinition
//{
//    [Binding]
//    public class AgentTC80_StepDefinition : BasePage
//    {
//        private readonly ScenarioContext _scenarioContext;
//        public FeatureContext _featureContext;
//        public CommonXpath _commonXpath;
//        public LoginPage _loginPage;
//        public ProfilePage _profilePage;
//        public PersonalAutoQuoteInformation _quoteInformation;
//        public Quote_ApplicantPage _quoteApplicant;
//        public Quote_LocationPage _quoteLocation;
//        public Quote_BuildingPage _quoteBuilding;
//        public Quote_BusinesscoveragePage _quoteBusinesscoverage;
//        public Quote_BCBindingPage _quoteBCBinding;
//        public PersonalAutoNewQuotePrefillOrder _personalAutoNewQuotePrefillOrder;

//        public AgentTC80_StepDefinition(
//            ScenarioContext scenarioContext,
//            LoginPage loginPage,
//            CommonXpath commonXpath,
//            ProfilePage profilePage,
//            PersonalAutoQuoteInformation quoteInformation,
//            PersonalAutoNewQuotePrefillOrder personalAutoNewQuotePrefillOrder,
//            Quote_ApplicantPage quoteApplicantpage,
//            Quote_LocationPage quoteLocationpage,
//            Quote_BuildingPage quoteBuildingpage,
//            Quote_BusinesscoveragePage quoteBusinesscoveragepage,
//            Quote_BCBindingPage quoteBCBindingPage ) : base(scenarioContext)
//        {
//            _scenarioContext = scenarioContext;
//            _loginPage = loginPage;
//            _commonXpath = commonXpath;
//            _profilePage = profilePage;
//            _quoteInformation = quoteInformation;
//            _personalAutoNewQuotePrefillOrder = personalAutoNewQuotePrefillOrder;
//            _quoteApplicant = quoteApplicantpage;
//            _quoteLocation = quoteLocationpage;
//            _quoteBuilding = quoteBuildingpage;
//            _quoteBusinesscoverage = quoteBusinesscoveragepage;
//            _quoteBCBinding = quoteBCBindingPage;
//        }

//        [When(@"user opens the Quoting link and checks if Online Quoting text appears")]
//        public async Task WhenUserOpensTheQuotingLinkAndChecksIfOnlineQuotingTextAppearsAsync()
//        {
//            await Button.ClickButtonCssAsync(_commonXpath.ShadowHost, _commonXpath.QuotingSidePanelShadow)
//            await Label.VerifyTextAsync(_commonXpath.OnlineQuoting_Text, "Online Quoting", true, 1);
//        }

//        [When(@"user taps on the new quote tab")]
//        public async Task WhenUserTapsOnTheNewQuoteTabAsync()
//        {
//            await Button.ClickButtonAsync(_commonXpath.NewQuoteLink, ActionType.Click, true, 1);
//        }

//        [When(@"user chooses the Business cover option")]
//        public async Task WhenUserChoosesTheBusinessCoverOptionAsync()
//        {
//            await Button.ClickButtonAsync(_commonXpath.Quote_BusinessCover, ActionType.Click, true, 1);
//        }

//        [Then(@"confirm that Business cover text appears")]
//        public async Task ThenConfirmThatBusinessCoverTextAppearsAsync()
//        {
//            await Label.VerifyTextAsync(_commonXpath.BusinessCover_Text, "Business Cover", true, 1);
//            await Label.GetTextAsync(_commonXpath.BusinessCover_FullText, true, 1);
//            var pattern = @"^Business Cover - \d+$";
//            await Label.VerifyTextFormatAsync("//div[@id='formHeaderLeft']", pattern, true, 1, "Policy Header");
//        }

//        [When(@"user completes the mandatory fields in the Business cover new quote page")]
//        public async Task WhenUserCompletesTheMandatoryFieldsInTheBusinessCoverNewQuotePageAsync()
//        {
//            await _quoteApplicant.ApplicantDatafillAsync();
//        }

//        [When(@"user completes the mandatory fields in the Business cover location page")]
//        public async Task WhenUserCompletesTheMandatoryFieldsInTheBusinessCoverLocationPageAsync()
//        {
//            await _quoteLocation.LocationDatafillAsync();
//        }

//        [When(@"user completes the mandatory fields in the Building page and presses next")]
//        public async Task WhenUserCompletesTheMandatoryFieldsInTheBuildingPageAndPressesNextAsync()
//        {
//            await _quoteBuilding.BuildingDatafillAsync();
//        }

//        [When(@"user completes the mandatory fields in the Business cover coverage page and presses next")]
//        public async Task WhenUserCompletesTheMandatoryFieldsInTheBusinessCoverCoveragePageAndPressesNextAsync()
//        {
//            await _quoteBusinesscoverage.BusinesscoverageDatafillAsync();
//        }

//        [Then(@"user checks if Applicant information is shown on the Summary page")]
//        public async Task ThenUserChecksIfApplicantInformationIsShownOnTheSummaryPageAsync()
//        {
//            //await Button.ScrollUpAsync(_page);
//            //await Button.ScrollUpAsync(_page);
//            await Task.Delay(4000);
//            // Uncomment if you wish to verify
//            // await Label.VerifyTextAsync(_page, _commonXpath.Businesscover_Address1_updated, "9 Mill St", true, 1);
//            // await Label.VerifyTextAsync(_page, _commonXpath.Businesscover_EffectiveDateText, "Effective date", true, 1);
//            // await Label.VerifyTextAsync(_page, _commonXpath.Businesscover_EffectiveDate, "08/06/2025", true, 1);
//        }

//        [Then(@"user checks if Limits of Insurance information is shown on the Summary page")]
//        public async Task ThenUserChecksIfLimitsOfInsuranceInformationIsShownOnTheSummaryPageAsync()
//        {
//            await Label.VerifyTextAsync(_commonXpath.Businesscover_TerrorismLossLiability, "$ 500,000", true, 1);
//            await Label.VerifyTextAsync(_commonXpath.Businesscover_TerrorismLossproperty, "$ 350,000", true, 1);
//            await Label.VerifyTextAsync( _commonXpath.Businesscover_EmploymentrelatedLiability, "$ 50,000", true, 1);
//            await Label.VerifyTextAsync(_commonXpath.Businesscover_FireLegalliability, "$ 300,000", true, 1);
//            //await Button.ScrollUpAsync(_page);
//            await Task.Delay(4000);
//        }

//        [Then(@"user checks if Total premium amount is shown on the Summary page")]
//        public async Task ThenUserChecksIfTotalPremiumAmountIsShownOnTheSummaryPageAsync()
//        {
//            await Label.GetTextAsync(_commonXpath.BCTotalPremium, true, 1);
//            await Label.VerifyValueAsync( _commonXpath.BCTotalPremium, "768", true, 1);
//            await Button.ClickButtonAsync(_commonXpath.Continuetomortage, ActionType.Click, true, 1);
//        }

//        [When(@"user completes the required fields on the BC Billing page")]
//        public async Task WhenUserCompletesTheRequiredFieldsOnTheBCBillingPageAsync()
//        {
//            await Button.ClickButtonAsync(_commonXpath.BCContinueBilling, ActionType.Click, true, 1);
//            await Button.ClickButtonAsync(_commonXpath.Payment_6Pay, ActionType.Click, true, 1);
//            // Uncomment to verify premium breakdown
//            // await Label.GetTextAsync(_page, _commonXpath.BC6PayPremium_1, true, 1);
//            // await Label.VerifyValueAsync(_page, _commonXpath.BC6PayPremium_1, "152", true, 1);
//            // ...
//            await Button.ClickButtonAsync(_commonXpath.BCContinueBinding, ActionType.Click, true, 1);
//            await Task.Delay(10000);
//        }

//        [When(@"user completes the required fields on the BC Binding page")]
//        public async Task WhenUserCompletesTheRequiredFieldsOnTheBCBindingPageAsync()
//        {
//            await _quoteBCBinding.BindingDataFillAsync();
//            //await Button.ScrollUpAsync(_page);
//            //await Button.ScrollUpAsync(_page);
//            //await Button.ScrollUpAsync(_page);
//            await page.WaitForTimeoutAsync(2000);
//            await Button.ClickButtonAsync(_commonXpath.Save_btn, ActionType.Click, true, 1);
//            await Button.ClickButtonAsync(_commonXpath.Rate_btn, ActionType.Click, true, 1);
//            await page.WaitForTimeoutAsync(5000);
//            //await Button.ScrollDownAsync(_page);
//            ///await Button.ScrollDownAsync(page);
//            //await Button.ScrollDownAsync(_page);
//            await page.WaitForTimeoutAsync(20000);
//            // Uncomment for overrides and checkboxes
//            // await Button.ClickButtonAsync(_page, _commonXpath.MessageOverRides, ActionType.Click, true, 1);
//            // await _page.WaitForTimeoutAsync(7000);
//            // await Checkbox.SelectCheckboxAsync(_page, _commonXpath.BCoverride1, true, true, 1);
//            // await Button.ScrollDownAsync(_page);
//            // ...
//            // await Button.ClickButtonAsync(_page, _commonXpath.ApplyOverRides2, ActionType.Click, true, 1);
//            // await _page.Dialogs[0].AcceptAsync();
//            await page.WaitForTimeoutAsync(20000);
//            await Button.ClickButtonAsync(_commonXpath.Bcbind_btn, ActionType.Click, true, 1);
//            await page.WaitForTimeoutAsync(5000);
//            await Button.ClickButtonAsync(_commonXpath.BindPolicyOkButton, ActionType.Click, true, 1);
//            await page.WaitForTimeoutAsync(5000);
//            //await Button.ScrollUpAsync(_page);
//            await page.WaitForTimeoutAsync(40000);
//        }

//        [Then(@"user should see whether the policy is bound successfully")]
//        public async Task VerifyPolicyIsBoundSuccessfullyAsync()
//        {
//            // Place additional assertions if needed
//            await page.WaitForTimeoutAsync(5000);
//        }

//        [When(@"User clicks on the Logout")]
//        public async Task UserClickontheLogoutButtonAsync()
//        {
//            await Button.ClickButtonCssAsync("gg-navigation", "a[href*='logout']");
//            Console.WriteLine("Agent Logout Successfully.");
//        }
//    }
//}
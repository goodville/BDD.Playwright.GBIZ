using AventStack.ExtentReports.Gherkin.Model;
using BDD.Playwright.GBIZ.PageElements;
using BDD.Playwright.GBIZ.Pages.CommonPage;
using BDD.Playwright.GBIZ.Pages.XpathProperties;
using BDD.Playwright.Origami.Pages.AgentPages;
using GoodVille.GBIZ.Reqnroll.Automation.Pages.GlobalPages;

namespace GoodVille.GBIZ.Specflow.Automation.Steps.AgentsStepDefinition
{
    [Binding]
    public class AgentTC68_StepDefinition : BasePage
    {
        private readonly ScenarioContext _scenarioContext;
        public FeatureContext _featureContext;
        public CommonXpath _commonXpath;
        public LoginPage _loginPage;
        public ProfilePage _profilePage;
        // Constructor
        public AgentTC68_StepDefinition(ScenarioContext scenarioContext, LoginPage loginPage, CommonXpath commonXpath, ProfilePage profilePage) : base(scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _loginPage = loginPage;
            _commonXpath = commonXpath;
            _profilePage = profilePage;
        }

        [When (@"User clicks on new quote")]
        public async Task UserSClicksNewQuoteForDwellingFireAsync()
        {
             await Button.ClickButtonAsync(_commonXpath.NewQuoteLink, ActionType.Click, true, 1);
            //await Button.ClickButtonAsync(_commonXpath.BusinessCoverQuote, ActionType.Click, true, 1);
             await Task.Delay(4000);
         }

        [When(@"User select the Personal Umbrella Quote")]
        public async Task UserSelectThePersonalUmbrellalinkAsync()
        {
            await Button.ClickButtonAsync(_commonXpath.Quote_PersonalUmbrella, ActionType.Click, true, 1);
            await Task.Delay(12000);
            //await DropDown.SelectDropDownAsync(_commonXpath.Quote_PersonalUmbrella_PolLimit, "1,000,000", true, 1);
            await InputField.SetTextAreaInputFieldAsync(_commonXpath.Quote_PersonalUmbrella_NamedInsFirstName, "TestFirstName", true, 1);
            await InputField.SetTextAreaInputFieldAsync(_commonXpath.Quote_PersonalUmbrella_NamedInsLastName, "TestLastName", true, 1);
            await InputField.SetTextAreaInputFieldAsync(_commonXpath.Quote_PersonalUmbrella_NamedInsNamedInsDOB, "01/01/1990", true, 1);
            await InputField.SetTextAreaInputFieldAsync(_commonXpath.Quote_PersonalUmbrella_SecondNamedInsFirstName, "TestSecondName", true, 1);
            await InputField.SetTextAreaInputFieldAsync(_commonXpath.Quote_PersonalUmbrella_SecondNamedInsLastName, "TestSecondLastName", true, 1);
            await InputField.SetTextAreaInputFieldAsync(_commonXpath.Quote_PersonalUmbrella_SecondNamedInsNamedInsDOB, "01/01/1991", true, 1);
            await InputField.SetTextAreaInputFieldAsync(_commonXpath.Quote_PersonalUmbrella_Address, "876 W Main St", true, 1);
            await InputField.SetTextAreaInputFieldAsync(_commonXpath.Quote_PersonalUmbrella_AddressZIP, "17557", true, 1);
            //await Button.ClickButtonAsync(_commonXpath.IHaveInformedInsured, ActionType.Click, true, 1);
            //Label.VerifyText(_commonXpath.IHaveInformedInsured, "I have informed the insured", true, 1);
            await DropDown.SelectDropDownAsync(_commonXpath.Quote_PersonalUmbrella_RelTo_Insured, "Other", true, 1);
            await Task.Delay(2000);
            await InputField.SetTextAreaInputFieldAsync(_commonXpath.Quote_PersonalUmbrella_LstRel, "Test", true, 1);
            await DropDown.SelectDropDownAsync(_commonXpath.Quote_PersonalUmbrella_PolLimit, "1,000,000", true, 1);
            await Task.Delay(2000);
            await DropDown.SelectDropDownAsync(_commonXpath.Quote_PersonalUmbrella_Retentikon, "250", true, 1);
            await Task.Delay(2000);
            await Button.ClickButtonAsync(_commonXpath.Quote_PersonalUmbrella_IsThisAlsoMailingAddress, ActionType.Click, true, 1);
            await Button.ClickButtonAsync(_commonXpath.Quote_PersonalUmbrella_ContinueToUndelyingPolicy, ActionType.Click, true, 1);
            await Task.Delay(7000);
            //TextLink.ClickTextLink(_commonXpath.PolicyPage_SearchPolicies_Link, true, 1);
            //await Button.ClickButtonAsync(_commonXpath.OnlineQuoting_ContinueLink, ActionType.Click, true, 1);
            //TextLink.ClickTextLink(_commonXpath.PolicyPage_SearchPolicies_Link, true, 1);
        }

        [When(@"User enters the Underlying Policy details")]
        public async Task UserEntersTheUnderlyingPolicyDetailsAsync()
        {
            await DropDown.SelectDropDownAsync(_commonXpath.Quote_PersonalUmbrella_PolicyType, "Homeowners", true, 1);
            await Task.Delay(4000);
            await DropDown.SelectDropDownAsync(_commonXpath.Quote_PersonalUmbrella_Company, "Goodville Mutual", true, 1);
            await Task.Delay(3000);
            await InputField.SetTextAreaInputFieldAsync(_commonXpath.Quote_PersonalUmbrella_PolicyNum, "595778", true, 1);
            await InputField.SetTextAreaInputFieldAsync(_commonXpath.Quote_PersonalUmbrella_EffDate, "03/30/2023", true, 1);
            await InputField.SetTextAreaInputFieldAsync(_commonXpath.Quote_PersonalUmbrella_ExpDate, "03/30/2024", true, 1);
            await DropDown.SelectDropDownAsync(_commonXpath.Quote_HomeOwners_LiabilityLimit, "500,000", true, 1);
            await Button.ClickButtonAsync(_commonXpath.Quote_HomeOwners_ContinueToExposure, ActionType.Click, true, 1);
           await Task.Delay(7000);
            await DropDown.SelectDropDownAsync(_commonXpath.Quote_HomeOwners_Property_Occupancy, "Primary", true, 1);
            await InputField.SetTextAreaInputFieldAsync(_commonXpath.Quote_HomeOwners_Property_StreetAddress, "445 Grand Blvd", true, 1);
            await InputField.SetTextAreaInputFieldAsync(_commonXpath.Quote_HomeOwners_Property_City, "Wyoming", true, 1);
            await InputField.SetTextAreaInputFieldAsync(_commonXpath.Quote_HomeOwners_Property_Zip, "19934-9512", true, 1);
            //await InputField.SetTextAreaInputFieldAsync(_commonXpath.Quote_PersonalUmbrella_EffDate, "19934-9512", true, 1);
            await Button.ClickButtonAsync(_commonXpath.Quote_HomeOwners_Property_PrimaryHomeRadio, ActionType.Click, true, 1);
            await Button.ClickButtonAsync(_commonXpath.Quote_HomeOwners_Property_AreThereAnyCountryHomeRadio, ActionType.Click, true, 1);
            await Button.ClickButtonAsync(_commonXpath.Quote_HomeOwners_Property_IsThereASwimmingPoolHomeRadio, ActionType.Click, true, 1);
            await Button.ClickButtonAsync(_commonXpath.Quote_HomeOwners_Property_IsThereATrampolineHomeRadio, ActionType.Click, true, 1);
            await DropDown.SelectDropDownAsync(_commonXpath.Quote_HomeOwners_Property_AddAnotherVehiclePrimary, "Primary", true, 1);
            await InputField.SetTextAreaInputFieldAsync(_commonXpath.Quote_HomeOwners_Property_AddAnotherStreetAddress, "74 Sunrise Dr, Englewood, FL 34223", true, 1);
            await InputField.SetTextAreaInputFieldAsync(_commonXpath.Quote_HomeOwners_Property_AddAnotherCity, "Wyoming", true, 1);
            await InputField.SetTextAreaInputFieldAsync(_commonXpath.Quote_HomeOwners_Property_AddAnotherZip, "19934-9512", true, 1);
            await Button.ClickButtonAsync(_commonXpath.Quote_HomeOwners_Property_ClickChevron, ActionType.Click, true, 5);
            await Button.ClickButtonAsync(_commonXpath.Quote_HomeOwners_Property_AddAnotherIsThePrimaryHome, ActionType.Click, true, 1);
            await Button.ClickButtonAsync(_commonXpath.Quote_HomeOwners_Property_AddAnotherAreThereAnyCountryHome, ActionType.Click, true, 1);
            await Button.ClickButtonAsync(_commonXpath.Quote_HomeOwners_Property_AddAnotherIsThereAnySwimmingPool, ActionType.Click, true, 1);
            await Button.ClickButtonAsync(_commonXpath.Quote_HomeOwners_Property_AddAnotherIsThereATrampoline, ActionType.Click, true, 1);
            await Button.ClickButtonAsync(_commonXpath.Quote_HomeOwners_Property_AddAnotherSafetyEnclosureNet, ActionType.Click, true, 1);
            await Task.Delay(12000);
            await Button.ClickButtonAsync(_commonXpath.Quote_HomeOwners_Property_AddAnotherVehiclesSubTabClick, ActionType.Click, true, 1);
            await DropDown.SelectDropDownAsync(_commonXpath.Quote_HomeOwners_Property_AddAnotherVehiclesSubTabVehicleType, "Motorcycles", true, 1);
            //await InputField.SetTextAreaInputFieldAsync(_commonXpath.Quote_HomeOwners_Property_AddAnotherVehiclesSubTabVehicleType, "Wyoming", true, 1);
            await InputField.SetTextAreaInputFieldAsync(_commonXpath.Quote_HomeOwners_Property_AddAnotherVehiclesSubTabYear, "2019", true, 1);
            await InputField.SetTextAreaInputFieldAsync(_commonXpath.Quote_HomeOwners_Property_AddAnotherVehiclesSubTabMake, "Test", true, 1);
            await InputField.SetTextAreaInputFieldAsync(_commonXpath.Quote_HomeOwners_Property_AddAnotherVehiclesSubTabModal, "Test", true, 1);
            await Button.ClickButtonAsync(_commonXpath.Quote_HomeOwners_Property_AddAnotherVehicleSubTabDrivers, ActionType.Click, true, 1);
            await InputField.SetTextAreaInputFieldAsync(_commonXpath.Quote_HomeOwners_Property_DriverFirstName, "TIM", true, 1);
            await InputField.SetTextAreaInputFieldAsync(_commonXpath.Quote_HomeOwners_Property_DriverMiddleName, "M", true, 1);
            await InputField.SetTextAreaInputFieldAsync(_commonXpath.Quote_HomeOwners_Property_DriverLastName, "Edwards", true, 1);
            await InputField.SetTextAreaInputFieldAsync(_commonXpath.Quote_HomeOwners_Property_DriverDOB, "01/16/1963", true, 1);
            await Button.ClickButtonAsync(_commonXpath.Quote_HomeOwners_PropertyGender, ActionType.Click, true, 1);
            await DropDown.SelectDropDownAsync(_commonXpath.Quote_HomeOwners_Property_MaritalStatus, "Single", true, 1);
            await DropDown.SelectDropDownAsync(_commonXpath.Quote_HomeOwners_Property_LICState, "Virginia", true, 1);
            await InputField.SetTextAreaInputFieldAsync(_commonXpath.Quote_HomeOwners_Property_LICNum, "T67190270", true, 1);
            await Button.ClickButtonAsync(_commonXpath.Quote_HomeOwners_PropertyGender, ActionType.Click, true, 1);
            await TextLink.ClickTextLinkAsync(_commonXpath.Quote_HomeOwners_Property_Rate, true, 1);
            await Task.Delay(8000);
            await TextLink.ClickTextLinkAsync(_commonXpath.Quote_HomeOwners_Property_Save, true, 1);
        }
    }
}

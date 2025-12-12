using AventStack.ExtentReports.Gherkin.Model;
using BDD.Playwright.Core.Interfaces;
using BDD.Playwright.Core.Loggers;
using BDD.Playwright.GBIZ.PageElements;
using BDD.Playwright.GBIZ.Pages.AgentPages;
using BDD.Playwright.GBIZ.Pages.CommonPage;
using BDD.Playwright.GBIZ.Pages.XpathProperties;
using BDD.Playwright.Origami.Pages.AgentPages;
using GoodVille.GBIZ.Reqnroll.Automation.Pages.AgentPages;
using GoodVille.GBIZ.Reqnroll.Automation.Pages.GlobalPages;
using Microsoft.Playwright;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace GoodVille.GBIZ.Reqnroll.Automation.Steps.AgentsStepDefinition
{
    [Binding]
    public class Agent75_StepDefinition : BasePage
    {
        private readonly ScenarioContext _scenarioContext;
        public Quote_ApplicantPage _quoteApplicant;
        public Quote_CoveragesPage _quoteCoverage;
        public Quote_DwellingPage _quoteDwelling;
        private readonly LoginPage _loginPage;
        private readonly CommonXpath _commonXpath;
        public Farm_CoveragesPage _farm_CoveragesPage;
        public Quote_ApplicantPage _quoteApplicantPage;
        public Claims_FarmownerPage _claims_FarmownerPage;
        public Quote_DwellingPage _quoteDwellingPage;
        private readonly IFileReader _fileReader;
        public CommonPage _commonPage;

        public Agent75_StepDefinition(
            ScenarioContext scenarioContext,
            LoginPage loginPage,
            CommonXpath commonXpath,
            Farm_CoveragesPage farm_CoveragesPage,
            Quote_DwellingPage quoteDwellingpage,
            Quote_CoveragesPage quoteCoveragespage,
            Quote_ApplicantPage quoteApplicantpage,
            Claims_FarmownerPage claims_FarmownerPage,
            Quote_DwellingPage quoteDwellingPage,
            Quote_ApplicantPage quoteApplicantPage,
            IFileReader fileReader,
            CommonPage commonPage
        ) : base(scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _loginPage = loginPage;
            _quoteApplicant = quoteApplicantpage;
            _quoteCoverage = quoteCoveragespage;
            _quoteDwelling = quoteDwellingpage;
            _commonXpath = commonXpath;
            _farm_CoveragesPage = farm_CoveragesPage;
            _quoteDwellingPage = quoteDwellingPage;
            _quoteApplicantPage = quoteApplicantPage;
            _claims_FarmownerPage = claims_FarmownerPage;
            _fileReader = fileReader;
            _commonPage = commonPage;
        }

        #region Xpath
        public string AddPersonalprop_scheduled { get; set; } = "//input[@id='fld_policyNumber']";
        public string ProprtyInfo_scheduled { get; set; } = "//input[@id='fld_PP_descriptionFreeForm_4']";
        public string Limit_Scheduled { get; set; } = "//input[@id='fld_PP_Limit_4']";
        public string FormGFarm_Owner { get; set; } = "//div[@class='tabNav_rightdiv'  and @tabindex='1']";
        public string AddFArmperProperty_Dropdown { get; set; } = "//a[normalize-space()='Add Farm Personal Property']";
        public string Birds_Dropdwn { get; set; } = "//a[@href='#Poultry' and @data-dropdown-action='addFarmPropertyOther' and @data-dropdown-type='Poultry' and @tabindex='1']";
        public string Limitform_Text { get; set; } = "//input[@id='fld_propC_limit_1' and @name='propC_limit_1' and @type='text' and @class='inputtext' and @tabindex='1']";
        public string Formperil_drpdwn { get; set; } = "//select[@id='fld_propC_FormPerils_1']";
        public string DeductIble_drpDown { get; set; } = "//select[@id='fld_propC_Deductible_1']";
        public string Suffocation_Radiobutton { get; set; } = "//input[@id='fld_yes_propC_Suffocation_1']";
        public string FarmPro_GButton { get; set; } = "//div[@class='tabNav_rightdiv' and @onclick='YAHOO.goodville.fn.goToPage(String(4.03));' and @tabindex='1']";
        public string Libility_subtab { get; set; } = "//div[contains(text(),'Liability')]";
        public string Bodilyinjured_drpDown { get; set; } = "//select[@name='lC_BodilyInjury']";
        public string MedicalPayment_DrpDown { get; set; } = "//select[@name='lC_MedicalPaymentLimit']";
        public string PersonalInju_radioButon { get; set; } = "//input[@id='fld_no_lC_PIHOM']";
        public string InsuranceTransferred_Checkbox { get; set; } = "//input[@id='fld_no_binding_insuranceTransferred']";
        public string CoverageDeclined_Checkbox { get; set; } = "//input[@id='fld_no_binding_coverageDeclined']";
        public string FiledBankruptcy_Checkbox { get; set; } = "//input[@id='fld_no_binding_filedBankruptcy']";
        public string ConvictedArson_Checkbox { get; set; } = "//input[@id='fld_no_binding_convictedArson']";
        public string ProcessForEndConsumer_Checkbox { get; set; } = "//input[@id='fld_no_binding_processForEndConsumer']";
        public string ContractServices_Checkbox { get; set; } = "//input[@id='fld_no_binding_contractServices']";
        public string PublicActivities_Checkbox { get; set; } = "//input[@id='fld_no_binding_publicActivities']";
        public string OutbuildingStoves_Checkbox { get; set; } = "//input[@id='fld_no_binding_outbuildingStoves']";
        public string AdequateFences_Checkbox { get; set; } = "//input[@id='fld_no_binding_adequateFences']";
        public string LandHeld_Checkbox { get; set; } = "//input[@id='fld_no_binding_landHeld']";
        public string MilkProducts_Checkbox { get; set; } = "//input[@id='fld_no_binding_milkProducts']";
        public string ExoticAnimals_Checkbox { get; set; } = "//input[@id='fld_no_binding_exoticAnimals']";
        public string Hunting_Checkbox { get; set; } = "//input[@id='fld_no_binding_hunting']";
        public string Horses_Checkbox { get; set; } = "//input[@id='fld_no_binding_horses']";
        public string IncludeBnb_Checkbox { get; set; } = "//input[@id='fld_no_binding_includeBnb']";
        public string OccupiedDaily_Checkbox { get; set; } = "//input[@id='fld_no_binding_occupiedDaily']";
        public string AddOptionalLiabilityCoverage_Link { get; set; } = "//a[contains(@class,'actionToggle') and contains(text(),'Add Optional Liablity Coverage')]";
        public string CustomFarmWorkWithoutPesticides_Link { get; set; } = "//a[@data-dropdown-action='addFarmLiabilityCoverage' and @data-dropdown-type='CFRCT' and contains(text(),'Custom Farm Work - without pesticides')]";
        public string TotalAnnualreciept_Text { get; set; } = "//input[@id='fld_lC_TotalAnnualReceipts_CFRCT']";
        public string BillinTab { get; set; } = "//a[contains(text(),'Billing')]";
        public string BindTaB { get; set; } = "//a[normalize-space()='Bind']";
        public string OthrEremai_drp { get; set; } = "//input[@id='fld_binding_destinationemail_3']";
        public string EmailBox_Text { get; set; } = "//input[@id='fld_binding_confirmemail']";
        public string Agree_Checkbox { get; set; } = "//input[@id='fld_binding_agreetoterms']";
        public string Save_button { get; set; } = "//a[normalize-space()='save']";
        public string MessageOveRRide_button { get; set; } = "//div[normalize-space()='Message Overrides']";
        public string Messageone_Checkbox { get; set; } = "//div[@id='manualOverridesDialog']//div[@id='Quote_Override_r1']//input[@name='overrideCodes']";
        public string Messagetwo_Checkbox { get; set; } = "//div[@id='manualOverridesDialog']//div[@id='Quote_Override_r2']//input[@name='overrideCodes']";
        public string Messagethre_Checkbox { get; set; } = "//div[@id='manualOverridesDialog']//div[@id='Quote_Override_r3']//input[@name='overrideCodes']";
        public string Messagefour_Checkbox { get; set; } = "//div[@id='manualOverridesDialog']//div[@id='Quote_Override_r4']//input[@name='overrideCodes']";
        public string Messagefive_Checkbox { get; set; } = "//div[@id='manualOverridesDialog']//div[@id='Quote_Override_r5']//input[@name='overrideCodes']";
        public string Messagesix_Checkbox { get; set; } = "//div[@id='manualOverridesDialog']//div[@id='Quote_Override_r6']//input[@name='overrideCodes']";
        public string Messageseven_Checkbox { get; set; } = "//div[@id='manualOverridesDialog']//div[@id='Quote_Override_r7']//input[@name='overrideCodes']";
        public string Messageeight_Checkbox { get; set; } = "//div[@id='manualOverridesDialog']//div[@id='Quote_Override_r8']//input[@name='overrideCodes']";
        public string Messagenine_Checkbox { get; set; } = "//div[@id='manualOverridesDialog']//div[@id='Quote_Override_r9']//input[@name='overrideCodes']";
        public string Messagetesn_Checkbox { get; set; } = "//div[@id='manualOverridesDialog']//div[@id='Quote_Override_r11']//input[@name='overrideCodes']";
        public string MessageELEven_Checkbox { get; set; } = "//div[@id='manualOverridesDialog']//div[@id='Quote_Override_r12']//input[@name='overrideCodes']";
        public string ApplyOverride_button { get; set; } = "//button//span[normalize-space()='Apply Override(s)']";
        public string BindPolicyWith_Goodvillebutton { get; set; } = "//button[@id='buttonbinding_bind_submitbutton']";
        public string OkButton_Binding { get; set; } = "//button[@id='buttonbinding_bind_submitbutton']";
        public string Hay_textBox { get; set; } = "//input[@id='fld_lC_Description_CFRCT']";
        public string Summary_Button { get; set; } = "//a[normalize-space()='Summary']";
        public string Coverages_SumButon { get; set; } = "//a[normalize-space()='Coverages']";
        public string AddFArmProp_Drp { get; set; } = "//a[normalize-space()='Add Farm Personal Property']";
        public string Agree_CheckbOx { get; set; } = "//input[@id='fld_binding_agreetoterms']";
        public string AttacHedDoc_Button { get; set; } = "//div//div[contains(text(),'Attach Documents')]";
        public string RetunTobinding_button { get; set; } = "//button[@id='buttonattachCancel']";
        public string Delete_Quotebutton { get; set; } = "//a[normalize-space()='delete']";
        public string Location_addFarmbird { get; set; } = "//select[@id='fld_propC_location_1']";
        public string Description_AddfarmText { get; set; } = "//input[@id='fld_propC_descriptionFreeForm_1']";
        public string Deducts_Drpdwn { get; set; } = "//select[@name='propC_CovGDeductible']";
        public string BindPolicyWithGoodville_Button { get; set; } = "//button[@id='buttonbinding_bind_submitbutton']";
        public string Ok_Button { get; set; } = "//span[contains(@class,'ui-button-text') and text()='OK']";
        public string PolicyNumber_TextFO { get; set; } = "//div[contains(@class,'tabContainer') and contains(text(),'Your Policy Number is')]";
        public string Office_Drp { get; set; } = "//select[@name='binding_office']";
        public string Producer_Drp { get; set; } = "//select[@name='binding_producer']";
        #endregion

        // All methods below should be async using await, Playwright style
        [When("User Navigates to Add Structure page")]
        public async Task WhenUserNavigatesToAddStructurePageAsync()
        {
            await Task.Delay(2000);
            await Button.ScrollIntoViewAsync(_farm_CoveragesPage.AddStructure_Farm, true, 1);
            await Button.ClickButtonAsync(_farm_CoveragesPage.AddStructure_Farm, ActionType.Click, true, 1);
        }
        [When("User Navigates to poLicyForm Dropdown")]
        public async Task WhenUserNavigatesToPoLicyFormDropdownAsync()
        {
            await DropDown.SelectDropDownAsync(_farm_CoveragesPage.FarmPolIcYFom_Drp, "Broad", true, 1);
        }
        [When("User navigates to Type of building dropdown")]
        public async Task WhenUserNavigatesToTypeOfBuildingDropdownAsync()
        {
            await DropDown.SelectDropDownAsync(_farm_CoveragesPage.TypeOfBuilding_Drp, "Poultry broiler house", true, 1);
        }
        [When("User navigates to coverageFarmOwNer Page from json {string}")]
        public async Task WhenUserNavigatesToCoverageFarmOwNerPageAsync(string jsonFile)
        {
            await _farm_CoveragesPage.CoveragesforFarmOwnerAsync(jsonFile);
        }
        [When("user navigates to FarmPropF button")]
        public async Task WhenUserNavigatesToFarmPropFButtonAsync()
        {
            await Task.Delay(2000);
            await Button.ClickButtonAsync(FormGFarm_Owner, ActionType.Click, true, 1);
        }
        [When("User navigates to FarmProperty page from json {string}")]
        public async Task WhenUserNavigatesToFarmPropertyPageAsync(string profileKey)
        {
            var filePath = "FarmPersonalProperty\\FarmPersonalPropertyPage.json";
            await Task.Delay(2000);
            await Button.ScrollIntoViewAsync(AddFArmProp_Drp, true, 1, "Add Farm Personal Property");
            await Task.Delay(2000);

            page.Locator(AddFArmProp_Drp).ClickAsync();
            await Task.Delay(2000);
            page.Locator(Birds_Dropdwn).ClickAsync();

            await DropDown.SelectDropDownAsync(Location_addFarmbird, _fileReader.GetOptionalValue(filePath, $"{profileKey}.Location"), true, 1);
            await InputField.SetTextAreaInputFieldAsync(Description_AddfarmText, _fileReader.GetOptionalValue(filePath, $"{profileKey}.Description"), true, 1);
            await InputField.SetTextAreaInputFieldAsync(Limitform_Text, _fileReader.GetOptionalValue(filePath, $"{profileKey}.Limitform"), true, 1);
            await DropDown.SelectDropDownAsync(Formperil_drpdwn, _fileReader.GetOptionalValue(filePath, $"{profileKey}.Formperil"), true, 1);
            await DropDown.SelectDropDownAsync(DeductIble_drpDown, _fileReader.GetOptionalValue(filePath, $"{profileKey}.DeductIble"), true, 1);

            var suffocationValue = _fileReader.GetOptionalValue(filePath, $"{profileKey}.Suffocation");
            if (!string.IsNullOrEmpty(suffocationValue))
            {
                await RadioButton.SelectRadioButtonAsync(Suffocation_Radiobutton, suffocationValue, true, 1);
            }
        }
        [When("User navigates to FarmPropG button")]
        public async Task WhenUserNavigatesToFarmPropGButtonAsync()
        {
            await Button.ClickButtonAsync(FarmPro_GButton, ActionType.Click, true, 1);
            await Task.Delay(2000);
        }
        [When("User NAvigates to Deduct drpdown")]
        public async Task WhenUserNAvigatesToDeductDrpdownAsync()
        {
            await Task.Delay(2000);
            await DropDown.SelectDropDownAsync(Deducts_Drpdwn, "500", true, 1);
        }
        [When("User Navigates to Libilty subTAB")]
        public async Task WhenUserNavigatesToLibiltySubTABAsync()
        {
            await Task.Delay(4000);
            await Button.ClickButtonAsync(Libility_subtab, ActionType.Click, true, 1);
        }
        [When("Navigates to libility subTab Page from json {string}")]
        public async Task WhenNavigatesToLibilitySubTabPageAsync(string profileKey)
        {
            await Task.Delay(5000);

            var filePath = "FarmPersonalProperty\\FarmPersonalPropertyPage.json";

            await DropDown.SelectDropDownAsync(Bodilyinjured_drpDown, _fileReader.GetOptionalValue(filePath, $"{profileKey}.BodilyInjury&PropertyDamageLiabilityLimit"), true, 1);
            await DropDown.SelectDropDownAsync(MedicalPayment_DrpDown, _fileReader.GetOptionalValue(filePath, $"{profileKey}.MedicalPaymentLimit"), true, 1);
            await Checkbox.SelectCheckboxAsync(PersonalInju_radioButon, true, true, 1);
        }
        [When("User navigates to add Optional libility cov dropdown")]
        public async Task WhenUserNavigatesToAddOptionalLibilityCovDropdownAsync()
        {
            await Task.Delay(2000);
            // Playwright can't zoom with JS from C#, but you can skip or use page.EvaluateAsync if needed
             await page.EvaluateAsync("document.body.style.zoom='70%'");
            await Task.Delay(2000);
            await page.Locator(AddOptionalLiabilityCoverage_Link).ClickAsync();
            await page.Locator(CustomFarmWorkWithoutPesticides_Link).ClickAsync();
            await page.Locator("//body").ClickAsync();
            await Task.Delay(2000);
            await InputField.SetTextAreaInputFieldAsync(Hay_textBox, "hay", true, 1);
            await InputField.SetTextAreaInputFieldAsync(TotalAnnualreciept_Text, "15000", true, 1);
            await Task.Delay(2000);
            await Button.ScrollIntoViewAsync(_quoteApplicantPage.FOPage_Save_Btn, true, 1, "Save Button");
            await Button.ClickButtonAsync(_quoteApplicantPage.FOPage_Save_Btn, ActionType.Click, true, 1);
        }
        [When("User NAvigates to Summary page")]
        public async Task WhenUserNAvigatesToSummaryPageAsync()
        {
            await Button.ScrollIntoViewAsync(Summary_Button, true, 1, "Summary");
            await Button.ClickButtonAsync(Summary_Button, ActionType.Click, true, 1);
            await Task.Delay(2000);
        }
        [When("User Navigates to Rate Button")]
        public async Task WhenUserNavigatesToRateButtonAsync()
        {
            await Task.Delay(6000);
            await Button.ScrollIntoViewAsync(_commonXpath.Rate_btn, true, 1, "Rate Button");
            await Button.ClickButtonAsync(_commonXpath.Rate_btn, ActionType.Click, true, 1);
            await Task.Delay(7000);
        }
        [When("User navigates to coverages pages")]
        public async Task WhenUserNavigatesToCoveragesPagesAsync()
        {
            await Task.Delay(2000);
            await Button.ScrollIntoViewAsync(Coverages_SumButon, true, 1, "Coverages");
            await Button.ClickButtonAsync(Coverages_SumButon, ActionType.Click, true, 1);
        }
        [When("User NAvigates to the billing tab")]
        public async Task WhenUserNAvigatesToTheBillingTabAsync()
        {
            await Task.Delay(8000);
            await Button.ScrollIntoViewAsync(BillinTab, true, 1, "Billing");
            await Button.ClickButtonAsync(BillinTab, ActionType.Click, true, 1);
            await Task.Delay(8000);
            await Task.Delay(3000);
        }
        [When("User navigates to Binding paGe for farmowner")]
        public async Task WhenUserNavigatesToBindingPaGeForFarmownerAsync()
        {
            await Task.Delay(2000);
            //await _commonFunctions.UserWaitForPageToLoadCompletlyAsync();
            await page.EvaluateAsync("window.scrollTo(0,0);");
            await Button.ClickButtonAsync(BindTaB, ActionType.Click, true, 1);
            await Checkbox.SelectCheckboxAsync(InsuranceTransferred_Checkbox, true, true, 1);
            await Checkbox.SelectCheckboxAsync(CoverageDeclined_Checkbox, true, true, 1);
            await Checkbox.SelectCheckboxAsync(FiledBankruptcy_Checkbox, true, true, 1);
            await Checkbox.SelectCheckboxAsync(ConvictedArson_Checkbox, true, true, 1);
            await Checkbox.SelectCheckboxAsync(ProcessForEndConsumer_Checkbox, true, true, 1);
            await Checkbox.SelectCheckboxAsync(ContractServices_Checkbox, true, true, 1);
            await Checkbox.SelectCheckboxAsync(PublicActivities_Checkbox, true, true, 1);
            await Checkbox.SelectCheckboxAsync(OutbuildingStoves_Checkbox, true, true, 1);
            await Checkbox.SelectCheckboxAsync(AdequateFences_Checkbox, true, true, 1);
            await Checkbox.SelectCheckboxAsync(LandHeld_Checkbox, true, true, 1);
            await Checkbox.SelectCheckboxAsync(MilkProducts_Checkbox, true, true, 1);
            await Checkbox.SelectCheckboxAsync(ExoticAnimals_Checkbox, true, true, 1);
            await Checkbox.SelectCheckboxAsync(Hunting_Checkbox, true, true, 1);
            await Checkbox.SelectCheckboxAsync(Horses_Checkbox, true, true, 1);
            await Checkbox.SelectCheckboxAsync(IncludeBnb_Checkbox, true, true, 1);
            await Checkbox.SelectCheckboxAsync(OccupiedDaily_Checkbox, true, true, 1);
            await Checkbox.SelectCheckboxAsync(OthrEremai_drp, true, true, 1);
        }
        [When("User enter {string} in mail box")]
        public async Task WhenUserEnterInMailBoxAsync(string p0)
        {
            await InputField.SetTextAreaInputFieldAsync(EmailBox_Text, p0, true, 1);
            await Button.ClickButtonAsync(EmailBox_Text, ActionType.Click, true, 1);
        }
        [When("User Navigates to save button")]
        public async Task WhenUserNavigatesToSaveButtonAsync()
        {
            await Task.Delay(2000);
            await Button.ScrollIntoViewAsync(_quoteApplicantPage.FOPage_Save_Btn, true, 1, "Save Button");
            await Button.ClickButtonAsync(_quoteApplicantPage.FOPage_Save_Btn, ActionType.Click, true, 1);
        }
        [When("User navigates to save and rate button")]
        public async Task WhenUserNavigatesToSaveAndRateButtonAsync()
        {
            await Task.Delay(2000);
            await Button.ScrollIntoViewAsync(_commonXpath.Save_btn, true, 1, "Save Button");
            await Task.Delay(2000);
            await Button.ClickButtonAsync(_commonXpath.Save_btn, ActionType.Click, true, 1);
            await Task.Delay(5000);
        }
        [When("User Verifies Attched Docs")]
        public async Task WhenUserVerifiesAttchedDocsAsync()
        {
            await Task.Delay(5000);
            await Button.ScrollIntoViewAsync(AttacHedDoc_Button, true, 1, "Attach Documents");
            await Button.ClickButtonAsync(AttacHedDoc_Button, ActionType.Click, true, 1);
            await Task.Delay(5000);
            await Button.ClickButtonAsync(RetunTobinding_button, ActionType.Click, true, 1);
            await Task.Delay(5000);
        }
        [When("User navigates to save button for farm")]
        public async Task WhenUserNavigatesToSaveButtonForFarmAsync()
        {
            await Task.Delay(5000);
            await Button.ClickButtonAsync(Save_button, ActionType.Click, true, 1);
        }
        [When("user navigates to message override button")]
        public async Task WhenUserNavigatesToMessageOverrideButtonAsync()
        {
            await Button.ScrollIntoViewAsync(MessageOveRRide_button, true, 1, "Message Override");
            await Button.ClickButtonAsync(MessageOveRRide_button, ActionType.Click, true, 1);
        }
        [When("User Checked all override checkboxes")]
        public async Task WhenUserCheckedAllOverrideCheckboxesAsync()
        {
            await Task.Delay(2000);
            await Checkbox.SelectCheckboxAsync(Messageone_Checkbox, true, true, 1);
            await Checkbox.SelectCheckboxAsync(Messagetwo_Checkbox, true, true, 1);
            await Checkbox.SelectCheckboxAsync(Messagethre_Checkbox, true, true, 1);
            await Checkbox.SelectCheckboxAsync(Messagefour_Checkbox, true, true, 1);
            await Checkbox.SelectCheckboxAsync(Messagefive_Checkbox, true, true, 1);
            await Task.Delay(4000);
        }
        [When("User Click On Apply Oveeride Button")]
        public async Task WhenUserClickOnApplyOveerideButtonAsync()
        {
            await Task.Delay(2000);
            await Button.ClickButtonAsync(ApplyOverride_button, ActionType.Click, true, 1);

            // Handle browser dialog with Playwright
            page.Dialog += async (_, dialog) => await dialog.AcceptAsync();
            await Task.Delay(2000);
        }
        [When("User Navigates to Agree Checkbox")]
        public async Task WhenUserNavigatesToAgreeCheckboxAsync()
        {
            var messageOverrides = page.Locator("//div[normalize-space()='Message Overrides']");
            await messageOverrides.ClickAsync();
            /*
            var checkboxes = page.Locator("//div[@id='manualOverridesDialog']//input[@type='checkbox']");
            var checkboxCount = await checkboxes.CountAsync();

            for (var i = 0; i < checkboxCount; i++)
            {
                var checkbox = checkboxes.Nth(i);
                var isChecked = await checkbox.IsCheckedAsync();
                var isEnabled = await checkbox.IsEnabledAsync();
                var isVisible = await checkbox.IsVisibleAsync();
                if (!isChecked && isEnabled && isVisible)
                {
                    await Task.Delay(1000);
                    await checkbox.ClickAsync();
                }
            }

            page.Dialog += async (_, dialog) => await dialog.AcceptAsync();
            var applyButton = page.Locator("//span[normalize-space()='Apply Override(s)']");
            await applyButton.ClickAsync();*/
            await _commonPage.CheckAllMessageOverrideCheckboxes1Async();
            await Task.Delay(2000);
            page.Dialog += async (_, dialog) =>
            {
                try
                {
                    await dialog.AcceptAsync();
                }
                catch (PlaywrightException ex)
                {
                    Console.WriteLine("Dialog already handled: " + ex.Message);
                    logger.WriteLine("Dialog already handled: " + ex.Message);
                }
            };
            var applyButton = page.Locator("//span[normalize-space()='Apply Override(s)']");
            await applyButton.ClickAsync();
        }
        [When("User NavIGAtes to Binding Tab")]
        public async Task WhenUserNavIGAtesToBindingTabAsync()
        {
            await Task.Delay(9000);
            await Button.ScrollIntoViewAsync(BindTaB, true, 1, "Bind");
            await Button.ClickButtonAsync(BindTaB, ActionType.Click, true, 1);
            await Task.Delay(5000);
        }
        [When("User Navigates to producer tab from json {string}")]
        public async Task WhenUserNavigatesToProducerTabOldAsync(string profileKey)
        {
            var filePath = "QuoteBindingPage\\QuoteBindingPage.json";

            await DropDown.SelectDropDownAsync(Office_Drp, _fileReader.GetOptionalValue(filePath, $"{profileKey}.AgencyOffice"), true, 1);
            await Task.Delay(2000);
            await DropDown.SelectDropDownAsync(Producer_Drp, _fileReader.GetOptionalValue(filePath, $"{profileKey}.AgencyProducer"), true, 1);
            await Task.Delay(2000);
        }
        [When("User Select override for DE State")]
        public async Task WhenUserSelectOverrideForDEStateAsync()
        {
            var messageOverrides = page.Locator("//div[normalize-space()='Message Overrides']");
            await messageOverrides.ClickAsync();
            await _commonPage.CheckAllMessageOverrideCheckboxes1Async();
            await Task.Delay(2000);
            page.Dialog += async (_, dialog) =>
            {
                try
                {
                    await dialog.AcceptAsync();
                }
                catch (PlaywrightException ex)
                {
                    Console.WriteLine("Dialog already handled: " + ex.Message);
                    logger.WriteLine("Dialog already handled: " + ex.Message);
                }
            };
            var applyButton = page.Locator("//span[normalize-space()='Apply Override(s)']");
            await applyButton.ClickAsync();
            await Button.ScrollIntoViewAsync(_commonXpath.Rate_btn, true, 1, "Rate Button");
            await Button.ClickButtonAsync(_commonXpath.Rate_btn, ActionType.Click, true, 1);
            await Task.Delay(3000);
            await Button.ScrollIntoViewAsync(_quoteApplicantPage.FOPage_Save_Btn, true, 1, "Save Button");
            await Task.Delay(15000);
            await Button.ScrollIntoViewAsync(BindPolicyWithGoodville_Button, true, 1, "Bind Policy with Goodville");
            await Task.Delay(6000);
        }
        [When("User Select override for IN State")]
        public async Task WhenUserSelectOverrideForINStateAsync()
        {
            var messageOverrides = page.Locator("//div[normalize-space()='Message Overrides']");
            await messageOverrides.ClickAsync();
            await _commonPage.CheckAllMessageOverrideCheckboxes1Async();
            await Task.Delay(2000);
            page.Dialog += async (_, dialog) =>
            {
                try
                {
                    await dialog.AcceptAsync();
                }
                catch (PlaywrightException ex)
                {
                    Console.WriteLine("Dialog already handled: " + ex.Message);
                    logger.WriteLine("Dialog already handled: " + ex.Message);
                }
            };
            var applyButton = page.Locator("//span[normalize-space()='Apply Override(s)']");
            await applyButton.ClickAsync();
            await Task.Delay(2000);
            await Button.ScrollIntoViewAsync(_commonXpath.Rate_btn, true, 1, "Rate Button");
            await Button.ClickButtonAsync(_commonXpath.Rate_btn, ActionType.Click, true, 1);
            await Task.Delay(3000);
            await Button.ScrollIntoViewAsync(_quoteApplicantPage.FOPage_Save_Btn, true, 1, "Save Button");
            await Task.Delay(19000);
            await Button.ScrollIntoViewAsync(BindPolicyWithGoodville_Button, true, 1, "Bind Policy with Goodville");
            await Task.Delay(9000);
        }
        [When("User Select override for IL State")]
        public async Task WhenUserSelectOverrideForILStateAsync()
        {
            var messageOverrides = page.Locator("//div[normalize-space()='Message Overrides']");
            await messageOverrides.ClickAsync();
            await _commonPage.CheckAllMessageOverrideCheckboxes1Async();
            await Task.Delay(2000);
            page.Dialog += async (_, dialog) =>
            {
                try
                {
                    await dialog.AcceptAsync();
                }
                catch (PlaywrightException ex)
                {
                    Console.WriteLine("Dialog already handled: " + ex.Message);
                    logger.WriteLine("Dialog already handled: " + ex.Message);
                }
            };
            var applyButton = page.Locator("//span[normalize-space()='Apply Override(s)']");
            await applyButton.ClickAsync();
            await Task.Delay(2000);
            await Button.ScrollIntoViewAsync(_commonXpath.Rate_btn, true, 1, "Rate Button");
            await Button.ClickButtonAsync(_commonXpath.Rate_btn, ActionType.Click, true, 1);
            await Task.Delay(3000);
            await Button.ScrollIntoViewAsync(_quoteApplicantPage.FOPage_Save_Btn, true, 1, "Save Button");
            await Task.Delay(19000);
            await Button.ScrollIntoViewAsync(BindPolicyWithGoodville_Button, true, 1, "Bind Policy with Goodville");
            await Task.Delay(18000);
        }
        [When("User Navigates to binding pOlicy and ok Button Verification")]
        public async Task WhenUserNavigatesToBindingPOlicyAndOkButtonVerificationAsync()
        {
            await Task.Delay(19000);
            await Button.ScrollIntoViewAsync(BindPolicyWithGoodville_Button, true, 1, "Bind Policy with Goodville");
            await Task.Delay(18000);
            await Button.ClickButtonAsync(BindPolicyWithGoodville_Button, ActionType.Click, true, 1);
            await Task.Delay(6000);
            await Button.ClickButtonAsync(Ok_Button, ActionType.Click, true, 1);
            await Task.Delay(30000);
            var actualText = await Label.GetTextAsync(PolicyNumber_TextFO, true, 1);
            Console.WriteLine($"Actual UI text: '{actualText}'");
        }

        [When("USer navigates to Ok button for binding")]
        public async Task WhenUSerNavigatesToOkButtonForBindingAsync()
        {
            await Task.Delay(1000);
            await Task.Delay(7000);
            await Button.ClickButtonAsync(_commonXpath.BindPolicywithGoodVilleButton, ActionType.Click, true, 1);
            await Task.Delay(1000);
            await Button.ClickButtonAsync(_commonXpath.BindPolicyOkButton, ActionType.Click, true, 1);
        }
        [When("User Navigates to AddProperty scheduled button")]
        public async Task WhenUserNavigatesToAddPropertyScheduledButtonOldAsync()
        {
            await DropDown.SelectDropDownAsync(AddPersonalprop_scheduled, "Bicycle", true, 1);
            await InputField.SetTextAreaInputFieldAsync(ProprtyInfo_scheduled, "Bicycle", true, 1);
            await InputField.SetTextAreaInputFieldAsync(Limit_Scheduled, "50000", true, 1);
        }
        [When("User Navigates to Claims Farmowner page from json {string}")]
        public async Task WhenUserNavigatesToClaimsFarmownerPageAsync(string jsonFile)
        {
            await _claims_FarmownerPage.ClaimsFarmOwnerPageAsync(jsonFile);
        }
    }
}
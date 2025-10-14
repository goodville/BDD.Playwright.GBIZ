using BDD.Playwright.Origami.Pages.CommonPage;
using Reqnroll;

namespace GoodVille.GBIZ.Reqnroll.Automation.Pages.AgentPages
{
    public class Quote_BusinesscoveragePage : BasePage
    {
        private readonly CommonFunctions _commonFunctions;
        private readonly ScenarioContext _scenarioContext;
        public FeatureContext _featureContext;
        public CommonXpath _commonXpath;
        public LoginPage _loginPage;
        // Constructor
        public Quote_BusinesscoveragePage(ScenarioContext scenarioContext, CommonFunctions commonFunctions, LoginPage loginPage, CommonXpath commonXpath) : base(scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _commonFunctions = commonFunctions;
            _loginPage = loginPage;
            _commonXpath = commonXpath;
        }
        #region Xpath
        /* public string AddBuilding { get; set; } = "//a[text()='Add Building']";
         public string Location_Drp { get; set; } = "//select[@name='bld_location_1' and @id='fld_bld_location_1']";
         public string Description_input { get; set; } = "//input[@id='fld_bld_description_1']";
         public string CheckAllThatAreLocated_Radio { get; set; } = "//input[contains(@id,'cbAPTRENT_fld_bld_businessFunction_1')  and @value='{0}']";

         public string InsuredOwnBuilding_Radio { get; set; } = "//input[contains(@name,'bld_insuredOwnBuilding_1')  and @value='{0}']";
         public string TotalSquareFootage_input { get; set; } = "//input[contains(@id,'fld_bld_totalSquareFootage_1')]";

         public string Constructiontype_Drp { get; set; } = "//select[@name='bld_constructionType_1' and @id='fld_bld_constructionType_1']";


         public string IsthisACondoUnit_Radio { get; set; } = "//input[contains(@name,'bld_condoUnit_1')  and @value='{0}']";
         public string NumberOfStories_input { get; set; } = "//input[contains(@id,'fld_bld_numberOfStories_1')]";

         public string Limit_tab { get; set; } = "//div[@id='buildingLimits_head']";

         public string Continue_btn { get; set; } = "//button[contains(text(),'Continue')]";

         public string Building_input { get; set; } = "//input[contains(@id,'fld_bld_buildingLimit_1')]";

         public string Buildingdeductible_drp { get; set; } = "//select[@name='bld_buildingDeductible_1' and @id='fld_bld_buildingDeductible_1']";

         public string Buildingwindhaildeductible_drp { get; set; } = "//select[@name='bld_whBldDeductible_1' and @id='fld_bld_whBldDeductible_1']";

         public string BuildingpersonalProperty_Limit { get; set; } = "//input[contains(@id,'fld_bld_personalPropertyLimit_1')]";

         public string BuildingpersonalPropertyDeductible_drp { get; set; } = "//select[@name='bld_personalPropertyDeductible_1' and @id='fld_bld_personalPropertyDeductible_1']";
         public string BuildingRating_tab { get; set; } = "//div[@id='buildingRatingInformation_head']";

         public string Doesbuildinghavesprinklers { get; set; } = "//input[contains(@name,'bld_riSprinklers_1')  and @value='{0}']";

         public string bld_riLessThan100Amp_Radio { get; set; } = "//input[contains(@name,'bld_riLessThan100Amp_1')  and @value='{0}']";

         public string heatexist_checkboxlabel { get; set; } = "//input[contains(@name,'cbG_bld_riSourcesOfHeat_1')  and @value='G']";
         public string YearHeatSourceUpdated_input { get; set; } = "//input[contains(@id,'fld_bld_riYearHeatSourceUpdated_1')]";
         public string localPropertyManager_Radio { get; set; } = "//input[contains(@name,'bld_riLocalPropertyManager_1')  and @value='{0}']";
         public string YearOfConstruction_input { get; set; } = "//input[contains(@id,'fld_bld_riYearOfConstruction_1')]";

         public string ValueOfBuildingListed100Percent_Radio { get; set; } = "//input[contains(@name, 'bld_riValueOfBuildingListed100Percent_1')  and @value = '{0}']";

         public string RoofPeaked_Radio { get; set; } = "//input[contains(@name,'bld_riRoofPeaked_1')  and @value='{0}']";

         public string PortionOfRoofMaterial_Radio { get; set; } = "//input[contains(@name,'bld_riPortionOfRoofMaterial_1')  and @value='{0}']";

         public string NearFloodzone_Radio { get; set; } = "//input[contains(@name,'bld_riNearFloodzone_1')  and @value='{0}']";

         public string BuildingIsMobileHome_Radio { get; set; } = "//input[contains(@name,'bld_riBuildingIsMobileHome_1')  and @value='{0}']";
         public string BuildingIsTownHouse_Radio { get; set; } = "//input[contains(@name,'bld_riBuildingIsTownHouse_1')  and @value='{0}']";
         public string ExtendedUnoccupied_Radio { get; set; } = "//input[contains(@name,'bld_riExtendedUnoccupied_1')  and @value='{0}']";
         public string HasAsbestos_Radio { get; set; } = "//input[contains(@name,'bld_riHasAsbestos_1')  and @value='{0}']";

         public string DoorsWindowsGoodRepair_Radio { get; set; } = "//input[contains(@name,'bld_riDoorsWindowsGoodRepair_1')  and @value='{0}']";

         public string OtherOccupanciesOnPremises_Radio { get; set; } = "//input[contains(@name,'bld_riOtherOccupanciesOnPremises_1')  and @value='{0}']";


         public string BuildingTotalSquareFootage_input { get; set; } = "//input[contains(@id,'fld_bld_riTotalSquareFootage_1')]";


         public string WorkingSmokeDetectorsInPlace_Radio { get; set; } = "//input[contains(@name,'bld_riWorkingSmokeDetectorsInPlace_1')  and @value='{0}']";

         public string FireExtinguishersInPlace_Radio { get; set; } = "//input[contains(@name,'bld_riFireExtinguishersInPlace_1')  and @value='{0}']";

         public string SecuritySystem2_Radio { get; set; } = "//input[contains(@name,'bld_riSecuritySystem2_1')  and @value='{0}']";

         public string APTRENTSquareFootage_input { get; set; } = "//input[contains(@id,'fld_bld_riAPTRENTSquareFootage_1')]";

         public string APTRENTOccupiedByInsured_Radio { get; set; } = "//input[contains(@name,'bld_riAPTRENTOccupiedByInsured_1')  and @value='{0}']";

         public string NumberOfUnits_input { get; set; } = "//input[contains(@id,'fld_bld_riNumberOfUnits_1')]";

        1931203

         public string StudentHousing_Radio { get; set; } = "//input[contains(@name,'bld_riStudentHousing_1')  and @value='{0}']";

         public string InsuredIsCondoAssociation_Radio { get; set; } = "//input[contains(@name,'bld_riInsuredIsCondoAssociation_1')  and @value='{0}']";

         public string HeldForSale_Radio { get; set; } = "//input[contains(@name,'bld_riHeldForSale_1')  and @value='{0}']";

         public string LeaseType_drp { get; set; } = "//select[@name='bld_riLeaseType_1' and @id='fld_bld_riLeaseType_1']";
 */
        public string NumberOfOwners_input { get; set; } = "//input[contains(@id,'fld_numberOfOwners')]";
        public string NumberOfFulltime_input { get; set; } = "//input[contains(@id,'fld_numberOfFulltime')]";
        public string NumberOfParttime_input { get; set; } = "//input[contains(@id,'fld_numberOfParttime')]";
        public string CovCyberliab_Radio { get; set; } = "//input[contains(@name,'covCyberliab')  and @value='{0}']";
        public string CovCyberLimit_drp { get; set; } = "//select[@name='covCyberLimit' and @id='fld_covCyberLimit']";

        public string CovCyberClaims_drp { get; set; } = "//input[contains(@name,'covCyberClaims')  and @value='{0}']";
        public string MechancialSystemsBreakdown_Radio { get; set; } = "//input[contains(@name,'mechancialSystemsBreakdown')  and @value='{0}']";
        public string Terrorism_Radio { get; set; } = "//input[contains(@name,'terrorism')  and @value='{0}']";
        public string MedicalPaymentsLimit_drp { get; set; } = "//select[@name='medicalPaymentsLimit' and @id='fld_medicalPaymentsLimit']";
        public string FireLegalLimit_drp { get; set; } = "//select[@name='fireLegalLimit' and @id='fld_fireLegalLimit']";
        public string LiabilityLimit_drp { get; set; } = "//select[@name='liabilityLimit' and @id='fld_liabilityLimit']";

        public string Summary_tab { get; set; } = "//*[@id=\"topTabLinkContainer_7\"]";
        public string Continue_btn { get; set; } = "//button[contains(text(),'Continue')]";

        public string Message_btn { get; set; } = "//div[normalize-space()='Message Overrides']";

        public string Quote_overideR1_btn { get; set; } = "(//div[@id='Quote_Override_r1' and @title='RPA_981']//input[@type='checkbox'])[2]";

        //public string quote_overideR2_btn { get; set; } = "(//div[@id='Quote_Override_r2' and @title='SCR_008']//input[@type='checkbox'])[2]";
        public string Quote_overideR2_btn { get; set; } = "(//div[@id='Quote_Override_r2' and @title='RPA_497']//input[@type='checkbox'])[2]";
        public string Quote_overideR3_btn { get; set; } = "(//div[@id='Quote_Override_r3' and @title='RPA_392']//input[@type='checkbox'])[2]";
        public string Quote_overideR4_btn { get; set; } = "(//div[@id='Quote_Override_r4' and @title='RPA_398']//input[@type='checkbox'])[2]";
        public string Quote_overideR5_btn { get; set; } = "(//div[@id='Quote_Override_r5' and @title='RPA_380']//input[@type='checkbox'])[2]";
        public string Quote_overideR6_btn { get; set; } = "(//div[@id='Quote_Override_r6' and @title='RPA_384']//input[@type='checkbox'])[2]";
        public string Quote_overideR7_btn { get; set; } = "(//div[@id='Quote_Override_r7' and @title='RPA_395']//input[@type='checkbox'])[2]";
        public string Quote_overideR8_btn { get; set; } = "(//div[@id='Quote_Override_r8' and @title='RPA_382']//input[@type='checkbox'])[2]";
        public string Quote_overideR9_btn { get; set; } = "(//div[@id='Quote_Override_r9' and @title='RPA_397']//input[@type='checkbox'])[2]";
        public string Quote_overideR10_btn { get; set; } = "(//div[@id='Quote_Override_r10' and @title='RPA_400']//input[@type='checkbox'])[2]";
        public string Quote_overideR11_btn { get; set; } = "(//div[@id='Quote_Override_r11' and @title='RPA_402']//input[@type='checkbox'])[2]";
        public string Quote_overideR12_btn { get; set; } = "(//div[@id='Quote_Override_r12' and @title='RPA_401']//input[@type='checkbox'])[2]";
        public string Quote_overideR13_btn { get; set; } = "(//div[@id='Quote_Override_r13' and @title='RPA_366']//input[@type='checkbox'])[2]";

        public string Apply_overide_btn { get; set; } = "//span[contains(text(),'Apply Override')]";

        public string Continueclaims_btn { get; set; } = "//button[@id='buttonattributes.id_submitbutton']";

        public string Continueumberlla_btn { get; set; } = "//button[@id='buttonattributes.id_submitbutton']";

         public string Continuesummary2_btn { get; set; } = "(//button[normalize-space()='Continue to Summary'])[1]";

        #endregion
        public async Task BusinesscoverageDatafillAsync()
        {
            commonFunctions.UserWaitForPageToLoadCompletly();
            await Task.Delay(1000); 
            commonFunctions.ReadTestDataForBusinesscoveragePage();

            await InputField.SetTextAreaInputFieldAsync(NumberOfOwners_input, commonFunctions.Business_numberOfOwners_input_LabelAndValue.Item2, true, 1);
            await InputField.SetTextAreaInputFieldAsync(NumberOfFulltime_input, commonFunctions.Business_numberOfFulltime_input_LabelAndValue.Item2, true, 1);
            await InputField.SetTextAreaInputFieldAsync(NumberOfParttime_input, commonFunctions.Business_numberOfParttime_input_LabelAndValue.Item2, true, 1);
            if (commonFunctions.Business_covCyberliab_Radio_LabelAndValue.Item2 != string.Empty)
            {
                if (commonFunctions.Business_covCyberliab_Radio_LabelAndValue.Item2 == "Yes")
                {
                    var covCyberliab_Radio1 = string.Format(CovCyberliab_Radio, commonFunctions.Business_covCyberliab_Radio_LabelAndValue.Item2);
                    await RadioButton.SelectRadioButtonAsync(covCyberliab_Radio1, true, 1);
                }
                else
                {
                    var covCyberliab_Radio1 = string.Format(CovCyberliab_Radio, commonFunctions.Business_covCyberliab_Radio_LabelAndValue.Item2);
                    await RadioButton.SelectRadioButtonAsync(covCyberliab_Radio1, true, 1);
                }
            }

            if (commonFunctions.Business_covCyberLimit_drp_LabelAndValue.Item2 != string.Empty)
            {
               
                    await DropDown.SelectDropDownAsync(CovCyberLimit_drp, commonFunctions.Business_covCyberLimit_drp_LabelAndValue.Item2, true, 1);
                }
            

           

                if (commonFunctions.Business_covCyberClaims_drp_LabelAndValue.Item2 != string.Empty)
            {
                var covCyberClaims_drp1 = string.Format(CovCyberClaims_drp, commonFunctions.Business_covCyberClaims_drp_LabelAndValue.Item2);
                await RadioButton.SelectRadioButtonAsync(covCyberClaims_drp1, true, 1);
            }
            /*else
            {
                string covCyberClaims_drp1 = string.Format(covCyberClaims_drp, commonFunctions.Business_covCyberClaims_drp_LabelAndValue.Item2);
                RadioButton.SelectRadioButton(covCyberClaims_drp1, true, 1);
            }*/
            if (commonFunctions.Business_mechancialSystemsBreakdown_Radio_LabelAndValue.Item2 != string.Empty)
            {
                if (commonFunctions.Business_mechancialSystemsBreakdown_Radio_LabelAndValue.Item2 == "Yes")
                {
                    var mechancialSystemsBreakdown_Radio1 = string.Format(MechancialSystemsBreakdown_Radio, commonFunctions.Business_mechancialSystemsBreakdown_Radio_LabelAndValue.Item2);
                    await RadioButton.SelectRadioButtonAsync(mechancialSystemsBreakdown_Radio1, true, 1);
                }
                else
                {
                    var mechancialSystemsBreakdown_Radio1 = string.Format(MechancialSystemsBreakdown_Radio, commonFunctions.Business_mechancialSystemsBreakdown_Radio_LabelAndValue.Item2);
                    await RadioButton.SelectRadioButtonAsync(mechancialSystemsBreakdown_Radio1, true, 1);
                }
            }

            if (commonFunctions.Business_terrorism_Radio_LabelAndValue.Item2 != string.Empty)
            {
                if (commonFunctions.Business_terrorism_Radio_LabelAndValue.Item2 == "Yes")
                {
                    var terrorism_Radio1 = string.Format(Terrorism_Radio, commonFunctions.Business_terrorism_Radio_LabelAndValue.Item2);
                    await RadioButton.SelectRadioButtonAsync(terrorism_Radio1, true, 1);
                }
                else
                {
                    var terrorism_Radio1 = string.Format(Terrorism_Radio, commonFunctions.Business_terrorism_Radio_LabelAndValue.Item2);
                    await RadioButton.SelectRadioButtonAsync(terrorism_Radio1, true, 1);
                }
            }

            await DropDown.SelectDropDownAsync(MedicalPaymentsLimit_drp, commonFunctions.Business_medicalPaymentsLimit_drp_LabelAndValue.Item2, true, 1);
            await DropDown.SelectDropDownAsync(FireLegalLimit_drp, commonFunctions.Business_fireLegalLimit_drp_LabelAndValue.Item2, true, 1);
            await DropDown.SelectDropDownAsync(LiabilityLimit_drp, commonFunctions.Business_liabilityLimit_drp_LabelAndValue.Item2, true, 1);
            await Task.Delay(1000);
            //commonFunctions.ScrollDown();
            //((IJavaScriptExecutor)Driver).ExecuteScript("document.body.style.zoom='30%';");
            await Task.Delay(1000); // Wait for all elements to settle
            /*commonFunctions.HandleMessageOverridesBCPopup(Driver);
            Thread.Sleep(1000);
            *//*Button.ClickButton(summary_tab, ActionType.Click, true, 1);
            Thread.Sleep(1000);*/
            await Button.ClickButtonAsync(Message_btn, ActionType.Click, true, 1);
            await Task.Delay(500);

            await Checkbox.SelectCheckboxAsync(Quote_overideR1_btn, true, true, 1);
            await Checkbox.SelectCheckboxAsync(Quote_overideR2_btn, true, true, 1);
            await Checkbox.SelectCheckboxAsync(Quote_overideR3_btn, true, true, 1);
            await Checkbox.SelectCheckboxAsync(Quote_overideR4_btn, true, true, 1);
            await Checkbox.SelectCheckboxAsync(Quote_overideR5_btn, true, true, 1);
            await Checkbox.SelectCheckboxAsync(Quote_overideR6_btn, true, true, 1);
            await Checkbox.SelectCheckboxAsync(Quote_overideR7_btn, true, true, 1);
            await Checkbox.SelectCheckboxAsync(Quote_overideR8_btn, true, true, 1);
            await Checkbox.SelectCheckboxAsync(Quote_overideR9_btn, true, true, 1);
            await Checkbox.SelectCheckboxAsync(Quote_overideR10_btn, true, true, 1);
            await Checkbox.SelectCheckboxAsync(Quote_overideR11_btn, true, true, 1);
            await Checkbox.SelectCheckboxAsync(Quote_overideR12_btn, true, true, 1);
            await Checkbox.SelectCheckboxAsync(Quote_overideR13_btn, true, true, 1);

            //Checkbox.SelectCheckbox(quote_overideR14_btn, true, true, 1);
            await Button.ClickButtonAsync(Apply_overide_btn, ActionType.Click, true, 1);

            await Task.Delay(500);
            //((IJavaScriptExecutor)Driver).ExecuteScript("document.body.style.zoom='50%';");
            //*Thread.Sleep(1000)
            commonFunctions.ScrollDown();
            await Task.Delay(1000);
            commonFunctions.ScrollDown();
            await Task.Delay(1000);
            commonFunctions.ScrollDown();
            await Task.Delay(1000);
            commonFunctions.ScrollDown();
            await Task.Delay(1000);
            commonFunctions.ScrollDown();
            await Task.Delay(1000);
            commonFunctions.ScrollDown();
            await Task.Delay(1000);
           /* Button.scroll*/
            await Button.ClickButtonAsync(Continueclaims_btn, ActionType.Click, true, 1);
            await Task.Delay(3000);
            //commonFunctions.UserWaitForPageToLoadCompletly();
            await Button.ClickButtonAsync(Continueumberlla_btn, ActionType.Click, true, 1);
            await Task.Delay(5000);
            await Button.ClickButtonAsync(Continuesummary2_btn, ActionType.Click, true, 1);
            await Task.Delay(3000);

            //commonFunctions.UserWaitForPageToLoadCompletly();

            /*Driver.Manage().Window.Maximize();
            ((IJavaScriptExecutor)Driver).ExecuteScript("document.body.style.zoom='80%';");
            *//*Thread.Sleep(1000)*//*

            Thread.Sleep(1000);
            commonFunctions.ScrollDown();
            Thread.Sleep(1000);




            Button.ClickButton(Continue_btn, ActionType.Click, true, 1);
            *//*commonFunctions.UserWaitForPageToLoadCompletly();*//*
            Thread.Sleep(2000);
            Button.ClickButton(Continue_btn, ActionType.Click, true, 1);
            Thread.Sleep(2000);*/
        }
}
}


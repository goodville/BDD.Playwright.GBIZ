using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BDD.Playwright.GBIZ.Pages.XpathProperties
{
    public class CommonXpath
    {
        #region Login
        public string AgentPortal { get; set; } = "//a[text()='Agent Portal']";
        public string Members { get; set; } = "//a[text()='Members']";
        public string UsernameInp { get; set; } = "//input[contains(@id,'username')]";
        public string PasswordInp { get; set; } = "//input[contains(@id,'password')]";
        public string SignInBtn { get; set; } = "//button[contains(text(),'Sign In')]";
        #endregion

        #region HomePage
        public string AboutUS_Link { get; set; } = "//a[contains(text(),'About Us')]";
        public string Products_Link { get; set; } = "//a[contains(text(),'Products')]";
        public string FindanAgent_Link { get; set; } = "//a[contains(text(),'Find an Agent')]";
        public string MakeaPayment_Link { get; set; } = "//a[contains(text(),'Make a Payment')]";
        public string MakeaPayment_Link_BreadCrumb { get; set; } = "//a[contains(text(),'Make a Payment')]";
        public string MakeaPayment_PolicyTitle { get; set; } = "//*[contains(text(),'Policy Information')]";
        public string MakeaPayment_PolicyInsuredName { get; set; } = "//p[contains(., 'Regression IN Individual Farm')]";
        public string MakeaPayment_PolicyNumber { get; set; } = "//p[contains(text(),' GMQA100032863 ')]";

        //public string MakeaPayment_inputPolicy { get; set; } = "//input[contains(@id,'pcyInput')]";
        //public string MakeaPayment_inputZIP { get; set; } = "//input[contains(@id,'zip')]";
        //public string MakeaPayment_submitBtn { get; set; } = "//button[contains(text(),'Submit')]";

        public string ReportaClaim_Link { get; set; } = "//a[contains(text(),'Report a Claim')]";
        public string HomePage_Link { get; set; } = "//a[contains(text(),'Home')]";
        public string OurBlog_Link { get; set; } = "//a[contains(text(),'Our Blog')]";
        public string Careers_Link { get; set; } = "//a[contains(text(),'Careers')]";
        public string Covid19_Link { get; set; } = "//a[contains(text(),'COVID-19')]";
        public string ContactUs_Link { get; set; } = "//a[contains(text(),'Contact Us')]";
        public string LearnHow_Link { get; set; } = "//a[contains(text(),'Learn How')]";
        public string AMBest_Icon { get; set; } = "//img[@alt='AM Best A Excellent rating']";
        public string Ward50_Icon { get; set; } = "//img[@alt='Wards 50']";
        public string Search_ICON { get; set; } = "//span[contains(@class,'searchWrapper')]";
        public string SearchBlog_Inp { get; set; } = "body > div.masterWrapper > header > div.navWrapper.clearfix > nav > ul > li.search.darkBlue.navSearchToggle.expanded > form > input[type=text]";
        public string Address_Inp { get; set; } = "//input[contains(@name,'address')]";
        public string Search_Button { get; set; } = "//button[contains(text(),'Search')]";
        public string Auto_Icon { get; set; } = "//a[./img[contains(@alt,'Auto')]]";
        public string Home_Icon { get; set; } = "//a[./img[contains(@alt,'Home')]]";
        public string Business_Icon { get; set; } = "//a[./img[contains(@alt,'Business')]]";
        public string Church_Icon { get; set; } = "//a[./img[contains(@alt,'Church')]]";
        public string Farm_Icon { get; set; } = "//a[./img[contains(@alt,'Farm')]]";
        public string Umbrella_Icon { get; set; } = "//a[./img[contains(@alt,'Umbrella')]]";
        public string Auto_LearnMore_Link { get; set; } = "//div[./a[./img[contains(@alt,'Auto')]]]/a[2][contains(text(),'Learn More')]";
        public string Home_LearnMore_Link { get; set; } = "//div[./a[./img[contains(@alt,'Home')]]]/a[2][contains(text(),'Learn More')]";
        public string Business_LearnMore_Link { get; set; } = "//div[./a[./img[contains(@alt,'Business')]]]/a[2][contains(text(),'Learn More')]";
        public string Church_LearnMore_Link { get; set; } = "//div[./a[./img[contains(@alt,'Church')]]]/a[2][contains(text(),'Learn More')]";
        public string Farm_LearnMore_Link { get; set; } = "//div[./a[./img[contains(@alt,'Farm')]]]/a[2][contains(text(),'Learn More')]";
        public string Umbrella_LearnMore_Link { get; set; } = "//div[./a[./img[contains(@alt,'Umbrella')]]]/a[2][contains(text(),'Learn More')]";
        public string PolicyHolderMakeaPayment_Link { get; set; } = "//ul[contains(@class,'linedList')]/li/a[contains(text(),'Make a Payment')]";
        public string PolicyHolderChangePaymentPlan_Link { get; set; } = "//ul[contains(@class,'linedList')]/li/a[contains(text(),'Change Payment Plan')]";
        public string PolicyHolderReportaClaim_Link { get; set; } = "//ul[contains(@class,'linedList')]/li/a[contains(text(),'Report a Claim')]";
        public string PolicyHolderPolicyInformation_Link { get; set; } = "//ul[contains(@class,'linedList')]/li/a[contains(text(),'Policy Information')]";
        public string PolicyHolderGetanIDCard_Link { get; set; } = "//ul[contains(@class,'linedList')]/li/a[contains(text(),'Get an ID Card')]";
        public string NewGMFindanAgent_Link { get; set; } = "//ul[contains(@class,'linedList')]/li/a[contains(text(),'Find an Agent')]";
        public string NewGMWhyDoINeedanAgent_Link { get; set; } = "//ul[contains(@class,'linedList')]/li/a[contains(text(),'Why Do I need an Agent')]";
        public string NewGMAboutGoodVille_Link { get; set; } = "//ul[contains(@class,'linedList')]/li/a[contains(text(),'About Goodville')]";
        public string SeeWhatOthersHaveToSay_Link { get; set; } = "//a[text()='SEE WHAT OTHERS HAVE TO SAY']";
        public string ViewMoreSafetyTips_Link { get; set; } = "//a[text()='View more Safety Tips']";
        public string Proprietorship_RadioButton { get; set; } = "//div[contains(text(),'Sole')]";
        public string VisitUsOnFacebook_Link { get; set; } = "//a[text()='Visit us on Facebook']";
        public string TalkWithUsContactUs_Link { get; set; } = "//div[@class='homePanelFooter container-fluid']//following::a[text()='Contact us']";
        public string FooterAuto_Link { get; set; } = "//gv-footer[@class='footer pageFooter']//following::a[text()='Auto']";
        public string FooterHome_Link { get; set; } = "//gv-footer[@class='footer pageFooter']//following::a[text()='Home']";
        public string FooterBusiness_Link { get; set; } = "//gv-footer[@class='footer pageFooter']//following::a[text()='Business']";
        public string FooterChurch_Link { get; set; } = "//gv-footer[@class='footer pageFooter']//following::a[text()='Church']";
        public string FooterFarm_Link { get; set; } = "//gv-footer[@class='footer pageFooter']//following::a[text()='Farm']";
        public string FooterUmbrella_Link { get; set; } = "//gv-footer[@class='footer pageFooter']//following::a[text()='Umbrella']";
        public string FooterAboutUs_Link { get; set; } = "//gv-footer[@class='footer pageFooter']//following::a[text()='About Us']";
        public string FooterCareers_Link { get; set; } = "//gv-footer[@class='footer pageFooter']//following::a[text()='Careers']";
        public string FooterSafetyTips_Link { get; set; } = "//gv-footer[@class='footer pageFooter']//following::a[text()='Safety Tips']";
        public string FooterFeedback_Link { get; set; } = "//gv-footer[@class='footer pageFooter']//following::a[text()='Feedback']";
        public string FooterTermsConditions_Link { get; set; } = "//gv-footer[@class='footer pageFooter']//following::a[text()='Terms & Conditions']";
        public string FooterPrivacyPolicy_Link { get; set; } = "//gv-footer[@class='footer pageFooter']//following::a[text()='Privacy Policy']";
        public string FooterTransparencyCompliance_Link { get; set; } = "//gv-footer[@class='footer pageFooter']//following::a[text()='Transparency & Compliance']";
        public string FooterFindAnAgent_Link { get; set; } = "//gv-footer[@class='footer pageFooter']//following::a[text()='Find an agent']";
        public string FooterMakeAPayment_Link { get; set; } = "//gv-footer[@class='footer pageFooter']//following::a[text()='Make a payment']";
        public string FooterReportAClaim_Link { get; set; } = "//gv-footer[@class='footer pageFooter']//following::a[text()='Report a claim']";
        public string FooterFacebook_Link { get; set; } = "//gv-footer[@class='footer pageFooter']//following::a[@aria-label='Facebook']";
        public string FooterLinkedin_Link { get; set; } = "//gv-footer[@class='footer pageFooter']//following::a[@aria-label='Linked In']";
        public string FooterMobileApp_Link { get; set; } = "//gv-footer[@class='footer pageFooter']//following::div[@class='mobileAppLink']";
        public string FooterAMBest_Link { get; set; } = "//gv-footer[@class='footer pageFooter']//following::img[@alt='FSR']";
        public string SendSecureEmail_Link { get; set; } = "//a[contains(text(),'SEND SECURE EMAIL')]";

        public string AgentSendSecureEmail_Link { get; set; } = "//*[@id=\"agentads\"]/a[2]";
        public string AboutUs_Link { get; set; } = "//a[@href='/aboutus']";
        public string BecomeAgent_Link { get; set; } = "//a[normalize-space()='BECOME A GOODVILLE AGENT']";
        public string Continue_Button { get; set; } = "//button[contains(text(),'Continue')]";
        //public string ReviewAndApplyContinue_Button { get; set; } = "//div[contains(text(),'Application completed and submitted by')]//following::button[normalize-space()='CONTINUE']";
        public string ReviewAndApplyContinue_Button { get; set; } = "//button[contains(text(),'Apply')]";
        #endregion

        #region Agents
        public string ShadowHost { get; set; } = ".gg-leftnav.hydrated";

        public string ShadowHost2 { get; set; } = "gg-navigation";
        public string ClaimsSidePanelShadow { get; set; } = "div.gg-leftnavlinkgrid > a:nth-child(3)";
        public string SearchSidePanelShadow { get; set; } = "div.gg-leftnavlinkgrid > a[href='/agents/business/search/']";
        public string PolociesAndQuotes_Search_Text { get; set; } = "//div[contains(text(),'Policies & Quotes')]";
        public string PolicySidePanelShadow { get; set; } = "div.sublinks.blue.subnav-search > a[href='/agents/business/policy/']";
        public string QuotingSidePanelShadow { get; set; } = "div.gg-leftnavlinkgrid > a[href='/agents/business/quoting']";
        public string AccountingSidePanelShadow { get; set; } = "div.gg-leftnavlinkgrid > a[href='/agents/accounting/']";
        public string DocumentsPolicyTab { get; set; } = "//a[contains(text(),'DOCUMENTS')]";
        public string EstimatorHistDoc { get; set; } = "//gg-panel-title[contains(text(),'Estimator History')]";
        public string PDFClickDoc { get; set; } = "//td[contains(@class,'gg-cell cdk-cell cdk-column-download gg-column-download ng-tns-c2678191355-8 ng-star-inserted')]//a[contains(@id,'download')]";
        public string DocumentsSidePanelShadow { get; set; } = "div.gg-leftnavlinkgrid > a[href='/agents/business/documents/']";
        public string HomeMainShadow { get; set; } = "a[href='/agents/']";
        public string SignOutShadow { get; set; } = "a[href='/agents/index.cfm?logout=logout']";
        public string CancelButton { get; set; } = "//button[normalize-space(translate(text(), 'abcdefghijklmnopqrstuvwxyz', 'ABCDEFGHIJKLMNOPQRSTUVWXYZ')) = 'CANCEL']";
        public string NewQuoteLink { get; set; } = "//a[normalize-space()='NEW QUOTE']";
        public string PersonalAutoButton { get; set; } = "//button[normalize-space()='Personal Auto']";
        public string CommercialAutoButton { get; set; } = "//button[normalize-space()='Commercial Auto']";
        public string FarmownersButton { get; set; } = "//button[normalize-space()='Farmowners']";
        public string HomeownersButton { get; set; } = "//button[normalize-space()='Homeowners']";
        public string BusinessCoverButton { get; set; } = "//button[normalize-space()='Business Cover']";
        public string PersonalUmbrellaButton { get; set; } = "//button[normalize-space()='Personal Umbrella']";
        public string TradesmanCoverButton { get; set; } = "//button[normalize-space()='Tradesman Cover']";
        public string FarmOwnerButton { get; set; } = "//button[normalize-space()='Farmowners']";
        //public string TradesmanCoverButton { get; set; } = "//button[normalize-space()='Tradesman Cover']";
        public string WorkersCompensationButton { get; set; } = "//button[normalize-space()='Workers Comp']";
        public string MailingPreferences_Link { get; set; } = "//span[normalize-space()='Mailing Preferences']";
        public string AgreementCommercialLinesNewAgent_Input { get; set; } = "//input[@id='agreement_CommercialLines_new_agent']";
        public string AgreementCommercialLinesNewInsured_Input { get; set; } = "//input[@id='agreement_CommercialLines_new_insured']";
        public string CommercialLines_BusinessCover_InsuredRadioButton { get; set; } = "//input[@id='agreement_BusinessCover_new_BC_insured']";
        public string CommercialLines_CommercialUmbrella_AgentRadioButton { get; set; } = "//input[@id='agreement_UmbrellaCommercial_new_UC_agent']";
        public string Link_IIAA { get; set; } = "//a[contains(text(),'IIAA')]";
        public string Link_PIA { get; set; } = "//a[contains(text(),'PIA')]";
        public string Link_AppliedSystyems { get; set; } = "//a[contains(text(),'Applied Systems')]";
        public string Link_ACSnet { get; set; } = "//a[contains(text(),'ASCnet')]";
        public string Link_Doris { get; set; } = "//a[contains(text(),'Doris')]";
        public string Link_Vertafore { get; set; } = "//a[contains(text(),'Vertafore')]";
        public string Link_CPCU { get; set; } = "//a[contains(text(),'CPCU')]";
        public string Link_AmericanInsCPCUIns { get; set; } = "//a[contains(text(),'The American Institute for CPCU and Insurance Institute of America')]";
        public string Link_NationalAlliance { get; set; } = "//a[contains(text(),'The National Alliance for Insurance Education and Research')]";
        public string Link_NationalUWCompany { get; set; } = "//a[contains(text(),'The National Underwriter Company')]";
        public string Link_EZLynx { get; set; } = "//a[contains(text(),'EZLynx')]";
        public string Link_PLRating { get; set; } = "//a[contains(text(),'PL Rating')]";
        public string Link_Quomation { get; set; } = "//a[contains(text(),'Quomation')]";
        public string Link_RoughNotes { get; set; } = "//a[contains(text(),'Rough Notes')]";
        public string Link_NFPA { get; set; } = "//a[contains(text(),'NFPA')]";
        public string Link_NADA { get; set; } = "//a[contains(text(),'NADA')]";
        #endregion

        #region Products Page
        public string Product_Auto_Icon { get; set; } = "//a[contains(@href,'products/auto')]/div";
        public string Product_Home_Icon { get; set; } = "//a[contains(@href,'products/home')]/div";
        public string Product_Business_Icon { get; set; } = "//a[contains(@href,'products/business')]/div";
        public string Product_Church_Icon { get; set; } = "//a[contains(@href,'products/church')]/div";
        public string Product_Farm_Icon { get; set; } = "//a[contains(@href,'products/farm')]/div";
        public string Product_Umbrella_Icon { get; set; } = "//a[contains(@href,'products/umbrella')]/div";
        public string Product_AutoCoverage_Link { get; set; } = "//a[contains(@href,'products/auto') and @class='arrowAfter small blue']";
        public string Product_HomeCoverage_Link { get; set; } = "//a[contains(@href,'products/home') and @class='arrowAfter small blue']";
        public string Product_BusinessCoverage_Link { get; set; } = "//a[contains(@href,'products/business') and @class='arrowAfter small blue']";
        public string Product_ChurchCoverage_Link { get; set; } = "//a[contains(@href,'products/church') and @class='arrowAfter small blue']";
        public string Product_FarmCoverage_Link { get; set; } = "//a[contains(@href,'products/farm') and @class='arrowAfter small blue']";
        public string Product_UmbrellaCoverage_Link { get; set; } = "//a[contains(@href,'products/umbrella') and @class='arrowAfter small blue']";
        public string Product_AutoSafetyTips_Link { get; set; } = "//a[contains(@href,'products/safetytips/auto') and @class='arrowAfter small blue']";
        public string Product_HomeSafetyTips_Link { get; set; } = "//a[contains(@href,'products/safetytips/home') and @class='arrowAfter small blue']";
        public string Product_BusinessSafetyTips_Link { get; set; } = "//a[contains(@href,'products/safetytips/workersComp') and @class='arrowAfter small blue']";
        public string Product_ChurchSafetyTips_Link { get; set; } = "//a[contains(@href,'products/safetytips/church') and @class='arrowAfter small blue']";
        public string Product_FarmSafetyTips_Link { get; set; } = "//a[contains(@href,'products/safetytips/workersComp') and @class='arrowAfter small blue']";
        public string Product_All_LOBAgent_Link { get; set; } = "//a[contains(text(),'agents')]";
        public string Product_All_LOB_ReducingyourPremium { get; set; } = "//a[contains(@href,'products/premiumtips')]";
        public string Product_Home_OtherCoverage_IdentityTheft { get; set; } = "//a[contains(@href,'products/identitytheft')]";

        #region Safety Tips for All LOB
        public string SafetyTip_Home_CandleSafetyTip_Link { get; set; } = "//a[contains(@href,'pdf/CandleSafety')]";
        public string SafetyTip_Home_ChristmasSafetyTip_Link { get; set; } = "//a[contains(@href,'pdf/ChristmasTreeSafety')]";
        public string SafetyTip_Home_DisasterPlanningMakeaPlanReadyGov_Link { get; set; } = "//a[contains(@href,'make-a-plan')]";
        public string SafetyTip_Home_DisasterPlanningMakeaPlanAmericanRedCross_Link { get; set; } = "//a[contains(@href,'emergencies/make-a-plan')]";
        public string SafetyTip_Home_FirePitSafety_Link { get; set; } = "//a[contains(@href,'FirePitSafety')]";
        public string SafetyTip_Home_FireSafetyChildrenNFPA_Link { get; set; } = "//a[contains(@href,'pdf/ChildrenAndFireSafety')]";
        public string SafetyTip_Home_FireSafetyChildrenUSFA_Link { get; set; } = "//a[contains(@href,'home-fires/at-risk-audiences/children')]";
        public string SafetyTip_Home_GrillSafety_Link { get; set; } = "//a[contains(@href,'pdf/Grilling_safety')]";
        public string SafetyTip_Home_WinterHeatingTipFreezeWinter_Link { get; set; } = "//a[contains(@href,'pdf/FreezeWinter')]";
        public string SafetyTip_Home_WinterHeatingTipHeating_Link { get; set; } = "//a[contains(@href,'pdf/Heating_Safety')]";
        public string SafetyTip_Home_WinterHolidaySafety_Link { get; set; } = "//a[contains(@href,'pdf/Winter_Holiday_Safety')]";
        public string SafetyTip_Auto_BoosterSeat_Link { get; set; } = "//a[contains(@href,'child-boosters')]";
        public string SafetyTip_Auto_CellPhoneTextlingLaw_Link { get; set; } = "//a[contains(@href,'cellphone-laws')]";
        public string SafetyTip_Auto_DistractedDriving_Link { get; set; } = "//a[contains(@href,'risky-driving/distracted-driving')]";
        public string SafetyTip_Auto_TeenDrivingNHTSA_Link { get; set; } = "//a[contains(@href,'road-safety/teen-driving')]";
        public string SafetyTip_Auto_TeenDrivingIIHS_Link { get; set; } = "//a[contains(@href,'iihs.org') and contains(text(),'Insurance Institute for Highway Safety')]";
        public string SafetyTip_Auto_TeenDrivingUSDOT_Link { get; set; } = "//a[contains(@href,'transportation.gov')]";
        public string SafetyTip_Auto_TeenDrivingIII_Link { get; set; } = "//a[contains(@href,'iii.org/article')]";
        public string SafetyTip_Auto_TeenDrivingChooseBestVehicle_Link { get; set; } = "//a[contains(@href,'vehicles-for-teens')]";
        public string SafetyTip_Auto_TeenDrivingConsumerReport_Link { get; set; } = "//a[contains(@href,'consumerreports') and contains(text(),'teen')]";
        public string SafetyTip_Auto_DrivingAgreementAAA_Link { get; set; } = "//a[contains(text(),'AAA Parent-Teen Driving Agreement')]";
        public string SafetyTip_Auto_DrivingAgreementTeenDriving_Link { get; set; } = "//a[contains(text(),'TeenDriving.com')]";
        public string SafetyTip_Auto_AdditionalInformation_CDC_Link { get; set; } = "//a[contains(text(),'Motor Vehicle Safety')]";
        public string SafetyTip_Auto_AdditionalInformation_ConsumerReport_Link { get; set; } = "//a[contains(text(),'Guide to Car Safety')]";
        public string SafetyTip_Auto_AdditionalInformation_USDepartment_Link { get; set; } = "//a[contains(text(),'U.S. Department')]";
        public string SafetyTip_Auto_AdditionalInformation_SafetyTipTeen_Link { get; set; } = "//a[contains(text(),'Safety Tips for Teen Drivers')]";
        public string SafetyTip_Auto_VehicleSafetyRating_Link { get; set; } = "//p[contains(text(),'Vehicle safety')]//following::a[contains(@href,'iihs/ratings')]";
        public string SafetyTip_WorkerCompensation_ConstructionSiteSafety_Link { get; set; } = "//a[contains(text(),'Contruction Site Safety Guide')]";
        public string SafetyTip_WorkerCompensation_TopTenConstructionSite_Link { get; set; } = "//a[contains(text(),'Top Ten Construction Safety Tips')]";
        public string SafetyTip_WorkerCompensation_PennStateFarmSafety_Link { get; set; } = "//a[contains(text(),'PennState Extension Farm Safety')]";
        public string SafetyTip_WorkerCompensation_OSHAAgricultural_Link { get; set; } = "//a[contains(@href,'/OSHA3835.pdf')]";
        public string SafetyTip_Church_ChildProtection_childrenJustice_Link { get; set; } = "//a[contains(text(),'Summary of requirements from the Center for Children')]";
        public string SafetyTip_Church_ChildProtection_VolunteerFAQ_Link { get; set; } = "//a[contains(text(),'Volunteer FAQs from the Pennsylvania Department of Human Services')]";
        public string SafetyTip_Church_ChildProtection_MandatoryReporter_Link { get; set; } = "//a[contains(text(),'Mandatory Reporter Training FAQs from the Pennsylvania Family Support Alliance')]";
        public string SafetyTip_Church_CribSafety_FullSize_Link { get; set; } = "//a[contains(text(),'Requirements for Full-Size Cribs')]";
        public string SafetyTip_Church_CribSafety_NonFullSize_Link { get; set; } = "//a[contains(text(),'Requirements for Non-Full-Size Cribs')]";
        public string SafetyTip_Church_CribSafety_CribStandard_Link { get; set; } = "//a[contains(text(),'The New Crib Standard: Questions and Answers')]";
        public string SafetyTip_Church_CribSafety_CribInformation_Link { get; set; } = "//a[contains(text(),'CPSC Crib Information Center')]";
        public string SafetyTip_Church_Cooking_Basic_Link { get; set; } = "//a[contains(text(),'Basics for Food Safety')]";
        public string SafetyTip_Church_Cooking_VolunteerGuide_Link { get; set; } = "//a[contains(text(),'Cooking for Groups: A Volunteer')]";
        public string SafetyTip_Church_15Passenger_Link { get; set; } = "//a[contains(text(),'15-passenger')]";
        public string SafetyTip_Church_PlayGroundSafety_Public_Link { get; set; } = "//a[contains(text(),'Public Playground Safety Checklist from the CPSC')]";
        public string SafetyTip_Church_PlayGroundSafety_Hazard_Link { get; set; } = "//a[contains(text(),'Playground Hazards from Grounds for Play')]";
        public string SafetyTip_Church_ChildYoutProtection_Link { get; set; } = "//a[contains(text(),'Sample Child-Youth Protection Policy')]";
        public string SafetyTip_Church_VolunteerApplication_Link { get; set; } = "//a[contains(text(),'Children/Youth Workers Volunteer Application')]";
        public string SafetyTip_Church_ConsenttoTreat_Link { get; set; } = "//a[contains(text(),'Consent to Treat')]";
        public string SafetyTip_Church_TravelPermission_Link { get; set; } = "//a[contains(text(),'Travel Permission Form')]";
        public string SafetyTip_Church_AccidentorAllegationreporting_Link { get; set; } = "//a[contains(text(),'Accident/Allegation Reporting Form')]";
        public string SafetyTip_Church_CriminalRecord_Link { get; set; } = "//a[contains(text(),'Criminal Record Check')]";
        public string SafetyTip_Church_ReducingRisk_Link { get; set; } = "//a[contains(text(),'Reducing The Risk')]";
        public string SafetyTip_Church_StopItNow_Link { get; set; } = "//a[contains(text(),'Stop it Now!')]";
        public string SafetyTip_Church_DarknessItLight_Link { get; set; } = "//a[contains(text(),'Darkness to Light')]";

        #endregion

        #endregion

        #region About US
        public string Ward50_Link { get; set; } = "//a[contains(text(),'WARD')]";
        public string CompanyHistory_Link { get; set; } = "//a[contains(text(),'COMPANY HISTORY')]";
        public string InsuranceFraud_Link { get; set; } = "//a[contains(text(),'HOW INSURANCE FRAUD AFFECTS YOU')]";
        public string PresidentMessage_Link { get; set; } = "//a[contains(text(),'PRESIDENT')]";
        public string BecomeaGoodvilleAgent_Link { get; set; } = "//a[contains(text(),'BECOME A GOODVILLE AGENT')]";
        public string AnnualReport_Link { get; set; } = "//a[contains(text(),'ANNUAL REPORT')]";
        public string CreditHistory_Link { get; set; } = "//a[contains(text(),'YOUR CREDIT HISTORY AND HOW IT AFFECTS YOUR PREMIUM')]";
        public string AboutUsCareers_Link { get; set; } = "//a[contains(text(),'CAREERS')]";
        public string WardGroup_Link { get; set; } = "//a[contains(text(),'Ward Group')]";
        public string CompanyHistory_AMBest_Link { get; set; } = "//a[contains(text(),'A.M. Best')]";
        public string AnnualReportDownloadPDF_Icon { get; set; } = "//div[@data-tooltip='Download PDF']";
        public string CreditHistoryValidationMessage { get; set; } = "//h1[contains(text(),'Your Credit History and How it Affects Your Premium')]";

        #endregion

        #region Find An Agent
        public string AgentValidation { get; set; } = "//strong[@class='ng-binding']";
        public string NoAgentValidation { get; set; } = "//h3[@class='ng-binding']";
        public string ZipSearch_Inp { get; set; } = "//input[@id='zipSearchField']|//input[contains(@id,'ZipSearch')]";
        public string OfficeContact { get; set; } = "//div[./strong[contains(text(),'Office')]]/span";
        public string ShowMore_Link { get; set; } = "//span[contains(text(),'Show More')]";
        public string ShowLess_Link { get; set; } = "//span[contains(text(),'Show Less')]";
        #endregion

        #region Make a Payment
        public string MakeACHorEFTPayment_Btn { get; set; } = "//button[contains(text(),'Make ACH/EFt Payment')]";
        public string PaymentPolicyNumber_Inp { get; set; } = "//input[contains(@name,'txtPolicyNumber')]";
        public string PaymentPolicyEffectiveDate_Inp { get; set; } = "//input[contains(@name,'txtEffectiveDate')]";
        public string PaymentContinue_Btn { get; set; } = "//input[contains(@name,'btnContinue')]";
        public string PaymentErrorValidation_Text { get; set; } = "//span[@id='lblMessage']";
        #endregion

        #region Report a Claim

        #endregion

        #region Our Blog
        public string PolicyHolderStories_Link { get; set; } = "//a[contains(text(),'POLICYHOLDER STORIES')]";
        public string PolicyHolderMessageValidation { get; set; } = "//h3[contains(text(),'Policyholder Claim Story: Rich in Ohio')]";
        public string BlogArchive2016_Link { get; set; } = "//h2[contains(text(),'2016')]";
        public string BlogArchive2016Oct_Link { get; set; } = "//a[contains(text(),'October') and contains(@href,'2016')]";
        public string BlogArchive2016Oct_Validation { get; set; } = "//h6[contains(text(),'October 19, 2016')]";
        public string BlogPage_Validation { get; set; } = "//li[contains(text(),'Our Blog')]";
        public string BlogPage_NoResult_Validation { get; set; } = "//h3[contains(text(),'There are no results to display.')]";
        #endregion

        #region Contact US
        public string SecureEmail_Link { get; set; } = "//a[contains(text(),'Secure Email')]";
        public string SelectaTopic_Drp { get; set; } = "//select[@ng-model='data.topic']";
        public string Name_Inp { get; set; } = "//input[@ng-model='data.name']";
        public string EmailAddress_Inp { get; set; } = "//input[@ng-model='data.email']";
        public string PhoneNumber_Inp { get; set; } = "//input[@ng-model='data.phone']";
        public string PolicyNumber_Inp { get; set; } = "//input[@ng-model='data.policyNum']";
        public string Message_Inp { get; set; } = "//textarea[@ng-model='data.message']";
        public string ReCaptcha_CheckBox { get; set; } = "//span[@id='recaptcha-anchor']";
        public string Submit_Btn { get; set; } = "//button[contains(text(),'Submit')]";
        public string EmailSentSuccessfulMessage_Validation { get; set; } = "//p[text()='Your message has been sent. You will receive a response to your inquiry as soon as possible.']";
        #endregion

        #region HomePage Policy
        public string RiskAddressGrouping_Link { get; set; } = "//a[./span[contains(text(),'Risk Address Grouping')]]";
        public string ShadowHostTopPanelShadow { get; set; } = ".gg-header.hydrated";
        public string ShadowHostSlidePanelShadow { get; set; } = ".gg-leftnav.hydrated";
        public string ShadowHost_SeeAllLink { get; set; } = "gg-contacts.modacross.modcolumned1";
        public string SeeAll_dOcumentshadow { get; set; } = "a.rightText[href=\"/agents/marketing/employees/\"]";
        public string HomePage_Report_Link { get; set; } = "li.light > a[href='/agents/reports/']";
        public string Report_ClaimPayments_Link { get; set; } = "div.gg-leftnavlinkgrid > a[href*='/agents/business/claims/payment']";
        public string BusinessMainShadow { get; set; } = "a[href='/agents/business/']";
        public string GoodvilleInformationMainShadow { get; set; } = "a[href='/agents/marketing/']";

        public string Report_DailyTransaction_Link { get; set; } = "//div[text()='Daily Transactions']";

        public string Report_PrincipleReport_Link { get; set; } = "div.gg-leftnavlinkgrid > a[href='/agents/reports/principal/']";

        public string Report_PrincipleReport2_Link { get; set; } = "//div[contains(text(),'Principal Reports')]";
        #endregion

        #region RiskAddressGroupingPage
        public string RAGPage_Street_Inp { get; set; } = "//input[@name='address_street']";
        public string RAGPage_StreetLine2_Inp { get; set; } = "//input[@name='address_street_line2']";
        public string RAGPage_City_Inp { get; set; } = "//input[@name='address_city']";
        public string RAGPage_State_Inp { get; set; } = "//input[@name='address_state']";
        public string RAGPage_Zip_Inp { get; set; } = "//input[@name='address_zip']";
        public string RAGPage_PolicyNumber_Inp { get; set; } = "//input[@name='policy_number']";
        public string RAGPage_QuoteNumber_Inp { get; set; } = "//input[@name='quote_number']";
        public string RAGPage_Company_Drp { get; set; } = "//select[@name='company_type']";
        public string RAGPage_Radius_Drp { get; set; } = "//select[@name='radius']";
        public string RAGPage_LookUp_Btn { get; set; } = "//input[@id='lookup_address_button']";
        public string RAGPage_Clear_Btn { get; set; } = "//input[@id='reset_address_search_button']";
        public string AddressSearched_Validation { get; set; } = "//div[contains(text(),'Found Location:')]";

        #endregion

        #region Cross SellPage
        public string CrossSell_Btn { get; set; } = "//button[contains(text(),'Cross Sell')]";
        public string CrossSell_BusinessCover_Btn { get; set; } = "//button[contains(text(),'Business Cover')]";
        public string CrossSell_CommericalAuto_Btn { get; set; } = "//button[contains(text(),'Commercial Auto')]";
        public string CrossSell_DwellingFire_Btn { get; set; } = "//button[contains(text(),'Dwelling Fire')]";
        public string CrossSell_HomeOwners_Btn { get; set; } = "//button[contains(text(),'Homeowners')]";
        public string CrossSell_PersonalAuto_Btn { get; set; } = "//button[contains(text(),'Personal Auto')]";
        public string CrossSell_PersonalUmbrella_Btn { get; set; } = "//button[contains(text(),'Personal Umbrella')]";
        public string CrossSell_TradesmanCover_Btn { get; set; } = "//button[contains(text(),'Tradesman Cover')]";
        public string CrossSell_Cancel_Btn { get; set; } = "//button[contains(text(),'Cancel')]";
        public string Delete_Link { get; set; } = "//a[contains(text(),'delete')]";
        public string BusinessCover_Link { get; set; } = "//a[contains(text(),'Business Cover ')]";
        public string CrossSell_CommercialUmbrella_Btn { get; set; } = "//button[contains(text(),'Commercial Umbrella')]";
        public string CommercialUmbrellaApplicant_Text { get; set; } = "//div[contains(text(),'Commercial Umbrella')]";
        #endregion

        #region PolicyPage
        public string PolicyPage_SearchPolicies_Link { get; set; } = "//a[contains(text(),'Search Policies')]";
        public string PolicyPage_AccountingGuidelines_Link { get; set; } = "//a[contains(text(),'Accounting Guidelines')]";
        public string PolicyPage_AccountingNewLink_Link { get; set; } = "//input[contains(@value,'Accounting ➜ Accounting Guidelines')]";
        public string AccountingSuccessfulOpen_Text { get; set; } = "//div[contains(text(),'Accounting Guidelines')]";
        public string PolicyPage_PaymentOptions_Link { get; set; } = "//a[contains(text(),'Payment Options')]";
        public string PaymentOptionsSuccessful_Text { get; set; } = "//div[contains(text(),'Policies & Quotes')]";
        public string PolicyPage_FAQs_Link { get; set; } = "//a[contains(text(),'FAQs')]";
        public string FAQsSuccessfulOpen_Text { get; set; } = "//h1[contains(text(),'Questions Frequently Asked by Agents')]";
        public string PolicyPage_VisitNewSearch { get; set; } = "//input[contains(@value,'Visit the new Search experience')]";
        #endregion

        #region SearchPoliciesPage
        public string SearchPolicyPage_Keyword_Inp { get; set; } = "//input[@placeholder='Keyword']";
        public string NoRecordFound_Text { get; set; } = "//span[contains(text(),'No Records Returned!')]";
        #endregion

        #region QuotingPage
        public string LineDropDown { get; set; } = "//div[@class='gg-form-field-infix ng-tns-c2841192430-0']";
        public string Quote_FarmOwner { get; set; } = "//span[text()='Farmowners']";
        public string OnlineQuoting_Text { get; set; } = "//div[text()='Online Quoting']";

        public string ShadowHost_Logout { get; set; } = ".gg-header.hydrated";

        //public string SignOutShadow1 { get; set; } = "a[href='/agents/index.cfm?logout=logout']";
        public string SignOutShadow1 { get; set; } = "div.gg-head > a[href='/agents/index.cfm?logout=logout']";

        public string Quote_Homeowners { get; set; } = "//button[normalize-space()='Homeowners']";

        public string Quote_PersonalAuto { get; set; } = "//button[normalize-space()='Personal Auto']";

        //public string ClaimsSidePanelShadow { get; set; } = "div.gg-leftnavlinkgrid > a[href='/agents/business/claims/']";
        public string InfoLMICnsuredCheckbox { get; set; } = "//label[text()='I have informed the insured']";

        public string Quote_Continue_Btn { get; set; } = "//a[normalize-space()='Continue']";
        public string Farmowners_Text { get; set; } = "//div[contains(text(),'Farmowners')]";
        public string Homeowners_Text { get; set; } = "//div[contains(text(),'Homeowners')]";
        public string DwellingFire_Text { get; set; } = "//div[contains(text(),'Dwelling Fire')]";
        public string PersonalAuto_Text { get; set; } = "//div[contains(text(),'Personal Automobile')]";
        public string PersonalAuto_FullText { get; set; } = "//div[@id='formHeaderLeft']";
        public string OnlineQuoting_LineLink { get; set; } = "//gg-select[contains(@id,'gg-select-0')]";
        public string DwellingFire_Link { get; set; } = "//button[contains(text(),'Dwelling Fire')]";
        public string OnlineQuoting_ContinueLink { get; set; } = "//a[contains(text(),'Continue')]";
        public string IHaveInformedInsured { get; set; } = "//label[contains(text(),'I have informed the insured')]";
        public string BusinessCoverQuote { get; set; } = "//button[contains(text(),'Business Cover')]";
        public string HomeOwners_QuoteType { get; set; } = "//select[contains(@id,'fld_quoteType')]";
        public string HomeOwners_QuoteChange_PolicyInput { get; set; } = "//input[contains(@id,'fld_previousPolicyNumber')]";
        public string HomeOwners_PolicyInput_Reload { get; set; } = "//button[contains(text(),'Reload')]";
        public string HomeOwners_PolicyInput_Producer { get; set; } = "//select[contains(@id,'fld_applicant_producer')]";
        public string HomeOwners_PolicyInput_RCCost_Yes { get; set; } = "//input[contains(@id,'fld_yes_useEstimator')]";
        public string HomeOwners_PolicyInput_ContinueToProInfo { get; set; } = "//button[contains(text(),'Continue to Property Info')]";
        public string HomeOwners_PolicyInput_pdfdocdownload { get; set; } = "//a[contains(text(),'E2Value Estimation')]";
        public string HomeOwners_PolicyInput_RCEstTab { get; set; } = "//div[contains(text(),'RC Estimator')]";
        public string HomeOwners_PolicyInput_Edit_ReorderBtn { get; set; } = "//button[contains(text(),'Edit/Reorder Estimate')]";
        public string HomeOwners_PolicyInput_LocDesc { get; set; } = "//select[contains(@id,'fld_descriptionOfLocale')]";
        public string HomeOwners_PolicyInput_ConQuality { get; set; } = "//select[contains(@id,'fld_constructionQuality')]";
        public string HomeOwners_PolicyInput_PriExt { get; set; } = "//select[contains(@id,'fld_primaryExterior')]";
        public string HomeOwners_PolicyInput_PriRoofCov { get; set; } = "//select[contains(@id,'fld_primaryRoofCovering')]";
        public string HomeOwners_PolicyInput_ArcStyle { get; set; } = "//select[contains(@id,'fld_architecturalStyle')]";
        public string HomeOwners_PolicyInput_ConType { get; set; } = "//select[contains(@id,'fld_structureType')]";
        public string HomeOwners_PolicyInput_PhyShape { get; set; } = "//select[contains(@id,'fld_physicalShape')]";
        public string HomeOwners_PolicyInput_LivArea_SqFootArea { get; set; } = "//input[contains(@id,'fld_squareFootage')]";
        public string HomeOwners_PolicyInput_AddOtherArea { get; set; } = "//a[contains(text(),'Add other area')]";
        public string HomeOwners_PolicyInput_OA_AreaType { get; set; } = "//select[contains(@id,'fld_oa_areaType_3')]";
        public string HomeOwners_PolicyInput_OA_SqFtA { get; set; } = "//input[contains(@id,'fld_oa_squareFootage_3')]";
        public string HomeOwners_PolicyInput_OA_SqFtYear { get; set; } = "//input[contains(@id,'fld_oa_yearBuilt_3')]";
        public string HomeOwners_PolicyInput_OrderEstimate { get; set; } = "//button[contains(text(),'Order Estimate')]";
        public string HomeOwners_OA_VarifyText1 { get; set; } = "//div[contains(text(),'balcony')]";
        public string HomeOwners_OA_VarifyText2 { get; set; } = "//div[contains(@class,'clearfix')]//div[contains(text(),'2024')]";
        public string HomeOwners_OA_VarifyText3 { get; set; } = "//div[contains(@class,'clearfix')]//div[contains(text(),'200')]";
        public string HomeOwners_OA_EditReorderEst { get; set; } = "//button[contains(text(),'Edit/Reorder Estimate')]";
        public string HomeOwners_OA_ConsQuality { get; set; } = "//select[contains(@id,'fld_constructionQuality')]";
        public string HomeOwners_DeleteOA { get; set; } = "//div[contains(@id,'otherAreasListHead')]//img[contains(@alt,'x')]";
        public string HomeOwners_OrderEst { get; set; } = "//button[contains(text(),'Order Estimate')]";
        //public string HomeOwners_PolicyInput_RCEstTab { get; set; } = "//div[contains(text(),'RC Estimator')]";

        public string BusinessCover_Text { get; set; } = "//div[contains(text(),'Business Cover')]";

        public string BusinessCover_FullText { get; set; } = "//div[@id='formHeaderLeft']";
        public string Quote_BusinessCover { get; set; } = "//button[normalize-space()='Business Cover']";
        public string Quote_PersonalUmbrella { get; set; } = "//button[contains(text(), 'Personal Umbrella')]";
        public string Quote_PersonalUmbrella_RelTo_Insured { get; set; } = "//select[contains(@id,'fld_ci_relationshipToInsured')]";
        public string Quote_PersonalUmbrella_LstRel { get; set; } = "//input[contains(@id,'fld_ci_relationshipToInsured')]";
        public string Quote_PersonalUmbrella_PolLimit { get; set; } = "//select[contains(@id,'fld_pol_limit')]";
        public string Quote_PersonalUmbrella_Retentikon { get; set; } = "//select[contains(@id,'fld_pol_retention')]";
        public string Quote_PersonalUmbrella_IsThisAlsoMailingAddress { get; set; } = "//input[contains(@id,'fld_yes_sa_isMailingAddress')]";
        public string Quote_PersonalUmbrella_ContinueToUndelyingPolicy { get; set; } = "//button[contains(@id,'buttonid_nextbutton')]";
        public string Quote_PersonalUmbrella_NamedInsFirstName { get; set; } = "//input[contains(@id,'fld_ni_firstName')]";
        public string Quote_PersonalUmbrella_NamedInsLastName { get; set; } = "//input[contains(@id,'fld_ni_lastName')]";
        public string Quote_PersonalUmbrella_NamedInsNamedInsDOB { get; set; } = "//input[contains(@id,'fld_ni_dateOfBirthtext')]";
        public string Quote_PersonalUmbrella_SecondNamedInsFirstName { get; set; } = "//input[contains(@id,'fld_ci_firstName')]";
        public string Quote_PersonalUmbrella_SecondNamedInsLastName { get; set; } = "//input[contains(@id,'fld_ci_lastName')]";
        public string Quote_PersonalUmbrella_SecondNamedInsNamedInsDOB { get; set; } = "//input[contains(@id,'fld_ci_dateOfBirthtext')]";
        public string Quote_PersonalUmbrella_Address { get; set; } = "//input[contains(@id,'fld_sa_address1')]";
        public string Quote_PersonalUmbrella_AddressZIP { get; set; } = "//input[contains(@id,'fld_sa_zip')]";
        public string Quote_PersonalUmbrella_PolicyType { get; set; } = "//select[contains(@id,'fld_upy_policytype_1')]";
        public string Quote_PersonalUmbrella_Company { get; set; } = "//select[contains(@id,'fld_upy_selectCompany_1')]";
        public string Quote_PersonalUmbrella_PolicyNum { get; set; } = "//input[contains(@id,'fld_upy_policynumber_1')]";
        public string Quote_PersonalUmbrella_EffDate { get; set; } = "//input[contains(@id,'fld_upy_effectivedate_1')]";
        public string Quote_PersonalUmbrella_ExpDate { get; set; } = "//input[contains(@id,'fld_upy_expirationDate_1')]";
        public string Quote_HomeOwners_LiabilityLimit { get; set; } = "//select[contains(@id,'fld_upy_homeownersLimit_1')]";
        public string Quote_HomeOwners_ContinueToExposure { get; set; } = "//button[contains(@id,'buttonid_nextbutton')]";
        public string Quote_HomeOwners_Property_Occupancy { get; set; } = "//select[contains(@id,'fld_property_occtype_1')]";
        public string Quote_HomeOwners_Property_StreetAddress { get; set; } = "//input[contains(@id,'fld_loc_streetAddress_1')]";
        public string Quote_HomeOwners_Property_City { get; set; } = "//input[contains(@id,'fld_loc_city_1')]";
        public string Quote_HomeOwners_Property_Zip { get; set; } = "//input[contains(@id,'fld_loc_zipCode_1')]";
        public string Quote_HomeOwners_Property_PrimaryHomeRadio { get; set; } = "//input[contains(@id,'fld_yes_property_units_1')]";
        public string Quote_HomeOwners_Property_AreThereAnyCountryHomeRadio { get; set; } = "//input[contains(@id,'fld_no_property_isFarmExposure_1')]";
        public string Quote_HomeOwners_Property_IsThereASwimmingPoolHomeRadio { get; set; } = "//input[contains(@id,'fld_no_property_isPool_1')]";
        public string Quote_HomeOwners_Property_IsThereATrampolineHomeRadio { get; set; } = "//input[contains(@id,'fld_no_property_trampoline_1')]";
        public string Quote_HomeOwners_Property_AddAnotherVehiclePrimary { get; set; } = "//select[contains(@id,'fld_property_occtype_2')]";
        public string Quote_HomeOwners_Property_AddAnotherStreetAddress { get; set; } = "//input[contains(@id,'fld_loc_streetAddress_2')]";
        public string Quote_HomeOwners_Property_AddAnotherCity { get; set; } = "//input[contains(@id,'fld_loc_city_2')]";
        public string Quote_HomeOwners_Property_AddAnotherZip { get; set; } = "//input[contains(@id,'fld_loc_zipCode_2')]";
        public string Quote_HomeOwners_Property_ClickChevron { get; set; } = "//img[contains(@class,'icon')]";
        public string Quote_HomeOwners_Property_AddAnotherIsThePrimaryHome { get; set; } = "//input[contains(@id,'fld_yes_property_units_2')]";
        public string Quote_HomeOwners_Property_AddAnotherAreThereAnyCountryHome { get; set; } = "//input[contains(@id,'fld_no_property_isFarmExposure_2')]";
        public string Quote_HomeOwners_Property_AddAnotherIsThereAnySwimmingPool { get; set; } = "//input[contains(@id,'fld_no_property_isPool_2')]";
        public string Quote_HomeOwners_Property_AddAnotherIsThereATrampoline { get; set; } = "//input[contains(@id,'fld_yes_property_trampoline_2')]";
        public string Quote_HomeOwners_Property_AddAnotherSafetyEnclosureNet { get; set; } = "//input[contains(@id,'fld_property_trampolineNet_2_1')]";
        public string Quote_HomeOwners_Property_AddAnotherVehiclesSubTabClick { get; set; } = "//div[contains(text(),'Vehicles')]";
        public string Quote_HomeOwners_Property_AddAnotherVehiclesSubTabVehicleType { get; set; } = "//select[contains(@id,'fld_vehicles_type_1')]";
        public string Quote_HomeOwners_Property_AddAnotherVehiclesSubTabYear { get; set; } = "//input[contains(@id,'fld_vehicles_year_1')]";
        public string Quote_HomeOwners_Property_AddAnotherVehiclesSubTabMake { get; set; } = "//input[contains(@id,'fld_vehicles_make_1')]";
        public string Quote_HomeOwners_Property_AddAnotherVehiclesSubTabModal { get; set; } = "//input[contains(@id,'fld_vehicles_model_1')]";
        public string Quote_HomeOwners_Property_AddAnotherVehicleSubTabDrivers { get; set; } = "//div[contains(text(),'Drivers')]";
        public string Quote_HomeOwners_Property_DriverFirstName { get; set; } = "//input[contains(@id,'fld_dr_firstName_1')]";
        public string Quote_HomeOwners_Property_DriverMiddleName { get; set; } = "//input[contains(@id,'fld_dr_middleName_1')]";
        public string Quote_HomeOwners_Property_DriverLastName { get; set; } = "//input[contains(@id,'fld_dr_lastName_1')]";
        public string Quote_HomeOwners_Property_DriverDOB { get; set; } = "//input[contains(@id,'fld_dr_dateOfBirth_1')]";
        public string Quote_HomeOwners_PropertyGender { get; set; } = "//input[contains(@id,'fld_dr_gender_1_1')]";
        public string Quote_HomeOwners_Property_MaritalStatus { get; set; } = "//select[contains(@id,'fld_dr_maritalStatus_1')]";
        public string Quote_HomeOwners_Property_LICState { get; set; } = "//select[contains(@id,'fld_dr_licensedState_1')]";
        public string Quote_HomeOwners_Property_LICNum { get; set; } = "//input[contains(@id,'fld_dr_licenseNumber_1')]";
        public string Quote_HomeOwners_Property_ContinueToSummary { get; set; } = "//button[contains(text(),'Continue to Summary')]";
        public string Quote_HomeOwners_Property_Rate { get; set; } = "//a[contains(@id,'formHeaderLeft_quoteAction_rate')]";
        public string Quote_HomeOwners_Property_Save { get; set; } = "//a[contains(@href,'#')]";
        //public string Quote_PersonalUmbrella_link { get; set; } = "//button[contains(text(),'Homeowners')]";
        //public string Quote_PersonalUmbrella_link_IHaveInformedIns { get; set; } = "//label[contains(text(),'I have informed the insured')]";
        //public string Quote_PersonalUmbrella_link_ContinueClick { get; set; } = "//label[contains(text(),'I have informed the insured')]";
        //public string Quote_PersonalUmbrella_BookOfBusiness { get; set; } = "//input[contains(@id,'fld_bookofbusiness_text')]";
        //button[normalize-space()='Personal Auto']
        public string Quote_PersonalAuto_QuoteButton_Click { get; set; } = "//button[normalize-space()='Personal Auto']";
        public string Quote_PersonalAuto_IHaveInformedInsures_Click { get; set; } = "//label[@for='fld_FCRAAcknowledgement']";
        //public string aaa { get; set; } = "//a[contains(@href,'#')]";
        //public string zzz { get; set; } = "//a[contains(@href,'#')]";
        public string QuoteType_DropDown { get; set; } = "//select[contains(@id,'quoteType')]";
        public string InformedInsured_Checkbox { get; set; } = "//label[@for='fld_FCRAAcknowledgement']";
        public string Producer_DropDown { get; set; } = "//select[@id='fld_prefillProducer']";
        public string FirstName_Input { get; set; } = "//input[@id='fld_prefillFirstName']";
        public string LastName_Input { get; set; } = "//input[@id='fld_prefillLastName']";
        public string Address_Input { get; set; } = "//input[@id='fld_prefillAddress1']";
        public string Zip_Input { get; set; } = "//input[@id='fld_prefillZip']";
        public string InformedApplicantPrefill_Checkbox { get; set; } = "//label[@for='fld_prefillInformed']";
        public string OrderDataPrefill_Button { get; set; } = "//button[contains(text(),'Order Data Prefill')]";
        //public string QuoteType_New_Radio { get; set; } = "//input[@name='quoteType' and @value='New']";
        //public string QuoteDescription_Input { get; set; } = "//input[contains(@id,'quoteDescription')]";
        //public string EffectiveDate_Input { get; set; } = "//input[contains(@id,'effectiveDate')]";
        public string BookOfBusiness_Applicant_Input { get; set; } = "//input[@id='fld_bookofbusiness_text']";
        public string IsQuoteRollover_Yes_Radio { get; set; } = "//input[@name='isQuoteRollover' and @value='Yes']";
        public string IsQuoteRollover_No_Radio { get; set; } = "//input[@name='isQuoteRollover' and @value='No']";
        public string Office_DropDown { get; set; } = "//select[contains(@id,'office')]";
        public string Producer_Applicant_DropDown1 { get; set; } = "//select[@id='fld_applicant_producer']";
        public string NamedInsured_FirstName_Input { get; set; } = "//input[@id='fld_ni_firstName']";
        //public string NamedInsured_MiddleName_Input { get; set; } = "//input[contains(@id,'namedInsuredMiddleName')]";
        public string NamedInsured_LastName_Input { get; set; } = "//input[@id='fld_ni_lastName']";
        // public string NamedInsured_Suffix_DropDown { get; set; } = "//select[contains(@id,'namedInsuredSuffix')]";
        // public string NamedInsured_SSN_Input { get; set; } = "//input[contains(@id,'namedInsuredSSN')]";
        public string NamedInsured_DOB_Input { get; set; } = "//input[@id='fld_ni_dateOfBirthtext']";
        public string SecondNamedInsured_FirstName_Input { get; set; } = "//input[@id='fld_ci_firstName']";
        // public string SecondNamedInsured_MiddleName_Input { get; set; } = "//input[contains(@id,'secondNamedInsuredMiddleName')]";
        public string SecondNamedInsured_LastName_Input { get; set; } = "//input[@id='fld_ci_lastName']";
        //public string SecondNamedInsured_Suffix_DropDown { get; set; } = "//select[contains(@id,'secondNamedInsuredSuffix')]";
        // public string SecondNamedInsured_SSN_Input { get; set; } = "//input[contains(@id,'secondNamedInsuredSSN')]";
        public string SecondNamedInsured_DOB_Input { get; set; } = "//input[@id='fld_ci_dateOfBirthtext']";
        public string RelationshipToInsured_DropDown { get; set; } = "//select[@id='fld_ci_relationshipToInsured']";
        public string StreetAddress_Input { get; set; } = "//input[@id='fld_sa_address1']";
        // public string City_Input { get; set; } = "//input[contains(@id,'city')]";
        // public string State_DropDown { get; set; } = "//select[contains(@id,'state')]";
        public string Zip_Input1 { get; set; } = "//input[@id='fld_sa_zip']";
        //public string County_DropDown { get; set; } = "//select[contains(@id,'county')]";
        public string IsMailingAddress_Yes_Radio { get; set; } = "//input[@id='fld_yes_sa_isMailingAddress']";
        //public string IsMailingAddress_No_Radio { get; set; } = "//input[@name='isMailingAddress' and @value='No']";
        public string YearsAtCurrentResidence_DropDown { get; set; } = "//select[@id='fld_pa_numberyears']";
        //public string TerritoryOverride_Input { get; set; } = "//input[contains(@id,'territoryOverride')]";
        public string PackageDiscount_Yes_Radio { get; set; } = "//select[@id='fld_packageDiscount']";
        // public string Company_DropDown { get; set; } = "//select[contains(@id,'company')]";
        //public string PolicyNumber_Input { get; set; } = "//input[contains(@id,'policyNumber')]";
        // public string ExpirationDate_Input { get; set; } = "//input[contains(@id,'expirationDate')]";
        //public string PriorInsuranceCarrier_DropDown { get; set; } = "//select[contains(@id,'priorInsuranceCarrier')]";
        public string PriorInsuranceCarrierBodilyInjuryPerPerson_Input { get; set; } = "//input[@id='fld_priorCovBIPP']";
        public string PriorInsuranceCarrierBodilyInjuryPerOccurrence_Input { get; set; } = "//input[@id='fld_priorCovBIPO']";
        public string PriorInsuranceCarrierPropertyDamage_Input { get; set; } = "//input[@id='fld_priorCovPD']";
        //public string PriorInsuranceCarrierCombinedSingleLimit_Input { get; set; } = "//input[contains(@id,'priorCombinedSingleLimit')]";
        public string PriorInsuranceCarrierAge_DropDown { get; set; } = "//select[@id='fld_priorCovAge']";
        public string NumberOfYearsContinuousInsurance_DropDown { get; set; } = "//select[@id='fld_numberYearsContinuous']";
        //public string FinancialResponsibilityFiling_Yes_Radio { get; set; } = "//input[@id='fld_no_financialResponsibility'];
        public string FinancialResponsibilityFiling_No_Radio { get; set; } = "//input[@id='fld_no_financialResponsibility']";
        //public string VehicleSharing_Yes_Radio { get; set; } = "//input[@name='vehicleSharing' and @value='Yes']";
        public string VehicleSharing_No_Radio { get; set; } = "//input[@id='fld_no_vehicleSharing']";
        public string ResidenceType_DropDown { get; set; } = "//select[@id='fld_residenceType']";
        //public string ForceMultiCarDiscount_Yes_Radio { get; set; } = "//input[@name='multiCarDiscount' and @value='Yes']";
        //public string ForceMultiCarDiscount_No_Radio { get; set; } = "//input[@name='multiCarDiscount' and @value='No']";
        //public string ForceApplyAdvanceQuoteDiscount_Button { get; set; } = "//button[contains(@id,'applyAdvanceQuoteDiscount')]";
        public string ContinueToDrivers_Button { get; set; } = "//button[@id='buttonid_nextbutton']";

        #endregion

        #region Dailytransactionpage

        public string Allbook_dropdown { get; set; } = "//select[@name=\"book_select\"]";

        public string Allbook_3700 { get; set; } = "//option[@value='3700']";

        public string Allbook { get; set; } = "//option[@value='ALL']";

        public string Allbook_37ZZ { get; set; } = "//option[@value='37ZZ']";
        public string Allbooks_input { get; set; } = "//input[@id='book']";

        public string Allbooks_0704 { get; set; } = "//option[@value='0704']";

        public string Claimstartdate { get; set; } = "//input[@name='startdate']";

        public string Policystartdate { get; set; } = "//input[@name='startdate']";

        public string Policyenddate { get; set; } = "//input[@name='enddate']";

        public string Policynumber { get; set; } = "//input[@id='policynumber']";

        public string Policynumbersearch { get; set; } = "//input[@value='Search']";

        public string Policynumbersuccessmessage { get; set; } = "//div[@id=\"message\"]";

        public string Pdfviewbutton { get; set; } = "//a[@href='/agents/pdf/fetchPDF.cfm?pn=MP0105&type=LPNB&dt=20161107']";

        public string Policytype_all { get; set; } = "//option[@value=\"all\"]/..//ancestor::select[@id='policytype']";

        public string Date_today { get; set; } = "//div[contains(text(),\"Date\")]/ ..//option[@value=\"Today\"]";

        public string Date_Last3months { get; set; } = "//div[contains(text(),'Date')]/ ..//option[@value='Last 3 months']";

        public string Date_DateRange { get; set; } = "//div[contains(text(),'Date')]/ ..//option[@value='Custom']";

        public string TransactionType_policy { get; set; } = "//div[contains(text(),\"Transaction Type\")]/ ..//option[@value=\"policy\"]";
        public string TransactionType_all { get; set; } = "//div[contains(text(),\"Transaction Type\")]/ ..//option[@value=\"all\"]";

        public string FooterPrivacyPolicyDailytransactions_Link { get; set; } = "div.footernav > a[href='/help/privacypolicy/']";

        public string FooterContactus_Link { get; set; } = "div.footernav > a[href='/contactus/']";

        public string FooterTermscondition_Link { get; set; } = "div.footernav > a[href = '/help/terms/']";

        public string Footercopyright_text { get; set; } = ".gg-footer.hydrated > div[part=\'gg-footer-copyright\']";
        public string FooterPrivacyPolicyDailytransactions_Link1 { get; set; } = "//a[@part='gg-footer-link']//div[text()='Privacy Policy']";

        public string ShadowHost_2 { get; set; } = ".gg-footer.hydrated";

        // public string ShadowHost { get; set; } = ".gg-leftnav.hydrated";

        public string AMBest_logo { get; set; } = "//img[@alt=FSR' and @src='/images/fsrLogoWhite.png']";

        #endregion
        #region BusinessCoverPage
        public string Businesscover_Name { get; set; } = "//div[normalize-space(text())='Vijay Qatest']";

        public string Businesscover_Address1 { get; set; } = "//div[normalize-space(text())='41 Commerce St']";

        public string Businesscover_Address1_updated { get; set; } = "//div[normalize-space(text())='9 Mill St']";

        /*public string Businesscover_Address2 { get; set; } = "//div[normalize-space(text())='Harrington, DE 19952-1501']";*/

        public string Businesscover_EffectiveDateText { get; set; } = "//div[normalize-space()='Effective date']";

        public string Businesscover_EffectiveDate { get; set; } = "//div[normalize-space(text())='08/06/2025']";

        public string Businesscover_TerrorismLossLiability { get; set; } = "//div[normalize-space()='$500,000']";

        public string Businesscover_TerrorismLossproperty { get; set; } = "//div[normalize-space()='$ 350,000']";

        public string Businesscover_EmploymentrelatedLiability { get; set; } = "//div[@class='colTwo'][normalize-space()='$ 50,000']";

        public string Businesscover_FireLegalliability { get; set; } = "//div[@class='colTwo'][normalize-space()='$300,000']";

        /*public string BCOrderCredit_btn { get; set; } = "//button[contains(text(),'Order Credit')]";*/

        public string BCTotalPremium { get; set; } = "//div[@id='location_summaryPremium_1']";

        public string Continuetomortage { get; set; } = "//button[@id='buttonid_nextbutton']";

        public string AddMortage { get; set; } = "//div[@class='left iconText']";
        public string ContinueBilling { get; set; } = "//button[@id='buttonid_nextbutton' and contains(text(),'Continue to Billing')]";

        public string BCContinueBilling { get; set; } = "//button[@id='buttonmortgagee_submitbutton']";
        public string Payment_6Pay { get; set; } = "//input[@name='bill_paymentplan' and @value='6']";

        public string Payment_FullPay { get; set; } = "//input[@name='bill_paymentplan' and @value='1']";

        public string Payment_FullPaypremium1 { get; set; } = "//div[@class='paymentplanSubColOne grayBGdark withsvc minpayment'][normalize-space()='$754.00']";

        public string Payment_TotFullPaypremium { get; set; } = "//div[@class='paymentplanColFirst pp_col1']//div[@class='paymentplanSubColOne withsvc payinfull'][normalize-space()='$754.00']";

        public string BC6PayPremium_1 { get; set; } = "//div[@class='paymentplanSubColOne grayBGdark withsvc minpayment'][normalize-space()='$152.00']";
        public string BC6PayPremium_1_1 { get; set; } = "//div[@class='paymentplanSubColOne grayBGdark withsvc minpayment'][normalize-space()='$164.00']";
        public string BC6PayPremium_2 { get; set; } = "//div[@class='paymentplanRow ppRow2']//div[@class='paymentplanSubColOne withsvc'][normalize-space()='$157.00']";

        public string BC6PayPremium_2_2 { get; set; } = "//div[@class='paymentplanRow ppRow2']//div[@class='paymentplanSubColOne withsvc'][normalize-space()='$168.00']";
        public string BC6PayPremium_3 { get; set; } = "//div[@class='paymentplanSubColOne grayBGdark withsvc'][normalize-space()='$156.00']";
        public string BC6PayPremium_3_3 { get; set; } = "//div[@class='paymentplanSubColOne grayBGdark withsvc'][normalize-space()='$168.00']";

        public string BC6PayPremium_4 { get; set; } = "//div[@class='paymentplanRow ppRow4']//div[@class='paymentplanSubColOne withsvc'][normalize-space()='$156.00']";

        public string BC6PayPremium_4_4 { get; set; } = "//div[@class='paymentplanRow ppRow4']//div[@class='paymentplanSubColOne withsvc'][normalize-space()='$168.00']";

        public string BC6PayPremium_5 { get; set; } = "//div[@class='paymentplanSubColOne grayBGdark withsvc'][normalize-space()='$157.00']";

        public string BC6PayPremium_5_5 { get; set; } = "//div[@class='paymentplanSubColOne grayBGdark withsvc'][normalize-space()='$168.00']";

        public string BC6PayPremium_6 { get; set; } = "//div[@class='paymentplanRow ppRow6']//div[@class='paymentplanSubColOne withsvc'][normalize-space()='$156.00']";
        public string BC6PayPremium_6_6 { get; set; } = "//div[@class='paymentplanRow ppRow6']//div[@class='paymentplanSubColOne withsvc'][normalize-space()='$168.00']";
        public string BC6PayTotPremium { get; set; } = "//div[@class='paymentplanRowLast']//div[@class='paymentplanSubColOne withsvc payinfull'][normalize-space()='$934.00']";

        public string BC6PayTotPremium_1 { get; set; } = "//div[@class='paymentplanRowLast']//div[@class='paymentplanSubColOne withsvc payinfull'][normalize-space()='$1,004.00']";
        public string BC6PayTotPremium_80 { get; set; } = "//div[@class='paymentplanRowLast']//div[@class='paymentplanSubColOne withsvc payinfull'][normalize-space()='$914.00']";
        public string ContinueBinding { get; set; } = "//button[@id='buttonid_nextbutton' and contains(text(),'Continue to Binding')]";

        public string BCContinueBinding { get; set; } = "//button[@id='buttonattributes.id_submitbutton']";

        public string PABindPolicy { get; set; } = "//button[@id='buttonid_nextbutton']";
        public string MessageOverRides { get; set; } = "//div[normalize-space()='Message Overrides']";

        //public string BCoverride1 { get; set; } = "//div[@id='manualOverridesDialog']//div[@id='Quote_Override_r1']//input[@name='overrideCodes']";
        public string BCoverride1 { get; set; } = "(//div[@id='Quote_Override_r1' and @title='SCR_458']//input[@type='checkbox'])[2]";

        public string BCoverride1_1 { get; set; } = "(//div[@id='Quote_Override_r1' and @title='RPA_948']//input[@type='checkbox'])[2]";

        public string BCoverride1_2 { get; set; } = "(//div[@id='Quote_Override_r4' and @title='RPA_171']//input[@type='checkbox'])[2]";

        public string BCoverride2 { get; set; } = "//div[@id='manualOverridesDialog']//div[@id='Quote_Override_r2']//input[@name='overrideCodes']";

        public string MessageOverRides1 { get; set; } = "//div[normalize-space()='Message Overrides']";
        public string Save_btn { get; set; } = "//a[@data-action='save' and contains(text(),'save')]";

        public string Bcbind_btn { get; set; } = "//button[@id='buttonbinding_submitbutton']";

        public string BindPolicyOkButton { get; set; } = "//div[@class='ui-dialog-buttonset']//button[@type='button']//span[normalize-space()='OK']";
        public string BC_PolicyNumber { get; set; } = "(//div[@class='formPNtop']//div[@class='tabContainer'])[1]";
        public string BC_SatelliteImages { get; set; } = "//span[contains(text(),'Satellite Images')]";
        public string BC_Proposal { get; set; } = "(//span[contains(text(),'Proposal')])[1]";
        public string BC_RatingLog { get; set; } = "//span[contains(text(),'Rating Log')]";
        public string BC_EvidenceProperty { get; set; } = "//span[contains(text(),'Evidence of Property')]";
        public string BC_DeductibleShopper { get; set; } = "//span[contains(text(),'Deductible Shopper')]";
        public string BC_Application { get; set; } = "//span[contains(text(),'Application')]";
        public string BC_ProposalSummary { get; set; } = "//span[contains(text(),'Proposal Summary')]";
        public string BC_Binder { get; set; } = "//span[contains(text(),'Binder')]";

        #endregion

        //Rahul
        #region Spinner
        public string SpinnerOverlay_Icon { get; set; } = "//div[contains(@class,'overlay-container')]";
        #endregion
        public string Create_Button { get; set; } = "//button[contains(text(),'Create')]";
        public string Close_Button { get; set; } = "//button[contains(text(),'CLOSE')]";
        public string Open_Button { get; set; } = "//button[normalize-space()='Open']";
        public string Remove_Button { get; set; } = "//span[normalize-space()='Remove']";
        public string RemovePaymentMethod_Remove_Button { get; set; } = "//button[normalize-space()='REMOVE']";
        public string SearchPolicyPage_NavigateToPolicyInfo { get; set; } = "//td[normalize-space()='{0}']";

        #region PolicyDetailsPage
        public string PolicyDetailsPage_Billing_Link { get; set; } = "//a[normalize-space()='BILLING']";
        #endregion

        #region Quote_DwellingFire
        public string ContinueSummary { get; set; } = "//button[contains(text(),'Continue to Summary')]";
        public string ContinueClaims { get; set; } = "//button[contains(text(),'Continue to Claims')]";
        public string NextSummary { get; set; } = "//div[@id='bottomsubnav_nextlink']";
        public string DwellingSummary_Name { get; set; } = "//div[normalize-space(text())='Mohan Qtest']";
        public string DwellingSummaryDynamic_Name { get; set; } = "//div[normalize-space(text())='{0}']";

        public string PASummary_Name { get; set; } = "//div[@class='formColTwo'][normalize-space()='Vijay Sample']";
        public string DwellingSummary_Address1 { get; set; } = "//div[normalize-space(text())='41 Commerce St']";
        public string DwellingSummary_Address2 { get; set; } = "//div[normalize-space(text())='Harrington, DE 19952-1501']";
        public string DwellingSummary_EffectiveDateText { get; set; } = "//div[normalize-space(text())='Effective Date']";
        public string DwellingSummary_EffectiveDate { get; set; } = "//div[normalize-space(text())='08/09/2025']";

        public string PASummary_EffectiveDate { get; set; } = "//div[normalize-space(text())='08/06/2025']";
        public string DwellingSummary_CoverageLPremisesLiability { get; set; } = "//div[contains(text(),'$100,000 per occurrence / $200,000 per aggregate')]";
        public string DwellingSummary_CoverageMMedicalPayments { get; set; } = "//div[@class='row']//div[@class='colTwo dollar' and contains(text(), '$2,000')]";
        public string DwellingSummary_AllPerilsDeductible { get; set; } = "//div[@class='row']//div[@class='colTwo dollar' and contains(text(), '$1,000')]";
        public string DwellingSummary_WindOrHailDeductible { get; set; } = "//div[@class='row']//div[@class='colTwo dollar' and contains(text(), '$2,000')]";
        public string OrderCredit_btn { get; set; } = "//button[contains(text(),'Order Credit')]";
        public string TotalPremium { get; set; } = "//div[@class='colFour dollarpc']";

        public string PA_EstimatedPremium { get; set; } = "//div[@class='leftDataHeader' and contains(text(),'Estimated Premium:')]";

        /* public string save_btn { get; set; } = "//a[@data-action='save' and contains(text(),'save')]";*/
        public string Rate_btn { get; set; } = "//a[@data-action='rate' and contains(text(),'rate')]";
        public string Previous_btn { get; set; } = "//div[@id='bottomsubnav_prevlink']";
        public string Next_btn { get; set; } = "//div[@id='bottomsubnav_nextlink']";
        public string ContinueAddInterest { get; set; } = "//div[@id='bottomsubnav_nextlink']";
        /* public string AddMortage { get; set; } = "//div[@class='left iconText']";
         public string ContinueBilling { get; set; } = "//button[@id='buttonid_nextbutton' and contains(text(),'Continue to Billing')]";
         public string Payment_6Pay { get; set; } = "//input[@name='bill_paymentplan' and @value='6']";
         public string ContinueBinding { get; set; } = "//button[@id='buttonid_nextbutton' and contains(text(),'Continue to Binding')]";
         public string MessageOverRides { get; set; } = "//div[normalize-space()='Message Overrides']";*/

        public string ApplyOverRides { get; set; } = "(//div[@class='ui-dialog-buttonset']//button[@type='button']//span[normalize-space()='Apply Override(s)'])[2]";
        public string ApplyOverRide { get; set; } = "(//div[@class='ui-dialog-buttonset']//button[@type='button']//span[normalize-space()='Apply Override(s)'])";
        public string Remarks { get; set; } = "//div[@id='Quote_Override1']//textarea[@name='remarks']";
        public string DF_QuoteOverride1 { get; set; } = "(//div[@id='Quote_Override_r1' and @title='SCR_260']//input[@type='checkbox'])[2]";
        public string DF_QuoteOverride2 { get; set; } = "(//div[@id='Quote_Override_r2' and @title='SCR_005']//input[@type='checkbox'])[2]";
        public string DF_QuoteOverride3 { get; set; } = "(//div[@id='Quote_Override_r3' and @title='RPA_310']//input[@type='checkbox'])[2]";
        public string ApplyOverRides1 { get; set; } = "//button[@type='button']//span[normalize-space()='Apply Override(s)']";

        public string ApplyOverRides2 { get; set; } = "(//span[contains(text(),'Apply Override(s)')])[2]";

        public string ApplyOverRides4 { get; set; } = "//span[normalize-space()='Apply Override(s)']";
        public string ApplyOverRides5 { get; set; } = "(//button[@type='button']//span[normalize-space()='Apply Override(s)'])[3]";

        public string ApplyOverRides3 { get; set; } = "//div[normalize-space()='Message Overrides']";
        public string BindPolicywithGoodVilleButton { get; set; } = "//button[@id='buttonbinding_submitbutton' and contains(text(),'Bind Policy with Goodville')]";
        /*public string BindPolicyOkButton { get; set; } = "//div[@class='ui-dialog-buttonset']//button[@type='button']//span[normalize-space()='OK']";*/
        public string DF_PolicyNumber { get; set; } = "(//div[@class='formPNtop']//div[@class='tabContainer'])[1]";
        public string DF_SatelliteImages { get; set; } = "//span[contains(text(),'Satellite Images')]";
        public string DF_Proposal { get; set; } = "(//span[contains(text(),'Proposal')])[1]";
        public string DF_RatingLog { get; set; } = "//span[contains(text(),'Rating Log')]";
        public string DF_EvidenceProperty { get; set; } = "//span[contains(text(),'Evidence of Property')]";
        public string DF_DeductibleShopper { get; set; } = "//span[contains(text(),'Deductible Shopper')]";
        public string DF_Application { get; set; } = "//span[contains(text(),'Application')]";
        public string DF_ProposalSummary { get; set; } = "//span[contains(text(),'Proposal Summary')]";
        public string DF_Binder { get; set; } = "//span[contains(text(),'Binder')]";
        public string DF_PolicySearch { get; set; } = "//span[normalize-space()='Policies']";
        #endregion

        #region Quote_PA

        public string PA_QuoteOverride1 { get; set; } = "(//div[@id='Quote_Override_r1' and @title='SCR_005']//input[@type='checkbox'])[2]";

        public string PA_BindQuoteOverride1 { get; set; } = "//div[@id='Quote_Override1']//div[@id='Quote_Override_r1']//input[@name='overrideCodes']";

        public string PA_BindQuoteOverride1_1 { get; set; } = "//body[1]/div[6]/div[2]/div[1]/div[1]/input[1]";

        public string PA_BindQuoteOverride2_0 { get; set; } = "(//div[@id='Quote_Override_r1' and @title='ISSUEERR_03']//input[@type='checkbox'])[2]";
        public string PA_BindQuoteOverride2_1 { get; set; } = "(//div[@id='Quote_Override_r3' and @title='RPA_302']//input[@type='checkbox'])[2]";

        public string PA_BindQuoteOverride2_2 { get; set; } = "(//div[@id='Quote_Override_r4' and @title='RPA_302']//input[@type='checkbox'])[2]";

        public string PA_BindQuoteOverride2_3 { get; set; } = "//div[@id='Quote_Override1']//div[@id='Quote_Override_r5']//input[@name='overrideCodes']";

        public string PA_BindQuoteOverride2_4 { get; set; } = "//div[@id='Quote_Override1']//div[@id='Quote_Override_r6']//input[@name='overrideCodes']";

        public string PA_BindQuoteOverride2_5 { get; set; } = "//div[@id='Quote_Override1']//div[@id='Quote_Override_r7']//input[@name='overrideCodes']";
        public string PA_BindQuoteOverride2_6 { get; set; } = "//body/div[6]/div[2]/div[1]/div[6]/input[1]";
        public string PA_BindQuoteOverride2_7 { get; set; } = "//div[@id='Quote_Override1']//div[@id='Quote_Override_r8']//input[@name='overrideCodes']";
        public string PA_BindQuoteOverride2_8 { get; set; } = "//div[@id='Quote_Override1']//div[@id='Quote_Override_r9']//input[@name='overrideCodes']";
        public string PA_BindQuoteOverride2_9 { get; set; } = "//div[@id='Quote_Override1']//div[@id='Quote_Override_r10']//input[@name='overrideCodes']";
        public string PA_BindQuoteOverride2_10 { get; set; } = "//div[@id='Quote_Override1']//div[@id='Quote_Override_r11']//input[@name='overrideCodes']";
        public string PA_BindQuoteOverride2_11 { get; set; } = "//div[@id='Quote_Override1']//div[@id='Quote_Override_r12']//input[@name='overrideCodes']";
        public string PA_BindQuoteOverride2_12 { get; set; } = "//div[@id='Quote_Override1']//div[@id='Quote_Override_r13']//input[@name='overrideCodes']";

        public string PA_BindQuoteOverride1_2 { get; set; } = "//body[1]/div[6]/div[2]/div[1]/div[2]/input[1]";

        public string PA_BindQuoteOverride1_3 { get; set; } = "//body[1]/div[6]/div[2]/div[1]/div[3]/input[1]";
        public string PA_BindQuoteOverride1_4 { get; set; } = "//body[1]/div[6]/div[2]/div[1]/div[4]/input[1]";
        public string PA_BindQuoteOverride1_5 { get; set; } = "//body[1]/div[6]/div[2]/div[1]/div[5]/input[1]";
        public string PA_BindQuoteOverride1_6 { get; set; } = "//body[1]/div[6]/div[2]/div[1]/div[6]/input[1]";
        public string PA_BindQuoteOverride2 { get; set; } = "//div[@id='Quote_Override1']//div[@id='Quote_Override_r2']//input[@name='overrideCodes']";
        public string PA_BindQuoteOverride3 { get; set; } = "//div[@id='Quote_Override1']//div[@id='Quote_Override_r4']//input[@name='overrideCodes']";
        public string PA_BindQuoteOverride4 { get; set; } = "//div[@id='Quote_Override1']//div[@id='Quote_Override_r5']//input[@name='overrideCodes']";
        public string PA_BindQuoteOverride5 { get; set; } = "//div[@id='Quote_Override1']//div[@id='Quote_Override_r6']//input[@name='overrideCodes']";

        public string PA_BindQuoteOverride6 { get; set; } = "//div[@id='Quote_Override1']//div[@id='Quote_Override_r7']//input[@name='overrideCodes']";
        public string PA_BindQuoteOverride7 { get; set; } = "//div[@id='Quote_Override1']//div[@id='Quote_Override_r8']//input[@name='overrideCodes']";
        public string PA_BindQuoteOverride8 { get; set; } = "//div[@id='Quote_Override1']//div[@id='Quote_Override_r9']//input[@name='overrideCodes']";
        public string PA_BindQuoteOverride9 { get; set; } = "//div[@id='Quote_Override1']//div[@id='Quote_Override_r10']//input[@name='overrideCodes']";
        public string PA_BindQuoteOverride10 { get; set; } = "//div[@id='Quote_Override1']//div[@id='Quote_Override_r11']//input[@name='overrideCodes']";

        public string PA_BindQuoteOverride11 { get; set; } = "//div[@id='Quote_Override1']//div[@id='Quote_Override_r12']//input[@name='overrideCodes']";

        public string PA_BindQuoteOverride12 { get; set; } = "//div[@id='Quote_Override1']//div[@id='Quote_Override_r13']//input[@name='overrideCodes']";

        public string PA_QuoteOverride2 { get; set; } = "(//div[@id='Quote_Override_r2' and @title='SCR_831']//input[@type='checkbox'])[2]";
        public string PA_QuoteOverride3 { get; set; } = "(//div[@id='Quote_Override_r3' and @title='RPA_344']//input[@type='checkbox'])[2]";
        public string PA_QuoteOverride4 { get; set; } = "(//div[@id='Quote_Override_r4' and @title='SCR_084']//input[@type='checkbox'])[2]";
        public string PA_QuoteOverride6 { get; set; } = "(//div[@id='Quote_Override_r5' and @title='RPA_023']//input[@type='checkbox'])[2]";
        public string PA_QuoteOverride7 { get; set; } = "(//div[@id='Quote_Override_r6' and @title='SCR_027']//input[@type='checkbox'])[2]";

        public string PA_QuoteOverride8 { get; set; } = "(//div[@id='Quote_Override_r7' and @title='SCR_026']//input[@type='checkbox'])[2]";

        public string PA_QuoteOverride9 { get; set; } = "(//div[@id='Quote_Override_r9' and @title='RPA_280']//input[@type='checkbox'])[2]";

        public string PA_QuoteOverride10 { get; set; } = "(//div[@id='Quote_Override_r10' and @title='SCR_027']//input[@type='checkbox'])[2]";

        public string PA_QuoteOverride11 { get; set; } = "(//div[@id='Quote_Override_r11' and @title='SCR_026']//input[@type='checkbox'])[2]";

        public string PA_QuoteOverrideAlt4 { get; set; } = "(//div[@id='Quote_Override_r4']//input[@type='checkbox'])[1]";
        public string PA_QuoteOverrideAlt6 { get; set; } = "(//div[@id='Quote_Override_r6']//input[@type='checkbox'])[1]";
        public string PA_QuoteOverrideAlt7 { get; set; } = "(//div[@id='Quote_Override_r7']//input[@type='checkbox'])[1]";
        public string PA_QuoteOverrideAlt8 { get; set; } = "(//div[@id='Quote_Override_r8']//input[@type='checkbox'])[1]";
        public string PA_QuoteOverrideAlt9 { get; set; } = "(//div[@id='Quote_Override_r9']//input[@type='checkbox'])[1]";
        public string PA_QuoteOverrideAlt10 { get; set; } = "(//div[@id='Quote_Override_r10']//input[@type='checkbox'])[1]";
        public string PA_QuoteOverrideAlt11 { get; set; } = "(//div[@id='Quote_Override_r11']//input[@type='checkbox'])[1]";
        public string PA_QuoteOverrideRPA171 { get; set; } = "(//div[@id='Quote_Override_r3' and @title='RPA_171']//input[@type='checkbox'])[2]";
        public string PA_QuoteOverrideRPA163 { get; set; } = "(//div[@id='Quote_Override_r4' and @title='RPA_163']//input[@type='checkbox'])[2]";

        public string PAcoverageContinue_btn { get; set; } = "//button[contains(text(),'Continue')]";

        #endregion
        #region DF6Pay
        public string DF6PayPremium_1 { get; set; } = "//div[@class='paymentplanSubColOne grayBGdark withsvc minpayment'][normalize-space()='$54.00']";
        public string DF6PayPremium_2 { get; set; } = "//div[@class='paymentplanRow ppRow2']//div[@class='paymentplanSubColOne withsvc'][normalize-space()='$58.00']";
        public string DF6PayPremium_3 { get; set; } = "(//div[@class='paymentplanSubColOne grayBGdark withsvc'][normalize-space()='$58.00'])[1]";

        public string DF6PayPremium_4 { get; set; } = "//div[@class='paymentplanRow ppRow4']//div[@class='paymentplanSubColOne withsvc'][normalize-space()='$57.00']";

        public string DF6PayPremium_5 { get; set; } = "(//div[@class='paymentplanSubColOne grayBGdark withsvc'][normalize-space()='$58.00'])[2]";

        public string DF6PayPremium_6 { get; set; } = "//div[@class='paymentplanRow ppRow6']//div[@class='paymentplanSubColOne withsvc'][normalize-space()='$58.00']";
        public string DF6PayTotPremium { get; set; } = "//div[@class='paymentplanRowLast']//div[@class='paymentplanSubColOne withsvc payinfull'][normalize-space()='$343.00']";
        #endregion

        #region Quote_DF_Summary1
        public string DFSummary1_Name1 { get; set; } = "//div[normalize-space(text())='Sam Sample']";
        public string DFSummary1_Address1 { get; set; } = "//div[normalize-space()='9 Mill St']";
        public string DFSummary1_Address2 { get; set; } = "//div[normalize-space()='Greenwood, DE 19950-132']";
        public string DFSummary1_EffectiveDateText1 { get; set; } = "//div[normalize-space(text())='Effective Date']";
        //public string DFSummary1_EffectiveDate1 { get; set; } = "//div[normalize-space(text())='08/09/2025']";
        public string DFSummary1_CoverageLPremisesLiability1 { get; set; } = "//div[contains(text(),'$300,000 per occurrence / $600,000 per aggregate')]";
        public string DFSummary1_CoverageMMedicalPayments1 { get; set; } = "//div[@class='row']//div[@class='colTwo dollar' and contains(text(), '$2,000')]";
        public string DFSummary1_AllPerilsDeductible { get; set; } = "//div[@class='row']//div[@class='colTwo dollar' and contains(text(), '$500')]";
        public string DFSummary1_WindOrHailDeductible { get; set; } = "//div[@class='row']//div[@class='colTwo dollar' and contains(text(), '$1,000')]";
        public string DFSummary1_TotalPremium { get; set; } = "//div[@class='colFour dollarpc']";
        #endregion
        #region DF Checkboxes
        public string DF_OverrideCode_Input1 { get; set; } = "(//div[@id='Quote_Override_r1' and @title='RPA_344']//input[@type='checkbox'])[2]";
        public string DF_OverrideCode_Input2 { get; set; } = "(//div[@id='Quote_Override_r2' and @title='SCR_101']//input[@type='checkbox'])[2]";
        public string DF_OverrideCode_Input3 { get; set; } = "(//div[@id='Quote_Override_r3' and @title='SCR_102']//input[@type='checkbox'])[2]";
        public string DF_OverrideCode_Input4 { get; set; } = "//div[@id='Quote_Override1']//div[@id='Quote_Override_r4']//input[@name='overrideCodes']";
        public string DF_OverrideCode_Input5 { get; set; } = "//div[@id='Quote_Override1']//div[@id='Quote_Override_r5']//input[@name='overrideCodes']";
        public string DF_OverrideCode_Input6 { get; set; } = "//div[@id='Quote_Override1']//div[@id='Quote_Override_r6']//input[@name='overrideCodes']";
        public string DF_OverrideCode_Input7 { get; set; } = "//div[@id='Quote_Override1']//div[@id='Quote_Override_r7']//input[@name='overrideCodes']";
        public string DF_OverrideCode_Input8 { get; set; } = "//div[@id='Quote_Override1']//div[@id='Quote_Override_r8']//input[@name='overrideCodes']";
        public string DF_OverrideCode_Input9 { get; set; } = "//div[@id='Quote_Override1']//div[@id='Quote_Override_r9']//input[@name='overrideCodes']";
        public string DF_OverrideCode_Input10 { get; set; } = "(//div[@id='Quote_Override_r4' and @title='SCR_103']//input[@type='checkbox'])[4]";
        public string DF_OverrideCode_Input11 { get; set; } = "(//div[@id='Quote_Override_r10' and @title='RPA_164']//input[@type='checkbox'])[4]";
        #endregion

        #region Quote_DF_Summary2
        public string DFSummary2_Address1 { get; set; } = "//div[normalize-space()='1 Anna Ave']";
        public string DFSummary2_Address2 { get; set; } = "//div[normalize-space()='Bear, DE 19701-131']";
        public string DFSummary2_EffectiveDateText1 { get; set; } = "//div[normalize-space(text())='Effective Date']";
        //public string DFSummary1_EffectiveDate1 { get; set; } = "//div[normalize-space(text())='08/09/2025']";
        public string DFSummary2_CoverageLPremisesLiability1 { get; set; } = "//div[contains(text(),'$500,000 per occurrence / $1,000,000 per aggregate')]";
        public string DFSummary2_CoverageMMedicalPayments1 { get; set; } = "//div[@class='row']//div[@class='colTwo dollar' and contains(text(), '$5,000')]";
        public string DFSummary2_AllPerilsDeductible { get; set; } = "(//div[@class='row']//div[@class='colTwo dollar' and contains(text(), '$1,000')])[2]";
        public string DFSummary2_WindOrHailDeductible { get; set; } = "//div[@class='row']//div[@class='colTwo dollar' and contains(text(), '$2,000')]";
        public string DFSummary2_TotalPremium { get; set; } = "//div[@class='colFour dollarpc']";
        #endregion

        #region Quote_DF_Summary3
        public string DFSummary3_Address1 { get; set; } = "//div[normalize-space()='106 W Douglas St']";
        public string DFSummary3_Address2 { get; set; } = "//div[normalize-space()='Carlock, IL 61725-140']";
        public string DFSummary3_EffectiveDateText1 { get; set; } = "//div[normalize-space(text())='Effective Date']";
        //public string DFSummary1_EffectiveDate1 { get; set; } = "//div[normalize-space(text())='08/09/2025']";
        public string DFSummary3_CoverageLPremisesLiability1 { get; set; } = "//div[contains(text(),'$300,000 per occurrence / $600,000 per aggregate')]";
        public string DFSummary3_CoverageMMedicalPayments1 { get; set; } = "//div[@class='row']//div[@class='colTwo dollar' and contains(text(), '$2,000')]";
        public string DFSummary3_AllPerilsDeductible { get; set; } = "(//div[@class='row']//div[@class='colTwo dollar' and contains(text(), '$500')])";
        public string DFSummary3_WindOrHailDeductible { get; set; } = "//div[@class='row']//div[@class='colTwo dollar' and contains(text(), '$1,000')]";
        public string DFSummary3_TotalPremium { get; set; } = "//div[@class='colFour dollarpc']";
        #endregion

        #region Quote_DF_Summary4
        public string DFSummary4_Address1 { get; set; } = "//div[normalize-space()='719 E North Grand Ave']";
        public string DFSummary4_Address2 { get; set; } = "//div[normalize-space()='Springfield, IL 62702-137']";
        public string DFSummary4_EffectiveDateText1 { get; set; } = "//div[normalize-space(text())='Effective Date']";
        //public string DFSummary1_EffectiveDate1 { get; set; } = "//div[normalize-space(text())='08/09/2025']";
        public string DFSummary4_CoverageLPremisesLiability1 { get; set; } = "//div[contains(text(),'$500,000 per occurrence / $1,000,000 per aggregate')]";
        public string DFSummary4_CoverageMMedicalPayments1 { get; set; } = "//div[@class='row']//div[@class='colTwo dollar' and contains(text(), '$5,000')]";
        public string DFSummary4_AllPerilsDeductible { get; set; } = "(//div[@class='row']//div[@class='colTwo dollar' and contains(text(), '$1,000')])[2]";
        public string DFSummary4_WindOrHailDeductible { get; set; } = "//div[@class='row']//div[@class='colTwo dollar' and contains(text(), '$2,000')]";
        public string DFSummary4_TotalPremium { get; set; } = "//div[@class='colFour dollarpc']";
        #endregion
        #region Quote_DF_Summary5
        public string DFSummary5_Address1 { get; set; } = "//div[normalize-space()='20327 Dean Rd']";
        public string DFSummary5_Address2 { get; set; } = "//div[normalize-space()='Harlan, IN 46743-139']";
        public string DFSummary5_EffectiveDateText1 { get; set; } = "//div[normalize-space(text())='Effective Date']";
        //public string DFSummary1_EffectiveDate1 { get; set; } = "//div[normalize-space(text())='08/09/2025']";
        public string DFSummary5_CoverageLPremisesLiability1 { get; set; } = "//div[contains(text(),'$300,000 per occurrence / $600,000 per aggregate')]";
        public string DFSummary5_CoverageMMedicalPayments1 { get; set; } = "//div[@class='row']//div[@class='colTwo dollar' and contains(text(), '$2,000')]";
        public string DFSummary5_AllPerilsDeductible { get; set; } = "(//div[@class='row']//div[@class='colTwo dollar' and contains(text(), '$500')])";
        public string DFSummary5_WindOrHailDeductible { get; set; } = "//div[@class='row']//div[@class='colTwo dollar' and contains(text(), '$1,000')]";
        public string DFSummary5_TotalPremium { get; set; } = "//div[@class='colFour dollarpc']";
        #endregion

        #region Quote_DF_Summary6
        public string DFSummary6_Address1 { get; set; } = "//div[normalize-space()='921 E 9th St']";
        public string DFSummary6_Address2 { get; set; } = "//div[normalize-space()='Rochester, IN 46975-146']";
        public string DFSummary6_EffectiveDateText1 { get; set; } = "//div[normalize-space(text())='Effective Date']";
        //public string DFSummary1_EffectiveDate1 { get; set; } = "//div[normalize-space(text())='08/09/2025']";
        public string DFSummary6_CoverageLPremisesLiability1 { get; set; } = "//div[contains(text(),'$500,000 per occurrence / $1,000,000 per aggregate')]";
        public string DFSummary6_CoverageMMedicalPayments1 { get; set; } = "//div[@class='row']//div[@class='colTwo dollar' and contains(text(), '$5,000')]";
        public string DFSummary6_AllPerilsDeductible { get; set; } = "(//div[@class='row']//div[@class='colTwo dollar' and contains(text(), '$1,000')])[2]";
        public string DFSummary6_WindOrHailDeductible { get; set; } = "//div[@class='row']//div[@class='colTwo dollar' and contains(text(), '$2,000')]";
        public string DFSummary6_TotalPremium { get; set; } = "//div[@class='colFour dollarpc']";
        #endregion

        #region Quote_DF_Summary7
        public string DFSummary7_Address1 { get; set; } = "//div[normalize-space()='714 N Main St']";
        public string DFSummary7_Address2 { get; set; } = "//div[contains(text(),'Newton, KS')]";
        public string DFSummary7_EffectiveDateText1 { get; set; } = "//div[normalize-space(text())='Effective Date']";
        //public string DFSummary1_EffectiveDate1 { get; set; } = "//div[normalize-space(text())='08/09/2025']";
        public string DFSummary7_CoverageLPremisesLiability1 { get; set; } = "//div[contains(text(),'$300,000 per occurrence / $600,000 per aggregate')]";
        public string DFSummary7_CoverageMMedicalPayments1 { get; set; } = "(//div[@class='row']//div[@class='colTwo dollar' and contains(text(), '$2,000')])[1]";
        public string DFSummary7_AllPerilsDeductible { get; set; } = "(//div[@class='row']//div[@class='colTwo dollar' and contains(text(), '$1,000')])";
        public string DFSummary7_WindOrHailDeductible { get; set; } = "(//div[@class='row']//div[@class='colTwo dollar' and contains(text(), '$2,000')])[2]";
        public string DFSummary7_TotalPremium { get; set; } = "//div[@class='colFour dollarpc']";
        #endregion

        #region Quote_DF_Summary8
        public string DFSummary8_Address1 { get; set; } = "//div[normalize-space()='201 S Main St']";
        public string DFSummary8_Address2 { get; set; } = "//div[normalize-space()='Pratt, KS 67124-101']";
        public string DFSummary8_EffectiveDateText1 { get; set; } = "//div[normalize-space(text())='Effective Date']";
        //public string DFSummary1_EffectiveDate1 { get; set; } = "//div[normalize-space(text())='08/09/2025']";
        public string DFSummary8_CoverageLPremisesLiability1 { get; set; } = "//div[contains(text(),'$500,000 per occurrence / $1,000,000 per aggregate')]";
        public string DFSummary8_CoverageMMedicalPayments1 { get; set; } = "(//div[@class='row']//div[@class='colTwo dollar' and contains(text(), '$5,000')])[1]";
        public string DFSummary8_AllPerilsDeductible { get; set; } = "(//div[@class='row']//div[@class='colTwo dollar' and contains(text(), '$2,500')])";
        public string DFSummary8_WindOrHailDeductible { get; set; } = "(//div[@class='row']//div[@class='colTwo dollar' and contains(text(), '$5,000')])[2]";
        public string DFSummary8_TotalPremium { get; set; } = "//div[@class='colFour dollarpc']";
        #endregion
        #region Quote_DF_Summary9
        public string DFSummary9_Address1 { get; set; } = "//div[normalize-space()='213 S Sandusky Ave']";
        public string DFSummary9_Address2 { get; set; } = "//div[normalize-space()='Upper Sandusky, OH 43351-138']";
        public string DFSummary9_EffectiveDateText1 { get; set; } = "//div[normalize-space(text())='Effective Date']";
        //public string DFSummary1_EffectiveDate1 { get; set; } = "//div[normalize-space(text())='08/09/2025']";
        public string DFSummary9_CoverageLPremisesLiability1 { get; set; } = "//div[contains(text(),'$300,000 per occurrence / $600,000 per aggregate')]";
        public string DFSummary9_CoverageMMedicalPayments1 { get; set; } = "(//div[@class='row']//div[@class='colTwo dollar' and contains(text(), '$2,000')])[1]";
        public string DFSummary9_AllPerilsDeductible { get; set; } = "(//div[@class='row']//div[@class='colTwo dollar' and contains(text(), '$1,000')])";
        public string DFSummary9_WindOrHailDeductible { get; set; } = "(//div[@class='row']//div[@class='colTwo dollar' and contains(text(), '$2,000')])[2]";
        public string DFSummary9_TotalPremium { get; set; } = "//div[@class='colFour dollarpc']";
        #endregion
        #region Quote_DF_Summary10
        public string DFSummary10_Address1 { get; set; } = "//div[normalize-space()='1029 Refugee Rd']";
        public string DFSummary10_Address2 { get; set; } = "//div[normalize-space()='Pickerington, OH 43147-133']";
        public string DFSummary10_EffectiveDateText1 { get; set; } = "//div[normalize-space(text())='Effective Date']";
        //public string DFSummary1_EffectiveDate1 { get; set; } = "//div[normalize-space(text())='08/09/2025']";
        public string DFSummary10_CoverageLPremisesLiability1 { get; set; } = "//div[contains(text(),'$500,000 per occurrence / $1,000,000 per aggregate')]";
        public string DFSummary10_CoverageMMedicalPayments1 { get; set; } = "(//div[@class='row']//div[@class='colTwo dollar' and contains(text(), '$5,000')])[1]";
        public string DFSummary10_AllPerilsDeductible { get; set; } = "(//div[@class='row']//div[@class='colTwo dollar' and contains(text(), '$2,500')])";
        public string DFSummary10_WindOrHailDeductible { get; set; } = "(//div[@class='row']//div[@class='colTwo dollar' and contains(text(), '$5,000')])[2]";
        public string DFSummary10_TotalPremium { get; set; } = "//div[@class='colFour dollarpc']";
        #endregion
        #region Quote_DF_Summary11
        public string DFSummary11_Address12 { get; set; } = "(//div[normalize-space()='305 S Oklahoma'])[1]";
        public string DFSummary11_Address1 { get; set; } = "//div[normalize-space()='2600 Amy Ct']";
        public string DFSummary11_Address2 { get; set; } = "//div[normalize-space()='Oklahoma City, OK 73160-131']";
        public string DFSummary11_Address22 { get; set; } = "//div[normalize-space()='Corn, OK 73024-292']";

        public string DFSummary11_EffectiveDateText1 { get; set; } = "//div[normalize-space(text())='Effective Date']";
        //public string DFSummary1_EffectiveDate1 { get; set; } = "//div[normalize-space(text())='08/09/2025']";
        public string DFSummary11_CoverageLPremisesLiability1 { get; set; } = "//div[contains(text(),'$500,000 per occurrence / $1,000,000 per aggregate')]";
        public string DFSummary11_CoverageMMedicalPayments1 { get; set; } = "(//div[@class='row']//div[@class='colTwo dollar' and contains(text(), '$5,000')])[1]";
        public string DFSummary11_AllPerilsDeductible { get; set; } = "(//div[@class='row']//div[@class='colTwo dollar' and contains(text(), '$2,500')])";
        public string DFSummary11_WindOrHailDeductible { get; set; } = "(//div[@class='row']//div[@class='colTwo dollar' and contains(text(), 'Not Applicable')])";
        public string DFSummary11_TotalPremium { get; set; } = "//div[@class='colFour dollarpc']";
        #endregion
        #region Quote_DF_Summary12
        public string DFSummary12_Address1 { get; set; } = "//div[normalize-space()='625 W Main St']";
        public string DFSummary12_Address2 { get; set; } = "//div[normalize-space()='New Holland, PA 17557-132']";
        public string DFSummary12_EffectiveDateText1 { get; set; } = "//div[normalize-space(text())='Effective Date']";
        //public string DFSummary1_EffectiveDate1 { get; set; } = "//div[normalize-space(text())='08/09/2025']";
        public string DFSummary12_CoverageLPremisesLiability1 { get; set; } = "//div[contains(text(),'$300,000 per occurrence / $600,000 per aggregate')]";
        public string DFSummary12_CoverageMMedicalPayments1 { get; set; } = "(//div[@class='row']//div[@class='colTwo dollar' and contains(text(), '$2,000')])[1]";
        public string DFSummary12_AllPerilsDeductible { get; set; } = "(//div[@class='row']//div[@class='colTwo dollar' and contains(text(), '$500')])";
        public string DFSummary12_WindOrHailDeductible { get; set; } = "(//div[@class='row']//div[@class='colTwo dollar' and contains(text(), '$1,000')])";
        public string DFSummary12_TotalPremium { get; set; } = "//div[@class='colFour dollarpc']";
        #endregion

        #region Quote_DF_Summary13
        public string DFSummary13_Address1 { get; set; } = "//div[normalize-space()='3223 Sr 119']";
        public string DFSummary13_Address2 { get; set; } = "//div[normalize-space()='New Alexandria, PA 15670-142']";
        public string DFSummary13_EffectiveDateText1 { get; set; } = "//div[normalize-space(text())='Effective Date']";
        //public string DFSummary1_EffectiveDate1 { get; set; } = "//div[normalize-space(text())='08/09/2025']";
        public string DFSummary13_CoverageLPremisesLiability1 { get; set; } = "//div[contains(text(),'$500,000 per occurrence / $1,000,000 per aggregate')]";
        public string DFSummary13_CoverageMMedicalPayments1 { get; set; } = "(//div[@class='row']//div[@class='colTwo dollar' and contains(text(), '$5,000')])[1]";
        public string DFSummary13_AllPerilsDeductible { get; set; } = "(//div[@class='row']//div[@class='colTwo dollar' and contains(text(), '$1,000')])[2]";
        public string DFSummary13_AllPerilsDeductible1 { get; set; } = "(//div[@class='row']//div[@class='colTwo dollar' and contains(text(), '$1,000')])";
        public string DFSummary13_WindOrHailDeductible1 { get; set; } = "(//div[@class='row']//div[@class='colTwo dollar' and contains(text(), '$2,000')])[2]";
        public string DFSummary13_WindOrHailDeductible { get; set; } = "(//div[@class='row']//div[@class='colTwo dollar' and contains(text(), '$2,000')])";
        public string DFSummary13_TotalPremium { get; set; } = "//div[@class='colFour dollarpc']";
        #endregion

        #region Quote_DF_Summary14
        public string DFSummary14_Address1 { get; set; } = "//div[normalize-space()='1291 S Boston Rd']";
        public string DFSummary14_Address2 { get; set; } = "//div[normalize-space()='Danville, VA 24540-105']";
        public string DFSummary14_EffectiveDateText1 { get; set; } = "//div[normalize-space(text())='Effective Date']";
        //public string DFSummary1_EffectiveDate1 { get; set; } = "//div[normalize-space(text())='08/09/2025']";
        public string DFSummary14_CoverageLPremisesLiability1 { get; set; } = "//div[contains(text(),'$300,000 per occurrence / $600,000 per aggregate')]";
        public string DFSummary14_CoverageMMedicalPayments1 { get; set; } = "(//div[@class='row']//div[@class='colTwo dollar' and contains(text(), '$2,000')])[1]";
        public string DFSummary14_AllPerilsDeductible { get; set; } = "(//div[@class='row']//div[@class='colTwo dollar' and contains(text(), '$500')])";
        public string DFSummary14_WindOrHailDeductible { get; set; } = "(//div[@class='row']//div[@class='colTwo dollar' and contains(text(), '$1,000')])";
        public string DFSummary14_TotalPremium { get; set; } = "//div[@class='colFour dollarpc']";
        #endregion
        #region Quote_DF_Summary15
        public string DFSummary15_Address1 { get; set; } = "//div[normalize-space()='2485 Stuarts Draft Hwy']";
        public string DFSummary15_Address2 { get; set; } = "//div[normalize-space()='Stuarts Draft, VA 24477-141']";
        public string DFSummary15_EffectiveDateText1 { get; set; } = "//div[normalize-space(text())='Effective Date']";
        //public string DFSummary1_EffectiveDate1 { get; set; } = "//div[normalize-space(text())='08/09/2025']";
        public string DFSummary15_CoverageLPremisesLiability1 { get; set; } = "//div[contains(text(),'$500,000 per occurrence / $1,000,000 per aggregate')]";
        public string DFSummary15_CoverageMMedicalPayments1 { get; set; } = "(//div[@class='row']//div[@class='colTwo dollar' and contains(text(), '$5,000')])[1]";
        public string DFSummary15_AllPerilsDeductible { get; set; } = "(//div[@class='row']//div[@class='colTwo dollar' and contains(text(), '$1,000')])[2]";
        public string DFSummary15_WindOrHailDeductible { get; set; } = "(//div[@class='row']//div[@class='colTwo dollar' and contains(text(), '$2,000')])";
        public string DFSummary15_TotalPremium { get; set; } = "//div[@class='colFour dollarpc']";
        #endregion
        #region Quote_HomeOwner Summary OverRide Checkbox
        public string HO_OverrideCheckbox1 { get; set; } = " //div[@id='Quote_Override1']//div[@id='Quote_Override_r1']//input[@name='overrideCodes']";
        public string HO_OverrideCheckbox2 { get; set; } = " //div[@id='Quote_Override1']//div[@id='Quote_Override_r3']//input[@name='overrideCodes']";
        public string HO_OverrideCheckbox3 { get; set; } = "//div[@id='Quote_Override1']//div[@id='Quote_Override_r4']//input[@name='overrideCodes']";
        public string HO_OverrideCheckbox4 { get; set; } = "//div[@id='Quote_Override1']//div[@id='Quote_Override_r5']//input[@name='overrideCodes']";
        public string HO_OverrideCheckbox5 { get; set; } = "//div[@id='Quote_Override1']//div[@id='Quote_Override_r6']//input[@name='overrideCodes']";
        public string HO_OverrideCheckbox6 { get; set; } = "//div[@id='Quote_Override1']//div[@id='Quote_Override_r7']//input[@name='overrideCodes']";
        public string HO_OverrideCheckbox7 { get; set; } = "//div[@id='Quote_Override1']//div[@id='Quote_Override_r8']//input[@name='overrideCodes']";
        #endregion
        #region Quote_HomeOwnerSummaryApplicant
        public string HO_ApplicantName { get; set; } = "//div[@class='questionBlockOne']//div[2]//div[2]";
        public string HO_EffectievDate { get; set; } = "//div[@class='questionBlockOne']//div[3]//div[2]";
        public string HO_AllPerilsDeductible { get; set; } = "//div[normalize-space()='$1,000.00']";
        public string HO_WindHailDeductible { get; set; } = "//div[normalize-space()='$2,000.00']";
        public string HO_MailingAddress { get; set; } = "//div[@class='questionBlockOne']//div[@class='formColTwo'][contains(text(),'625 W Main St')]";
        public string HO_PropertyAddress { get; set; } = "//div[@class='questionBlockTwo']//div[@class='formColTwo'][contains(text(),'625 W Main St')]";
        public string HO_YearofConstruction { get; set; } = "//div[normalize-space()='2000']";
        public string HO_Protection { get; set; } = "//div[normalize-space()='Protected A']";
        public string HO_ConstructionType { get; set; } = "//div[normalize-space()='Frame']";
        public string HO_ResidenceType { get; set; } = "//div[normalize-space()='Dwelling']";
        public string HO_OccupancyType { get; set; } = "//div[normalize-space()='Primary']";
        public string HO_NumberofFamilies { get; set; } = "//div[normalize-space()='1']";
        #endregion
        #region Quote_HomeOwnerSummaryCoverages
        public string HO_Dwelling_Amount { get; set; } = "//div[normalize-space()='$ 200,000']";
        public string HO_Dwelling_Amount1 { get; set; } = "//div[normalize-space()='$ 10,000']";
        public string HO_Dwelling_Amount2 { get; set; } = "//div[normalize-space()='$ 60,000']";
        public string HO_RelatedPrivateStructures_Amount { get; set; } = "//div[normalize-space()='$ 20,000']";
        public string HO_PersonalProperty_Amount { get; set; } = "//div[normalize-space()='$ 150,000']";
        public string HO_PersonalProperty_Amount1 { get; set; } = "//div[normalize-space()='$ 100,000']";

        public string HO_AdditionalLivingCosts { get; set; } = "//div[normalize-space()='Unlimited']";
        public string HO_Dwelling_Label { get; set; } = "//div[normalize-space()='A. Dwelling']";
        public string HO_RelatedPrivateStructures_Label { get; set; } = "//div[normalize-space()='B. Related Private Structures']";
        public string HO_PersonalProperty_Label { get; set; } = "//div[normalize-space()='C. Personal Property']";
        public string HO_AdditionalLivingCosts_LossOfRents_Label { get; set; } = "//div[normalize-space()='D. Additional Living Costs & Loss of Rents']";
        public string HO_HomeCoverExtraEndorsement_Amount { get; set; } = "//div[normalize-space()='$ 45']";
        public string HO_ProtectiveDevices_Amount { get; set; } = "//div[normalize-space()='$ -12']";
        public string HO_HomeCoverExtraEndorsement_Label { get; set; } = "//div[normalize-space()='Home Cover Extra Endorsement']";
        public string HO_ProtectiveDevices_Label { get; set; } = "//div[normalize-space()='Protective Devices']";
        public string HO_EstimatedPremium { get; set; } = "//div[@class='leftDataHeader' and contains(text(),'Estimated Premium:')]";
        public string Rate1_btn { get; set; } = "//a[@id='formHeaderLeft_quoteAction_rate']";
        public string Save1_btn { get; set; } = "//a[normalize-space()='save']";

        public string HOQuoteOverride1 { get; set; } = "(//div[@id='Quote_Override1']//div[@id='Quote_Override_r1']//input[@name='overrideCodes'])[2]";
        public string HOQuoteOverride2 { get; set; } = "(//div[@id='Quote_Override1']//div[@id='Quote_Override_r3']//input[@name='overrideCodes'])[2]";
        public string HOQuoteOverride3 { get; set; } = "(//div[@id='Quote_Override1']//div[@id='Quote_Override_r4']//input[@name='overrideCodes'])[2]";
        public string HOQuoteOverride4 { get; set; } = "(//div[@id='Quote_Override1']//div[@id='Quote_Override_r5']//input[@name='overrideCodes'])[2]";

        public string HO_QuoteOver1 { get; set; } = "(//div[@id='Quote_Override_r1' and @title='SCR_005']//input[@type='checkbox'])[2]";
        public string HO_QuoteOver2 { get; set; } = "(//div[@id='Quote_Override_r3' and @title='SCR_103']//input[@type='checkbox'])[2]";
        public string HO_QuoteOver3 { get; set; } = "(//div[@id='Quote_Override_r4' and @title='RPA_310']//input[@type='checkbox'])[2]";
        public string HO_QuoteOver4 { get; set; } = "(//div[@id='Quote_Override_r5' and @title='SCR_164']//input[@type='checkbox'])[2]";

        //New One
        public string HO_MessageOver2 { get; set; } = "(//div[@id='Quote_Override_r2' and @title='SCR_017']//input[@type='checkbox'])[2]";
        public string HO_MessageOver3 { get; set; } = "(//div[@id='Quote_Override_r4' and @title='SCR_103']//input[@type='checkbox'])[2]";
        public string HO_MessageOver4 { get; set; } = "(//div[@id='Quote_Override_r5' and @title='RPA_310']//input[@type='checkbox'])[2]";
        public string HO_MessageOver5 { get; set; } = "(//div[@id='Quote_Override_r6' and @title='SCR_164']//input[@type='checkbox'])[2]";

        //New One
        public string HO_MOver3 { get; set; } = "(//div[@id='Quote_Override_r3' and @title='RPA_932']//input[@type='checkbox'])[2]";
        public string HO_MOver4 { get; set; } = "(//div[@id='Quote_Override_r5' and @title='SCR_103']//input[@type='checkbox'])[2]";
        public string HO_MOver5 { get; set; } = "(//div[@id='Quote_Override_r6' and @title='RPA_310']//input[@type='checkbox'])[2]";
        public string HO_MOver6 { get; set; } = "(//div[@id='Quote_Override_r7' and @title='SCR_164']//input[@type='checkbox'])[2]";

        #endregion

        #region Quote_HomeOwnerBilling
        public string HO6PayPremium_1 { get; set; } = "//div[@class='paymentplanSubColOne grayBGdark withsvc minpayment'][normalize-space()='$109.00']";
        public string HO6PayPremium_2 { get; set; } = "//div[@class='paymentplanRow ppRow2']//div[@class='paymentplanSubColOne withsvc'][normalize-space()='$113.00']";
        public string HO6PayPremium_3 { get; set; } = "(//div[@class='paymentplanSubColOne grayBGdark withsvc'][normalize-space()='$114.00'])[1]";
        public string HO6PayPremium_4 { get; set; } = "//div[@class='paymentplanRow ppRow4']//div[@class='paymentplanSubColOne withsvc'][normalize-space()='$113.00']";
        public string HO6PayPremium_5 { get; set; } = "(//div[@class='paymentplanSubColOne grayBGdark withsvc'][normalize-space()='$113.00'])";
        public string HO6PayPremium_6 { get; set; } = "//div[@class='paymentplanRow ppRow6']//div[@class='paymentplanSubColOne withsvc'][normalize-space()='$113.00']";
        public string HO6TotalPremium { get; set; } = "//div[@class='paymentplanRowLast']//div[@class='paymentplanSubColOne withsvc payinfull'][normalize-space()='$675.00']";
        public string HOsave_btn { get; set; } = "//a[normalize-space()='save']";
        public string HO_PolicyNumber { get; set; } = "//div[@class='applicationID']";
        #endregion

        #region Quote_HO_Claims_Checkbox
        public string HO_ClaimsCheckbox1 { get; set; } = "(//div[@id='Quote_Override_r1' and @title='SCR_260']//input[@type='checkbox'])[2]";
        public string HO_ClaimsCheckbox2 { get; set; } = "(//div[@id='Quote_Override_r2' and @title='SCR_005']//input[@type='checkbox'])[2]";
        public string HO_ClaimsCheckbox3 { get; set; } = "(//div[@id='Quote_Override_r4' and @title='SCR_103']//input[@type='checkbox'])[2]";
        public string HO_ClaimsCheckbox4 { get; set; } = "(//div[@id='Quote_Override_r5' and @title='RPA_310']//input[@type='checkbox'])[2]";
        public string HO_ClaimsCheckbox5 { get; set; } = "(//div[@id='Quote_Override_r6' and @title='SCR_164']//input[@type='checkbox'])[2]";
        public string HO_ClaimsCheckbox6 { get; set; } = "(//div[@id='Quote_Override_r3' and @title='RPA_170']//input[@type='checkbox'])[2]";
        public string HO_ClaimsDeductible { get; set; } = "(//div[@id='Quote_Override_r3' and @title='SCR_818']//input[@type='checkbox'])[2]";
        public string HO_YearCheckBox { get; set; } = "(//div[@id='Quote_Override_r5' and @title='SCR_103']//input[@type='checkbox'])[2]";
        public string HO_HeaterCheckBox { get; set; } = "(//div[@id='Quote_Override_r6' and @title='RPA_310']//input[@type='checkbox'])[2]";
        public string HO_ScheduledCheckBox { get; set; } = "(//div[@id='Quote_Override_r7' and @title='SCR_164']//input[@type='checkbox'])[2]";

        #endregion

        #region Quote_HomeOwnerSummaryApplicant1
        public string HO_ApplicantName1 { get; set; } = "//div[@class='questionBlockOne']//div[2]//div[2]";
        public string HO_EffectievDate1 { get; set; } = "//div[@class='questionBlockOne']//div[3]//div[2]";
        public string HO_AllPerilsDeductible1 { get; set; } = "(//div[@class='questionBlockOne']//div[@class='formColTwo'])[3]";
        public string HO_WindHailDeductible1 { get; set; } = "(//div[@class='questionBlockOne']//div[@class='formColTwo'])[4]";
        public string HO_MailingAddress1 { get; set; } = "(//div[@class='questionBlockOne']//div[@class='formColTwo'])[6]";
        public string HO_MailingAddress2 { get; set; } = "(//div[@class='questionBlockOne']//div[@class='formColTwo'])[5]";

        public string HO_PropertyAddress1 { get; set; } = "(//div[@class='questionBlockTwo']//div[@class='formColTwo'])[1]";
        public string HO_YearofConstruction1 { get; set; } = "//div[normalize-space()='2000']";
        public string HO_Protection1 { get; set; } = "//div[normalize-space()='Protected A']";
        public string HO_ConstructionType1 { get; set; } = "//div[normalize-space()='Frame']";
        public string HO_ResidenceType1 { get; set; } = "//div[normalize-space()='Dwelling']";
        public string HO_OccupancyType1 { get; set; } = "//div[normalize-space()='Primary']";
        public string HO_NumberofFamilies1 { get; set; } = "//div[normalize-space()='1']";
        public string HO_ProtectiveDevices_Amount1 { get; set; } = "//div[normalize-space()='$ -14']";
        public string HO_MailingAddres1 { get; set; } = "(//div[@class='questionBlockOne']//div[@class='formColTwo'])[5]";
        public string HO_Protection2 { get; set; } = "//div[normalize-space()='Partially Protected']";
        public string HO_ProtectiveDevice_Amount1 { get; set; } = "//div[normalize-space()='$ -37']";
        #endregion

        #region Quote_HomeOwnerBilling1
        public string HO6PayPremium1 { get; set; } = "(//div[@class='paymentplanSubColOne grayBGdark withsvc minpayment'])[4]";
        public string HO6PayPremium2 { get; set; } = "(//div[@class='paymentplanRow ppRow2']//div[@class='paymentplanSubColOne withsvc'])[4]";
        public string HO6PayPremium3 { get; set; } = "(//div[@class='paymentplanRow grayBGdark ppRow3']//div[@class='paymentplanSubColOne grayBGdark withsvc'])[2]";
        public string HO6PayPremium4 { get; set; } = "(//div[@class='paymentplanRow ppRow4']//div[@class='paymentplanSubColOne withsvc'])[4]";
        public string HO6PayPremium5 { get; set; } = "(//div[@class='paymentplanRow grayBGdark ppRow5']//div[@class='paymentplanSubColOne grayBGdark withsvc'])[1]";
        public string HO6PayPremium6 { get; set; } = "(//div[@class='paymentplanRow ppRow6']//div[@class='paymentplanSubColOne withsvc'])[4]";
        public string HO6TotalPremium1 { get; set; } = "(//div[@class='paymentplanRowLast']//div[@class='paymentplanSubColOne withsvc payinfull'])[4]";
        public string ApplicantEffectievDate { get; set; } = "//div[@class='questionContainerFirst']//div[3]//div[2]";
        #endregion

        #region Quote_HomeOwnerSummary1
        public string HO_SummaryDwelling_Amount { get; set; } = "//div[normalize-space()='$ 60,000']";
        public string HO_SummarylProperty_Amount { get; set; } = "//div[normalize-space()='$ 100,000']";
        public string HO_SummaryProtectiveDevices_Amount1 { get; set; } = "//div[normalize-space()='$ -11']";
        public string HO_SummaryCoverExtraEndorsement_Amount { get; set; } = "//div[normalize-space()='$ 25']";
        #endregion

        #region QuoteBinding
        public string Message_btn { get; set; } = "//div[normalize-space()='Message Overrides']";
        public string Apply_Override_btn { get; set; } = "//span[contains(text(),'Apply Override')]";
        #endregion

        public class NumberExtractor
        {
            public static string GetFirstNumber(string input)
            {
                // Match the first sequence of digits (optionally with commas and decimals)
                var match = Regex.Match(input, @"\d[\d,\.]*");

                return match.Success ? match.Value : null;
            }
        }
    }
}

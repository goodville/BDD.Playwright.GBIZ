using BDD.Playwright.GBIZ.PageElements;
using BDD.Playwright.GBIZ.Pages.CommonPage;
using BDD.Playwright.GBIZ.Pages.XpathProperties;
using Microsoft.Playwright;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDD.Playwright.Test.StepDefinitions.Public_StepDefinition
{
    [Binding]
    public class TC10_StepDefinition : BasePage
    {
        private readonly ScenarioContext _scenarioContext;
        public CommonXpath _commonXpath;
        public TC10_StepDefinition(ScenarioContext scenarioContext, CommonXpath commonXpath) : base(scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _commonXpath = commonXpath;
        }

        [When(@"User Click on the Products and Verify the Title and clicks on Home Coverage Link and Verify the Agent,Identity and Tips for reducing your premium Link")]
        public async Task WhenUserClickontheProductsandVerifytheTitleandClickonHomepageCoverageLinkandVerifytheAgentandIdentityandTipsforReducingyourPremiumLinkAsync()
        {
            await TextLink.ClickTextLinkAsync(_commonXpath.Products_Link, true, 1);
            await TextLink.ClickTextLinkAsync(_commonXpath.Product_Home_Icon, true, 1);
            var Product_Home_Title = await page.TitleAsync();
            if (Product_Home_Title == "Goodville Mutual Casualty Company - Homeowners")
            {
                logger.WriteLine("Product Home page Title is Goodville Mutual Casualty Company - Homeowners");
            }
            else
            {
                throw new Exception("Product Home page Title is not Matching it is displaying " + Product_Home_Title);
            }

            await Product_FindAnAgentAsync();
            await DriverBackAsync();
            await TextLink.ClickTextLinkAsync(_commonXpath.Product_Home_OtherCoverage_IdentityTheft, true, 1);
            var Product_HomeIdentityTheft_Title = await page.TitleAsync();
            if (Product_HomeIdentityTheft_Title == "Goodville Mutual Casualty Company - Identity Theft")
            {
                logger.WriteLine("Product Home Identity Theft Page Title is Goodville Mutual Casualty Company - Identity Theft");
            }
            else
            {
                throw new Exception("Product Home Identity Theft page Title is not Matching it is displaying " + Product_HomeIdentityTheft_Title);
            }

            await DriverBackAsync();
            await ReducingPremiumAsync();
            await TextLink.ClickTextLinkAsync(_commonXpath.Products_Link, true, 1);
        }

        [When(@"User Clicks on the Home Safety Tips Link and Verify the title and all links in that page")]
        public async Task WhenUserClicksontheHomeSafetyTipsLinkandVerifytheTitleandAllLinksinthatPageAsync()
        {
            await TextLink.ClickTextLinkAsync(_commonXpath.Products_Link, true, 1);
            await PageTitleVerifyMethodAsync(_commonXpath.Product_HomeSafetyTips_Link, "Goodville Mutual Casualty Company - Safety Tips | Home");
            await NextPageTitleVerifyMethodAsync(_commonXpath.SafetyTip_Home_DisasterPlanningMakeaPlanReadyGov_Link, "Make A Plan | Ready.gov");
            await NextPageTitleVerifyMethodAsync(_commonXpath.SafetyTip_Home_DisasterPlanningMakeaPlanAmericanRedCross_Link, "Disaster Preparedness Plan | Make a Plan | Red Cross");
            await NextPageTitleVerifyMethodAsync(_commonXpath.SafetyTip_Home_FirePitSafety_Link, "Grilling and Fire Pit Safety");
            await NextPageTitleVerifyMethodAsync(_commonXpath.SafetyTip_Home_FireSafetyChildrenUSFA_Link, "Fire Safety for Children");
            await TestingAsync(_commonXpath.SafetyTip_Home_CandleSafetyTip_Link);
            await TestingAsync(_commonXpath.SafetyTip_Home_ChristmasSafetyTip_Link);
            await TestingAsync(_commonXpath.SafetyTip_Home_FireSafetyChildrenNFPA_Link);
            await TestingAsync(_commonXpath.SafetyTip_Home_GrillSafety_Link);
            await TestingAsync(_commonXpath.SafetyTip_Home_WinterHeatingTipFreezeWinter_Link);
            await TestingAsync(_commonXpath.SafetyTip_Home_WinterHeatingTipHeating_Link);
            await TestingAsync(_commonXpath.SafetyTip_Home_WinterHolidaySafety_Link);
            await TextLink.ClickTextLinkAsync(_commonXpath.Products_Link, true, 1);
        }

        [When(@"User Clicks on the Auto Coverage Link and Verify the Title and Verify the agent,Reducing Premium Link")]
        public async Task WhenUserClickontheAutoCoverageLinkandVerifytehTitleandVerifytheAgentandReducingPremiumLinkAsync()
        {
            await PageTitleVerifyMethodAsync(_commonXpath.Product_AutoCoverage_Link, "Goodville Mutual Casualty Company - Auto");
            await Product_FindAnAgentAsync();
            await DriverBackAsync();
            await ReducingPremiumAsync();
            await TextLink.ClickTextLinkAsync(_commonXpath.Products_Link, true, 1);
        }

        [When(@"User Clicks on the Auto Safety Tips Link and Verify the title and all links in that page")]
        public async Task WhenUserClicksontheAutoSafetyTipsLinkandVerifytheTitleandAllLinksinthatPageAsync()
        {
            await PageTitleVerifyMethodAsync(_commonXpath.Product_AutoSafetyTips_Link, "Goodville Mutual Casualty Company - Safety Tips | Auto");
            await NextPageTitleVerifyMethodAsync(_commonXpath.SafetyTip_Auto_BoosterSeat_Link, "Booster ratings");
            //NextPageTitleVerifyMethod(_commonXpath.SafetyTip_Auto_CellPhoneTextlingLaw_Link, "Distracted driving");
            await NextPageTitleVerifyMethodAsync(_commonXpath.SafetyTip_Auto_DistractedDriving_Link, "Distracted Driving Dangers and Statistics | NHTSA");
            await NextPageTitleVerifyMethodAsync(_commonXpath.SafetyTip_Auto_TeenDrivingNHTSA_Link, "Teen Safe Driving: How Teens Can Be Safer Drivers | NHTSA");
            await NextPageTitleVerifyMethodAsync(_commonXpath.SafetyTip_Auto_TeenDrivingIIHS_Link, "IIHS-HLDI");
            await NextPageTitleVerifyMethodAsync(_commonXpath.SafetyTip_Auto_TeenDrivingUSDOT_Link, "Department of Transportation");
            await NextPageTitleVerifyMethodAsync(_commonXpath.SafetyTip_Auto_TeenDrivingIII_Link, "Background On: Teen drivers | III");
            await NextPageTitleVerifyMethodAsync(_commonXpath.SafetyTip_Auto_TeenDrivingChooseBestVehicle_Link, "Safe vehicles for teens");
            await NextPageTitleVerifyMethodAsync(_commonXpath.SafetyTip_Auto_TeenDrivingConsumerReport_Link, "How to Choose a Good, Safe Car for Your New Teen Driver - Consumer Reports News");
            await NextPageTitleVerifyMethodAsync(_commonXpath.SafetyTip_Auto_DrivingAgreementAAA_Link, "404 Not Found");
            await NextPageTitleVerifyMethodAsync(_commonXpath.SafetyTip_Auto_DrivingAgreementTeenDriving_Link, "Tips for Parents – teendriving.com");
            await NextPageTitleVerifyMethodAsync(_commonXpath.SafetyTip_Auto_AdditionalInformation_CDC_Link, "Page Not Found | CDC");
            await NextPageTitleVerifyMethodAsync(_commonXpath.SafetyTip_Auto_AdditionalInformation_ConsumerReport_Link, "Car Safety Guide - Consumer Reports");
            await NextPageTitleVerifyMethodAsync(_commonXpath.SafetyTip_Auto_AdditionalInformation_SafetyTipTeen_Link, "Goodville Mutual Casualty Company - Blog");
            await NextPageTitleVerifyMethodAsync(_commonXpath.SafetyTip_Auto_AdditionalInformation_USDepartment_Link, "Department of Transportation");
            await NextPageTitleVerifyMethodAsync(_commonXpath.SafetyTip_Auto_VehicleSafetyRating_Link, "Vehicle ratings");
            await TextLink.ClickTextLinkAsync(_commonXpath.Products_Link, true, 1);
        }

        [When(@"User Clicks on the Business Coverage Link and Verify the Title and Verify the agent,Reducing Premium Link")]
        public async Task WhenUserClickontheBusinessCoverageLinkandVerifytehTitleandVerifytheAgentandReducingPremiumLinkAsync()
        {
            await PageTitleVerifyMethodAsync(_commonXpath.Product_BusinessCoverage_Link, "Goodville Mutual Casualty Company - Business");
            await Product_FindAnAgentAsync();
            await DriverBackAsync();
            await ReducingPremiumAsync();
            await TextLink.ClickTextLinkAsync(_commonXpath.Products_Link, true, 1);
        }

        [When(@"User Clicks on the Business Safety Tips Link and Verify the title and all links in that page")]
        public async Task WhenUserClicksontheBusinessSafetyTipsLinkandVerifytheTitleandAllLinksinthatPageAsync()
        {
            await PageTitleVerifyMethodAsync(_commonXpath.Product_BusinessSafetyTips_Link, "Goodville Mutual Casualty Company - Safety Tips | Wokers Compensation");
            await NextPageTitleVerifyMethodAsync(_commonXpath.SafetyTip_WorkerCompensation_ConstructionSiteSafety_Link, "Construction Site Safety Guide");
            await NextPageTitleVerifyMethodAsync(_commonXpath.SafetyTip_WorkerCompensation_PennStateFarmSafety_Link, "Farm Safety and Agricultural Health | Penn State Extension");
            await NextPageTitleVerifyMethodAsync(_commonXpath.SafetyTip_WorkerCompensation_TopTenConstructionSite_Link, "Top Ten Construction Safety Tips | For Construction Pros");
            await TestingAsync(_commonXpath.SafetyTip_WorkerCompensation_OSHAAgricultural_Link);
            await TextLink.ClickTextLinkAsync(_commonXpath.Products_Link, true, 1);
        }

        [When(@"User Clicks on the Church Coverage Link and Verify the Title and Verify the agent,Reducing Premium Link")]
        public async Task WhenUserClickontheChurchCoverageLinkandVerifytehTitleandVerifytheAgentandReducingPremiumLinkAsync()
        {
            await PageTitleVerifyMethodAsync(_commonXpath.Product_ChurchCoverage_Link, "Goodville Mutual Casualty Company - Church");
            await Product_FindAnAgentAsync();
            await DriverBackAsync();
            await ReducingPremiumAsync();
            await TextLink.ClickTextLinkAsync(_commonXpath.Products_Link, true, 1);
        }

        [When(@"User Clicks on the Church Safety Tips Link and Verify the title and all links in that page")]
        public async Task WhenUserClicksontheChurchSafetyTipsLinkandVerifytheTitleandAllLinksinthatPageAsync()
        {
            await PageTitleVerifyMethodAsync(_commonXpath.Product_ChurchSafetyTips_Link, "Goodville Mutual Casualty Company - Safety Tips | Church");
            //NextPageTitleVerifyMethod(_commonXpath.SafetyTip_Church_ChildProtection_MandatoryReporter_Link, "Frequently Asked Questions | Pennsylvania Family Support Alliance");
            await NextPageTitleVerifyMethodAsync(_commonXpath.SafetyTip_Church_CribSafety_FullSize_Link, "Full-Size Baby Cribs | CPSC.gov");
            await NextPageTitleVerifyMethodAsync(_commonXpath.SafetyTip_Church_CribSafety_NonFullSize_Link, "Non-full-size Baby Cribs Business Guidance | CPSC.gov");
            await NextPageTitleVerifyMethodAsync(_commonXpath.SafetyTip_Church_CribSafety_CribStandard_Link, "OnSafety – The New Crib Standard: Questions and Answers");
            await NextPageTitleVerifyMethodAsync(_commonXpath.SafetyTip_Church_CribSafety_CribInformation_Link, "Safe Sleep – Cribs and Infant Products | CPSC.gov");
            await NextPageTitleVerifyMethodAsync(_commonXpath.SafetyTip_Church_Cooking_Basic_Link, "Food Safety Basics | Food Safety and Inspection Service");
            await NextPageTitleVerifyMethodAsync(_commonXpath.SafetyTip_Church_Cooking_VolunteerGuide_Link, "Cooking for Groups: A Volunteer's Guide to Food Safety | Food Safety and Inspection Service");
            await NextPageTitleVerifyMethodAsync(_commonXpath.SafetyTip_Church_15Passenger_Link, "15-Passenger Vans | NHTSA");
            await NextPageTitleVerifyMethodAsync(_commonXpath.SafetyTip_Church_PlayGroundSafety_Public_Link, "Public Playground Safety Checklist | CPSC.gov");
            await NextPageTitleVerifyMethodAsync(_commonXpath.SafetyTip_Church_StopItNow_Link, "Stop It Now | Stop It Now");
            await NextPageTitleVerifyMethodAsync(_commonXpath.SafetyTip_Church_ReducingRisk_Link, "Reducing the Risk | Church Law & Tax");
            await NextPageTitleVerifyMethodAsync(_commonXpath.SafetyTip_Church_DarknessItLight_Link, "Home - Darkness to Light");
            await TestingAsync(_commonXpath.SafetyTip_Church_ChildProtection_childrenJustice_Link);
            await TestingAsync(_commonXpath.SafetyTip_Church_ChildProtection_VolunteerFAQ_Link);
            await TestingAsync(_commonXpath.SafetyTip_Church_ChildYoutProtection_Link);
            await TestingAsync(_commonXpath.SafetyTip_Church_VolunteerApplication_Link);
            await TestingAsync(_commonXpath.SafetyTip_Church_ConsenttoTreat_Link);
            await TestingAsync(_commonXpath.SafetyTip_Church_CriminalRecord_Link);
            await TestingAsync(_commonXpath.SafetyTip_Church_AccidentorAllegationreporting_Link);
            await TestingAsync(_commonXpath.SafetyTip_Church_TravelPermission_Link);
            await TestingAsync(_commonXpath.SafetyTip_Church_PlayGroundSafety_Hazard_Link);
            await TextLink.ClickTextLinkAsync(_commonXpath.Products_Link, true, 1);
        }

        [When(@"User Clicks on the Farm Coverage Link and Verify the Title and Verify the agent,Reducing Premium Link")]
        public async Task WhenUserClickontheFarmCoverageLinkandVerifytehTitleandVerifytheAgentandReducingPremiumLinkAsync()
        {
            await PageTitleVerifyMethodAsync(_commonXpath.Product_FarmCoverage_Link, "Goodville Mutual Casualty Company - Farm");
            await Product_FindAnAgentAsync();
            await DriverBackAsync();
            await ReducingPremiumAsync();
            await TextLink.ClickTextLinkAsync(_commonXpath.Products_Link, true, 1);
        }

        [When(@"User Clicks on the Farm Safety Tips Link and Verify the title")]
        public async Task WhenUserClicksontheFarmSafetyTipsLinkandVerifytheTitleAsync()
        {
            await PageTitleVerifyMethodAsync(_commonXpath.Product_FarmSafetyTips_Link, "Goodville Mutual Casualty Company - Safety Tips | Wokers Compensation");
            await TextLink.ClickTextLinkAsync(_commonXpath.Products_Link, true, 1);
        }

        [When(@"User Clicks on the Umbrella Coverage Link and Verify the Title and Verify the agent,Reducing Premium Link")]
        public async Task WhenUserClickontheUmbrellaCoverageLinkandVerifytehTitleandVerifytheAgentandReducingPremiumLinkAsync()
        {
            await PageTitleVerifyMethodAsync(_commonXpath.Product_UmbrellaCoverage_Link, "Goodville Mutual Casualty Company - Umbrella");
            await Product_FindAnAgentAsync();
            await DriverBackAsync();
            await ReducingPremiumAsync();
        }

        public async Task PageTitleVerifyMethodAsync(string RequiredXpath, string ExpectedPageTitle)
        {
            await TextLink.ClickTextLinkAsync(RequiredXpath, true, 1);
            var ActualPageTitle = await page.TitleAsync();
            if (ActualPageTitle == ExpectedPageTitle)
            {
                logger.WriteLine(ExpectedPageTitle + " is dispalying correctly");
            }
            else
            {
                throw new Exception("Expected Page Title is " + ExpectedPageTitle + " not Matching it is displaying " + ActualPageTitle);
            }
        }
        public async Task NextPageTitleVerifyMethodAsync(string RequiredXpath, string ExpectedPageTitle)
        {
            var popup = await page.RunAndWaitForPopupAsync(async () =>
            {
                await TextLink.ClickTextLinkAsync(RequiredXpath, true, 1);
            });
            await page.WaitForLoadStateAsync(LoadState.NetworkIdle);
            await page.WaitForTimeoutAsync(2000);
            var ActualPageTitle = await popup.TitleAsync();
            if (ActualPageTitle == ExpectedPageTitle)
            {
                logger.WriteLine(ExpectedPageTitle + " is displaying correctly");
            }
            else
            {
                throw new Exception("Expected Title is " + ExpectedPageTitle + " not Matching it is displaying " + ActualPageTitle);
            }

            await popup.CloseAsync();
        }

        /*public async Task TestingAsync(string Xpath)
        {
            var locator = page.Locator($"xpath={Xpath}");
            var pdfUrl = await locator.GetAttributeAsync("href");

            if (string.IsNullOrWhiteSpace(pdfUrl))
            {
                throw new Exception("Href attribute is missing or empty.");
            }
            // Combine relative URL with page base URL
            Uri fullUri;
            if (Uri.TryCreate(pdfUrl, UriKind.Absolute, out fullUri))
            {
                // Already absolute
            }
            else
            {
                fullUri = new Uri(new Uri(page.Url), pdfUrl);
            }

            var downloadPath = Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location).Replace("bin\\Debug\\net8.0", "TestingPDF\\");
            var fileName = Path.GetFileName(new Uri(pdfUrl).LocalPath);
            var filePath = Path.Combine(downloadPath, fileName);

            // Download via HttpClient
            using (var client = new HttpClient())
            {
                var bytes = await client.GetByteArrayAsync(pdfUrl);
                await File.WriteAllBytesAsync(filePath, bytes);
                Console.WriteLine("PDF downloaded to: " + filePath);
            }
        }*/

        public async Task TestingAsync(string Xpath)
        {
            var locator = page.Locator($"xpath={Xpath}");
            var pdfUrl = await locator.GetAttributeAsync("href");

            if (string.IsNullOrWhiteSpace(pdfUrl))
            {
                throw new Exception("Href attribute is missing or empty.");
            }

            if (Uri.TryCreate(pdfUrl, UriKind.Absolute, out var fullUri))
            {
                // Already absolute
            }
            else
            {
                fullUri = new Uri(new Uri(page.Url), pdfUrl);
            }

            var downloadPath = Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location)
                .Replace("bin\\Debug\\net8.0", "TestingPDF\\");
            var fileName = Path.GetFileName(fullUri.LocalPath);
            var filePath = Path.Combine(downloadPath, fileName);

            using (var client = new HttpClient())
            {
                var bytes = await client.GetByteArrayAsync(fullUri);
                await File.WriteAllBytesAsync(filePath, bytes);
                Console.WriteLine("PDF downloaded to: " + filePath);
            }
        }

        public async Task Product_FindAnAgentAsync()
        {
            await TextLink.ClickTextLinkAsync(_commonXpath.Product_All_LOBAgent_Link, true, 1);
            var FindanAgent_Title = await page.TitleAsync();
            if (FindanAgent_Title == "Goodville Mutual Casualty Company - Find An Agent")
            {
                logger.WriteLine("Find an Agent page Title is Goodville Mutual Casualty Company - Find An Agent");
            }
            else
            {
                throw new Exception("Find an Agent page Title is not Matching it is displaying " + FindanAgent_Title);
            }
        }

        public async Task ReducingPremiumAsync()
        {
            await TextLink.ClickTextLinkAsync(_commonXpath.Product_All_LOB_ReducingyourPremium, true, 1);
            var ReducingPremium_Title = await page.TitleAsync();
            if (ReducingPremium_Title == "Goodville Mutual Casualty Company - Tips for Reducing Your Premium")
            {
                 logger.WriteLine("Reducing Premium Page Title is Goodville Mutual Casualty Company - Tips for Reducing Your Premium");
            }
            else
            {
                throw new Exception("Reducimg Premium page Title is not Matching it is displaying " + ReducingPremium_Title);
            }
        }

        public async Task DriverBackAsync()
        {
            await page.GoBackAsync();
            logger.WriteLine("Back Clicked");
        }
    }
}
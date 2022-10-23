using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanAjourneyPageProject.Pages
{
    public class JourneyResultPage
    {
       private readonly IWebDriver? driver;
        public JourneyResultPage(IWebDriver? _driver)
        {
            driver = _driver;
        }
       
        private By? JourneyResultSummarySectionFrom => By.XPath("//div[1]/span[@class='notranslate']/strong");
        private By JourneyResultSummarySectionTo => By.XPath("//div[2]/span[@class='notranslate']/strong");
        private By JourneyResultDateTimeLabel => By.XPath("//div[@class='summary-row clearfix']/strong");
        private By PlanAJourneyLink => By.CssSelector("a[href*='/plan-a-journey/']");
        private By JpFastestPublicTransaport => By.XPath("//div[@class='journey-results publictransport no-map']/h2");
        private By JourneyResultDateTimePlanned => By.XPath("//div[@class='summary-row clearfix']/strong");
        private By EditLinkText => By.XPath("//*[@id='plan-a-journey']/div[1]/div[3]/a");
        private By EditPanelSection => By.XPath("//div[@id='plan-a-journey']");
        private By PlanAJourneyBanner => By.XPath("//span[@class='hero-headline']");
        string url = "https://tfl.gov.uk/plan-a-journey/";








        [Obsolete]
        public void JourneyResultPagePlan(string From, string To)
        {
            var JourneyResultSectionFrom = driver?.FindElement(JourneyResultSummarySectionFrom).Text;
            var JourneyResultSectionTo = driver?.FindElement(JourneyResultSummarySectionTo).Text;

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(ExpectedConditions.ElementIsVisible(JpFastestPublicTransaport));

            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView();", driver?.FindElement(JpFastestPublicTransaport));
            var FastestJPBanner = driver?.FindElement(JpFastestPublicTransaport).Text;

            Assert.AreEqual(FastestJPBanner, "Fastest by public transport");
            Assert.AreEqual(JourneyResultSectionFrom, From);
            Assert.AreEqual(JourneyResultSectionTo, To);
        }
        [Obsolete]
        public void JourneyTimePlanned(string DateAndTime)
        {
            var waitToLoad = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            waitToLoad.Until(ExpectedConditions.ElementIsVisible(JourneyResultSummarySectionFrom));
            
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView();", driver?.FindElement(JourneyResultDateTimeLabel));

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(ExpectedConditions.ElementIsVisible(JpFastestPublicTransaport));

            var JourneyTimePlanned = driver?.FindElement(JourneyResultDateTimePlanned).Text;
            Assert.AreEqual(JourneyTimePlanned, DateAndTime);
        }

        [Obsolete]
        public void NavigateBackToJourneyPlannerPage()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;

            js.ExecuteScript("arguments[0].scrollIntoView();", driver?.FindElement(PlanAJourneyLink));
            driver?.FindElement(PlanAJourneyLink).Click();

            var WaitToLoad = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            WaitToLoad.Until(ExpectedConditions.UrlToBe(url));

            js.ExecuteScript("arguments[0].scrollIntoView();", driver?.FindElement(PlanAJourneyBanner));
            var PlanAJourneyDisplayed = driver?.FindElement(PlanAJourneyBanner).Text;

            Assert.AreEqual(PlanAJourneyDisplayed, "Plan a journey");
            PlanAJourneyDisplayed.Should().Be("Plan a journey");

        }

        [Obsolete]
        public void EditJourney()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView();", driver?.FindElement(EditLinkText));

            var EditLink = driver?.FindElement(EditLinkText);
            EditLink?.Click();

            var EditPanel = driver?.FindElements(EditPanelSection);
            Assert.That(EditPanel, Is.Not.Null);

        }

        [Obsolete]
        public void UpdatedJourneyResultPage(string From, string To, string DateAndTime)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView();", driver?.FindElement(JourneyResultSummarySectionFrom));
            var JourneyResultSectionFrom = driver?.FindElement(JourneyResultSummarySectionFrom).Text;
            var JourneyResultSectionTo = driver?.FindElement(JourneyResultSummarySectionTo).Text;

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(ExpectedConditions.ElementIsVisible(JpFastestPublicTransaport));

            js.ExecuteScript("arguments[0].scrollIntoView();", driver?.FindElement(JpFastestPublicTransaport));
            var FastestJPBanner = driver?.FindElement(JpFastestPublicTransaport).Text;

            var JourneyDateTime = driver?.FindElement(JourneyResultDateTimePlanned).Text;

            Assert.AreEqual(FastestJPBanner, "Fastest by public transport");
            Assert.AreEqual(JourneyResultSectionFrom, From);
            Assert.AreEqual(JourneyResultSectionTo, To);
            Assert.AreEqual(JourneyDateTime, DateAndTime);
            JourneyDateTime.Should().Be(DateAndTime);
        }
        public void JourneyResulPageSection(string From, string To)
        {
            var ResultPageFrom = driver?.FindElement(JourneyResultSummarySectionFrom).Text;
            var ResultPageTo = driver?.FindElement(JourneyResultSummarySectionTo).Text;

            Assert.AreEqual(ResultPageFrom, From);
            Assert.AreEqual(ResultPageTo, To);
            ResultPageFrom.Should().Be(From);
            ResultPageTo.Should().Be(To);

        }

    }
}

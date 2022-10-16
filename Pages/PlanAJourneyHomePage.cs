using AngleSharp.Dom;
using Docker.DotNet.Models;
using Microsoft.VisualBasic;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V102.CSS;
using OpenQA.Selenium.DevTools.V102.DOM;
using OpenQA.Selenium.Support.UI;
using PlanAjourneyPageProject.Drivers;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PlanAjourneyPageProject.Pages
{
    public class PlanAJourneyHomePage : DriverHelper
    {

        IJavaScriptExecutor js = (IJavaScriptExecutor)driver;

        private By? planAJourney = By.XPath("//li[@class='plan-journey']");
        private By? SearchFrom = By.XPath("//input[@id='InputFrom']");
        private By? SearchTo = By.XPath("//input[@id='InputTo']");
        private By? planjourneybtc = By.CssSelector("#plan-journey-button");
        private By? TimeSet = By.XPath("//div[@class='time-defaults'] ");
        private By? Leaving = By.XPath("//label[@for='departing']");
        private By? Arriving = By.XPath("//label[@for='arriving']");
        private By? IDate => By.Id("Date");
        private By? ITime => By.Id("Time");
        private By? ChangeDepartureTime = By.XPath("//a[@class='change-departure-time']");
        private IWebElement JourneyResultDateTimePlanned => driver.FindElement(By.XPath("//div[@class='summary-row clearfix']/strong"));
        private By RecentSection = By.XPath("//li[@id='jp-recent-tab-jp']");
        private By EditLinkText = By.XPath("//*[@id='plan-a-journey']/div[1]/div[3]/a");
        private By EditPanelSection = By.XPath("//div[@id='plan-a-journey']");
        private By EditFromTextBox = By.XPath("//input[@id='InputFrom']");
        private By EditToTextBox = By.XPath("//input[@id='InputTo']");
        private By? JourneyResultSummarySectionFrom = By.XPath("//div[1]/span[@class='notranslate']/strong");
        private By JourneyResultSummarySectionTo = By.XPath("//div[2]/span[@class='notranslate']/strong");
        private By JpFastestPublicTransaport = By.XPath("//div[@class='journey-results publictransport no-map']/h2");
        private By ErrorMessageField = By.XPath("//ul[@class='field-validation-errors']");
        private By FromFieldError = By.XPath("//span[@id='InputFrom-error']");
        private By ToFieldError = By.XPath("//span[@id='InputTo-error']");









        public void PlanAjourneyPage() => driver?.FindElement(planAJourney).Click();

        [Obsolete]
        public void SearchBoxFromTo(string From, string To)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(ExpectedConditions.ElementIsVisible(SearchFrom));
            
            js.ExecuteScript("arguments[0].scrollIntoView();", driver?.FindElement(SearchFrom));
            driver?.FindElement(SearchFrom)?.Click();
            driver?.FindElement(SearchFrom)?.SendKeys(From);
            driver?.FindElement(SearchTo)?.Click();
            driver?.FindElement(SearchTo)?.SendKeys(To);
        }
        public void LeavingNow()
        {
            driver?.FindElement(TimeSet)?.Click();
            driver?.FindElement(Leaving)?.Click();
        }
        public void PlanMyJourneyTab()
        {
            driver?.FindElement(planjourneybtc).Click();
        }
        [Obsolete]
        public void JourneyResultPage(string From, string To)
        {
            var JourneyResultSectionFrom = driver?.FindElement(JourneyResultSummarySectionFrom).Text;
            var JourneyResultSectionTo = driver?.FindElement(JourneyResultSummarySectionTo).Text;
            
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(ExpectedConditions.ElementIsVisible(JpFastestPublicTransaport));

            js.ExecuteScript("arguments[0].scrollIntoView();", driver?.FindElement(JpFastestPublicTransaport));
            var FastestJPBanner = driver?.FindElement(JpFastestPublicTransaport).Text;

            Assert.AreEqual(FastestJPBanner, "Fastest by public transport");
            Assert.AreEqual(JourneyResultSectionFrom, From);
            Assert.AreEqual(JourneyResultSectionTo, To);
        }

        public void SelectDateAndTime(string Date, string Time)
        {
            driver?.FindElement(ChangeDepartureTime).Click();
            driver?.FindElement(IDate).SendKeys(Date + Keys.Enter);
            driver?.FindElement(ITime).SendKeys(Time + Keys.Enter);
            js.ExecuteScript("arguments[0].scrollIntoView();", driver?.FindElement(By.Id("Time")));
        }
        public void TurnOnRecentJourney()
        {
            var RecentPlannedJourney = driver?.FindElement(By.XPath("//a[@href='#jp-recent']"));
            RecentPlannedJourney?.Click();
            
            var TurnOnJourneyLink = driver?.FindElement(By.XPath("//a[@class='turn-on-recent-journeys']"));
            TurnOnJourneyLink?.Click();

            var IsTurnedOnJourneyLink = driver?.FindElement(By.XPath("//a[@class='turn-off-recent-journeys']"));
            Assert.IsNotNull(IsTurnedOnJourneyLink);
        }

        [Obsolete]
        public void JourneyTimePlanned(string DateAndTime)
        {
            var waitToLoad = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            waitToLoad.Until(ExpectedConditions.ElementIsVisible(JourneyResultSummarySectionFrom));
            js.ExecuteScript("arguments[0].scrollIntoView();", driver?.FindElement(By.XPath("//div[@class='summary-row clearfix']/strong")));
            Assert.AreEqual(JourneyResultDateTimePlanned.Text, DateAndTime);
        }
        public void NavigateBackToJourneyPlannerPage()
        {
            js.ExecuteScript("arguments[0].scrollIntoView();", driver?.FindElement(By.CssSelector("a[href*='/plan-a-journey/']")));
            driver?.FindElement(By.CssSelector("a[href*='/plan-a-journey/']")).Click();
            
            var WaitToLoad = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            WaitToLoad.Until(ExpectedConditions.UrlToBe("https://tfl.gov.uk/plan-a-journey/"));

            js.ExecuteScript("arguments[0].scrollIntoView();", driver?.FindElement(By.XPath("//span[@class='hero-headline']")));
            var PlanAJourneyDisplayed = driver?.FindElement(By.XPath("//span[@class='hero-headline']")).Text;
            
            Assert.AreEqual(PlanAJourneyDisplayed, "Plan a journey");
        }
        public void RecentJourneyTabDisplayed(string RecentPlan)
        {
            js.ExecuteScript("arguments[0].scrollIntoView();", driver?.FindElement(RecentSection));

            var RecentPlannedJourney = driver?.FindElement(By.XPath("//a[@href='#jp-recent']"));
            RecentPlannedJourney?.Click();

            string? DetailRecentJourney = driver?.FindElement(By.XPath("//div[@id='jp-recent-content-jp-']/a")).Text;
            
            Assert.AreEqual(DetailRecentJourney, RecentPlan);
        }

        [Obsolete]
        public void EditJourney()
        {
            js.ExecuteScript("arguments[0].scrollIntoView();", driver?.FindElement(EditLinkText));
           
            var EditLink =driver?.FindElement(EditLinkText);
            EditLink?.Click();

            var EditPanel = driver?.FindElements(EditPanelSection);
            Assert.That(EditPanel, Is.Not.Null);           
        }
        public void EditLocation(string From, string To)
        {
            driver?.FindElement(EditFromTextBox)?.SendKeys(Keys.Control + "a");
            driver?.FindElement(EditFromTextBox)?.SendKeys(From);
            driver?.FindElement(EditToTextBox)?.SendKeys(Keys.Control + "a");
            driver?.FindElement(EditToTextBox)?.SendKeys(To);
        }
        public void ArrivingBox()
        {
            driver?.FindElement(Arriving)?.Click();
        }
        public void UpdatedTheDateAndTime(string Date, string Time)
        {
            driver?.FindElement(IDate).SendKeys(Date);
            driver?.FindElement(ITime).SendKeys(Time);
        }
        public void ClickUpdateJourneyButton()
        {
            driver?.FindElement(planjourneybtc).Click(); 
        }
        public void UpdatedJourneyResultPage(string From, string To,string DateAndTime)
        {
            js.ExecuteScript("arguments[0].scrollIntoView();", driver?.FindElement(JourneyResultSummarySectionFrom));
            var JourneyResultSectionFrom = driver?.FindElement(JourneyResultSummarySectionFrom).Text;
            var JourneyResultSectionTo = driver?.FindElement(JourneyResultSummarySectionTo).Text;

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(ExpectedConditions.ElementIsVisible(JpFastestPublicTransaport));

            js.ExecuteScript("arguments[0].scrollIntoView();", driver?.FindElement(JpFastestPublicTransaport));
            var FastestJPBanner = driver.FindElement(JpFastestPublicTransaport).Text;

            Assert.AreEqual(FastestJPBanner, "Fastest by public transport");
            Assert.AreEqual(JourneyResultSectionFrom, From);
            Assert.AreEqual(JourneyResultSectionTo, To);
            Assert.AreEqual(JourneyResultDateTimePlanned.Text, DateAndTime);
        }
        public void JourneyResulPageSection(string From, string To)
        {
            var ResultPageFrom = driver?.FindElement(JourneyResultSummarySectionFrom).Text;
            var ResultPageTo = driver?.FindElement(JourneyResultSummarySectionTo).Text;
            
            Assert.AreEqual(ResultPageFrom, From);
            Assert.AreEqual(ResultPageTo, To);
        }
        public void ErrorMessageDisplayed(string ErrorMessage)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(ExpectedConditions.ElementIsVisible(ErrorMessageField));
            
            js.ExecuteScript("arguments[0].scrollIntoView();", driver?.FindElement(ErrorMessageField));

            var ErrorMessageBanner = driver?.FindElement(ErrorMessageField).Text;
            Assert.AreEqual(ErrorMessageBanner, ErrorMessage);
        }
        public void BlankFromAndTo(string From, string To)
        {
            js.ExecuteScript("arguments[0].scrollIntoView();", driver?.FindElement(SearchFrom));

            driver?.FindElement(SearchFrom)?.SendKeys(From);
            driver?.FindElement(SearchFrom).SendKeys(Keys.Enter);
            driver?.FindElement(SearchTo)?.SendKeys(To);
            driver?.FindElement(SearchTo).SendKeys(Keys.Enter);
        }
        public void FromToFieldValidationError(string FieldErrorMessageFrom, string FieldErrorMessageTo)
        {
            var ErrorFromMessage = driver?.FindElement(FromFieldError).Text;
            var ErrorToMessage = driver?.FindElement(ToFieldError).Text;
            
            Assert.AreEqual(ErrorFromMessage, FieldErrorMessageFrom);
            Assert.AreEqual(ErrorToMessage, FieldErrorMessageTo);
        }
    }
}




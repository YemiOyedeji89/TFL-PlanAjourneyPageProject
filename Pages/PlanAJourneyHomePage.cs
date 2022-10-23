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
    public class PlanAJourneyHomePage 
    {
      private readonly  IWebDriver? driver;
        public PlanAJourneyHomePage(IWebDriver? _driver)
        {
            driver = _driver;
        }
        private By RecentSection => By.XPath("//li[@id='jp-recent-tab-jp']");
        private By RecentLink => By.XPath("//a[@href='#jp-recent']");
        private By OnRecentJourney => By.XPath("//a[@class='turn-on-recent-journeys']");
        private By OffRecentJourneyLink => By.XPath("//a[@class='turn-off-recent-journeys']");
        private By RecentDetails => By.XPath("//div[@id='jp-recent-content-jp-']/a");




        public void TurnOnRecentJourney()
        {
            var RecentPlannedJourney = driver?.FindElement(RecentLink);
            RecentPlannedJourney?.Click();
            
            var TurnOnJourneyLink = driver?.FindElement(OnRecentJourney);
            TurnOnJourneyLink?.Click();

            var IsTurnedOnJourneyLink = driver?.FindElement(OffRecentJourneyLink);
            Assert.IsNotNull(IsTurnedOnJourneyLink);
        }

        [Obsolete]
        public void RecentJourneyTabDisplayed(string RecentPlan)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView();", driver?.FindElement(RecentSection));

            var RecentPlannedJourney = driver?.FindElement(RecentLink);
            RecentPlannedJourney?.Click();

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(ExpectedConditions.ElementIsVisible(RecentDetails));

            string? DetailRecentJourney = driver?.FindElement(RecentDetails).Text;
            
            Assert.AreEqual(DetailRecentJourney, RecentPlan);
        } 
    }
}

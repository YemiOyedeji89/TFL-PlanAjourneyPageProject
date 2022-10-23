using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanAjourneyPageProject.Pages
{
    public class Tfl_HomePage
    {
        private readonly IWebDriver? driver;
        public Tfl_HomePage(IWebDriver? _driver)
        {
            driver = _driver;
        }

        private By? planAJourney => By.XPath("//li[@class='plan-journey']");


        public void PlanAjourneyPage() => driver?.FindElement(planAJourney).Click();





    }
}

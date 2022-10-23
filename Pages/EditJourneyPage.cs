using Docker.DotNet.Models;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanAjourneyPageProject.Pages
{
    public class EditJourneyPage
    {

        private readonly IWebDriver? driver;
        public EditJourneyPage(IWebDriver? _driver)
        {
            driver = _driver;
        }

        private By EditFromTextBox => By.XPath("//input[@id='InputFrom']");
        private By EditToTextBox => By.XPath("//input[@id='InputTo']");
        private By? Arriving => By.XPath("//label[@for='arriving']");
        private By? IDate => By.Id("Date");
        private By? ITime => By.Id("Time");
        private By? planjourneybtc => By.CssSelector("#plan-journey-button");





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
    }
}

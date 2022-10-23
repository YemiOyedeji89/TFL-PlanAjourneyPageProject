using Docker.DotNet.Models;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace PlanAjourneyPageProject.Pages
{
    public class PlanAJourneyWidget

    {
        private readonly IWebDriver? driver;
        public PlanAJourneyWidget(IWebDriver? _driver)
        {
            driver = _driver;
        }

        private By? SearchFrom => By.XPath("//input[@id='InputFrom']");
        private By? SearchTo => By.XPath("//input[@id='InputTo']");
        private By? TimeSet => By.XPath("//div[@class='time-defaults'] ");
        private By? Leaving => By.XPath("//label[@for='departing']");
        private By? IDate => By.Id("Date");
        private By? ITime => By.Id("Time");
        private By? ChangeDepartureTime => By.XPath("//a[@class='change-departure-time']");
        private By? planjourneybtc => By.CssSelector("#plan-journey-button");
        private By ErrorMessageField => By.XPath("//ul[@class='field-validation-errors']");
        private By FromFieldError => By.XPath("//span[@id='InputFrom-error']");
        private By ToFieldError => By.XPath("//span[@id='InputTo-error']");
     







        [Obsolete]
        public void SearchBoxFromTo(string From, string To)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(ExpectedConditions.ElementIsVisible(SearchFrom));

            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
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
        public void SelectDateAndTime(string Date, string Time)
        {
            driver?.FindElement(ChangeDepartureTime).Click();
            driver?.FindElement(IDate).SendKeys(Date + Keys.Enter);
            driver?.FindElement(ITime).SendKeys(Time + Keys.Enter);
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView();", driver?.FindElement(By.Id("Time")));
        }
        public void ErrorMessageDisplayed(string ErrorMessage)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(ExpectedConditions.ElementIsVisible(ErrorMessageField));

            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView();", driver?.FindElement(ErrorMessageField));

            var ErrorMessageBanner = driver?.FindElement(ErrorMessageField).Text;
            Assert.AreEqual(ErrorMessageBanner, ErrorMessage);
        }
        public void BlankFromAndTo(string From, string To)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
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

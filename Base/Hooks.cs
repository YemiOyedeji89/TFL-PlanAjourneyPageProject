using Docker.DotNet.Models;
using Dynamitey.DynamicObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using PlanAjourneyPageProject.Drivers;
using System.Diagnostics;
using TechTalk.SpecFlow;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

using PlanAjourneyPageProject.Pages;
using BoDi;

namespace PlanAjourneyPageProject.Base
{
    [Binding]
    public class Hooks : DriverHelper
    {
        public static ChromeOptions? options;
        ObjectContainer container;

        public Hooks (IObjectContainer _container)
        {
            container = (ObjectContainer)_container;
           
        }

        [BeforeScenario]


        public void BeforeScenarioWithTag()
        {

            new DriverManager().SetUpDriver(new ChromeConfig());
            options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            driver = new ChromeDriver(options);
            container.RegisterInstanceAs(driver);

            driver.Navigate().GoToUrl("https://tfl.gov.uk");

            
            var mainHandle = driver.CurrentWindowHandle;
            var handles = driver.WindowHandles;

            foreach (var handle in handles)
            {
                if (mainHandle == handle)
                {
                    continue;
                }
                driver.SwitchTo().Window(handle);
                break;
            }
            
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView();", driver.FindElement(By.XPath("//button[@onclick='acceptAllCookies(); return false;']")));
            driver.FindElement(By.Id("CybotCookiebotDialogBodyLevelButtonLevelOptinAllowAll")).Click();

            driver.FindElement(By.XPath("//button[@onclick='endCookieProcess(); return false;']")).Click();

            foreach (var handle in handles)
            {
                driver.SwitchTo().Window(handle);
                break;
            }

        }


        [AfterScenario]
        public static void AfterScenario(IWebDriver driver)
        {
            driver.Quit();

            using (var process = Process.GetCurrentProcess())

                if (process.ToString() == "chromedriver")
                {
                    process.Kill();

                }
                else if (process.ToString() == "geckodriver")
                {
                    process.Kill();
                }
        }

    }
}
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UITests.Source.Helper;

namespace UITests.Source.Pages
{
    public class MainPage
    {
        protected AppiumDriver driver;

        private By usernameLabelBy = MobileByExtensions.ByPlatformSpecificId("usernamelbl");
        private By greetingLabelBy = MobileByExtensions.ByPlatformSpecificId("greetinglbl");
        private By greetingButtonBy = MobileByExtensions.ByPlatformSpecificId("greetusrbtn");

        public MainPage(AppiumDriver driver)
        {
            this.driver = driver;
        }

        public string GetUsername()
        {
            return driver.FindElement(usernameLabelBy).Text;
        }

        public void GreetUser()
        {
            var username = driver.FindElement(usernameLabelBy).Text;
            driver.FindElement(greetingButtonBy).Click();
        }

        public string GetGreeting()
        {
            var greetingLabel = driver.FindElement(greetingLabelBy);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(driver => greetingLabel.Text);
            return greetingLabel.Text;
        }
    }
}

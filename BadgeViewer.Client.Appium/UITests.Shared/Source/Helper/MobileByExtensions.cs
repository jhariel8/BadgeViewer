using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UITests.Source.Helper
{
    public static class MobileByExtensions
    {
        public static By ByPlatformSpecificId(string id)
        {
            if(AppiumSetup.App is WindowsDriver)
            {
                return MobileBy.AccessibilityId(id);
            }

            return MobileBy.Id(id);
        }
    }
}

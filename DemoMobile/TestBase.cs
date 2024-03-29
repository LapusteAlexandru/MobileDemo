﻿
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Support.UI;
using System;

namespace DemoMobile
{
    class TestBase
    {


        public static AndroidDriver<IWebElement> driver { get; set; }

        public static WebDriverWait wait { get; set; }
        
        public static void RootInit()
        {
            var cap = new AppiumOptions();
            cap.AddAdditionalCapability(MobileCapabilityType.DeviceName, "Nexus");
            cap.AddAdditionalCapability(MobileCapabilityType.PlatformVersion, "10.0");
            cap.AddAdditionalCapability(MobileCapabilityType.App, "C:/Users/alexandru.lapuste/Desktop/Smcs.MobileClient.Droid.apk");
            cap.AddAdditionalCapability(MobileCapabilityType.PlatformName, "Android");
            cap.AddAdditionalCapability(MobileCapabilityType.FullReset, true);
            driver = new AndroidDriver<IWebElement>(new Uri("http://localhost:4444/wd/hub"), cap);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(50));
        }

    }
}

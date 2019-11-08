using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;

namespace Tests
{
    public class Tests
    {
        private static AndroidDriver<AndroidElement> _driver;
        [SetUp]
        public void Setup()
        {
            var cap = new AppiumOptions();
            cap.AddAdditionalCapability(MobileCapabilityType.DeviceName,"Nexus");
            cap.AddAdditionalCapability(MobileCapabilityType.PlatformVersion, "10.0");
            cap.AddAdditionalCapability(MobileCapabilityType.App, "C:/Users/alexandru.lapuste/Desktop/Smcs.MobileClient.Droid.apk");
            cap.AddAdditionalCapability(MobileCapabilityType.PlatformName, "Android");
            cap.AddAdditionalCapability(MobileCapabilityType.FullReset, true);
            _driver = new AndroidDriver<AndroidElement>(new Uri("http://127.0.0.1:4723/wd/hub"), cap);
        }
        
        [Test]
        public void Test1()
        {
            //implicit wait
            //_driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            //explicit wait
            AndroidElement email = (AndroidElement)new WebDriverWait(_driver,TimeSpan.FromSeconds(30)).Until(
                ExpectedConditions.ElementIsVisible(MobileBy.AccessibilityId("email")));
            //AndroidElement email = _driver.FindElementByAccessibilityId("email");
            email.SendKeys("alexandru.lapuste@amdaris.com");
            Assert.Pass();
        }
    }
}
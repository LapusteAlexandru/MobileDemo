using DemoMobile;
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
        [SetUp]
        public void Setup()
        {
            TestBase.rootInit();
        }
        
        [Test]
        public void Test1()
        {
            //implicit wait
            //_driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            //explicit wait
            //AndroidElement email = (AndroidElement)new WebDriverWait(_driver,TimeSpan.FromSeconds(30)).Until(
            //ExpectedConditions.ElementIsVisible(MobileBy.AccessibilityId("email")));
            //AndroidElement email = _driver.FindElementByAccessibilityId("email");
            //email.SendKeys("alexandru.lapuste@amdaris.com");
            LoginPage lp = new LoginPage();
            lp.doLogin("smcs.materialcontroller@test.com", "Pass123$");
            Assert.Pass();
        }
    }
}
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

        [TearDown]

        public void TearDown()
        {
            TestBase.driver.Quit();
        }
        
        [Test]
        public void testSuccessfulLogin()
        {
            LoginPage lp = new LoginPage(TestBase.driver);
            lp.doLogin("smcs.materialcontroller@test.com", "Pass123$");
            Assert.Pass();
        }

        [Test]
        public void resetPassBtnLoadsPage()
        {
            LoginPage lp= new LoginPage(TestBase.driver);
            ForgotPassword fp = lp.ForgotPassword();
            fp.PageLoad();
        }
    }
}
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
            TestBase.RootInit();
        }

        [TearDown]

        public void TearDown()
        {
            TestBase.driver.Quit();
        }
        
        [Test]
        public void TestSuccessfulLogin()
        {
            LoginPage lp = new LoginPage(TestBase.driver);
            DashboardPage dp=lp.DoLogin("smcs.materialcontroller@test.com", "Pass123$");
            
        }

        [Test]
        public void ResetPassBtnLoadsPage()
        {
            LoginPage lp= new LoginPage(TestBase.driver);
            ForgotPasswordPage fp = lp.ForgotPassword();
 
            foreach(IWebElement e in fp.GetMainElements())
            {
                Assert.That(e.Displayed);
            }
        }
    }
}
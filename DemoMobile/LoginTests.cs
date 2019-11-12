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
            TestBase.wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/hierarchy/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.widget.RelativeLayout/android.view.ViewGroup/android.support.v4.widget.DrawerLayout/android.view.ViewGroup/android.view.ViewGroup/android.view.ViewGroup/android.view.ViewGroup[2]/android.view.ViewGroup/android.widget.ScrollView/android.view.ViewGroup/android.view.ViewGroup/android.view.ViewGroup[1]/android.view.ViewGroup/android.view.ViewGroup/android.widget.TextView[1]")));
            Assert.That(dp.username.GetAttribute("text").Contains("SMCS Material Controller"));
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
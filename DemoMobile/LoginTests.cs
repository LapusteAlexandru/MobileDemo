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
        public void testLoginPageLoads()
        {
            LoginPage lp = new LoginPage(TestBase.driver);
            TestBase.wait.Until(ExpectedConditions.ElementIsVisible(MobileBy.AccessibilityId("email")));
            foreach (IWebElement e in lp.GetMainElements())
            {
                Assert.That(e.Displayed);
            }
        }
        
        [Test]
        public void TestSuccessfulLogin()
        {
            //LoginPage lp = new LoginPage(TestBase.driver);
            //DashboardPage dp=lp.DoLogin("smcs.materialcontroller@test.com", "Pass123$");
            //TestBase.wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/hierarchy/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.widget.RelativeLayout/android.view.ViewGroup/android.support.v4.widget.DrawerLayout/android.view.ViewGroup/android.view.ViewGroup/android.view.ViewGroup/android.view.ViewGroup[2]/android.view.ViewGroup/android.widget.ScrollView/android.view.ViewGroup/android.view.ViewGroup/android.view.ViewGroup[1]/android.view.ViewGroup/android.view.ViewGroup/android.widget.TextView[1]")));
            //Assert.That(dp.username.Displayed);
            TestBase.wait.Until(ExpectedConditions.ElementIsVisible(MobileBy.AccessibilityId("email")));
            IWebElement email = TestBase.driver.FindElement(By.XPath("//android.widget.EditText[@content-desc='email']"));
            email.Clear();
            email.SendKeys("smcs.materialcontroller@test.com");
            IWebElement password = TestBase.driver.FindElement(By.XPath("//android.widget.EditText[@content-desc='password']"));
            password.Clear();
            password.SendKeys("Pass123$");
            IWebElement btnSignIn = TestBase.driver.FindElement(By.XPath("//android.widget.Button[@content-desc='signin']"));
            btnSignIn.Click();
            TestBase.wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/hierarchy/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.widget.RelativeLayout/android.view.ViewGroup/android.support.v4.widget.DrawerLayout/android.view.ViewGroup/android.view.ViewGroup/android.view.ViewGroup/android.view.ViewGroup[2]/android.view.ViewGroup/android.widget.ScrollView/android.view.ViewGroup/android.view.ViewGroup/android.view.ViewGroup[1]/android.view.ViewGroup/android.view.ViewGroup/android.widget.TextView[1]")));
            IWebElement username = TestBase.driver.FindElement(By.XPath("/hierarchy/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.widget.RelativeLayout/android.view.ViewGroup/android.support.v4.widget.DrawerLayout/android.view.ViewGroup/android.view.ViewGroup/android.view.ViewGroup/android.view.ViewGroup[2]/android.view.ViewGroup/android.widget.ScrollView/android.view.ViewGroup/android.view.ViewGroup/android.view.ViewGroup[1]/android.view.ViewGroup/android.view.ViewGroup/android.widget.TextView[1]"));
            Assert.That(username.Displayed);
            Assert.That(username.GetAttribute("text").Contains("SMCS Material Controller"));
        }

        [Test]
        public void TestResetPassBtnLoadsPage()
        {
            //LoginPage lp= new LoginPage(driver);
            //ForgotPasswordPage fp = lp.ForgotPassword();
 
            //foreach(IWebElement e in fp.GetMainElements())
            //{
             //   Assert.That(e.Displayed);
            //}
        }
    }
}
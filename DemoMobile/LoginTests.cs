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

        public static AndroidDriver<IWebElement> driver { get; set; }

        public static WebDriverWait wait { get; set; }
        [SetUp]
        public void Setup()
        {
            //TestBase.RootInit();

            var cap = new AppiumOptions();
            cap.AddAdditionalCapability(MobileCapabilityType.DeviceName, "Nexus");
            cap.AddAdditionalCapability(MobileCapabilityType.PlatformVersion, "10.0");
            cap.AddAdditionalCapability(MobileCapabilityType.App, "C:/Users/alexandru.lapuste/Desktop/Smcs.MobileClient.Droid.apk");
            cap.AddAdditionalCapability(MobileCapabilityType.PlatformName, "Android");
            cap.AddAdditionalCapability(MobileCapabilityType.FullReset, true);
            cap.AddAdditionalCapability(MobileCapabilityType.FullReset, true);
            driver = new AndroidDriver<IWebElement>(new Uri("http://localhost:4444/wd/hub"), cap);

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
        }

        [TearDown]

        public void TearDown()
        {
            driver.Quit();
        }
        
        [Test]
        public void TestSuccessfulLogin()
        {
            //LoginPage lp = new LoginPage(TestBase.driver);
            //DashboardPage dp=lp.DoLogin("smcs.materialcontroller@test.com", "Pass123$");
            //TestBase.wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/hierarchy/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.widget.RelativeLayout/android.view.ViewGroup/android.support.v4.widget.DrawerLayout/android.view.ViewGroup/android.view.ViewGroup/android.view.ViewGroup/android.view.ViewGroup[2]/android.view.ViewGroup/android.widget.ScrollView/android.view.ViewGroup/android.view.ViewGroup/android.view.ViewGroup[1]/android.view.ViewGroup/android.view.ViewGroup/android.widget.TextView[1]")));
            //Assert.That(dp.username.GetAttribute("text").Contains("SMCS Material Controller"));
            wait.Until(ExpectedConditions.ElementIsVisible(MobileBy.AccessibilityId("email")));
            IWebElement email = driver.FindElement(By.XPath("//android.widget.EditText[@content-desc='email']"));
            email.Clear();
            email.SendKeys("smcs.materialcontroller@test.com");
            IWebElement password = driver.FindElement(By.XPath("//android.widget.EditText[@content-desc='password']"));
            password.Clear();
            password.SendKeys("Pass123$");
            IWebElement btnSignIn = driver.FindElement(By.XPath("//android.widget.Button[@content-desc='signin']"));
            btnSignIn.Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/hierarchy/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.widget.RelativeLayout/android.view.ViewGroup/android.support.v4.widget.DrawerLayout/android.view.ViewGroup/android.view.ViewGroup/android.view.ViewGroup/android.view.ViewGroup[2]/android.view.ViewGroup/android.widget.ScrollView/android.view.ViewGroup/android.view.ViewGroup/android.view.ViewGroup[1]/android.view.ViewGroup/android.view.ViewGroup/android.widget.TextView[1]")));
            IWebElement username = driver.FindElement(By.XPath("/hierarchy/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.widget.RelativeLayout/android.view.ViewGroup/android.support.v4.widget.DrawerLayout/android.view.ViewGroup/android.view.ViewGroup/android.view.ViewGroup/android.view.ViewGroup[2]/android.view.ViewGroup/android.widget.ScrollView/android.view.ViewGroup/android.view.ViewGroup/android.view.ViewGroup[1]/android.view.ViewGroup/android.view.ViewGroup/android.widget.TextView[1]"));
            Assert.That(username.Displayed);
            Assert.That(username.GetAttribute("text").Contains("SMCS Material Controller"));
        }

        [Test]
        public void TestResetPassBtnLoadsPage()
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
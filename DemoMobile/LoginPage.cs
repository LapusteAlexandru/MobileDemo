using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoMobile
{
    class LoginPage
    {
        public LoginPage(AndroidDriver<IWebElement> _driver)
        {
            PageFactory.InitElements(_driver, this);
        }

        [FindsBy(How=How.XPath,Using = "//android.widget.EditText[@content-desc='email']")]
        public IWebElement email {get;set;}
        [FindsBy(How = How.XPath, Using = "//android.widget.EditText[@content-desc='password']")]
        public IWebElement password { get; set; }
        [FindsBy(How = How.XPath, Using = "//android.widget.Button[@content-desc='signin']")]
        public IWebElement btnSignIn { get; set; }
        [FindsBy(How = How.XPath, Using = "/hierarchy/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.widget.RelativeLayout/android.view.ViewGroup/android.view.ViewGroup/android.view.ViewGroup/android.view.ViewGroup[1]/android.view.ViewGroup[1]")]
        public IWebElement logo { get; set; }
        [FindsBy(How = How.XPath, Using = "/hierarchy/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.widget.RelativeLayout/android.view.ViewGroup/android.view.ViewGroup/android.view.ViewGroup/android.view.ViewGroup[1]/android.view.ViewGroup[2]/android.view.ViewGroup/android.widget.TextView[4]")]
        public IWebElement forgotPassword { get; set; }
        [FindsBy(How = How.Id, Using = "android:id/message")]
        public IWebElement invalidCredentialsMsg { get; set; }

        public DashboardPage doLogin(string email,string password)
        {
            IWebElement wait = new WebDriverWait(TestBase.driver, TimeSpan.FromSeconds(30)).Until(
                ExpectedConditions.ElementIsVisible(MobileBy.AccessibilityId("email")));
            this.email.SendKeys(email);
            this.password.SendKeys(password);
            btnSignIn.Click();

            return new DashboardPage();
        }

        public ForgotPassword ForgotPassword()
        {
            IWebElement wait = new WebDriverWait(TestBase.driver, TimeSpan.FromSeconds(30)).Until(
                ExpectedConditions.ElementIsVisible(MobileBy.AccessibilityId("email")));
            forgotPassword.Click();
            return new ForgotPassword(TestBase.driver);
        }

    }
}

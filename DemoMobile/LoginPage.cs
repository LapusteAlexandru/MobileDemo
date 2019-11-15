﻿using OpenQA.Selenium;
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

        public IList<IWebElement> mainElements = new List<IWebElement>();
        public IList<IWebElement> GetMainElements()
        {
            mainElements.Add(email);
            mainElements.Add(password);
            mainElements.Add(btnSignIn);
            mainElements.Add(logo);
            mainElements.Add(forgotPassword);
            return mainElements;
        }
        public void DoLogin(string email,string password)
        {
            TestBase.wait.Until(ExpectedConditions.ElementIsVisible(MobileBy.AccessibilityId("email")));
            this.email.SendKeys(email);
            this.password.SendKeys(password);
            btnSignIn.Click();

            //return new DashboardPage(TestBase.driver);
        }

        public ForgotPasswordPage ForgotPassword()
        {
            TestBase.wait.Until(ExpectedConditions.ElementIsVisible(MobileBy.AccessibilityId("email")));
            forgotPassword.Click();
            return new ForgotPasswordPage(TestBase.driver);
        }

    }
}

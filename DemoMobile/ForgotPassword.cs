using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoMobile
{
    class ForgotPassword
    {
        public ForgotPassword(AndroidDriver<IWebElement> _driver)
        {
            PageFactory.InitElements(_driver, this);
        }

        [FindsBy(How = How.Id, Using = "Smcs.MobileClient.Droid:id/materialformsedittext")]
        public IWebElement email { get; set; }
        [FindsBy(How = How.XPath, Using = "/hierarchy/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.widget.RelativeLayout/android.view.ViewGroup/android.view.ViewGroup/android.view.ViewGroup/android.view.ViewGroup/android.view.ViewGroup[2]/android.widget.Button")]
        public IWebElement btnSend { get; set; }
        
        public IList<IWebElement> primaryElements = new List<IWebElement>() { };
        

        public void ResetPassword(string email)
        {
            this.email.SendKeys(email);
            btnSend.Click();
        }

        public void PageLoad()
        {
            primaryElements.Add(email);
            primaryElements.Add(btnSend);

            foreach(IWebElement e in primaryElements)
            {
                Assert.That(e.Displayed);
            }
        }
    }
}

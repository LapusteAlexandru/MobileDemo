using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoMobile
{
    class ForgotPasswordPage
    {
        public ForgotPasswordPage(AndroidDriver<IWebElement> _driver)
        {
            PageFactory.InitElements(_driver, this);
        }

        [FindsBy(How = How.Id, Using = "Smcs.MobileClient.Droid:id/materialformsedittext")]
        public IWebElement email { get; set; }
        [FindsBy(How = How.XPath, Using = "//android.widget.Button[contains(@text,'SEND')]")]
        public IWebElement btnSend { get; set; }

        public IList<IWebElement> mainElements = new List<IWebElement>();
        public IList<IWebElement> GetMainElements()
        {
            mainElements.Add(email);
            mainElements.Add(btnSend);
            return mainElements;
        }

        public void ResetPassword(string email)
        {
            this.email.SendKeys(email);
            btnSend.Click();
        }

        
    }
}

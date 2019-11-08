using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoMobile
{
    class LoginPage
    {
        
        AndroidElement email ;
        AndroidElement password ;
        AndroidElement btnSignIn ;

        public DashboardPage doLogin(string email,string password)
        {
            AndroidElement wait = (AndroidElement)new WebDriverWait(TestBase._driver, TimeSpan.FromSeconds(30)).Until(
                ExpectedConditions.ElementIsVisible(MobileBy.AccessibilityId("email")));
            this.email = TestBase._driver.FindElementByAccessibilityId("email");
            this.password = TestBase._driver.FindElementByAccessibilityId("password");
            this.btnSignIn = TestBase._driver.FindElementByAccessibilityId("signin");
            this.email.SendKeys(email);
            this.password.SendKeys(password);
            this.btnSignIn.Click();
            return new DashboardPage();
        }

    }
}

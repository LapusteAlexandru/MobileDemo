using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System.Collections.Generic;

namespace DemoMobile
{
    class LoginPage
    {
        public LoginPage(AndroidDriver<IWebElement> _driver)
        {
            PageFactory.InitElements(_driver, this);
        }


        [FindsBy(How = How.Custom, Using = "email", CustomFinderType = typeof(ByAccesibilityID))]
        public IWebElement email { get; set; }
        [FindsBy(How = How.Custom, Using = "password", CustomFinderType = typeof(ByAccesibilityID))]
        public IWebElement password { get; set; }
        [FindsBy(How = How.Custom, Using = "signin", CustomFinderType = typeof(ByAccesibilityID))]
        public IWebElement btnSignIn { get; set; }
        [FindsBy(How = How.XPath, Using = "/hierarchy/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.widget.RelativeLayout/android.view.ViewGroup/android.view.ViewGroup/android.view.ViewGroup/android.view.ViewGroup[1]/android.view.ViewGroup[1]")]
        public IWebElement logo { get; set; }
        [FindsBy(How = How.XPath, Using = "//android.widget.TextView[contains(@text,'Forgot Password')]")]
        public IWebElement forgotPassword { get; set; }
        [FindsBy(How = How.Id, Using = "android:id/message")]
        public IWebElement invalidCredentialsMsg { get; set; }
        [FindsBy(How = How.XPath, Using = "//android.widget.TextView[contains(@text,'email is required')]")]
        public IWebElement usernameErrorMsg { get; set; }
        [FindsBy(How = How.XPath, Using = "//android.widget.TextView[contains(@text,'password is required')]")]
        public IWebElement passwordErrorMsg { get; set; }

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
        public DashboardPage DoLogin(string email,string password)
        {
            TestBase.wait.Until(ExpectedConditions.ElementToBeClickable(this.email));
            this.email.SendKeys(email);
            this.password.SendKeys(password);
            btnSignIn.Click();
            return new DashboardPage(TestBase.driver);
        }
    }
}

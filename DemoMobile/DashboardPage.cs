using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using SeleniumExtras.PageObjects;

namespace DemoMobile
{
    class DashboardPage
    {
        public DashboardPage(AndroidDriver<IWebElement> driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//android.widget.TextView[contains(@text,'SMCS Material Controller')]")]
        public IWebElement username { get; set; }
        

    }
}

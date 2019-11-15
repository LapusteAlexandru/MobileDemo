using DemoMobile;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using SeleniumExtras.WaitHelpers;

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
        public void testSuccessfulLogin()
        {

            LoginPage lp = new LoginPage(TestBase.driver);
            DashboardPage dp = lp.DoLogin("smcs.materialcontroller@test.com", "Pass123$");
            TestBase.wait.Until(ExpectedConditions.ElementToBeClickable(dp.username));
            Assert.That(dp.username.Displayed);
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

    }
}
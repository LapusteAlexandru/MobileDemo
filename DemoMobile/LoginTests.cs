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
        public void TestSuccessfulLogin()
        {
            LoginPage lp = new LoginPage(TestBase.driver);
            DashboardPage dp = lp.DoLogin("smcs.materialcontroller@test.com", "Pass123$");
            TestBase.wait.Until(ExpectedConditions.ElementToBeClickable(dp.username));
            Assert.That(dp.username.Displayed);
        }

        [Test]
        public void TestLoginPageLoads()
        {
            LoginPage lp = new LoginPage(TestBase.driver);
            TestBase.wait.Until(ExpectedConditions.ElementIsVisible(MobileBy.AccessibilityId("email")));
            foreach (IWebElement e in lp.GetMainElements())
            {
                Assert.That(e.Displayed);
            }
        }

        [Test]

        public void TestLoginInvalidUser()
        {
            LoginPage lp = new LoginPage(TestBase.driver);
            lp.DoLogin("test@test.com", "123");
            TestBase.wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/hierarchy/android.widget.FrameLayout")));
            Assert.That(lp.invalidCredentialsMsg.Displayed);
        }

        [Test]

        public void TestRequiredMsgs()
        {
            LoginPage lp = new LoginPage(TestBase.driver);

            TestBase.wait.Until(ExpectedConditions.ElementToBeClickable(lp.email));
            lp.DoLogin(" ", " ");
            //lp.email.SendKeys("abc");
            //lp.email.Clear();
            //lp.password.SendKeys("abc");
            //lp.password.Clear();
            Assert.That(lp.usernameErrorMsg.Displayed && lp.passwordErrorMsg.Displayed);

        }

    }
}
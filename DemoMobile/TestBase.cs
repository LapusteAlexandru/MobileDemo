using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoMobile
{
    class TestBase
    {


        public static AndroidDriver<AndroidElement> _driver { get; set; }
        public static void rootInit()
        {
            var cap = new AppiumOptions();
            cap.AddAdditionalCapability(MobileCapabilityType.DeviceName, "Nexus");
            cap.AddAdditionalCapability(MobileCapabilityType.PlatformVersion, "10.0");
            cap.AddAdditionalCapability(MobileCapabilityType.App, "C:/Users/alexandru.lapuste/Desktop/Smcs.MobileClient.Droid.apk");
            cap.AddAdditionalCapability(MobileCapabilityType.PlatformName, "Android");
            cap.AddAdditionalCapability(MobileCapabilityType.FullReset, true);
            _driver = new AndroidDriver<AndroidElement>(new Uri("http://127.0.0.1:4723/wd/hub"), cap);
        }

        
    }
}

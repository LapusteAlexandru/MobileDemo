using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoMobile
{
    public class ByAccesibilityID : By
    {
        public ByAccesibilityID(string locator)
        {
            FindElementMethod = (ISearchContext context) => context.FindElement(MobileBy.AccessibilityId(locator));
        }
        
    }
}

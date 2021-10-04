using System;
using OpenQA.Selenium;

namespace Hound.B3.WebScraping.Selenium.Extensions
{
    internal static class SeleniumWebDriverExtensions
    {
        public static bool ElementExists(this IWebDriver webDriver, By by)
        {
            try
            {
                webDriver.FindElement(by);
            }
            catch (NoSuchElementException)
            {
                return false;
            }

            return true;
        }
    }
}
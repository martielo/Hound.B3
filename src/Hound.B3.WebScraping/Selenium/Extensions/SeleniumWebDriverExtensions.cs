using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

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

        public static bool TrySelectByText(this SelectElement selectElement, string text, bool partialMatch = false)
        {
            try
            {
                selectElement.SelectByText(text, partialMatch: partialMatch);
            }
            catch (NoSuchElementException)
            {
                return false;
            }

            return true;
        }
    }
}
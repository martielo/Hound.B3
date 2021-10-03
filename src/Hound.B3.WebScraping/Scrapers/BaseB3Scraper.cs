using System;
using Hound.B3.WebScraping.Selenium;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Hound.B3.WebScraping.Scrapers
{
    public abstract class BaseB3Scraper
    {
        protected IWebDriver NewHeadlessChromeDriverInstance(TimeSpan? implicitWait = null)
        {
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("headless");

            var chromeService = ChromeDriverService.CreateDefaultService(Environment.GetEnvironmentVariable("CHROME_DRIVER_PATH"));
            chromeService.HideCommandPromptWindow = true;

            var driver = new HoundB3WebDriver(new ChromeDriver(chromeService, chromeOptions));

            if (implicitWait.HasValue)
                driver.Manage().Timeouts().ImplicitWait = implicitWait.Value;
            
            return driver;

        }
    }
}
using System.Collections.Generic;
using System;
using System.Collections.ObjectModel;
using OpenQA.Selenium;

namespace Hound.B3.WebScraping.Selenium
{
    internal class HoundB3WebDriver : IWebDriver
    {
        private readonly IWebDriver _webDriver;

        public HoundB3WebDriver(
            IWebDriver webDriver
        )
        {
            if (webDriver == null) throw new ArgumentNullException(nameof(webDriver));
            
            _webDriver = webDriver;
        }

        public string Url { get => _webDriver.Title; set => _webDriver.Url = value; }

        public string Title => _webDriver.Title;

        public string PageSource => _webDriver.PageSource;

        public string CurrentWindowHandle => _webDriver.CurrentWindowHandle;

        public ReadOnlyCollection<string> WindowHandles => _webDriver.WindowHandles;

        public void Close() => _webDriver.Close();

        public void Dispose() => _webDriver.Dispose();

        public IWebElement FindElement(By by)
        {
            return new HoundB3WebElement(_webDriver.FindElement(by), this, by);
        }

        public ReadOnlyCollection<IWebElement> FindElements(By by)
        {
            var webElements = new List<IWebElement>();

            foreach (var webElement in _webDriver.FindElements(by))
            {
                webElements.Add(new HoundB3WebElement(webElement, this, by));
            }

            return new ReadOnlyCollection<IWebElement>(webElements);
        }

        public IOptions Manage() => _webDriver.Manage();

        public INavigation Navigate() => _webDriver.Navigate();

        public void Quit() => _webDriver.Quit();

        public ITargetLocator SwitchTo() => _webDriver.SwitchTo();
    }
}
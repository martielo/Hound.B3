using System;
using System.Collections.ObjectModel;
using System.Drawing;
using OpenQA.Selenium;

namespace Hound.B3.WebScraping.Selenium
{
    internal class HoundB3WebElement : IWebElement
    {
        private IWebElement _webElement;
        private readonly HoundB3WebDriver _houndB3WebDriver;
        private readonly By _by;

        private const int MaxRetries = 10;

        public HoundB3WebElement(
            IWebElement webElement,
            HoundB3WebDriver houndB3WebDriver,
            By by
        )
        {
            _webElement = webElement;
            _houndB3WebDriver = houndB3WebDriver;
            _by = by;
        }

        public string TagName => _webElement.TagName;

        public string Text => GetText();

        public bool Enabled => _webElement.Enabled;

        public bool Selected => _webElement.Selected;

        public Point Location => _webElement.Location;

        public Size Size => _webElement.Size;

        public bool Displayed => _webElement.Displayed;

        public void Clear() => _webElement.Clear();

        public void Click() => _webElement.Click();

        public IWebElement FindElement(By by) => _webElement.FindElement(by);

        public ReadOnlyCollection<IWebElement> FindElements(By by) => _webElement.FindElements(by);

        public string GetCssValue(string propertyName) => _webElement.GetCssValue(propertyName);

        public string GetProperty(string propertyName) => _webElement.GetProperty(propertyName);

        public void SendKeys(string text) => _webElement.SendKeys(text);

        public void Submit() => _webElement.Submit();

        public string GetAttribute(string attributeName) => GetFromWebElementWithRetry(() => _webElement.GetAttribute(attributeName));

        private string GetText() => GetFromWebElementWithRetry(() => _webElement.Text);

        private dynamic GetFromWebElementWithRetry(Func<dynamic> func)
        {
            int retries = 0;

            dynamic @dynamic = default;

            while (retries < MaxRetries)
            {
                try
                {
                    @dynamic = func.Invoke();
                    return @dynamic;
                }
                catch (StaleElementReferenceException) { _webElement = RefreshElement(); }

                retries++;
            }

            throw new StaleElementReferenceException($"Element is still stale after {MaxRetries} retries.");
        }

        private IWebElement RefreshElement()
        {
            return _houndB3WebDriver.FindElement(_by);
        }
    }
}
using System;
using System.Collections.Generic;
using Hound.B3.Core;
using Hound.B3.WebScraping.Abstractions;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace Hound.B3.WebScraping.Scrapers
{
    public class FiisListadosScraper : BaseB3FiiScraper, IFiisListadosScraper
    {
        public IEnumerable<Fii> ObterFiisListados()
        {
            var fiis = new List<Fii>();

            using (var driver = NewHeadlessChromeDriverInstance())
            {
                driver.Navigate().GoToUrl(Constants.B3ListadosFiiUrl);

                short quantidadeFiis;

                CarregarListaFiisCompleta(driver, out quantidadeFiis);

                for (short i = 1; i <= quantidadeFiis; i++)
                {
                    var nomeFiiElement = driver.FindElement(By.XPath($"//*[@id=\"nav-bloco\"]/div/div[{i}]/a/div/div/h5"));
                    var nomePregaoElement = driver.FindElement(By.XPath($"//*[@id=\"nav-bloco\"]/div/div[{i}]/a/div/div/p[2]"));
                    
                    var fii = new Fii(nomeFiiElement.Text, nomePregaoElement.Text);
                    fiis.Add(fii);
                }
            }

            return fiis;
        }

        private void CarregarListaFiisCompleta(IWebDriver driver, out short quantidadeFiis)
        {
            var quantidadeFiisListadosElement = driver.FindElement(By.XPath("//*[@id=\"divContainerIframeB3\"]/form/div[1]/div/p/strong[1]"));
            short quantidadeFiisListados = short.Parse(quantidadeFiisListadosElement.Text.Trim());
            ((IJavaScriptExecutor)driver).ExecuteScript($"var element = document.getElementById('selectPage'); element[1].value = {quantidadeFiisListados}");

            var selectPageElement = new SelectElement(driver.FindElement(By.Id("selectPage")));
            selectPageElement.SelectByIndex(1);

            quantidadeFiis = quantidadeFiisListados;
        }
    }
}
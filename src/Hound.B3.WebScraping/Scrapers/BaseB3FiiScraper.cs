using System;
using Hound.B3.Core;
using OpenQA.Selenium;

namespace Hound.B3.WebScraping.Scrapers
{
    public abstract class BaseB3FiiScraper : BaseB3Scraper
    {
        protected IWebDriver NavegarParaPaginaSobreOFundo(IWebDriver driver, Fii fii)
        {
            if (string.IsNullOrEmpty(fii.IdB3))
            {
                return NavegarParaPaginaSobreOFundoSemIdB3(driver, fii);
            }

            return NavegarPagaPaginaSobreOFundoComIdB3(driver, fii);
        }

        protected void AvancarPaginacaoSeNecessario(IWebDriver driver, ref int index, ref int quantidadeItensCategoria)
        {
            const int maximoItensPorPagina = 4;

            int elemento = index - 1;

            if (elemento % maximoItensPorPagina == 0 && elemento != 0)
            {
                quantidadeItensCategoria = quantidadeItensCategoria - maximoItensPorPagina;

                var proximaPaginaElement = driver.FindElement(By.XPath("//*[@id=\"listing_pagination\"]/pagination-template/ul/li[5]/a"));
                proximaPaginaElement.Click();

                index = 1;
            }
        }

        private IWebDriver NavegarPagaPaginaSobreOFundoComIdB3(IWebDriver driver, Fii fii)
        {
            driver.Navigate().GoToUrl(new Uri(Constants.B3ListadosBaseUrl, $"fundsPage/main/{fii.IdB3}/{fii.Nome}/7/about"));
            return driver;
        }

        private IWebDriver NavegarParaPaginaSobreOFundoSemIdB3(IWebDriver driver, Fii fii)
        {
            driver.Navigate().GoToUrl(Constants.B3ListadosFiiUrl);

            var palavraChaveElement = driver.FindElement(By.Id("palavrachave"));
            palavraChaveElement.SendKeys(fii.Nome);

            var botaoBuscarElement = driver.FindElement(By.XPath("//*[@id=\"divContainerIframeB3\"]/form/div[1]/div/div/div[1]/div/div[2]/button"));
            botaoBuscarElement.Click();

            var cardFiiElement = driver.FindElement(By.XPath("//*[@id=\"nav-bloco\"]/div/div/a/div"));
            cardFiiElement.Click();

            return driver;
        }
    }
}
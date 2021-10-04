using System;
using Hound.B3.Core;
using Hound.B3.WebScraping.Abstractions;
using Hound.B3.WebScraping.Selenium.Extensions;
using OpenQA.Selenium;

namespace Hound.B3.WebScraping.Scrapers
{
    public class DetalhesSobreOFiiScraper : BaseB3FiiScraper, IDetalhesSobreOFiiScraper
    {
        public Fii ObterDetalhesSobreOFii(Fii fii)
        {
            using (var driver = NewHeadlessChromeDriverInstance(TimeSpan.FromSeconds(5)))
            {
                NavegarParaPaginaSobreOFundo(driver, fii);

                bool ehNegociado = driver.ElementExists(By.XPath("//*[@id=\"divContainerIframeB3\"]/app-funds-about/div/div[1]/div[1]/div/div/a"));

                var cnpjFiiElement = driver.FindElement(By.XPath("//*[@id=\"divContainerIframeB3\"]/app-funds-about/div/div[1]/div[1]/div/div/p[6]"));
                var siteFiiElement = driver.FindElement(By.XPath("//*[@id=\"divContainerIframeB3\"]/app-funds-about/div/div[1]/div[1]/div/div/p[8]/a"));
                var classificacaoSetorialElement = driver.FindElement(By.XPath("//*[@id=\"divContainerIframeB3\"]/app-funds-about/div/div[1]/div[1]/div/div/p[10]"));
                var quantidadeCotasEmitidasElement = driver.FindElement(By.XPath("//*[@id=\"divContainerIframeB3\"]/app-funds-about/div/div[1]/div[1]/div/div/p[12]"));

                string cnpjFii = cnpjFiiElement.Text;
                string siteFii = siteFiiElement.Text;
                string[] setores = classificacaoSetorialElement.Text.Split('/');
                string[] quantidadeEDataCotasEmitidas = quantidadeCotasEmitidasElement.Text.Split('-');

                int quantidadeCotasEmitidas = int.Parse(quantidadeEDataCotasEmitidas[0].Trim().Replace(".", string.Empty));
                var dataUltimasCotasEmitidas = DateTime.Parse(quantidadeEDataCotasEmitidas[1].Trim());

                var sobreOFii = new SobreOFii(
                    ehNegociado,
                    cnpjFii,
                    siteFii,
                    quantidadeCotasEmitidas,
                    dataUltimasCotasEmitidas
                );

                fii.AdicionarDetalhesSobreOFii(sobreOFii);
            }

            return fii;
        }
    }
}
using System.Collections.Generic;
using System;
using Hound.B3.Core;
using Hound.B3.WebScraping.Abstractions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Hound.B3.WebScraping.Scrapers
{
    public class InformacoesRelevantesFiiScraper : BaseB3FiiScraper, IInformacoesRelevantesFiiScraper
    {
        private const string BaseXPathIframB3FundsInformation = "//*[@id=\"divContainerIframeB3\"]/app-funds-information/";
        
        public Fii ObterInformacoesRelevantes(Fii fii)
        {
            var relatorios = new List<Relatorio>();

            using (var driver = NewHeadlessChromeDriverInstance(implicitWait: TimeSpan.FromSeconds(5)))
            {
                driver.Navigate().GoToUrl(new Uri(Constants.B3ListadosBaseUrl, $"fundsPage/main/{fii.IdB3}/{fii.Nome}/7/information"));

                var selectCategoryElement = new SelectElement(driver.FindElement(By.Id("selectCategory")));
                selectCategoryElement.SelectByText("Relatórios", partialMatch: true);

                string textoCategoria = selectCategoryElement.SelectedOption.Text;
                int quantidadeItensCategoria = int.Parse(textoCategoria.Split(" ")[1].Replace("(", string.Empty).Replace(")", string.Empty));

                var buscarElement = driver.FindElement(By.XPath($"{BaseXPathIframB3FundsInformation}div/form/div/div[3]/button"));
                buscarElement.Click();

                for (int i = 1; i <= quantidadeItensCategoria; i++)
                {
                    AvancarPaginacaoSeNecessario(driver, ref i, ref quantidadeItensCategoria);

                    var apresentacaoElement = driver.FindElement(By.XPath($"{BaseXPathIframB3FundsInformation}div/div[2]/div/div[{i}]/div[2]/div/div[3]/div[2]/p/a"));
                    var dataReferenciaElement = driver.FindElement(By.XPath($"{BaseXPathIframB3FundsInformation}div/div[2]/div/div[{i}]/div[1]/table/tbody/tr[1]/td[2]"));
                    var dataEntregaElement = driver.FindElement(By.XPath($"{BaseXPathIframB3FundsInformation}div/div[2]/div/div[{i}]/div[1]/table/tbody/tr[2]/td[2]"));
                    var tipoRelatorioElement = driver.FindElement(By.XPath($"{BaseXPathIframB3FundsInformation}div/div[2]/div/div[{i}]/div[1]/table/tbody/tr[3]/td[2]"));

                    relatorios.Add(
                        new Relatorio(
                            DateTime.Parse(dataReferenciaElement.Text),
                            DateTime.Parse(dataEntregaElement.Text),
                            apresentacaoElement.GetAttribute("href").Replace("visualizar", "exibir")
                        )
                    );
                }

                fii.AdicionarInformacaoRelevante(new InformacaoRelevante("2021", "1111").AdicionarRelatorios(relatorios));
            }

            return fii;
        }
    }
}
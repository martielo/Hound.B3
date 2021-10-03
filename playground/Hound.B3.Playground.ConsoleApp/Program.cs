using System;
using Hound.B3.Core;
using Hound.B3.WebScraping.Scrapers;
using Newtonsoft.Json;

namespace Hound.B3.Playground.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
 
            var informacoesRelevantesScraper = new InformacoesRelevantesFiiScraper();
            var ffis = informacoesRelevantesScraper.ObterInformacoesRelevantes(new Fii("AFHI", "AFHI"));

            Console.WriteLine(JsonConvert.SerializeObject(ffis));
            
            // var b3Scraper = new B3FiisScraper(new FiisListadosScraper(), new DetalhesSobreOFiiScraper());
            // var fiis = b3Scraper.ObterFiisListados();
            // var fii = b3Scraper.ObterDetalhesSobreOFii(new Fii("BZEL", "BZEL"));
          
          Console.Read();
        }
    }
}

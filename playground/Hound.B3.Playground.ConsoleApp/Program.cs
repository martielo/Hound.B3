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
 
            // var fiiAFHI = new InformacoesRelevantesFiiScraper().ObterInformacoesRelevantes(new Fii("AFHI", string.Empty).AdicionarIdB3("36642293000158"));
            // var fiiALZR = new InformacoesRelevantesFiiScraper().ObterInformacoesRelevantes(new Fii("ALZR", string.Empty).AdicionarIdB3("28737771000185"));
            // var fiiKNRI = new InformacoesRelevantesFiiScraper().ObterInformacoesRelevantes(new Fii("KNRI", string.Empty).AdicionarIdB3("12005956000165"));
            // var fiiHGLG = new InformacoesRelevantesFiiScraper().ObterInformacoesRelevantes(new Fii("HGLG", string.Empty).AdicionarIdB3("11728688000147"));

            // Console.WriteLine(JsonConvert.SerializeObject(fiiAFHI));
            // Console.WriteLine(JsonConvert.SerializeObject(fiiALZR));
            // Console.WriteLine(JsonConvert.SerializeObject(fiiKNRI));
            // Console.WriteLine(JsonConvert.SerializeObject(fiiHGLG));

            var b3Scraper = new B3FiisScraper(new FiisListadosScraper(), new DetalhesSobreOFiiScraper());
            var fiis = b3Scraper.ObterFiisListados();

            foreach (var fii in fiis)
            {
                var fiiDetalhado = b3Scraper.ObterDetalhesSobreOFii(fii);
                var fiiComIfomacoesRelevantes = new InformacoesRelevantesFiiScraper().ObterInformacoesRelevantes(fii);

                Console.WriteLine(JsonConvert.SerializeObject(fiiComIfomacoesRelevantes));

            }
          
          Console.Read();
        }
    }
}

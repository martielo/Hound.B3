using Hound.B3.Core;

namespace Hound.B3.WebScraping.Abstractions
{
    public interface IInformacoesRelevantesFiiScraper
    {
        Fii ObterInformacoesRelevantes(Fii fii);
    }
}
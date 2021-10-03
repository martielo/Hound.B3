using System.Collections.Generic;
using Hound.B3.Core;

namespace Hound.B3.WebScraping.Abstractions
{
    public interface IFiisListadosScraper
    {
        IEnumerable<Fii> ObterFiisListados();
    }
}
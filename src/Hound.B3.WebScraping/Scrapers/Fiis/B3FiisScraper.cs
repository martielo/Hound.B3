using System.Collections.Generic;
using System;
using Hound.B3.Core;
using Hound.B3.WebScraping.Abstractions;

namespace Hound.B3.WebScraping.Scrapers
{
    public class B3FiisScraper
    {
        private readonly IDetalhesSobreOFiiScraper _detalhesSobreOFiiScraper;
        private readonly IFiisListadosScraper _fiisListadosScraper;

        public B3FiisScraper(
            IFiisListadosScraper fiisListadosScraper,
            IDetalhesSobreOFiiScraper detalhesSobreOFiiScraper
        )
        {
            if (fiisListadosScraper == null) throw new ArgumentNullException(nameof(fiisListadosScraper));
            if (detalhesSobreOFiiScraper == null) throw new ArgumentNullException(nameof(detalhesSobreOFiiScraper));
            
            _fiisListadosScraper = fiisListadosScraper;
            _detalhesSobreOFiiScraper = detalhesSobreOFiiScraper;
        }
        
        public IEnumerable<Fii> ObterFiisListados() => _fiisListadosScraper.ObterFiisListados();
        public Fii ObterDetalhesSobreOFii(Fii fii) => _detalhesSobreOFiiScraper.ObterDetalhesSobreOFii(fii);
    }
}
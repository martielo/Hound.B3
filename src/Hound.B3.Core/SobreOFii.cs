using System;
using System.Collections.Generic;

namespace Hound.B3.Core
{
    public class SobreOFii
    {
        public bool EhNegociado { get; private set; }
        public string CNPJ { get; private set; }
        public string Site { get; private set; }
        public ICollection<ClassificacaoSetorial> ClassificacoesSetoriais { get; private set; }
        public int QuantidadeCotasEmitidas { get; private set; }
        public DateTime UltimaDataCotasEmitidas { get; private set; }

        public SobreOFii(
            bool ehNegociado,
            string cnpj,
            string site,
            int quantidadeCotasEmitidas,
            DateTime ultimaDataCotasEmitidas
        )
        {
            EhNegociado = ehNegociado;
            CNPJ = cnpj;
            Site = site;
            QuantidadeCotasEmitidas = quantidadeCotasEmitidas;
            UltimaDataCotasEmitidas = ultimaDataCotasEmitidas;
        }

        public SobreOFii AdicionarClassificacaoSetorial(ClassificacaoSetorial classificacaoSetorial)
        {
            ClassificacoesSetoriais.Add(classificacaoSetorial);
            return this;
        }
    }
}
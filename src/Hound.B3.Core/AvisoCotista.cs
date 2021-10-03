using System;

namespace Hound.B3.Core
{
    public class AvisoCotista
    {
        public short QuantidadeAvisos { get; private set; }
        public DateTime DataReferencia { get; private set; }
        public DateTime DataEntrega { get; private set; }
        public string Assunto { get; private set; }
        public string UrlDocumento { get; private set; }

        public AvisoCotista(
            short quantidadeAvisos,
            DateTime dataReferencia,
            DateTime dataEntrega,
            string assunto,
            string urlDocumento
        )
        {
            QuantidadeAvisos = quantidadeAvisos;
            DataReferencia = dataReferencia;
            DataEntrega = dataEntrega;
            Assunto = assunto;
            UrlDocumento = urlDocumento;
        }
    }
}
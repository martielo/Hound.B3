using System;

namespace Hound.B3.Core
{
    public class Relatorio
    {
        public DateTime DataReferencia { get; private set; }
        public DateTime DataEntrega { get; private set; }
        public string UrlDocumento { get; private set; }

        public Relatorio(
            DateTime dataReferencia,
            DateTime dataEntrega,
            string urlDocumento
        )
        {
            DataReferencia = dataReferencia;
            DataEntrega = dataEntrega;
            UrlDocumento = urlDocumento;
        }
    }
}
using System;

namespace Hound.B3.WebScraping
{
    public static class Constants
    {
        public static Uri B3ListadosBaseUrl { get; } = new Uri("https://sistemaswebb3-listados.b3.com.br/");
        public static Uri B3ListadosFiiUrl { get; } = new Uri(B3ListadosBaseUrl, "fundsPage/7");
    }
}
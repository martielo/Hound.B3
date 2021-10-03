using System.Collections.Generic;

namespace Hound.B3.Core
{
    public class InformacaoRelevante
    {
        public string Ano { get; private set; }
        public string Categoria { get; private set; }
        public ICollection<AvisoCotista> AvisoAosCotistas { get; private set; }
        public ICollection<Relatorio> Relatorios { get; private set; }

        public InformacaoRelevante(
            string ano,
            string categoria
        )
        {
            Ano = ano;
            Categoria = categoria;

            AvisoAosCotistas = new List<AvisoCotista>();
            Relatorios = new List<Relatorio>();
        }

        public InformacaoRelevante AdicionarRelatorio(Relatorio relatorio)
        {
            Relatorios.Add(relatorio);
            return this;
        }

        public InformacaoRelevante AdicionarRelatorios(ICollection<Relatorio> relatorios)
        {
            (Relatorios as List<Relatorio>).AddRange(relatorios);
            return this;
        }
    }
}
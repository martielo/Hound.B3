using System.Collections.Generic;
using System;

namespace Hound.B3.Core
{
    public class Fii
    {
        public Guid Id { get; private set; }
        public string IdB3 { get; private set; }
        public string Nome { get; private set; }
        public string CodigoNegociacao { get; private set; }
        public string NomeDoPregao { get; private set; }
        public SobreOFii SobreOFii { get; private set; }
        public ICollection<InformacaoRelevante> InformacoesRelevantes { get; private set; }

        public Fii(
            string nome,
            string nomeDoPregao
        )
        {
            Id = Guid.NewGuid();
            Nome = nome;
            NomeDoPregao = nomeDoPregao;
            CodigoNegociacao = $"{Nome}11";
            IdB3 = "36642293000158"; //FHI

            InformacoesRelevantes = new List<InformacaoRelevante>();
        }

        public Fii AdicionarDetalhesSobreOFii(SobreOFii sobreOFii)
        {
            SobreOFii = sobreOFii;
            IdB3 = sobreOFii.CNPJ.Replace(".", string.Empty).Replace("/", string.Empty).Replace("-", string.Empty);
            return this;
        }

        public Fii AdicionarInformacaoRelevante(InformacaoRelevante informacaoRelevante)
        {
            InformacoesRelevantes.Add(informacaoRelevante);
            return this;
        }
    }
}
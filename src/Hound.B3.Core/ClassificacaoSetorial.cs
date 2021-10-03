namespace Hound.B3.Core
{
    public class ClassificacaoSetorial
    {
        public string NomeSetor { get; private set; }

        public ClassificacaoSetorial(
            string nomeSetor
        )
        {
            NomeSetor = nomeSetor;
        }
    }
}
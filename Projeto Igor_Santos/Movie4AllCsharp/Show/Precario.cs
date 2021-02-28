using System;

namespace Movie4AllCsharp
{
    public class Precario
    {
        public DateTime DataInicio { get; set; }
        public DateTime DataAtual { get; set; }
        public Show Show { get; set; }
        public int Preco { get; set; }

        public Precario()
        {

        }
        public Precario(Show show, int preco, DateTime dataAtual)
        {
            Show = show;
            Preco = preco;
            DataInicio = DateTime.Now;
            DataAtual = dataAtual;
        }

    }
}

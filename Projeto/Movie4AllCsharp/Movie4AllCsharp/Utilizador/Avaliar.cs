using System;

namespace Movie4AllCsharp
{
    public class Avaliar
    {
        public int Id { get; set; }
        public DateTime DataUpdate { get; set; }
        public Show Nome { get; set; }
        public string Descricao { get; set; }
        public int Stars { get; set; }

        public Avaliar()
        {

        }

        public Avaliar(Show nome, DateTime dataUp, int stars, string descricao)
        {
            Nome = nome;
            DataUpdate = dataUp;
            Stars = stars;
            Descricao = descricao;
        }
    }
}

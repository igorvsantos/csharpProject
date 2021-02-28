using System.Collections.Generic;

namespace Movie4AllCsharp
{
        public class Temporada
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Numero { get; set; }
        public List<Episodio> Episodios { get; set; }

        public Temporada()
        {

        }

        public Temporada(int id, string nome, int numero)
        {
            Id = id;
            Nome = nome;
            Numero = numero;
            Episodios = new List<Episodio>();
        }
    }
}

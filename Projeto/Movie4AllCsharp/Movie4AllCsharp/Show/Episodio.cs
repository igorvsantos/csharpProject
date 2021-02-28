using System;

namespace Movie4AllCsharp
{
    public class Episodio
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Numero { get; set; }
        public DateTime Data { get; set; }

        public Episodio()
        {

        }

        public Episodio(int id, string nome, int numero, DateTime data)
        {
            Id = id;
            Nome = nome;
            Numero = numero;
            Data = data;
        }
    }
}

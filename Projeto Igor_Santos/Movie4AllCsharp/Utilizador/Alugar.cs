using System;
using System.Collections.Generic;

namespace Movie4AllCsharp
{
    public class Alugar
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public Show Nome { get; set; }

        public Alugar()
        {

        }

        public Alugar(Show nome, DateTime data, int id)
        {
            Nome = nome;
            Data = data;
            Id = id;
        }
    }
}

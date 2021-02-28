using Movie4AllCsharp;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;

namespace Movie4AllCsharp
{
    public abstract class Show
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public int Ano { get; set; }
        public string CodPais { get; set; }
        public List<Atores> Atores { get; set; }

        public List<Precario> Precarios { get; set; }
    }

    public class Filme : Show
    {
        public Filme()
        {
        }

        public Filme(string titulo, int ano, string codPais, int id)
        {
            Titulo = titulo;
            Ano = ano;
            CodPais = codPais;
            Id = id;
            Atores = new List<Atores>();
            Precarios = new List<Precario>();
        }

        public Filme(string line)
        {
            var split = line.Split(',');
            Id = int.Parse(split[0]);
            Titulo = split[1];
            CodPais = split[2];
        }

    }



    public class Serie : Show
    {
        public List<Temporada> Temporadas { get; set; }
        public Serie()
        {

        }

        public Serie(string titulo, int ano, string codPais, int id)
        {
            Titulo = titulo;
            Ano = ano;
            CodPais = codPais;
            Id = id;
            Atores = new List<Atores>();
            Temporadas = new List<Temporada>();
            Precarios = new List<Precario>();
        }
    }

    public class Documentario : Show
    {
        public Documentario()
        {

        }
        public Documentario(string titulo, int ano, string codPais, int id)
        {
            Titulo = titulo;
            Ano = ano;
            CodPais = codPais;
            Id = id;
            Atores = new List<Atores>();
            Precarios = new List<Precario>();
        }


    }
}

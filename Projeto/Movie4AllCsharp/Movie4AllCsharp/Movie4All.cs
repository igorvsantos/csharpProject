using System.Collections.Generic;

namespace Movie4AllCsharp
{
    public class Movie4All
    {
        public List<Show> Filmes { get; set; }

        public List<Utilizador> Utilizadores { get; set; }

        public Movie4All()
        {
            Filmes = new List<Show>();
            Utilizadores = new List<Utilizador>();
        }

    }
}

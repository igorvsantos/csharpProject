namespace Movie4AllCsharp
{
    public class Atores
{
        public string Nome { get; set; }
        public string Nickname { get; set; }
        public string Genero{ get; set; }

        public Atores()
        {

        }

        public Atores(string nome, string nickname, string genero)
        {
            Nome = nome;
            Nickname = nickname;
            Genero = genero;
        }
    }

}

namespace Movie4AllCsharp
{
    public class Cartao 
    {
        public int Id { get; set; }
        public int Mes { get; set; }
        public int Ano { get; set; }
        public int Numero { get; set; }
        public int Cvc { get; set; }
        public string NomeTitular { get; set; }

        public Cartao()
        {

        }

        public Cartao(int id, int mes, int ano, int numero, int cvc, string nomeTitular)
        {
            Id = id;
            Mes = mes;
            Ano = ano;
            Numero = numero;
            Cvc = cvc;
            NomeTitular = nomeTitular;
        }
    }
}

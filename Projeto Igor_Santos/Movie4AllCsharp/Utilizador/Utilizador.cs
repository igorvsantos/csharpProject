using System;
using System.Collections.Generic;

namespace Movie4AllCsharp
{
    public class Utilizador 
    {
        public string User { get; set; }
        public string Email { get; set; }
        public int NumFiscal { get; set; }
        public int Telemovel { get; set; }

        public List<Alugar> Aluguer { get; set; }

        public List<Avaliar> Avaliar { get; set; }
        public List<Cartao> Cartao { get; set; }

        public Utilizador() 
        {
            
        }

        public Utilizador(string user, string email, int numFiscal, int telemovel)
        {          
            User = user;
            Email = email;
            NumFiscal = numFiscal;
            Telemovel = telemovel;
            Aluguer = new List<Alugar>();
            Avaliar = new List<Avaliar>();
            Cartao = new List<Cartao>();
            Console.WriteLine("Utilizador criado");
        }
        
    }
}

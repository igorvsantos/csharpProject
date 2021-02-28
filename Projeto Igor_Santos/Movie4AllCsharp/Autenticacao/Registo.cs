using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Movie4AllCsharp
{
    public static class Registo

    {
        public static void Registar(Movie4All movie4all)
        {
            var utilizadores = movie4all.Utilizadores;

            Console.Clear();
            Console.WriteLine("Inserir username");
            string user = Console.ReadLine();
            if (utilizadores.Any(i => i.User == user))
                Console.WriteLine("User já existe, Tente outro");
            else
            {

                Console.WriteLine("Inserir email");
                string email = Console.ReadLine();

                Console.WriteLine("Inserir Contribuinte");
                int numFiscal;
                while (!int.TryParse(Console.ReadLine(), out numFiscal))
                {
                    Console.WriteLine("Contribuinte inválido");
                    Console.WriteLine("Introduza um contribuinte correto");
                }

                Console.WriteLine("Inserir Telemóvel");
                int telemovel;
                while (!int.TryParse(Console.ReadLine(), out telemovel))
                {
                    Console.WriteLine("Telemóvel inválido");
                    Console.WriteLine("Introduza um número correto");
                }

                //Criação do Utilizador
                utilizadores.Add(new Utilizador(user, email, numFiscal, telemovel));
            }
         
            Thread.Sleep(500);         
            Console.Clear();
        }
    }
}

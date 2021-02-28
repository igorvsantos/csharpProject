using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Movie4AllCsharp
{
    public static class Login
    {
        public static void Entrar( Movie4All movie4All)
        {
            var utilizadores = movie4All.Utilizadores;
           
            Console.Clear();
            Console.WriteLine("Login");
            Console.WriteLine("Inser Username");
            string userLogin = Console.ReadLine();

            if(utilizadores.Any(a=>a.User == userLogin.ToLower()))
            {   
                Console.WriteLine("Login Efetuado");
                Thread.Sleep(500);
                Console.Clear();
                MenuUtilizador.Home(movie4All, userLogin);
            }
                
            else if (userLogin.ToLower() == "admin")
            {
                Console.WriteLine("Olá Admin");
                Thread.Sleep(500);
                Console.Clear();
                MenuAdmin.Home(movie4All);
            }              
            else
            {
                Console.WriteLine("Wrong User");
                Thread.Sleep(500);
                Console.Clear();
                Menu.Home(movie4All);
            }           
        }
    }
}

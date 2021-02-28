using System;
using System.Collections.Generic;
using System.Threading;

namespace Movie4AllCsharp
{
    public class Menu
    {
        static int index = 0;
        public static void Home(Movie4All movie4all)
        {
            List<string> menuItem = new List<string>()
            {
            "Login",
            "Registar",
            "Sair",
            };

            while (true)
            {
                var verMenu = MostrarMenu(menuItem);
                if (verMenu == "Registar")
                {
                    Registo.Registar(movie4all);
                }
                else if (verMenu == "Login")
                {
                    Login.Entrar(movie4all);
                }
                else if (verMenu == "Sair")
                    break;               
            }
        }

        // Interagir com o Menu 
        public static string MostrarMenu(List<string> menuItem)
        {
            for (int i = 0; i < menuItem.Count; i++)
            {
                if (i == index)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(menuItem[i]);
                }
                else
                {
                    Console.WriteLine(menuItem[i]);
                }
                Console.ResetColor();
            }

            ConsoleKeyInfo key = Console.ReadKey();
            if (key.Key == ConsoleKey.DownArrow)
            {
                if (index == menuItem.Count - 1)
                    index = 0;
                else
                    index++;
            }
            else if (key.Key == ConsoleKey.UpArrow)
            {
                if (index <= 0)
                    index = menuItem.Count - 1;
                else
                    index--;
            }
            else if (key.Key == ConsoleKey.Enter)
            {
                return menuItem[index];
            }

            Console.Clear();
            return "";

        }

    }
}

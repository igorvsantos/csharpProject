using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;

namespace Movie4AllCsharp
{
    public static class MenuAdmin
    {
        static int index = 0;
        
        public static void Home(Movie4All movie4all)
        {
            List<string> menuItem = new List<string>()
            {
            "Adicionar Show",
            "Adicionar Temporada",
            "Adicionar Epsisódio",
            "Adicionar Atores",
            "Adicionar Preços",
            "Remover Show",
            "Ver Shows", 
            "Sair",
            };

            int id = 0;

            while (true)
            {
                var verMenu = Menu.MostrarMenu(menuItem);
                if (verMenu == "Adicionar Show")
                {
                    id++;
                    AdicionarShow(movie4all, id);
                }

                else if (verMenu == "Adicionar Atores")
                {
                    Console.Clear();
                    AdicionarAtores(movie4all);
                }

                else if (verMenu == "Remover Show")
                {
                    Console.Clear();
                    RemoverShow(movie4all);
                }

                else if (verMenu == "Ver Shows")
                {
                    Console.Clear();
                    MostrarFilmes(movie4all);
                }
                else if (verMenu == "Adicionar Temporada")
                {
                    Console.Clear();
                    AdicionarTemp(movie4all);                  
                }
                else if (verMenu == "Adicionar Epsisódio")
                {
                    Console.Clear();
                    AdicionarEpi(movie4all);
                }
                else if (verMenu == "Adicionar Preços")
                {
                    Console.Clear();
                    AdicionarPreco(movie4all);
                }
                else if (verMenu == "Sair")
                {
                    Console.Clear();
                    break;
                }
            }
        }

        public static string MenuFilmes(List<Show> menuItem)
        {   
            //Mostrar item destacado no Menu
            for (int i = 0; i < menuItem.Count; i++)
            {
                if (i == index)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(menuItem[i].Titulo);
                }
                else
                {
                    Console.WriteLine(menuItem[i].Titulo);
                }
                Console.ResetColor();
            }

            // Interagir com o Menu
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
                return menuItem[index].Titulo;
            }
            Console.Clear();
            return "";

        }

        public static void AdicionarShow(Movie4All movie4All, int id)
        {
            var show = movie4All.Filmes;
            bool goBack = false;

            while (!goBack)
            {               
                Console.Clear();

                Console.WriteLine("Tipo Show: Filme | Serie | Documentario");
                string tipo = Console.ReadLine();
                Console.Clear();

                Console.WriteLine("Adicionar {0}", tipo);
                Console.WriteLine("Inserir Titulo");
                string titulo = Console.ReadLine();
                Console.Clear();

                Console.WriteLine("Inserir Ano [yyyy]");
                int ano;
                while (!int.TryParse(Console.ReadLine(), out ano))
                {
                    Console.WriteLine("Ano inválido");
                    Console.WriteLine("Introduza um ano correto");
                }
                Console.Clear();

                Console.WriteLine("Inserir Codigo Pais");
                string codPais = Console.ReadLine();
                codPais = codPais.Substring(0, 2);

                if (tipo == "filme")
                {
                    var filme = new Filme(titulo.ToUpper(), ano, codPais.ToUpper(), id);
                    show.Add(filme);
                    Console.WriteLine("Adicionado");
                }
                else if (tipo == "serie")
                {
                    var serie = new Serie(titulo.ToUpper(), ano, codPais.ToUpper(), id);
                    show.Add(serie);
                    Console.WriteLine("Adicionado");
                }
                else if (tipo == "documentario")
                {
                    var documentario = new Documentario(titulo.ToUpper(), ano, codPais.ToUpper(), id);
                    show.Add(documentario);
                    Console.WriteLine("Adicionado");
                }
                else
                {
                    Console.WriteLine("Tipo de show não exite, tente de novo");
                    Thread.Sleep(500);
                }
                Thread.Sleep(500);
                Console.Clear();
                goBack = true;
            }
        }

        public static void AdicionarAtores(Movie4All movie4All)
        {
            var show = movie4All.Filmes;
            bool goBack = false;
            if (show.Count <= 0)
                DisplayInfo();
            else
            {
                while (!goBack)
                {
                    Console.Clear();

                    Console.WriteLine("Adicionar Atores");
                    Console.WriteLine("Qual o Show?");
                    string nomeShow = Console.ReadLine();
                    Console.Clear();

                    Console.WriteLine("Inserir Nome");
                    string nome = Console.ReadLine();
                    Console.Clear();

                    Console.WriteLine("Inserir Nickname");
                    string nickname = Console.ReadLine();
                    Console.Clear();

                    Console.WriteLine("Inserir Genero [F/M]");
                    string genero = Console.ReadLine();
                    genero = genero.Substring(0, 1);
                    Console.Clear();

                    var ator = new Atores(nome.ToUpper(), nickname.ToLower(), genero.ToUpper());

                    foreach (var item in show)
                    {
                        if (nomeShow.ToUpper() == item.Titulo)
                        {
                            item.Atores.Add(ator);
                            Console.WriteLine("Adicionado");
                        }
                        else
                            Console.WriteLine("Show não existe");
                    }
                    Thread.Sleep(500);
                    Console.Clear();
                    goBack = true;
                }
            }
        }

        public static void RemoverShow(Movie4All movie4all)
        {
            var show = movie4all.Filmes;
            bool goBack = false;

            if (show.Count <= 0)
                DisplayInfo();
            else
            {
                while (!goBack)
                {
                    Console.Clear();
                    Console.WriteLine("Remover Show");
                    Console.WriteLine("Inserir Titulo");
                    string titulo = Console.ReadLine();
                    Console.Clear();

                    foreach (var item in show)
                    {
                        if (titulo.ToUpper() == item.Titulo)
                        {
                            show.Remove(item);
                            Console.WriteLine("Removido");
                        }
                        else
                            Console.WriteLine("Show não existe");
                       
                        Thread.Sleep(500);
                        Console.Clear();
                        goBack = true;
                        break;
                    }

                }
            }
        }

        public static void MostrarFilmes(Movie4All movie4all)
        {
            var show = movie4all.Filmes;

            if (show.Count <= 0)           
                DisplayInfo();
            
            else
            {
                bool goBack = false;
                while (!goBack)
                {
                    var verMenu = MenuFilmes(show);
                    Console.Clear();
                    foreach (var item in show)
                    {
                        if (verMenu == item.Titulo)
                        {
                            Console.WriteLine("O show {0} ocorre no ano de {1} e foi filmado em {2}", item.Titulo, item.Ano, item.CodPais);
                            foreach (var preco in item.Precarios)
                            {
                                Console.WriteLine("O Preço deste show é: {0}", preco.Preco);
                            }
                            Console.WriteLine("Elenco:");
                            foreach (var ator in item.Atores)
                            {
                                Console.WriteLine("Ator: {0} do sexo {1} mas conhecido por {2} ", ator.Nome, ator.Genero, ator.Nickname);
                            }
                            Console.WriteLine("-------------------------------------------------------------------------------------");
                            Console.ReadLine();
                            goBack = true;
                            Console.Clear();
                        }
                    }

                }
            }
        }

        public static void AdicionarTemp(Movie4All movie4all)
        {
            var show = movie4all.Filmes;
            bool goBack = false;

            if (show.Count <= 0)
                DisplayInfo();
            else
            {
                while (!goBack)
                {
                    int id = 0;
                    Console.Clear();
                    Console.WriteLine("Adicionar Temporada");
                    Console.WriteLine("Inserir nome da série");
                    var nomeSerie = Console.ReadLine();

                    Console.WriteLine("Inserir nome da Temporada");
                    var nomeTemp = Console.ReadLine();

                    Console.WriteLine("Inserir número da Temporada");
                    int numero;
                    while (!int.TryParse(Console.ReadLine(), out numero))
                    {
                        Console.WriteLine("Introduza um número");
                    }

                    var Temporada = new Temporada(id, nomeTemp, numero);

                    foreach (var item in show)
                    {
                        if (item is Serie)
                        {
                            if (nomeSerie.ToUpper() == item.Titulo.ToUpper())
                            {
                                ((Serie)item).Temporadas.Add(Temporada);
                                Console.WriteLine("Adicionado");
                            }
                            else
                            {
                                Console.WriteLine("Serie não existe");
                                Thread.Sleep(500);
                                Console.Clear();
                            }
                        }
                        id++;
                    }                   
                    Thread.Sleep(500);
                    Console.Clear();
                    goBack = true;
                }
            }
        }

        public static void AdicionarEpi(Movie4All movie4all)
        {
            var show = movie4all.Filmes;
            bool goBack = false;

            if (show.Count <= 0)
                DisplayInfo();
            else
            {
                while (!goBack)
                {
                    int id = 0;
                    Console.Clear();
                    Console.WriteLine("Adicionar Temporada");
                    Console.WriteLine("Inserir nome da seríe");
                    var nomeSerie = Console.ReadLine();

                    Console.WriteLine("Inserir nome da Temporada");
                    var nomeTemp = Console.ReadLine();

                    Console.WriteLine("Inserir nome do Episódio");
                    var nomeEpi = Console.ReadLine();

                    Console.WriteLine("Inseir número do episódio");
                    int numeroEpi;
                    while (!int.TryParse(Console.ReadLine(), out numeroEpi))
                    {
                        Console.WriteLine("Introduza um número");
                    }


                    var Episodio = new Episodio(id, nomeEpi, numeroEpi, DateTime.Now);

                    foreach (var item in show)
                    {
                        if (item is Serie)
                        {
                            if (nomeSerie.ToUpper() == item.Titulo.ToUpper())
                            {
                                var a = ((Serie)item).Temporadas;
                                foreach (var item2 in a)
                                {
                                    //if (nomeTemp.ToUpper() == item2.Nome)                               
                                    item2.Episodios.Add(Episodio);
                                    Console.WriteLine("Adicionado");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Serie não existe");
                                Thread.Sleep(500);
                                Console.Clear();
                            }
                        }
                        id++;
                    }                   
                    Thread.Sleep(500);
                    Console.Clear();
                    goBack = true;
                }
            }
        }

        public static void AdicionarPreco(Movie4All movie4all)
        {
            var show = movie4all.Filmes;
            bool goBack = false;

             while (!goBack)
             {
                 Console.Clear();
                 Console.WriteLine("Definir Preço");
                 Console.WriteLine("Qual o tipo de Show? [filme/serie/documentario]");
                 string nomeShow = Console.ReadLine();

                 Console.WriteLine("Preço");
                 int preco;
                 while (!int.TryParse(Console.ReadLine(), out preco))
                 {
                     Console.WriteLine("Formato Preço inválido");
                 }

                Console.Clear();

                 foreach (var item in show)
                 {
                     var precario = new Precario(item, preco, DateTime.Now);
                    if (nomeShow == "serie")
                    {
                        if (item is Serie)
                            ((Serie)item).Precarios.Add(precario);
                    }
                    else if (nomeShow == "filme")
                    {
                        if (item is Filme)
                            ((Filme)item).Precarios.Add(precario);
                    }
                    else if (nomeShow == "documentario")
                    {
                        if (item is Documentario)
                            ((Documentario)item).Precarios.Add(precario);
                    }
                    else
                    {
                        Console.WriteLine("Tipo show errado. Tente novamente!");
                        Thread.Sleep(500);
                        Console.Clear();
                    }
                 }
                 Console.WriteLine("Adicionado");
                 Thread.Sleep(500);
                 Console.Clear();
                 goBack = true;
             }
        }

        public static void DisplayInfo()
        {
            Console.WriteLine("Não tem Shows");
            Console.WriteLine("Pressione uma tecla para voltar atrás");
            Console.ReadKey();
            Thread.Sleep(200);
            Console.Clear();
        }
    }
}

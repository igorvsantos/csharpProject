using System;
using System.Collections.Generic;
using System.Threading;

namespace Movie4AllCsharp
{
    public static class MenuUtilizador
    {
        //static int index = 0;

        public static void Home(Movie4All movie4all, string userLogin)
        {
            var utilizador = movie4all.Utilizadores;
            List<string> menuItem = new List<string>()
            {
            "Alugar Show",
            "Avaliar",
            "Historico alugueres",
            "Historico avaliações",
            "Dados da conta",
            "Adicionar Cartão",
            "Remover Cartão",
            "Sair",
            };

            while (true)
            {
                Console.WriteLine("Bem Vindo {0}, o que pretende fazer?", userLogin);
                var verMenu = Menu.MostrarMenu(menuItem);
                if (verMenu == "Alugar Show")
                {
                    Console.Clear();
                    AlugarShow(movie4all, userLogin);
                }
                else if (verMenu == "Avaliar")
                {
                    Console.Clear();
                    AvaliarShow(movie4all, userLogin);
                }
                else if (verMenu == "Historico alugueres")
                {
                    Console.Clear();
                    HistoricoShow(movie4all, userLogin);
                }
                else if (verMenu == "Historico avaliações")
                {
                    Console.Clear();
                    HistoricoAva(movie4all, userLogin);
                }
                else if (verMenu == "Dados da conta")
                {
                    Console.Clear();
                    DadosConta(movie4all, userLogin);
                }
                else if (verMenu == "Adicionar Cartão")
                {
                    Console.Clear();
                    AdicionarCartao(movie4all, userLogin);
                }
                else if (verMenu == "Remover Cartão")
                {
                    Console.Clear();
                    RemoverCartao(movie4all, userLogin);
                }
                else if (verMenu == "Sair")
                {
                    Console.Clear();
                    break;
                }
            }
        }

        public static void AlugarShow(Movie4All movie4all, string userLogin)
        {
            var utilizadores = movie4all.Utilizadores;
            var show = movie4all.Filmes;
            bool goBack = false;

            if (show.Count <= 0)
                MenuAdmin.DisplayInfo();
            else
            {
                while (!goBack)
                {
                    int id = 0;
                    var verMenu = MenuAdmin.MenuFilmes(show);
                    Console.Clear();
                    foreach (var item in show)
                    {
                        if (verMenu == item.Titulo)
                        {
                            Console.WriteLine("Pretende alugar {0}? [sim/nao]", item.Titulo);
                            string resposta = Console.ReadLine();
                            if (resposta.ToLower() == "sim")
                            {
                                var alugado = new Alugar(item, DateTime.Now, id);

                                if (item is Serie)
                                {
                                    Console.WriteLine("Digite o número da temporada");
                                    int temp;
                                    while (!int.TryParse(Console.ReadLine(), out temp))
                                    {
                                        Console.WriteLine("Temporada não existe");
                                        Console.WriteLine("Introduza novamente a Temporada");
                                    }

                                    Console.WriteLine("Digite o número do Episódio");
                                    int epi;
                                    while (!int.TryParse(Console.ReadLine(), out epi))
                                    {
                                        Console.WriteLine("Episódio não existe");
                                        Console.WriteLine("Introduza novamente o Episodio");
                                    }

                                    foreach (var tempo in ((Serie)item).Temporadas)
                                    {
                                        if (temp == tempo.Numero)
                                        {
                                            foreach (var episo in tempo.Episodios)
                                            {
                                                if (epi == episo.Numero)
                                                {
                                                    foreach (var item2 in utilizadores)
                                                    {
                                                        if (userLogin.ToUpper() == item2.User.ToUpper())
                                                            item2.Aluguer.Add(alugado);
                                                        Console.WriteLine("Serie: {0} , Temporada  {1}, Episodio {2} alugado com sucesso", item.Titulo, tempo.Numero, episo.Numero);
                                                    }
                                                }
                                            }
                                        }
                                    }                                   
                                }
                                else
                                {

                                    foreach (var item2 in utilizadores)
                                    {
                                        //var alugado = new Alugar(item, DateTime.Now, id);
                                        if (userLogin.ToUpper() == item2.User.ToUpper())
                                            item2.Aluguer.Add(alugado);
                                    }

                                    Console.WriteLine("{0} alugado com sucesso", item.Titulo);
                                }
                            }
                            Thread.Sleep(800);
                            goBack = true;
                            Console.Clear();
                        }
                        id++;
                    }
                }
            }
        }

        public static void HistoricoShow(Movie4All movie4all, string userLogin)
        {
            var utilizadores = movie4all.Utilizadores;
            bool goBack = false;

            while (!goBack)
            {
                Console.Clear();
                Console.WriteLine("Shows Alugados:");
                foreach (var item in utilizadores)
                {
                    if (userLogin.ToUpper() == item.User.ToUpper())
                    {
                        foreach (var u in item.Aluguer)
                        {
                            Console.WriteLine("Titulo: {0} | Dia Aluguer: {1} |", u.Nome.Titulo, u.Data);
                            Console.WriteLine("-------------------------------------------------------------------------");
                        }
                    }
                }
                Console.ReadLine();
                goBack = true;
                Console.Clear();
            }
        }

        public static void AvaliarShow(Movie4All movie4all, string userLogin)
        {
            var utilizadores = movie4all.Utilizadores;
            var show = movie4all.Filmes;

            if (show.Count <= 0)
                MenuAdmin.DisplayInfo();
            else
            {
                bool goBack = false;
                while (!goBack)
                {
                    int id = 0;
                    var verMenu = MenuAdmin.MenuFilmes(show);
                    Console.Clear();
                    foreach (var item in show)
                    {
                        if (verMenu == item.Titulo)
                        {
                            Console.WriteLine("Avaliação {0}", item.Titulo.ToUpper());
                            Console.WriteLine("Introduza a pontuação [1 a 5]");
                            int stars;
                            while (!int.TryParse(Console.ReadLine(), out stars))
                            {
                                Console.WriteLine("Formato de pontuação errada");
                                Console.WriteLine("Introduza um pontuação correta");
                            }

                            Console.WriteLine("Introduza descrição");
                            var descricao = Console.ReadLine();

                            var avaliado = new Avaliar(item, DateTime.Now, stars, descricao);

                            foreach (var user in utilizadores)
                            {
                                if (userLogin.ToUpper() == user.User.ToUpper())
                                    user.Avaliar.Add(avaliado);
                            }
                            Console.WriteLine("Avaliou {0} com sucesso", item.Titulo);
                        }
                        id++;
                        Thread.Sleep(600);
                        goBack = true;
                        Console.Clear();
                    }
                }
            }
        }

        public static void HistoricoAva(Movie4All movie4all, string userLogin)
        {
            var utilizadores = movie4all.Utilizadores;
            bool goBack = false;
            while (!goBack)
            {
                Console.Clear();
                Console.WriteLine("Shows Avaliados:");
                foreach (var user in utilizadores)
                {
                    if (userLogin.ToUpper() == user.User.ToUpper())
                    {
                        foreach (var u in user.Avaliar)
                        {
                            Console.WriteLine("Titulo: {0}", u.Nome.Titulo);
                            Console.WriteLine("Pontuação: {0} | Ultimo update: {1} |", u.Stars, u.DataUpdate);
                            Console.WriteLine("Opinião {0} ", u.Descricao);
                            Console.WriteLine("-----------------------------------------------------------------------------------");
                        }
                    }
                }
                Console.ReadLine();
                goBack = true;
                Console.Clear();
            }
        }

        public static void DadosConta(Movie4All movie4All, string userLogin)
        {
            var utilizadores = movie4All.Utilizadores;
            bool goBack = false;
            while (!goBack)
            {
                Console.Clear();
                Console.WriteLine("Dados da Conta:");
                foreach (var user in utilizadores)
                {
                    if (userLogin.ToUpper() == user.User.ToUpper())
                    {
                        Console.WriteLine("User: {0}", user.User);
                        Console.WriteLine("Email: {0}", user.Email);
                        Console.WriteLine("Contribuinte: {0} ", user.NumFiscal);
                        Console.WriteLine("Telemovel: {0}", user.Telemovel);
                        foreach (var cartao in user.Cartao)
                        {
                            Console.WriteLine("Número do cartão: {0}", cartao.Numero);
                        }
                        Console.WriteLine("-----------------------------------------------------------------------------------");
                    }
                }
                Console.ReadLine();
                goBack = true;
                Console.Clear();
            }

        }

        public static void AdicionarCartao(Movie4All movie4all, string userLogin)
        {
            var utilizadores = movie4all.Utilizadores;
            bool goBack = false;
            while (!goBack)
            {
                int id = 0;
                Console.Clear();
                Console.WriteLine("Adicionar Cartão");
                Console.WriteLine("Inserir nome do titular");
                var nomeTitular = Console.ReadLine();

                Console.WriteLine("Inserir CVC");
                int cvc;
                while (!int.TryParse(Console.ReadLine(), out cvc))
                {
                    Console.WriteLine("CVC inválido");
                    Console.WriteLine("Introduza um CVC correto");
                }

                Console.WriteLine("Inserir número");
                int numero;
                while (!int.TryParse(Console.ReadLine(), out numero))
                {
                    Console.WriteLine("Número cartão inválido");
                    Console.WriteLine("Introduza um número correto");
                }

                Console.WriteLine("Inserir mes");
                int mes;
                while (!int.TryParse(Console.ReadLine(), out mes))
                {
                    Console.WriteLine("Mês inválido");
                    Console.WriteLine("Introduza um mês correto");
                }
                if (mes > 12 || mes < 1)
                    Console.WriteLine("Mês invalido"); 

                Console.WriteLine("Inserir ano");
                int ano;
                while (!int.TryParse(Console.ReadLine(), out ano))
                {
                    Console.WriteLine("Ano inválido");
                    Console.WriteLine("Introduza um ano correto");
                }
                if (ano < 2020)
                    Console.WriteLine("Cartão expirado");


                var cartao = new Cartao(id, mes, ano, numero, cvc, nomeTitular);

                foreach (var item in utilizadores)
                {
                    if (userLogin.ToUpper() == item.User.ToUpper())
                    {
                        item.Cartao.Add(cartao);
                        Console.WriteLine("{0} adicionou cartão com sucesso", item.User);
                    }
                    id++;
                }
                Thread.Sleep(600);
                goBack = true;
                Console.Clear();
            }
        }

        public static void RemoverCartao(Movie4All movie4all, string userLogin)
        {
            var utilizadores = movie4all.Utilizadores;
            bool goBack = false;

                while (!goBack)
            {
                Console.Clear();
                Console.WriteLine("Remover Cartão");

                foreach (var item in utilizadores)
                {
                    if (userLogin.ToUpper() == item.User.ToUpper())
                    {
                        if (item.Cartao.Count <= 0)
                        {
                            Console.WriteLine("Não tem Cartões");
                            Console.WriteLine("Pressione uma tecla para voltar atrás");
                            Console.ReadKey();
                            Thread.Sleep(200);
                            Console.Clear();
                            goBack = true;
                            break;
                        }
                        else
                        {
                            foreach (var cartao in item.Cartao)
                            {
                                Console.WriteLine("Número do cartão: {0}", cartao.Numero);
                                Console.WriteLine("Pretende remover o cartão? [sim/nao]");
                                var resposta = Console.ReadLine();
                                if (resposta.ToLower() == "sim")
                                {
                                    item.Cartao.Remove(cartao);
                                    Console.WriteLine("{0} removeu o cartão com sucesso", item.User);
                                }
                                else
                                {
                                    Console.WriteLine("Não atualizado");
                                }
                                Thread.Sleep(600);
                                goBack = true;
                                Console.Clear();
                                break;
                            }
                        }
                    }
                }
            }
        }
    }
}




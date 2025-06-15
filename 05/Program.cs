using System;
using System.Collections.Generic;


public class Competidor
{
    public string Nome { get; set; }
    public int Idade { get; set; }
    public string Modalidade { get; set; }

    public Competidor(string nome, int idade, string modalidade)
    {
        Nome = nome;
        Idade = idade;
        Modalidade = modalidade;
    }
}


public class Competicao
{
    public string Nome { get; set; }
    private List<Competidor> competidores;

    public Competicao(string nome)
    {
        Nome = nome;
        competidores = new List<Competidor>();
    }

    public void AdicionarCompetidor(Competidor c)
    {
        competidores.Add(c);
    }

    public List<Competidor> ObterCompetidores()
    {
        return competidores;
    }
}

class Program
{
    static void Main()
    {
        Competicao competicao = null;
        bool continuar = true;

        while (continuar)
        {
            Console.WriteLine("\n--- Gerenciador de Competição ---");
            Console.WriteLine("1. Cadastrar uma nova competição");
            Console.WriteLine("2. Adicionar competidores");
            Console.WriteLine("3. Listar competidores");
            Console.WriteLine("4. Sair");
            Console.Write("Escolha uma opção: ");
            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    Console.Write("Digite o nome da competição: ");
                    string nomeCompeticao = Console.ReadLine();
                    competicao = new Competicao(nomeCompeticao);
                    Console.WriteLine($"Competição '{nomeCompeticao}' criada com sucesso!");
                    break;

                case "2":
                    if (competicao == null)
                    {
                        Console.WriteLine("Por favor, cadastre uma competição primeiro.");
                    }
                    else
                    {
                        AdicionarCompetidores(competicao);
                    }
                    break;

                case "3":
                    if (competicao == null)
                    {
                        Console.WriteLine("Por favor, cadastre uma competição primeiro.");
                    }
                    else
                    {
                        ListarCompetidores(competicao);
                    }
                    break;

                case "4":
                    continuar = false;
                    Console.WriteLine("Encerrando o programa...");
                    break;

                default:
                    Console.WriteLine("Opção inválida, tente novamente.");
                    break;
            }
        }
    }

    static void AdicionarCompetidores(Competicao competicao)
    {
        Console.WriteLine("\n--- Adicionar Competidores ---");
        bool adicionarMais = true;

        while (adicionarMais)
        {
            Console.Write("Nome: ");
            string nome = Console.ReadLine();

            Console.Write("Idade: ");
            if (!int.TryParse(Console.ReadLine(), out int idade))
            {
                Console.WriteLine("Valor inválido para idade. Tente novamente.");
                continue;
            }

            Console.Write("Modalidade: ");
            string modalidade = Console.ReadLine();

            Competidor c = new Competidor(nome, idade, modalidade);
            competicao.AdicionarCompetidor(c);
            Console.WriteLine("Competidor adicionado.");

            Console.Write("Deseja adicionar outro competidor? (s/n): ");
            string resposta = Console.ReadLine();
            if (resposta.ToLower() != "s")
            {
                adicionarMais = false;
            }
        }
    }

    static void ListarCompetidores(Competicao competicao)
    {
        Console.WriteLine($"\n--- Competidores em '{competicao.Nome}' ---");
        var lista = competicao.ObterCompetidores();
        if (lista.Count == 0)
        {
            Console.WriteLine("Nenhum competidor cadastrado.");
        }
        else
        {
            for (int i = 0; i < lista.Count; i++)
            {
                var c = lista[i];
                Console.WriteLine($"{i + 1}. {c.Nome} | Idade: {c.Idade} | Modalidade: {c.Modalidade}");
            }
        }
    }
}
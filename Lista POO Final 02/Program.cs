using System;
using System.Collections.Generic;

namespace GerenciadorAlunos
{
    
    public class Aluno
    {
        public string RA { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
    }

    class Program
    {
        static List<Aluno> alunos = new List<Aluno>();

        static void Main(string[] args)
        {
            bool rodando = true;

            while (rodando)
            {
                Console.WriteLine("\n=== Gerenciador de Alunos ===");
                Console.WriteLine("1. Cadastrar aluno");
                Console.WriteLine("2. Listar alunos");
                Console.WriteLine("3. Alterar dados de um aluno");
                Console.WriteLine("4. Remover um aluno");
                Console.WriteLine("5. Sair");
                Console.Write("Escolha uma opção: ");

                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        CadastrarAluno();
                        break;
                    case "2":
                        ListarAlunos();
                        break;
                    case "3":
                        AlterarAluno();
                        break;
                    case "4":
                        RemoverAluno();
                        break;
                    case "5":
                        rodando = false;
                        Console.WriteLine("Encerrando o programa...");
                        break;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }
            }
        }

        static void CadastrarAluno()
        {
            Console.WriteLine("\n--- Cadastrar Novo Aluno ---");
            Console.Write("RA (único): ");
            string ra = Console.ReadLine();

           
            if (alunos.Exists(a => a.RA == ra))
            {
                Console.WriteLine("ERRO: Já existe um aluno com esse RA.");
                return;
            }

            Console.Write("Nome: ");
            string nome = Console.ReadLine();

            Console.Write("Idade: ");
            if (!int.TryParse(Console.ReadLine(), out int idade))
            {
                Console.WriteLine("Erro: Idade inválida.");
                return;
            }

            Aluno novoAluno = new Aluno { RA = ra, Nome = nome, Idade = idade };
            alunos.Add(novoAluno);
            Console.WriteLine("Aluno cadastrado com sucesso!");
        }

        static void ListarAlunos()
        {
            Console.WriteLine("\n--- Lista de Alunos ---");
            if (alunos.Count == 0)
            {
                Console.WriteLine("Nenhum aluno cadastrado.");
                return;
            }

            foreach (var aluno in alunos)
            {
                Console.WriteLine($"RA: {aluno.RA} | Nome: {aluno.Nome} | Idade: {aluno.Idade}");
            }
        }

        static void AlterarAluno()
        {
            Console.WriteLine("\n--- Alterar Dados de um Aluno ---");
            Console.Write("Informe o RA do aluno a ser alterado: ");
            string ra = Console.ReadLine();

            var aluno = alunos.Find(a => a.RA == ra);

            if (aluno == null)
            {
                Console.WriteLine("Aluno não encontrado.");
                return;
            }

            Console.WriteLine($"Alterando aluno: {aluno.Nome} (RA: {aluno.RA})");
            Console.Write("Novo nome (pressione Enter para manter o existente): ");
            string novoNome = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(novoNome))
            {
                aluno.Nome = novoNome;
            }

            Console.Write("Nova idade (pressione Enter para manter a existente): ");
            string idadeInput = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(idadeInput))
            {
                if (int.TryParse(idadeInput, out int novaIdade))
                {
                    aluno.Idade = novaIdade;
                }
                else
                {
                    Console.WriteLine("ID de entrada inválido. Idade não alterada.");
                }
            }

            Console.WriteLine("Dados do aluno atualizados com sucesso!");
        }

        static void RemoverAluno()
        {
            Console.WriteLine("\n--- Remover Aluno ---");
            Console.Write("Informe o RA do aluno a ser removido: ");
            string ra = Console.ReadLine();

            var aluno = alunos.Find(a => a.RA == ra);

            if (aluno == null)
            {
                Console.WriteLine("Aluno não encontrado.");
                return;
            }

            alunos.Remove(aluno);
            Console.WriteLine("Aluno removido com sucesso!");
        }
    }
}
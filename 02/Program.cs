using System;
using System.Collections.Generic;
using System.Linq;

namespace CadastroProdutos
{
    
    public class Produto
    {
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
    }

    class Program
    {
        static List<Produto> produtos = new List<Produto>();

        static void Main(string[] args)
        {
            bool ativo = true;

            while (ativo)
            {
                Console.WriteLine("\n=== Gerenciador de Produtos ===");
                Console.WriteLine("1. Cadastrar produto");
                Console.WriteLine("2. Remover produto");
                Console.WriteLine("3. Pesquisar produto");
                Console.WriteLine("4. Mostrar produto com menor valor");
                Console.WriteLine("5. Sair");
                Console.Write("Escolha uma opção: ");
                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        CadastrarProduto();
                        break;
                    case "2":
                        RemoverProduto();
                        break;
                    case "3":
                        PesquisarProduto();
                        break;
                    case "4":
                        MostrarProdutoMenorValor();
                        break;
                    case "5":
                        ativo = false;
                        Console.WriteLine("Encerrando o programa...");
                        break;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }
            }
        }

        static void CadastrarProduto()
        {
            Console.WriteLine("\n--- Cadastrar Novo Produto ---");
            Console.Write("Descrição: ");
            string descricao = Console.ReadLine();

            Console.Write("Valor: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal valor))
            {
                Console.WriteLine("Erro: Valor inválido.");
                return;
            }

            Produto novoProduto = new Produto { Descricao = descricao, Valor = valor };
            produtos.Add(novoProduto);
            Console.WriteLine("Produto cadastrado com sucesso!");
        }

        static void RemoverProduto()
        {
            Console.WriteLine("\n--- Remover Produto ---");
            Console.Write("Descrição do produto a remover: ");
            string descricao = Console.ReadLine();

            var produtoRemover = produtos.Find(p => p.Descricao.Equals(descricao, StringComparison.OrdinalIgnoreCase));
            if (produtoRemover != null)
            {
                produtos.Remove(produtoRemover);
                Console.WriteLine("Produto removido com sucesso!");
            }
            else
            {
                Console.WriteLine("Produto não encontrado.");
            }
        }

        static void PesquisarProduto()
        {
            Console.WriteLine("\n--- Pesquisar Produto ---");
            Console.Write("Descrição do produto: ");
            string descricao = Console.ReadLine();

            var produto = produtos.Find(p => p.Descricao.Equals(descricao, StringComparison.OrdinalIgnoreCase));
            if (produto != null)
            {
                Console.WriteLine($"Produto encontrado:\nDescrição: {produto.Descricao}\nValor: {produto.Valor:C}");
            }
            else
            {
                Console.WriteLine("Produto não encontrado.");
            }
        }

        static void MostrarProdutoMenorValor()
        {
            Console.WriteLine("\n--- Produto com Menor Valor ---");
            if (produtos.Count == 0)
            {
                Console.WriteLine("Não há produtos cadastrados.");
                return;
            }

            var menorValorProduto = produtos.OrderBy(p => p.Valor).First();
            Console.WriteLine($"Descrição: {menorValorProduto.Descricao} | Valor: {menorValorProduto.Valor:C}");
        }
    }
}
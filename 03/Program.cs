using System;


public interface IPagamento
{
    void ProcessarPagamento(decimal valor);
}


public class PagamentoCartaoCredito : IPagamento
{
    public void ProcessarPagamento(decimal valor)
    {
        Console.WriteLine($"Pagamento de R${valor} processado no cartão de crédito.");
    }
}


public class PagamentoBoleto : IPagamento
{
    public void ProcessarPagamento(decimal valor)
    {
        Console.WriteLine($"Pagamento de R${valor} processado via boleto bancário.");
    }
}


public class PagamentoPIX : IPagamento
{
    public void ProcessarPagamento(decimal valor)
    {
        Console.WriteLine($"Pagamento de R${valor} processado via PIX.");
    }
}


public class LojaVirtual
{
    public void RealizarPagamento(IPagamento metodo, decimal valor)
    {
        metodo.ProcessarPagamento(valor);
    }
}


class Program
{
    static void Main()
    {
        LojaVirtual loja = new LojaVirtual();

        bool continuar = true;

        while (continuar)
        {
            Console.WriteLine("\nEscolha a forma de pagamento:");
            Console.WriteLine("1. Cartão de Crédito");
            Console.WriteLine("2. Boleto Bancário");
            Console.WriteLine("3. PIX (opcional)");
            Console.WriteLine("4. Sair");
            Console.Write("Opção: ");
            string opcao = Console.ReadLine();

            Console.Write("Informe o valor do pagamento: R$ ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal valor))
            {
                Console.WriteLine("Valor inválido. Tente novamente.");
                continue;
            }

            switch (opcao)
            {
                case "1":
                    loja.RealizarPagamento(new PagamentoCartaoCredito(), valor);
                    break;
                case "2":
                    loja.RealizarPagamento(new PagamentoBoleto(), valor);
                    break;
                case "3":
                    loja.RealizarPagamento(new PagamentoPIX(), valor);
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
}
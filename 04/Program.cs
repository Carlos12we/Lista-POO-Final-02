using System;

class Program
{
    static void Main()
    {
        bool continuar = true;

        while (continuar)
        {
            int num1, num2;

            
            while (true)
            {
                Console.Write("Digite o primeiro número: ");
                string input1 = Console.ReadLine();

                try
                {
                    num1 = int.Parse(input1);
                    break; 
                }
                catch (FormatException)
                {
                    Console.WriteLine("Erro: Valor inválido. Digite um número inteiro.");
                }
            }

            
            while (true)
            {
                Console.Write("Digite o segundo número: ");
                string input2 = Console.ReadLine();

                try
                {
                    num2 = int.Parse(input2);
                    
                    if (num2 == 0)
                    {
                        throw new DivideByZeroException();
                    }
                    break; 
                }
                catch (FormatException)
                {
                    Console.WriteLine("Erro: Valor inválido. Digite um número inteiro.");
                }
                catch (DivideByZeroException)
                {
                    Console.WriteLine("Erro: Não é possível dividir por zero.");
                }
            }

            
            try
            {
                int resultado = num1 / num2;
                Console.WriteLine($"Resultado: {resultado}");
            }
            catch (DivideByZeroException)
            {
                
                Console.WriteLine("Erro: Divisão por zero não é permitida.");
            }

           
            Console.Write("Deseja fazer outra operação? (s/n): ");
            string resposta = Console.ReadLine();
            if (resposta.ToLower() != "s")
            {
                continuar = false;
                Console.WriteLine("Programa encerrado.");
            }
        }
    }
}

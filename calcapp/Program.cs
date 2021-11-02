using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calcapp
{
    class Program
    {
		private static void Main(string[] args)
        {
            bool endApp = false;
			// Exibir título da aplicação
			Console.WriteLine("Console Calculadora in C#\r");
            Console.WriteLine("------------------------\n");

            while (!endApp)
            {
                // Declare variáveis e defina para esvaziar.
                string numInput1 = "";
                string numInput2 = "";
                double result = 0;

                // Peça ao usuário para digitar o primeiro número.
                Console.Write("Digite um número, e depois pressione Enter: ");
                numInput1 = Console.ReadLine();

                double cleanNum1 = 0;
                while (!double.TryParse(numInput1, out cleanNum1))
                {
                    Console.Write("digite um valor inteiro: ");
                    numInput1 = Console.ReadLine();
                }

                // Peça ao usuário para digitar o segundo número.
                Console.Write("Digite outro número e, em seguida, pressione Enter: ");
                numInput2 = Console.ReadLine();

                double cleanNum2 = 0;
                while (!double.TryParse(numInput2, out cleanNum2))
                {
                    Console.Write("Esta não é uma entrada válida. Por favor, digite um valor inteiro: ");
                    numInput2 = Console.ReadLine();
                }

                // Peça ao usuário que escolha um operador.
                Console.WriteLine("Choose an operator from the following list:");
                Console.WriteLine("\ta - Adição");
                Console.WriteLine("\ts - Subtração");
                Console.WriteLine("\tm - Multiplicação");
                Console.WriteLine("\td - Divisão");
                Console.Write("Sua opção? ");

                string op = Console.ReadLine();

                try
                {
                    result = Calculator.DoOperation(cleanNum1, cleanNum2, op);
                    if (double.IsNaN(result))
                    {
                        Console.WriteLine("Esta operação resultará em um erro matemático.\n");
                    }
                    else Console.WriteLine("Resultado: {0:0.##}\n", result);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Oh não! Ocorreu uma exceção ao tentar fazer as contas.\n - Detalhes: " + e.Message);
                }

                Console.WriteLine("------------------------\n");

                // Aguarde a resposta do usuário antes de fechar.
                Console.Write("Pressione 'n'  para fechar o aplicativo, ou pressione qualquer outra tecla e Enter para continuar: ");
                if (Console.ReadLine() == "n") endApp = true;

                Console.WriteLine("\n"); //linhas em branco, espaço amigável
            }
            return;
        }
    }
    class Calculator
    {
        public static double DoOperation(double num1, double num2, string op)
        {
            double result = double.NaN; // O valor padrão é "não um número" se uma operação, como a divisão, puder resultar em um erro.

            // estrutura switch para os calculos
            switch (op)
            {
                case "a":
                    result = num1 + num2;
                    break;
                case "s":
                    result = num1 - num2;
                    break;
                case "m":
                    result = num1 * num2;
                    break;
                case "d":
                    //divisor diferente de zero.
                    if (num2 != 0)
                    {
                        result = num1 / num2;
                    }
                    break;
                // retorna texto para uma entrada de opção incorreta.
              
                    default:
                    break;
            }
            return result;
        }
    }
}
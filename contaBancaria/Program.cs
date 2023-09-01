using System.Runtime.CompilerServices;
using contaBancaria.Model;
using ContaBancaria.Model;

namespace contaBancaria
{
    internal class Program
    {
        private static ConsoleKeyInfo consoleKeyInfo;
        static void Main(string[] args)
        {
            int entrada;

            /*Conta c1 = new Conta(1, 123, 1, "Julia", 1000000.0M);
            
            c1.Visualizar();
            c1.SetNumero(345);

            c1.Sacar(1000);
            c1.Visualizar();

            c1.Depositar(5000);
            c1.Visualizar(); */

            ContaCorrente cc1 = new ContaCorrente(2, 123, 1, "Samantha", 1000000.00M, 1000M);
            cc1.Visualizar();

            cc1.Sacar(20000000.00M);
            cc1.Depositar(5000);
            cc1.Visualizar();

            ContaPoupanca cp1 = new ContaPoupanca(3, 123, 2, "Priscila", 15000, 5);
            cp1.Visualizar();

            while(true)
            {
                Console.BackgroundColor = ConsoleColor.Gray;
                Console.ForegroundColor = ConsoleColor.Black;

                Console.WriteLine();
                Console.WriteLine("=============================================");
                Console.WriteLine("              BANCO ALEXANDRINO              ");
                Console.WriteLine("=============================================");
                Console.WriteLine("   1 - Criar conta                           ");
                Console.WriteLine("   2 - Listar todas as contas                ");
                Console.WriteLine("   3 - Buscar conta por número               ");
                Console.WriteLine("   4 - Atualizar dados da conta              ");
                Console.WriteLine("   5 - Apagar conta                          ");
                Console.WriteLine("   6 - Sacar                                 ");
                Console.WriteLine("   7 - Depositar                             ");
                Console.WriteLine("   8 - Transferir valores entre contas       ");
                Console.WriteLine("   9 - Sair                                  ");
                Console.WriteLine("=============================================");
                Console.ResetColor();

                Console.Write("\nEscolha a opção desejada: ");
                entrada = Convert.ToInt32(Console.ReadLine());

                switch (entrada)
                {

                    case 1:
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("Criar conta");
                        Console.ResetColor();
                        KeyPress();
                        break;

                    case 2:
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("Listar todas as contas");
                        Console.ResetColor();
                        KeyPress();
                        break;

                    case 3:
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("Consultar conta por número");
                        Console.ResetColor();
                        KeyPress();
                        break;

                    case 4:
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        Console.WriteLine("Atualizar dados da conta");                        
                        Console.ResetColor();
                        KeyPress();
                        break;

                    case 5:
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("Apagar conta");                        
                        Console.ResetColor();
                        KeyPress();
                        break;

                    case 6:
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("Saque");                        
                        Console.ResetColor();
                        KeyPress();
                        break;

                    case 7:
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Depósito");
                        Console.ResetColor();
                        KeyPress();
                        break;

                    case 8:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Transferência entre contas");
                        Console.ResetColor();
                        KeyPress();
                        break;

                    case 9:
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("\nBanco Alexandrino - Sua riqueza se faz aqui!");
                        Console.ResetColor();
                        Sobre();
                        System.Environment.Exit(0);
                        break;

                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Opção inválida!");
                        Console.ResetColor();
                        KeyPress();
                        break;
                }
            }
        }

        static void Sobre()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("==========================================================");
            Console.WriteLine("Projeto desenvolvido por Julia Alexandrino");
            Console.WriteLine("Generation Brasil - brazil.generation.org/");
            Console.WriteLine("github.com/conteudoGeneration | github.com/juhalexandrino");
            Console.WriteLine("==========================================================");
            Console.ResetColor();
        }

        static void KeyPress()
        {
            do
            {
                Console.Write("\nPressione enter para continuar...");
                consoleKeyInfo = Console.ReadKey();
            } while (consoleKeyInfo.Key != ConsoleKey.Enter);

        }
    }
}
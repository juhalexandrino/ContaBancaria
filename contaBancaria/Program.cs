using System.Runtime.CompilerServices;

namespace contaBancaria
{
    internal class Program
    {
        private static ConsoleKeyInfo consoleKeyInfo;
        static void Main(string[] args)
        {

            int entrada;
            do
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
                        Console.WriteLine("\nBanco Alexandrino - A riqueza se faz aqui!");
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
            } while (entrada > 0 && entrada <= 8);
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
            do{
                Console.Write("\nPressione enter para continuar...");
                consoleKeyInfo = Console.ReadKey();
            } while (consoleKeyInfo.Key != ConsoleKey.Enter);

        }
    }
}
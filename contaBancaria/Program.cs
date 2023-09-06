using System.Runtime.CompilerServices;
using ContaBancaria.Controller;
using ContaBancaria.Model;

namespace contaBancaria
{
    internal class Program
    {
        private static ConsoleKeyInfo consoleKeyInfo;
        static void Main(string[] args)
        {
            int entrada, numero, numeroDestino, agencia, tipo, aniversario;
            string titular;
            decimal valor, saldo, limite;

            ContaController conta = new();

            ContaCorrente cc1 = new ContaCorrente(conta.GerarNumero(), 123, 1, "Samantha", 100000, 50000);
            conta.Cadastrar(cc1);

            ContaPoupanca cp1 = new ContaPoupanca(conta.GerarNumero(), 123, 2, "Priscila", 15000, 5);
            conta.Cadastrar(cp1);

            while(true)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;

                Console.WriteLine();
                Console.WriteLine("=============================================");
                Console.WriteLine("=             BANCO ALEXANDRINO             =");
                Console.WriteLine("=============================================");
                Console.WriteLine("=  1 - Criar conta                          =");
                Console.WriteLine("=  2 - Listar todas as contas               =");
                Console.WriteLine("=  3 - Buscar conta por número              =");
                Console.WriteLine("=  4 - Atualizar dados da conta             =");
                Console.WriteLine("=  5 - Apagar conta                         =");
                Console.WriteLine("=  6 - Sacar                                =");
                Console.WriteLine("=  7 - Depositar                            =");
                Console.WriteLine("=  8 - Transferir valores entre contas      =");
                Console.WriteLine("=  9 - Sair                                 =");
                Console.WriteLine("=============================================");
                Console.ResetColor();

                // tratamento de exceção para impedir digitação de strings
                try
                {
                    Console.Write("\nEscolha a opção desejada: ");
                    entrada = Convert.ToInt32(Console.ReadLine());
                } catch(FormatException)
                {
                    Console.ForegroundColor= ConsoleColor.Red;
                    Console.WriteLine("Digite um valor inteiro entre 1 e 9!");
                    entrada = 0;
                    Console.ResetColor();
                }

                switch (entrada)
                {

                    case 1:
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("Criar conta");
                        Console.ResetColor();

                        Console.Write("Digite o número da agência: ");
                        agencia = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Digite o nome do titular: ");
                        titular = Console.ReadLine();
                        titular ??= string.Empty;

                        do
                        {
                            Console.Write("Digite o tipo da conta: ");
                            tipo = Convert.ToInt32(Console.ReadLine());
                        } while (tipo != 1 && tipo != 2);

                        Console.Write("Digite o saldo da conta: ");
                        saldo = Convert.ToDecimal(Console.ReadLine());
                        
                        switch(tipo) { 
                            case 1:
                                Console.Write("Digite o limite da conta: ");
                                limite = Convert.ToDecimal(Console.ReadLine());

                                conta.Cadastrar(new ContaCorrente(conta.GerarNumero(), agencia, tipo, titular, saldo, limite));
                                break; 
                            
                            case 2:
                                Console.Write("Digite o aniversário da conta: ");
                                aniversario = Convert.ToInt32(Console.ReadLine());

                                conta.Cadastrar(new ContaPoupanca(conta.GerarNumero(), agencia, tipo, titular, saldo, aniversario));
                                break;
                          }

                        
                        KeyPress();
                        break;

                    case 2:
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("Listar todas as contas");
                        Console.ResetColor();
                        conta.ListarTodas();
                        KeyPress();
                        break;

                    case 3:
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("Consultar conta por número");
                        Console.ResetColor();

                        Console.Write("Digite o número da conta: ");
                        numero = Convert.ToInt32(Console.ReadLine());
                        conta.ProcurarPorNumero(numero);

                        KeyPress();
                        break;

                    case 4:
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        Console.WriteLine("Atualizar dados da conta");                        
                        Console.ResetColor();

                        Console.Write("Digite o número da conta: ");
                        numero = Convert.ToInt32(Console.ReadLine());

                        var contas = conta.BuscarNaCollection(numero);

                        if (contas is not null)
                        {
                            Console.Write("Digite o número da agência: ");
                            agencia = Convert.ToInt32(Console.ReadLine());

                            Console.Write("Digite o nome do titular: ");
                            titular = Console.ReadLine();

                            titular ??= string.Empty;

                            Console.Write("Digite o saldo da conta: ");
                            saldo = Convert.ToDecimal(Console.ReadLine());

                            tipo = contas.GetTipo();

                            switch (tipo)
                            {
                                case 1:
                                    Console.Write("Digite o limite da conta: ");
                                    limite = Convert.ToDecimal(Console.ReadLine());

                                    conta.Atualizar(new ContaCorrente(numero, agencia, tipo, titular, saldo, limite));
                                    break;

                                case 2:
                                    Console.Write("Digite o dia do aniversário da conta: ");
                                    aniversario = Convert.ToInt32(Console.ReadLine());

                                    conta.Atualizar(new ContaPoupanca(numero, agencia, tipo, titular, saldo, aniversario));
                                    break;
                            }
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"A conta nº {numero} não foi encontrada!");
                            Console.ResetColor();
                        }

                        KeyPress();
                        break;

                    case 5:
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("Apagar conta");                        
                        Console.ResetColor();

                        Console.Write("Digite o número da conta: ");
                        numero = Convert.ToInt32(Console.ReadLine());
                        conta.Deletar(numero);
                        
                        KeyPress();
                        break;

                    case 6:
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("Saque");                        
                        Console.ResetColor();

                        Console.Write("Digite o número da conta: ");
                        numero = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Digite o valor do saque: ");
                        valor = Convert.ToDecimal(Console.ReadLine());

                        conta.Sacar(numero, valor);

                        KeyPress();
                        break;

                    case 7:
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Depósito");
                        Console.ResetColor();

                        Console.Write("Digite o número da conta: ");
                        numero = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Digite o valor do depósito: ");
                        valor = Convert.ToDecimal(Console.ReadLine());

                        conta.Depositar(numero, valor);

                        KeyPress();
                        break;

                    case 8:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Transferência entre contas");
                        Console.ResetColor();

                        Console.Write("Digite o número da conta origem: ");
                        numero = Convert.ToInt32(Console.ReadLine());
                        
                        Console.Write("Digite o número da conta destino: ");
                        numeroDestino = Convert.ToInt32(Console.ReadLine());
                        
                        Console.Write("Digite o valor da transferência: ");
                        valor = Convert.ToInt32(Console.ReadLine());

                        conta.Transferir(numero, numeroDestino, valor);

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
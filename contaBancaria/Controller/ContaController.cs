using ContaBancaria.Model;
using ContaBancaria.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContaBancaria.Controller
{
    public class ContaController : IContaRepository
    {
        private readonly List<Conta> listaContas = new();
        int numero = 0;

        // métodos CRUD
        public void Cadastrar(Conta conta)
        {
            listaContas.Add(conta);
            Console.WriteLine($"A conta nº {conta.GetNumero()} foi criada com sucesso!");
        }
        public void Atualizar(Conta conta)
        {
            var buscaConta = BuscarNaCollection(conta.GetNumero());

            if (buscaConta is not null)
            {
                var index = listaContas.IndexOf(buscaConta);

                listaContas[index] = conta;

                Console.WriteLine($"A conta nº {conta.GetNumero()} foi atualizada com sucesso!");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"A conta nº {numero} não foi encontrada!");
                Console.ResetColor();
            }
        }
        public void Deletar(int numero)
        {
            var conta = BuscarNaCollection(numero); 
            if (conta is not null)
            {
                if (listaContas.Remove(conta) == true)
                {
                    Console.WriteLine($"A conta {numero} foi apagada com sucesso!");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"A conta {numero} não foi encontrada!");
                    Console.ResetColor();
                }
            }
        }
        public void ListarTodas()
        {
            foreach (var conta in listaContas)
            {
               conta.Visualizar();
            }
        }

        //metódos bancários
        public void Sacar(int numero, decimal valor)
        {
            var conta = BuscarNaCollection(numero);

            if (conta is not null)
            {
                if (conta.Sacar(valor) == true)
                    Console.WriteLine($"O saque de R${valor} na conta nº {numero} foi efetuado com sucesso!");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"A conta nº {numero} não foi encontrada!");
                Console.ResetColor();
            }
        }
        public void Transferir(int numeroOrigem, int numeroDestino, decimal valor)
        {
            var contaOrigem = BuscarNaCollection(numeroOrigem);
            var contaDestino = BuscarNaCollection(numeroDestino);

            if (contaOrigem is not null && contaDestino is not null)
            {
                if (contaOrigem.Sacar(valor) == true)
                {
                    contaDestino.Depositar(valor);
                    Console.WriteLine($"A transferência R${valor} foi efetuada com sucesso!");
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"A conta de origem e/ou conta de destino não foram encontradas!");
                Console.ResetColor();
            }
        }
        public void Depositar(int numero, decimal valor)
        {
            var conta = BuscarNaCollection(numero);

            if (conta is not null)
            {
                conta.Depositar(valor);
                    Console.WriteLine($"O depósito de R${valor} na conta nº {numero} foi efetuado com sucesso!");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"A conta nº {numero} não foi encontrada!");
                Console.ResetColor();
            }
        }

        // metódos auxiliares
        public int GerarNumero()
        {
            return ++numero;
        }
        public void ProcurarPorNumero(int numero)
        {
            var conta = BuscarNaCollection(numero);

            if (conta is not null)
                conta.Visualizar();
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"A conta nº {numero} não foi encontrada!");
                Console.ResetColor();
            }
        }

        // método para buscar objeto conta específico
        public Conta? BuscarNaCollection(int numero)
        {
            foreach(var conta in listaContas)
            {
                if (conta.GetNumero() == numero)
                    return conta;
            }
                return null;
        }

    }
}

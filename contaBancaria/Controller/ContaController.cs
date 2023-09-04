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
            throw new NotImplementedException();
        }
        public void ProcurarPorNumero(int numero)
        {
            throw new NotImplementedException();
        }

        public void Deletar(int numero)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public void Transferir(int numeroOrigem, int numeroDestino, decimal valor)
        {
            throw new NotImplementedException();
        }

        public void Depositar(int numero, decimal valor)
        {
            throw new NotImplementedException();
        }

        // metódos auxiliares
        public int GerarNumero()
        {
            return ++numero;
        }
    }
}

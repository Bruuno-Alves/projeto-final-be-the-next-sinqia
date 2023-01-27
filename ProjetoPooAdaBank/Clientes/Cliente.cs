using ConsoleApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoPooAdaBank.Clientes
{
    public class Cliente
    {
        public string Nome { get; private set; }
        public string Cpf { get; private set; }
        public Endereco Endereco { get; set; }

        public Cliente(string nome, string cpf, Endereco endereco)
        {
            Nome = nome;
            Cpf = cpf;
            Endereco = endereco;
        }

        public static Cliente CadastrarCliente()
        {
            String nomeCompleto, CPF;

            Console.WriteLine("Informe o seu nome");
            nomeCompleto = Console.ReadLine();

            Console.Clear();
            do
            {
                Console.WriteLine("Informe o seu CPF");
                CPF = Console.ReadLine();
                if (CPFValidator.ValidaCPF(CPF))
                {
                    break;
                }
                Console.WriteLine("CPF inválido, por favor digite novamente.");
            } while (true);

            Console.Clear();

            Endereco endereco = Endereco.CadastrarEndereco();

            Cliente cliente = new(nomeCompleto, CPF, endereco);

            Console.WriteLine($"Nome: {cliente.Nome}, CPF: {cliente.Cpf}, rua: {cliente.Endereco.Rua} ");

            return cliente;
        }
    }
}

using ConsoleApp;
using ProjetoPooAdaBank.Clientes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoPooAdaBank.Contas
{
    internal class MenuAberturaConta
    {
        public void Menu()
        {
            int input;
            MensagemInicial();

            do
            {
                Console.WriteLine("Selecione [1] para criar uma nova conta ou [2] para logar");
                int.TryParse(Console.ReadLine(), out input);
            } while (input != 1 && input != 2);

            Console.Clear();

            if (input == 1)
            {
                AbrirConta();
            }
            else
            {
                LogarConta();
            }
        }
        public void MensagemInicial()
        {
            Console.WriteLine("$$$$$$$$$$$$$$$$$$$$$");
            Console.WriteLine("Bem Vindo ao Ada Bank");
            Console.WriteLine("$$$$$$$$$$$$$$$$$$$$$");
            
        }
        
        public Endereco CadastrarEndereco()
        {
            String logradouro, bairro, cidade, estado, cep;
            int numero;
            bool converteu;

            Console.WriteLine("Informe o seu logradouro");
            logradouro = Console.ReadLine();

            Console.Clear();

            do
            {
                Console.WriteLine("Informe o número da sua redidência");
                converteu = int.TryParse(Console.ReadLine(), out numero);

                if(!converteu)
                {
                    Console.WriteLine("Digite um número válido");
                }

            } while (!converteu);

            Console.Clear();

            Console.WriteLine("Informe o seu bairro");
            bairro = Console.ReadLine();

            Console.Clear();

            Console.WriteLine("Informe a sua cidade");
            cidade = Console.ReadLine();

            Console.Clear();

            Console.WriteLine("Informe o seu estado");
            estado = Console.ReadLine();

            Console.Clear();

            Console.WriteLine("Informe o seu CEP");
            cep = Console.ReadLine();

            Console.Clear();

            Endereco endereco = new Endereco(logradouro, numero, bairro, cidade, estado);

            return endereco;
        }
        public Cliente CadastrarCliente()
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

            Endereco endereco = CadastrarEndereco();

            Cliente cliente = new(nomeCompleto, CPF, endereco);

            Console.WriteLine($"Nome: {cliente.Nome}, CPF: {cliente.Cpf}, rua: {cliente.Endereco.Rua} ");

            return cliente;
        }

        public void AbrirConta()
        {
            int tipoConta;
            Console.WriteLine("Que tipo de conta você deseja abrir?");
            Console.WriteLine("[1] - Poupança\n[2] - Salario\n[3] - Investimento");

            do
            {
                int.TryParse(Console.ReadLine(), out tipoConta);
            } while (tipoConta < 1 || tipoConta > 3);

            Console.Clear();

            // criar métodos para construir as contas: poupança, salário e investimento.
            if (tipoConta == 2)
            {
                String cnpjEmpregador;
                double salario;
                bool converteu = false;

                Random random = new Random();

                Cliente cliente = CadastrarCliente();

                Console.WriteLine("Informe o CNPJ do seu empregador");
                cnpjEmpregador = Console.ReadLine();

                Console.Clear();

                Console.WriteLine("Informe o seu salário líquido");
                while (!converteu)
                {
                    converteu = double.TryParse(Console.ReadLine(), out salario);

                    if(!converteu)
                    {
                        Console.WriteLine("Digite um salário válido!");
                    } 
                    else
                    {
                        ContaSalario contaSalario = new ContaSalario(
                            001, 
                            random.Next(0, 9999), 
                            cliente, 
                            cnpjEmpregador, 
                            salario);

                        Console.Clear();

                        Console.WriteLine("Conta Salário aberta com sucesso!");
                        Console.WriteLine($"Agência: {contaSalario.NumeroAgencia}, " +
                                            $"Conta: {contaSalario.NumeroConta}, " +
                                            $"Titular: {contaSalario.Titular.Nome}, " +
                                            $"Data de abertura: {contaSalario.DataAbertura}");
                    }
                }
            }
        }

        public void LogarConta()
        {
            // criar login e senha ao final do processo de abertura da conta.
        }
}
}

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

            if (input == 1)
            {
                DadosCliente();
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

        public void DadosCliente()
        {
            String nomeCompleto, CPF,rua, bairro, cidade,estado, cep;
            int numero;

            Console.WriteLine("Informe o seu nome");
            nomeCompleto = Console.ReadLine();
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
            

            Console.WriteLine("Informe a rua da sua residência");
            rua = Console.ReadLine();

            Console.WriteLine("Informe o nº de sua residência");
            int.TryParse(Console.ReadLine(), out numero);

            Console.WriteLine("Informe o seu bairro");
            bairro = Console.ReadLine();

            Console.WriteLine("Informe a sua cidade");
            cidade = Console.ReadLine();

            Console.WriteLine("Informe o seu estado");
            estado = Console.ReadLine();

            Console.WriteLine("Informe o seu cep");
            cep = Console.ReadLine();

            Endereco endereco1 = new(rua,numero,bairro,cidade,estado);
            Cliente c1 = new(nomeCompleto,CPF,endereco1);

            Console.WriteLine($"Nome: {c1.Nome}, CPF: {c1.Cpf}, rua: {c1.Endereco.Rua} ");
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

            // criar métodos para construir as contas: poupança, salário e investimento.

            //switch(tipoConta)
            //{
            //    case 1:
            //}
        }

        public void LogarConta()
        {
            // criar login e senha ao final do processo de abertura da conta.
        }
}
}

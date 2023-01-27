using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ProjetoPooAdaBank.Clientes;

namespace ProjetoPooAdaBank.Contas
{
    public abstract class Conta
    { 
        public int TipoConta { get; protected set; }
        public int NumeroAgencia { get; private set; }
        public int NumeroConta { get; private set; }
        public Cliente Titular { get; set; }
        public double Saldo { get; protected set; }
        public string Email { get; protected set; }
        public string Senha { get; private set; }
        public List<Transacao> Extrato { get; private set; }
        private double ValorTaxaManutencao { get; set; }
        public static int ContasAbertas { get; private set; }
        public DateTime DataAbertura { get; private set; }

        public static List<Conta> ContasCriadas = new List<Conta>();

        public Conta( int numeroConta, string email, string senha, Cliente titular)
        {
            NumeroAgencia = 0001;
            NumeroConta = numeroConta;
            Email = email;
            Senha = senha;
            Titular = titular;
            Extrato = new List<Transacao>();
            ContasAbertas++;
            DataAbertura = DateTime.Now;
            ContasCriadas.Add(this);
        }

        public static (Conta, bool) Logar(string email, string senha)
        {
            foreach (Conta conta in ContasCriadas)
            {
                if (conta.Email == email && conta.Senha == senha)
                {
                    Console.WriteLine($"Seja bem vindo/a {conta.Titular.Nome}");
                    return (conta, true);
                }
            }

            Console.WriteLine("Email ou senha incorretos");
            return (null, false);
        }

        public void Depositar(double valor, bool transferir = false)
        {
            Saldo += valor;

            if (transferir == false)
            {
                Console.WriteLine("Deposito realizado com sucesso!");
                Extrato.Add(new Transacao("Depósito", valor, Saldo));
            }


        }

        public bool Sacar(double valor, bool transferir = false)
        {
            double tarifa = CalcularValorTarifaManutencao(valor);

            if (valor + tarifa <= Saldo)
            {
                Saldo -= valor;

                if (transferir == false)
                {
                    Saldo -= tarifa;
                    Console.WriteLine($"aplicada taxa no valor de {tarifa.ToString("C")}");
                    Console.WriteLine("Saque realizado com sucesso!");
                    Extrato.Add(new Transacao("Saque", valor,tarifa, Saldo));
                }

                return true;
            }

            Console.WriteLine($"Operação não realizada! Valor total de {(valor + tarifa).ToString("C")} é maior que o saldo em conta.");
            return false;
        }

        // VALIDAR UMA FORMA DE REUTILIZAR OS MÉTODOS DEPOSITAR + SACAR, SE NÃO, REESCREVE-LO.
        public void Transferir(double valor, string cpf, int numeroConta)
        {
            foreach (Conta conta in Conta.ContasCriadas)
            {
                if (conta.Titular.Cpf == cpf && this.TipoConta != conta.TipoConta && conta.NumeroConta == numeroConta)
                {

                    int taxa = 5;

                    Sacar(valor + taxa, true);
                    conta.Depositar(valor, true);
                    Console.WriteLine($"Para contas de titularidades diferentes há uma taxa de {taxa}R$");
                    Console.WriteLine("Tranferência realizada com sucesso!");

                    Extrato.Add(new Transacao("Transferência", valor,taxa, Saldo));
                    return;
                }
                else if (conta.Titular.Cpf == cpf && this.TipoConta == conta.TipoConta && numeroConta == conta.NumeroConta)
                {
                    Console.Write(conta.Titular.Cpf);
                    Sacar(valor, true);
                    conta.Depositar(valor, true);

                    Console.WriteLine("Tranferência realizada com sucesso!");

                    Extrato.Add(new Transacao("Transferência", valor, Saldo));
                    return;
                }
            }

            Console.WriteLine("Conta destino não encontrada!");
        }

        // alterar pra ser usado dentro do saque, baseado no valor a ser sacado e não no saldo da conta.
        public virtual double CalcularValorTarifaManutencao(double valor)
        {

            return valor * ValorTaxaManutencao;
        }

        public void MostrarExtrato()
        {
            foreach (Transacao transacao in Extrato)
            {
                Console.WriteLine(transacao.ToString());
            }

        }

        public static Tuple<string,string> LoginSenha()
        {
            string email, senha;
            double valorInicial;
            bool converteu = false;

            Random random = new Random();

            Console.WriteLine("Informe o seu Email");
            email = Console.ReadLine();

            Console.Clear();

            Console.WriteLine("Crie uma senha");
            senha = Console.ReadLine();

            Console.Clear();
            return Tuple.Create(email,senha);
        }

        public static (Conta?, bool) CriarConta(Cliente clienteCadastrado)
        {
            int tipoConta;

            Console.WriteLine("Que tipo de conta você deseja abrir?");
            Console.WriteLine("[1] - Poupança\n[2] - Salario\n[3] - Investimento");

            do
            {
                int.TryParse(Console.ReadLine(), out tipoConta);
            } while (tipoConta < 1 || tipoConta > 3);

            Console.Clear();

            if (tipoConta == 1)
            {
                ContaPoupanca contaPoupanca = ContaPoupanca.CriarConta(clienteCadastrado);
                return (contaPoupanca, true);

            } else if(tipoConta == 2)
            {
                ContaSalario contaSalario = ContaSalario.CriarConta(clienteCadastrado);
                return (contaSalario, true);

            } else if(tipoConta == 3)
            {
                ContaInvestimento contaInvestimento = ContaInvestimento.CriarConta(clienteCadastrado);

                return (contaInvestimento, true);
            } else
            {
                Console.WriteLine("Erro ao criar a conta! Tente novamente mais tarde");
                return (null, false);
            }
        }

        public static void FazerOperacao(Conta conta, int operacao)
        {
            double valor;
            bool sucedido = false;
            String cpf;
            int numeroConta;

            if (operacao == 1)
            {
                Console.WriteLine("Digite o valor a ser sacado");
                sucedido = double.TryParse(Console.ReadLine(), out valor);

                if (sucedido)
                {
                    conta.Sacar(valor);
                }
            }
            else if (operacao == 2)
            {
                conta.MostrarExtrato();
            }
            else if (operacao == 3)
            {
                Console.WriteLine("Digite o valor a ser depositado");
                sucedido = double.TryParse(Console.ReadLine(), out valor);

                if (sucedido)
                {
                    conta.Depositar(valor);

                }
            }
            else if (operacao == 4)
            {
                Console.WriteLine("Digite o valor a ser tranferido");
                sucedido = double.TryParse(Console.ReadLine(), out valor);

                Console.WriteLine("Digite o CPF do titular da conta para qual deseja transferir");
                cpf = Console.ReadLine();

                Console.WriteLine("Digite o nº da conta para qual deseja transferir");
                int.TryParse(Console.ReadLine(), out numeroConta);

                conta.Transferir(valor, cpf, numeroConta);
            }
            else if (operacao == 5)
            {
                Console.WriteLine($"O seu saldo atual é de R${conta.Saldo}");
            }
            else if (operacao == 6 && conta is ContaInvestimento)
            {
                var contaInvestimento = (ContaInvestimento)conta;
                contaInvestimento.Investir();
            }
            else
            {
                Console.WriteLine("Digite um valor válido ou pressione 'E' para sair");
            }
        }
    }
}
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

        public abstract Conta CriarConta(Cliente clienteCadastrado);
    }
}
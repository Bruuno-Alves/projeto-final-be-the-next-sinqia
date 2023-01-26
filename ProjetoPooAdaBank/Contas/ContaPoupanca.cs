using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoPooAdaBank.Clientes;

namespace ProjetoPooAdaBank.Contas
{
    internal class ContaPoupanca : Conta
    {
        static readonly int saldoMin = 50;
        public ContaPoupanca(
            int numeroConta,
            string email,
            string senha,
            Cliente titular,
            double valorInicial) : base(numeroConta, email, senha, titular)
        {
            this.TipoConta = 1;
            Saldo = valorInicial;
        }


        public static bool ValidaSaldoMin(double valorInicial)
        {
            if(valorInicial >= saldoMin)
            {
                return true;
            }
            return false;
        }
        // reajuste no valor da tarifa.
        public override double CalcularValorTarifaManutencao(double valor)
        {
            double tarifa = Saldo * 0.0035;
            return tarifa;
        }

        public override static Conta CriarConta(Cliente clienteCadastrado)
        {
            var (email, senha) = LoginSenha();
            double valorInicial;
            Console.WriteLine("Deposite ao menos R$ 50,00 de saldo inicial");
            do
            {
                double.TryParse(Console.ReadLine(), out valorInicial);

                if (valorInicial >= 50)
                {
                    break;
                }
                Console.WriteLine("O saldo inicial deve ser maior ou igual R$ 50,00");

            } while (true);
            Random random = new Random();
            ContaPoupanca contaPoupanca = new ContaPoupanca(
                random.Next(0, 9999),
                email,
                senha,
                clienteCadastrado,
                valorInicial);

            Console.Clear();

            Console.WriteLine("Conta Poupança aberta com sucesso!");
            Console.WriteLine($"Agência: {contaPoupanca.NumeroAgencia}, " +
                                $"Conta: {contaPoupanca.NumeroConta}, " +
                                $"Titular: {contaPoupanca.Titular.Nome}, " +
                                $"Data de abertura: {contaPoupanca.DataAbertura}");

            return contaPoupanca;

        }
    }
}

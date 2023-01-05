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
        int tipoConta = 1;
        static readonly int saldoMin = 50;
        public ContaPoupanca(
            int numeroAgencia,
            int numeroConta,
            string email,
            string senha,
            Cliente titular,
            double valorInicial) : base(numeroAgencia, numeroConta, email, senha, titular)
        {
            this.TipoConta = 1;
            Saldo = valorInicial;
        }


        public void DepositarPoupanca(double valorSaldoMinimo)
        {

            Saldo += valorSaldoMinimo;
            Extrato.Add(new Transacao("Depósito", valorSaldoMinimo, Saldo));
        }

        //método sacar levando em consideração a saldo mínimo
        public void SacarPoupanca(double valorSaldoMinimo)
        {
            if (valorSaldoMinimo <= Saldo)
            {
                Saldo -= valorSaldoMinimo;
                Extrato.Add(new Transacao("Saque", valorSaldoMinimo, Saldo));

            }
            else
            {
                Console.WriteLine("O valor solicitado é maior que o saldo da conta");
            }


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
        public override double CalcularValorTarifaManutencao()
        {
            double tarifa = Saldo * 0.0035;
            return tarifa;
        }

    }
}

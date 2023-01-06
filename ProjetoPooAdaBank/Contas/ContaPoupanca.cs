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

    }
}

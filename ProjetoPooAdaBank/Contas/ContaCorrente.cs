using ProjetoPooAdaBank.Clientes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoPooAdaBank.Contas
{
    public class ContaCorrente : Conta
    {
        static readonly int saldoMin = 0;
        public ContaCorrente(
            int numeroConta,
            string email,
            string senha,
            Cliente titular,
            double valorInicial) : base(numeroConta, email, senha, titular)
        {
            this.TipoConta = 4;
            Saldo = valorInicial;
        }


        public static bool ValidaSaldoMin(double valorInicial)
        {
            if (valorInicial >= saldoMin)
            {
                return true;
            }
            return false;
        }
        
        public override double CalcularValorTarifaManutencao(double valor)
        {
            double tarifa = Saldo * 0.0030;
            return tarifa;
        }
    }
}

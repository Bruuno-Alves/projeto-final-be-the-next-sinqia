
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoPooAdaBank.ContaSalario3
{
    public class ContaSalario : Conta
    {
        public Holerite Holerite { get; }

        public ContaSalario(
            int numeroAgencia,
            int numeroConta,
            Cliente titular,
            string cnpjEmpregador,
            double salarioLiquido) : base(numeroAgencia, numeroConta, titular)
        {
            Holerite = new Holerite(cnpjEmpregador, salarioLiquido);
        }

        public void DepositarSalario(double valor, string cnpjEmpregador)
        {
            if(cnpjEmpregador == Holerite.CnpjEmpregador)
            {
                base.Saldo += valor;
                base.Extrato.Add(new Transacao("Depósito", valor));
            }
        }

        public override double CalcularValorTarifaManutencao()
        {
            double tarifa = Saldo * (0.3 / 100);
            base.Saldo -= tarifa;

            return tarifa;
        }
    }
}

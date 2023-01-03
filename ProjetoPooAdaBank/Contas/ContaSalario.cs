﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoPooAdaBank.Clientes;

namespace ProjetoPooAdaBank.Contas
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
            this.TipoConta = 2;
            Holerite = new Holerite(cnpjEmpregador, salarioLiquido);
        }

        public void DepositarSalario(double valor, string cnpjEmpregador)
        {
            if (cnpjEmpregador == Holerite.CnpjEmpregador)
            {
                Saldo += valor;
                Extrato.Add(new Transacao("Depósito", valor, Saldo));
            }
        }

        public override double CalcularValorTarifaManutencao()
        {
            double tarifa = Saldo * 0.003;

            return tarifa;
        }
    }
}
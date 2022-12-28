using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoPooAdaBank.ContaPoupanca1 {
    internal class ContaPoupanca : Conta {

        public SaldoMinimo SaldoMinimo {get; }

        //construtor
        public ContaPoupanca(
            int numeroAgencia,
            int numeroConta,
            Cliente titular,
            double valorSaldoMinimo) : base (numeroAgencia, numeroConta, titular) 
            {

            //instanciando a classe
            SaldoMinimo = new SaldoMinimo(valorSaldoMinimo);
        }


        public void DepositarPoupanca(double valorSaldoMinimo) {

            base.Saldo += valorSaldoMinimo;
            base.Extrato.Add(new Transacao("Depósito", valorSaldoMinimo));
        }

        //método sacar levando em consideração a saldo mínimo
        public void SacarPoupanca(double valorSaldoMinimo) {
            if (valorSaldoMinimo <= Saldo) {
                Saldo -= valorSaldoMinimo;
                Extrato.Add(new Transacao("Saque", valorSaldoMinimo));

            } else {
                Console.WriteLine("O valor solicitado é maior que o saldo da conta");
            }
            

        }

        

        //implementando o metodo para calcular a tarifa de manutenção de 0,35
        public override double CalcularValorTarifaManutencao() {
            double tarifa = Saldo * 0.35;
            base.Saldo -= tarifa;

            //caso seja necessário imprimir o valor da tarifa sem o desconto direto no saldo
            //Console.WriteLine(tarifa);
            return tarifa;
        }

    }
}

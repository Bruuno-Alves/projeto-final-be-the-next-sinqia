using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoPooAdaBank.ContaPoupanca1 {
    internal class SaldoMinimo {

        //propriedade
        public double saldoMinimoPoupanca { get; private set; }

        //construtor
        public SaldoMinimo(double valorSaldoMinimo) 
            {

            //condição para criar a poupança com um limite mínimo de 50 reais
            if(valorSaldoMinimo >= 50.0) 
                {
                saldoMinimoPoupanca = valorSaldoMinimo;
            } else {
                Console.WriteLine("Saldo mínimo inválido para criar a conta poupança!");
            }
            

        }
    }
}

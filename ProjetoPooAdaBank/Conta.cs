using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoPooAdaBank
{
    public abstract class Conta
    {
        public int NumeroAgencia { get; private set; }
        public int NumeroConta { get; private set; }
        public Cliente Titular { get; set; }
        public double Saldo { get; protected set; }
        public List<Transacao> Extrato { get; private set; }
        public double ValorTaxaManutencao { get; set; } //Ideal definir o valor da taxa de manutenção dentro de cada construtor das classes filhas

        public Conta(int numeroAgencia, int numeroConta, Cliente titular)
        {
            NumeroAgencia = numeroAgencia;
            NumeroConta = numeroConta;
            Titular = titular;
            //Preciso ver como instanciar uma lista dentro de um construtor
            // Extrato = new List<Transacao>;
        }

        public void Depositar(double valor)
        {
            Saldo += valor;
            Extrato.Add(new Transacao("Depósito", valor));
        }

        public bool Sacar(double valor)
        {
            if(valor <= Saldo)
            {
                Saldo -= valor;
                Extrato.Add(new Transacao("Saque", valor));
                return true;
            }
            return false;
        }

        //O valor de cada conta pode ser definida através do valor passado dentro do construtor de
        //cada classe filha, por isso não deixei o método como virtual para ser sobrescrito
        public double CalcularValorTarifaManutencao() 
        {
            return Saldo * ValorTaxaManutencao;
        }
    }
}

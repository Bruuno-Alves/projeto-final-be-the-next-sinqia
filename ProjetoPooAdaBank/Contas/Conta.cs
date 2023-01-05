using System;
using System.Collections.Generic;
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
        public List<Transacao> Extrato { get; private set; }
        private double ValorTaxaManutencao { get; set; }
        public static int ContasAbertas { get; private set; }
        public DateTime DataAbertura { get; private set; }
        public Conta(int numeroAgencia, int numeroConta, Cliente titular)
        {
            NumeroAgencia = numeroAgencia;
            NumeroConta = numeroConta;
            Titular = titular;
            Extrato = new List<Transacao>();
            ContasAbertas++;
            DataAbertura = DateTime.Now;
        }

        public void Depositar(double valor, bool transferir = false)
        {
            Saldo += valor;

            if (transferir == false)
            {
                Extrato.Add(new Transacao("Depósito", valor, Saldo));
            }

        }

        public bool Sacar(double valor, bool transferir = false)
        {
            if (valor <= Saldo)
            {
                Saldo -= valor;

                if (transferir == false)
                {
                    Extrato.Add(new Transacao("Saque", valor, Saldo));
                }

                return true;
            }
            return false;
        }

        // VALIDAR UMA FORMA DE REUTILIZAR OS MÉTODOS DEPOSITAR + SACAR, SE NÃO, REESCREVE-LO.
        public void Transferir(double valor, Conta destino)
        {
            if (this.TipoConta != destino.TipoConta)
            {
                int taxa = 5;
                Sacar(valor + taxa, true);
                destino.Depositar(valor, true);
            }
            else
            {
                Sacar(valor, true);
                destino.Depositar(valor, true);
            }
            Extrato.Add(new Transacao("Transferência", valor, Saldo));
        }

        public virtual double CalcularValorTarifaManutencao()
        {

            return Saldo * ValorTaxaManutencao;
        }

        public void AplicarTaxaManutencao()
        {
            this.Saldo -= CalcularValorTarifaManutencao();
        }

        public void MostrarExtrato()
        {
            foreach (Transacao transacao in Extrato)
            {
                Console.WriteLine(transacao.ToString());
            }

        }
    }
}

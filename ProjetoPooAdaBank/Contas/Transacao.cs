using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoPooAdaBank.Contas
{
    public class Transacao
    {
        string Tipo { get; set; }
        public double Valor { get; set; }

        public double Taxa { get; set; }
        public double NovoSaldo { get; set;}

        public DateTime DataEHoraDaTransacao { get; private set; }
        public Transacao(string tipo, double valor, double novoSaldo)
        {
            Tipo = tipo;
            Valor = valor;
            NovoSaldo = novoSaldo;
            DataEHoraDaTransacao = DateTime.Now;
        }

        public Transacao(string tipo, double valor, double taxa, double novoSaldo)
        {
            Tipo = tipo;
            Valor = valor;
            Taxa = taxa;
            NovoSaldo = novoSaldo;
            DataEHoraDaTransacao = DateTime.Now;
        }

        public override string ToString()
        {
            if(Taxa > 0)
            {
                return $"Transação: {Tipo}\n - Valor: {Valor.ToString("C")}\n - Taxa: {Taxa.ToString("C")}\n - Saldo Atual {NovoSaldo.ToString("C")}\n - Data {DataEHoraDaTransacao}";
            }
            return $"Transação: {Tipo}\n - Valor: {Valor.ToString("C")}\n - Saldo Atual {NovoSaldo.ToString("C")}\n - Data {DataEHoraDaTransacao}";
        }

    }


}

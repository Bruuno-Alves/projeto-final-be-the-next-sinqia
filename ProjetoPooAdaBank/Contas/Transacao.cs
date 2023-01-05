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
        public double NovoSaldo { get; set;}
        public DateTime DataEHoraDaTransacao { get; private set; }
        public Transacao(string tipo, double valor, double novoSaldo)
        {
            Tipo = tipo;
            Valor = valor;
            NovoSaldo = novoSaldo;
            DataEHoraDaTransacao = DateTime.Now;
        }

        public override string ToString()
        {
            return $"Transação: {Tipo}\n - Valor: {Valor}\n - Saldo Atual {NovoSaldo}\n - Data {DataEHoraDaTransacao}";
        }
    }


}

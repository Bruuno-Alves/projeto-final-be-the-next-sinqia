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
        public Transacao(string tipo, double valor, double novoSaldo)
        {
            Tipo = tipo;
            Valor = valor;
            NovoSaldo = novoSaldo;
        }

        public override string ToString()
        {
            return $"Transação: {Tipo} - Valor: {Valor} - Saldo Atual {NovoSaldo}";
        }
    }


}

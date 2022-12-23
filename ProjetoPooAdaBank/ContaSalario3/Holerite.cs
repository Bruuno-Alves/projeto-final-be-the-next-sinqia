using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoPooAdaBank.ContaSalario3
{
    public class Holerite
    {
        public string CnpjEmpregador { get; private set; }
        public double SalarioLiquido { get; private set; }

        public Holerite(string cnpjEmpregador, double salarioLiquido)
        {
            CnpjEmpregador = cnpjEmpregador;
            SalarioLiquido = salarioLiquido;
        }
    }
}

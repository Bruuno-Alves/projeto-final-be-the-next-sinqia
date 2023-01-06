using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoPooAdaBank.Contas
{
    public class Holerite
    {
        public string CnpjEmpregador { get; private set; }
        public double SalarioLiquido { get; private set; }

        public DateTime DataHolerite { get; private set; }
        // Sugestão:
        // adicionar uma propertie data do holerite,
        // validar a diferença em relação ao Date.Now ( menor que 90 dias).


        public Holerite(string cnpjEmpregador, double salarioLiquido, DateTime dataHolerite)
        {
            CnpjEmpregador = cnpjEmpregador;
            SalarioLiquido = salarioLiquido;
            DataHolerite = dataHolerite;
        }

        public static bool ValidarDataHolerite(DateTime dataHolerite) {

            DateTime dataAtual = DateTime.Today;
            TimeSpan diferenca = dataAtual.Subtract(dataHolerite);
            if (diferenca.TotalDays <= 90) {
                return true;
            }
            return false;
        }
    }
}

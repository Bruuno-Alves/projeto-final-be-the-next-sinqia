using ProjetoPooAdaBank.ContaSalario3;
using ProjetoPooAdaBank.ContaPoupanca1;
namespace ProjetoPooAdaBank
{
    public class Program
    {
        static void Main(string[] args)
        {
            Endereco endereco1 = new Endereco("Rua Jose Batista", 44, "Centro", "Itabaiana", "SE");
            Cliente cliente1 = new Cliente("Jonas Augusto", "000.000.000-00", endereco1);
            ContaSalario cs = new ContaSalario(28, 123, cliente1, "11.111.111/0001-11", 2500);
            ContaPoupanca cp = new ContaPoupanca(13, 131313, cliente1, 50);

            Console.WriteLine(cs.Saldo);
            cs.DepositarSalario(2500, "11.111.111/0001-11");
            

            cp.DepositarPoupanca(50);
            cp.CalcularValorTarifaManutencao();
            Console.WriteLine(cp.Saldo);


            Console.WriteLine(Conta.ContasAbertas);
        }
    }
}
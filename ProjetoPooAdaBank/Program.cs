using ProjetoPooAdaBank.Clientes;
using ProjetoPooAdaBank.Contas;
namespace ProjetoPooAdaBank
{
    public class Program
    {
        static void Main(string[] args)
        {
            MenuAberturaConta menu = new MenuAberturaConta();
            menu.Menu();
        }
    }
}
using ProjetoPooAdaBank.Clientes;
using ProjetoPooAdaBank.Contas;
namespace ProjetoPooAdaBank
{
    public class Program
    {
        static void Main(string[] args)
        {
            Endereco endereco = new Endereco("Rua Jose Seabra", 190, "Jardins", "Aracaju", "SE");
            Cliente cliente = new Cliente("Jonas Augusto", "555.377.944-89", endereco);

            ContaSalario contaSalario = new ContaSalario(001, 
                                                        1234,
                                                        "jonas@gmail.com", 
                                                        "123456", 
                                                        cliente, 
                                                        "12.345.678/0001-77", 
                                                        6550.70);

            MenuAberturaConta menu = new MenuAberturaConta();
            menu.Menu();
        }
    }
}
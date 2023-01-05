using ProjetoPooAdaBank.Clientes;
using ProjetoPooAdaBank.Contas;
namespace ProjetoPooAdaBank
{
    public class Program
    {
        static void Main(string[] args)
        {
            Endereco endereco = new Endereco("Rua Jose Seabra", 190, "Jardins", "Aracaju", "SE");
            Endereco endereco2 = new Endereco("Rua Mariano Peixoto", 45, "Centro", "Natal", "RN");

            Cliente cliente = new Cliente("Jonas Augusto", "555.377.944-89", endereco);
            Cliente cliente2 = new Cliente("Rita de Cassia", "211.418.520-63", endereco2);

            ContaSalario contaSalario = new ContaSalario(001, 
                                                        1234,
                                                        "jonas@gmail.com", 
                                                        "123456", 
                                                        cliente, 
                                                        "12.345.678/0001-77", 
                                                        6550.70);

            ContaPoupanca contaPoupanca = new ContaPoupanca(002, 4567, "rita@gmail.com", "456789", cliente2, 100);

            MenuAberturaConta menu = new MenuAberturaConta();
            menu.Menu();
        }
    }
}
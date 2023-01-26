using ProjetoPooAdaBank.Clientes;
using ProjetoPooAdaBank.Contas;
namespace ProjetoPooAdaBank
{
    public class Program
    {
        static void Main(string[] args)
        {

            Endereco endereco = new Endereco("Rua Jose Seabra", 190, "Jardins", "Aracaju", "SE");
            Cliente cliente = new Cliente("Jonas Augusto", "000.000.000-00", endereco);
            Holerite holerite = new Holerite("12.345.678/0001-77", 6550.70, new DateTime(2022,11,25));

            Endereco endereco2 = new Endereco("Rua Mariano Peixoto", 45, "Centro", "Natal", "RN");
            Cliente cliente2 = new Cliente("Rita de Cassia", "111.111.111-11", endereco2);

            Endereco endereco3 = new("Faria Lima", 1964, "Pinheiros", "São Paulo","SP");
            Cliente cliente3 = new("DayTrader", "222.222.222-22",endereco3);
            Holerite holerite3 = new Holerite("12.345.678/0001-77", 6550.70, new DateTime(2022, 10, 25));

            //contas do Jonas

            ContaSalario contaSalario = new ContaSalario(1234,
                                                        "jonas@gmail.com",
                                                        "123456", 
                                                        cliente,
                                                        holerite);


            ContaPoupanca contaPoupanca2 = new ContaPoupanca(2345,"jonas@gmail.com","poupanca",cliente, 200);
            ContaInvestimento contaInvestimentoJonas = new(3456, "jonas@gmail.com", "investimento",cliente, true);

            //outras contas:
            ContaPoupanca contaPoupanca = new ContaPoupanca(4567, "rita@gmail.com", "456789", cliente2, 100);
            ContaInvestimento fariaLimer = new(9999,"sirigueijo@gmail.com","654321",cliente3,true);
            ContaSalario contaSalarioFariaLimer = new ContaSalario(9998, "sirigueijo@gmail.com", "654321", cliente3, holerite3);


            MenuAberturaConta menu = new MenuAberturaConta();
            menu.Menu();
        }
    }
}
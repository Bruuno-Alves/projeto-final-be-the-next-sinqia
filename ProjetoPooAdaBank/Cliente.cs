using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoPooAdaBank
{
    public class Cliente
    {
        public string Nome { get; private set; }
        public string Cpf { get; private set; }
        public Endereco Endereco { get; set; }

        public Cliente(string nome, string cpf, Endereco endereco) 
        {
            Nome= nome;
            Cpf= cpf;
            Endereco = endereco;
        }
    }
}

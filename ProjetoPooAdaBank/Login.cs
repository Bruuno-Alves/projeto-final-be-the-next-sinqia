using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoPooAdaBank
{
    public class Login
    {
        public string Email { get; set; }
        private string Password;

        public Login(string email, string password)
        {
            Email = email;
            Password = password;
        }

        public bool ChecarSenha(string password)
        {
            if(password == Password)
            {
                return true;
            }

            return false;
        }
    }
}

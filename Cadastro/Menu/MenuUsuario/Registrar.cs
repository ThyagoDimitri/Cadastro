using Cadastro.Banco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastro.Menu.MenuUsuario
{
    public class Registrar
    {
        private UsuarioDAL dal;

        public Registrar(List<Users> users)
        {
            dal = new UsuarioDAL();
        }

        public void RegistrarNovoUsuario()
        {
            Console.WriteLine("Digite o nome do usuário: ");
            string nome = Console.ReadLine();

            Console.WriteLine("Digite o login que deseja");
            string login = Console.ReadLine();

            Console.WriteLine("Digite qual senha será a senha deste usuário");
            string senha = Console.ReadLine();

            Users registroNovo = new Users(nome, login, senha);
            dal.RegistrarUsuario(registroNovo);
        }
    }
}

using Cadastro.Menu.MenuUsuario;

public class Users
{
    public string? Nome { get; private set; }
    public string? LoginUsers { get; private set; }
    public string Password { get; private set; }
    public int IdUsers { get; internal set; }

    public Users(string? nome, string? login, string senha)
    {
        Nome = nome;
        LoginUsers = login;
        Password = senha;
    }

    public List<Users> Usuario { get; private set; } = new List<Users>();

    private static void Main(string[] args)
    {
        ExibirOpcoesDoMenu();
    }

    public static void ExibirOpcoesDoMenu()
    {
        Registrar registrar = new Registrar(new List<Users>());
        Logar logar = new Logar();
        while (true)
        {
            Console.WriteLine("Escolha a opção que deseja: ");
            Console.WriteLine("1- Registrar");
            Console.WriteLine("2- Logar");
            Console.WriteLine("3- Sair");

            int opcao;
            if (!int.TryParse(Console.ReadLine(), out opcao))
            {
                Console.WriteLine("Opção inválida, tente novamente.");
                continue;
            }

            switch (opcao)
            {
                case 1:
                    registrar.RegistrarNovoUsuario();
                    break;
                case 2:
                    logar.LogarUsuario();
                    break;
                case 3:
                    return;
                default:
                    Console.WriteLine("Opção inválida, tente novamente.");
                    break;
            }
        }
    }
}
public class Pessoa
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public string Senha { get; set; } // Adicionando campo de senha
}
static void AdicionarPessoa()
{
    Console.Write("Nome: ");
    var nome = Console.ReadLine();

    Console.Write("Email: ");
    var email = Console.ReadLine();

    Console.Write("Senha: ");
    var senha = Console.ReadLine();

    using (var db = new ApplicationContext())
    {
        var pessoa = new Pessoa { Nome = nome, Email = email, Senha = senha };
        db.Pessoas.Add(pessoa);
        db.SaveChanges();
    }

    Console.WriteLine("Pessoa adicionada com sucesso!");
}
static void AcessarDados()
{
    Console.Write("Informe o Email: ");
    var email = Console.ReadLine();

    Console.Write("Informe a Senha: ");
    var senha = Console.ReadLine();

    using (var db = new ApplicationContext())
    {
        var pessoa = db.Pessoas.FirstOrDefault(p => p.Email == email && p.Senha == senha);

        if (pessoa != null)
        {
            Console.WriteLine($"Acesso permitido. Nome: {pessoa.Nome}, Email: {pessoa.Email}");
        }
        else
        {
            Console.WriteLine("Acesso negado. Email ou senha incorretos.");
        }
    }
}
switch (opcao)
{
    case "1":
        AdicionarPessoa();
        break;
    case "2":
        ListarPessoas();
        break;
    case "3":
        AcessarDados();
        break;
    default:
        Console.WriteLine("Opção inválida.");
        break;
}
Console.WriteLine("Escolha uma opção:");
Console.WriteLine("1 - Adicionar Pessoa");
Console.WriteLine("2 - Listar Pessoas");
Console.WriteLine("3 - Acessar Dados");

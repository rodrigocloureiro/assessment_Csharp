namespace assessment;
public class Program
{
    public delegate IRepositorio Repositorios();
    //public IRepositorio _repositorio;
    public static IRepositorio _repositorio;

    public static void TipoOperacao()
    {
        Repositorios repositorios;

        Console.WriteLine("Como deseja salvar?");
        Console.WriteLine("1- Em lista");
        Console.WriteLine("2- Em arquivo");
        int operacao = int.Parse(Console.ReadLine());

        if (operacao == 1) repositorios = () => new RepositorioEmColecao();
        else if (operacao == 2) repositorios = () => new RepositorioEmArquivo();
        else
        {
            Console.WriteLine("Opção inválida.");
            return;
        }

        //new Program()._repositorio = repositorios();
        _repositorio = repositorios();
    }

    public static void ExibirUltimosCadastros()
    {
        Console.Clear();

        List<Aluno> alunos = _repositorio.Listar();
        List<Aluno> ultimosCadastros = alunos.Count >=5 ? alunos.GetRange(alunos.Count - 5, 5) : alunos;

        if (ultimosCadastros.Count > 0 && ultimosCadastros.Count < 5) Console.WriteLine($"Há um total de {ultimosCadastros.Count} alunos cadastrados.");
        else if (ultimosCadastros.Count > 0)
        {
            Console.WriteLine("Últimos 5 cadastros:");
            ultimosCadastros.ForEach(al => Console.WriteLine(al));
        }
        else Console.WriteLine("Ainda não há alunos cadastrados.");

        Console.ReadKey();
    }

    public static void Main(string[] args)
    {
        string pathFile = "alunos.csv";

        TipoOperacao();

        ExibirUltimosCadastros();

        Menu menu = new Menu(_repositorio);

        while (true)
        {
            Console.Clear();
            Console.WriteLine("1- Visualizar alunos"); // Read
            Console.WriteLine("2- Adicionar aluno"); // Create
            Console.WriteLine("3- Editar aluno"); // Update
            Console.WriteLine("4- Apagar aluno"); // Delete
            Console.WriteLine("5- Sair");
            int opcao = int.Parse(Console.ReadLine());

            if (opcao == 5) break;

            switch (opcao)
            {
                case 1:
                    menu.ListarAluno();
                    break;
                case 2:
                    menu.AdicionarAluno();
                    break;
                case 3:
                    menu.EditarAluno();
                    break;
                case 4:
                    menu.ApagarAluno();
                    break;
            }
        }

        Console.ReadKey();
    }
}

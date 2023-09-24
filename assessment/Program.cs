namespace assessment;
public class Program
{
    public delegate IRepositorio Repositorios();
    public static IRepositorio _repositorio; //public IRepositorio _repositorio;

    public static void TipoOperacao()
    {
        Repositorios repositorios;

        Console.Clear();
        Console.WriteLine("Como deseja salvar?");
        Console.WriteLine("1- Em lista");
        Console.WriteLine("2- Em arquivo");
        int operacao = int.Parse(Console.ReadLine());

        if (operacao == 1) repositorios = () => new RepositorioEmColecao();
        else if (operacao == 2) repositorios = () => new RepositorioEmArquivo();
        else throw new Exception("Opção inválida.");

        _repositorio = repositorios(); //new Program()._repositorio = repositorios();
    }

    public static void ExibirUltimosCadastros()
    {
        Console.Clear();

        List<Aluno> alunos = _repositorio.Listar();
        List<Aluno> ultimosCadastros = alunos.Count >= 5 ? alunos.GetRange(alunos.Count - 5, 5) : alunos;

        if (ultimosCadastros.Count > 0 && ultimosCadastros.Count < 5)
            Console.WriteLine($"Há um total de {ultimosCadastros.Count} alunos cadastrados.");
        else if (ultimosCadastros.Count > 0)
        {
            Console.WriteLine("Últimos 5 cadastros:\n");
            ultimosCadastros.ForEach(al => Console.WriteLine(al));
        }
        else Console.WriteLine("Ainda não há alunos cadastrados.");

        Console.WriteLine("Aperte ENTER para continuar");
        Console.ReadKey();
    }

    public static void GerandoLog(Aluno aluno, RepositorioEventArgs e)
    {
        Console.WriteLine($"O aluno {aluno.Nome} foi {e.Acao}");
    }

    public static void Main(string[] args)
    {
        do
        {
            try
            {
                TipoOperacao();
                ExibirUltimosCadastros();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
            }
        } while (_repositorio == null);

        bool prosseguir = true;
        Menu menu = new Menu(_repositorio);
        _repositorio.RepositoryChanged += GerandoLog;

        do
        {
            Console.Clear();
            Console.WriteLine("1- Pesquisar aluno"); // Read
            Console.WriteLine("2- Adicionar aluno"); // Create
            Console.WriteLine("3- Editar aluno"); // Update
            Console.WriteLine("4- Apagar aluno"); // Delete
            Console.WriteLine("5- Sair");
            int opcao = int.Parse(Console.ReadLine());

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
                case 5:
                    prosseguir = false;
                    break;
                default:
                    Console.WriteLine("Opção inválida. Aperte ENTER e tente novamente.");
                    Console.ReadKey();
                    break;
            }

        } while (prosseguir);

        Console.ReadKey();
    }
}

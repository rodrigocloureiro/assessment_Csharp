namespace assessment
{
    public class Program
    {
        public delegate IRepositorio Repositorio();
        public static IRepositorio _repositorio; //public IRepositorio _repositorio;

        public static void TipoOperacao()
        {
            Repositorio repo = null;

            do
            {
                Console.Clear();
                Console.WriteLine("Como deseja salvar?");
                Console.WriteLine("1- Em lista");
                Console.WriteLine("2- Em arquivo");
                int.TryParse(Console.ReadLine(), out int operacao);

                switch (operacao)
                {
                    case 1:
                        repo = () => new RepositorioEmColecao();
                        //_repositorio = new RepositorioEmColecao();
                        break;
                    case 2:
                        repo = () => new RepositorioEmArquivo();
                        //_repositorio = new RepositorioEmArquivo();
                        break;
                    default:
                        Console.WriteLine("Opção inválida. Aperte ENTER e tente novamente.");
                        Console.ReadKey();
                        break;
                }
            } while (repo == null);

            _repositorio = repo(); //new Program()._repositorio = repositorios();
        }

        public static void UltimosCadastros()
        {
            Console.Clear();
            List<Aluno> ultimosCadastros = _repositorio.Listar();

            if (ultimosCadastros.Count >= 5)
            {
                Console.WriteLine("***** Últimos 5 cadastros *****\n");
                ultimosCadastros.GetRange(_repositorio.Listar().Count - 5, 5).ForEach(al => Console.WriteLine(al));
            }
            else if (ultimosCadastros.Count > 0) Console.WriteLine($"Há um total de {ultimosCadastros.Count} alunos cadastrados.");
            else Console.WriteLine("Não há alunos cadastrados.");

            Console.WriteLine("Aperte ENTER para continuar");
            Console.ReadKey();
        }

        public static void Log(Aluno aluno, RepositorioEventArgs e)
        {
            Console.WriteLine($"O aluno {aluno.Nome} foi {e.Acao}");
        }

        public static void Main(string[] args)
        {
            TipoOperacao();
            UltimosCadastros();
            bool prosseguir = true;
            Menu menu = new Menu(_repositorio);
            _repositorio.RepositoryChanged += Log;

            do
            {
                Console.Clear();
                Console.WriteLine("1- Pesquisar aluno"); // Read
                Console.WriteLine("2- Adicionar aluno"); // Create
                Console.WriteLine("3- Editar aluno"); // Update
                Console.WriteLine("4- Apagar aluno"); // Delete
                Console.WriteLine("5- Sair");
                int.TryParse(Console.ReadLine(), out int opcao);

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
}

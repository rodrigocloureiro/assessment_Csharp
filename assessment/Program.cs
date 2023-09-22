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

        if (operacao == 1) repositorios = () => new RepositorioLista();
        else if (operacao == 2) return;
        else
        {
            Console.WriteLine("Opção inválida.");
            return;
        }

        //new Program()._repositorio = repositorios();
        _repositorio = repositorios();
    }

    public static void Main(string[] args)
    {
        string pathFile = "alunos.csv";

        TipoOperacao();

        _repositorio.Adicionar(new Aluno("Rodrigo Loureiro", DateTime.ParseExact("01/03/2001", "dd/MM/yyyy", null), 9.1));
        _repositorio.Adicionar(new Aluno("Maria Vianna", DateTime.ParseExact("01/03/2001", "dd/MM/yyyy", null), 9.1));
        _repositorio.Adicionar(new Aluno("Rodrigo Vianna", DateTime.ParseExact("01/03/2001", "dd/MM/yyyy", null), 9.1));
        _repositorio.Adicionar(new Aluno("Bruno", DateTime.ParseExact("01/03/2001", "dd/MM/yyyy", null), 9.1));
        _repositorio.Adicionar(new Aluno("Ricardo", DateTime.ParseExact("01/03/2001", "dd/MM/yyyy", null), 9.1));
        _repositorio.Adicionar(new Aluno("Morais", DateTime.ParseExact("01/03/2001", "dd/MM/yyyy", null), 9.1));
        _repositorio.Adicionar(new Aluno("Gabriel", DateTime.ParseExact("01/03/2001", "dd/MM/yyyy", null), 9.1));

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

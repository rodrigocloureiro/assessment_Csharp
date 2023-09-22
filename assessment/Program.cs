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

        //_repositorio.Salvar(new Aluno("Rodrigo Loureiro", DateTime.ParseExact("01/03/2001", "dd/MM/yyyy", null), 9.1));

        //_repositorio.Listar().ForEach(al => Console.WriteLine(al));

        Console.ReadKey();
    }
}

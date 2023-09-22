namespace assessment
{
	public class Menu
	{
		private IRepositorio _repositorio;

		public Menu(IRepositorio repositorio)
		{
			_repositorio = repositorio;
		}

		public void AdicionarAluno()
		{
			Console.Write("Nome completo: ");
			string nome = Console.ReadLine();

			Console.Write("Data de nascimento (dia/mes/ano): ");
			string dataNascimento = Console.ReadLine();

			Console.Write("Média final: ");
			double mediaFinal = double.Parse(Console.ReadLine());

			_repositorio.Adicionar(new Aluno(nome, DateTime.ParseExact(dataNascimento, "dd/MM/yyyy", null), mediaFinal));
		}

		public void ListarAlunos()
		{
			_repositorio.Listar().ForEach(al => Console.WriteLine(al));
		}
	}
}

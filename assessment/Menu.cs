namespace assessment
{
	public class Menu
	{
		private IRepositorio _repositorio;

		public Menu(IRepositorio repositorio)
		{
			_repositorio = repositorio;
		}

		public void AdicionarAluno() // Create
		{
			Console.Clear();
			Console.Write("Nome completo: ");
			string nome = Console.ReadLine();

			Console.Write("Data de nascimento (dia/mes/ano): ");
			string dataNascimento = Console.ReadLine();

			Console.Write("Média final: ");
			double mediaFinal = double.Parse(Console.ReadLine());

			_repositorio.Adicionar(new Aluno(nome, DateTime.ParseExact(dataNascimento, "dd/MM/yyyy", null), mediaFinal));

			Console.WriteLine("Aluno adicionado com sucesso.");
			Console.ReadKey();
		}

		public void ListarAluno() // Read
		{
			Console.Clear();
			_repositorio.Listar().ForEach(al => Console.WriteLine(al));
			Console.ReadKey();
		}

		public void ApagarAluno() // Delete
		{
			Aluno aluno;
			Console.Clear();

			Console.Write("Informe o nome do aluno para apagar: ");
			string nome = Console.ReadLine();

			aluno = _repositorio.Listar().Find(al => al.Nome.Equals(nome));
			if (aluno != null)
			{
				Console.WriteLine("Resultado:");
				Console.WriteLine(aluno);

				Console.WriteLine("Confirma a exclusão?\n1- Sim\n2- Não");
				int opcao = int.Parse(Console.ReadLine());

				if (opcao == 1) _repositorio.Apagar(aluno);
				else Console.WriteLine("ok. Voltando..");
			}
			else
			{
				Console.WriteLine("Aluno não encontrado. Tente novamente.");
			}

            Console.ReadKey();
		}
	}
}

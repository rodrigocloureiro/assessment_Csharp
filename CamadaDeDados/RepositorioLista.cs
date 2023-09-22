namespace assessment
{
	public class RepositorioLista : IRepositorio
	{
		private List<Aluno> _alunos;

		public RepositorioLista()
		{
			_alunos = new();
		}


		public void Adicionar(Aluno aluno)
		{
			_alunos.Add(aluno);
		}

		public List<Aluno> Listar()
		{
			return _alunos;
		}

		public void Editar(Aluno aluno)
		{

		}

		public void Apagar(Aluno aluno)
		{

		}
    }
}


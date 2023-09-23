namespace assessment
{
    public class RepositorioEmColecao : IRepositorio
    {
        private List<Aluno> _alunos;

        public RepositorioEmColecao()
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

        public void Editar(Aluno aluno, Aluno alunoEditado)
        {
            int indice = _alunos.IndexOf(aluno);

            _alunos[indice] = alunoEditado;
        }

        public void Apagar(Aluno aluno)
        {
            _alunos.Remove(aluno);
        }
    }
}

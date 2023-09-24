namespace assessment
{
    public delegate void Notificacao<RepositorioEventArgs>(Aluno aluno, RepositorioEventArgs e);

    public class RepositorioEmColecao : IRepositorio
    {
        private List<Aluno> _alunos;
        public event Notificacao<RepositorioEventArgs> RepositoryChanged;

        public RepositorioEmColecao()
        {
            _alunos = new();
        }

        public void Adicionar(Aluno aluno)
        {
            _alunos.Add(aluno);
            RepositoryChanged.Invoke(aluno, new RepositorioEventArgs { Acao = "adicionado" });
        }

        public List<Aluno> Listar()
        {
            return _alunos;
        }

        public void Editar(Aluno aluno, Aluno alunoEditado)
        {
            int indice = _alunos.IndexOf(aluno);

            _alunos[indice] = alunoEditado;
            RepositoryChanged.Invoke(alunoEditado, new RepositorioEventArgs { Acao = "editado" });
        }

        public void Apagar(Aluno aluno)
        {
            _alunos.Remove(aluno);
            RepositoryChanged.Invoke(aluno, new RepositorioEventArgs { Acao = "removido" });
        }
    }
}

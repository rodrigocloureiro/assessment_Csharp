namespace assessment
{
    public delegate void Notificacao<RepositorioEventArgs>(Aluno aluno, RepositorioEventArgs e);

    public interface IRepositorio
    {
        event Notificacao<RepositorioEventArgs> RepositoryChanged;
        void Adicionar(Aluno aluno); // Create
        List<Aluno> Listar(); // Read
        void Editar(Aluno aluno, Aluno alunoEditado); // Update
        void Apagar(Aluno aluno); // Delete
    }
}

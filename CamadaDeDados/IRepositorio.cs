namespace assessment
{
    public interface IRepositorio
    {
        void Salvar(Aluno aluno); // Create
        List<Aluno> Listar(); // Read
        void Editar(Aluno aluno); // Update
        void Apagar(Aluno aluno); // Delete
    }
}

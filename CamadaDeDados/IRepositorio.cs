namespace assessment
{
    public interface IRepositorio
    {
        void Adicionar(Aluno aluno); // Create
        List<Aluno> Listar(); // Read
        void Editar(Aluno aluno); // Update
        void Apagar(Aluno aluno); // Delete
    }
}

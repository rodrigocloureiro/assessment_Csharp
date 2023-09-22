namespace assessment
{
    public interface IRepositorio
    {
        void Adicionar(Aluno aluno); // Create
        List<Aluno> Listar(); // Read
        void Editar(Aluno aluno, Aluno alunoEditado); // Update
        void Apagar(Aluno aluno); // Delete
    }
}

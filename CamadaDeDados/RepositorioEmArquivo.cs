using System.Runtime.Intrinsics.X86;

namespace assessment
{
    public class RepositorioEmArquivo : IRepositorio
    {
        private List<Aluno> _alunos;
        private string _pathFile = "alunos.csv";

        public RepositorioEmArquivo()
        {
            _alunos = new();

            if (File.Exists(_pathFile))
            {
                string[] valores = File.ReadAllLines(_pathFile);

                foreach (string valor in valores)
                {
                    string[] partes = valor.Split(";");
                    _alunos.Add(new Aluno(partes[1], DateTime.ParseExact(partes[2], "dd/MM/yyyy", null), double.Parse(partes[4]), new Guid(partes[0])));
                }
            }
            else
            {
                File.Create(_pathFile);
            }
        }

        private void PersistirNoArquivo()
        {
            List<string> alunosArquivo = _alunos.Select(al => $"{al.Id};{al.Nome};{al.DataNascimento:dd/MM/yyyy};{al.CalcularIdade()};{al.MediaFinal};{al.Aprovado}").ToList();
            File.WriteAllLines(_pathFile, alunosArquivo);
        }

        public void Adicionar(Aluno aluno) // Create
        {
            _alunos.Add(aluno);
            PersistirNoArquivo();
        }

        public List<Aluno> Listar() // Read
        {
            return _alunos;
        }

        public void Editar(Aluno aluno, Aluno alunoEditado) // Update
        {
            int indice = _alunos.IndexOf(aluno);
            _alunos[indice] = alunoEditado;
            PersistirNoArquivo();
        }

        public void Apagar(Aluno aluno) // Delete
        {
            _alunos.Remove(aluno);
            PersistirNoArquivo();
        }
    }
}

namespace assessment
{
    public class RepositorioEmArquivo : IRepositorio
    {
        private List<Aluno> _alunos;
        private const string PathFile = "alunos.csv";

        public RepositorioEmArquivo()
        {
            _alunos = new();

            if (File.Exists(PathFile))
            {
                string[] valores = File.ReadAllLines(PathFile);

                foreach (string valor in valores)
                {
                    string[] partes = valor.Split(";");
                    _alunos.Add(new Aluno(partes[1], DateTime.ParseExact(partes[2], "dd/MM/yyyy", null), double.Parse(partes[4]), new Guid(partes[0])));
                }
            }
            else
            {
                File.Create(PathFile);
            }
            Console.ReadKey();
        }

        public void Adicionar(Aluno aluno) // Create
        {
            _alunos.Add(aluno);
            List<string> aux = new();

            //IEnumerable<string> teste = _alunos.Select(al => $"{al.Id};{al.Nome};{al.DataNascimento:dd/MM/yyyy};{al.CalcularIdade()};{al.MediaFinal};{al.Aprovado}");
            //File.WriteAllLines(PathFile, teste);

            foreach (Aluno al in _alunos)
            {
                aux.Add($"{al.Id};{al.Nome};{al.DataNascimento:dd/MM/yyyy};{al.CalcularIdade()};{al.MediaFinal};{al.Aprovado}");
            }

            File.WriteAllLines(PathFile, aux);
        }

        public List<Aluno> Listar() // Read
        {
            return _alunos;
        }

        public void Editar(Aluno aluno, Aluno alunoEditado) // Update
        {
            int indice = _alunos.IndexOf(aluno);

            _alunos[indice] = alunoEditado;

            List<string> aux = new();

            foreach (Aluno al in _alunos)
            {
                aux.Add($"{al.Id};{al.Nome};{al.DataNascimento:dd/MM/yyyy};{al.CalcularIdade()};{al.MediaFinal};{al.Aprovado}");
            }

            File.WriteAllLines(PathFile, aux);
        }

        public void Apagar(Aluno aluno) // Delete
        {
            _alunos.Remove(aluno);
            List<string> aux = new();

            foreach (Aluno al in _alunos)
            {
                aux.Add($"{al.Id};{al.Nome};{al.DataNascimento:dd/MM/yyyy};{al.CalcularIdade()};{al.MediaFinal};{al.Aprovado}");
            }

            File.WriteAllLines(PathFile, aux);
        }
    }
}

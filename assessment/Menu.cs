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
            Console.Write("Informe o nome ou ID do aluno: ");
            string filtro = Console.ReadLine();

            List<Aluno> listaFiltrada =
                _repositorio.Listar()
                .Where(al => al.Nome.ToLower().Contains(filtro.ToLower()) || al.Id.ToString().Equals(filtro))
                .ToList();

            if (listaFiltrada.Count > 0)
            {
                Console.WriteLine("Escolha uma opção abaixo para visualizar mais detalhes:");
                for (int i = 0; i < listaFiltrada.Count; i++)
                {
                    Console.WriteLine($"{i+1}- {listaFiltrada.ElementAt(i).Nome}");
                }
                int.TryParse(Console.ReadLine(), out int opcao);

                if (opcao > 0 && opcao <= listaFiltrada.Count()) Console.WriteLine(listaFiltrada.ElementAt(opcao-1));
                else Console.WriteLine("Opção inválida. Tente novamente.");
            }
            else Console.WriteLine("Aluno não encontrado. Tente novamente.");

            Console.ReadKey();
        }

        public void EditarAluno() // Update
        {
            Aluno aluno;
            Console.Clear();

            Console.Write("Informe o nome do aluno para editar: ");
            string nome = Console.ReadLine();

            aluno = _repositorio.Listar().Find(al => al.Nome.Equals(nome));

            if (aluno != null)
            {
                Console.WriteLine("Resultado:");
                Console.WriteLine(aluno);

                Console.Write("\nNovo nome: ");
                string novoNome = Console.ReadLine();

                Console.Write("Nova data de nascimento (dia/mes/ano): ");
                string novaDataNascimento = Console.ReadLine();

                Console.Write("Nova média final: ");
                double novaMediaFinal = double.Parse(Console.ReadLine());

                _repositorio.Editar(aluno, new Aluno(novoNome, DateTime.ParseExact(novaDataNascimento, "dd/MM/yyyy", null), novaMediaFinal, aluno.Id));
            }
            else
            {
                Console.WriteLine("Aluno não encontrado. Tente novamente.");
            }

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

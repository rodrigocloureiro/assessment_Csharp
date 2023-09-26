namespace assessment
{
    public class Menu
    {
        private IRepositorio _repo;

        public Menu(IRepositorio repositorio)
        {
            _repo = repositorio;
        }

        private Aluno Pesquisar()
        {
            Console.Write("Informe o nome exato ou ID do aluno: ");
            string pesquisa = Console.ReadLine();

            return _repo.Listar().Find(al => al.Nome.ToLower().Equals(pesquisa.ToLower()) || al.Id.ToString().Equals(pesquisa));
        }

        private List<Aluno> Filtrar()
        {
            Console.Write("Informe o nome ou ID do aluno: ");
            string filtro = Console.ReadLine();

            return _repo.Listar()
                .Where(al => al.Nome.ToLower().Contains(filtro.ToLower()) || al.Id.ToString().Equals(filtro))
                .ToList();
        }

        public void AdicionarAluno() // Create
        {
            Console.Clear();
            Console.Write("Nome: ");
            string nome = Console.ReadLine();

            Console.Write("Data de nascimento (dia/mês/ano): ");
            string dataNascimento = Console.ReadLine();

            Console.Write("Média final: ");
            double mediaFinal = double.Parse(Console.ReadLine());

            _repo.Adicionar(new Aluno(nome, DateTime.ParseExact(dataNascimento, "dd/MM/yyyy", null), mediaFinal));

            Console.ReadKey();
        }

        public void ListarAluno() // Read
        {
            Console.Clear();
            List<Aluno> listaFiltrada = Filtrar();

            if (listaFiltrada.Count > 0)
            {
                Console.WriteLine("Escolha uma opção abaixo para visualizar mais detalhes:");
                for (int i = 0; i < listaFiltrada.Count; i++)
                {
                    Console.WriteLine($"{i + 1}- {listaFiltrada.ElementAt(i).Nome}");
                }
                int.TryParse(Console.ReadLine(), out int opcao);

                if (opcao > 0 && opcao <= listaFiltrada.Count()) Console.WriteLine(listaFiltrada.ElementAt(opcao - 1));
                else Console.WriteLine("Opção inválida. Tente novamente.");
            }
            else Console.WriteLine("Aluno não encontrado. Tente novamente.");

            Console.ReadKey();
        }

        public void EditarAluno() // Update
        {
            Console.Clear();
            Aluno aluno = Pesquisar();

            if (aluno != null)
            {
                Console.WriteLine("Resultado:");
                Console.WriteLine(aluno);

                Console.WriteLine("Informe os dados para edição:");
                Console.Write("Novo nome: ");
                string novoNome = Console.ReadLine();

                Console.Write("Nova data de nascimento (dia/mes/ano): ");
                string novaDataNascimento = Console.ReadLine();

                Console.Write("Nova média final: ");
                double novaMediaFinal = double.Parse(Console.ReadLine());

                _repo.Editar(aluno, new Aluno(novoNome, DateTime.ParseExact(novaDataNascimento, "dd/MM/yyyy", null), novaMediaFinal, aluno.Id));
            }
            else
            {
                Console.WriteLine("Aluno não encontrado. Tente novamente.");
            }

            Console.ReadKey();
        }

        public void ApagarAluno() // Delete
        {
            Console.Clear();
            Aluno aluno = Pesquisar();

            if (aluno != null)
            {
                Console.WriteLine("Resultado:");
                Console.WriteLine(aluno);

                Console.WriteLine("Confirma a exclusão?\n1- Sim\n2- Não");
                int.TryParse(Console.ReadLine(), out int opcao);

                switch (opcao)
                {
                    case 1:
                        _repo.Apagar(aluno);
                        break;
                    case 2:
                        Console.WriteLine("Aluno NÃO removido.");
                        break;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }
            }
            else Console.WriteLine("Aluno não encontrado. Tente novamente.");

            Console.ReadKey();
        }
    }
}

namespace assessment
{
    public class Aluno
    {
        private string _nome;
        private DateTime _dataNascimento;
        private bool _aprovado;
        private double _mediaFinal;
        private Guid _id;

        public Aluno(string nome, DateTime dataNascimento, double mediaFinal)
        {
            _nome = nome;
            _dataNascimento = dataNascimento;
            _mediaFinal = mediaFinal;
        }

        public string Nome { get { return _nome; } }
        public DateTime DataNasicmento { get { return _dataNascimento; } }
        public bool Aprovado { get { return _aprovado; } }
        public double MediaFinal { get { return _mediaFinal; } }
        public Guid Id { get { return _id; } }

        private int CalcularIdade()
        {
            DateTime agora = DateTime.Now;

            if (_dataNascimento.Month < agora.Month || _dataNascimento.Month == agora.Month && _dataNascimento.Day < agora.Day)
                return (agora.Year - _dataNascimento.Year) - 1;
            else
                return agora.Year - _dataNascimento.Year;
        }
    }
}


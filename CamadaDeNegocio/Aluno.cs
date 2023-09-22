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
    }
}


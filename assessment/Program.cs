using System.Globalization;

namespace assessment;
public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        string pathFile = "alunos.csv";

        Aluno al = new Aluno("Rodrigo Loureiro", DateTime.ParseExact("01/03/2001", "dd/MM/yyyy", CultureInfo.CurrentCulture), 9.1);

        Console.WriteLine(al);

        Console.ReadKey();
    }
}

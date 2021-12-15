using MySql.Data.MySqlClient;
using Desafio_06;

public class Program
{
    public static void Main()
    {
        string connStr = "server=localhost;user=root;database=desafio_06;port=3306;password=Lolmicrosoft126";

        List<string> listName = new List<string>();
        Aluno aluno = new Aluno();

        Console.WriteLine("Qual o nome do aluno ?\n");
        aluno.Name=Console.ReadLine();
        listName.Add(aluno.Name);
  
        List<int> listIdade = new List<int>();
        Console.WriteLine("Qual a idade do aluno ?\n");
        aluno.Idade=Convert.ToInt32(Console.ReadLine());
        listIdade.Add(aluno.Idade);

        List<decimal> listNota=new List<decimal>();
        Console.WriteLine("Qual a nota do aluno ?\n");
        aluno.Nota=Convert.ToDecimal(Console.ReadLine());
        listNota.Add(aluno.Nota);

        Guid id = Guid.NewGuid();

        using (var conn = new MySqlConnection(connStr))

        {
            MySqlCommand comm = conn.CreateCommand();
            conn.Open();

            comm.CommandText = $"INSERT INTO alunos (idAlunos,Nome,Idade,Notas) VALUES (?idAlunos,?Nome,?Idade,?Notas)";
            comm.Parameters.AddWithValue($"@idAlunos", $"{id}");
            comm.Parameters.AddWithValue($"@Nome", $"{aluno.Name}");
            comm.Parameters.AddWithValue($"@Idade", $"{aluno.Idade}");
            comm.Parameters.AddWithValue($"@Notas", $"{aluno.Nota}");

            var somaNotas = new MySqlCommand("SELECT sum(notas) FROM Alunos",conn);

            comm.ExecuteNonQuery();
            var soma = somaNotas.ExecuteScalar();

            conn.Close();

            Console.WriteLine($"A soma das notas é igual a: {soma}");
        }
        Console.WriteLine("Desafio concluído!.");
    }
}
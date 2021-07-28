using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using CsvHelper;
using System.Globalization;
using System.Text;

namespace Desafio_6
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Aluno> aluno = new List<Aluno>();
            aluno.Add(new Aluno { nome = "John Smith", idade = 12, nota = 7 });
            aluno.Add(new Aluno { nome = "Ana Lee", idade = 13, nota = 9 });
            aluno.Add(new Aluno { nome = "Maria Jane", idade = 13, nota = 8 });

            foreach (var estudante in aluno)
            {
                Console.WriteLine((" " + estudante.nome + "\t"));
                Console.WriteLine((" Idade: " + estudante.idade + "\t"));
                Console.WriteLine(" Nota final: " + estudante.nota + "\t" + "\n");
            }
            int[] notas = { 7, 9, 8 };
            int soma = notas.Sum();
            Console.WriteLine(" A Soma das notas: " + soma);

            //RELATORIO PARA CADA ALUNO

            StringBuilder csvcontent = new StringBuilder();
            csvcontent.AppendLine(", Relatório, ");
            csvcontent.AppendLine("Alunos,Idade,Nota");
            csvcontent.AppendLine("Ana Lee, 13,9");
            csvcontent.AppendLine("John Smith,12,7");
            csvcontent.AppendLine("Maria Jane, 13,8");
            csvcontent.AppendLine(", ,");
            csvcontent.AppendLine("Total de notas, ," + soma);

            string csvpath = @"C:\Users\User\OneDrive\Documents\Desafio_06\Lee_boletim.csv";
            File.AppendAllText(csvpath, csvcontent.ToString());

            string csvpath2 = @"C:\Users\User\OneDrive\Documents\Desafio_06\Smith_boletim.csv";
            File.AppendAllText(csvpath2, csvcontent.ToString());

            string csvpath3 = @"C:\Users\User\OneDrive\Documents\Desafio_06\Jane_boletim.csv";
            File.AppendAllText(csvpath3, csvcontent.ToString());

        }
    }
}


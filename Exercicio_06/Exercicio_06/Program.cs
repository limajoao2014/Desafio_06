using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Desafio_06
{
    public class Aluno
    {
        public string nome;
        public int idade;
        public double nota;


        public string Nome { get; set; }
        public int Idade { get; set; }
        public double Nota { get; set; }
        public Aluno(string nome, int idade, double nota)
        {
            Nome = nome;
            this.nome = nome;

            Idade = idade;
            this.idade = Idade;

            Nota = nota;
            this.nota = nota;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Aluno[] alunosArray = new Aluno[3];

            // for para coletar os dados dos alunos
            for (int i = 0; i < alunosArray.Length; i++)
            {
                int count = i + 1;

                Console.WriteLine("Qual o nome do aluno {0}?", count);
                string nome = Console.ReadLine();

                Console.WriteLine("Qual a idade do {0}?", nome);
                int idade = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Qual a nota do {0}?", nome);
                double nota = double.Parse(Console.ReadLine(), System.Globalization.CultureInfo.InvariantCulture);

                alunosArray[i] = new Aluno(nome, idade, nota);
            }

            // Alunos em lista
            List<Aluno> alunosList = new List<Aluno>();

            alunosList.Add(new Aluno(alunosArray[0].nome, alunosArray[0].idade, alunosArray[0].nota));
            alunosList.Add(new Aluno(alunosArray[1].nome, alunosArray[1].idade, alunosArray[1].nota));
            alunosList.Add(new Aluno(alunosArray[2].nome, alunosArray[2].idade, alunosArray[2].nota));

            //foreach para exportar para o excel
            foreach (Aluno aluno in alunosList)
            {
                //configurando o diretorio
                var diretorio = System.IO.Path.GetFullPath(@"..\..\..\Arquivos\");
                var nomeArquivo = $"{aluno.nome}-{Guid.NewGuid().ToString().Substring(0, 4)}.csv";

                //exportação para o excel
                using (SpreadsheetDocument arquivo = SpreadsheetDocument.Create($"{diretorio}{nomeArquivo}", SpreadsheetDocumentType.Workbook))
                {
                    //nomeando o workbook e sheet
                    WorkbookPart workbookpart = arquivo.AddWorkbookPart();
                    workbookpart.Workbook = new Workbook();

                    WorksheetPart worksheetPart = workbookpart.AddNewPart<WorksheetPart>();
                    SheetData sheetData = new SheetData();
                    worksheetPart.Worksheet = new Worksheet(sheetData);

                    //configurando a tab com o nome Dados
                    Sheets sheets = arquivo.WorkbookPart.Workbook.AppendChild<Sheets>(new Sheets());
                    Sheet sheet = new Sheet()
                    {
                        Id = arquivo.WorkbookPart.GetIdOfPart(worksheetPart),
                        SheetId = 1,
                        Name = "Dados"
                    };

                    List<Row> linhas  = new List<Row>();

                    //exportando primeira linha
                    Row header = new Row() { RowIndex = 1 };
                    header.Append(new Cell() { CellReference = "A1", CellValue = new CellValue("Nome"), DataType = CellValues.String });
                    header.Append(new Cell() { CellReference = "B1", CellValue = new CellValue("Idade"), DataType = CellValues.String });
                    header.Append(new Cell() { CellReference = "C1", CellValue = new CellValue("Nota"), DataType = CellValues.String });
                    linhas.Add(header);

                    //exportando segunda linha
                    Row dados = new Row() { RowIndex = 2 };
                    dados.Append(new Cell() { CellReference = $"A{dados.RowIndex}", CellValue = new CellValue(aluno.nome), DataType = CellValues.String });
                    dados.Append(new Cell() { CellReference = $"B{dados.RowIndex}", CellValue = new CellValue(aluno.idade), DataType = CellValues.Number });
                    dados.Append(new Cell() { CellReference = $"C{dados.RowIndex}", CellValue = new CellValue(aluno.nota), DataType = CellValues.Number });
                    linhas.Add(dados);

                    sheetData.Append(linhas);
                    sheets.Append(sheet);

                    workbookpart.Workbook.Save();
                }
            }
        }
    }
}

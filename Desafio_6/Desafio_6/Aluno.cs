using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Desafio_6
{
    class Aluno
    {
        public string nome { get; set; }
        public int idade { get; set; }
        public double nota { get; set; }

        public void Nota()
        {
            Aluno[] alunos = {
            new Aluno{nome = "John Smith", idade =12, nota=7},
            new Aluno{nome = "Ana Lee", idade =13, nota=9},
            new Aluno{nome = "Maria Jane", idade =13, nota=8},
            };
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testandoBanco
{
    [Table]
  public  class Aluno
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int id { get; set; }
        [Column]
        public string Nome { get; set; }
        [Column]
        public string Turma { get; set; }
        [Column]
        public string Local { get; set; }

        public override string ToString()
        {

            return Nome + Turma + Local;

        }

        
    }
}

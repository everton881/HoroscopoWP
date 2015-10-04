using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testandoBanco
{
    public class AlunoContext : DataContext
    {

        public AlunoContext() : base("isostore:/ aluno.sdf") { }
        public Table<Aluno> alunos;
    }
}

using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Horoscopo
{

    [Table]
    public class Horoscopo
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true )]
        public int Id { get; set; }
        [Column(IsPrimaryKey = true)]
        public string Nome { get; set; }
        [Column]
        public string Data { get; set; }
        [Column]
        public string Mensagem { get; set; }
        [Column]
        public string Icone { get; set; }


    }
}

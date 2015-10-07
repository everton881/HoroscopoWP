using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Horoscopo
{
    class HoroscopoContext :DataContext
    {

        public HoroscopoContext() : base("isostore:/banco.sdf") { }
        public Table<Horoscopo> signos;

      
    }
}

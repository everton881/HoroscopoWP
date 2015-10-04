using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Horoscopo
{
    [DataContract]
    public class HoroscopoJson
    {
        [DataMember(Name = "nome")]
        public string nome { get; set; }
        [DataMember(Name = "data")]
        public string data { get; set; }
        [DataMember(Name = "msg")]
        public string msg { get; set; }

    }
}
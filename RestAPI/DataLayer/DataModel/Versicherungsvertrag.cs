using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestAPI.Model
{
    public class Versicherungsvertrag
    {
        public int ID { get; set; }
        public int Benutzer { get; set; }
        public int Versicherungspolice { get; set; }
    }
}

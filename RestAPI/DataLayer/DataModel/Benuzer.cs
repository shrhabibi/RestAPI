using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestAPI.Model
{
    public class Benuzer
    {
        public int ID { get; set; }
        public string Benutzername { get; set; }
        public string Kennwort { get; set; }
        public string Vorname { get; set; }
        public string Nachname { get; set; }
        public string Telefonnummer { get; set; }
        public string Adresse { get; set; }
    }
}

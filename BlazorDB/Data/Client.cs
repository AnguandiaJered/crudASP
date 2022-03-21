using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorDB.Data
{
    public class Client
    {
        public int Id { set; get; }
        public string Noms { set; get; }
        public string Sexe { set; get; }
        public DateTime Datenaissance { set; get; }
        public string Adresse { set; get; }
        public string Telephone { set; get; }
        public string Ville { set; get; }
        public string Nationalite { set; get; }
    }
}

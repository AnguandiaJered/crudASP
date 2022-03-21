using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorDB.Data
{
    public class Compte
    {
        public int Id { set; get; }
        public string NumCompte { set; get; }
        public string TypeCompte { set; get; }
        public DateTime DateCreate { set; get; }
        public decimal Solde { set; get; }
        public string RefClient { set; get; }
        public string Author { set; get; }
    }
}

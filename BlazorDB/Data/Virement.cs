using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorDB.Data
{
    public class Virement
    {
        public int Id { set; get; }
        public decimal Montant { set; get; }
        public string RefCompte { set; get; }
        public string Compte2 { set; get; }
        public DateTime Datevirement { set; get; }
        public string Author { set; get; }
    }
}

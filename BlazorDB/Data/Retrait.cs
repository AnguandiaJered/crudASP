using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorDB.Data
{
    public class Retrait
    {
        public int Id { set; get; }
        public string RefClient { set; get; }
        public string RefCompte { set; get; }
        public decimal Montant { set; get; }
        public string Devise { set; get; }
        public DateTime DateRetrait { set; get; }
        public string Author { set; get; }
    }
}

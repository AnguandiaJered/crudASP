using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorDB.Data
{
    public class DepotModel:Depot
    {
        public string ClientName { set; get; }
        public string CompteName { set; get; }
    }
}

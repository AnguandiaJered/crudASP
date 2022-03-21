using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorDB.Data.Interfaces
{
    interface IDepotService
    {
        Task<IEnumerable<DepotModel>> GetDepot();
        Task<bool> CreateDepot(Depot depot);
        Task<DepotModel> SingleDepot(int id);
        Task<bool> DeleteDepot(int id);
        Task<bool> UpdateDepot(int id, Depot depot);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorDB.Data.Interfaces
{
    interface IVirementService
    {
        Task<IEnumerable<VirementModel>> GetVirement();
        Task<bool> CreateVirement(Virement virement);
        Task<VirementModel> SingleVirement(int id);
        Task<bool> DeleteVirement(int id);
        Task<bool> UpdateVirement(int id, Virement virement);
    }
}

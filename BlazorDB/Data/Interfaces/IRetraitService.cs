using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorDB.Data.Interfaces
{
    interface IRetraitService
    {
        Task<IEnumerable<RetraitModel>> GetRetrait();
        Task<bool> CreateRetrait(Retrait retrait);
        Task<RetraitModel> SingleRetrait(int id);
        Task<bool> DeleteRetrait(int id);
        Task<bool> UpdateRetrait(int id, Retrait retrait);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorDB.Data.Interfaces
{
    interface ICompteService
    {
        Task<IEnumerable<CompteModel>> GetCompte();
        Task<bool> CreateCompte(Compte compte);
        Task<CompteModel> SingleCompte(int id);
        Task<bool> DeleteComte(int id);
        Task<bool> UpdateCompte(int id, Compte compte);
    }
}

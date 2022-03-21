using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorDB.Data.Interfaces
{
   public interface IClientService
    {
        Task<IEnumerable<Client>> GetClients();
        Task<bool> CreateClient(Client client);
        Task<bool> EditClient(int id, Client client);
        Task<Client> SingleClient(int id);
        Task<bool> DeleteClient(int id);
    }
}

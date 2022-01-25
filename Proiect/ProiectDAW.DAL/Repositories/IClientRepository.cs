using ProiectDAW.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectDAW.DAL.Repositories
{
    public interface IClientRepository
    {
        IQueryable<Client> GetClients();
        IQueryable<object> GetClientsWithRentalsInfo();
        IQueryable<Client> GetClientsWithInfo();
        void Create(Client client);
        void Update(Client client);
        void Delete(Client client);
    }
}

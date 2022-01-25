using ProiectDAW.DAL.Entities;
using ProiectDAW.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectDAW.BLL.Managers
{
    public interface IClientManager
    {
        List<Client> GetClients();
        List<object> GetClientsWithRentalsInfo();
        List<Client> GetClientsWithInfo();
        Client GetClientById(int id);
        void Create(ClientModel model);
        void Update(ClientModel model);
        void Delete(int id);
    }
}

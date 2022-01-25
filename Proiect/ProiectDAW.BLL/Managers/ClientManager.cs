using ProiectDAW.DAL.Entities;
using ProiectDAW.DAL.Models;
using ProiectDAW.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectDAW.BLL.Managers
{
    public class ClientManager : IClientManager
    {
        private readonly IClientRepository repo;

        public ClientManager(IClientRepository clientRepo)
        {
            this.repo = clientRepo;
        }

        public void Create(ClientModel model)
        {
            var newClient = new Client
            {
                LastName = model.LastName,
                FirstName = model.FirstName
            };

            repo.Create(newClient);
        }

        public void Delete(int id)
        {
            var client = GetClientById(id);

            repo.Delete(client);
        }

        public Client GetClientById(int id)
        {
            var client = repo.GetClients().FirstOrDefault(x => x.Id == id);

            return client;
        }

        public List<Client> GetClients()
        {
            var clients = repo.GetClients().ToList();

            return clients;
        }

        public List<Client> GetClientsWithInfo()
        {
            var clients = repo.GetClientsWithInfo().ToList();

            return clients;
        }

        public List<object> GetClientsWithRentalsInfo()
        {
            var clients = repo.GetClientsWithRentalsInfo().ToList();

            return clients;
        }

        public void Update(ClientModel model)
        {
            var client = GetClientById(model.Id);

            client.LastName = model.LastName;
            client.FirstName = model.FirstName;

            repo.Update(client);
        }
    }
}

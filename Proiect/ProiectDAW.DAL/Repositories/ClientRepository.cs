using Microsoft.EntityFrameworkCore;
using ProiectDAW.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectDAW.DAL.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly AppDbContext db;

        public ClientRepository(AppDbContext context)
        {
            this.db = context;
        }

        public void Create(Client client)
        {
            db.Clients.Add(client);

            db.SaveChanges();
        }

        public void Delete(Client client)
        {
            db.Clients.Remove(client);

            db.SaveChanges();
        }

        public IQueryable<Client> GetClients()
        {
            var clients = db.Clients;

            return clients;
        }

        public IQueryable<object> GetClientsWithRentalsInfo()
        {
            var clients = GetClients();
            var join = db.ClientCar.Join(clients, b => b.ClientId, a => a.Id, (b, a) => new
            {
                b.ClientId,
                a.LastName,
                a.FirstName,
                b.DayNumber,
                b.DayPrice
            });

            return join;
        }

        public IQueryable<Client> GetClientsWithInfo()
        {
            var clients = GetClients().Include(x => x.ClientInfo);

            return clients;
        }

        public void Update(Client client)
        {
            db.Clients.Update(client);

            db.SaveChanges();
        }
    }
}

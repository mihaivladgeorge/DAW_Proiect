using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectDAW.DAL.Entities
{
    public class Client
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }

        public virtual ClientInfo ClientInfo { get; set; }
        public virtual ICollection<ClientCar> ClientCar { get; set; }
    }
}

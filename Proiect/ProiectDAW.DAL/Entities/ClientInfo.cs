using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectDAW.DAL.Entities
{
    public class ClientInfo
    {
        public int Id { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string County { get; set; }
        public DateTime BirthDate { get; set; }
        public int ClientId { get; set; }

        public virtual Client Client { get; set; }
    }
}

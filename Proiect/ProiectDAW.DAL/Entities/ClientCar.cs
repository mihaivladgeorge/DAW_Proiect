using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectDAW.DAL.Entities
{
    public class ClientCar
    {
        public DateTime RentDate { get; set; }
        public int DayNumber { get; set; }
        public int DayPrice { get; set; }
        public int ClientId { get; set; }
        public int CarId { get; set; }

        public virtual Client Client { get; set; }
        public virtual Car Car { get; set; }

    }
}

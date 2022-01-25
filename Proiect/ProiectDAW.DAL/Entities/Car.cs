using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectDAW.DAL.Entities
{
    public class Car
    {
        public int Id { get; set; }
        public string ModelName { get; set; }
        public int ProductionYear { get; set; }
        public int Mileage { get; set; }
        public string Color { get; set; }
        public int ManufacturerId { get; set; }

        public virtual Manufacturer Manufacturer { get; set; }
        public virtual ICollection<ClientCar> ClientCar { get; set; }
    }
}

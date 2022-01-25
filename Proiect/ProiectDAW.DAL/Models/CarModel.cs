using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectDAW.DAL.Models
{
    public class CarModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public string ModelName { get; set; }
        public int ProductionYear { get; set; }
        public int Mileage { get; set; }
        public string Color { get; set; }
        public int ManufacturerId { get; set; }
    }
}

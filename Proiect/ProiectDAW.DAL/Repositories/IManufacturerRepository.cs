using ProiectDAW.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectDAW.DAL.Repositories
{
    public interface IManufacturerRepository
    {
        IQueryable<Manufacturer> GetManufacturers();
        IQueryable<Manufacturer> GetCarsForManufacturer();
        void Create(Manufacturer manufacturer);
        void Update(Manufacturer manufacturer);
        void Delete(Manufacturer manufacturers);
    }
}

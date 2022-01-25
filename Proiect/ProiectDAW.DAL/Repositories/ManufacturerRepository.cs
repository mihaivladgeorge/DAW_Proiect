using Microsoft.EntityFrameworkCore;
using ProiectDAW.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectDAW.DAL.Repositories
{
    public class ManufacturerRepository : IManufacturerRepository
    {
        private readonly AppDbContext db;

        public ManufacturerRepository(AppDbContext context)
        {
            this.db = context;
        }

        public void Create(Manufacturer manufacturer)
        {
            db.Manufacturers.Add(manufacturer);

            db.SaveChanges();
        }

        public void Delete(Manufacturer manufacturer)
        {
            db.Manufacturers.Remove(manufacturer);

            db.SaveChanges();
        }

        public IQueryable<Manufacturer> GetCarsForManufacturer()
        {
            var manufacturersWithCars = GetManufacturers().Include(x => x.Cars);

            return manufacturersWithCars;
        }

        public IQueryable<Manufacturer> GetManufacturers()
        {
            var manufacturers = db.Manufacturers;

            return manufacturers;
        }

        public void Update(Manufacturer manufacturer)
        {
            db.Manufacturers.Update(manufacturer);

            db.SaveChanges();
        }
    }
}

using Microsoft.EntityFrameworkCore;
using ProiectDAW.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectDAW.DAL.Repositories
{
    public class CarRepository : ICarRepository
    {
        private readonly AppDbContext db;

        public CarRepository(AppDbContext context)
        {
            this.db = context;
        }

        public IQueryable<Car> GetCars()
        {
            var cars = db.Cars;

            return cars;
        }

        public IQueryable<Car> GetCarsWithManufacturer()
        {
            var cars = GetCars().Include(x => x.Manufacturer);

            return cars;
        }

        public void Create(Car car)
        {
            db.Cars.Add(car);

            db.SaveChanges();
        }

        public void Update(Car car)
        {
            db.Cars.Update(car);

            db.SaveChanges();
        }

        public void Delete(Car car)
        {
            db.Cars.Remove(car);

            db.SaveChanges();
        }

        public IQueryable<object> GetCarsWithAvgPrice()
        {
            var cars = db.ClientCar.GroupBy(x => x.CarId).Select(x => new
            {
                CarId = x.Key,
                Avg = x.Average(x => x.DayPrice),
            });

            return cars;
        }
    }
}

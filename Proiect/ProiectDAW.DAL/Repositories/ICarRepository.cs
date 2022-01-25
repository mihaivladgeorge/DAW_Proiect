using ProiectDAW.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectDAW.DAL.Repositories
{
    public interface ICarRepository
    {
        IQueryable<Car> GetCars();
        IQueryable<Car> GetCarsWithManufacturer();
        IQueryable<object> GetCarsWithAvgPrice();
        void Create(Car car);
        void Update(Car car);
        void Delete(Car car);
    }
}

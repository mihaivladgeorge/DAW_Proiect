using ProiectDAW.DAL.Entities;
using ProiectDAW.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectDAW.BLL.Managers
{
    public interface ICarManager
    {
        List<Car> GetCars();
        List<Car> GetCarsWithManufacturer();
        Car GetCarById(int id);
        List<object> GetCarsWithAvgPrice();
        void Create(CarModel model);
        void Update(CarModel model);
        void Delete(int id);
    }
}

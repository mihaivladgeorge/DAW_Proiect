using ProiectDAW.DAL.Entities;
using ProiectDAW.DAL.Models;
using ProiectDAW.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectDAW.BLL.Managers
{
    public class CarManager : ICarManager
    {
        private readonly ICarRepository repo;

        public CarManager(ICarRepository carRepository)
        {
            this.repo = carRepository;
        }

        public List<Car> GetCars()
        {
            return repo.GetCars().ToList();
        }

        public List<Car> GetCarsWithManufacturer()
        {
            var cars = repo.GetCarsWithManufacturer();

            return cars.ToList();
        }

        public Car GetCarById(int id)
        {
            var car = repo.GetCars().FirstOrDefault(x => x.Id == id);

            return car;
        }

        public void Create(CarModel model)
        {
            var newCar = new Car
            {
                ModelName = model.ModelName,
                ProductionYear = model.ProductionYear,
                Mileage = model.Mileage,
                Color = model.Color,
                ManufacturerId = model.ManufacturerId
            };

            repo.Create(newCar);
        }

        public void Update(CarModel model)
        {
            var car = GetCarById(model.Id);

            car.ModelName = model.ModelName;
            car.ProductionYear = model.ProductionYear;
            car.Mileage = model.Mileage;
            car.Color = model.Color;
            car.ManufacturerId = model.ManufacturerId;

            repo.Update(car);
        }

        public void Delete(int id)
        {
            var car = GetCarById(id);

            repo.Delete(car);
        }

        public List<object> GetCarsWithAvgPrice()
        {
            var cars = repo.GetCarsWithAvgPrice();

            return cars.ToList();
        }
    }
}

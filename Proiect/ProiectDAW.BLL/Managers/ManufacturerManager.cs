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
    public class ManufacturerManager : IManufacturerManager
    {
        private readonly IManufacturerRepository repo;

        public ManufacturerManager(IManufacturerRepository manufacturerRepository)
        {
            this.repo = manufacturerRepository;
        }

        public void Create(ManufacturerModel manufacturerModel)
        {
            var newManufacturer = new Manufacturer
            {
                Name = manufacturerModel.Name,
                Country = manufacturerModel.Country
            };

            repo.Create(newManufacturer);
        }

        public void Delete(int id)
        {
            var manufacturer = GetManufacturerById(id);

            repo.Delete(manufacturer);
        }

        public List<Manufacturer> GetCarsForManufacturers()
        {
            var manufacturers = repo.GetCarsForManufacturer();

            return manufacturers.ToList();
        }

        public Manufacturer GetManufacturerById(int id)
        {
            var manufacturer = repo.GetManufacturers().FirstOrDefault(x => x.Id == id);

            return manufacturer;
        }

        public List<Manufacturer> GetManufacturers()
        {
            var manufacturers = repo.GetManufacturers();

            return manufacturers.ToList();
        }

        public void Update(ManufacturerModel manufacturerModel)
        {
            var manufacturer = GetManufacturerById(manufacturerModel.Id);

            manufacturer.Name = manufacturerModel.Name;
            manufacturer.Country = manufacturerModel.Country;

            repo.Update(manufacturer);
        }
    }
}

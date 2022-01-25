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
    public interface IManufacturerManager
    {
        List<Manufacturer> GetManufacturers();
        List<Manufacturer> GetCarsForManufacturers();
        Manufacturer GetManufacturerById(int id);
        void Create(ManufacturerModel manufacturerModel);
        void Update(ManufacturerModel manufacturerModel);
        void Delete(int id);

    }
}

using CarBook.Application.Interfaces.CarInterfaces;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistence.Repositories.CarRepositories
{
    public class CarRepository : ICarRepository
    {
        private readonly CarBookContext _db;

        public CarRepository(CarBookContext db)
        {
            _db = db;
        }

        public List<Car> GetCarsListWithBrands()
        {
            var values =  _db.Cars.Include(x=>x.Brand).ToList();
            return values;
        }

        public List<CarPricing> GetCarsWithPricings()
        {
            var val = _db.CarPricings.Include(x=>x.Car).ThenInclude(y=>y.Brand).Include(z=>z.Pricing).Where(x=>x.PricingID==2).ToList();
            return val;
        }

        public List<Car> GetLast5CarsListWithBrands()
        {
            var val = _db.Cars.Include(x => x.Brand).OrderByDescending(x=>x.CarID).Take(5).ToList();
            return val;
        }
    }
}

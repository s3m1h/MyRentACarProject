using DataAccess.Abstract;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{ Id = 1,BrandId = 1, ColorId = 1,ModelYear=2000},
                new Car{ Id = 2,BrandId = 1, ColorId = 3,ModelYear=2002},
                new Car{ Id = 3,BrandId = 2, ColorId = 3,ModelYear=2003},
                new Car{ Id = 4,BrandId = 2, ColorId = 5,ModelYear=2004},
                new Car{ Id = 5,BrandId = 3, ColorId = 5,ModelYear=2005},
                new Car{ Id = 6,BrandId = 3, ColorId = 7,ModelYear=2006},
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car car1 = _cars.SingleOrDefault(c=>c.Id ==car.Id);
            _cars.Remove(car1);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public void GetById()
        {
            throw new NotImplementedException();
        }

        public Car GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car car1 = _cars.SingleOrDefault(c => c.Id == car.Id);
            car1.ModelYear = car.ModelYear;
            car1.BrandId = car.BrandId;
            car1.ColorId = car.ColorId;
            car1.DailyPrice = car.DailyPrice;
            car1.Description = car.Description;
        }
    }
}

﻿using Business.Abstract;
using DataAccess.Abstract;
using Entities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public void Add(Car car)
        {
            if(car.Description.Length > 2 && car.DailyPrice >0)
            {
                _carDal.Add(car);
            }
            // ekleme yaparken aynı isimde veri varsa ekleme yapmasın hata versin
            else
            {
                throw new Exception("minimum 2 karakter olmalı");
            }
        }

        public void Delete(Car car)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public List<Car> GetCarsByBrandId(int id)
        {
            return _carDal.GetAll(c => c.BrandId == id);
        }

        public List<Car> GetCarsByColorId(int id)
        {
            return _carDal.GetAll(c=>c.ColorId == id);
        }

        public void Update(Car car)
        {
            throw new NotImplementedException();
        }
    }
}

using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConserns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
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

        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {
            
            _carDal.Add(car);
            return new SuccessResult();

        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult();
        }

        public IDataResult<Car> Get(int id)
        {
            var result = _carDal.GetById(c=>c.Id == id);
            return new SuccessDataResult<Car>(result,"saef");
        }

        public IDataResult<List<Car>> GetAll()
        {
            if(DateTime.Now.Hour == 23)
            {
                return new ErrorDataResult<List<Car>>();
            }
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(),"Arabalar listelendi");
        }

        public IDataResult<List<CarDetailDto>> GetCarDetail()
        {
            return new DataResult<List<CarDetailDto>>(_carDal.GetCarDetail(),true);
        }

        public List<Car> GetCarsByBrandId(int id)
        {
            return _carDal.GetAll(c => c.BrandId == id);
        }

        public List<Car> GetCarsByColorId(int id)
        {
            return _carDal.GetAll(c=>c.ColorId == id);
        }

        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult();
        }
    }
}

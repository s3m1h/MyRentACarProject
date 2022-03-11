using Business.Abstract;
using Business.Constants;
using Core.Utilities.Images;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;
        IFile _file;
        public CarImageManager(ICarImageDal carImageDal, IFile file)
        {
            _carImageDal = carImageDal;
            _file = file;
        }
        public IResult Add(IFormFile file,CarImage carImage)
        {

            //IResult result = BusinessRules.Run(CheckIfCarImageLimit(carImage.CarId));
            carImage.ImagePath = _file.Upload(file, ImagePath.Path);
            carImage.Date = DateTime.Now;
            _carImageDal.Add(carImage); 
            return new SuccessResult("Resim başarıyla yüklendi");
        }

        public IResult Delete(CarImage carImage)
        {
            _file.Delete();
            _carImageDal.Delete(carImage);
            return new SuccessResult();
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IResult Update(IFormFile file, CarImage carImage)
        {
            throw new NotImplementedException();
        }
    }
}

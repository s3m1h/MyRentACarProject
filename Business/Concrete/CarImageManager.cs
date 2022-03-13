using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
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

        private string path = ImagePath.Path;
        public CarImageManager(ICarImageDal carImageDal, IFile file)
        {
            _carImageDal = carImageDal;
            _file = file;
        }
        public IResult Add(IFormFile file,CarImage carImage)
        {
            IResult result = BusinessRules.Run(CheckIfCarImageLimit(carImage.CarId));
            if(result != null)
            {
                return result;
            }
            
            //IResult result = BusinessRules.Run(CheckIfCarImageLimit(carImage.CarId));
            carImage.ImagePath = _file.Upload(file, path);
            carImage.Date = DateTime.Now;
            _carImageDal.Add(carImage); 
            return new SuccessResult("Resim başarıyla yüklendi");
        }

        private IResult CheckIfCarImageLimit(int carId)
        {
            var result = _carImageDal.GetAll(c=>c.Id == carId).Count;
            if(result <= 5)
            {
                return new SuccessResult();
            }
            return new ErrorResult();
        }

        public IResult Delete(CarImage carImage)
        {
            _file.Delete(path + carImage.ImagePath);
            _carImageDal.Delete(carImage);
            return new SuccessResult();
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            var result = _carImageDal.GetAll();
            return new SuccessDataResult<List<CarImage>>(result);
        }

        public IResult Update(IFormFile file, CarImage carImage)
        {
            carImage.ImagePath = _file.Update(file, path + carImage.ImagePath, path);
            _carImageDal.Update(carImage);
            return new SuccessResult();
        }

        public IDataResult<List<CarImage>> GetAllByCarImageId(int carId)
        {
            var result = _carImageDal.GetAll(c => c.CarId == carId);
            return new SuccessDataResult<List<CarImage>>(result);
        }

        public IDataResult<List<CarImage>> GetDefaultCarImage(int carId)
        {
            List<CarImage> carImages = new List<CarImage>();
            carImages.Add(new CarImage { CarId=carId,Date=DateTime.Now,ImagePath="default.jpg"});
            return new SuccessDataResult<List<CarImage>>(carImages);
        }
    }
}

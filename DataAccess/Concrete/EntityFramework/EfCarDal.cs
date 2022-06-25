using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, RentACarContext>, ICarDal
    {
        public List<CarAllDetailDto> GetAllCarDetail(Expression<Func<CarAllDetailDto, bool>> filter = null)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from c in context.Cars
                             join cl in context.Colors on c.ColorId equals cl.ColorId
                             join b in context.Brands on c.BrandId equals b.BrandId
                             select new CarAllDetailDto
                             {
                                 CarId = c.Id,
                                 BrandId = b.BrandId,
                                 ColorId = cl.ColorId,
                                 BrandName = b.BrandName,
                                 CarName = c.Description,
                                 ColorName = cl.ColorName,
                                 DailyPrice = c.DailyPrice
                             };
                return filter is null ? result.ToList() : result.Where(filter).ToList();
            }
        }

        public List<CarDetailDto> GetCarDetail()
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands on c.BrandId equals b.BrandId
                             join cl in context.Colors on c.ColorId equals cl.ColorId
                             select new CarDetailDto
                             {
                                 BrandName = b.BrandName,
                                 CarId = c.Id,
                                 ColorName = cl.ColorName,
                                 Description = c.Description
                             };
                return result.ToList();
            }
        }
    }
}

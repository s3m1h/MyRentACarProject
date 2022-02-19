using DataAccess.Abstract;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : ICarDal
    {
        public void Add(Car entity)
        {
            using (RentACarContext context = new RentACarContext())
            {
                // eklenecek varlık
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(Car entity)
        {
            using (RentACarContext context = new RentACarContext())
            {
                // silinecek varlık
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            using (RentACarContext context = new RentACarContext())
            {
                // filtre verilmemişse tüm carları listeye çevirip getir
                // filtre verilmişse filtreleyip getir
                return filter == null ? context.Set<Car>().ToList() : context.Set<Car>().Where(filter).ToList();
            }
        }

        public Car GetById(int id)
        {
            using (RentACarContext context = new RentACarContext())
            {
                return context.Set<Car>().SingleOrDefault(c => c.Id == id);
            }
        }

        public void Update(Car entity)
        {
            using (RentACarContext context = new RentACarContext())
            {
                // update edilecek varlık
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}

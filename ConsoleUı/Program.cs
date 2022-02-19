// See https://aka.ms/new-console-template for more information
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities;

Console.WriteLine("Hello, World!");


CarManager carManager = new CarManager(new EfCarDal());
foreach (var car in carManager.GetAll())
{
    Console.WriteLine(car.Description);
}


carManager.Add(new Car
{
    BrandId = 2,
    ColorId = 2,
    ModelYear = 2000,
    DailyPrice = 10000,
    Description = "newFerrari"
});


// See https://aka.ms/new-console-template for more information
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities;
using Entities.Concrete;

//Console.WriteLine("Hello, World!");


//CarManager carManager = new CarManager(new EfCarDal());
//foreach (var car in carManager.GetAll())
//{
//    Console.WriteLine(car.Description);
//}


//carManager.Add(new Car
//{
//    BrandId = 2,
//    ColorId = 2,
//    ModelYear = 2000,
//    DailyPrice = 10000,
//    Description = "newFerrari"
//});

CarManager carManager1 = new CarManager(new EfCarDal());
foreach (var car in carManager1.GetCarDetail())
{
    Console.WriteLine("{0} / {1} / {2} / {3}",car.CarName,car.BrandName,car.ColorName,car.DailyPrice);
}





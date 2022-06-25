//using Business.Concrete;
//using DataAccess.Concrete.EntityFramework;
//using Entities;
//using Entities.Concrete;


//RentalManager rentalManager = new RentalManager(new EfRentalDal());

//rentalManager.Add(new Rental {
//    CustomerId=2,
//    CarId=2,
//    RentDate=DateTime.Today,
//    ReturnDate=DateTime.Today.Date
//});


//// GetAllTest();

//// GetCarDetailTest();

//// GetCarByColorIdTest();

//static void GetCarByColorIdTest()
//{
//    CarManager carManager = new CarManager(new EfCarDal());
//    foreach (var item in carManager.GetCarsByColorId(1))
//    {
//        Console.WriteLine(item.Description);
//    }
//}

//static void GetCarDetailTest()
//{
//    CarManager carManager1 = new CarManager(new EfCarDal());
//    var result = carManager1.GetCarDetail();
//    if (result.Success)
//    {
//        foreach (var car in result.Data)
//        {
//            Console.WriteLine("{0} / {1} / {2} / {3}", car.CarName, car.BrandName, car.ColorName, car.DailyPrice);
//        }
//    }
//}

//static void GetAllTest()
//{
//    CarManager carManager = new CarManager(new EfCarDal());
//    foreach (var car in carManager.GetAll().Data)
//    {
//        Console.WriteLine(car.Description);
//    }


//    carManager.Add(new Car
//    {
//        BrandId = 2,
//        ColorId = 2,
//        ModelYear = 2000,
//        DailyPrice = 10000,
//        Description = "newFerrari"
//    });
//}
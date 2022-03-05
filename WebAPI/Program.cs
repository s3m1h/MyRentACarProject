using Autofac;
using Autofac.Extensions.DependencyInjection;
using Business.Abstract;
using Business.Concrete;
using Business.DependencyResolvers.Autofac;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Autofac
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(builder =>
{
    builder.RegisterModule(new AutofacBusinessModule());
});


//// Car
//builder.Services.AddSingleton<ICarService,CarManager>();
//builder.Services.AddSingleton<ICarDal,EfCarDal>();

//// Rental
//builder.Services.AddSingleton<IRentalService, RentalManager>();
//builder.Services.AddSingleton<IRentalDal,EfRentalDal>();

//// Brand
//builder.Services.AddSingleton<IBrandService, BrandManager>();
//builder.Services.AddSingleton<IBrandDal, EfBrandDal>();

//// Color
//builder.Services.AddSingleton<IColorService, ColorManager>();
//builder.Services.AddSingleton<IColorDal, EfColorDal>();

//// Customer
//builder.Services.AddSingleton<ICustomerService, CustomerManager>();
//builder.Services.AddSingleton<ICustomerDal, EfCustomerDal>();

//// User
//builder.Services.AddSingleton<IUserService, UserManager>();
//builder.Services.AddSingleton<IUserDal, EfUserDal>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

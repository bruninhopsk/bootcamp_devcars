using System.Linq;
using Dapper;
using DevCars.Domain.Entities;
using DevCars.Domain.Enums;
using DevCars.Domain.InputModels;
using DevCars.Domain.ViewModels;
using DevCars.Infrastructure.EntityFramework.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace DevCars.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarsController : ControllerBase
    {
        public DevCarsDbContext Context { get; }
        public string ConnectionString { get; }

        public CarsController(DevCarsDbContext context, IConfiguration configuration)
        {
            Context = context;
            ConnectionString = configuration.GetConnectionString("DevCars");
        }

        //GET api/cards
        [HttpGet]
        public ActionResult Get()
        {
            // Query with Dapper
            // using (var sqlConnection = new SqlConnection(ConnectionString))
            // {
            //     var query = "SELECT Id, Brand, Model, Price FROM Cars WHERE Status = 0";
            //     var carsViewModel = sqlConnection.Query<CarItemViewModel>(query);
            // }

            var cars = Context.Cars.ToList();

            if (cars.Count > 0)
            {
                var carsViewModel = cars.Where(x => x.Status == CarStatusEnum.Available)
                                        .Select(x => new CarItemViewModel(x.Id, x.Brand, x.Model, x.Price, x.Status))
                                        .ToList();
                return Ok(carsViewModel);
            }

            return NotFound();
        }

        //GET api/cars/id
        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            var car = Context.Cars.SingleOrDefault(x => x.Id.Equals(id));

            if (car == null)
            {
                return NotFound();
            }

            var carDetailsViewModel = new CarDetailsViewModel(
                car.Id,
                car.Brand,
                car.Model,
                car.VinCode,
                car.Year,
                car.Price,
                car.Color,
                car.ProductionDate
            );
            return Ok(carDetailsViewModel);
        }

        //POST api/cars
        [HttpPost]
        public ActionResult Post([FromBody] AddCarInputModel carInputModel)
        {
            var newCar = new Car(
                carInputModel.VinCode,
                carInputModel.Brand,
                carInputModel.Model,
                carInputModel.Year,
                carInputModel.Price,
                carInputModel.Color,
                carInputModel.ProductionDate);

            Context.Cars.Add(newCar);
            Context.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = newCar.Id }, newCar);
        }

        //PUT api/cars/id
        [HttpPut("{id}")]
        public ActionResult Put([FromBody] UpdateCarInputModel carInputModel, int id)
        {
            var car = Context.Cars.SingleOrDefault(x => x.Id.Equals(id));

            if (car == null)
            {
                return NotFound();
            }

            car.Update(carInputModel.Color, carInputModel.Price);
            Context.SaveChanges();

            /* Command with Dapper
             using (var sqlConnection = new SqlConnection(ConnectionString))
             {
                 var command = "UPDATE Cars SET Color = @Color, Price = @price WHERE Id = @id";
                 sqlConnection.Execute(command, new { color = car.Color, price = car.Price, id = car.Id });
             } */

            return NoContent();
        }

        //DELETE api/cars/id
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var car = Context.Cars.SingleOrDefault(x => x.Id.Equals(id));

            if (car == null)
            {
                return NotFound();
            }

            car.SetAsSuspended();
            Context.SaveChanges();

            return NoContent();
        }
    }
}
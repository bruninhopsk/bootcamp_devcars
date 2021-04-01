using System.Linq;
using DevCars.Domain.Entities;
using DevCars.Domain.InputModels;
using DevCars.Domain.ViewModels;
using DevCars.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace DevCars.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarsController : ControllerBase
    {
        public DevCarsDbContext Context { get; }

        public CarsController(DevCarsDbContext context)
        {
            Context = context;
        }

        //GET api/cards
        [HttpGet]
        public ActionResult Get()
        {
            var cars = Context.Cars;

            var carsViewModel = cars.Select(x => new CarItemViewModel(x.Id, x.Brand, x.Model, x.Price)).ToList();

            return Ok(carsViewModel);
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
                4,
                carInputModel.VinCode,
                carInputModel.Brand,
                carInputModel.Model,
                carInputModel.Year,
                carInputModel.Price,
                carInputModel.Color,
                carInputModel.ProductionDate);

            Context.Cars.Add(newCar);

            return CreatedAtAction(nameof(GetById), new { id = newCar.Id });
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

            return NoContent();
        }
    }
}
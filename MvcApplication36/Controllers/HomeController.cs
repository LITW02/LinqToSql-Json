using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LinqToSqlJson.Data;
using MvcApplication36.Models;
using Newtonsoft.Json;

namespace MvcApplication36.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetPerson(int id)
        {
            var repo = new PersonRepository(Properties.Settings.Default.ConStr);
            Person person = repo.GetById(id);

            var result = new
            {
                FirstName = person.FirstName,
                LastName = person.LastName,
                Age = person.Age,
                Id = person.Id,
                Cars = person.Cars.Select(c => new
                {
                    Make = c.Make,
                    Model = c.Model,
                    Year = c.Year,
                    Id = c.Id
                })
            };

            //JsonPerson jsonPerson = new JsonPerson();
            //jsonPerson.Id = person.Id;
            //jsonPerson.FirstName = person.FirstName;
            //jsonPerson.LastName = person.LastName;
            //jsonPerson.Age = person.Age;

            //jsonPerson.Cars = person.Cars.Select(c => new JsonCar
            //{
            //    Make = c.Make,
            //    Model = c.Model,
            //    Year = c.Year,
            //    Id = c.Id
            //});

            //List<JsonCar> cars = new List<JsonCar>();
            //foreach (Car car in person.Cars)
            //{
            //    JsonCar jsonCar = new JsonCar();
            //    jsonCar.Id = car.Id;
            //    jsonCar.Make = car.Make;
            //    jsonCar.Model = car.Model;
            //    jsonCar.Year = car.Year;
            //    cars.Add(jsonCar);
            //}

            //jsonPerson.Cars = cars;

            return Json(result, JsonRequestBehavior.AllowGet);
        }

    }
}

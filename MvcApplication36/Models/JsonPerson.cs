using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication36.Models
{
    public class JsonPerson
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public IEnumerable<JsonCar> Cars { get; set; } 
    }

    public class JsonCar
    {
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
    }
}
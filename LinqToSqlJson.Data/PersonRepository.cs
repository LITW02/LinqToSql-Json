using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqToSqlJson.Data
{
    public class PersonRepository
    {
        private string _connectionString;

        public PersonRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public Person GetById(int id)
        {
            using (var context = new PeopleCarsDataContext(_connectionString))
            {
                var loadOptions = new DataLoadOptions();
                loadOptions.LoadWith<Person>(p => p.Cars);
                context.LoadOptions = loadOptions;
                return context.Persons.First(p => p.Id == id);
            }
        }
    }
}

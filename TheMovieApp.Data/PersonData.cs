using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheMovieApp.Core;

namespace TheMovieApp.Data
{
    public interface IPersonData
    {
        IEnumerable<Person> GetAll();
        Person GetById(int id);
    }
    public class PersonData : IPersonData
    {
        List<Person> people;
        public PersonData()
        {
            people = new List<Person>()
            {
            new Person() { Id = 1, FirstName = "Martin", LastName = "Lawrence", Age = 55, Role = Role.Actor },
            new Person() { Id = 2, FirstName = "Will", LastName = "Smith", Age = 51, Role = Role.Actor },
            new Person() { Id = 3, FirstName = "Jim", LastName = "Carrey", Age = 58, Role = Role.Actor },
            new Person() { Id = 4, FirstName = "James", LastName = "Marsden", Age = 46, Role = Role.Actor },
            };
        }




        public IEnumerable<Person> GetAll()
        {
            return people.OrderBy(p => p.FirstName);
        }

        public Person GetById(int id)
        {
            return people?.FirstOrDefault(p => p.Id == id);
        }

    }
}

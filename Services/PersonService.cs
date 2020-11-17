using JeComplete.Data;
using System.Collections.Generic;
using System.Linq;

namespace JeComplete.Services
{
    public class PersonService
    {
        private static PersonService _instance;

        private DBContext Context { get; set; }

        private PersonService() { }

        public static PersonService GetInstance()
        {
            if (_instance == null)
            {
                _instance = new PersonService();
                _instance.Context = DBContext.GetInstance();
            }

            return _instance;
        }

        public Person GetPerson(ulong id)
        {
            return Context.PeopleList.Find(p => p.Id == id);
        }

        public List<Person> GetPeopleList()
        {
            return (from person in Context.PeopleList
                    orderby person.LastName, person.FirstName
                    select person).ToList();
        }
    }
}
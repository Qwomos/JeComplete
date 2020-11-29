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

        public List<Person> SearchPeopleByNames(string query)
        {
            string[] names;

            if (query == null)
                return null;

            if (query.Contains(' '))
                names = query.Split(' ');
            else 
            {
                names = new string[1];
                names[0] = query;
            }

            return (from person in Context.PeopleList
                    where names.Any(n => person.FirstName.ToLower().Contains(n.ToLower())) ||
                        names.Any(n => person.LastName.ToLower().Contains(n.ToLower()))
                    select person).Take(10).ToList();
        }
    }
}
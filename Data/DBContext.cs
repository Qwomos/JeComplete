using Bogus;
using System;
using System.Collections.Generic;
using Bogus.DataSets;

namespace JeComplete.Data 
{
    public class DBContext
    {
        private static DBContext _instance;
        public List<Person> PeopleList { get; set; }

        private DBContext() {}

        public static DBContext GetInstance()
        {
            if (_instance == null) 
            {
                _instance = new DBContext();
                Init();
            } 

            return _instance;
        }

        private static void Init()
        {
            Faker<Person> fakerPerson;
            string[] roles = { "Administrateur", "Acheteur", "Vendeur", "Conseiller", "Secrétaire", "Comptable" };

            Randomizer.Seed = new Random(293758);
            fakerPerson = new Faker<Person>()
            .RuleFor(p => p.Id, f => f.Random.ULong())
            .RuleFor(p => p.Gender, f => f.PickRandom<Name.Gender>())
            .RuleFor(p => p.FirstName, (f, p) => f.Name.FirstName(p.Gender))
            .RuleFor(p => p.LastName, (f) => f.Name.LastName())
            .RuleFor(p => p.Role, f => f.PickRandom<string>(roles))
            .RuleFor(p => p.Birthdate, f => f.Date.Between(DateTime.Today.AddYears(-75), DateTime.Today.AddYears(-18)));
            _instance.PeopleList = fakerPerson.Generate(1000);
        }
    }
}
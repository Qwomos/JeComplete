using Bogus.DataSets;
using System;

namespace JeComplete.Data
{
    public class Person
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Name.Gender Gender { get; set; }
        public string Role { get; set; }
        public DateTime Birthdate { get; set; }
    }
}

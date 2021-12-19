using frout_implementation.Domain.Model.ValueObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace frout_implementation.Domain.Model
{
    public class Customer
    {
        //Ef CORE needs empty constructor
        public Customer()
        {
        }

        public Customer(string firstname, string lastname, Location location)
        {
            FirstName = firstname;
            LastName = lastname;
            Location = location;
        }

        [Key]
        public int Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public Location Location { get; private set; }
    }
}

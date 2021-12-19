using frout_implementation.Domain.Model.ValueObjects;
using System.ComponentModel.DataAnnotations;

namespace frout_implementation.Domain.Model
{
    public class Farmer
    {
        //Ef CORE needs empty constructor
        public Farmer()
        {
        }

        public Farmer(string firstname, string lastname, Location location)
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

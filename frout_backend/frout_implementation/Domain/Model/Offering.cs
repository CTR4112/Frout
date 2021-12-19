using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace frout_implementation.Domain.Model
{
    public class Offering
    {
        //Ef CORE needs empty constructor
        public Offering()
        {
        }

        public Offering(string name, string description, string additional_Information, decimal price, Farmer farmer)
        {
            Name = name;
            Description = description;
            Additional_Information = additional_Information;
            Price = price;
            Farmer = farmer;
        }

        [Key]
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string Additional_Information { get; private set; }
        public decimal Price { get; private set; }

        [JsonIgnore]
        public int FarmerId { get; set; }

        [JsonIgnore]
        [ForeignKey("FarmerId")] //referenziert auf die UserId oben, die zwei sharen sich sozusagen den Foreign Key
        public virtual Farmer Farmer { get; set; }

        //Relationships
        public ICollection<SubscriptionDetail> SubscriptionDetails { get; private set; }
    }
}

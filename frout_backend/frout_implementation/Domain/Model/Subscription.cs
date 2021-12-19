using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace frout_implementation.Domain.Model
{
    public class Subscription
    {
        //Ef CORE needs empty constructor
        public Subscription()
        {
        }

        public Subscription(DateTime orderDate, int nextDeliveryCalendarWeek, Customer customer, Farmer farmer)
        {
            OrderDate = orderDate;
            NextDeliveryCalendarWeek = nextDeliveryCalendarWeek;
            Customer = customer;
            Farmer = farmer;
        }

        [Key]
        public int Id { get; private set; }
        public DateTime OrderDate { get; private set; }
        public int NextDeliveryCalendarWeek { get; private set; }

        [JsonIgnore]
        public int FarmerId { get; set; }
        [JsonIgnore]
        [ForeignKey("FarmerId")] //referenziert auf die UserId oben, die zwei sharen sich sozusagen den Foreign Key
        public virtual Farmer Farmer { get; set; }
        [JsonIgnore]
        public int CustomerId { get; set; }
        [JsonIgnore]
        [ForeignKey("CustomerId")] //referenziert auf die UserId oben, die zwei sharen sich sozusagen den Foreign Key
        public virtual Customer Customer { get; set; }

        //Relationships
        public ICollection<SubscriptionDetail> SubscriptionDetails { get; private set; }

        public void ConfirmDelivery()
        {
            CultureInfo myCI = new CultureInfo("de-AT");
            Calendar myCal = myCI.Calendar;
            int currentCalendarWeek = myCal.GetWeekOfYear(DateTime.Now, CalendarWeekRule.FirstDay, DayOfWeek.Monday);
            NextDeliveryCalendarWeek = currentCalendarWeek + 1; //next delivery is one week later...

        }
    }
}

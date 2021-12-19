using frout_implementation.Domain.Model;
using frout_implementation.Domain.Model.ValueObjects;
using frout_implementation.Infrastructure.DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace frout_implementation.Infrastructure
{
    public class SeedDB
    {
        public static async Task InitializeAsync(FroutDbContext context)
        {
            if (context.Database.GetPendingMigrations().Count() != 0)
            {
                Console.WriteLine("DBSeeder: Applying pending migrations...");
                context.Database.Migrate();
            }

            if (!context.Farmers.Any() && !context.Customers.Any() && !context.Offerings.Any() && !context.Subscriptions.Any())
            {
                await PopulateFarmers(context);
                await PopulateCustomers(context);
                await PopulateOffering(context);
                await PopulateSubscription(context);
                await PopulateSubscriptionDetail(context);

                Console.WriteLine("WARNING: Non-productive code \"DBSeeder\" is in use"); 
            }
            return;
        }

        private static async Task PopulateFarmers(FroutDbContext context)
        {
            Farmer farmer1 = new Farmer("John", "Doe", new Location(47.406940, 9.744520)); 
            Farmer farmer2 = new Farmer("Jane", "Doe", new Location(47.30742676230293, 9.619625497998522)); 

            context.Farmers.Add(farmer1);
            context.Farmers.Add(farmer2);

            await context.SaveChangesAsync();
        }

        private static async Task PopulateCustomers(FroutDbContext context)
        {
            Customer customer1 = new Customer("Mark", "Smith", new Location(47.412925971844885, 9.710977716022189)); 
            Customer customer2 = new Customer("Bob", "Johnson", new Location(47.39846144976148, 9.676731274101543)); 
            Customer customer3 = new Customer("Tom", "Williams", new Location(47.3550440504117, 9.63613335838242)); 
            Customer customer4 = new Customer("David", "Jones", new Location(47.3735894549603, 9.67776124268394)); 
            Customer customer5 = new Customer("Donald", "Brown", new Location(47.3140509624823, 9.609904805365964)); 
            Customer customer6 = new Customer("Joe", "Miller", new Location(47.274605760349125, 9.650168724808688)); 
            Customer customer7 = new Customer("Michael", "Wilson", new Location(47.98597068410954, 13.43930008250548)); 
            Customer customer8 = new Customer("Herbert", "Moore", new Location(47.40623411191827, 9.739937644449451)); 

            context.Customers.Add(customer1);
            context.Customers.Add(customer2);
            context.Customers.Add(customer3);
            context.Customers.Add(customer4);
            context.Customers.Add(customer5);
            context.Customers.Add(customer6);
            context.Customers.Add(customer7);
            context.Customers.Add(customer8);

            await context.SaveChangesAsync();
        }

        private static async Task PopulateOffering(FroutDbContext context)
        {
            Farmer farmer1 = context.Farmers.Where(farmer => farmer.Id == 1).First();
            Farmer farmer2 = context.Farmers.Where(farmer => farmer.Id == 2).First();

            Offering offering1 = new Offering("Large Vegetables Box", "Large Vegetables Box with seasonal products", "Additional Information 1", (decimal)19.99, farmer1);
            Offering offering2 = new Offering("Small Vegetables Box", "Small Vegetables Box with seasonal products", "Additional Information 2", (decimal)15.99, farmer1);
            Offering offering3 = new Offering("Potatoes 10 pounds", "10 pounds of the best potatoes", "Additional Information 3", (decimal)4.9, farmer1);
            Offering offering4 = new Offering("Tomatoes 10 pounds", "10 pounds of the best tomatoes", "Additional Information 4", (decimal)4.9, farmer2);
            Offering offering5 = new Offering("Milk 1 gallon", "1 gallon of the best milk", "Additional Information 5", (decimal)2.5, farmer2);

            context.Offerings.Add(offering1);
            context.Offerings.Add(offering2);
            context.Offerings.Add(offering3);
            context.Offerings.Add(offering4);
            context.Offerings.Add(offering5);

            await context.SaveChangesAsync();
        }

        private static async Task PopulateSubscription(FroutDbContext context)
        {
            Farmer farmer1 = context.Farmers.Where(farmer => farmer.Id == 1).First();
            Farmer farmer2 = context.Farmers.Where(farmer => farmer.Id == 2).First();

            Customer customer1 = context.Customers.Where(customer => customer.Id == 1).First();
            Customer customer2 = context.Customers.Where(customer => customer.Id == 2).First();
            Customer customer3 = context.Customers.Where(customer => customer.Id == 3).First();
            Customer customer4 = context.Customers.Where(customer => customer.Id == 4).First();
            Customer customer5 = context.Customers.Where(customer => customer.Id == 5).First();

            Subscription subscription1 = new Subscription(new DateTime(2021, 12, 18), 51, customer1, farmer1);
            Subscription subscription2 = new Subscription(new DateTime(2021, 12, 18), 51, customer2, farmer2);
            Subscription subscription3 = new Subscription(new DateTime(2021, 12, 18), 51, customer2, farmer1);
            Subscription subscription4 = new Subscription(new DateTime(2021, 12, 18), 51, customer3, farmer1);
            Subscription subscription5 = new Subscription(new DateTime(2021, 12, 18), 52, customer4, farmer1);
            Subscription subscription6 = new Subscription(new DateTime(2021, 12, 18), 52, customer5, farmer1);

            context.Subscriptions.Add(subscription1);
            context.Subscriptions.Add(subscription2);
            context.Subscriptions.Add(subscription3);
            context.Subscriptions.Add(subscription4);
            context.Subscriptions.Add(subscription5);
            context.Subscriptions.Add(subscription6);

            await context.SaveChangesAsync();
        }

        private static async Task PopulateSubscriptionDetail(FroutDbContext context)
        {
            Offering offering1 = context.Offerings.Where(o => o.Id == 1).First();
            Subscription subscription1 = context.Subscriptions.Where(s => s.Id == 1).First();

            Offering offering2 = context.Offerings.Where(o => o.Id == 2).First();
            Subscription subscription2 = context.Subscriptions.Where(s => s.Id == 2).First();

            Offering offering3 = context.Offerings.Where(o => o.Id == 3).First();
            Subscription subscription3 = context.Subscriptions.Where(s => s.Id == 3).First();

            SubscriptionDetail subscriptionDetail1 = new SubscriptionDetail(subscription1, offering1);
            SubscriptionDetail subscriptionDetail2 = new SubscriptionDetail(subscription2, offering2);
            SubscriptionDetail subscriptionDetail3 = new SubscriptionDetail(subscription3, offering3);

            await context .SaveChangesAsync();
        }
    }
}

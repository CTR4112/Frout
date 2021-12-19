using frout_implementation.Domain.Model;
using frout_implementation.Domain.Repositories;
using frout_implementation.Infrastructure.DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace frout_implementation.Infrastructure
{
    public class EFCoreSubscriptionRepository : ISubscriptionRepository
    {
        public FroutDbContext _context { get; set; }
        public EFCoreSubscriptionRepository(FroutDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<List<Subscription>> GetSubscriptionsAsync(Farmer farmer)
        {
            CultureInfo myCI = new CultureInfo("de-AT");
            Calendar myCal = myCI.Calendar;
            int currentCalendarWeek = myCal.GetWeekOfYear(DateTime.Now, CalendarWeekRule.FirstDay, DayOfWeek.Monday);

            return await _context.Subscriptions.Include(s => s.Customer).Include(s => s.SubscriptionDetails).ThenInclude(sd => sd.Offering)
                .Where(s => s.Farmer == farmer && s.NextDeliveryCalendarWeek <= currentCalendarWeek) //Subscription is relevant
                .ToListAsync();
        }

        public async Task<Subscription> GetSubscriptionByIdAsync(int subscriptionid)
        {
            return await _context.Subscriptions.FirstOrDefaultAsync(s => s.Id == subscriptionid);
        }
    }
}

using frout_implementation.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace frout_implementation.Domain.Repositories
{
    public interface ISubscriptionRepository
    {
        Task<List<Subscription>> GetSubscriptionsAsync(Farmer farmer);
        Task<Subscription> GetSubscriptionByIdAsync(int subscriptionid);
    }
}

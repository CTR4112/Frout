using frout_implementation.Application.Implementation;
using frout_implementation.Domain.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace frout_implementation.Application
{
    public interface IDeliveryService
    {
        //Farmer
        Task<Farmer> GetFarmerByIdAsync(int farmerid);

        //Subscription
        Task<List<Subscription>> GetSubscriptionsAsync(int farmerid);
        Task<List<Subscription>> OptimizeSubscriptionsAsync(int farmerid);
        Task ConfirmDeliveryAsync(int subscriptionid);
    }
}

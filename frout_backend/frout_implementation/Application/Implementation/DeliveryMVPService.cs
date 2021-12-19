using frout_implementation.Domain.Model;
using frout_implementation.Domain.Model.ValueObjects;
using frout_implementation.Domain.Repositories;
using frout_implementation.View.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace frout_implementation.Application.Implementation
{
    public class DeliveryMVPService : IDeliveryService
    {
        private IFarmerRepository _fr;
        private ISubscriptionRepository _sr;
        public DeliveryMVPService(IFarmerRepository farmerRepository, ISubscriptionRepository subscriptionRepository)
        {
            _fr = farmerRepository;
            _sr = subscriptionRepository;
        }

        public async Task ConfirmDeliveryAsync(int subscriptionid)
        {
            Subscription subscription = await _sr.GetSubscriptionByIdAsync(subscriptionid);
            if (subscription == null)
                throw new ArgumentNullException("subscription is unknown!");
            subscription.ConfirmDelivery();
        }

        public async Task<Farmer> GetFarmerByIdAsync(int farmerid)
        {
            return await _fr.GetFarmerByIdAsync(farmerid);
        }

        public async Task<List<Subscription>> GetSubscriptionsAsync(int farmerid)
        {
            Farmer farmer = await GetFarmerByIdAsync(farmerid);
            if (farmer == null)
                throw new ArgumentNullException("farmer is unkown!");

            return await _sr.GetSubscriptionsAsync(farmer);
        }

        public async Task<List<Subscription>> OptimizeSubscriptionsAsync(int farmerid)
        {
            List<Subscription> destinations = await GetSubscriptionsAsync(farmerid);
            Farmer farmer = await GetFarmerByIdAsync(farmerid);
            double startPointLatitude = farmer.Location.Latitude;
            double startPointLongitude = farmer.Location.Longitude;
            List<LocationAndDifferenceDTO> tempList = new List<LocationAndDifferenceDTO>();

            foreach (Subscription subscription in destinations)
            {
                tempList.Add(new LocationAndDifferenceDTO(
                    subscription,
                    subscription.Customer.Location.Latitude, 
                    subscription.Customer.Location.Longitude,
                    LocationAndDifferenceDTO.Distance(startPointLatitude, startPointLongitude, subscription.Customer.Location.Latitude, subscription.Customer.Location.Longitude, 'K')));
            }

            List<Subscription> result = new List<Subscription>();
            foreach (var item in tempList.OrderBy(list => list.Difference).ToList())
                result.Add(item.Subscription);

            return result;
        }
    }
}

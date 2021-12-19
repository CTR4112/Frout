using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace frout_implementation.Domain.Model
{
    public class SubscriptionDetail
    {
        //Ef CORE needs empty constructor
        private SubscriptionDetail()
        {
        }

        public SubscriptionDetail(Subscription subscription, Offering offering)
        {
            Subscription = subscription;
            Offering= offering;
        }

        [Key]
        public int Id { get; private set; }
        public Subscription Subscription { get; }
        public Offering Offering { get; }
    }
}


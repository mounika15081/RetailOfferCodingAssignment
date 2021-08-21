using System;
using System.Collections.Generic;
using System.Text;

namespace RetailOfferCodingAssignment
{
    public class CustomerReward
    {
        public int CustomerId { get; set; }

        public string CustomerName { get; set; }

        public int CustomerTransactionId { get; set; }

        public int Price { get; set; }

        public DateTime TransactionDate { get; set; }

        public int RewardPoints { get; set; }
    }
}

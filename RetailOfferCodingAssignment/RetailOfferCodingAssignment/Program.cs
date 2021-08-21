using System;
using System.Collections.Generic;
using System.Linq;

namespace RetailOfferCodingAssignment
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the customer reward system");
            List<CustomerReward> calculatedRewards = new List<CustomerReward>();
            var customerData = SeedCustomerData();
            foreach (var reward in customerData)
            {
                int calcRewards = CalculateRewards(reward.Price);
                reward.RewardPoints = calcRewards;
                calculatedRewards.Add(reward);
                Console.WriteLine($"Customer Name : {reward.CustomerName} and Reward Points : {reward.RewardPoints}");
            }

            var resultValues = RewardPerMonth(calculatedRewards);

            Console.ReadLine();
        }

        public static int CalculateRewards(int price)
        {
            if (price >= 50 && price < 100)
            {
                return price - 50;
            }
            else if (price > 100)
            {
                return (2 * (price - 100) + 50);
            }
            return 0;
        }

        public static List<CustomerReward> RewardPerMonth(List<CustomerReward> customerRewards)
        {
            List<CustomerReward> customers = new List<CustomerReward>();
            for (int i = 0; i < 3; i++)
            {
                var filteredList = customerRewards.Where(trans => trans.TransactionDate.Month == DateTime.Now.Month - i);
                customers = filteredList
                    .GroupBy(l => l.CustomerId)
                    .Select(cl => new CustomerReward
                    {
                        CustomerId = cl.First().CustomerId,
                        CustomerName = cl.First().CustomerName,
                        RewardPoints = cl.Sum(c => c.RewardPoints),
                        Price = cl.Sum(c => c.Price),
                    }).ToList();
                Console.WriteLine("===============================================");
                Console.WriteLine($"Please check below calculate the reward points earned for each customer per month {i}");
                foreach (var monthresult in customers)
                {
                    Console.WriteLine($"Customer Name : {monthresult.CustomerName} and Total Price : {monthresult.Price} and Total Reward Points : {monthresult.RewardPoints}");
                }
            }
            return customers;
        }

        public static List<CustomerReward> SeedCustomerData()
        {
            var result = new List<CustomerReward> {
            new CustomerReward{CustomerId=1, CustomerName="Abc", CustomerTransactionId=1001, Price=65, TransactionDate = DateTime.Today.AddDays(-1) },
            new CustomerReward{CustomerId=1, CustomerName="Abc", CustomerTransactionId=1002, Price=685, TransactionDate = DateTime.Today.AddDays(-5) },
            new CustomerReward{CustomerId=1, CustomerName="Abc", CustomerTransactionId=1003, Price=458, TransactionDate = DateTime.Today.AddDays(-15) },
            new CustomerReward{CustomerId=1, CustomerName="Abc", CustomerTransactionId=1004, Price=1200, TransactionDate = DateTime.Today.AddDays(-35) },
            new CustomerReward{CustomerId=1, CustomerName="Abc", CustomerTransactionId=1005, Price=410, TransactionDate = DateTime.Today.AddDays(-42)  },
            new CustomerReward{CustomerId=1, CustomerName="Abc", CustomerTransactionId=1006, Price=120, TransactionDate = DateTime.Today.AddDays(-3) },
            new CustomerReward{CustomerId=1, CustomerName="Abc", CustomerTransactionId=1006, Price=40, TransactionDate = DateTime.Today.AddDays(-68) },
            new CustomerReward{CustomerId=1, CustomerName="Abc", CustomerTransactionId=1006, Price=180, TransactionDate = DateTime.Today.AddDays(-72) },

            new CustomerReward{CustomerId=2, CustomerName="Xyz", CustomerTransactionId=1011, Price=75, TransactionDate = DateTime.Today.AddDays(-1) },
            new CustomerReward{CustomerId=2, CustomerName="Xyz", CustomerTransactionId=1012, Price=325, TransactionDate = DateTime.Today.AddDays(-5) },
            new CustomerReward{CustomerId=2, CustomerName="Xyz", CustomerTransactionId=1013, Price=158, TransactionDate = DateTime.Today.AddDays(-45) },
            new CustomerReward{CustomerId=2, CustomerName="Xyz", CustomerTransactionId=1014, Price=500, TransactionDate = DateTime.Today.AddDays(-45)  },
            new CustomerReward{CustomerId=2, CustomerName="Xyz", CustomerTransactionId=1015, Price=110, TransactionDate = DateTime.Today.AddDays(-15)  },
            new CustomerReward{CustomerId=2, CustomerName="Xyz", CustomerTransactionId=1016, Price=320, TransactionDate = DateTime.Today.AddDays(-12) },
            new CustomerReward{CustomerId=2, CustomerName="Xyz", CustomerTransactionId=1016, Price=120, TransactionDate = DateTime.Today.AddDays(-65) },
            new CustomerReward{CustomerId=2, CustomerName="Xyz", CustomerTransactionId=1016, Price=250, TransactionDate = DateTime.Today.AddDays(-82) },

            new CustomerReward{CustomerId=3, CustomerName="Pqr", CustomerTransactionId=1021, Price=155, TransactionDate = DateTime.Today.AddDays(-1) },
            new CustomerReward{CustomerId=3, CustomerName="Pqr", CustomerTransactionId=1022, Price=685, TransactionDate = DateTime.Today.AddDays(-15) },
            new CustomerReward{CustomerId=3, CustomerName="Pqr", CustomerTransactionId=1023, Price=158, TransactionDate = DateTime.Today.AddDays(-35)  },
            new CustomerReward{CustomerId=3, CustomerName="Pqr", CustomerTransactionId=1024, Price=1100, TransactionDate = DateTime.Today.AddDays(-25)  },
            new CustomerReward{CustomerId=3, CustomerName="Pqr", CustomerTransactionId=1025, Price=480, TransactionDate = DateTime.Today.AddDays(-42)  },
            new CustomerReward{CustomerId=3, CustomerName="Pqr", CustomerTransactionId=1026, Price=20, TransactionDate = DateTime.Today.AddDays(-8) },
            new CustomerReward{CustomerId=3, CustomerName="Pqr", CustomerTransactionId=1026, Price=520, TransactionDate = DateTime.Today.AddDays(-81) },
            new CustomerReward{CustomerId=3, CustomerName="Pqr", CustomerTransactionId=1026, Price=120, TransactionDate = DateTime.Today.AddDays(-86) },
            };

            return result;
        }
    }
}

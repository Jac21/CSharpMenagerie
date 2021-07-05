using System;
using System.Collections.Generic;
using System.Linq;

namespace Joins
{
    internal class Program
    {
        private static void Main()
        {
            Console.WriteLine("Hello, Join!");

            var customers = new List<Customer>
            {
                new Customer
                {
                    Id = 100,
                    Name = "Jeremy Cantu"
                },
                new Customer
                {
                    Id = 200,
                    Name = "Bill Gates"
                }
            };

            var customersPreferences
                = new List<CustomerPreferences>
                {
                    new CustomerPreferences
                    {
                        CustomerId = 100
                    }
                };

            var customerWithPreferences = new List<CustomerAggregate>
            {
                new CustomerAggregate
                {
                    Name = "Jeremy Cantu",
                    CustomerId = 100
                }
            };

            // the slow approach to merging two lists
            foreach (var customer in customers)
            {
                var customerPreference = customerWithPreferences
                    .SingleOrDefault(preference => preference.CustomerId == customer.Id);

                customerWithPreferences.Add(new CustomerAggregate
                {
                    CustomerId = customer.Id,
                    Name = customer.Name
                });
            }

            // also slow, using Select
            var customersWithPreferencesSelect = customers
                .Select(customer =>
                {
                    var preference =
                        customersPreferences
                            .SingleOrDefault(pref => pref.CustomerId == customer.Id);

                    return new CustomerAggregate
                    {
                        CustomerId = customer.Id,
                        Name = customer.Name,
                        Preference = preference
                    };
                });

            // the faster approach
            var customersWithPreferencesJoined =
                customers.Join(
                    customersPreferences,
                    customer => customer.Id,
                    preference => preference.CustomerId,
                    (customer, preference) => new CustomerAggregate
                    {
                        CustomerId = customer.Id,
                        Name = customer.Name,
                        Preference = preference
                    });

            Console.ReadLine();
        }
    }
}
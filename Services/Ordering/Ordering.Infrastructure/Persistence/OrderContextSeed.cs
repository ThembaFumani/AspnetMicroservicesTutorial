using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Ordering.Domain.Entities;

namespace Ordering.Infrastructure.Persistence
{
	public class OrderContextSeed
	{
		public static async Task SeedAsync(OrderContext orderContext, ILogger<OrderContextSeed> logger)
        {
			if (!orderContext.Orders.Any())
            {
				orderContext.Orders.AddRange(GetPreconfigOrders());
                await orderContext.SaveChangesAsync();
                logger.LogInformation("Seed database associated with context {DbContextName}", typeof(OrderContext));
            }
        }


		private static IEnumerable<Order> GetPreconfigOrders()
        {
            return new List<Order>
            {
                new Order()
                {
                    UserName = "me",
                    FirstName = "Themba",
                    LastName = "Maluleke",
                    EmailAddress = "thembamaluleke6@gmail.com",
                    AddressLine = "Mams",
                    Country = "Republic of South Africa",
                    TotalPrice = 350
                }
            };
        }
	}
}


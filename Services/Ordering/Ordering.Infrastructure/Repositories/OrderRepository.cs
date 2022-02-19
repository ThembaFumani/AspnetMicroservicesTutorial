using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Ordering.Infrastructure.Persistence;
using Ordering.Application.Contracts.Persistence;
using Ordering.Domain.Entities;

namespace Ordering.Infrastructure.Repositories
{
	public class OrderRepository : RepositoryBase<Order>, IOrderRepository
	{
        private readonly OrderContext _dbContext;

		public OrderRepository(OrderContext dbContext) : base(dbContext)
		{
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
		}

        public async Task<IEnumerable<Order>> GetOrderByUserName(string userName)
        {
            var orderList = await _dbContext.Orders
                                    .Where(o => o.UserName == userName)
                                    .ToListAsync();

            return orderList;
        }
    }
}


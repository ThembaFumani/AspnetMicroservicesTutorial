﻿using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Ordering.Application.Contracts.Persistence;
using Ordering.Application.Exceptions;
using Ordering.Domain.Entities;

namespace Ordering.Application.Features.Orders.Commands.DeleteOrder
{
	public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand>
	{
		private readonly IOrderRepository _orderRepository;
		private readonly IMapper _mapper;
		private readonly ILogger<DeleteOrderCommandHandler> _logger;

		public DeleteOrderCommandHandler(IOrderRepository orderRepository, IMapper mapper,
			ILogger<DeleteOrderCommandHandler> logger)
		{
			_orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
			_mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
			_logger = logger ?? throw new ArgumentNullException(nameof(logger));
		}

        public async Task<Unit> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
			var orderToDelete = await _orderRepository.GetByIdAsync(request.Id);

			if (orderToDelete == null)
			{
				_logger.LogError("Order does not exist in the database.");
				throw new NotFoundException(nameof(Order), request.Id);
			}

			_mapper.Map(request, orderToDelete, typeof(DeleteOrderCommand), typeof(Order));

			await _orderRepository.DeleteAsync(orderToDelete);

			_logger.LogInformation($"Order {orderToDelete.Id} was successfully deleted.");

			return Unit.Value;
		}
    }
}


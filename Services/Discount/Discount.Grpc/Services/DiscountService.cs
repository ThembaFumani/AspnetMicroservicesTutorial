﻿using System;
using System.Threading.Tasks;
using AutoMapper;
using Discount.Grpc.Entities;
using Discount.Grpc.Protos;
using Discount.Grpc.Repositories;
using Grpc.Core;
using Microsoft.Extensions.Logging;

namespace Discount.Grpc.Services
{
    public class DiscountService : DiscountProtoService.DiscountProtoServiceBase
    {
        private readonly IDiscountRepository _repository;
        private readonly ILogger _logger;
        private readonly IMapper _mapper;

        public DiscountService(IDiscountRepository repository, ILogger logger, IMapper mapper)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(logger));
        }

        public override async Task<CouponModel> GetDiscount(GetDiscountRequest request, ServerCallContext context)
        {
            var coupon = await _repository.GetDiscount(request.ProductName);
            if (coupon == null)
                throw new RpcException(new Status(StatusCode.NotFound, $"Discount with ProductName={request.ProductName} could not be found"));

            _logger.LogInformation("Discount is retrieved for ProductName: {productName}, Amount : {amount}", coupon.ProductName, coupon.Amount);

            var couponModel = _mapper.Map<CouponModel>(coupon);
            return couponModel;
        }

        public override async Task<CouponModel> CreateDiscount(CreateDiscountRequest request, ServerCallContext context)
        {
            var coupon = _mapper.Map<Coupon>(request.Coupon);

            await _repository.CreateDiscount(coupon);

            _logger.LogInformation("Discount is successfully created. ProductName: {productName}, Amount : {amount}", coupon.ProductName, coupon.Amount);

            var couponModel = _mapper.Map<CouponModel>(coupon);

            return couponModel;
        }

        public override async Task<CouponModel> UpdateDiscount(UpdateDiscountRequest request, ServerCallContext context)
        {
            var coupon = _mapper.Map<Coupon>(request);

            await _repository.UpdateDiscount(coupon);

            _logger.LogInformation("Discount is successfully updated. ProductName: {productName}, Amount : {amount}, Description : {description}", coupon.ProductName, coupon.Amount, coupon.Description);

            var couponModel = _mapper.Map<CouponModel>(coupon);

            return couponModel;
        }

        public override async Task<DeleteDiscountResponse> DeleteDiscount(DeleteDiscountRequest request, ServerCallContext context)
        {
            var deleted = await _repository.DeleteDiscount(request.ProductName.ToString());

            var response = new DeleteDiscountResponse
            {
                Success = deleted
            };

            return response;
        }
    }
}

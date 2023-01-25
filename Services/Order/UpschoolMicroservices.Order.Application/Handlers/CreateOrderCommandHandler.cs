using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UpSchoolECommerce.Shared.Dtos;
using UpschoolMicroservices.Order.Application.Commands;
using UpschoolMicroservices.Order.Application.DTOs;
using UpschoolMicroservices.Order.Domain.OrderAggregate;
using UpschoolMicroservices.Order.Infrastructure;

namespace UpschoolMicroservices.Order.Application.Handlers
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, ResponseDto<CreatedOrderDto>>
    {
        private readonly OrderDbContext _orderDbContext;
        private readonly IMapper _mapper;

        public CreateOrderCommandHandler(OrderDbContext orderDbContext, IMapper mapper)
        {
            _orderDbContext = orderDbContext;
            _mapper = mapper;
        }
        public async Task<ResponseDto<CreatedOrderDto>> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var newAddress = new Address(request.Address.City, request.Address.District, request.Address.Street,request.Address.ZipCode);
            Domain.OrderAggregate.Order newOrder = new Domain.OrderAggregate.Order(request.BuyerId, newAddress);
            request.orderItems.ForEach(x => {

                newOrder.AddOrderItem(x.ProductId, x.ProductName, x.Price, x.PictureUrl);


                });

            await _orderDbContext.Orders.AddAsync(newOrder);
            await _orderDbContext.SaveChangesAsync();
            return ResponseDto<CreatedOrderDto>.Success(new CreatedOrderDto { OrderId = newOrder.Id }, 204);
        }
    }
}

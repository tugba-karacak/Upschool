using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UpSchoolECommerce.Shared.Dtos;
using UpschoolMicroservices.Order.Application.DTOs;
using UpschoolMicroservices.Order.Application.Queries;
using UpschoolMicroservices.Order.Infrastructure;

namespace UpschoolMicroservices.Order.Application.Handlers
{
  public  class GetOrdersByUserIdQueryHandler : IRequestHandler<GetOrdersByUserIdQuery, ResponseDto<List<OrderDto>>>
    {
        private readonly OrderDbContext _orderDbContext;
        private readonly IMapper _mapper;

        public GetOrdersByUserIdQueryHandler(OrderDbContext orderDbContext, IMapper mapper)
        {
            _orderDbContext = orderDbContext;
            _mapper = mapper;
        }


        public async Task<ResponseDto<List<OrderDto>>> Handle(GetOrdersByUserIdQuery request, CancellationToken cancellationToken)
        {
            var orders = await _orderDbContext.Orders.Include(x => x.OrderItems).Where(x => x.BuyerId == request.UserId).ToListAsync();
           
                return ResponseDto<List<OrderDto>>.Success(_mapper.Map<List<OrderDto>>(orders),200 );
           
          

            //mapleme yazılacak
        }
    }
}

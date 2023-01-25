using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpSchoolECommerce.Shared.Dtos;
using UpschoolMicroservices.Order.Application.DTOs;

namespace UpschoolMicroservices.Order.Application.Queries
{
  public  class GetOrdersByUserIdQuery:IRequest<ResponseDto<List<OrderDto>>>
    {
        public string UserId { get; set; }
    }
}

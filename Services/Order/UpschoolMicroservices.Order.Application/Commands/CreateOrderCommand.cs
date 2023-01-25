using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpSchoolECommerce.Shared.Dtos;
using UpschoolMicroservices.Order.Application.DTOs;

namespace UpschoolMicroservices.Order.Application.Commands
{
   public class CreateOrderCommand:IRequest<ResponseDto<CreatedOrderDto>>
    {
        public string BuyerId { get; set; }
        public AddressDto Address { get; set; }
        public List<OrderItemDto> orderItems { get; set; }
    }
}

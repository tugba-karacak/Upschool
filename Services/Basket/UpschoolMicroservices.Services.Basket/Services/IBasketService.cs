using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UpSchoolECommerce.Shared.Dtos;
using UpschoolMicroservices.Services.Basket.Dtos;

namespace UpschoolMicroservices.Services.Basket.Services
{
   public interface IBasketService
    {
        Task<ResponseDto<BasketDto>> GetBasket(string userId);
        Task<ResponseDto<bool>> SaveOrUpdate(BasketDto basketDto);
        Task<ResponseDto<bool>> Delete(string userId);

    }
}

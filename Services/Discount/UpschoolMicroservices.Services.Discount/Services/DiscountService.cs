using Dapper;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using UpSchoolECommerce.Shared.Dtos;


namespace UpschoolMicroservices.Services.Discount.Services
{
    public class DiscountService : IDiscountService
    {
        private readonly IConfiguration _configuration;
        private readonly IDbConnection _dbConnection;

        public DiscountService(IConfiguration configuration)
        {
            _configuration = configuration;
            _dbConnection = new NpgsqlConnection(_configuration.GetConnectionString("PostgreSql"));
        }

        public async Task<ResponseDto<NoContent>> Delete(int id)
        {
            var status = await _dbConnection.ExecuteAsync("delete from discount where Id=@id", new
            {
                id=id

            });
            return status > 0 ? ResponseDto<NoContent>.Success(204) : ResponseDto<NoContent>.Fail("Silinecek değer bulunamadı", 404);
          
        }

        public async Task<ResponseDto<List<Models.Discount>>> GetAll()
        {
            var discounts = await _dbConnection.QueryAsync<Models.Discount>("select *from discount");
            return ResponseDto<List<Models.Discount>>.Success(discounts.ToList(), 200);
        }

        public Task<ResponseDto<Models.Discount>> GetByCodeUserId(string code, string userId)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseDto<Models.Discount>> GetById(int id)
        {
            var discount = (await _dbConnection.QueryAsync<Models.Discount>("select *from discount where Id=@id", new
            {

                id = id

            })).SingleOrDefault();
                return ResponseDto<Models.Discount>.Success(discount, 200);
          
        }

        public async Task<ResponseDto<NoContent>> Save(Models.Discount discount)
        {
            var status = await _dbConnection.ExecuteAsync("insert into discount(userid,rate,code) values (@UserId,@Rate,@Code)", discount);

            if (status>0)
            {
                return ResponseDto<NoContent>.Success(204);
            }
            return ResponseDto<NoContent>.Fail("Bir Hata Oluştu", 500);
        }

        public async Task<ResponseDto<NoContent>> Update(Models.Discount discount)
        {
            var status = await _dbConnection.ExecuteAsync("update discount set userid=@UserId,rate=@Rate,GetByCodeUserId=@Code where Id=@Id)", discount);

            if (status > 0)
            {
                return ResponseDto<NoContent>.Success(204);
            }
            return ResponseDto<NoContent>.Fail("Bir Hata Oluştu", 500);
        }
    }
}

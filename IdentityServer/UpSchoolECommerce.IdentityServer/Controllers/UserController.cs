using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using UpSchoolECommerce.IdentityServer.DTOs;
using UpSchoolECommerce.IdentityServer.Models;
using UpSchoolECommerce.Shared.Dtos;
using static IdentityServer4.IdentityServerConstants;

namespace UpSchoolECommerce.IdentityServer.Controllers
{
    [Authorize(LocalApi.PolicyName)]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        [HttpPost]
        public async  Task<IActionResult> SignUp(SignUpDTOs signUpDTOs)
        {
            var user = new ApplicationUser
            {
                UserName = signUpDTOs.UserName,
                Email = signUpDTOs.Email,
                City = signUpDTOs.City
            };
            var result = await _userManager.CreateAsync(user, signUpDTOs.Password);

            if (!result.Succeeded)
            {
                return BadRequest(ResponseDto<NoContent>.Fail(result.Errors.Select(x=>x.Description).ToList(),400));
            }

            return NoContent();
        }
        [HttpGet]
        public async Task<IActionResult> GetUser()
        {
            var userId = User.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Sub);
            var user = await _userManager.FindByIdAsync(userId.Value);
            return Ok(new
            {
                Id=user.Id,
                UserName=user.UserName,
                Email=user.Email,
                City=user.City
            });

        }
    }
}

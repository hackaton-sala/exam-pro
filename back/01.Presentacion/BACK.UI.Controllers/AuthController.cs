using AutoMapper;
using BACK.CORE.Entities;
using BACK.CORE.Resources;
using BACK.CORE.Interfaces;
using BACK.UI.Controllers.Helpers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BACK.UI.Controllers
{
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly IServiceManager _service;
        private readonly IMapper _mapper;

        public AuthController(IConfiguration config, IServiceManager service, IMapper mapper)
        {
            _config = config;
            _service = service;
            _mapper = mapper;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginResource resource)
        {
            var user = await _service.UserService.FindByEmailAsync(resource.Email);
            if (user == null) 
            {
                return BadRequest(new { message = "invalid-username", success = false });
            }

            if(!await _service.UserService.CheckPasswordAsync(user, resource.Password))
            {
                return BadRequest(new { message = "invalid-password", success = false });
            }

            if (user != null && await _service.UserService.CheckPasswordAsync(user, resource.Password))
            {
                // Generar token JWT
                var token = GenerateJwtToken(_mapper.Map<UserResource>(user));
                var UserInformation = _service.UserService.GetUserFull(user.UserId);
                return Ok(new { token, User = UserInformation, message = "login-success", success = true });
            }
            return BadRequest(new { message = "login-error", success = false });
        }

        private string GenerateJwtToken(UserResource userResource)
        {
            var token = JWTHelper.GetToken(_config, userResource);
            return token;
        }


    }
}
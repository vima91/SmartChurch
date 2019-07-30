using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using SmartChurch.DataModel.Models.Dtos;
using SmartChurch.Infrastructure;
using SmartChurch.Infrastructure.Exceptions;
using SmartChurch.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace SmartChurch.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        //private readonly IMapper _mapper;
        private readonly IServiceProvider _serviceProvider;

        public UsersController(
            IUserService userService,
            //IMapper mapper, 
            IServiceProvider serviceProvider)
        {
            _userService = userService;
            //_mapper = mapper;
            _serviceProvider = serviceProvider;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody]AppUserDto userDto)
        {
            var user = _userService.Authenticate(userDto.UserName, userDto.Password);

            if (user == null)
            {
                return BadRequest(new { message = "Username or password is incorrect" });
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(SiriusConfiguration.AppSecret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, user.Id)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            // return basic user info (without password) and token to store client side
            return Ok(new
            {
                Id = user.Id,
                Username = user.UserName,
                Token = tokenString
            });
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public IActionResult Register([FromBody]AppUserDto userDto)
        {
            var userManager = _serviceProvider.GetRequiredService<UserManager<IdentityUser>>();

            var user = userManager.FindByEmailAsync(userDto.UserName).Result;

            var requiredRole = (SiriusEnums.Roles) userDto.Role;

            if (user != null)
            {
                return BadRequest($"User {userDto.UserName} already exists!");
            }

            try
            {
                user = new IdentityUser
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName = userDto.UserName,
                    Email = userDto.UserName,
                    SecurityStamp = Guid.NewGuid().ToString(),
                };
                userManager.CreateAsync(user, userDto.Password + SiriusConfiguration.Salt).Wait();
                userManager.AddToRoleAsync(user, requiredRole.ToString()).Wait();
                return Ok();
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }

        //[HttpGet]
        //public IActionResult GetAll()
        //{
        //    var users = _userService.GetAll();
        //    var userDtos = _mapper.Map<IList<AppUserDto>>(users);
        //    return Ok(userDtos);
        //}

        //[HttpGet("{id}")]
        //public IActionResult GetById(int id)
        //{
        //    var user = _userService.GetById(id);
        //    var userDto = _mapper.Map<AppUserDto>(user);
        //    return Ok(userDto);
        //}

        //[HttpPut("{id}")]
        //public IActionResult Update(string id, [FromBody]AppUserDto userDto)
        //{
        //    // map dto to entity and set id
        //    var user = _mapper.Map<IdentityUser>(userDto);
        //    user.Id = id;

        //    try
        //    {
        //        // save 
        //        _userService.Update(user, userDto.Password);
        //        return Ok();
        //    }
        //    catch (AppException ex)
        //    {
        //        // return error message if there was an exception
        //        return BadRequest(new { message = ex.Message });
        //    }
        //}

        //[HttpDelete("{id}")]
        //public IActionResult Delete(int id)
        //{
        //    _userService.Delete(id);
        //    return Ok();
        //}
    }
}
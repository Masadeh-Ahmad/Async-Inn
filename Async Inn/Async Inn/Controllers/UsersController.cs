using Async_Inn.Interfaces;
using Async_Inn.Models;
using Async_Inn.Models.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Async_Inn.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }


        [HttpPost("Register")]
        public async Task<ActionResult> Register(RegisterUserDTO data)
        {
            try
            {
            
                await _userService.Register(data, this.ModelState);
                if (ModelState.IsValid)
                {
                    return Ok("Registered done");

                }
                return BadRequest(new ValidationProblemDetails(ModelState));

            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
        [HttpPost("Login")]
        public async Task<ActionResult> Authenticate(LoginUserDTO loginUserDTO)
        {
            try
            {
                var result = await _userService.Authenticate(loginUserDTO.UserName, loginUserDTO.Password, this.ModelState);
                if (result == null)
                {
                    return BadRequest("User not found or password is wrong");
                }

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return Ok(loginUserDTO);
        }
    }
    
}

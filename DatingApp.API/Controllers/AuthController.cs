using Microsoft.AspNetCore.Mvc;
using DatingApp.API.Data;
using System.Threading.Tasks;
using DatingApp.API.Models;
using DatingApp.API.Dtos;

namespace DatingApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _repo;
        public AuthController(IAuthRepository repo)
        {
            _repo  = repo;
        }

        [HttpPost("register")]
        //public async Task<IActionResult> Register([FromBody]UserFOrRegisterDto userFOrRegisterDto)
        public async Task<IActionResult> Register([FromBody]UserFOrRegisterDto userFOrRegisterDto)
        {
            //if(!ModelState.IsValid)
                //return BadRequest(ModelState);
            
            userFOrRegisterDto.Username = userFOrRegisterDto.Username.ToLower();

            if(await _repo.UserExists(userFOrRegisterDto.Username))
                return BadRequest("Username already exists");

            var userToCreate = new User
            {
                Username = userFOrRegisterDto.Username
            };

            var CreatedUser = await _repo.Register(userToCreate, userFOrRegisterDto.Password);

            return StatusCode(201);
        }
    }
}
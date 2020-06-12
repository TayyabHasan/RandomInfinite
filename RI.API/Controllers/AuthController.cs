using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RI.api.Data;
using RI.api.DTO;
using RI.api.Models;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System;

namespace RI.api.Controllers 
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _repo;

        public IConfiguration _config { get; }

        public AuthController(IAuthRepository repo,IConfiguration config)
        {
            _repo = repo;
            _config = config;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserForRegisterDto userForRegisterDto){
            
            if (await _repo.UserExists(userForRegisterDto.email.ToLower())){
                return BadRequest("Email Already Exist");
            }

            var userToCreate = new User{
                email = userForRegisterDto.email.ToLower(),
                dateOfBirth = userForRegisterDto.dateOfBirth,
                gender = userForRegisterDto.gender,
                name = userForRegisterDto.name
            };

            var createdUser = _repo.Register(userToCreate,userForRegisterDto.password);
            return StatusCode(201); 

        } 

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserForLoginDto userForLoginDto){
            //Check if User already exists or not
            var userFromRepo = await _repo.Login(userForLoginDto.email.ToLower(),userForLoginDto.password);
            if (userFromRepo == null)
                return Unauthorized();
            
            //If user exist Now we need to create a Token

            var claims = new []{
                new Claim(ClaimTypes.NameIdentifier, userFromRepo.id.ToString()),
                new Claim(ClaimTypes.Name, userFromRepo.name)
            };

            //This will Generate a Key for Us using our Secret Token
            var key = new SymmetricSecurityKey(Encoding.UTF8
                .GetBytes(_config.GetSection("AppSettings:Token").Value));


            //Generating Siging Credentials (KEY , Algorithm TYPE)
            var creds = new SigningCredentials(key,SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddHours(24),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return Ok(new {
                token = tokenHandler.WriteToken(token)
            });

        }

    }
}
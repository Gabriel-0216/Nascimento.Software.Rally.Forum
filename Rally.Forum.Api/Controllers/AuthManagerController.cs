using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rally.Forum.Api.DTO;
using Rally.Forum.Domain.models;
using Rally.Forum.Infra.Users;
using Rally.Forum.Services.Services.JWT;
using System.Threading.Tasks;

namespace Rally.Forum.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthManagerController : ControllerBase
    {

        private readonly TokenGenerator _Tokens;
        private readonly IMapper _mapper;

        public AuthManagerController(TokenGenerator tokens, IMapper mapper)
        {
            _Tokens = tokens;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("registration")]
        public async Task<ActionResult> Registration([FromServices] IUserRepository _repo, UserRegistrationDTO userDTO)
        {
            if (ModelState.IsValid)
            {
                var userRegister = _mapper.Map<UserRegistration>(userDTO);
                var userRegisterResponse = await _repo.Register(userRegister);
                if(userRegisterResponse.User == null)
                {
                    return BadRequest($"Ocorreu um erro no registro {userRegisterResponse.Errors}, {userRegisterResponse.response}");
                }

                var token = _Tokens.GenerateJwtToken(userRegisterResponse.User);
                if (token == null)
                {
                    return BadRequest("Ocorreu um erro");
                }
                return Ok(new AuthResult()
                {
                    Success = true,
                    Token = token,
                });
            }
            return StatusCode(StatusCodes.Status500InternalServerError);
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult> Login([FromServices] IUserRepository _repo, UserLoginDTO userLogin)
        {
            if (ModelState.IsValid)
            {
                var userLoginMap = _mapper.Map<UserLogin>(userLogin);
                var userLoginResponse = await _repo.Login(userLoginMap);
                if(userLoginResponse.User == null)
                {
                    return BadRequest($"Ocorreu um erro no login: {userLoginResponse.Errors}, {userLoginResponse.response}");
                }

                var token = _Tokens.GenerateJwtToken(userLoginResponse.User);

                if (token == null) return BadRequest("Ocorreu um erro");

                return Ok(new AuthResult()
                {
                    Success = true,
                    Token = token,
                });
            }
            return StatusCode(StatusCodes.Status500InternalServerError);

        }
    }
}

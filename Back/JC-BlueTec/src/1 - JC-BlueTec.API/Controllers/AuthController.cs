using AutoMapper;
using JC_BlueTec.API.Token;
using JC_BlueTec.API.Utilities;
using JC_BlueTec.API.ViewModes;
using JC_BlueTec.Services.DTO;
using JC_BlueTec.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace JC_BlueTec.API.Controllers
{
    [Route("api/[controller]")]
    public class AuthController : Controller
    {

        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        private readonly ITokenGenerator _tokenGenerator;

        public AuthController(ITokenGenerator tokenGenerator, IMapper mapper, IUserService userService)
        {
            _tokenGenerator = tokenGenerator;
            _mapper = mapper;
            _userService = userService;
        }

        [HttpPost]

        public async Task<IActionResult> Login([FromBody] LoginViewModel loginView)
        {
            try
            {
                var user = await _userService.GetByEmail(loginView.Usuario);

                if (user == null)
                    return Ok(new ResultViewModel
                    {
                        Message = "Nenhum usuário foi encontrado com o email informado.",
                        Success = true,
                        Data = user
                    });

                if (user.Password == loginView.Senha)
                {
                    var token = _tokenGenerator.GenerateToken();
                    return Ok(token);
                }

                return BadRequest("e-mail ou senha inválidos!");

            }
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }

        }

    }
}

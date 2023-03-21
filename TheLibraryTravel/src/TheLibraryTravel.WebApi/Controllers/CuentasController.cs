using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TheLibraryTravel.Dtos;

namespace TheLibraryTravel.WebApi.Controllers
{
    [ApiController]
    [Route("api/cuentas")]
    public class CuentasController : ControllerBase
    {
        private readonly UserManager<IdentityUser> UserManager;
        private readonly IConfiguration Configuration;
        private readonly SignInManager<IdentityUser> SignInManager;

        public CuentasController(UserManager<IdentityUser> userManager, IConfiguration configuration, SignInManager<IdentityUser> signInManager)
        {
            UserManager = userManager;
            Configuration = configuration;
            SignInManager = signInManager;
        }

        [HttpPost("Registar")]
        public async Task<ActionResult<AutentificacionDto>> Registrar(CredencialesUsuarioDto credencialesUsuarioDto)
        {
            var usuario = new IdentityUser { UserName = credencialesUsuarioDto.Email, Email = credencialesUsuarioDto.Email };
            var resultado = await UserManager.CreateAsync(usuario, credencialesUsuarioDto.Password);

            if (resultado.Succeeded)
            {
                return ConstruirToken(credencialesUsuarioDto);
            }
            else
            {
                return BadRequest(resultado.Errors);
            }
        }


        [HttpGet("RenovarToken")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<AutentificacionDto>> Renovar()
        {
            var emailClaim = HttpContext.User.Claims.Where(claim => claim.Type == "email").FirstOrDefault();
            var email = emailClaim.Value;
            var credencialesUsuario = new CredencialesUsuarioDto()
            {
                Email = email
            };

            return ConstruirToken(credencialesUsuario);
        }

        [HttpPost("Login", Name = "loginUsuario")]
        public async Task<ActionResult<AutentificacionDto>> Login(CredencialesUsuarioDto credencialesUsuarioDto)
        {
            var resultado = await SignInManager.PasswordSignInAsync(credencialesUsuarioDto.Email,
                credencialesUsuarioDto.Password, isPersistent: false, lockoutOnFailure: false);

            if (resultado.Succeeded)
            {
                return ConstruirToken(credencialesUsuarioDto);
            }
            else
            {
                return BadRequest("Login incorrecto");
            }
        }

        private AutentificacionDto ConstruirToken(CredencialesUsuarioDto credencialesUsuarioDto)
        {
            var claims = new List<Claim>()
            {
                new Claim("email", credencialesUsuarioDto.Email)
            };

            var llave = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["llavejwt"]));
            var creds = new SigningCredentials(llave, SecurityAlgorithms.HmacSha256);
            var expiracion = DateTime.UtcNow.AddMinutes(160);
            var securityToken = new JwtSecurityToken(issuer: null, audience: null, claims: claims, expires: expiracion, signingCredentials: creds);

            return new AutentificacionDto()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(securityToken),
                Expiracion = expiracion
            };
        }

    }
}

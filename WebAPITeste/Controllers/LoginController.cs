using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPITeste.Models;
using WebAPITeste.Repository;
using WebAPITeste.Services;

namespace WebAPITeste.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<dynamic>> Authenticate([FromBody] User model)
        {
            var user = UserRepository.Get(model.Username, model.Passowrd);

            if( user == null )
            {
                return NotFound(new { message = "Usuário ou senha inválidos" });

            }

            var token = TokenService.GenerateToken(user);

            user.Passowrd = "";
           
            return new
            {
                user = user,
                token = token
            };

        }
    }
}

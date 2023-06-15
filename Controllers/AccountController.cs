using Microsoft.AspNetCore.Mvc;
using ProjektZawody.Data.Services;
using ProjektZawody.Models;
using System.Text.RegularExpressions;

namespace ProjektZawody.Controllers
{
    [Route("api/account")]//sciezka podstawowa dla wszytskich akcji w kontrolerze
    //[ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService) 
        {
            _accountService = accountService;
        }
        [HttpPost("register")]
        public ActionResult RegisterUser([FromBody]RegisterUserDto dto)
        {
            _accountService.RegisterUser(dto);
            return Ok();
        }

        [HttpPost("login")]
        public ActionResult Login([FromBody]LoginDto dto)
        {
            string token = _accountService.GenerateJwt(dto);
            return Ok(token);
        }
    }
}

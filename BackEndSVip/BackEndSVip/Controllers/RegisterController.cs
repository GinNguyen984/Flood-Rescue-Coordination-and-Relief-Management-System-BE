using DataAccessLayer.ViewModels;
using Microsoft.AspNetCore.Mvc;
using BusinessLayer.IService;

namespace BackEndSVip.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly IUserService _userService;
        public RegisterController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterVM registerInfo)
        {
            var success = await _userService.RegisterAsync(registerInfo);
            if (!success)
            {
                return Conflict(new { message = "Phone number already existed." });
            }
            return Ok(new { message = "Register Succeedfully." });
        }
    }
}
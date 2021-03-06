using GymManagement.Application.Interfaces.ServiceInterfaces;
using GymManagement.Application.ViewModels.MemberViewModel;
using Microsoft.AspNetCore.Mvc;

using System.Threading.Tasks;

namespace GymManagement.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthenticationController(IAuthService authService)
        { 
            _authService = authService;
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] MemberLoginViewModel model)
        {
            var token = await _authService.Login(model);
            return Ok(token);
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register ([FromBody] MemberRegisterViewModel model)
        {
            await _authService.Register(model);
            return Ok("Kayıt Başarılı");
        }
    }
}

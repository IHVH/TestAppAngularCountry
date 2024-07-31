using AutoMapper;
using EntitiesDAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TestAppAngularCountry.Server.DataTransferObjects;

namespace TestAppAngularCountry.Server.Controllers
{
    public class AccountsController : Controller
    {
        private readonly ILogger _logger;
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        public AccountsController(UserManager<User> userManager, IMapper mapper, ILogger<AccountsController> logger)
        {
            _userManager = userManager;
            _mapper = mapper;
            _logger = logger;
        }
        [HttpPost("Registration")]
        public async Task<IActionResult> RegisterUser([FromBody] UserForRegistrationDto userForRegistration)
        {
            try
            {
                if (userForRegistration == null || !ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var user = _mapper.Map<User>(userForRegistration);
                var result = await _userManager.CreateAsync(user, userForRegistration.Password!);
                if (!result.Succeeded)
                {
                    var errors = result.Errors.Select(e => e.Description);
                    return BadRequest(new RegistrationResponseDto { Errors = errors });
                }

                return StatusCode(201);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Registration exception!");
                return BadRequest(new RegistrationResponseDto { Errors = [ex.Message] });
            }
        }
    }
}

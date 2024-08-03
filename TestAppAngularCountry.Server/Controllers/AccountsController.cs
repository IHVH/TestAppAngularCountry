using AutoMapper;
using EntitiesDAL.Interfaces.Repositories;
using EntitiesDAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TestAppAngularCountry.Server.DataTransferObjects;

namespace TestAppAngularCountry.Server.Controllers
{
    [Route("api/accounts")]
    [ApiController]
    public class AccountsController : Controller
    {
        private readonly ILogger _logger;
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        private readonly IProvinceRepository _provinceRepository;

        public AccountsController(UserManager<User> userManager, 
            IMapper mapper, 
            ILogger<AccountsController> logger,
            IProvinceRepository  provinceRepository)
        {
            _userManager = userManager;
            _mapper = mapper;
            _logger = logger;
            _provinceRepository = provinceRepository;
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

        [HttpPost("UpdateUser")]
        public async Task<IActionResult> UpdateUser([FromBody] UserForUpdateDto userForRegistration)
        {
            try
            {
                if (userForRegistration == null || !ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var user = await _userManager.FindByEmailAsync(userForRegistration.Email!);
                if(user == null)
                {
                    return BadRequest(new RegistrationResponseDto { Errors = ["User is not found."] });
                } 
                    
                else
                {
                    if(await _userManager.CheckPasswordAsync(user, userForRegistration.Password!))
                    {
                        var province = await _provinceRepository.Find(userForRegistration.ProvinceId);
                        if (province?.CountryId == userForRegistration.CountryId)
                        {
                            user.CountryId = userForRegistration.CountryId;
                            user.ProvinceId = userForRegistration.ProvinceId;
                            var result = await _userManager.UpdateAsync(user);
                            if (!result.Succeeded)
                            {
                                var errors = result.Errors.Select(e => e.Description);
                                return BadRequest(new RegistrationResponseDto { Errors = errors });
                            }
                        }
                        else
                        {
                            return BadRequest(new RegistrationResponseDto { Errors = ["Incorrect country and region values ​​passed."] });
                        }
                    }
                    else
                    {
                        return BadRequest(new RegistrationResponseDto { Errors = ["Incorrect password."] });
                    }
                }

                return StatusCode(201);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Update user exception!");
                return BadRequest(new RegistrationResponseDto { Errors = [ex.Message] });
            }
        }
    }
}

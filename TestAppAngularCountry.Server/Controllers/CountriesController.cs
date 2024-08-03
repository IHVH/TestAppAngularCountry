using AutoMapper;
using EntitiesDAL.Interfaces.Repositories;
using EntitiesDAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TestAppAngularCountry.Server.DataTransferObjects;

namespace TestAppAngularCountry.Server.Controllers
{
    [Route("api/countries")]
    [ApiController]
    public class CountriesController : Controller
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly IProvinceRepository _provinceRepository;
        private readonly ICountryRepository _countryRepository;

        public CountriesController(ILogger<CountriesController> logger,
            IMapper mapper,
            IProvinceRepository provinceRepository,
            ICountryRepository countryRepository)
        {
            _logger = logger;
            _mapper = mapper;
            _provinceRepository = provinceRepository;
            _countryRepository = countryRepository;
        }

        [HttpGet("List")]
        public async Task<IActionResult> Countries()
        {
            try
            {
                var countries = await _countryRepository.GetListAsNoTracking();
                var response = _mapper.Map<List<CountryDto>>(countries);
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "list countries exception!");
                return BadRequest(new ErrorResponseDto { Errors = [ex.Message] });
            }
        }

        [HttpGet("ProvincesList")]
        public async Task<IActionResult> Provinces(int countryId)
        {
            try
            {
                var provinces = await _provinceRepository.GetListProvinceAsNoTracking(countryId);
                var response = _mapper.Map<List<ProvinceDto>>(provinces);
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "list provinces exception!");
                return BadRequest(new ErrorResponseDto { Errors = [ex.Message] });
            }
        }
    }
}

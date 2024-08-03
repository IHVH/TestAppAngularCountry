using System.ComponentModel.DataAnnotations;

namespace TestAppAngularCountry.Server.DataTransferObjects
{
    public class UserForUpdateDto : UserForRegistrationDto
    {
        [Required(ErrorMessage = "Country is required.")]
        public int CountryId { get; set; }

        [Required(ErrorMessage = "Province is required.")]
        public int ProvinceId { get; set; }
    }
}

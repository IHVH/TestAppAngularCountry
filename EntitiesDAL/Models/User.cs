using Microsoft.AspNetCore.Identity;

namespace EntitiesDAL.Models
{
    public class User : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public Country? Country { get; set; }
        public int? CountryId { get; set; }
        public Province? Province { get; set; }
        public int? ProvinceId { get; set; }
        public bool Agree { get; set; }
    }
}

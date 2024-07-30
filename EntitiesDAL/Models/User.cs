using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

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
    }
}

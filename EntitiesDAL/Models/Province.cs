using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesDAL.Models
{
    public class Province
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public Country? Country { get; set; }
        public int? CountryId { get; set; }
        public List<User> Users { get; set; } = new();
    }
}

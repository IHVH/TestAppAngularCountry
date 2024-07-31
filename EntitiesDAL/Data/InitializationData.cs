using EntitiesDAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesDAL.Data
{
    public static class InitializationData
    {
        public static (Country[], Province[]) GetData()
        {
            Country ru = new() { Id = 1, Name = "Russia", Code = "RU" };
            Country de = new() { Id = 2, Name = "Germany", Code = "DE" };


            Province ru_spb = new() { Id = 1, CountryId = ru.Id, Name = "Saint Petersburg" };
            Province ru_sta = new() { Id = 2, CountryId = ru.Id, Name = "Stavropol region" };
            Province de_he = new() { Id = 3, CountryId = de.Id, Name = "Hesse" };
            Province de_by = new() { Id = 4, CountryId = de.Id, Name = "Bavaria" };

            return (
                [ru, de], 
                [ru_spb, ru_sta, de_he, de_by]
            );
        }
    }
}

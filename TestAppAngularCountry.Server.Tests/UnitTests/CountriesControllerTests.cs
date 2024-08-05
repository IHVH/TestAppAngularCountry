using AutoMapper;
using EntitiesDAL.Data;
using EntitiesDAL.Interfaces.Repositories;
using EntitiesDAL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestAppAngularCountry.Server.Controllers;
using TestAppAngularCountry.Server.DataTransferObjects;

namespace TestAppAngularCountry.Server.Tests.UnitTests
{
    public class CountriesControllerTests
    {
        [Test]
        public async Task Countries_ReturnsOkObjectResult_WithAListCountryDto()
        {
            // Arrange
            int countryId = 1;
            var data = InitializationData.GetData();
            var testProvinces = data.Item2.Where(p => p.CountryId == countryId).ToList();
            var testCountries = data.Item1.ToList();

            var mapperMock = new Mock<IMapper>();
            var loggerMock = new Mock<ILogger<CountriesController>>();

            var mockProvinceRepo = new Mock<IProvinceRepository>();
            mockProvinceRepo.Setup(repo => repo.GetListProvinceAsNoTracking(countryId))
                .ReturnsAsync(testProvinces);

            var mockCountryRepo = new Mock<ICountryRepository>();
            mockCountryRepo.Setup(repo => repo.GetListAsNoTracking())
                .ReturnsAsync(testCountries);

            var expectedCountries = new List<CountryDto>();
            foreach (var country in testCountries)
            {
                expectedCountries.Add(new CountryDto { Id = country.Id, Name = country.Name });
            }

            mapperMock.Setup(m => m.Map<List<CountryDto>>(testCountries)).Returns(expectedCountries);

            var controller = new CountriesController(loggerMock.Object,
                mapperMock.Object,
                mockProvinceRepo.Object,
                mockCountryRepo.Object);

            // Act
            var result = await controller.Countries();

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(result, Is.InstanceOf<IActionResult>());
                Assert.That(result, Is.InstanceOf<OkObjectResult>());
                var okResult = result as OkObjectResult;
                Assert.That(okResult?.StatusCode!, Is.EqualTo(200));

                Assert.That(okResult?.Value, Is.InstanceOf<List<CountryDto>>());
                var resultCountries = okResult?.Value as List<CountryDto>;
                Assert.That(resultCountries?.Count!, Is.EqualTo(testCountries.Count));

                foreach (var country in testCountries)
                {
                    CountryDto resultCountry = resultCountries?.First(c => c.Id == country.Id)!;
                    Assert.Multiple(() =>
                    {
                        Assert.That(resultCountry.Id, Is.EqualTo(country.Id));
                        Assert.That(resultCountry.Name!, Is.EqualTo(country.Name!));
                    });
                }
            });
        }

        [Test]
        public async Task Provinces_ReturnsOkObjectResult_WithAListProvinceDto()
        {
            // Arrange
            int countryId = 1;
            var data = InitializationData.GetData();
            var testProvinces = data.Item2.Where(p => p.CountryId == countryId).ToList();
            var testCountries = data.Item1.ToList();

            var mapperMock = new Mock<IMapper>();
            var loggerMock = new Mock<ILogger<CountriesController>>();

            var mockProvinceRepo = new Mock<IProvinceRepository>();
            mockProvinceRepo.Setup(repo => repo.GetListProvinceAsNoTracking(countryId))
                .ReturnsAsync(testProvinces);

            var mockCountryRepo = new Mock<ICountryRepository>();
            mockCountryRepo.Setup(repo => repo.GetListAsNoTracking())
                .ReturnsAsync(testCountries);

            var expectedProvinces = new List<ProvinceDto>();
            foreach (var province in testProvinces)
            {
                expectedProvinces.Add(new ProvinceDto { Id = province.Id, Name = province.Name });
            }

            mapperMock.Setup(m => m.Map<List<ProvinceDto>>(testProvinces)).Returns(expectedProvinces);

            var controller = new CountriesController(loggerMock.Object,
                mapperMock.Object,
                mockProvinceRepo.Object,
                mockCountryRepo.Object);

            // Act
            var result = await controller.Provinces(countryId);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(result, Is.InstanceOf<IActionResult>());
                Assert.That(result, Is.InstanceOf<OkObjectResult>());
                var okResult = result as OkObjectResult;
                Assert.That(okResult?.StatusCode!, Is.EqualTo(200));
                Assert.That(okResult?.Value, Is.InstanceOf<List<ProvinceDto>>());
                var resultProvinces = okResult?.Value as List<ProvinceDto>;
                Assert.That(resultProvinces?.Count!, Is.EqualTo(testProvinces.Count));
                foreach (var province in testProvinces)
                {
                    ProvinceDto resultProvince = resultProvinces?.First(p => p.Id == province.Id)!;
                    Assert.Multiple(() =>
                    {
                        Assert.That(resultProvince.Id, Is.EqualTo(province.Id));
                        Assert.That(resultProvince.Name!, Is.EqualTo(province.Name!));
                    });
                }
            });
        }


        [Test]
        public async Task Provinces_ReturnsOkObjectResult_With_NULL_When_countryIdisWrong()
        {
            // Arrange
            int countryId = 1;
            var data = InitializationData.GetData();
            var testProvinces = data.Item2.Where(p => p.CountryId == countryId).ToList();
            var testCountries = data.Item1.ToList();

            var mapperMock = new Mock<IMapper>();
            var loggerMock = new Mock<ILogger<CountriesController>>();

            var mockProvinceRepo = new Mock<IProvinceRepository>();
            mockProvinceRepo.Setup(repo => repo.GetListProvinceAsNoTracking(countryId))
                .ReturnsAsync(testProvinces);

            var mockCountryRepo = new Mock<ICountryRepository>();
            mockCountryRepo.Setup(repo => repo.GetListAsNoTracking())
                .ReturnsAsync(testCountries);

            var expectedProvinces = new List<ProvinceDto>();
            foreach (var province in testProvinces)
            {
                expectedProvinces.Add(new ProvinceDto { Id = province.Id, Name = province.Name });
            }

            mapperMock.Setup(m => m.Map<List<ProvinceDto>>(testProvinces)).Returns(expectedProvinces);

            var controller = new CountriesController(loggerMock.Object,
                mapperMock.Object,
                mockProvinceRepo.Object,
                mockCountryRepo.Object);

            // Act
            var result = await controller.Provinces(0);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(result, Is.InstanceOf<IActionResult>());
                Assert.That(result, Is.InstanceOf<OkObjectResult>());
                var okResult = result as OkObjectResult;
                Assert.That(okResult?.StatusCode!, Is.EqualTo(200));
                Assert.That(okResult?.Value, Is.EqualTo(null));
            });
        }
    }
}

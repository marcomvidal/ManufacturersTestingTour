using System.Collections.Generic;
using System.Linq;
using Cars.Api.Services;
using Cars.Domain.Models;
using Cars.Domain.Seeds;
using FluentAssertions;
using Xunit;

namespace Cars.Test.Integration
{
    public class ManufacturersServiceTest : IntegrationTest
    {
        [Fact]
        public async void ShouldGetAllManufacturers()
        {
            this.db.Manufacturers.AddRange(DataSeed.Manufacturers);
            this.db.SaveChanges();

            var service = new ManufacturersService(this.db);
            var manufacturers = await service.GetAll();

            manufacturers.Should()
                .BeOfType<List<Manufacturer>>().And
                .HaveCount(DataSeed.Manufacturers.Count());
        }

        [Fact]
        public async void ShouldGetManufacturerByIdSuccessfully()
        {
            this.db.Manufacturers.Add(DataSeed.Manufacturers[0]);
            this.db.SaveChanges();
            
            var service = new ManufacturersService(this.db);
            var manufacturer = await service.GetById(1);

            manufacturer.Should().Match<Manufacturer>(x => x.Id == 1 && x.Name == "Volkswagen");
        }

        [Fact]
        public async void ShouldReturnNullWhenGettingManufacturerByAnInvalidId()
        {
            this.db.Manufacturers.Add(DataSeed.Manufacturers[0]);
            this.db.SaveChanges();
            
            var service = new ManufacturersService(this.db);
            var manufacturer = await service.GetById(2);

            manufacturer.Should().Be(null);
        }
    }
}
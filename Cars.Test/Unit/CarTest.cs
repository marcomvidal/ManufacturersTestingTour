using System;
using Cars.Domain.Models;
using FluentAssertions;
using Xunit;

namespace Cars.Test.Unit
{
    public class CarTest
    {
        [Fact]
        public void ShouldIncreaseSpeedByTenWhenAccelerate()
        {
            var car = new Car();
            car.Accelerate();

            car.Speed.Should().Be(10);
        }

        [Fact]
        public void ShouldThrowExceptionWhenAccelerateMoreThan210Kmh()
        {
            var car = new Car();
            car.Speed = 211;
            Action accelerate = () => car.Accelerate();

            accelerate.Should().ThrowExactly<InvalidOperationException>();
        }

        [Fact]
        public void ShouldDecreaseSpeedByTenWhenBrake()
        {
            var car = new Car();
            car.Speed = 100;
            car.Brake();

            car.Speed.Should().Be(90);
        }

        [Fact]
        public void ShouldThrowExceptionWhenBrakeLessThan9Kmh()
        {
            var car = new Car();
            car.Speed = 9;
            Action brake = () => car.Brake();

            brake.Should().ThrowExactly<InvalidOperationException>();
        }
    }
}
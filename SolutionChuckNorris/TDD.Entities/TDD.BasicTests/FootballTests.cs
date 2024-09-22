using FluentAssertions;
using Moq;
using System.Collections.Generic;
using TDD.Entities;
using Xunit;

namespace TDD.BasicTests
{
    public class FootBallTest
    {
        private List<Player> _players =
            new List<Player> {
                new Player {  Value = 20 },
                new Player { Value = 20 },
                new Player { Value = 100 }
            };




        [Fact]
        public void TestGetSum()
        {
            // arrange
            int expected = 140;

             // mock context
            var mockRepository = new Mock<TDD.Interfaces.IRepository>();

            // stub
            mockRepository.Setup( instance => instance.GetAll()).Returns(_players);

            var footballService = new Services.FootballService(
                mockRepository.Object
                );


            // act 
            int actual = footballService.GetCost();
            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestGetSumFluent()
        {
            // arrange
            int expected = 140;

            // mock context
            var mockRepository = new Mock<TDD.Interfaces.IRepository>();

            // stub
            mockRepository.Setup(instance => instance.GetAll()).Returns(_players);

            var footballService = new Services.FootballService(
                mockRepository.Object
                );


            // act 
            int actual = footballService.GetCost();
            // Assert

            actual.Should().Be(expected);
            
        }

    }
}
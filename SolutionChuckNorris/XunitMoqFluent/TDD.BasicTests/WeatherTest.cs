using Xunit;

namespace TDD.BasicTests
{
    public class WeatherTest
    {
        [Fact]
        public void TestGetTemperature2OK()
        {
            // arrange
            int initialTemperature = 20;
            int year = 2023;
            int expected = 22;
            TDD.Services.WeatherService weatherService = new TDD.Services.WeatherService();
            // act 
            int actual = weatherService.GetTemperature(initialTemperature, year);
            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestGetTemperature46OK()
        {
            // arrange
            int initialTemperature = 20;
            int year = 2034;
            int expected = 46;
            TDD.Services.WeatherService weatherService = new TDD.Services.WeatherService();
            // act 
            int actual = weatherService.GetTemperature(initialTemperature, year);
            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestGetTemperature21OK()
        {
            // arrange
            int initialTemperature = 20;
            int year = 2044;
            int expected = 66;
            TDD.Services.WeatherService weatherService = new TDD.Services.WeatherService();
            // act 
            int actual = weatherService.GetTemperature(initialTemperature, year);
            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(20,2023,22)]
        [InlineData(20, 2034, 46)]
        [InlineData(20, 2044, 66)]

        public void TestGetTemperatureAllOK( int temperature, int newYear , int result)
        {
            // arrange
            int initialTemperature = temperature;
            int year = newYear;
            int expected = result;
            TDD.Services.WeatherService weatherService = new TDD.Services.WeatherService();
            // act 
            int actual = weatherService.GetTemperature(initialTemperature, year);
            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
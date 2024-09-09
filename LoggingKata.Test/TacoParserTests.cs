using System;
using Xunit;

namespace LoggingKata.Test
{
    public class TacoParserTests
    {
        [Fact]
        public void ShouldReturnNonNullObject()
        {
            //Arrange
            var tacoParser = new TacoParser();

            //Act
            var actual = tacoParser.Parse("34.073638, -84.677017, Taco Bell Acwort...");

            //Assert
            Assert.NotNull(actual);

        }

        [Theory]
        [InlineData("34.073638, -84.677017, Taco Bell Acwort...", -84.677017)]
        [InlineData("34.996237,-85.291147,Taco Bell Chattanooga...", -85.291147)]
        [InlineData("34.888408,-85.267909,Taco Bell Chickamaug...", -85.267909)]
        [InlineData("33.796264,-84.224516,Taco Bell Stone Mountain...", -84.224516)]
        [InlineData("34.118399,-87.989494,Taco Bell Hamilto...", -87.989494)]
        public void ShouldParseLongitude(string line, double expected)
        {
            // TODO: Complete the test with Arrange, Act, Assert steps below.
            
            //Arrange
            var tacoParser1 = new TacoParser();

            //Act
            var actual = tacoParser1.Parse(line).Location.Longitude;

            //Assert
            Assert.Equal(expected, actual);
        }


        //TODO: Create a test called ShouldParseLatitude
        
        [Theory]
        [InlineData("34.073638, -84.677017, Taco Bell Acwort...", 34.073638)]
        [InlineData("34.996237,-85.291147,Taco Bell Chattanooga...", 34.996237)]
        [InlineData("34.888408,-85.267909,Taco Bell Chickamaug...", 34.888408)]
        [InlineData("33.796264,-84.224516,Taco Bell Stone Mountain...", 33.796264)]
        [InlineData("34.118399,-87.989494,Taco Bell Hamilto...", 34.118399)]
        public void ShouldParseLatitude(string line, double expected)
        {
            //Arrange
            var tacoParser1 = new TacoParser();

            //Act
            var actual = tacoParser1.Parse(line).Location.Longitude;

            //Assert
            Assert.Equal(expected, actual);
        }

    }
}

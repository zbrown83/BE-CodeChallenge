using Xunit;
using dotnet_code_challenge.DataAccess;

namespace dotnet_code_challenge.Test
{
    public class RaceDaoTest
    {
        private IRaceDao _raceDao = new RaceDao();

        [Fact]
        public void GetJsonRaceDataReturnsRaceObject()
        {
            // Arrange
            string content = @"{
                                ""RawData"": {
                                    ""FixtureName"": ""Doomben"",
                                    ""Markets"": [
                                        {
                                            ""Selections"": [
                                                {
                                                    ""Price"": 10.0,
                                                    ""Tags"": {
                                                        ""participant"": ""1"",
                                                        ""name"": ""Apples""
                                                    }
                                                },
                                                {
                                                    ""Price"": 4.4,
                                                    ""Tags"": {
                                                        ""participant"": ""2"",
                                                        ""name"": ""Banana""
                                                    }
                                                } 
                                            ],
                                            }
                                    ],    
                                    }
                                }";

            // Act
            var race = _raceDao.GetJsonRaceData(content);

            // Assert
            Assert.NotNull(race);
            Assert.Equal("Doomben", race.RaceName);
        }

        [Fact]
        public void GetJsonRaceDataWithEmptyContentReturnsNull()
        {
            // Arrange
            string content = @"";

            // Act
            var race = _raceDao.GetJsonRaceData(content);

            // Assert
            Assert.Null(race);
        }

        [Fact]
        public void GetXmlRaceDataReturnsRaceObject()
        {
            // Arrange
            string content = @"
                <meeting>
                  <races>
                    <race number=""1"" name=""Eagle Farm"">
                      <horses>
                        <horse name=""Jupiter"">
                          <number>1</number>          
                        </horse>
                        <horse name=""Saturn"">
                          <number>2</number>          
                        </horse>
                      </horses>
                      <prices>
                        <price>
                          <horses>
                            <horse number=""1"" Price=""5""/>
                            <horse number=""2"" Price=""10.4""/>
                          </horses>
                        </price>
                      </prices>
                    </race>
                  </races>
                </meeting>";

            // Act
            var races = _raceDao.GetXmlRaceData(content);

            // Assert
            Assert.NotNull(races);
            Assert.Single(races);
            Assert.Equal("Eagle Farm", races[0].RaceName);
        }

        [Fact]
        public void GetXmlRaceDataWithEmptyContentReturnsNull()
        {
            // Arrange
            string content = @"";

            // Act
            var races = _raceDao.GetXmlRaceData(content);

            // Assert
            Assert.Null(races);
        }
    }
}

using Xunit;
using dotnet_code_challenge.Service;

namespace dotnet_code_challenge.Test
{
    public class RaceServiceTest
    {
        private IRaceService _raceService = new RaceService();

        [Fact]
        public void GetRacesReturnsAllRacesFromFeedDataFiles()
        {
            // NOTE: As it currently is, this will be testing the DAO layer as well as the get feed data files
            // If I had more time, I would implement a mocking framework such as MOQ to mock those calls
            // so I can just test this method
            var races = _raceService.GetRaces();

            Assert.Equal(2, races.Count);
        }

        [Fact]
        public void GetFeedDataFilesReturnsCorrectNumberOfFiles()
        {
            var dataFiles = _raceService.GetFeedDataFiles();

            Assert.Equal(2, dataFiles.Length);
        }
    }
}

using System.IO;
using System.Reflection;
using System.Collections.Generic;
using dotnet_code_challenge.DataAccess.Domain;
using dotnet_code_challenge.DataAccess;

namespace dotnet_code_challenge.Service
{
    public class RaceService : IRaceService
    {
        public IRaceDao _raceDao = new RaceDao();

        /// <summary>
        /// Get a list of races with horses and their price
        /// </summary>
        /// <returns>A list of races</returns>
        public List<Race> GetRaces()
        {
            FileInfo[] files = GetFeedDataFiles();

            var races = new List<Race>();

            foreach (var file in files)
            {
                string content = File.ReadAllText(file.FullName);

                switch (file.Extension)
                {
                    case ".json":
                        Race race = _raceDao.GetJsonRaceData(content);

                        if (race != null)
                        {
                            races.Add(race);
                        }
                        
                        break;
                    case ".xml":
                        races.AddRange(_raceDao.GetXmlRaceData(content));
                        break;
                    default:
                        // Ignore unsupported file types
                        break;
                }
            }

            return races;
        }

        /// <summary>
        /// Get a list of files from the feed data directory
        /// </summary>
        /// <returns>A list of feed data files</returns>
        public FileInfo[] GetFeedDataFiles()
        {
            var absolutePath = Path.Combine(Assembly.GetExecutingAssembly().Location, @"..\..\..\..\..\dotnet-code-challenge\FeedData");
            
            DirectoryInfo d = new DirectoryInfo(absolutePath);
            return d.GetFiles();
        }
    }
}

using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;
using Newtonsoft.Json;
using dotnet_code_challenge.DataAccess.Domain;
using dotnet_code_challenge.Tools;

namespace dotnet_code_challenge.DataAccess
{
    public class RaceDao : IRaceDao
    {
        /// <summary>
        /// Get race data from a JSON file
        /// </summary>
        /// <param name="content">The content of the file</param>
        /// <returns>A race domain object</returns>
        public Race GetJsonRaceData(string content)
        {
            if (string.IsNullOrWhiteSpace(content))
            {
                return null;
            }

            RaceJson raceJson = JsonConvert.DeserializeObject<RaceJson>(content);

            return Converter.ConvertRaceJsonToRace(raceJson);
        }

        /// <summary>
        /// Get race data from an XML file
        /// </summary>
        /// <param name="content">The content of the file</param>
        /// <returns>A list of race domain objects</returns>
        public List<Race> GetXmlRaceData(string content)
        {
            if (string.IsNullOrWhiteSpace(content))
            {
                return null;
            }

            var serializer = new XmlSerializer(typeof(RaceXml), new XmlRootAttribute("meeting"));
            var stringReader = new StringReader(content);

            RaceXml raceXml = (RaceXml)serializer.Deserialize(stringReader);

            var races = new List<Race>();

            if (raceXml?.Races?.Race != null)
            {
                foreach (var meetingRace in raceXml.Races.Race)
                {
                    Race race = Converter.ConvertMeetingRaceXmlToRace(meetingRace);

                    if (race != null)
                    {
                        races.Add(race);
                    }                    
                }
            }

            return races;
        }
    }
}

using System.Linq;
using System.Collections.Generic;
using dotnet_code_challenge.DataAccess.Domain;

namespace dotnet_code_challenge.Tools
{
    public static class Converter
    {
        /// <summary>
        /// Convert a RaceJson object to a Race object
        /// </summary>
        /// <param name="raceJson">The object to convert</param>
        /// <returns>The race object</returns>
        public static Race ConvertRaceJsonToRace(RaceJson raceJson)
        {
            var horsesInRace = new List<RaceHorse>();

            if (raceJson?.Fixture?.Markets != null)
            {
                foreach (Market market in raceJson.Fixture.Markets)
                {
                    if (market?.Selections != null)
                    {
                        foreach (Selection selection in market.Selections)
                        {
                            horsesInRace.Add(new RaceHorse
                                {
                                    Name = selection.Horse.Name,
                                    Price = selection.Price
                                });
                        }
                    }
                }
            }

            return new Race
                {
                    RaceName = raceJson.Fixture.FixtureName,
                    Horses = horsesInRace
                };
        }

        /// <summary>
        /// Convert a MeetingRaceXml object to a Race object
        /// </summary>
        /// <param name="meetingRace">The object to convert</param>
        /// <returns>The race object</returns>
        public static Race ConvertMeetingRaceXmlToRace(MeetingRace meetingRace)
        {
            if (meetingRace == null)
            {
                return null;
            }

            var horsesInRace = new List<RaceHorse>();

            if (meetingRace?.Horses?.Horse != null)
            {
                foreach (HorseXml horse in meetingRace.Horses.Horse)
                {
                    horsesInRace.Add(new RaceHorse
                        {
                            Name = horse.Name,
                            Price = meetingRace.Prices.Price.FirstOrDefault()?.Horses.Horse.FirstOrDefault(x => x.Number == horse.Number)?.Price ?? 0
                        });
                }
            }

            return new Race
                {
                    RaceName = meetingRace.Name,
                    Horses = horsesInRace
                };
        }
    }
}

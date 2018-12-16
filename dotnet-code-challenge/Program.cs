using System;
using System.Linq;
using dotnet_code_challenge.Service;

namespace dotnet_code_challenge
{
    public class Program
    {
        public static IRaceService _raceService = new RaceService();

        public static void Main(string[] args)
        {
            var races = _raceService.GetRaces();

            foreach (var race in races)
            {
                Console.WriteLine($"Meeting: {race.RaceName}");

                foreach (var raceHorse in race.Horses.OrderBy(x => x.Price)) 
                {
                    Console.WriteLine($"{raceHorse.Name} - {raceHorse.Price}");
                }

                Console.WriteLine("\n\n"); // Space out display of races
            }

            Console.ReadKey();
        }
    }
}

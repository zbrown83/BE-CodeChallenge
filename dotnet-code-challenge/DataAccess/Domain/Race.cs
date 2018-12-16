using System.Collections.Generic;

namespace dotnet_code_challenge.DataAccess.Domain
{
    public class Race
    {
        public string RaceName { get; set; }

        public List<RaceHorse> Horses { get; set; }        
    }
}

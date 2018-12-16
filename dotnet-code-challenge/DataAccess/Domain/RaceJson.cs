using Newtonsoft.Json;
using System.Collections.Generic;

namespace dotnet_code_challenge.DataAccess.Domain
{
    public class RaceJson
    {
        [JsonProperty(PropertyName = "RawData")]
        public Fixture Fixture { get; set; }
    }

    public class Fixture
    {
        public string FixtureName { get; set; }

        public List<Market> Markets { get; set; }
    }

    public class Market
    {
        public List<Selection> Selections{ get; set; }
    }

    public class Selection
    {
        public decimal Price { get; set; }

        [JsonProperty(PropertyName = "Tags")]
        public HorseJson Horse{ get; set; }
    }

    public class HorseJson
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
    }
}

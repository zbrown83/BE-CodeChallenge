using System.Collections.Generic;
using System.Xml.Serialization;

namespace dotnet_code_challenge.DataAccess.Domain
{
    [XmlRoot("meeting")]
    public class RaceXml
    {
        [XmlElement("races")]
        public MeetingRaces Races { get; set; }
    }

    public class MeetingRaces
    {
        [XmlElement("race")]
        public List<MeetingRace> Race { get; set; }
    }
    
    public class MeetingRace
    {
        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlElement("horses")]
        public HorsesXml Horses { get; set; }

        [XmlElement("prices")]
        public PricesXml Prices { get; set; }
    }

    public class HorsesXml
    {
        [XmlElement("horse")]
        public List<HorseXml> Horse { get; set; }
    }

    public class HorseXml
    {
        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlElement("number")]
        public int Number { get; set; }
    }

    public class PricesXml
    {
        [XmlElement("price")]
        public List<PriceXml> Price { get; set; }
    }

    public class PriceXml
    {
        [XmlElement("horses")]
        public PriceHorses Horses { get; set; }
    }

    public class PriceHorses
    {
        [XmlElement("horse")]
        public List<PriceHorse> Horse { get; set; }
    }

    public class PriceHorse
    {
        [XmlAttribute]
        public decimal Price { get; set; }

        [XmlAttribute("number")]
        public int Number { get; set; }
    }
}

using System.Collections.Generic;
using dotnet_code_challenge.DataAccess.Domain;

namespace dotnet_code_challenge.DataAccess
{
    public interface IRaceDao
    {
        Race GetJsonRaceData(string content);

        List<Race> GetXmlRaceData(string content);
    }
}

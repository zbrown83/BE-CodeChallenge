using System.IO;
using System.Collections.Generic;
using dotnet_code_challenge.DataAccess.Domain;

namespace dotnet_code_challenge.Service
{
    public interface IRaceService
    {
        List<Race> GetRaces();

        FileInfo[] GetFeedDataFiles();
    }
}

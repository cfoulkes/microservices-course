using System.Collections.Generic;
using CommandsService.Data.Models;

namespace CommandsService.SyncDataServices.Grpc
{
    public interface IPlatformDataClient
    {
        IEnumerable<Platform> ReturnAllPlatforms();
    }
}

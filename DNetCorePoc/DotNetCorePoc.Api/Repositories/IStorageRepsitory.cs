using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace DotNetCorePoc.Api.Repositories
{
    public interface IStorageRepsitory
    {
        void Configure(string location);
        Task<bool> copy(string currentLocation);
    }
}

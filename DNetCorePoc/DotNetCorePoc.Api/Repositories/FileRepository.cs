using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using DotNetCorePoc.Api.Helpers;

namespace DotNetCorePoc.Api.Repositories
{
    public sealed class FileRepository : IStorageRepsitory
    {
        private string _baseLocation;

        public void Configure(string location)
        {
            _baseLocation = location;

        }

        public async Task<bool> copy(string currentLocation)
        {
            string fileName = FileHelper.GetFileName(currentLocation);
            return true;
        }
    }
}

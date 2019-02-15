using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DotNetPoc.Services.Host.Contracts
{
    [Serializable]
    [DataContract]
    public enum StatusCodes
    {
        [EnumMember]
        Sucess = 1,
        [EnumMember]
        Error,
        [EnumMember]
        BadRequest
    }
}

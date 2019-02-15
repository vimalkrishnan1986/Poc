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
    public class FaultModel
    {
        [DataMember]
        public Exception Exception { get; set; }

        [DataMember]
        public string Message { get; set; }

    }
}

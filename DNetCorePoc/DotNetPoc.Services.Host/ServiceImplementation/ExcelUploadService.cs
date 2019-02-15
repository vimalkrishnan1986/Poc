using DotNetPoc.Services.Host.Contracts;
using DotNetPoc.Services.Host.ServiceContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace DotNetPoc.Services.Host.ServiceImplementation
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple, InstanceContextMode = InstanceContextMode.PerSession)]
    public sealed class ExcelUploadService : IExcelUploadServicecs
    {
        public ExcelUploadResponseModel Upload(ExcelUploadModel model)
        {
            return null;
        }
    }
}

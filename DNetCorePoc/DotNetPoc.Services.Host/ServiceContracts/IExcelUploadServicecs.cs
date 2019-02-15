using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using DotNetPoc.Services.Host.Contracts;

namespace DotNetPoc.Services.Host.ServiceContracts
{
    [ServiceContract]
    public interface IExcelUploadServicecs
    {
        [OperationContract(Name = "Upload")]
        [FaultContract(typeof(FaultModel))]
        ExcelUploadResponseModel Upload(ExcelUploadModel model);
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DotNetCorePoc.Api.Models;

namespace DotNetCorePoc.Api.BusinessServices
{
    public interface IUploadBusinessService
    {
        Task<ExcelResponseModel> Upload(ExcelUploadModel model);
    }
}

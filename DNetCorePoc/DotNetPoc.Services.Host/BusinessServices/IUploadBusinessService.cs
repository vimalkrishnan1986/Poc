using DotNetPoc.Services.Host.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace DotNetPoc.Services.Host.BusinessServices
{
    public interface IUploadBusinessService
    {
        Task<ExcelUploadResponseModel> Upload(ExcelUploadModel model);
    }
}

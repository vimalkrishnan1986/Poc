using DotNetPoc.Services.Host.Contracts;
using DotNetPoc.Services.Host.ServiceContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using DotNetPoc.Services.Host.BusinessServices;
using DotNetPoc.Services.Host.Repositories;
using DotNetPoc.Services.Host.ExcelReader;
using DotNetPoc.Services.Host.Helpers;

namespace DotNetPoc.Services.Host.ServiceImplementation
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple, InstanceContextMode = InstanceContextMode.PerSession)]
    public sealed class ExcelUploadService : IExcelUploadServicecs
    {
        private readonly IUploadBusinessService _businessService;
        private readonly IExcelReader _excelReader;
        private readonly IStorageRepsitory _storageRepository;
        const string _baseLocationKey = "storageLocation";

        public ExcelUploadService()
        {
            _excelReader = Activator.CreateInstance<OleDbExcelReader>();
            _storageRepository = Activator.CreateInstance<FileRepository>();
            _storageRepository.Configure(ConfigHelper.GetAppSettingValue<string>(_baseLocationKey));
            _businessService = new UploadBusinessService(_storageRepository, _excelReader);
        }

        public async Task<ExcelUploadResponseModel> Upload(ExcelUploadModel model)
        {
            try
            {
                return await _businessService.Upload(model);
            }
            catch (Exception ex)
            {
                throw new FaultException<FaultModel>(new FaultModel
                { Exception = ex.InnerException, Message = ex.Message });
            }
        }
    }
}

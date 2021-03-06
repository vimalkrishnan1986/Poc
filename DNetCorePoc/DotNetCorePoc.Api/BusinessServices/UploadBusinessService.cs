﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DotNetCorePoc.Api.Models;
using DotNetCorePoc.Api.Repositories;
using System.Reflection;
using DotNetCorePoc.Api.Helpers;
using DotNetCorePoc.Api.ExcelReader;
using System.Data;
using System.Net;

namespace DotNetCorePoc.Api.BusinessServices
{
    public class UploadBusinessService : IUploadBusinessService
    {
        private readonly IStorageRepsitory _storageRepsitory;
        private readonly IExcelReader _excelReader;
        const string app_data = "App_Data";

        private string GetTemperotyFileName(string fileName)
        {
            string extension1 = ".xls";
            string extension2 = ".xlsx";

            if (!fileName.EndsWith(extension1) && !fileName.EndsWith(extension2))
            {
                fileName = $"{fileName}{extension2}";
            }
            return $"{FileHelper.CurrentDirrectory(Assembly.GetExecutingAssembly().CodeBase)}//{app_data}//{fileName}";

        }

        public UploadBusinessService(IStorageRepsitory storageRepsitory, IExcelReader excelReader)
        {
            _storageRepsitory = storageRepsitory ?? throw new ArgumentNullException(nameof(storageRepsitory));
            _excelReader = excelReader ?? throw new ArgumentNullException(nameof(excelReader));

        }

        public async Task<ExcelResponseModel> Upload(ExcelUploadModel model)
        {
            string tempFileName = GetTemperotyFileName(model.Name);
            //saving to temprory file;
            FileHelper.WriteToFile(model.Content, tempFileName);
            //performing the validation
            var validationResults = await GetValidationResults(tempFileName);
            if (validationResults.HttpStatusCode != HttpStatusCode.Accepted)
            {
                return validationResults;
            }
            await _storageRepsitory.copy(tempFileName);

            return new ExcelResponseModel(null);
        }

        private async Task<ExcelResponseModel> GetValidationResults(string fileName)
        {
            var data = await _excelReader.ReadFromExcel(fileName);

            List<ErrorMessageModel> errorMessageModels = new List<ErrorMessageModel>();

            if (data == null)
            {
                throw new InvalidOperationException();
            }

            // performing the validation here

            if (data.Rows.Count == 0)
            {
                throw new IndexOutOfRangeException();
            }

            int row = 0;

            foreach (DataRow dataRow in data.Rows)
            {
                var errorMessageModel = new ErrorMessageModel(row);

                if (dataRow[0].ToString() == "vimal")
                {
                    errorMessageModel.ErrorMessagees.Add("Colum [0] can't have value vimal");
                }
                errorMessageModels.Add(errorMessageModel);
                row++;
                /// contine with other checks over here;
            }
            return new ExcelResponseModel(errorMessageModels);
        }
    }
}

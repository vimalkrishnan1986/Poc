using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;

namespace DotNetCorePoc.Api.ExcelReader
{
    public sealed class OleDbExcelReader : IExcelReader
    {
        private string _filePath
        {
            get; set;
        }
        private string _connectionString
        {
            get
            {
                return $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source='" + _filePath +
                    "';Extended Properties=\"Excel 12.0;HDR=YES;\"";

            }
        }
        public async Task<DataTable> ReadFromExcel(string fullFileName)
        {
            _filePath = fullFileName;
            return await Task.FromResult(new DataTable());
        }
    }
}

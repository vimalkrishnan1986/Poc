using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;

namespace DotNetPoc.Services.Host.ExcelReader
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
            try
            {
                using (OleDbConnection connection = new OleDbConnection(_connectionString))
                {
                    string query = "Select * from [Sheet1$]";
                    using (OleDbDataAdapter ada = new OleDbDataAdapter(query, connection))
                    {
                        DataTable dt = new DataTable();
                        ada.Fill(dt);
                        return await Task.FromResult(dt).ConfigureAwait(false);
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}

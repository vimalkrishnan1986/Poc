﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Threading.Tasks;

namespace DotNetPoc.Services.Host.ExcelReader
{
    public interface IExcelReader
    {
        Task<DataTable> ReadFromExcel(string fullFileName);

    }
}

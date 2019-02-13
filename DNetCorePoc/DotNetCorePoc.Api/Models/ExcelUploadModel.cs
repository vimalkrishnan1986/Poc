using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetCorePoc.Api.Models
{
    public class ExcelUploadModel
    {
        public string Name { get; set; }
        public byte[] Content { get; set; }
    }
}

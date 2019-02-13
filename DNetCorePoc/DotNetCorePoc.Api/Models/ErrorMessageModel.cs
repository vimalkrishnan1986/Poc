using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetCorePoc.Api.Models
{
    public class ErrorMessageModel
    {
        public int Row { get; private set; }
        public List<string> ErrorMessagees { get; set; }

        public ErrorMessageModel(int row)
        {
            Row = row;
            ErrorMessagees = new List<string>();
        }

    }
}

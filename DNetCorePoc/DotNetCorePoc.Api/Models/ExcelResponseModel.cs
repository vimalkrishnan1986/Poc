using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace DotNetCorePoc.Api.Models
{
    public class ExcelResponseModel
    {
        public HttpStatusCode HttpStatusCode { get; private set; }
        public List<ErrorMessageModel> ErrorMessages { get; private set; }

        public ExcelResponseModel(List<ErrorMessageModel> errorModels)
        {
            Initilize(errorModels);
        }

        private void Initilize(List<ErrorMessageModel> errorModels)
        {
            if (errorModels == null)
            {
                this.HttpStatusCode = HttpStatusCode.Accepted;
                return;
            }
            if (errorModels.Count == 0)
            {
                this.HttpStatusCode = HttpStatusCode.Accepted;
                return;
            }
            ErrorMessages = errorModels;
            HttpStatusCode = HttpStatusCode.BadRequest;
        }
    }
}

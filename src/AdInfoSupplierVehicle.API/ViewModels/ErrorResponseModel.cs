using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdInfoSupplierVehicle.API.ViewModels
{
    public class ErrorResponseModel
    {
        public ErrorResponseModel()
        {
            TraceId = Guid.NewGuid().ToString();
            Errors = new List<ErrorDetailsModel>();
        }

        public ErrorResponseModel(string logref, string message)
        {
            TraceId = Guid.NewGuid().ToString();
            Errors = new List<ErrorDetailsModel>();
            AddError(logref, message);
        }

        public string TraceId { get; private set; }
        public List<ErrorDetailsModel> Errors { get; private set; }

        public class ErrorDetailsModel
        {
            public ErrorDetailsModel(string logref, string message)
            {
                Logref = logref;
                Message = message;
            }

            public string Logref { get; private set; }

            public string Message { get; private set; }
        }

        public void AddError(string logref, string message)
        {
            Errors.Add(new ErrorDetailsModel(logref, message));
        }
    }
}

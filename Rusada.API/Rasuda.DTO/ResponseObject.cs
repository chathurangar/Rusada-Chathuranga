using System;
using System.Collections.Generic;
using System.Text;

namespace Rasuda.DTO
{
    public class ResponseObject
    {
        public bool isSuccess { get; set; }
        public string errorMessage { get; set; }
        public object result { get; set; }
        public bool isValidationError { get; set; }
    }
}

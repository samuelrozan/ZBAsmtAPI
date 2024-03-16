using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZBAsmtAPI.Models
{
    //Base Respones Model
    public class BaseResponse
    {
        public string Status { get; set; }

        public string Message { get; set; }
    }
}
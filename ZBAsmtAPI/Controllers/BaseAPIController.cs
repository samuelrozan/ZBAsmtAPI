using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using ZBAsmtAPI.Models;

namespace ZBAsmtAPI.Controllers
{
    public class BaseAPIController : ApiController
    {
        //Response variable message updated for data availability for data
        protected void SetResponseMessage<T>(EmployeesResponse<T> objResponse)
        {
            if (objResponse.EmployeesList != null)
            {
                if (objResponse.EmployeesList.Count > 0)
                {
                    objResponse.Status = "TRUE";
                    objResponse.Message = "Success";
                }
                else
                {
                    objResponse.Status = "TRUE";
                    objResponse.Message = "Record not found";
                }
            }
            else
            {
                objResponse.Status = "FALSE";
                objResponse.Message = "Something went wrong";
            }
            
        }

    }
}

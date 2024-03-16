using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ZBAsmtAPI.Models
{
    //Employee ||||||||||Moel |Class
    public class Employees
    {
        [Display(Name = "id")]
        public int id { get; set; }

        [Display(Name = "FirstName")]
        public string FirstName { get; set; }

        [Display(Name = "MiddleName")]
        public string MiddleName { get; set; }

        [Display(Name = "LastName")]
        public string LastName { get; set; }
    }
    //Base response with |List
    public class EmployeesResponse<T> : BaseResponse
    {
        public List<T> EmployeesList { get; set; }
    }
    //Base \response with single record
    public class EmployeeResponse : BaseResponse
    {
        public Employees Employee { get; set; }
    }
}
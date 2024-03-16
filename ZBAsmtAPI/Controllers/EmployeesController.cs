
using Microsoft.VisualStudio.Services.DelegatedAuthorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using ZBAsmtAPI.BusinessLayer;
using ZBAsmtAPI.Models;
using HttpGetAttribute = System.Web.Http.HttpGetAttribute;
using System.Reflection;
using System.Web.Http;

namespace ZBAsmtAPI.Controllers
{

    //Employees Controller
    [RoutePrefix("api/Employees")]
    public class EmployeesController : BaseAPIController
    {
        //Repository Pivate Variable
        private IEmployeesRepository employeeRepository;

        public EmployeesController()
        {
            //Initialize Employees \Repository in Constructor
            employeeRepository = new EmployeesRepository(new EmployeesContext());
        }
        // GET api/Employees
        public IHttpActionResult Get()
        {
           
            //Response variable initialized
            EmployeesResponse<Employees> employeeList = new EmployeesResponse<Employees>();
            try
            {
                //Response variable filled from repository
                employeeList = employeeRepository.GetEmployees();
                //Response variable message updated for data availability for data
                SetResponseMessage<Employees>(employeeList);
            }
            catch (Exception ex)
            {
                //Response variable updated for error occurance
                employeeList.Status = "FALSE";
                employeeList.Message = ex.Message;
            }

            return Ok(employeeList);
        }


        // GET api/Employees/5
        public IHttpActionResult Get(int id)
        {
            EmployeeResponse objEmployee = null;
            try
            {
                objEmployee = employeeRepository.GetEmployee(id);
                
            }
            catch (Exception ex)
            {
                //Response variable updated for error occurance
                objEmployee.Status = "FALSE";
                objEmployee.Message = ex.Message;
            }


            return Ok(objEmployee);
        }

        // Post api/Employees  {from body with JSON media type}
        public IHttpActionResult Post([FromBody]Employees emp)
        {
            BaseResponse result = new BaseResponse();
            try
            {
                result = employeeRepository.CreateEmployee(emp);
                
            }
            catch (Exception ex)
            {
                //Response variable updated for error occurance
                result.Status = "FALSE";
                result.Message = ex.Message;
            }
           
            return Ok(result);
        }
        // PUT api/Employees/5
        public IHttpActionResult Put(int id, [FromBody]Employees emp)
        {
            BaseResponse result = new BaseResponse();
            try
            {
                result = employeeRepository.UpdateEmployee(id,emp);

            }
            catch (Exception ex)
            {
                //Response variable updated for error occurance
                result.Status = "FALSE";
                result.Message = ex.Message;
            }

            return Ok(result);
        }

        // DELETE api/Employees/5
        public IHttpActionResult Delete(int id)
        {
            BaseResponse result = new BaseResponse();
            try
            {
                result = employeeRepository.DeleteEmployee(id);

            }
            catch (Exception ex)
            {
                //Response variable updated for error occurance
                result.Status = "FALSE";
                result.Message = ex.Message;
            }

            return Ok(result);
        }
    }
    
}

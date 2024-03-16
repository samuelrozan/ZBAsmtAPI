using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZBAsmtAPI.Models;

namespace ZBAsmtAPI.BusinessLayer
{
    //Employees Repository Interface
    interface IEmployeesRepository
    {
        //Get Employees List
        EmployeesResponse<Employees> GetEmployees();

        //Get Employee by ID
        EmployeeResponse GetEmployee(int id);

        //Create Employee
        BaseResponse CreateEmployee(Employees emp);

        //Update Employee
        BaseResponse UpdateEmployee(int id,Employees emp);

        //Delete Employee
        BaseResponse DeleteEmployee(int id);
    }
}

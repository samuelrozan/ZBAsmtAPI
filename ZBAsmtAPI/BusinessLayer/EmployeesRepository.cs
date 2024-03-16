using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZBAsmtAPI.Models;

namespace ZBAsmtAPI.BusinessLayer
{
    public class EmployeesRepository : IEmployeesRepository, IDisposable
    {
        private EmployeesContext employeesContext=null;

        //Initialize Context for Employees repository
        public EmployeesRepository(EmployeesContext empContext)
        {
            this.employeesContext = empContext;
            
        }

        //Implementation for Get  employees list
        public EmployeesResponse<Employees> GetEmployees()
        {
            return this.employeesContext.GetEmployees();
        }
        //Implementation for GetEmployee  y id
        public  EmployeeResponse GetEmployee(int id)
        {
            return this.employeesContext.GetEmployee(id);
        }

        //Implementation for Create Employee
        public BaseResponse CreateEmployee(Employees emp)
        {
            return this.employeesContext.CreateEmployee(emp);
        }

        //Implementation for Update Employee
        public BaseResponse UpdateEmployee(int id,Employees emp)
        {
            return this.employeesContext.UpdateEmployee(id,emp);
        }

        //Implementation for Delete Employee
        public BaseResponse DeleteEmployee(int id)
        {
            return this.employeesContext.DeleteEmployee(id);
        }
        //manditory for interface
        public void Dispose()
        {
            throw new NotImplementedException();
        }
        
    }
}
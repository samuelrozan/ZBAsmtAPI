using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZBAsmtAPI.Models;

namespace ZBAsmtAPI.DataContext
{
    interface IDataContext : IDisposable
    {
        //GetEmployeesList Method
        DataTable GetEmployeesList();

        //GwtEmployee by id
        DataTable GetEmployee(int id);
       
        //Create Employee
        DataTable CreateEmployee(Employees emp);

        //Update Employee
        DataTable UpdateEmployee(int id,Employees emp);

        //Delete Employee
        DataTable DeleteEmployee(int id);
    }
}

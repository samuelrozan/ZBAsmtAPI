using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Http;
using ZBAsmtAPI.DataContext;
using ZBAsmtAPI.Models;
using ZBAsmtAPI.Utility;

namespace ZBAsmtAPI.BusinessLayer
{
    //
    public class EmployeesContext
    {
        private DataTable dt = null;
        private IDataContext dbContext;

        //Get Employees List
        public EmployeesResponse<Employees> GetEmployees()
        {
            EmployeesResponse<Employees> _LoadListResponse = new EmployeesResponse<Employees>();

            _LoadListResponse.Status = "FALSE";
            _LoadListResponse.Message = "SOMETHING WENT WRONG";
            try
            {
                //Get data from MySQL
                //dbContext = new DBContextMySQL();


                //Get data from MSSQL
                dbContext = new DBContextMSSQL();

                dt = dbContext.GetEmployeesList();
                
             
                //Convert Datatable to ModelClass List
                List<Employees> objEmployeesList = SQLUtilities.ConvertToList<Employees>(dt);
               
                //Check for Data Retrival status
                if (objEmployeesList != null)
                {
                    _LoadListResponse.EmployeesList = objEmployeesList;
                    _LoadListResponse.Status = "TRUE";
                    _LoadListResponse.Message = "Data Retrived Successfully";
                }
                else
                {
                    _LoadListResponse.Status = "FALSE";
                    _LoadListResponse.Message = "Data Retrival Failed";
                }
                

            }
            catch (Exception e)
            {

                _LoadListResponse.Status = "ERROR";
                _LoadListResponse.Message = e.Message;
                
            }
            return _LoadListResponse;
        }

        //Get Employee by id
        public EmployeeResponse GetEmployee(int id)
        {
            EmployeeResponse _employeeResponse = new EmployeeResponse();

            _employeeResponse.Status = "FALSE";
            _employeeResponse.Message = "SOMETHING WENT WRONG";
            try
            {
                //Get data from MySQL
                //dbContext = new DBContextMySQL();


                //Get data from MSSQL
                dbContext = new DBContextMSSQL();

                dt = dbContext.GetEmployee(id);


                //Convert Datatable to ModelClass List
                List<Employees> objEmployee = SQLUtilities.ConvertToList<Employees>(dt);

                //Check for Data Retrival status
                if (objEmployee != null)
                {
                    _employeeResponse.Employee = objEmployee.FirstOrDefault();
                    _employeeResponse.Status = "TRUE";
                    _employeeResponse.Message = "Data Retrived Successfully";
                }
                else
                {
                    _employeeResponse.Status = "FALSE";
                    _employeeResponse.Message = "Data Retrival Failed";
                }


            }
            catch (Exception e)
            {

                _employeeResponse.Status = "ERROR";
                _employeeResponse.Message = e.Message;

            }
            return _employeeResponse;
        }

        //Create Employee
        public BaseResponse CreateEmployee(Employees emp)
        {
            BaseResponse _baseResponse = new BaseResponse();

            _baseResponse.Status = "FALSE";
            _baseResponse.Message = "SOMETHING WENT WRONG";
            try
            {
                //Get data from MySQL
                //dbContext = new DBContextMySQL();


                //Get data from MSSQL
                dbContext = new DBContextMSSQL();

                dt = dbContext.CreateEmployee(emp);


                //Convert Datatable to ModelClass List
                List<Employees> objEmployee = SQLUtilities.ConvertToList<Employees>(dt);

                //Check for Data Retrival status
                if (objEmployee != null)
                {
                    _baseResponse.Status = "TRUE";
                    _baseResponse.Message = "Data Inserted Successfully";
                }
                else
                {
                    _baseResponse.Status = "FALSE";
                    _baseResponse.Message = "Data insertion failed";
                }


            }
            catch (Exception e)
            {

                _baseResponse.Status = "ERROR";
                _baseResponse.Message = e.Message;

            }
            return _baseResponse;
        }

        //Update Employee
        public BaseResponse UpdateEmployee(int id,Employees emp)
        {
            BaseResponse _baseResponse = new BaseResponse();

            _baseResponse.Status = "FALSE";
            _baseResponse.Message = "SOMETHING WENT WRONG";
            try
            {
                //Get data from MySQL
                //dbContext = new DBContextMySQL();


                //Get data from MSSQL
                dbContext = new DBContextMSSQL();

                dt = dbContext.UpdateEmployee(id,emp);


                //Convert Datatable to ModelClass List
                List<Employees> objEmployee = SQLUtilities.ConvertToList<Employees>(dt);

                //Check for Data Retrival status
                if (objEmployee != null)
                {
                    _baseResponse.Status = "TRUE";
                    _baseResponse.Message = "Data Updated Successfully";
                }
                else
                {
                    _baseResponse.Status = "FALSE";
                    _baseResponse.Message = "Data Updation failed";
                }


            }
            catch (Exception e)
            {

                _baseResponse.Status = "ERROR";
                _baseResponse.Message = e.Message;

            }
            return _baseResponse;
        }

        //Delete Employee
        public BaseResponse DeleteEmployee(int id)
        {
            BaseResponse _baseResponse = new BaseResponse();

            _baseResponse.Status = "FALSE";
            _baseResponse.Message = "SOMETHING WENT WRONG";
            try
            {
                //Get data from MySQL
                //dbContext = new DBContextMySQL();


                //Get data from MSSQL
                dbContext = new DBContextMSSQL();

                dt = dbContext.DeleteEmployee(id);


                //Convert Datatable to ModelClass List
                List<Employees> objEmployee = SQLUtilities.ConvertToList<Employees>(dt);

                //Check for Data Retrival status
                if (objEmployee != null)
                {
                    _baseResponse.Status = "TRUE";
                    _baseResponse.Message = "Data Deleted Successfully";
                }
                else
                {
                    _baseResponse.Status = "FALSE";
                    _baseResponse.Message = "Data Deletion failed";
                }


            }
            catch (Exception e)
            {

                _baseResponse.Status = "ERROR";
                _baseResponse.Message = e.Message;

            }
            return _baseResponse;
        }
    }
}
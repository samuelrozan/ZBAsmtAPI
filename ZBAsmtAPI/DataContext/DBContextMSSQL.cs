using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using ZBAsmtAPI.Models;
using ZBAsmtAPI.Utility;

namespace ZBAsmtAPI.DataContext
{
    //DBContext for MSSQL
    public class DBContextMSSQL : IDataContext
    {
        public static string mLastError = "";

        //Implementation for GetEmployeesList
        public DataTable GetEmployeesList()
        {
            //Initialize command context
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "Asmt_GetEmployees";
           
            //Prepare Datatable
            DataTable dt = new DataTable();
            try
            {
                //Preparing and fetching data
                command.Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["AuthContext"].ConnectionString);
                using (SqlDataAdapter da = new SqlDataAdapter(command))
                {
                    da.Fill(dt);
                }
                command.Dispose();
            }
            catch (Exception ex)
            {
                mLastError = ex.Message;
                throw (new ArgumentOutOfRangeException(mLastError));
            }
            return dt;
        }

        public DataTable GetEmployee(int id)
        {
            Employees objEmployees = new Employees();

            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "Asmt_GetEmployee";

            //Prepare Datatable
            DataTable dt = new DataTable();
            try
            {
                //Preparing and fetching data
                command.Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["AuthContext"].ConnectionString);
                SQLUtilities.AddParamToSQLCmd(command, "@id", DbType.Int32, 10, ParameterDirection.Input,id);

                using (SqlDataAdapter da = new SqlDataAdapter(command))
                {
                    da.Fill(dt);
                }
                command.Dispose();
            }
            catch (Exception ex)
            {
                mLastError = ex.Message;
                throw (new ArgumentOutOfRangeException(mLastError));
            }

            return dt;

        }

        public DataTable CreateEmployee(Employees emp)
        {

            
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "Asmt_CreateEmployee";

            //Prepare Datatable
            DataTable dt = new DataTable();
            try
            {
                //Preparing and fetching data
                command.Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["AuthContext"].ConnectionString);
                SQLUtilities.AddParamToSQLCmd(command, "@FirstName", DbType.String, 50, ParameterDirection.Input, emp.FirstName);
                SQLUtilities.AddParamToSQLCmd(command, "@MiddleName", DbType.String, 50, ParameterDirection.Input, emp.MiddleName);
                SQLUtilities.AddParamToSQLCmd(command, "@LastName", DbType.String, 50, ParameterDirection.Input, emp.LastName);
                using (SqlDataAdapter da = new SqlDataAdapter(command))
                {
                    da.Fill(dt);
                }
                command.Dispose();
               
            }
            catch (Exception ex)
            {
                mLastError = ex.Message;
                throw (new ArgumentOutOfRangeException(mLastError));
            }

            return dt;

        }

        public DataTable UpdateEmployee(int id,Employees emp)
        {


            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "Asmt_UpdateEmployee";

            //Prepare Datatable
            DataTable dt = new DataTable();
            try
            {
                //Preparing and fetching data
                command.Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["AuthContext"].ConnectionString);
                SQLUtilities.AddParamToSQLCmd(command, "@id", DbType.Int32, 50, ParameterDirection.Input, id);
                SQLUtilities.AddParamToSQLCmd(command, "@FirstName", DbType.String, 50, ParameterDirection.Input, emp.FirstName);
                SQLUtilities.AddParamToSQLCmd(command, "@MiddleName", DbType.String, 50, ParameterDirection.Input, emp.MiddleName);
                SQLUtilities.AddParamToSQLCmd(command, "@LastName", DbType.String, 50, ParameterDirection.Input, emp.LastName);
                using (SqlDataAdapter da = new SqlDataAdapter(command))
                {
                    da.Fill(dt);
                }
                command.Dispose();

            }
            catch (Exception ex)
            {
                mLastError = ex.Message;
                throw (new ArgumentOutOfRangeException(mLastError));
            }

            return dt;

        }
        
        public DataTable DeleteEmployee(int id)
        {


            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "Asmt_DeleteEmployee";

            //Prepare Datatable
            DataTable dt = new DataTable();
            try
            {
                //Preparing and fetching data
                command.Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["AuthContext"].ConnectionString);
                SQLUtilities.AddParamToSQLCmd(command, "@id", DbType.Int32, 50, ParameterDirection.Input, id);
                
                using (SqlDataAdapter da = new SqlDataAdapter(command))
                {
                    da.Fill(dt);
                }
                command.Dispose();

            }
            catch (Exception ex)
            {
                mLastError = ex.Message;
                throw (new ArgumentOutOfRangeException(mLastError));
            }

            return dt;

        }
        public void Dispose()
        {

        }
    }
}
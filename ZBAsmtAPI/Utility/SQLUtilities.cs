using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Reflection;
using System.Web;

namespace ZBAsmtAPI.Utility
{
    public class SQLUtilities
    {

        //Method to pass data to store procedure
         public static void AddParamToSQLCmd(DbCommand dbCmd, string paramId, DbType dbType, int paramSize, ParameterDirection paramDirection, object paramValue)
        {
            // Validate Parameter Properties
            if (dbCmd == null)
                throw (new ArgumentNullException("dbCmd"));
            if (paramId == string.Empty)
                throw (new ArgumentOutOfRangeException("paramId"));

            // Add Parameter
            DbParameter newSqlParam = dbCmd.CreateParameter();
            newSqlParam.ParameterName = paramId;
            newSqlParam.DbType = dbType;
            newSqlParam.Direction = paramDirection;
            if (paramSize > 0)
                newSqlParam.Size = paramSize;

            if (paramValue != null)
                newSqlParam.Value = paramValue;

            dbCmd.Parameters.Add(newSqlParam);

        }

        //generic class to convert dat from Datatable to given class tyope list
         public static List<T> ConvertToList<T>(DataTable dt)
         {
             var columnNames = dt.Columns.Cast<DataColumn>().Select(c => c.ColumnName.ToLower()).ToList();
             var properties = typeof(T).GetProperties();
             return dt.AsEnumerable().Select(row =>
             {
                 var objT = Activator.CreateInstance<T>();
                 foreach (var pro in properties)
                 {
                     if (columnNames.Contains(pro.Name.ToLower()))
                     {
                         try
                         {
                             if (pro.PropertyType.Name.ToLower().Contains("string"))
                             {
                                 pro.SetValue(objT, row[pro.Name].ToString().Trim());
                             }
                             else
                             {
                                 pro.SetValue(objT, row[pro.Name]);
                             }

                         }
                         catch
                         {
                             //string str = ex.Message;
                             //throw;
                         }
                     }
                 }
                 return objT;
             }).ToList();
         }
    }
}
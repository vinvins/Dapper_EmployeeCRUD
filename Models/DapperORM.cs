using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace EmployeeTest.Models
{
    public static class DapperORM
    {
        public static string ConnectionString = "Data source=.;Initial catalog=EmployeeTest;Integrated security=True;";

        public static IEnumerable<T> ReturnList<T>(string StoredProcedure, DynamicParameters param=null)
        {
            using(SqlConnection con=new SqlConnection(ConnectionString))
            {
                return con.Query<T>(StoredProcedure, param, commandType: CommandType.StoredProcedure);
            }
        }

        public static void ReturnNothing(string StoredProcedure, DynamicParameters param = null)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Execute(StoredProcedure, param, commandType: CommandType.StoredProcedure);
            }
        }

        public static T ReturnSingleRow<T>(string StoredProcedure, DynamicParameters param = null)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                return (T) con.QuerySingle<T>(StoredProcedure, param, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
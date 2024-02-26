using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CatalystCMS.DAL
{
    public class UserDetailsRepo : IUserDetailsRepo
    {
        string _connectionString;
        public UserDetailsRepo(string connectionString)
        {
            _connectionString = connectionString;
        }

        public bool ValidateUser(string Username, string Password)
        {
            var procedure = "sp_ValidateTheUserDetails";
            var parameters = new DynamicParameters();
            parameters.Add("@UserName", Username, DbType.String, ParameterDirection.Input);
            parameters.Add("@Password", Password, DbType.String, ParameterDirection.Input);
            parameters.Add("@Result", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
            using (IDbConnection conn = new SqlConnection(_connectionString))
            {
                conn.Execute(procedure, parameters, commandType: CommandType.StoredProcedure);
            }
            var result = parameters.Get<int>("@Result");
            return result == 1 ? true : false;
        }
    }
}

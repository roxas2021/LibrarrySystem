using LibrarrySystem.Models;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;
using Dapper;
using LibrarrySystem.DAL;

namespace LibrarrySystem.ServicesController
{
    public class AccountVerify
    {
        DbContext conn = new DbContext();

        public UserInfo VerifyAccount(string id, string pass)
        {
            UserInfo userdata;

            DynamicParameters param = new DynamicParameters();
            param.Add("@userid", id);
            param.Add("userpass", pass);

            string query = "Select * From T_UserMaster Where Umt_UserID = @userid AND Umt_Password = @userpass";

            using (IDbConnection db = new SqlConnection(conn.ConString("LibrarryDB")))
            {
                userdata = db.Query<UserInfo>(query, param, commandType: CommandType.Text).FirstOrDefault();
            }

            return userdata;
        }
    }
}

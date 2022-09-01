using LibrarrySystem.Models;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;
using Dapper;
using MODELS;

namespace LibrarrySystem.DAL
{
    public class AccountVerify
    {
        DbContext conn = new DbContext();
        

        public T_UserMaster VerifyAccount(string id, string pass)
        {
            T_UserMaster userdata;

            DynamicParameters param = new DynamicParameters();
            param.Add("@userid", id);
            param.Add("userpass", pass);

            string query = "Select * From T_UserMaster Where Umt_UserID = @userid AND Umt_Password = @userpass";

            using (IDbConnection db = new SqlConnection(conn.ConString("LibrarryDB")))
            {
                userdata = db.Query<T_UserMaster>(query, param, commandType: CommandType.Text).FirstOrDefault();
            }

            return userdata;
        }

        public List<T_UserMaster> GetAccountData()
        {
            List<T_UserMaster> data = new List<T_UserMaster>();

            string query = "Select * From T_UserMaster";

            using (IDbConnection db = new SqlConnection(conn.ConString("LibrarryDB")))
            {
                data = db.Query<T_UserMaster>(query, commandType: CommandType.Text).ToList();
            }

            return data;
        }

        public byte InsertUser(T_UserMaster data)
        {
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@Umt_UserID", data.Umt_UserID);
                param.Add("@Umt_Password", data.Umt_Password);
                param.Add("@Umt_UserName", data.Umt_UserName);
                param.Add("@Umt_UserPosition", data.Umt_UserPosition);
                param.Add("@Umt_UserEmail", data.Umt_UserEmail);
                param.Add("@@Umt_UserStatus", "A");
                param.Add("@@Umt_LoginAttempt", "0");
                param.Add("@@Umt_PasswordExpired", "0");
                param.Add("@@Umt_PasswordDateChange", "");
                param.Add("@@Umt_IsLocked", "0");
                param.Add("@@Umt_DateUpdate", "");
                param.Add("@@Umt_UserIDUpdate", "");
                param.Add("@Umt_DateCreated", data.Umt_DateCreated);
                param.Add("@type", "I");
                using (IDbConnection db = new SqlConnection(conn.ConString("LibrarryDB")))
                {
                    int success = db.Execute("SP_UserMaster", param, commandType: CommandType.StoredProcedure);
                }
                return 1;
            }
            catch (Exception e)
            {
                return 0;
            }
        }

    }
}

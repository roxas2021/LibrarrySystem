using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELS
{
    public class T_UserMaster
    {
        public string Umt_UserID { get; set; }

        public string Umt_Password { get; set; }

        public string Umt_UserPosition { get; set; }

        public string Umt_UserEmail { get; set; }

        public string Umt_UserStatus { get; set; }

        public int Umt_LoginAttempt { get; set; }

        public string Umt_PasswordExpired { get; set; }

        public DateTime Umt_PasswordDateChange { get; set; }

        public int Umt_IsLocked { get; set; }

        public DateTime Umt_DateUpdated { get; set; }

        public string Umt_UserIDUpdated { get; set; }

        public string Umt_UserName { get; set; }

        public DateTime Umt_DateCreated { get; set; }

    }
}

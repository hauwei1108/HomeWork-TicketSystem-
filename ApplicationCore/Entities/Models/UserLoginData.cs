using System;
using System.Collections.Generic;

namespace ApplicationCore.Entities.Models
{
    public partial class UserLoginData
    {
        public string UldId { get; set; }
        public string UmId { get; set; }
        public DateTime? LoginDtm { get; set; }
        public DateTime? LastActionDtm { get; set; }
        public string IsLogin { get; set; }
        public string Token { get; set; }
        public string CreateUser { get; set; }
        public DateTime CreateDtm { get; set; }
        public string ModifyUser { get; set; }
        public DateTime ModifyDtm { get; set; }
        public string ClientIp { get; set; }
        public string ServerIp { get; set; }
    }
}

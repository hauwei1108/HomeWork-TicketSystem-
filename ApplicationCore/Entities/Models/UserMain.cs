using System;
using System.Collections.Generic;

namespace ApplicationCore.Entities.Models
{
    public partial class UserMain
    {
        public string UmId { get; set; }
        public string UserName { get; set; }
        public string UserAct { get; set; }
        public string UserPd { get; set; }
        public string CreateUser { get; set; }
        public DateTime CreateDtm { get; set; }
        public string ModifyUser { get; set; }
        public DateTime ModifyDtm { get; set; }
        public string ClientIp { get; set; }
        public string ServerIp { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace ApplicationCore.Entities.Models
{
    public partial class RoleMain
    {
        public string RmId { get; set; }
        public string RoleNm { get; set; }
        public string RoleType { get; set; }
        public string CreateUser { get; set; }
        public DateTime CreateDtm { get; set; }
        public string ModifyUser { get; set; }
        public DateTime ModifyDtm { get; set; }
        public string ClientIp { get; set; }
        public string ServerIp { get; set; }
        public string SysType { get; set; }
    }
}

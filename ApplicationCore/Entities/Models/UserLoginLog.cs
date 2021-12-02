using System;
using System.Collections.Generic;

namespace ApplicationCore.Entities.Models
{
    public partial class UserLoginLog
    {
        public string UllId { get; set; }
        public string UmId { get; set; }
        public DateTime LoginDtm { get; set; }
        public string IsSuccess { get; set; }
        public string CreateUser { get; set; }
        public DateTime CreateDtm { get; set; }
        public string ClientIp { get; set; }
        public string ServerIp { get; set; }
    }
}

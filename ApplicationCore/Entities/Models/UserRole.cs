using System;
using System.Collections.Generic;

namespace ApplicationCore.Entities.Models
{
    public partial class UserRole
    {
        public string UrId { get; set; }
        public string UmId { get; set; }
        public string RmId { get; set; }
        public string CreateUser { get; set; }
        public DateTime CreateDtm { get; set; }
        public string ClientIp { get; set; }
        public string ServerIp { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace ApplicationCore.Entities.Models
{
    public partial class TypeRole
    {
        public string TrId { get; set; }
        public string TtId { get; set; }
        public string RmId { get; set; }
        public string CreateUser { get; set; }
        public DateTime CreateDtm { get; set; }
        public string ClientIp { get; set; }
        public string ServerIp { get; set; }
    }
}

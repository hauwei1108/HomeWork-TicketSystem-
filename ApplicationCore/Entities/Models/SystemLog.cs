using System;
using System.Collections.Generic;

namespace ApplicationCore.Entities.Models
{
    public partial class SystemLog
    {
        public string SlId { get; set; }
        public string LogLevel { get; set; }
        public string Message { get; set; }
        public string CreateUser { get; set; }
        public DateTime CreateDtm { get; set; }
        public string ClientIp { get; set; }
        public string ServerIp { get; set; }
    }
}

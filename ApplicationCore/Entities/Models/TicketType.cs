using System;
using System.Collections.Generic;

namespace ApplicationCore.Entities.Models
{
    public partial class TicketType
    {
        public string TtId { get; set; }
        public string TypeNm { get; set; }
        public string Type { get; set; }
        public string CreateUser { get; set; }
        public DateTime CreateDtm { get; set; }
        public string ClientIp { get; set; }
        public string ServerIp { get; set; }
    }
}

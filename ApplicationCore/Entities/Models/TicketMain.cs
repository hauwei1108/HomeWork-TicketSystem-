using System;
using System.Collections.Generic;

namespace ApplicationCore.Entities.Models
{
    public partial class TicketMain
    {
        public string TmId { get; set; }
        public string TtId { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }
        public string CreateUser { get; set; }
        public DateTime CreateDtm { get; set; }
        public string ModifyUser { get; set; }
        public DateTime ModifyDtm { get; set; }
        public string ClientIp { get; set; }
        public string ServerIp { get; set; }
    }
}

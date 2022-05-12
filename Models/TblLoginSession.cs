using System;
using System.Collections.Generic;

namespace ktsstfportal.Models
{
    public partial class TblLoginSession
    {
        public int FldLoginKey { get; set; }
        public string? FldUserName { get; set; }
        public DateTime? FldLoginEvent { get; set; }
        public DateTime? FldLogoutEvent { get; set; }
        public string? FldComputerName { get; set; }
        public string? FldActivity { get; set; }
    }
}

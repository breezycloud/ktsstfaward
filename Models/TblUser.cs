using System;
using System.Collections.Generic;

namespace ktsstfportal.Models
{
    public partial class TblUser
    {
        public int PkenginnerId { get; set; }
        public int FkuserId { get; set; }
        public string? EngineerId { get; set; }
        public ulong? Active { get; set; }
        public ulong? FldLoggedIn { get; set; }
        public string? FldComputer { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace ktsstfportal.Models
{
    public partial class TblPermission
    {
        public int FkuserId { get; set; }
        public string? LoginName { get; set; }
        public string? FullName { get; set; }
        public string? Pwd { get; set; }
        public ulong? FldChangePwd { get; set; }
        public double? FldExpireDays { get; set; }
        public string? FldGroup { get; set; }
        public double? FldAccessLevel { get; set; }
        public DateTime? FldPwddate { get; set; }
        public ulong? FldNoExpire { get; set; }
        public double? SecQues { get; set; }
        public string? FldAlwd { get; set; }
        public ulong? FldLogOut { get; set; }
    }
}

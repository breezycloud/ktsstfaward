using System;
using System.Collections.Generic;

namespace ktsstfportal.Models
{
    public partial class TblBtn
    {
        public int Id { get; set; }
        public string? BtnId { get; set; }
        public string? BtnLb { get; set; }
        public string? GrpId { get; set; }
        public string? GrpLb { get; set; }
        public string? TabId { get; set; }
        public string? TabLb { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace ktsstfportal.Models
{
    public partial class TblRev
    {
        public int RevId { get; set; }
        public DateTime? RevDate { get; set; }
        public int? Build { get; set; }
        public string? RevNo { get; set; }
        public string? RevInfo { get; set; }
        public double? OrgFileSize { get; set; }
    }
}

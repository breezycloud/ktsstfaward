using System;
using System.Collections.Generic;

namespace ktsstfportal.Models
{
    public partial class Instituition
    {
        public int InstId { get; set; }
        public string? Instituition1 { get; set; }
        public string? Location { get; set; }
        public double? UnionDues { get; set; }
        public ulong? TuitionFee { get; set; }
        public string? Abbr { get; set; }
        public double? Instcode { get; set; }
    }
}

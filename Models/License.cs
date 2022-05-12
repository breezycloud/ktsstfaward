using System;
using System.Collections.Generic;

namespace ktsstfportal.Models
{
    public partial class License
    {
        public int Id { get; set; }
        public double? Lid { get; set; }
        public string? Pin { get; set; }
        public ulong? InUse { get; set; }
        public string? DuEd { get; set; }
        public string? ChkD { get; set; }
        public ulong? Used { get; set; }
    }
}

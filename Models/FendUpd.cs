using System;
using System.Collections.Generic;

namespace ktsstfportal.Models
{
    public partial class FendUpd
    {
        public int Id { get; set; }
        public string? RevNo { get; set; }
        public ulong? InitUpd { get; set; }
        public ulong? DunUpd { get; set; }
    }
}

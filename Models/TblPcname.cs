using System;
using System.Collections.Generic;

namespace ktsstfportal.Models
{
    public partial class TblPcname
    {
        public int Id { get; set; }
        public string Pcname { get; set; } = null!;
        public DateTime Date { get; set; }
        public long? AppNo { get; set; }
    }
}

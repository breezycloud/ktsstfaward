using System;
using System.Collections.Generic;

namespace ktsstfportal.Models
{
    public partial class TblAccess
    {
        public int Userid { get; set; }
        public string? Tabs { get; set; }
        public string? Groups { get; set; }
        public string? Buttons { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace ktsstfportal.Models
{
    public partial class VerifyList
    {
        public int VerifyId { get; set; }
        public string? AppNo { get; set; }
        public string? Session { get; set; }
        public double? FileNo { get; set; }
        public int Instid { get; set; }
        public double? InterviewNo { get; set; }
        public ulong? BioVerify { get; set; }
        public string? BioVby { get; set; }
        public DateTime? BioVdate { get; set; }
        public ulong? DocsVerify { get; set; }
        public string? DocsVby { get; set; }
        public DateTime? DocsVdate { get; set; }
        public ulong? Approved { get; set; }
        public string? ApprovedBy { get; set; }
        public ulong? Paid { get; set; }
        public double? Allowance { get; set; }
        public double? UnionDues { get; set; }
        public ulong? Calculated { get; set; }
        public string? StartSes { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace ktsstfportal.Models
{
    public partial class Studentslist
    {
        public int Id { get; set; }
        public double? FileNo { get; set; }
        public string AppNo { get; set; } = null!;
        public string? RegNo { get; set; }
        public string? Jamb { get; set; }
        public string? StName { get; set; }
        public string? Lgo { get; set; }
        public string? CourseClass { get; set; }
        public string? CourseDisp { get; set; }
        public string? CourseTitle { get; set; }
        public int? CourseTime { get; set; }
        public string? Bank { get; set; }
        public string? AcctNo { get; set; }
        public string? Instituition { get; set; }
        public int? Instid { get; set; }
        public DateTime? Dob { get; set; }
        public string? Pob { get; set; }
        public string? Gender { get; set; }
        public string? Address { get; set; }
        public string? Startses { get; set; }
        public double? AwardSn { get; set; }
        public ulong? Awarded { get; set; }
        public ulong? Expired { get; set; }
        public string? Expirereason { get; set; }
        public string? Enteredby { get; set; }
        public ulong? Confirmed { get; set; }
        public ulong? Approved { get; set; }
        public string? Gsm { get; set; }
        public string? Email { get; set; }
        public DateTime? Expiredate { get; set; }
        public ulong? Interviewed { get; set; }
        public string? Interviewby { get; set; }
        public DateTime? Intdate { get; set; }
        public string? PhotoUrl { get; set; }
        public ulong? Extended { get; set; }
    }
}

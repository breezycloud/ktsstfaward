using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ktsstfportal.Models;

namespace ktsstfportal.Data
{
    public partial class DataContext : DbContext
    {
        protected readonly IConfiguration Configuration;
        public DataContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }        

        public virtual DbSet<FendUpd> FendUpds { get; set; } = null!;
        public virtual DbSet<Instituition> Instituitions { get; set; } = null!;
        public virtual DbSet<License> Licenses { get; set; } = null!;
        public virtual DbSet<MinorsGlobal> MinorsGlobals { get; set; } = null!;
        public virtual DbSet<Studentslist> Studentslists { get; set; } = null!;
        public virtual DbSet<TblAccess> TblAccesses { get; set; } = null!;
        public virtual DbSet<TblAllow> TblAllows { get; set; } = null!;
        public virtual DbSet<TblBtn> TblBtns { get; set; } = null!;
        public virtual DbSet<TblLogOff> TblLogOffs { get; set; } = null!;
        public virtual DbSet<TblLoginSession> TblLoginSessions { get; set; } = null!;
        public virtual DbSet<TblPcname> TblPcnames { get; set; } = null!;
        public virtual DbSet<TblPermission> TblPermissions { get; set; } = null!;
        public virtual DbSet<TblRev> TblRevs { get; set; } = null!;
        public virtual DbSet<TblUser> TblUsers { get; set; } = null!;
        public virtual DbSet<UsysRibbon> UsysRibbons { get; set; } = null!;
        public virtual DbSet<VerifyList> VerifyLists { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = Configuration.GetConnectionString("Production");
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("latin1_swedish_ci")
                .HasCharSet("latin1");

            modelBuilder.Entity<FendUpd>(entity =>
            {
                entity.ToTable("FEndUPD");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID");

                entity.Property(e => e.DunUpd)
                    .HasColumnType("bit(1)")
                    .HasColumnName("DunUPD");

                entity.Property(e => e.InitUpd)
                    .HasColumnType("bit(1)")
                    .HasColumnName("InitUPD");

                entity.Property(e => e.RevNo).HasMaxLength(255);
            });

            modelBuilder.Entity<Instituition>(entity =>
            {
                entity.HasKey(e => e.InstId)
                    .HasName("PRIMARY");

                entity.Property(e => e.InstId)
                    .HasColumnType("int(11)")
                    .HasColumnName("InstID");

                entity.Property(e => e.Abbr)
                    .HasMaxLength(10)
                    .HasColumnName("ABBR");

                entity.Property(e => e.Instcode).HasColumnName("INSTCODE");

                entity.Property(e => e.Instituition1)
                    .HasMaxLength(255)
                    .HasColumnName("INSTITUITION");

                entity.Property(e => e.Location)
                    .HasMaxLength(255)
                    .HasColumnName("LOCATION");

                entity.Property(e => e.TuitionFee)
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("b'0'");

                entity.Property(e => e.UnionDues).HasDefaultValueSql("'0'");
            });

            modelBuilder.Entity<License>(entity =>
            {
                entity.ToTable("License");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID");

                entity.Property(e => e.ChkD).HasMaxLength(255);

                entity.Property(e => e.DuEd)
                    .HasMaxLength(255)
                    .HasColumnName("DuED");

                entity.Property(e => e.InUse).HasColumnType("bit(1)");

                entity.Property(e => e.Lid).HasColumnName("LID");

                entity.Property(e => e.Pin)
                    .HasMaxLength(255)
                    .HasColumnName("PIN");

                entity.Property(e => e.Used).HasColumnType("bit(1)");
            });

            modelBuilder.Entity<MinorsGlobal>(entity =>
            {
                entity.ToTable("MinorsGlobal");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID");

                entity.Property(e => e.Minors).HasMaxLength(255);
            });

            modelBuilder.Entity<Studentslist>(entity =>
            {
                entity.ToTable("STUDENTSLIST");

                entity.HasIndex(e => e.AppNo, "APP_NO");

                entity.HasIndex(e => e.FileNo, "FILE_NO");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID");

                entity.Property(e => e.AcctNo)
                    .HasMaxLength(255)
                    .HasColumnName("ACCT_NO");

                entity.Property(e => e.Address)
                    .HasMaxLength(200)
                    .HasColumnName("ADDRESS");

                entity.Property(e => e.AppNo).HasColumnName("APP_NO");

                entity.Property(e => e.Approved)
                    .HasColumnType("bit(1)")
                    .HasColumnName("APPROVED")
                    .HasDefaultValueSql("b'0'");

                entity.Property(e => e.AwardSn).HasColumnName("AwardSN");

                entity.Property(e => e.Awarded)
                    .HasColumnType("bit(1)")
                    .HasColumnName("AWARDED");

                entity.Property(e => e.Bank)
                    .HasMaxLength(255)
                    .HasColumnName("BANK");

                entity.Property(e => e.Confirmed)
                    .HasColumnType("bit(1)")
                    .HasColumnName("CONFIRMED")
                    .HasDefaultValueSql("b'0'");

                entity.Property(e => e.CourseClass)
                    .HasMaxLength(255)
                    .HasColumnName("COURSE_CLASS");

                entity.Property(e => e.CourseDisp)
                    .HasMaxLength(255)
                    .HasColumnName("COURSE_DISP");

                entity.Property(e => e.CourseTime)
                    .HasColumnType("int(11)")
                    .HasColumnName("COURSE_TIME");

                entity.Property(e => e.CourseTitle)
                    .HasMaxLength(255)
                    .HasColumnName("COURSE_TITLE");

                entity.Property(e => e.Dob)
                    .HasColumnType("datetime")
                    .HasColumnName("DOB");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.Enteredby)
                    .HasMaxLength(255)
                    .HasColumnName("ENTEREDBY");

                entity.Property(e => e.Expired)
                    .HasColumnType("bit(1)")
                    .HasColumnName("EXPIRED");

                entity.Property(e => e.Expiredate)
                    .HasColumnType("datetime")
                    .HasColumnName("EXPIREDATE");

                entity.Property(e => e.Expirereason)
                    .HasMaxLength(255)
                    .HasColumnName("EXPIREREASON");

                entity.Property(e => e.Extended)
                    .HasColumnType("bit(1)")
                    .HasColumnName("EXTENDED");

                entity.Property(e => e.FileNo).HasColumnName("FILE_NO");

                entity.Property(e => e.Gender)
                    .HasMaxLength(25)
                    .HasColumnName("GENDER");

                entity.Property(e => e.Gsm)
                    .HasMaxLength(255)
                    .HasColumnName("GSM");

                entity.Property(e => e.Instid)
                    .HasColumnType("int(11)")
                    .HasColumnName("INSTID");

                entity.Property(e => e.Instituition)
                    .HasMaxLength(255)
                    .HasColumnName("INSTITUITION");

                entity.Property(e => e.Intdate)
                    .HasColumnType("datetime")
                    .HasColumnName("INTDATE");

                entity.Property(e => e.Interviewby)
                    .HasMaxLength(255)
                    .HasColumnName("INTERVIEWBY");

                entity.Property(e => e.Interviewed)
                    .HasColumnType("bit(1)")
                    .HasColumnName("INTERVIEWED")
                    .HasDefaultValueSql("b'0'");

                entity.Property(e => e.Jamb)
                    .HasMaxLength(255)
                    .HasColumnName("JAMB");

                entity.Property(e => e.Lgo)
                    .HasMaxLength(255)
                    .HasColumnName("LGO");

                entity.Property(e => e.PhotoUrl)
                    .HasMaxLength(255)
                    .HasColumnName("PhotoURL");

                entity.Property(e => e.Pob)
                    .HasMaxLength(255)
                    .HasColumnName("POB");

                entity.Property(e => e.RegNo)
                    .HasMaxLength(255)
                    .HasColumnName("REG_NO");

                entity.Property(e => e.StName)
                    .HasMaxLength(255)
                    .HasColumnName("ST_NAME");

                entity.Property(e => e.Startses)
                    .HasMaxLength(255)
                    .HasColumnName("STARTSES");
            });

            modelBuilder.Entity<TblAccess>(entity =>
            {
                entity.HasKey(e => e.Userid)
                    .HasName("PRIMARY");

                entity.ToTable("TblAccess");

                entity.Property(e => e.Userid)
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever()
                    .HasColumnName("USERID");

                entity.Property(e => e.Buttons).HasColumnName("BUTTONS");

                entity.Property(e => e.Groups).HasColumnName("GROUPS");

                entity.Property(e => e.Tabs).HasColumnName("TABS");
            });

            modelBuilder.Entity<TblAllow>(entity =>
            {
                entity.HasKey(e => e.NuserId)
                    .HasName("PRIMARY");

                entity.ToTable("TblAllow");

                entity.Property(e => e.NuserId)
                    .HasColumnType("int(11)")
                    .HasColumnName("NUserID");

                entity.Property(e => e.BtnAppGet)
                    .HasColumnType("bit(1)")
                    .HasColumnName("btnAppGet")
                    .HasDefaultValueSql("b'0'");

                entity.Property(e => e.BtnAppSet)
                    .HasColumnType("bit(1)")
                    .HasColumnName("btnAppSet")
                    .HasDefaultValueSql("b'0'");

                entity.Property(e => e.BtnAppSync)
                    .HasColumnType("bit(1)")
                    .HasColumnName("btnAppSync")
                    .HasDefaultValueSql("b'0'");

                entity.Property(e => e.BtnAwardApprove)
                    .HasColumnType("bit(1)")
                    .HasColumnName("btnAwardApprove")
                    .HasDefaultValueSql("b'0'");

                entity.Property(e => e.BtnAwardConfirm)
                    .HasColumnType("bit(1)")
                    .HasColumnName("btnAwardConfirm")
                    .HasDefaultValueSql("b'0'");

                entity.Property(e => e.BtnAwardEnd)
                    .HasColumnType("bit(1)")
                    .HasColumnName("btnAwardEnd")
                    .HasDefaultValueSql("b'0'");

                entity.Property(e => e.BtnAwardExtend)
                    .HasColumnType("bit(1)")
                    .HasColumnName("btnAwardExtend")
                    .HasDefaultValueSql("b'0'");

                entity.Property(e => e.BtnAwardNew)
                    .HasColumnType("bit(1)")
                    .HasColumnName("btnAwardNew")
                    .HasDefaultValueSql("b'0'");

                entity.Property(e => e.BtnAwardRevoke)
                    .HasColumnType("bit(1)")
                    .HasColumnName("btnAwardRevoke")
                    .HasDefaultValueSql("b'0'");

                entity.Property(e => e.BtnBuyLicense)
                    .HasColumnType("bit(1)")
                    .HasColumnName("btnBuyLicense")
                    .HasDefaultValueSql("b'0'");

                entity.Property(e => e.BtnCalAllow)
                    .HasColumnType("bit(1)")
                    .HasColumnName("btnCalAllow")
                    .HasDefaultValueSql("b'0'");

                entity.Property(e => e.BtnChgPwd)
                    .HasColumnType("bit(1)")
                    .HasColumnName("btnChgPWD")
                    .HasDefaultValueSql("b'0'");

                entity.Property(e => e.BtnCseNew)
                    .HasColumnType("bit(1)")
                    .HasColumnName("btnCseNew")
                    .HasDefaultValueSql("b'0'");

                entity.Property(e => e.BtnEditAllow)
                    .HasColumnType("bit(1)")
                    .HasColumnName("btnEditAllow")
                    .HasDefaultValueSql("b'0'");

                entity.Property(e => e.BtnEditName)
                    .HasColumnType("bit(1)")
                    .HasColumnName("btnEditName")
                    .HasDefaultValueSql("b'0'");

                entity.Property(e => e.BtnEditNbr)
                    .HasColumnType("bit(1)")
                    .HasColumnName("btnEditNbr")
                    .HasDefaultValueSql("b'0'");

                entity.Property(e => e.BtnEditSch)
                    .HasColumnType("bit(1)")
                    .HasColumnName("btnEditSch")
                    .HasDefaultValueSql("b'0'");

                entity.Property(e => e.BtnEnroll)
                    .HasColumnType("bit(1)")
                    .HasColumnName("btnEnroll")
                    .HasDefaultValueSql("b'0'");

                entity.Property(e => e.BtnExApp)
                    .HasColumnType("bit(1)")
                    .HasColumnName("btnExApp")
                    .HasDefaultValueSql("b'0'");

                entity.Property(e => e.BtnFindName)
                    .HasColumnType("bit(1)")
                    .HasColumnName("btnFindName")
                    .HasDefaultValueSql("b'0'");

                entity.Property(e => e.BtnIdentify)
                    .HasColumnType("bit(1)")
                    .HasColumnName("btnIdentify")
                    .HasDefaultValueSql("b'0'");

                entity.Property(e => e.BtnIenroll)
                    .HasColumnType("bit(1)")
                    .HasColumnName("btnIEnroll")
                    .HasDefaultValueSql("b'0'");

                entity.Property(e => e.BtnIplist)
                    .HasColumnType("bit(1)")
                    .HasColumnName("btnIPlist")
                    .HasDefaultValueSql("b'0'");

                entity.Property(e => e.BtnIslist)
                    .HasColumnType("bit(1)")
                    .HasColumnName("btnISlist")
                    .HasDefaultValueSql("b'0'");

                entity.Property(e => e.BtnNapp)
                    .HasColumnType("bit(1)")
                    .HasColumnName("btnNApp")
                    .HasDefaultValueSql("b'0'");

                entity.Property(e => e.BtnNewCamp)
                    .HasColumnType("bit(1)")
                    .HasColumnName("btnNewCamp")
                    .HasDefaultValueSql("b'0'");

                entity.Property(e => e.BtnPaySch)
                    .HasColumnType("bit(1)")
                    .HasColumnName("btnPaySch")
                    .HasDefaultValueSql("b'0'");

                entity.Property(e => e.BtnPaySum)
                    .HasColumnType("bit(1)")
                    .HasColumnName("btnPaySum")
                    .HasDefaultValueSql("b'0'");

                entity.Property(e => e.BtnPivlist)
                    .HasColumnType("bit(1)")
                    .HasColumnName("btnPIVList")
                    .HasDefaultValueSql("b'0'");

                entity.Property(e => e.BtnPrintAward)
                    .HasColumnType("bit(1)")
                    .HasColumnName("btnPrintAward")
                    .HasDefaultValueSql("b'0'");

                entity.Property(e => e.BtnRecalAllow)
                    .HasColumnType("bit(1)")
                    .HasColumnName("btnRecalAllow")
                    .HasDefaultValueSql("b'0'");

                entity.Property(e => e.BtnRefLink)
                    .HasColumnType("bit(1)")
                    .HasColumnName("btnRefLink")
                    .HasDefaultValueSql("b'0'");

                entity.Property(e => e.BtnRiplist)
                    .HasColumnType("bit(1)")
                    .HasColumnName("btnRIPlist")
                    .HasDefaultValueSql("b'0'");

                entity.Property(e => e.BtnSchNew)
                    .HasColumnType("bit(1)")
                    .HasColumnName("btnSchNew")
                    .HasDefaultValueSql("b'0'");

                entity.Property(e => e.BtnSchRename)
                    .HasColumnType("bit(1)")
                    .HasColumnName("btnSchRename")
                    .HasDefaultValueSql("b'0'");

                entity.Property(e => e.BtnSetAcc)
                    .HasColumnType("bit(1)")
                    .HasColumnName("btnSetAcc")
                    .HasDefaultValueSql("b'0'");

                entity.Property(e => e.BtnStdInfo)
                    .HasColumnType("bit(1)")
                    .HasColumnName("btnStdInfo")
                    .HasDefaultValueSql("b'0'");

                entity.Property(e => e.BtnStdList)
                    .HasColumnType("bit(1)")
                    .HasColumnName("btnStdList")
                    .HasDefaultValueSql("b'0'");

                entity.Property(e => e.BtnUpdsoft)
                    .HasColumnType("bit(1)")
                    .HasColumnName("btnUPDSoft")
                    .HasDefaultValueSql("b'0'");

                entity.Property(e => e.BtnUserRemove)
                    .HasColumnType("bit(1)")
                    .HasColumnName("btnUserRemove")
                    .HasDefaultValueSql("b'0'");

                entity.Property(e => e.BtnUsersAdd)
                    .HasColumnType("bit(1)")
                    .HasColumnName("btnUsersAdd")
                    .HasDefaultValueSql("b'0'");

                entity.Property(e => e.BtnVapprove)
                    .HasColumnType("bit(1)")
                    .HasColumnName("btnVApprove")
                    .HasDefaultValueSql("b'0'");

                entity.Property(e => e.BtnVerify)
                    .HasColumnType("bit(1)")
                    .HasColumnName("btnVerify")
                    .HasDefaultValueSql("b'0'");

                entity.Property(e => e.BtnVnew)
                    .HasColumnType("bit(1)")
                    .HasColumnName("btnVNew")
                    .HasDefaultValueSql("b'0'");

                entity.Property(e => e.BtnVold)
                    .HasColumnType("bit(1)")
                    .HasColumnName("btnVOld")
                    .HasDefaultValueSql("b'0'");

                entity.Property(e => e.BtnVplist)
                    .HasColumnType("bit(1)")
                    .HasColumnName("btnVPlist")
                    .HasDefaultValueSql("b'0'");

                entity.Property(e => e.UserId)
                    .HasColumnType("int(11)")
                    .HasColumnName("UserID")
                    .HasDefaultValueSql("'0'");
            });

            modelBuilder.Entity<TblBtn>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID");

                entity.Property(e => e.BtnId)
                    .HasMaxLength(255)
                    .HasColumnName("BtnID");

                entity.Property(e => e.BtnLb).HasMaxLength(255);

                entity.Property(e => e.GrpId)
                    .HasMaxLength(255)
                    .HasColumnName("GrpID");

                entity.Property(e => e.GrpLb).HasMaxLength(255);

                entity.Property(e => e.TabId)
                    .HasMaxLength(255)
                    .HasColumnName("TabID");

                entity.Property(e => e.TabLb).HasMaxLength(255);
            });

            modelBuilder.Entity<TblLogOff>(entity =>
            {
                entity.ToTable("TblLogOff");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.LogOff).HasColumnType("bit(1)");
            });

            modelBuilder.Entity<TblLoginSession>(entity =>
            {
                entity.HasKey(e => e.FldLoginKey)
                    .HasName("PRIMARY");

                entity.ToTable("tblLoginSessions");

                entity.Property(e => e.FldLoginKey)
                    .HasColumnType("int(11)")
                    .HasColumnName("fldLoginKey");

                entity.Property(e => e.FldActivity).HasColumnType("mediumtext");

                entity.Property(e => e.FldComputerName)
                    .HasMaxLength(25)
                    .HasColumnName("fldComputerName");

                entity.Property(e => e.FldLoginEvent).HasColumnType("datetime");

                entity.Property(e => e.FldLogoutEvent)
                    .HasColumnType("datetime")
                    .HasColumnName("fldLogoutEvent");

                entity.Property(e => e.FldUserName)
                    .HasMaxLength(255)
                    .HasColumnName("fldUserName");
            });

            modelBuilder.Entity<TblPcname>(entity =>
            {
                entity.ToTable("tblPCName");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.AppNo)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("App_No");

                entity.Property(e => e.Date)
                    .HasColumnType("datetime")
                    .ValueGeneratedOnAddOrUpdate()
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Pcname)
                    .HasMaxLength(255)
                    .HasColumnName("PCName")
                    .HasDefaultValueSql("'0'");
            });

            modelBuilder.Entity<TblPermission>(entity =>
            {
                entity.HasKey(e => e.FkuserId)
                    .HasName("PRIMARY");

                entity.ToTable("tbl-Permissions");

                entity.Property(e => e.FkuserId)
                    .HasColumnType("int(11)")
                    .HasColumnName("FKUserId");

                entity.Property(e => e.FldAccessLevel).HasColumnName("fldAccessLevel");

                entity.Property(e => e.FldAlwd).HasMaxLength(255);

                entity.Property(e => e.FldChangePwd)
                    .HasColumnType("bit(1)")
                    .HasColumnName("fldChangePWD");

                entity.Property(e => e.FldExpireDays).HasColumnName("fldExpireDays");

                entity.Property(e => e.FldGroup)
                    .HasMaxLength(255)
                    .HasColumnName("fldGroup");

                entity.Property(e => e.FldLogOut).HasColumnType("bit(1)");

                entity.Property(e => e.FldNoExpire)
                    .HasColumnType("bit(1)")
                    .HasColumnName("fldNoExpire");

                entity.Property(e => e.FldPwddate)
                    .HasColumnType("datetime")
                    .HasColumnName("fldPWDDate");

                entity.Property(e => e.FullName).HasMaxLength(255);

                entity.Property(e => e.LoginName).HasMaxLength(20);

                entity.Property(e => e.Pwd)
                    .HasMaxLength(50)
                    .HasColumnName("PWD");
            });

            modelBuilder.Entity<TblRev>(entity =>
            {
                entity.HasKey(e => e.RevId)
                    .HasName("PRIMARY");

                entity.ToTable("TblRev");

                entity.Property(e => e.RevId)
                    .HasColumnType("int(11)")
                    .HasColumnName("RevID");

                entity.Property(e => e.Build).HasColumnType("int(11)");

                entity.Property(e => e.RevDate).HasColumnType("datetime");

                entity.Property(e => e.RevInfo).HasMaxLength(255);

                entity.Property(e => e.RevNo).HasMaxLength(255);
            });

            modelBuilder.Entity<TblUser>(entity =>
            {
                entity.HasKey(e => e.PkenginnerId)
                    .HasName("PRIMARY");

                entity.ToTable("Tbl-Users");

                entity.Property(e => e.PkenginnerId)
                    .HasColumnType("int(11)")
                    .HasColumnName("PKEnginnerID");

                entity.Property(e => e.Active).HasColumnType("bit(1)");

                entity.Property(e => e.EngineerId)
                    .HasMaxLength(15)
                    .HasColumnName("EngineerID");

                entity.Property(e => e.FkuserId)
                    .HasColumnType("int(11)")
                    .HasColumnName("FKUserID");

                entity.Property(e => e.FldComputer)
                    .HasMaxLength(50)
                    .HasColumnName("fldComputer");

                entity.Property(e => e.FldLoggedIn)
                    .HasColumnType("bit(1)")
                    .HasColumnName("fldLoggedIn");
            });

            modelBuilder.Entity<UsysRibbon>(entity =>
            {
                entity.ToTable("USysRibbons");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID");

                entity.Property(e => e.RibbonName).HasMaxLength(255);

                entity.Property(e => e.RibbonXml)
                    .HasColumnType("mediumtext")
                    .HasColumnName("RibbonXML");
            });

            modelBuilder.Entity<VerifyList>(entity =>
            {
                entity.HasKey(e => e.VerifyId)
                    .HasName("PRIMARY");

                entity.ToTable("VerifyList");

                entity.HasIndex(e => e.AppNo, "AppNo");

                entity.Property(e => e.VerifyId)
                    .HasColumnType("int(11)")
                    .HasColumnName("VerifyID");

                entity.Property(e => e.Approved)
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("b'0'");

                entity.Property(e => e.ApprovedBy).HasMaxLength(255);

                entity.Property(e => e.BioVby)
                    .HasMaxLength(255)
                    .HasColumnName("BioVBy");

                entity.Property(e => e.BioVdate)
                    .HasColumnType("datetime")
                    .HasColumnName("BioVDate");

                entity.Property(e => e.BioVerify)
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("b'0'");

                entity.Property(e => e.Calculated)
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("b'0'");

                entity.Property(e => e.DocsVby)
                    .HasMaxLength(255)
                    .HasColumnName("DocsVBy");

                entity.Property(e => e.DocsVdate)
                    .HasColumnType("datetime")
                    .HasColumnName("DocsVDate");

                entity.Property(e => e.DocsVerify)
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("b'0'");

                entity.Property(e => e.Instid)
                    .HasColumnType("int(11)")
                    .HasColumnName("INSTID");

                entity.Property(e => e.Paid)
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("b'0'");

                entity.Property(e => e.Session).HasMaxLength(255);

                entity.Property(e => e.StartSes).HasMaxLength(15);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

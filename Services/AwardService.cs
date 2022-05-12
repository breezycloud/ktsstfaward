using System.Reflection;
using ktsstfportal.Data;
using ktsstfportal.Models;
using ktsstfportal.Util;
using Microsoft.EntityFrameworkCore;
using Microsoft.JSInterop;
using Microsoft.Reporting.NETCore;

namespace ktsstfportal.Services;

public interface IAwardService
{
    ValueTask<Studentslist> GetAwardLetter(string option, string value);
    ValueTask PrintAward(Studentslist student);
}

public class AwardService : IAwardService
{
    private readonly DataContext _context;
    private Studentslist? student { get; set; } = null;
    private readonly IJSRuntime _js;
    private readonly IConverter _helper;
    public AwardService(DataContext context, IJSRuntime js, IConverter helper)
    {
        _context = context;
        _js = js;
        _helper = helper;
    }

    public async ValueTask<Studentslist> GetAwardLetter(string option, string value)
    {
        if (option == "AppNo")
        {
            student = await _context.Studentslists.Where(x => x.AppNo == value && x.Awarded == 1).FirstOrDefaultAsync() ?? new Studentslist();
        }
        else
        {
            student = await _context.Studentslists.Where(x => x.FileNo == double.Parse(value) && x.Awarded == 1).FirstOrDefaultAsync() ?? new Studentslist();
        }
        return student;
    }

    public async ValueTask PrintAward(Studentslist student)
    {
        var qrCode = await _helper.ConvertImageToByte(student.FileNo!.ToString()!);
        var photo = await _helper.GetImageByte(student.PhotoUrl!);
        using var fs = Assembly.GetExecutingAssembly().GetManifestResourceStream("ktsstfportal.Report.AwardLetter.rdlc");
        LocalReport report = new();
        report.LoadReportDefinition(fs);
        report.EnableExternalImages = true;        
        report.SetParameters(new[] 
        { 
            new ReportParameter("ApplicantName", student.StName!.ToUpper()),
            new ReportParameter("Institution", student.Instituition!.ToUpper()),
            new ReportParameter("AppNo", student.AppNo!.ToUpper()),
            new ReportParameter("FileNo", student.FileNo.ToString()!.ToUpper()),
            new ReportParameter("Session", student.Startses!),
            new ReportParameter("Programme", student.CourseTitle!.ToUpper()),
            new ReportParameter("Duration", $"{student.CourseTime} years Commencing {student.Startses!}"),
            new ReportParameter("QRCodeImage", Convert.ToBase64String(qrCode)),
            new ReportParameter("ApplicantPhoto", Convert.ToBase64String(photo)),
            new ReportParameter("ApplicationDate", student.Intdate!.Value!.ToString("dd-MMMM-yyyy")),
        });
        byte[] pdf = report.Render("HTML5", DeviceInfo());
        await _js.InvokeAsync<object>("exportExcelFile", $"{student.FileNo} Award Letter.html", Convert.ToBase64String(pdf));
    }

    private string DeviceInfo() =>            
                @"<DeviceInfo>
                    <OutputFormat>EMF</OutputFormat>
                    <PageWidth>21cm</PageWidth>
                    <PageHeight>29.7cm</PageHeight>
                    <MarginTop>0</MarginTop>
                    <MarginLeft>0</MarginLeft>
                    <MarginRight>0</MarginRight>
                    <MarginBottom>0</MarginBottom>
                </DeviceInfo>";
}
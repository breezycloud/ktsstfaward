using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using ktsstfportal.Data;
using MudBlazor.Services;
using Blazored.LocalStorage;
using ktsstfportal.Client.Services;
using ktsstfportal.Services;
using ktsstfportal.Util;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddMudServices();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddDbContext<DataContext>();
builder.Services.AddScoped<LayoutService>();
builder.Services.AddScoped<IConverter, Converter>();
builder.Services.AddScoped<IUserPreferencesService, UserPreferencesService>();
builder.Services.AddScoped<IAwardService, AwardService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();

using BidMandarin.BackroundServices;
using BidMandarin.Methods;
using BidMandarin.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DevConnection"))); 
builder.Services.AddSingleton<IHostedService, DailyCleanupService>(); 
builder.Services.AddSingleton<IEmailSender, EmailSender>();




var app = builder.Build(); 



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "mandarin",
    pattern: "{controller=Mandarin}/{action=Index}/{id}");

app.MapControllerRoute(
    name: "bid",
    pattern: "{controller = Bid}/{action=Index}/{id}");

app.Run();

using DocService.Models.Data;
using DocService.Repositories.Interfaces;
using DocService.Repositories.Repos;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using DocService.Utilities;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Database"));
});

builder.Services.AddIdentity<IdentityUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();;
    

// Add services to the container.
builder.Services.AddControllersWithViews();
//Razor Runtime Compilation
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
builder.Services.AddRazorPages();

//Add Repository
builder.Services.AddScoped<IDoctorRepository, DoctorRepository>();
//AddMapper

//email
builder.Services.AddSingleton<IEmailSender,EmailSender>();



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
app.UseAuthentication();;

app.UseAuthorization();
app.MapRazorPages();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

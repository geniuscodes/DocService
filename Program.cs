using DocService.Models.Data.Identity;
using DocService.Repositories.Interfaces;
using DocService.Repositories.Repos;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using DocService.Utilities;
using DocService.Models.Data;
using DocService.Profiles;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<IdentityAppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Database"));
});

//Identity Database Context
builder.Services.AddIdentity<IdentityUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<IdentityAppDbContext>()
    .AddDefaultTokenProviders();;

//Normal Database Context
builder.Services.AddDbContext<AppDbContext>(
    options=>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Database")));

// Add services to the container.
builder.Services.AddControllersWithViews();
//Razor Runtime Compilation
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
builder.Services.AddRazorPages();

//Add Repository
builder.Services.AddScoped<IDoctorRepository, DoctorRepository>();
builder.Services.AddScoped<INurseRepository, NurseRepository>();
builder.Services.AddScoped<IPatientRepository, PatientRepository>();
builder.Services.AddScoped<IAppointmentRepository, AppointmentRepository>();

builder.Services.AddAutoMapper(typeof(MapPtofiles)); // The Righr way to do this

//AddMapper

//email
builder.Services.AddSingleton<IEmailSender,EmailSender>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseSwagger();
    app.UseSwaggerUI();

}
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = string.Empty;
});
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSwagger();
app.UseSwaggerUI();
app.UseRouting();
app.UseAuthentication();;

app.UseAuthorization();
app.MapRazorPages();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

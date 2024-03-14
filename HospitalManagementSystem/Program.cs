using HospitalManagementSystem.Models;
using HospitalManagementSystem.Models.DoctorModel;
using HospitalManagementSystem.Models.PatientModel;
using HospitalManagementSystem.Models.ServiceModel;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IPatientRepository, PatientRepository>();

builder.Services.AddScoped<IDoctorRepository, DoctorRepository>();
builder.Services.AddScoped<IServiceRepository, ServiceRepository>();


builder.Services.AddDbContext<HospitalDbContext>(options => {
    options.UseNpgsql(
        builder.Configuration["ConnectionStrings:HospitalDbContextConnection"]);
});

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

app.Run();

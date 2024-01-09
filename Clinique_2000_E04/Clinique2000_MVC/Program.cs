using Clinique2000_DataAccess.Data;
using Clinique2000_Services.IServices;
using Clinique2000_Services.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);


builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = GoogleDefaults.AuthenticationScheme;
})
.AddCookie()
.AddGoogle(GoogleDefaults.AuthenticationScheme, option =>
{
    option.ClientId = builder.Configuration.GetSection("GoogleKeys:ClientId").Value;
    option.ClientSecret = builder.Configuration.GetSection("GoogleKeys:ClientSecret").Value;
});


// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddHttpContextAccessor();



//DbContext
builder.Services.AddDbContext<CliniqueDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
    options.UseLazyLoadingProxies();
});
#region Servivces
builder.Services.AddScoped(typeof(IServiceBaseAsync<>), typeof(ServiceBaseAsync<>));
builder.Services.AddScoped<IAuthenGoogleService, AuthenGoogleService>();
builder.Services.AddScoped(typeof(IPatientService), typeof(PatientService));
#endregion

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

app.UseAuthentication();
app.UseAuthorization();



app.MapControllerRoute(
    name: "default",
    pattern: "{area=Patients}/{controller=Home}/{action=Index}/{id?}");


//app.MapAreaControllerRoute(
//    name: "PatientArea",
//    areaName: "Patient",
//    pattern: "Patient/{controller=Home}/{action=Index}/{id?}");


app.Run();

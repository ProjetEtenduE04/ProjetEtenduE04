using Clinique2000_DataAccess.Data;
using Clinique2000_Services.IServices;
using Clinique2000_Services.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System.Text.Json.Serialization;
using Clinique2000_DataAccess.Initializer;
using Microsoft.IdentityModel.Tokens;
using Clinique2000_Utility.Constants;

var builder = WebApplication.CreateBuilder(args);
//DbContext
builder.Services.AddDbContext<CliniqueDbContext>(options =>
{ 
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")).UseLazyLoadingProxies();
  
});

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<CliniqueDbContext>();


builder.Services.AddAuthentication().AddGoogle(googleOptions =>
{
    googleOptions.ClientId = builder.Configuration.GetSection("GoogleKeys:ClientId").Value;
    googleOptions.ClientSecret = builder.Configuration.GetSection("GoogleKeys:ClientSecret").Value;
});
builder.Services.AddQuartzServices();
builder.Services.AddControllersWithViews();
builder.Services.AddHttpContextAccessor();

//builder.Services.AddAuthentication(options =>
//{
//    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
//    options.DefaultChallengeScheme = GoogleDefaults.AuthenticationScheme;
//})
//.AddCookie()
//.AddGoogle(GoogleDefaults.AuthenticationScheme, option =>
//{
//    option.ClientId = builder.Configuration.GetSection("GoogleKeys:ClientId").Value;
//    option.ClientSecret = builder.Configuration.GetSection("GoogleKeys:ClientSecret").Value;
//});

// Add services to the container.

#region Servivces
builder.Services.AddScoped(typeof(IServiceBaseAsync<>), typeof(ServiceBaseAsync<>));
builder.Services.AddScoped<IClinique2000Services, Clinique2000Services>();
builder.Services.AddScoped<ICliniqueService, CliniqueService>();
builder.Services.AddScoped<IdbInitialiser, DbInitialiser>();
builder.Services.AddScoped<IAdresseService, AdresseService>();
builder.Services.AddScoped<IListeAttenteService, ListeAttenteService>();
builder.Services.AddScoped<IAuthenGoogleService, AuthenGoogleService>();
builder.Services.AddScoped(typeof(IPatientService), typeof(PatientService));
builder.Services.AddScoped<IConsultationService, ConsultationService>();
builder.Services.AddScoped<IEmployesCliniqueService, EmployesCliniqueService>();
builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddScoped<IAdminService, AdminService>();

//builder.Services.AddTransient<DataImportService>();
//builder.Services.AddHostedService(provider =>
//    new DataImportBackgroundService(provider, AppConstants.CsvFilePath));

#endregion
builder.Services.AddControllersWithViews()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
    });


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("Area/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

void SeedDatabase()
{
    using (var scope = app.Services.CreateScope())
    {
        var dbInitializer = scope.ServiceProvider.GetRequiredService<IdbInitialiser>();
        dbInitializer.Initialize();
    }
}

SeedDatabase();

app.MapControllerRoute(
    name: "areaRoute",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();
app.Run();

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
using Clinique2000_Core.Models;
using Google;
using Clinique2000_MVC.Hubs;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;


var builder = WebApplication.CreateBuilder(args);

// DbContext
builder.Services.AddDbContext<CliniqueDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")).UseLazyLoadingProxies();
});

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
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

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAlmostAll", policy =>
    {
        policy.WithOrigins("http://localhost", "https:localhost");
        policy.AllowAnyHeader();
        policy.AllowAnyMethod();
        policy.AllowCredentials();
    });
});

builder.Services.AddControllersWithViews()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
    });

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Clinique2000_MVC", Version = "v1" });



    c.AddSecurityDefinition("ApiKey", new OpenApiSecurityScheme
    {
        Description = "Veuillez entrer la cl� API comme suit: Bearer {votre cl� ici}",
        Name = "X-Api-Key", // Le nom de l'en-t�te HTTP
        In = ParameterLocation.Header, // Emplacement de l'en-t�te
        Type = SecuritySchemeType.ApiKey, // Type du sch�ma de s�curit�
        Scheme = "ApiKeyScheme"
    });

    // Un dictionnaire de requirements pour assurer que nos endpoints utilisent le sch�ma de s�curit�
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
{
    {
        new OpenApiSecurityScheme
        {
            Reference = new OpenApiReference
            {
                Type = ReferenceType.SecurityScheme,
                Id = "ApiKey" // L'ID doit correspondre � l'ID d�fini dans AddSecurityDefinition
            },
            Scheme = "ApiKeyScheme",
            Name = "X-Api-Key",
            In = ParameterLocation.Header
        },
        new List<string>()
    }
});
});

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
builder.Services.AddScoped<IPatientAchargeService, PatientAchargeService>();
builder.Services.AddScoped<ISMSService,SMSService>();
builder.Services.AddScoped<IAPIService, APIService>();
builder.Services.AddScoped<IAPIKeyService, APIKeyService>();
builder.Services.AddScoped<IApiKeyAuthenticationService, ApiKeyAuthenticationService>();

#endregion

builder.Services.AddSignalR();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("Area/Home/Error");
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

app.UseCors("AllowAlmostAll");


app.MapControllerRoute(
    name: "areaRoute",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();
app.MapHub<MiseAJourListeAttentePatientHub>("/MiseAJourListeAttentePatientHub");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Clinique2000_MVC v1"));
}

app.Run();

using Append.Blazor.Printing;
using BlazorDownloadFile;
using Blazored.Toast;
using HealthCare.UI.AppSettings;
using HealthCare.Repository;
using HealthCare.UI.Shared;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Syncfusion.Blazor;
using System.Globalization;
using Microsoft.Crm.Sdk.Messages;
using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder(args);


//Db connection
builder.Services.AddDbContextFactory<CamcoDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), o => o.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery)), ServiceLifetime.Singleton);

builder.Services.AddDbContext<CamcoDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), o => o.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery)), ServiceLifetime.Singleton);



//configure Identity

builder.Services.Configure<CookiePolicyOptions>(options =>
        {
            options.MinimumSameSitePolicy = SameSiteMode.Strict;
            options.OnAppendCookie = cookieContext =>
                CheckSameSite(cookieContext.Context, cookieContext.CookieOptions);
            options.OnDeleteCookie = cookieContext =>
                CheckSameSite(cookieContext.Context, cookieContext.CookieOptions);
        });

builder.Services.ConfigureApplicationCookie(config =>
{
    config.SlidingExpiration = true;
    config.ExpireTimeSpan = TimeSpan.FromHours(5);
    config.Cookie.MaxAge = TimeSpan.FromHours(5);
});

void CheckSameSite(HttpContext httpContext, CookieOptions options)
{
    options.SameSite = SameSiteMode.Strict;
}


// Add services to the container.
builder.Services.AddSignalR(options => { options.MaximumReceiveMessageSize = null; });
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();


//Third party app
builder.Services.AddSyncfusionBlazor();
builder.Services.AddBlazoredToast();
builder.Services.AddServerSideBlazor().AddCircuitOptions(options => { options.DetailedErrors = true; });
builder.Services.AddControllers().AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
builder.Services.AddScoped<IPrintingService, PrintingService>();
builder.Services.AddBlazorDownloadFile(ServiceLifetime.Scoped);
builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");
builder.Services.AddSingleton(typeof(ISyncfusionStringLocalizer), typeof(SampleLocalizer));
builder.Services.AddHttpContextAccessor();
builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    // Define the list of cultures your app will support
    var supportedCultures = new List<CultureInfo>()
    {
        new CultureInfo("en-US"),
    };

    // Set the default culture
    options.DefaultRequestCulture = new RequestCulture("en-US");

    options.SupportedCultures = supportedCultures;
    options.SupportedUICultures = supportedCultures;
    options.RequestCultureProviders = new List<IRequestCultureProvider>()
    {
        new QueryStringRequestCultureProvider() // Here, You can also use other localization provider
    };
});


//App version
HealthCare.UI.Version.Number = builder.Configuration.GetValue<string>("Version").ToString();

//dependency injection
builder.Services.AppService();
builder.Services.AppRepository();


builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.ExpireTimeSpan = TimeSpan.FromMinutes(20);
        options.SlidingExpiration = true;
        options.AccessDeniedPath = "/loginAccount";
    });

var app = builder.Build();


//Syncfusion licens
Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NzE3NDUyQDMyMzAyZTMyMmUzMFNuelhLb0dOVlgxMSsxMUdZMTJlaWdKTjJFV3ZvV2FvRHpGdmR6MjZ6Mms9");


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.UseHttpsRedirection();


app.UseWebSockets();


app.UseStaticFiles();


app.UseRouting();


app.UseAuthentication();
app.UseAuthorization();

app.UseCookiePolicy(new CookiePolicyOptions()
{
    MinimumSameSitePolicy = SameSiteMode.Strict,
});


app.UseEndpoints(endpoints =>
{
    endpoints.MapBlazorHub();
    endpoints.MapFallbackToPage("/_Host");
});


app.Run();

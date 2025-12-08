using ClinicalManagement.Domain.Entities;
using ClinicalManagement.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MudBlazor.Services;
using WebApi.Client.Pages;
using WebApi.Components;
using WebApi.Data;
using WebApi.Features;

var builder = WebApplication.CreateBuilder(args);

// Add MudBlazor services
builder.Services.AddMudServices();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveWebAssemblyComponents();
//========================================================================================
//DbContext for ApplicationDbContext and DefaultConnection
//========================================================================================

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ApplicationDbContext"))
);

builder.Services.AddQuickGridEntityFrameworkAdapter();

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

// If you have another DbContext, define it here:
builder.Services.AddDbContext<ClinicalContextDB>(options =>
   options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);
//========================================================================================
//Microsoft.AspNetCore.Identity
//========================================================================================
builder.Services.AddIdentity<ClinicalManagementUser, IdentityRole>(options =>
{
    options.Password.RequiredLength = 6;
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireUppercase = false;
    options.Password.RequireNonAlphanumeric = false;

    options.User.RequireUniqueEmail = true;
})
.AddEntityFrameworkStores<ApplicationDbContext>()
.AddDefaultTokenProviders();

//============================================
//Authentication and Cookies
//============================================

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/login";
    options.LogoutPath = "/logout";
    options.AccessDeniedPath = "/access-denied";
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
    app.UseExceptionHandler("/Home/Error", createScopeForErrors: true);
    app.UseHsts();
    app.UseMigrationsEndPoint();
    using var scope = app.Services.CreateScope();
    var dbContext = scope.ServiceProvider.GetRequiredService<ClinicalContextDB>();
    dbContext.Database.Migrate();

    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    if (!await roleManager.RoleExistsAsync(Roles.Admin))
    {

        await roleManager.CreateAsync(new IdentityRole(Roles.Admin));
    }
    if (!await roleManager.RoleExistsAsync(Roles.Member))
    {
        await roleManager.CreateAsync(new IdentityRole(Roles.Member));
    }
    // app.MapScalarApiReference();
    RegisterUser.MapEndpoint(app);
    LoginUser.MapEndpoint(app);
}


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
//app.UseAuthorization();

//========================================================================
//API Endpoints Mapper
//=========================================================================

//app.UseMigrationsEndPoint();
//app.MapRazorPages();
//app.MapControllers();
//app.MapBlazorHub();

//app.MapFallbackToPage("/_Host");

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(WebApi.Client._Imports).Assembly);

app.Run();

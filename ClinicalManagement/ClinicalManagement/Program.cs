using ClinicalBookingSystem.Data;
using ClinicalManagement.Application.Interfaces;
using ClinicalManagement.Client.Pages;
using ClinicalManagement.Components;
using ClinicalManagement.Domain.Entities;
using ClinicalManagement.Infrastructure.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using System.Reflection;
using ClinicalManagement.Components.Account;
using ClinicalManagement.Data;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using MudBlazor.Services;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

builder.Services.AddMudServices();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();


builder.Services.AddDbContext<ClinicalContextDB>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ApplicationDbContext")));

builder.Services.AddCascadingAuthenticationState();

builder.Services.AddScoped<IdentityUserAccessor>();

builder.Services.AddScoped<IdentityRedirectManager>();

builder.Services.AddScoped<AuthenticationStateProvider, IdentityRevalidatingAuthenticationStateProvider>();

builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = IdentityConstants.ApplicationScheme;
    options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
})
    .AddIdentityCookies();

builder.Services.AddIdentityCore<ClinicalManagementUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddSignInManager()
    .AddDefaultTokenProviders();

builder.Services.AddSingleton<IEmailSender<ClinicalManagementUser>, IdentityNoOpEmailSender>();


builder.Services.AddQuickGridEntityFrameworkAdapter();

builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddScoped<IBookingRepository, BookingRepository>();

//builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<Program>());
builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    // app.MapScalarApiReference();

}
app.UseMigrationsEndPoint();

app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(ClinicalManagement.Client._Imports).Assembly);

app.MapAdditionalIdentityEndpoints();;



app.Run();


//public static class AppointmentEndpoints
//{
//	public static void MapAppointmentEndpoints (this IEndpointRouteBuilder routes)
//    {
//        var group = routes.MapGroup("/api/Appointment").WithTags(nameof(Appointment));

//        group.MapGet("/", async (ClinicalContextDB db) =>
//        {
//            return await db.appointments.ToListAsync();
//        })
//        .WithName("GetAllAppointments");

//        group.MapGet("/{id}", async Task<Results<Ok<Appointment>, NotFound>> (Guid id, ClinicalContextDB db) =>
//        {
//            return await db.appointments.AsNoTracking()
//                .FirstOrDefaultAsync(model => model.Id == id)
//                is Appointment model
//                    ? TypedResults.Ok(model)
//                    : TypedResults.NotFound();
//        })
//        .WithName("GetAppointmentById");

//        group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (Guid id, Appointment appointment, ClinicalContextDB db) =>
//        {
//            var affected = await db.appointments
//                .Where(model => model.Id == id)
//                .ExecuteUpdateAsync(setters => setters
//                  .SetProperty(m => m.Id, appointment.Id)
//                  .SetProperty(m => m.PatientId, appointment.PatientId)
//                  .SetProperty(m => m.DoctorId, appointment.DoctorId)
//                  .SetProperty(m => m.ClinicId, appointment.ClinicId)
//                  .SetProperty(m => m.Phone, appointment.Phone)
//                  .SetProperty(m => m.AppointmentDate, appointment.AppointmentDate)
//                  .SetProperty(m => m.CreatedAt, appointment.CreatedAt)
//                  .SetProperty(m => m.EndTime, appointment.EndTime)
//                  .SetProperty(m => m.Status, appointment.Status)
//                  );
//            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
//        })
//        .WithName("UpdateAppointment");

//        group.MapPost("/", async (Appointment appointment, ClinicalContextDB db) =>
//        {
//            db.appointments.Add(appointment);
//            await db.SaveChangesAsync();
//            return TypedResults.Created($"/api/Appointment/{appointment.Id}",appointment);
//        })
//        .WithName("CreateAppointment");

//        group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (Guid id, ClinicalContextDB db) =>
//        {
//            var affected = await db.appointments
//                .Where(model => model.Id == id)
//                .ExecuteDeleteAsync();
//            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
//        })
//        .WithName("DeleteAppointment");
//    }
//}
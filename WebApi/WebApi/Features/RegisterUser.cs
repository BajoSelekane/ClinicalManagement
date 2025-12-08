using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ClinicalManagement.Domain.Entities;
using WebApi.Data;

namespace WebApi.Features
{
    public static class RegisterUser
    {
       
        public record Request(string Email,string Initials, string Password,bool EmailNotification=false);

        public static void MapEndpoint(IEndpointRouteBuilder app)
        {

            app.MapPost("register", async (
              Request request,
              ApplicationDbContext dbContext,
              UserManager<ClinicalManagementUser> userManager) =>
            {
                using var transaction = await dbContext.Database.BeginTransactionAsync();

                var user = new ClinicalManagementUser
                {
                    UserName = request.Email,
                    Email = request.Email,
                    Initials = request.Initials,
                    EnanbleNotification = request.EmailNotification
                };

                IdentityResult identityResult = await userManager.CreateAsync(user, request.Password);
                if (!identityResult.Succeeded)
                {
                    return Results.BadRequest(identityResult.Errors);
                }

                IdentityResult addToRoleResult = await userManager.AddToRoleAsync(user, Roles.Member);
                if (!addToRoleResult.Succeeded)
                {
                    return Results.BadRequest(addToRoleResult.Errors);

                }
                await transaction.CommitAsync();
                return Results.Ok(user);
            });
                
            

        }
    }
}

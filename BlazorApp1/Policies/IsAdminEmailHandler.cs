using System.Security.Claims;
using BlazorApp1.Policies;
using Microsoft.AspNetCore.Authorization;

public class IsAdminEmailHandler : AuthorizationHandler<IsAdminEmailRequirement>
{
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, IsAdminEmailRequirement requirement)
    {
        if (!context.User.HasClaim(c => c.Type == "preferred_username"))
        {
            return Task.CompletedTask;
        }
        
        var emailAddress = context.User.FindFirst(c => c.Type == "preferred_username").Value;
        
        if (emailAddress == requirement.AdminEmail)
        {
            context.Succeed(requirement);
        }
        
        return Task.CompletedTask;
    }
}
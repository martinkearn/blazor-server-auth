using Microsoft.AspNetCore.Authorization;

namespace BlazorApp1.Policies
{
    public class IsAdminEmailRequirement : IAuthorizationRequirement
{
    public string AdminEmail { get; }

    public IsAdminEmailRequirement(string adminEmail)
    {
        AdminEmail = adminEmail;
    }
}
}
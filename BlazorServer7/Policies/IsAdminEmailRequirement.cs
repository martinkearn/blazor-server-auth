using Microsoft.AspNetCore.Authorization;

namespace blazor_server_auth.Policies
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

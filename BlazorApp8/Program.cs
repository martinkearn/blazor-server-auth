using BlazorApp8.Components;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.Identity.Web;
using Microsoft.Identity.Web.UI;

var builder = WebApplication.CreateBuilder(args);

//Auth services
builder.Services.AddAuthentication(OpenIdConnectDefaults.AuthenticationScheme)
    .AddMicrosoftIdentityWebApp(builder.Configuration.GetSection("AzureAdB2C"));
builder.Services.AddControllersWithViews()
    .AddMicrosoftIdentityUI();
builder.Services.AddCascadingAuthenticationState();


// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddMicrosoftIdentityConsentHandler();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();
app.UseRouting();
app.UseAuthorization();
app.UseAntiforgery();
app.MapControllers();

// Redirect default built-in signed out page to root
app.UseRewriter(new RewriteOptions().Add(
    context =>
    {
        if (context.HttpContext.Request.Path == "/MicrosoftIdentity/Account/SignedOut")
        {
            context.HttpContext.Response.Redirect("/");
        }
    }));

app.Run();

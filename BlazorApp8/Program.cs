using BlazorApp8.Components;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.Identity.Web;
using Microsoft.Identity.Web.UI;

//Provided by template
var builder = WebApplication.CreateBuilder(args);

//Reads the app settings for AzureAdB2C and registers an authentication service
builder.Services.AddAuthentication(OpenIdConnectDefaults.AuthenticationScheme)
    .AddMicrosoftIdentityWebApp(builder.Configuration.GetSection("AzureAdB2C"));

//AddMicrosoftIdentityUI adds the razor pages used for account management, login etc
builder.Services.AddControllersWithViews()
    .AddMicrosoftIdentityUI();

//Adds CascadingAuthenticationState to service collection to avoid having it in razor.
//CascadingAuthenticationState exposes authentication data to razor pages and enables things like AuthorizeView
builder.Services.AddCascadingAuthenticationState();

//Required for Microsoft.Identity.Web.UI
//Based on https://github.com/dotnet/aspnetcore/issues/52245
builder.Services.AddRazorPages();

//Provided by template
// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

//Provided by template
var app = builder.Build();

//Provided by template
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//Provided by template
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

//Provided by template
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

//Provided by template
app.Run();

using PineappleFanSite;
using PineappleFanSite.Data;
using PineappleFanSite.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Builder;
//using Microsoft.AspNetCore.Identity.UI.Services;

var builder = WebApplication.CreateBuilder(args);

var connectionString =
    builder.Configuration.GetConnectionString("MySqlConnection");

//builder.Services.AddScoped<IRegistryRepository, RegistryRepository>();
builder.Services.AddDbContext<AppDbContext>(options =>
options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

// Adding identity services
//builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    //.AddEntityFrameworkStores<AppDbContext>();

builder.Services.AddTransient<IRegistryRepository, RegistryRepository>();

// Add services to the container.
builder.Services.AddControllersWithViews();

//builder.Services.AddIdentityCore<AppUser>(options => options.SignIn.RequireConfirmedAccount = true)
//    .AddUserManager<UserManager<Register>>()
//    .AddEntityFrameworkStores<AppDbContext>();

builder.Services.AddIdentity<AppUser, IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddSignInManager<SignInManager<AppUser>>()
    .AddDefaultTokenProviders();

//builder.Services.AddMvc(options =>
//{
    // Redirect unauthenticated users to your custom login page
    //options.Filters.Add(new AuthorizeFilter("/Register/Login"));
//});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    var signInManager = scope.ServiceProvider.GetRequiredService<SignInManager<AppUser>>();
    //var seedData = new SeedData(userManager);
    SeedData.Seed(dbContext, scope.ServiceProvider);
}

//void Configure(IApplicationBuilder app, IWebHostEnvironment env, AppDbContext context)
//{
    //if (env.IsDevelopment())
    //{
       // app.UseDeveloperExceptionPage();
        // var scopeFactory = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>();
        // using (var scope = scopeFactory.CreateScope())
        // {
            // var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            // var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
            // var seedData = new SeedData(userManager);
            // SeedData.Seed(dbContext, scope.ServiceProvider).Wait();
        // }
    // }
//}

app.Run();

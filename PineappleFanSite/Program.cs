using PineappleFanSite.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

var connectionString =
    builder.Configuration.GetConnectionString("MySqlConnection");

//builder.Services.AddScoped<IRegistryRepository, RegistryRepository>();
builder.Services.AddDbContext<AppDbContext>(options =>
options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

// Adding identity services
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>();

builder.Services.AddTransient<IRegistryRepository, RegistryRepository>();

// Add services to the container.
builder.Services.AddControllersWithViews();

var userManager = builder.Services.GetRequiredService<UserManager<IdentityUser>>();
var roleManager = builder.Services.GetRequiredService<RoleManager<IdentityRole>>();

var adminRole = new IdentityRole("Admin");
await roleManager.CreateAsync(adminRole);

var adminUser = new IdentityUser
{
    UserName = "admin@example.com",
    Email = "admin@example.com"
};
await userManager.CreateAsync(adminUser, "Password123!");
await userManager.AddToRoleAsync(adminUser, "Admin");

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
    var seedData = new SeedData(userManager);
    await seedData.Seed(dbContext);
}

void Configure(IApplicationBuilder app, IWebHostEnvironment env, AppDbContext context)
{
    if (env.IsDevelopment())
    {
        app.UseDeveloperExceptionPage();
        var scopeFactory = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>();
        using (var scope = scopeFactory.CreateScope())
        {
            var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
            var seedData = new SeedData(userManager);
            seedData.Seed(dbContext).Wait();
        }
    }
}

app.Run();

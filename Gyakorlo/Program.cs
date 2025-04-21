using Gyakorlo.Controllers;
using Gyakorlo.Data;
using Gyakorlo.Models;
using Gyakorlo.Models.Home;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Rotativa.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IHomeModel, HomeModel>();
builder.Services.AddScoped<IAppRepo, AppRepo>();
builder.Services.AddScoped<IUserClaimsPrincipalFactory<Felhasznalo>, CustomClaimsPrincipalFactory>();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<Felhasznalo, IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();


// Irányítsd át egy saját oldalra ha nem megfelelõ a jogosúltság
builder.Services.ConfigureApplicationCookie(options =>
{
    options.ExpireTimeSpan = TimeSpan.FromMinutes(10);
    options.SlidingExpiration = true;
    options.Cookie.IsEssential = true;
    options.Cookie.HttpOnly = true;
    options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
    options.Cookie.Expiration = null; // fontos!
    options.LoginPath = "/Bejelentkezes";
    options.AccessDeniedPath = "/";
});


builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequiredLength = 5;
    options.Password.RequiredUniqueChars = 1;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();
//RotativaConfiguration.Setup(app.Environment.WebRootPath, "Rotativa");
app.UseRotativa();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>();
    context.Database.Migrate();  // Adatbázis migrálása, ha szükséges
    var userManager = services.GetRequiredService<UserManager<Felhasznalo>>();
    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

    // Role-ok és alapfelhasználó hozzáadása
    var roleNames = new[] { "tanar", "diak" };

    foreach (var roleName in roleNames)
    {
        var roleExist = await roleManager.RoleExistsAsync(roleName);
        if (!roleExist)
        {
            await roleManager.CreateAsync(new IdentityRole(roleName));
        }
    }  // Role-ok és alapfelhasználó hozzáadása
}

app.UseAuthentication();
app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{action=Index}",
    defaults: new {controller = "Home"})
    .WithStaticAssets();

app.MapControllerRoute(
    name: "matematika",
    pattern: "{action}/{controller}/{osztaly:int}-Osztaly")
    .WithStaticAssets();

app.Run();

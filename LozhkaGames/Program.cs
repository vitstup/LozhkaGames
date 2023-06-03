using LozhkaGames;
using LozhkaGames.Interfaces;
using LozhkaGames.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<IUsersRepository, UsersRepository>();
builder.Services.AddTransient<IGamesRepository, GamesRepository>();
builder.Services.AddTransient<IKeysRepository, KeysRepository>();

//builder.Services.AddDbContext<ShopDbContext>(options => options.UseSqlServer("Server=DESKTOP-ANKHDH7;Database=LozhkaGamesDatabase;Trusted_Connection=True;TrustServerCertificate=true;"));
builder.Services.AddDbContext<ShopDbContext>(options =>
    options.UseSqlServer("Server=95.140.157.189;Database=LozhkaGamesDatabase;User Id=sa;Password=Abdula777999;TrustServerCertificate=True;"));

builder.Services.AddSession(options =>
{
    options.Cookie.Name = "MyApp.Session";
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Время истечения сеанса
    options.Cookie.HttpOnly = true; // Ограничить доступ к cookie из JavaScript
    options.Cookie.SameSite = SameSiteMode.Strict; // Установить значение SameSite
    options.Cookie.SecurePolicy = CookieSecurePolicy.Always; // Требовать использование HTTPS
});

builder.Services.AddHttpContextAccessor();

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

app.UseSession();

app.UseRouting();

app.UseStaticFiles();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "homeGame",
        pattern: "/Game/{id}",
        defaults: new { controller = "Home", action = "Game" });
    endpoints.MapDefaultControllerRoute();
});

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "gamesDetails",
        pattern: "/Details/{details}",
        defaults: new { controller = "Games", action = "Details" });
    endpoints.MapDefaultControllerRoute();
});

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "faq",
        pattern: "Faq",
        defaults: new { controller = "Faq", action = "Index" });

    endpoints.MapDefaultControllerRoute();
});

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);

// key generator
/*using (var scope = (app as IApplicationBuilder).ApplicationServices.CreateScope())
{
    ShopDbContext context = scope.ServiceProvider.GetRequiredService<ShopDbContext>();
    SteamKeysGenerator keysGenerator = new SteamKeysGenerator(context);
    keysGenerator.GenerateKeysForAllGames(50);
}*/

app.Run();
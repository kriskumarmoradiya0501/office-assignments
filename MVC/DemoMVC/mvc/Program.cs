using Npgsql;
using Repositories;
using Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddSession();

builder.Services.AddScoped<IUserInterface, UserRepository>();
builder.Services.AddScoped<IContactInterface, ContactRepository>();
builder.Services.AddScoped<NpgsqlConnection>(serviceProvider =>
{
    var configuration = serviceProvider.GetRequiredService<IConfiguration>();

    return new NpgsqlConnection(
        configuration.GetConnectionString("pgconn")
    );
});

var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.UseSession();

app.MapControllerRoute(
    name : "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);

app.Run();
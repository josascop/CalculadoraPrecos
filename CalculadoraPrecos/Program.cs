using Microsoft.EntityFrameworkCore;
using CalculadoraPrecos.Data;
using CalculadoraPrecos.Services;
using Microsoft.Data.Sqlite;

var builder = WebApplication.CreateBuilder(args);

var conexao = new SqliteConnection(
    $"Data Source={Path.Join("C:", "Users", "Eu", "Desktop", "db", "dbprodutos.db")}");

builder.Services.AddDbContext<CalculadoraPrecosContext>(options =>
    options.UseSqlite(conexao));

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<ProdutoService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment()) {
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

app.Run();

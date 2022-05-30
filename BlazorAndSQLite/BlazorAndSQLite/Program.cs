using BlazorAndSQLite;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.EntityFrameworkCore;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

// Get connection string from appsettings.json
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Add a AddDbContextFactory service, and pass the database name to SQLite.
builder.Services.AddDbContextFactory<ApplicationDbContext>(options => options.UseSqlite(connectionString));

// Get an instance of the DbContextFactory service.
var dbContextFactory = builder.Services.BuildServiceProvider().GetService<IDbContextFactory<ApplicationDbContext>>();

// Use the DbContextFactory service to create a DbContext.
var dbContext = dbContextFactory?.CreateDbContext();

// Use the just created DbContext to create the database.
dbContext?.Database.EnsureCreated();

await builder.Build().RunAsync();

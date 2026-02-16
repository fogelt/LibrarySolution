using Library.Data;
using Library.Web.Components;
using Library.Web.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// 2. Add DB Context Factory (Ensure this is here!)
builder.Services.AddDbContextFactory<LibraryDbContext>(options =>
    options.UseSqlite("Data Source=library.db"));

// 3. REGISTER THE LIBRARY SERVICE <--- THIS IS THE MISSING PIECE
builder.Services.AddScoped<LibraryService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();

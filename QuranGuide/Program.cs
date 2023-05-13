using Microsoft.Extensions.Configuration;
using QuranGuide.Data;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<QuranContext>(options =>
                    {
                        options.UseSqlServer(builder.Configuration["ConnectionStrings:QuranConnection"]);
                        options.EnableSensitiveDataLogging(true);

                    });

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

//builder.Services.AddScoped<DbContext, QuranContext>();


builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient();

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
    pattern: "{controller=Search}/{action=search_verse}/{id?}");



ReadData.fill_database_if_empty(app);
app.Run();

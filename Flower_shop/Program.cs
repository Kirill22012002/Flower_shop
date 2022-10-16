using Flower_shop;
using Flower_shop.EfStuff;
using Flower_shop.EfStuff.Repositories;
using Flower_shop.Services;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
var connectString =
    @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DbStore;Integrated Security=True;";
builder.Services.AddDbContext<WebDbContext>(x => x.UseSqlServer(connectString));

var authName = builder.Configuration.GetConnectionString("AuthName");

builder.Services.AddAuthentication(builder.Configuration.GetConnectionString("AuthName"))
    .AddCookie(builder.Configuration.GetConnectionString("AuthName"), config =>
    {
        config.LoginPath = "/Authentication/Autorization";
        config.AccessDeniedPath = "/Authentication/AccessDenied";
        config.Cookie.Name = "CoockieCool";
    });

builder.Services.AddAutoMapper(typeof(AppMappingProfile));

builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<TypeProductService>();
builder.Services.AddScoped<ProductRepository>();
builder.Services.AddScoped<TypeProductRepository>();
builder.Services.AddScoped<ImageRepository>();
builder.Services.AddScoped<UserRepository>();

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

// Who I am
app.UseAuthentication();

// Where could I go 
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Index}/{action=Index}/{id?}");
});

app.MapRazorPages();

app.Run();

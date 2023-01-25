using Serilog;
using Serilog.Events;

var builder = WebApplication.CreateBuilder(args);


const string logTemplate = @"{Timestamp:yyyy-MM-dd HH:mm:ss} [{Level:u4}] [{SourceContext:l}] {Message:lj}{NewLine}{Exception}";
Log.Logger = new LoggerConfiguration()
        .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
        .Enrich.FromLogContext()
        .WriteTo.File("Logs/log.txt", LogEventLevel.Information, logTemplate, rollingInterval: RollingInterval.Day)
        .WriteTo.File("Logs/error.txt", LogEventLevel.Error, logTemplate, rollingInterval: RollingInterval.Day)
        .CreateLogger();

builder.Logging.ClearProviders();

builder.Services.AddLogging(loggingBuilder => 
            loggingBuilder.AddSerilog(dispose: true));

builder.Services.AddMvc();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication(builder.Configuration.GetConnectionString("AuthName"))
    .AddCookie(builder.Configuration.GetConnectionString("AuthName"), config =>
    {
        config.LoginPath = "/Authentication/Autorization";
        config.AccessDeniedPath = "/Authentication/AccessDenied";
        config.Cookie.Name = "CoockieCool";
    });

builder.Services.AddDbContext<WebDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("FlowerShopDbContext")));

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ITypeProductService, TypeProductService>();
builder.Services.AddScoped<IColorSettingsService, ColorSettingsService>();
builder.Services.AddScoped<IImageRepository, ImageRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ITypeProductRepository, TypeProductRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IColorRepository, ColorRepository>();
builder.Services.AddScoped<ISeedData, SeedData>();

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

IMapper mapper = MappingConfig.RegisterMaps().CreateMapper();
builder.Services.AddSingleton(mapper);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
}

app.UseHsts();

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

var scopeFactory = app.Services.GetRequiredService<IServiceScopeFactory>();

using(var scope = scopeFactory.CreateScope())
{
    var seedData = scope.ServiceProvider.GetService<ISeedData>();
    seedData.Seed();
}

app.MapRazorPages();

app.Run();

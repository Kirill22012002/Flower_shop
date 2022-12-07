var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMvc();

builder.Services.AddAuthentication(builder.Configuration.GetConnectionString("AuthName"))
    .AddCookie(builder.Configuration.GetConnectionString("AuthName"), config =>
    {
        config.LoginPath = "/Authentication/Autorization";
        config.AccessDeniedPath = "/Authentication/AccessDenied";
        config.Cookie.Name = "CoockieCool";
    });

builder.Services.AddDbContext<WebDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("FlowerShopDbContext")));

builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<TypeProductService>();
builder.Services.AddScoped<IImageRepository, ImageRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ITypeProductRepository, TypeProductRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

IMapper mapper = MappingConfig.RegisterMaps().CreateMapper();
builder.Services.AddSingleton(mapper);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
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

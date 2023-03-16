using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MovieStoreMvc.Repositories.Implementation;
using MvcFoodRecipe.Models.Domain;
using MvcFoodRecipe.Repositories.Abstract;
using MvcFoodRecipe.Repositories.Implementation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
/*builder.Services.AddScoped<IUserAuthenticationService, UserAuthenticationService>();*/
builder.Services.AddScoped<IFileService, FileService>();
builder.Services.AddScoped<IFoodService, FoodService>();


/*builder.Services.AddDbContext<DatabaseContext>(options =>
               options.UseSqlServer(builder.Configuration.GetConnectionString("Connect") ?? throw new InvalidOperationException("Connection string 'DatabaseContext' not found.")));*/
builder.Services.AddDbContext<DatabaseContext>(options =>
{
    var defaultConn = builder.Configuration.GetSection("ConnectionString")["Connect"];
    options.UseSqlServer(defaultConn);
});

// For Identity  
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<DatabaseContext>()
    .AddDefaultTokenProviders();

//builder.Services.ConfigureApplicationCookie(options => options.LoginPath = "/UserAuthentication/Login");


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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

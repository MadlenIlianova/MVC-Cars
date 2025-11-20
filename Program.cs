using Microsoft.EntityFrameworkCore;
using WebApplication2.Services;
using WebDbContext;
using Microsoft.AspNetCore.Identity;

public class Program
{
    private static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
       

        builder.Services.AddDbContext<WebDbContext.AppDbContext>(options =>
            options.UseSqlServer(
                builder.Configuration.GetConnectionString("DefaultConnection"),
                b => b.MigrationsAssembly("WebDbContext")
        ));

        builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<AppDbContext>();

        

        builder.Services.AddScoped<ICarsService, CarApiService>();
        //builder.Services.AddScoped<DataSeed>();
        builder.Services.AddControllersWithViews();
        builder.Services.AddRazorPages();
        var app = builder.Build();

        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseRouting();
        app.UseAuthentication();
        app.UseAuthorization();
        app.MapRazorPages();
        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Cars}/{action=Search}/{id?}");
        app.Run();
    }
}


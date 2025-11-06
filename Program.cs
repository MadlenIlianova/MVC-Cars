using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.Extensions.Options;
using WebApplication2.Controllers;
using WebApplication2.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.Configure<AppOptions>(
    builder.Configuration.GetSection(AppOptions.ApiKeys));


builder.Services.AddSingleton(resolver =>
    resolver.GetRequiredService<IOptions<AppOptions>>().Value);


builder.Services.AddHttpClient<CarApiService>((serviceProvider, client) =>
{
    var options = serviceProvider.GetRequiredService<AppOptions>();
    if (!string.IsNullOrEmpty(options.Url))
        client.BaseAddress = new Uri(options.Url);
});


builder.Services.AddScoped<CarApiService>();

builder.Services.AddControllersWithViews();

var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
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
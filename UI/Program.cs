using System.Globalization;
using UI.Utils.Localization;

namespace UI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews().AddViewLocalization();
            builder.Services.AddLocalization(options =>
            {
                options.ResourcesPath = "Resources";
            });
            builder.Services.Configure<RequestLocalizationOptions>(options =>
            {
                options.DefaultRequestCulture = new("tr-TR");

                CultureInfo[] cultures = new CultureInfo[]
                {
                    new("tr-TR"),
                    new("en-US"),
                };
                options.SupportedCultures = cultures;
                options.SupportedUICultures = cultures;
            });
            builder.Services.AddScoped<RequestLocalizationCookiesMiddleware>();
            builder.Services.AddSingleton<Localization>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseRequestLocalization();
            app.UseRequestLocalizationCookies();

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.Services.GetService<Localization>(); //Auto activate
            app.Run();
        }
    }
}
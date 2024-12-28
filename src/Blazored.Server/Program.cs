using Blazored.Shared;
using Microsoft.AspNetCore.Hosting.StaticWebAssets;

namespace Blazored.Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //// Add services to the container.
            //builder.Services.AddRazorComponents()
            //    .AddInteractiveServerComponents();

            StaticWebAssetsLoader.UseStaticWebAssets(builder.Environment, builder.Configuration);

            // Add services to the container.
            builder.Services.AddRazorPages();

            builder.Services.AddHttpClient();
            builder.Services.AddServerSideBlazor();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            #if NET8_0
            app.UseStaticFiles();
            #else
            app.MapStaticAssets();
            #endif

            app.UseRouting();
            //app.UseAntiforgery();

            app.MapBlazorHub();
            app.MapFallbackToPage("/_Host");

            //app.MapRazorComponents<App>()
            //    .AddInteractiveServerRenderMode();

            app.Run();
        }
    }
}

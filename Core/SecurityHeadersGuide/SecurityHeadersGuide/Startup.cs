using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace SecurityHeadersGuide
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();

            // take full control of X-Frame-Options header setting
            services.AddAntiforgery(options =>
            {
                options.SuppressXFrameOptionsHeader = true;
            });

            // customize Strict-Transport-Security header value to avoid
            // issues when developing locally
            services.AddHsts(options =>
            {
                options.IncludeSubDomains = true;
                options.MaxAge = TimeSpan.FromDays(365);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");

                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            // adding headers in middleware
            app.Use(async (context, next) =>
            {
                if (!context.Response.Headers.ContainsKey("Header-Name"))
                {
                    context.Response.Headers.Add("Header-Name", "Header-Value");
                }

                await next();
            });

            // tell any client that framing isn't allowed
            app.Use(async (context, next) =>
            {
                context.Response.Headers.Add("X-Frame-Options", "DENY");
                await next();
            });

            // cause most modern browsers to stop loading the page when a cross-site scripting
            // attack is identified (1 means enabled, block blocks browser rendering)
            app.Use(async (context, next) =>
            {
                context.Response.Headers.Add("X-Xss-Protection", "1; mode=block");
                await next();
            });

            // prevent primarily old browsers from MIME-sniffing
            app.Use(async (context, next) =>
            {
                context.Response.Headers.Add("X-Content-Type-Options", "nosniff");
                await next();
            });

            // disable calling URL automatically transferring to a linked site
            app.Use(async (context, next) =>
            {
                context.Response.Headers.Add("Referrer-Policy", "no-referrer");
                await next();
            });

            // disable the possibility of Flash making cross-site requests
            app.Use(async (context, next) =>
            {
                context.Response.Headers.Add("X-Permitted-Cross-Domain-Policies", "none");
                await next();
            });

            // tell which platform features this site needs
            app.Use(async (context, next) =>
            {
                context.Response.Headers.Add("Feature-Policy", "accelerometer 'none'; camera 'none'; geolocation 'none'; gyroscope 'none'; magnetometer 'none'; microphone 'none'; payment 'none'; usb 'none'");
                await next();
            });

            // helps to prevent code injection attacks like cross-site scripting and clickjacking, 
            // by telling the browser which dynamic resources that are allowed to load
            app.Use(async (context, next) =>
            {
                context.Response.Headers.Add("Content-Security-Policy", "default-src 'self'");
                await next();
            });

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}

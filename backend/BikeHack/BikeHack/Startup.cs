using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;

namespace BikeHack
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
            services.AddMvc();
            CloudStorageAccount storageAccount = null;
            var connectionString = Configuration.GetConnectionString("bikehackstorage");
            if (connectionString == null)
            {
                var accountName = Configuration["storage-account-name"];
                var accountKey = Configuration["storage-account-key"];
                var credentials = new StorageCredentials(accountName, accountKey);
                storageAccount = new CloudStorageAccount(credentials, true);
            }
            else
            {
                storageAccount = CloudStorageAccount.Parse(connectionString);
            }
            var bikeStorage = new BikeStorage(storageAccount);
            var tripStorage = new TripStorage(storageAccount);
            services.AddSingleton(bikeStorage);
            services.AddSingleton(tripStorage);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}

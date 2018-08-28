using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using AnimalSalvationArmy.Services.AnimalShelterServices;
using AnimalSalvationArmy.Services.PetService;
using AnimalSalvationArmy.Services.ShelterWorkerService;
using AnimalSalvationArmy.Services.ShelterWorker;
using AnimalSalvationArmy.DataAccessLayer;
using AnimalSalvationArmy.DataAccessLayer.DataHelpers;

namespace AnimalSalvationArmyShelters
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            ConfigureAnimalShelterServices(services);
        }

        public void ConfigureAnimalShelterServices(IServiceCollection services)
        {
            services.AddScoped<IAnimalShelterServices, AnimalShelterServices>();
            services.AddScoped<IPetService, PetService>();
            services.AddScoped<IShelterWorkerService, ShelterWorkerService>();
            services.AddSingleton<AnimalShelterApplicationDataStore, AnimalShelterApplicationDataStore>();
            services.AddScoped<IUniqueIdentityGenerator, UniqueIdentityGenerator>();
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}

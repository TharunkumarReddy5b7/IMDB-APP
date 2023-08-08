using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using MovieApi.Helpers;
using MovieApi.Repositories;
using MovieApi.Repositories.Interfaces;
using MovieApi.Services;
using MovieApi.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApi
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

            services.AddControllers();
            services.AddSingleton<IActorService, ActorService>();

            services.Configure<ConnectionString>(Configuration.GetSection(key: "ConnectionString"));

            services.AddSingleton<IActorRepository, ActorRepository>();

            services.AddSingleton<IProducerService, ProducerService>();

            services.AddSingleton<IProducerRepository, ProducerRepository>();

            services.AddSingleton<IGenreService, GenreService>();

            services.AddSingleton<IGenreRepository, GenreRepository>();

            services.AddSingleton<IMovieService, MovieService>();

            services.AddSingleton<IMovieRepository, MovieRepository>();

            services.AddSingleton<IReviewService, ReviewService>();

            services.AddSingleton<IReviewRepository, ReviewRepository>();

            services.AddAutoMapper(typeof(Startup));


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

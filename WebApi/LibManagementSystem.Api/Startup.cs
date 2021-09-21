using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper.Internal;
using LibManagementSystem.Infrastructure;
using LibManagementSystem.Infrastructure.Services;
using LibraryManagementSystem.Domain.Repositories;
using LibraryManagementSystem.Infrastructure.Data;
using LibraryManagementSystem.Infrastructure.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;

namespace LibManagementSystem
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
            services.AddMvc(option => option.EnableEndpointRouting = false)
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
                .AddNewtonsoftJson(opt => opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);

            services.AddDbContext<LibraryManagementDbContext>(options =>
                //options.UseSqlServer(Configuration.GetConnectionString("MYSQL_CON")));
                options.UseMySql(Configuration.GetConnectionString("MYSQL_CON"),
                    ServerVersion.AutoDetect(Configuration.GetConnectionString("MYSQL_CON"))));
            services.AddTransient<LibraryManagementDbContext>();
            services.AddTransient<IBookRepository, BookRepository>();
            services.AddTransient<IAuthorRepository, AuthorRepository>();
            services.AddTransient<IIssuedRepository, IssuedRepository>();
            services.AddTransient<IMemberRepository, MemberRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddScoped<Seeder>();
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IMemberService, MemberService>();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            
            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.WithOrigins("https://lib-management-web.herokuapp.com")
                    .AllowAnyHeader()
                    .AllowAnyMethod();
            }));
            
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "LibManagementSystem.Api", Version = "v1"});
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, Seeder seeder)
        {
            seeder.Seed();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "LibManagementSystem.Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors("MyPolicy"); 
            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}
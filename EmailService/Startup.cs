using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using EmailService.Common;
using EmailService.Common.DataClasses;
using EmailService.Common.Interfaces;
using EmailService.Database;
using EmailService.Domain.Entities;
using EmailService.Database.Queries.Emails;
using EmailService.Database.Requests.Emails;
using EmailService.Filters;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Serilog;

namespace EmailService
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
            services.AddControllers(options=> { options.Filters.Add<ValidationFilter>(); }).
                AddFluentValidation(configuration => configuration.RegisterValidatorsFromAssemblyContaining<Startup>());
            services.AddDbContext<ServiceContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddMediatR(typeof(Startup));
            services.AddSingleton<IEmailSender,EmailSender>();
            services.AddSingleton<ISMTPData, SMTPData>();
            services.AddSingleton<IMapper<CreateEmailRequest, Email>, CreateEmailRequestToEmailMapper>();
            services.AddScoped<IEmailRepository,EmailRepository>();
            services.AddSwaggerGen(c =>
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "Email Microservice", Version = "v1"}));
            // Read the connection string from appsettings.
            string dbConnectionString = this.Configuration.GetConnectionString("DefaultConnection");

            // Inject IDbConnection, with implementation from SqlConnection class.
            services.AddTransient<IDbConnection>((sp) => new SqlConnection(dbConnectionString));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Email Microservice"));

            app.UseSerilogRequestLogging();

            app.UseRouting();
            
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService <ServiceContext> ();
                context.Database.Migrate();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using eBus.WebApi.Database;
using eBus.WebApi.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

using eBus.Model.Requests;
using Microsoft.AspNetCore.Authentication;
using eBus.WebApi.Security;
using System.ComponentModel;
using eBus.WebApi.Filters;

namespace eBus.WebApi
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
            

            services.AddMvc(x => x.Filters.Add<ErrorFilter>()).AddRazorPagesOptions(options =>
            {
                options.Conventions.AddPageRoute("/Swagger", "");
            });

           

            var connection = Configuration.GetConnectionString("eBus");
            services.AddDbContext<_170048Context>(options => options.UseSqlServer(connection));

            services.AddAuthentication("BasicAuthentication")
               .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);

           

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "TheCodeBuzz-Service", Version = "v1" });

                c.AddSecurityDefinition("basic", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = "basic",
                    In = ParameterLocation.Header,
                    Description = "Basic Authorization header using the Bearer scheme."
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                          new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "basic"
                                }
                            },
                            new string[] {}
                    }
                });

            });

            services.AddAutoMapper(typeof(_170048Context));

            //services.AddScoped<IKorisniciService, KorisniciService>();
            services.AddScoped<IPreporukaService, PreporukaService>();
            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<IKorisniciService, KorisniciService>();
            
            services.AddScoped<ICRUDService<Model.Angazuje, AngazujeSearchRequest, AngazujeUpsertRequest, AngazujeUpsertRequest>, AngazujeService>();
            services.AddScoped<ICRUDService<Model.Drzava, DrzavaSearchRequest, DrzavaUpsertRequest, DrzavaUpsertRequest>, DrzavaService>();
            services.AddScoped<ICRUDService<Model.Grad, GradSearchRequest, GradUpsertRequest, GradUpsertRequest>, GradService>();
            services.AddScoped<IService<Model.Uloga, object>, BaseService<Model.Uloga, object, Database.Uloga>>();
            services.AddScoped<ICRUDService<Model.Cijena, CijenaSearchRequest, CijenaUpsertRequest, CijenaUpsertRequest>, CijenaService>();
            services.AddScoped<ICRUDService<Model.Kompanija, KompanijaSearchRequest, KompanijaUpsertRequest, KompanijaUpsertRequest>, KompanijaService>();
            services.AddScoped<ICRUDService<Model.Karta, KartaSearchRequest, KartaUpsertRequest, KartaUpsertRequest>, KartaService>();
            services.AddScoped<ICRUDService<Model.Linija, LinijaSearchRequest, LinijaUpsertRequest, LinijaUpsertRequest>, LinijaService>();
            services.AddScoped<ICRUDService<Model.Notifikacije, NotifikacijeSearchRequest, NotifikacijaUpsertRequest, NotifikacijaUpsertRequest>, NotifikacijaService>();
            services.AddScoped<ICRUDService<Model.Novosti, NovostiSearchRequest, NovostiUpsertRequest, NovostiUpsertRequest>, NovostiService>();
            services.AddScoped<ICRUDService<Model.Ocjena, OcjenaSearchRequest, OcjenaUpsertRequest, OcjenaUpsertRequest>, OcjenaService>();
            services.AddScoped<ICRUDService<Model.Putnik, PutnikSearchRequest, PutnikUpsertRequest, PutnikUpsertRequest>, PutnikService>();
            services.AddScoped<ICRUDService<Model.Rezervacija, RezervacijaSearchRequest, RezervacijaUpsertRequest, RezervacijaUpsertRequest>, RezervacijaService>();
            services.AddScoped<ICRUDService<Model.Sjediste, SjedisteSearchRequest, SjedisteUpsertRequest, SjedisteUpsertRequest>, SjedisteService>();
            services.AddScoped<ICRUDService<Model.Vozilo, VoziloSearchRequest, VoziloUpsertRequest, VoziloUpsertRequest>, VoziloService>();
            services.AddScoped<ICRUDService<Model.PutnikNotifikacije, PutnikNotifikacijeSearchRequest, PutnikNotifikacijeUpsertRequest, PutnikNotifikacijeUpsertRequest>, PutnikNotifikacijeService>();


            //services.AddCors(c =>
            //{
            //    c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin());
            //    c.AddPolicy("AllowHeader", options => options.AllowAnyHeader());
            //    c.AddPolicy("AllowMethod", options => options.AllowAnyMethod());

            //});

            // Enable CORS
            services.AddCors(options =>
            {
                options.AddPolicy("EnableCORS", builder =>
                {
                    builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod().Build();
                });
            });

            services.AddControllers().AddNewtonsoftJson(options =>
                 options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
        }

        // This method gets called by the runtime. Use this method to configure thet HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            app.UseCors("EnableCORS");


            app.UseAuthentication();
            app.UseRouting();

            app.UseAuthorization();

            //app.UseCors(options => options.AllowAnyOrigin());           // ovo sad dodao radi angulara
            //app.UseCors(options => options.AllowAnyHeader());           // ovo sad dodao radi angulara
            //app.UseCors(options => options.AllowAnyMethod());           // ovo sad dodao radi angulara

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

           // app.UseHttpsRedirection();
            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

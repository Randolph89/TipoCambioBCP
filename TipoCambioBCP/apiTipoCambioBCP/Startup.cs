using apiTipoCambioBCP.Context;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System;
using apiTipoCambioBCP.Service.Interfaces;
using apiTipoCambioBCP.Service.Implementatios;
using apiTipoCambioBCP.Repository.Interfaces;
using apiTipoCambioBCP.Repository.Repositories;
using AutoMapper;
using apiTipoCambioBCP.CrossCutting.Entities;
using apiTipoCambioBCP.CrossCutting.Dto;

namespace apiTipoCambioBCP
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
            services.AddDbContext<TipoCambioDBContext>(opt => opt.UseInMemoryDatabase("TipoCambioDB"));
            services.AddControllers();

            var mapper = AutoMapperConfig.RegisterMappings().CreateMapper();
            services.AddSingleton(mapper);

            // Agregando clases para inyeccionn de dependencias
            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<ILoginRepositorio, LoginRepositorio>();
            //
            AutoMapperConfig.RegisterMappings();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["jwt:key"])),
                        ClockSkew = TimeSpan.Zero
                    });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
    public class AutoMapperConfig
    {
        public static MapperConfiguration RegisterMappings()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new EntidadesToDtoProfile());
                //cfg.ValidateInlineMaps = false;
                //cfg.CreateMissingTypeMaps = true;
            });
        }
    }
    public class EntidadesToDtoProfile : Profile
    {
        public EntidadesToDtoProfile()
        {
            CreateMap<UsuarioDto, UsuarioBe>().ReverseMap().ReverseMap();
        }
    }
}

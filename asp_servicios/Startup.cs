﻿using asp_servicios.Controllers;
using lib_aplicaciones.Implementaciones;
using lib_aplicaciones.Interfaces;
using lib_repositorios;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using Microsoft.AspNetCore.Server.Kestrel.Core;

namespace asp_servicios
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public static IConfiguration? Configuration { set; get; }

        public void ConfigureServices(WebApplicationBuilder builder, IServiceCollection services)
        {
            services.Configure<KestrelServerOptions>(x => { x.AllowSynchronousIO = true; });
            services.Configure<IISServerOptions>(x => { x.AllowSynchronousIO = true; });
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddScoped<Conexion, Conexion>();
            // Repositorios}
            services.AddScoped<IAuditoriaRepositorio, AuditoriaRepositorio>();
            services.AddScoped<IDetallesImagenesRepositorio, DetallesImagenesRepositorio>();
            services.AddScoped<IImagenesRepositorio, ImagenesRepositorio>();
            services.AddScoped<ILocalidadesRepositorio, LocalidadesRepositorio>();
            services.AddScoped<ILocalizacionesRepositorio, LocalizacionesRepositorio>();
            services.AddScoped<IPersonasRepositorio, PersonasRepositorio>();
            services.AddScoped<IUbicacionesRepositorio, UbicacionesRepositorio>();
            // Aplicaciones
            services.AddScoped<IDetallesImagenesAplicacion, DetallesImagenesAplicacion>();
            services.AddScoped<IImagenesAplicacion, ImagenesAplicacion>();
            services.AddScoped<ILocalidadesAplicacion,LocalidadesAplicacion>();
            services.AddScoped<ILocalizacionesAplicacion, LocalizacionesAplicacion>();
            services.AddScoped<IPersonasAplicacion, PersonasAplicacion>();
            services.AddScoped<IUbicacionesAplicacion, UbicacionesAplicacion>();
            // Controladores
            services.AddScoped<DetallesImagenesController, DetallesImagenesController>();
            services.AddScoped<ImagenesController, ImagenesController>();
            services.AddScoped<LocalidadesController, LocalidadesController>();
            services.AddScoped<LocalizacionesController, LocalizacionesController>();
            services.AddScoped<PersonasController, PersonasController>();
            services.AddScoped<TokenController, TokenController>();
            services.AddScoped<UbicacionesController, UbicacionesController>();
            services.AddCors(o => o.AddDefaultPolicy(b => b.AllowAnyOrigin()));
        }

        public void Configure(WebApplication app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
            app.UseRouting();
            app.UseCors();
        }
    }
}
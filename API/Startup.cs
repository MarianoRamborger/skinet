using API.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace API
{
    public class Startup //new instance created upon running app
    {
        private readonly IConfiguration _config; //private readonly fields se suelen nombrar con underscore _
        public Startup(IConfiguration config) //configuration is a set of key/value pairs taken from json files (IE appsettings.json)
        {       //Para hacer la depinjection en la usual manner, click der en configuración y "initialize field from parameter"
            _config = config;
          
        }
        
        // public IConfiguration Configuration { get; } this is normally here but no es la usual way en que se hace dependency injection

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) //This is the dependancy injection container
        {
            services.AddControllers();

            services.AddDbContext<StoreContext>(x => 
            x.UseSqlite(_config.GetConnectionString("DefaultConnection")));
            //Añade la conexión a la DB para poder ser usada app-wide.
            //! Es importante que en appsettings.dev.json, ConnectionStrings se llame así, porque GetConnectionString busca esa key
            // ! Por default tiene un lifetime por la duración de la request (Scoped)
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) //here we add MIDDLEWARE. Our http request goes through a pipeline exposed here.
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
}

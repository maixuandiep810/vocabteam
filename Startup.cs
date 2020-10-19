using System.Net.Mime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using vocabteam.Helpers;
using vocabteam.Middlewares;
using vocabteam.Models;
using vocabteam.Models.Repositories;
using vocabteam.Models.Services;


namespace vocabteam
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
            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));

            services.AddCors();
            services.AddControllers().AddNewtonsoftJson(options
            => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            var sqlConnectionString = Configuration.GetConnectionString("MySqlConnection");
            services.AddDbContext<VocabteamContext>(options =>
              options.UseMySQL(sqlConnectionString)
          );

            #region Add Custom Services
            services.AddScoped(typeof(IRepository<>), typeof(MySqlRepository<>));
            services.AddScoped(typeof(IUserRepository), typeof(UserRepository));
            services.AddScoped(typeof(IUserService), typeof(UserService));
            services.AddScoped(typeof(IVocabularyRepository), typeof(VocabularyRepository));
            services.AddScoped(typeof(IVocabularyService), typeof(VocabularyService));
            services.AddScoped(typeof(IPermissionRepository), typeof(PermissionRepository));
            services.AddScoped(typeof(IPermissionService), typeof(PermissionService));
            #endregion

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseRouting();

            // global cors policy
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseJwtMiddleware();
            // app.UseAuthorizationMiddleware();

            app.UseStaticFiles();

            app.UseEndpoints(x => x.MapControllers());
        }


        /// 
        /// HELPER
        /// 


    }


}



// private static bool CheckUsingJwtMiddleware(HttpContext context)
// {
//     bool result = context.Request.Path.Value.StartsWith("/user");
//     return result;
// }

// app.MapWhen(
//     (context) =>
//     {
//         return CheckUsingJwtMiddleware(context);
//     },
//     appProduct =>
//     {
//         appProduct.UseMiddleware<JwtMiddleware>();
//     });


// app.UseMiddleware<JwtMiddleware>();
// 
//             app.MapWhen(context => context.Request.Path.StartsWithSegments("/api"), appBuilder =>
// {
//     appBuilder.UseMiddlewareTwo();
// });
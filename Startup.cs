using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using vocabteam.Helpers;
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
            services.AddScoped(typeof(IVocabularyRepository), typeof(VocabularyRepository));
            services.AddScoped(typeof(IPermissionRepository), typeof(PermissionRepository));
            services.AddScoped(typeof(ICategoryRepository), typeof(CategoryRepository));
            services.AddScoped(typeof(IRolePermissionRepository), typeof(RolePermissionRepository));
            services.AddScoped(typeof(IUserRoleRepository), typeof(UserRoleRepository));
            services.AddScoped(typeof(IRoleRepository), typeof(RoleRepository));
            services.AddScoped(typeof(ITestRepository), typeof(TestRepository)); 
            services.AddScoped(typeof(IUserSettingRepository), typeof(UserSettingRepository)); 


            services.AddScoped(typeof(IUserService), typeof(UserService));
            services.AddScoped(typeof(IVocabularyService), typeof(VocabularyService));
            services.AddScoped(typeof(IPermissionService), typeof(PermissionService));
            services.AddScoped(typeof(ICategoryService), typeof(CategoryService));
            services.AddScoped(typeof(IRoleService), typeof(RoleService));
            services.AddScoped(typeof(ITestService), typeof(TestService));
            services.AddScoped(typeof(IUserSettingService), typeof(UserSettingService));

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
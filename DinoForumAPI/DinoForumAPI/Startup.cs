using DinoForumAPI.DAL.Data;
using DinoForumAPI.DAL.Repositories;
using DinoForumAPI.Entities.Settings;
using DinoForumAPI.Filters;
using DinoForumAPI.Services.PasswordHelper;

namespace DinoForumAPI
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", builder =>
                {
                    builder
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                });
            });

            services.Configure<JsonFileSettings>(_configuration.GetSection("JsonFile"));
            services.AddLogging(loggingBuilder => loggingBuilder.AddConsole());

            services.AddScoped<IDinoForumDbContext, DinoForumDbContext>();
            services.AddScoped<IPasswordHelper, PasswordHelper>();

            services.AddTransient<IUserRepository, UsersRepository>();
            services.AddTransient<IPostRepository, PostRepository>();

            services.AddControllers(options => { options.Filters.Add(new ExceptionHandler(new Logger<ExceptionHandler>(new LoggerFactory()))); });
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseRouting();
            app.UseCors("AllowAll");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "Default",
                    pattern: "api/{controller}/{action}/{id?}");
            });
        }
    }
}

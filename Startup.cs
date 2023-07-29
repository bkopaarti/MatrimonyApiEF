using MatrimonyApiEF.Models;
using MatrimonyApiEF.Models.dssfunctions;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace MatrimonyApiEF
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public string? dbname { get; set; } = "matrimony.db";

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddCors(o =>
                    o
                        .AddPolicy("MyPolicy",
                        builder =>
                        {
                            builder
                                .AllowAnyOrigin()
                                .AllowAnyMethod()
                                .AllowAnyHeader();
                        }));
            services.AddMvc();

            services.AddControllers();
            services
                .AddSwaggerGen(c =>
                {
                    c
                        .SwaggerDoc("v1",
                        new OpenApiInfo { Title = "export", Version = "v1" });
                });

            IConfigurationSection sec =
                Configuration.GetSection("UserSettings");
            services.Configure<UserSettings> (sec);
            services
                .AddDbContext<MatrimonyContext>(options =>
                {
                    Configuration
                        .GetConnectionString("defaultConnectionString");
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app
                .Use((context, next) =>
                {
                    if (
                        context.Request.Headers["database"].ToString() !=
                        String.Empty
                    ) dbname = context.Request.Headers["database"].ToString();
                    return next.Invoke();
                });

            //using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            //{
            //    var context = serviceScope.ServiceProvider.GetRequiredService<RetailDeskContext>();
            //    context.Database.EnsureCreated();
            //}
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app
                    .UseSwaggerUI(c =>
                        c
                            .SwaggerEndpoint("/swagger/v1/swagger.json",
                            "export v1"));
            }

            app.UseCors("MyPolicy");

            app.UseRouting();

            app.UseAuthorization();

            app
                .UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers();
                });
        }
    }
}

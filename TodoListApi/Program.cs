using TodoListApi.Services;
using TodoListApi.Settings;

namespace TodoListApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.Configure<AngularSettings>(builder.Configuration.GetSection("Angular"));
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Configure CORS to allow requests from the Angular application.
            var angularSettings = builder.Configuration.GetSection("Angular").Get<AngularSettings>();
            if (angularSettings != null && !string.IsNullOrEmpty(angularSettings.Host))
            {
                builder.Services.AddCors(options =>
                {
                    options.AddPolicy("AllowAngular",
                        policy => policy.WithOrigins(angularSettings.Host)
                                        .AllowAnyHeader()
                                        .AllowAnyMethod());
                });
            }

            // Register the TodoService as a singleton service based on project scenario.
            builder.Services.AddSingleton<ITodoService, TodoService>();

            var app = builder.Build();
            app.UseCors("AllowAngular");

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}

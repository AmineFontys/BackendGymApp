using GymApp.Data.DAL;
using GymApp.Data.Interfaces;
using GymApp.Data.Repositories;
using GymAppTraining.Api.Interfaces;
using GymAppTraining.Api.Services;
using GymAppTraining.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BackendTraining
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<TrainingContext>(options => options.UseSqlServer(configuration.GetConnectionString("Default")));

            builder.Services.AddControllers();
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                {
                    builder
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowAnyOrigin();  // testing only
                      //.WithOrigins("http://localhost:4200") 
                        //.AllowCredentials();
                });
            });

            builder.Services.AddSignalR();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            RegisterInterfaces(builder);
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors("CorsPolicy");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<MyHub>("/myHub");
            });

            app.Run();
        }

        private static void RegisterInterfaces(WebApplicationBuilder builder)
        {
            builder.Services.AddAutoMapper(typeof(Program).Assembly);  // Adjust the assembly if your profiles are elsewhere

            builder.Services.AddScoped<ITrainingContext, TrainingContext>();
            builder.Services.AddScoped<UserRepository>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<ExerciseRepository>();
            builder.Services.AddScoped<IExerciseRepository, ExerciseRepository>();
            builder.Services.AddScoped<IExerciseService, ExerciseService>();
            builder.Services.AddScoped<TrainingRepository>();
            builder.Services.AddScoped<ITrainingRepository, TrainingRepository>();
            builder.Services.AddScoped<ITrainingService, TrainingService>();
            builder.Services.AddScoped<EnrollmentRepository>();
            builder.Services.AddScoped<IEnrollmentRepository, EnrollmentRepository>();
            builder.Services.AddScoped<IEnrollmentService, EnrollmentService>();
            builder.Services.AddScoped<TrainingScheduleRepository>();
            builder.Services.AddScoped<ITrainingScheduleRepository, TrainingScheduleRepository>();
            builder.Services.AddScoped<ITrainingScheduleService, TrainingScheduleService>();
            builder.Services.AddScoped<IRepository, Repository>();
            builder.Services.AddScoped<IService, Service>();
        }
    }
}

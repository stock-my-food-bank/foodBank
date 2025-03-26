using DotNetEnv;
using Server.Interfaces;
using Server.Repositories;

namespace Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Env.Load();

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("localhost", policy =>
                {
                    policy.WithOrigins("http://localhost:3000").AllowAnyHeader().AllowAnyMethod();

                });
                options.AddPolicy("production", policy =>
                {
                    policy.WithOrigins("http://localhost:4173").AllowAnyHeader().AllowAnyMethod();
                });
            });

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddControllers();
            builder.Services.AddScoped<ICommentsRepository, CommentsRepository>();
            builder.Services.AddScoped<ISurveysRepository, SurveysRepository>();
            builder.Services.AddScoped<IFoodItemsRepository, FoodItemsRepository>();
            builder.Services.AddScoped<IUsersRepository, UsersRepository>();
            builder.Services.AddScoped<ISurveyFoodItemResultsRepository, SurveyFoodItemResultsRepository>();

            var app = builder.Build();

            app.UseCors("localhost");
            app.UseCors("production");

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

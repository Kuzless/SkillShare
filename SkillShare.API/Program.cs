
using Microsoft.EntityFrameworkCore;
using SkillShare.API.Configuration;
using SkillShare.Application.CQRS.Chat.Commands.AddChatCommand;
using SkillShare.Domain.Interfaces;
using SkillShare.Infrastructure;

namespace SkillShare.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddDbContext<DatabaseContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddAutoMapper(typeof(AutoMappingProfile));
            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));
            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(AddChatCommand).Assembly));

            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

            var app = builder.Build();

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

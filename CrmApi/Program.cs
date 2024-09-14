using Application.Interfaces;
using Application.UseCase;
using Infrastructure.Command;
using Infrastructure.Persistence;
using Infrastructure.Querys;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;
using FluentValidation;
using FluentValidation.AspNetCore;
using Application.Validators;
using Application.Request;
using Azure.Core;

namespace CrmApi
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "Marketing CRM", Version = "1.0" });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                options.IncludeXmlComments(xmlPath);
            });


            // custom            
            var connectionString = builder.Configuration["ConnectionString"];

            builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));

            builder.Services.AddScoped<ICampaignTypeQuery, CampaignTypeQuery>();
            builder.Services.AddScoped<ICampaignTypeServices, CampaignTypeServices>();
            builder.Services.AddScoped<IInteractionTypeQuery, InteractionTypeQuery>();
            builder.Services.AddScoped<IInteractionTypeServices, InteractionTypeServices>();
            builder.Services.AddScoped<ITaskStatusQuery, TaskStatusQuery>();
            builder.Services.AddScoped<ITaskStatusServices, TaskStatusServices>();
            builder.Services.AddScoped<IUserQuery, UserQuery>();
            builder.Services.AddScoped<IUserServices, UserServices>();
            builder.Services.AddScoped<IClientCommand, ClientCommand>();
            builder.Services.AddScoped<IClientQuery, ClientQuery>();
            builder.Services.AddScoped<IClientServices, ClientServices>();            
            builder.Services.AddScoped<IProjectQuery, ProjectQuery>();
            builder.Services.AddScoped<IProjectCommand, ProjectCommand>();
            builder.Services.AddScoped<IProjectGetServices, ProjectGetServices>();
            builder.Services.AddScoped<IProjectPostServices, ProjectPostServices>();
            builder.Services.AddScoped<IProjectPatchServices, ProjectPatchServices>();
            builder.Services.AddScoped<IProjectPutServices, ProjectPutServices>();            
            builder.Services.AddScoped<ITaskQuery, TaskQuery>();
            builder.Services.AddScoped<IInteractionQuery, InteractionQuery>();

            // Register the validators
            builder.Services.AddValidatorsFromAssemblyContaining<ProjectRequestValidator>();
            builder.Services.AddValidatorsFromAssemblyContaining<TasksRequestValidator>();
            builder.Services.AddValidatorsFromAssemblyContaining<InteractionsRequestValidator>();
            builder.Services.AddValidatorsFromAssemblyContaining<ClientsRequestValidator>();
            builder.Services.AddScoped<IValidatorHandler<ProjectRequest>, ValidatorHandler<ProjectRequest>>();
            builder.Services.AddScoped<IValidatorHandler<TasksRequest>, ValidatorHandler<TasksRequest>>();
            builder.Services.AddScoped<IValidatorHandler<InteractionsRequest>, ValidatorHandler<InteractionsRequest>>();
            builder.Services.AddScoped<IValidatorHandler<ClientsRequest>, ValidatorHandler<ClientsRequest>>();            



            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint("/swagger/v1/swagger.json", "Marketing CRM v1.0");                    
                });
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}

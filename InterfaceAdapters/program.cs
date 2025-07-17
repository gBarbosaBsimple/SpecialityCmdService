
using Microsoft.EntityFrameworkCore;
using Infrastructure;
using Infrastructure.Repositories;
using Infrastructure.DataModel;
using Domain.Interfaces;
using Domain.Models;
using Domain.IRepository;
using Infrastructure.Resolvers;
using Domain.Factory;
using Application.Services;
using Application.DTO;
using MassTransit;
using InterfaceAdapters.Consumers;
using Domain.Factory.SpecialityFactory;
using Application.DTO.Speciality;
using InterfaceAdapters;
using Application.Interfaces;
using Domain.Factory;
using Domain.Factory.TechnologyFactory;
using Domain.Factory.CollaboratorFactory;
using Application.DTO.Technology;
using Application.DTO.Collaborator;
using Application.IPublishers;
using InterfaceAdapters.Publisher;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
var environment = builder.Environment.EnvironmentName;

builder.Configuration
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{environment}.json", optional: true, reloadOnChange: true)
    .AddEnvironmentVariables();
builder.Services.AddDbContext<AbsanteeContext>(opt =>
    opt.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
    );

//Services
builder.Services.AddTransient<ISpecialityService, SpecialityService>();
builder.Services.AddTransient<ITechnologyService, TechnologyService>();
builder.Services.AddTransient<ICollaboratorService, CollaboratorService>();
builder.Services.AddTransient<IMessagePublisher, MassTransitPublisher>();


//Repositories
builder.Services.AddTransient<ITechnologyRepositoryEF, TechnologyRepositoryEF>();
builder.Services.AddTransient<ISpecialityRepositoryEF, SpecialityRepositoryEF>();
builder.Services.AddTransient<ICollaboratorRepositoryEF, CollaboratorRepositoryEF>();


//Factories
builder.Services.AddTransient<ISpecialityFactory, SpecialityFactory>();
builder.Services.AddTransient<ITechnologyFactory, TechnologyFactory>();
builder.Services.AddTransient<ICollaboratorFactory, CollaboratorFactory>();



//Mappers
builder.Services.AddTransient<SpecialityDataModelConverter>();
builder.Services.AddTransient<CollaboratorDataModelConverter>();

builder.Services.AddAutoMapper(cfg =>
{
    //DataModels
    cfg.AddProfile<DataModelMappingProfile>();

    //DTO
    cfg.CreateMap<Technology, TechnologyDTO>();
    cfg.CreateMap<TechnologyDTO, Technology>();

    cfg.CreateMap<Collaborator, CollaboratorDTO>();
    cfg.CreateMap<CollaboratorDTO, Collaborator>();

    cfg.CreateMap<Speciality, SpecialityDTO>();
    cfg.CreateMap<SpecialityDTO, Speciality>();

});
// MassTransit
var instance = InstanceInfo.InstanceId;

builder.Services.AddMassTransit(x =>
{
    x.AddConsumer<SpecialityCreatedConsumer>();
    x.AddConsumer<SpecialityUpdatedConsumer>();
    x.AddConsumer<TechnologyCreatedConsumer>();
    x.AddConsumer<CollaboratorCreatedConsumer>();

    x.UsingRabbitMq((context, cfg) =>
   {
       cfg.Host("rabbitmq://localhost");
       cfg.ReceiveEndpoint($"specialityMicroService-cmd-{instance}", e =>
       {
           e.ConfigureConsumer<SpecialityCreatedConsumer>(context);
           e.ConfigureConsumer<SpecialityUpdatedConsumer>(context);
           e.ConfigureConsumer<TechnologyCreatedConsumer>(context);
           e.ConfigureConsumer<CollaboratorCreatedConsumer>(context);
       });
   });
});
//sender:


// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.MapOpenApi();
app.UseSwagger();
app.UseSwaggerUI();



app.UseCors(builder => builder
                .AllowAnyHeader()
                .AllowAnyMethod()
                .SetIsOriginAllowed((host) => true)
                .AllowCredentials());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program { }
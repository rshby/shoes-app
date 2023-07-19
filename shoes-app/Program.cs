using Microsoft.EntityFrameworkCore;
using shoes_app.Data;
using shoes_app.GraphQL;
using shoes_app.Repositories;
using shoes_app.Services;

var builder = WebApplication.CreateBuilder(args);

// register db context 
string? connectionString = builder.Configuration.GetConnectionString("MySqlConnect");
builder.Services.AddDbContext<ShoesContext>(x => x.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)), ServiceLifetime.Transient);

// register repository
builder.Services.AddScoped<ShoesRepository>();

// register service
builder.Services.AddScoped<IShoesService, ShoesService>();

// configure graphql
builder.Services.AddGraphQLServer().AddQueryType<ShoesQuery>().AddMutationType<ShoesMutation>();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
   app.UseSwagger();
   app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.MapGraphQL();

app.Run();

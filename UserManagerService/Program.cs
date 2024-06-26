using Microsoft.EntityFrameworkCore;
using UserManagerService.Data;
using UserManagerService.Data.Repositories;
using UserManagerService.Mapping;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "UserManagerService", Version = "v1" });
});

// Database
builder.Services.AddDbContext<UserManagerDbContext>(opt =>
    opt.UseInMemoryDatabase("InMem"));

// Repositories
builder.Services.AddScoped<IProfileRepository, ProfileRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

// Cors
builder.Services.AddCors();

// Mapping
builder.Services.AddAutoMapper(typeof(ProfileMapper));
builder.Services.AddAutoMapper(typeof(UserMapper));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

PrepDb.PrepPopulation(app);

app.Run();
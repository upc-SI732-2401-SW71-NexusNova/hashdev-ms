using FeedManagerService.Data;
using FeedManagerService.Data.Repositories;
using FeedManagerService.Mapping;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "FeedManagerService", Version = "v1" });
});

builder.Services.AddDbContext<FeedManagerDbContext>(opt =>
    opt.UseInMemoryDatabase("InMem"));

builder.Services.AddScoped<IPostRepository, PostRepository>();
builder.Services.AddScoped<ICommentRepository, CommentRepository>();

builder.Services.AddCors();

builder.Services.AddAutoMapper(typeof(PostMapper));
builder.Services.AddAutoMapper(typeof(CommentMapper));

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

using Microsoft.EntityFrameworkCore;
using PaymentManagerService.Data;
using PaymentManagerService.Data.Repositories;
using PaymentManagerService.Mapping;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "PaymentManagerService", Version = "v1" });
});

builder.Services.AddDbContext<PaymentManagerDbContext>(opt =>
    opt.UseInMemoryDatabase("InMem"));

builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();

builder.Services.AddCors();

builder.Services.AddAutoMapper(typeof(PaymentMapper));

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

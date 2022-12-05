using HR_app;
using HR_app.App.Interfaces.DataServices;
using HR_app.Data;
using HR_app.Data.Services;
using HR_app.Interfaces.Services;
using HR_app.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<HRAppDbContext>();
builder.Services.AddAutoMapper(typeof(HRAppAutoMapperProfile));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IPersonService, PersonService>();
builder.Services.AddTransient<IPersonDataService, PersonDataService>();

builder.Services.AddCors(options => options.AddDefaultPolicy(p => p.AllowAnyOrigin()));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();

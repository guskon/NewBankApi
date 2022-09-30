using BankWebAPI.ClassLibrary.Extensions;
using BankWebAPI.Controllers;
using BankWebAPI.Helpers;
using BankWebAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddRepositories(builder.Configuration);
builder.Services.AddTransient<ClientService>();
builder.Services.AddTransient<AccountService>();
builder.Services.AddTransient<AddressService>();
builder.Services.AddTransient<AccountTypeService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ErrorHandlerMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

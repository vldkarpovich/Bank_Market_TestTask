using Bank.API.Middleware;
using Bank.Application;
using Bank.Application.Behaviors;
using Bank.Application.Transactions.CreateTransaction;
using Bank.DAL.Interfaces.Repositories;
using Bank.DAL.Interfaces.Services;
using Bank.DAL.Repositories;
using Bank.DAL.Services;
using Bank.EFModels;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDataContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("ApplicationDataConnection")));
builder.Services.AddMediatR(typeof(CreateTransactionHandler).Assembly);
builder.Services.AddAutoMapper(typeof(AppMappingProfile));

builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
builder.Services.AddScoped<IValidator<CreateTransactionCommand>, CreateTransactionValidation>();
//builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ITransactionSerice, TransactionService>();
builder.Services.AddScoped<ITransactionRepository, TransactionRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ErrorHandlingMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

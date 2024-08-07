using Microsoft.EntityFrameworkCore;
using PinewoodsCrm.API.Data;
using PinewoodsCrm.API.Exceptions;
using PinewoodsCrm.API.Migrations;
using PinewoodsCrm.API.Services;

var builder = WebApplication.CreateBuilder(args);

string context = nameof(CrmContext);
builder.Services
    .AddDbContext<CrmContext>(
        options => options.UseSqlServer(builder.Configuration.GetConnectionString(context) ?? throw new MissingConnectionStringException(context))
    )
    .AddTransient<ICustomersService, CustomersService>()
    .AddSwaggerGen()
    .AddEndpointsApiExplorer()
    .AddControllers();

var app = builder.Build();

using var scope = app.Services.CreateScope();

SeedData.Initialize(scope.ServiceProvider);

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

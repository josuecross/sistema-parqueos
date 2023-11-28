using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using API_Proyecto3.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<API_Proyecto3Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("API_Proyecto3Context") ?? throw new InvalidOperationException("Connection string 'API_Proyecto3Context' not found.")));

// Add services to the container.
builder.Services.AddControllers(options =>
    options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true);
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

app.Run();

using BlogAPI.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Cihaz içi bir veritabaný kurup test edilmesi için bir DbContext enjeksiyonu
//builder.Services.AddDbContext<ArticlesAPIDbContext>(options => options.UseInMemoryDatabase("ArticlesDb"));
builder.Services.AddDbContext<ArticlesAPIDbContext>(options => 
options.UseSqlServer(builder.Configuration.GetConnectionString("ArticlesApiConnectionString")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

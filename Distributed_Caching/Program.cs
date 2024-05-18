using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = "127.0.0.1:1453"; // veya Redis sunucunuzun IP ve baðlantý noktasý
    options.InstanceName = "Distributed_Caching_________"; // Opsiyonel: Birden çok uygulamanýn ayný Redis sunucusunu kullanmasýna izin verirken, her bir uygulama için benzersiz bir önek saðlar.
});


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

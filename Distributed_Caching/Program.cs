using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = "127.0.0.1:1453"; // veya Redis sunucunuzun IP ve ba�lant� noktas�
    options.InstanceName = "Distributed_Caching_________"; // Opsiyonel: Birden �ok uygulaman�n ayn� Redis sunucusunu kullanmas�na izin verirken, her bir uygulama i�in benzersiz bir �nek sa�lar.
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

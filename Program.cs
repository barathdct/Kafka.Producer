using Kafka.Producer.Config;
using Kafka.Producer.Services;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;

// Add services to the container.
var kafkaConfiguration = configuration.GetSection(nameof(KafkaConfiguration)).Get<KafkaConfiguration>();
builder.Services.AddSingleton(kafkaConfiguration);
builder.Services.AddSingleton<Producer>();

builder.Services.AddControllers();
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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

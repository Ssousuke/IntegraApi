using IntegraApi.Api.Interfaces;
using IntegraApi.Api.Mappings;
using IntegraApi.Api.Rest;
using IntegraApi.Api.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IEnderecoServices, EnderecoServices>();
// builder.Services.AddSingleton<IBancoServices, BancoServices>();
builder.Services.AddSingleton<IBrasilApiServices, BrasilApiRest>();

builder.Services.AddAutoMapper(typeof(EnderecoMapping));

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

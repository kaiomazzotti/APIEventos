using APIEventos.Service.Interface;
using APIEventos.Service.Service;
using CityEvent.Service.Service;
using APIEventos.Infra.Data.Repository;
using APIEventos.Filter;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using APIEventos.Service.Entity;
using APIEventos.Service.Dto;
using AutoMapper;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddMvc(options =>
{
    options.Filters.Add(typeof(ExcecaoGeralFilter));
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var key = Encoding.ASCII.GetBytes(Environment.GetEnvironmentVariable("SECRET_KEY"));
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = true,
        ValidIssuer = "APIClientes.com",
        ValidateAudience = true,
        ValidAudience = "APIEvents.com"
    };
});

builder.Services.AddScoped<ICityEventRepository, CityEventRepository>();
builder.Services.AddScoped<IEventReservationRepository, EventReservationRepository>();
builder.Services.AddScoped<ICityEventService, CityEventService>();
builder.Services.AddScoped<IEventReservationService, EventReservationServices>();

MapperConfiguration mapperConfig = new(mc =>
{
    mc.CreateMap<CityEventEntity, CityEventDto>().ReverseMap();

    mc.CreateMap<EventReservationEntity, EventReservationDto>().ReverseMap();
}
          );


IMapper mapper = mapperConfig.CreateMapper();


builder.Services.AddSingleton(mapper);

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

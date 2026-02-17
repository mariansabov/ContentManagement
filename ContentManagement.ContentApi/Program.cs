using AutoMapper;
using ContentManagement.Application.Common.Mappings;
using ContentManagement.Application.Features.Announcements;
using ContentManagement.ContentApi.Extensions;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;
// 
// // Add services to the container
// 
builder.Services.AddDatabase(configuration);

builder.Services.AddControllers();

// ------------------------
// MediatR
// ------------------------
builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(typeof(CreateAnnouncementCommand).Assembly));

builder.Services.AddAutoMapper(cfg => { }, typeof(AnnouncementProfile).Assembly);

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

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
